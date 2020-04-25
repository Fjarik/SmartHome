using System.Text;
using System.Threading.Tasks;
using Backend.GraphQL.Schemas;
using Backend.IManagers;
using Backend.Other;
using Backend.Other.Auth;
using DataAccess.Contexts;
using DataService;
using GraphQL;
using GraphQL.Server;
using GraphQL.Server.Ui.Playground;
using GraphQL.Server.Ui.Voyager;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;

namespace Backend
{
	public class Startup
	{
		public Startup(IConfiguration configuration, IWebHostEnvironment environment)
		{
			Configuration = configuration;
			Environment = environment;
		}

		private IConfiguration Configuration { get; }
		private IWebHostEnvironment Environment { get; }
		private readonly string _myAllowSpecificOrigins = "_myAllowSpecificOrigins";

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			var appSettingsSection = Configuration.GetSection(nameof(AppSettings));
			services.Configure<AppSettings>(appSettingsSection);
			services.Configure<GraphQLOptions>(this.Configuration.GetSection("GraphQL"));

			services.Configure<CookiePolicyOptions>(options => {
				// This lambda determines whether user consent for non-essential cookies is needed for a given request.
				options.CheckConsentNeeded = context => true;
				options.MinimumSameSitePolicy = SameSiteMode.None;
			});

			services.AddDbContext<MainContext>(opt =>
												   opt.UseSqlServer(Configuration.GetConnectionString("MainDatabase"))
				//.EnableSensitiveDataLogging()
				//.EnableDetailedErrors()
			);

			// CORS
			services.AddCors(opt => {
				opt.AddDefaultPolicy(builder => builder.AllowAnyOrigin()
													   .AllowAnyHeader()
													   .AllowAnyMethod());

				opt.AddPolicy(_myAllowSpecificOrigins,
							  builder => {
								  builder.WithOrigins("http://localhost:3000", "https://smarthome.now.sh")
										 .AllowAnyHeader()
										 .AllowAnyMethod()
										 .AllowCredentials();
							  });
			});

			services.AddHttpContextAccessor()
					.AddRepositories()
					.AddServices()
					.AddManagers();

			// GraphQL
			services.AddScoped<IDependencyResolver>(s => new FuncDependencyResolver(s.GetRequiredService))
					.AddScoped<AppSchema>()
					.AddGraphQL(options => {
						var graphQLopts = this.Configuration
											  .GetSection("GraphQL")
											  .Get<GraphQLOptions>();
						// Set some limits for security, read from configuration.
						options.ComplexityConfiguration = graphQLopts.ComplexityConfiguration;
						// Enable GraphQL metrics to be output in the response, read from configuration.
						options.EnableMetrics = graphQLopts.EnableMetrics;
						// Show stack traces in exceptions. Don't turn this on in production.
						options.ExposeExceptions = this.Environment.IsDevelopment();
					})
					.AddGraphTypes(ServiceLifetime.Scoped)
					.AddRelayGraphTypes()
					.AddRelayGraphTypes()
					.AddUserContextBuilder<GraphQLUserContextBuilder>()
					.AddDataLoader();

			services.Configure<KestrelServerOptions>(options => { options.AllowSynchronousIO = true; })
					.Configure<IISServerOptions>(options => { options.AllowSynchronousIO = true; })
					.Configure<FormOptions>(options => { options.MultipartBodyLengthLimit = long.MaxValue; })
					.AddRazorPages();

			// JWT
			var appSettings = appSettingsSection.Get<AppSettings>();
			var key = Encoding.UTF8.GetBytes(appSettings.Secret);
			services.AddAuthentication(options => {
				options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
				options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
			}).AddJwtBearer(options => {
				options.RequireHttpsMetadata = false;
				options.SaveToken = true;
				options.TokenValidationParameters = new TokenValidationParameters {
					ValidateIssuerSigningKey = true,
					ValidateIssuer = true,
					ValidateAudience = true,
					ValidateLifetime = true,
					RequireExpirationTime = true,
					ValidIssuer = appSettings.Issuer,
					ValidAudience = appSettings.Audience,
					IssuerSigningKey = new SymmetricSecurityKey(key),
				};
				options.Events = new JwtBearerEvents {
					OnAuthenticationFailed = ctx => {
						if (ctx.Exception is SecurityTokenExpiredException) {
							ctx.Response.Headers.Add("Token-Expired", "true");
						}
						return Task.CompletedTask;
					}
				};
			});

			// Auth
			services.AddAuthentication(options => {
				options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
				options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
			});
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment()) {
				app.UseDeveloperExceptionPage();
			} else {
				app.UseExceptionHandler("/Home/Error");
				app.UseHsts();
			}

			//app.UseHttpsRedirection();

			app.UseCors(_myAllowSpecificOrigins)
			   .UseGraphQL<AppSchema>()
			   .UseGraphQLPlayground(new GraphQLPlaygroundOptions {
				   GraphQLEndPoint = "/graphql",
				   Path = "/",
			   })
			   .UseGraphQLVoyager(new GraphQLVoyagerOptions {
				   GraphQLEndPoint = "/graphql",
				   Path = "/voyager",
			   })
			   .UseWebSockets()
			   .UseRouting()
			   .UseAuthentication()
			   .UseAuthorization();
		}
	}
}