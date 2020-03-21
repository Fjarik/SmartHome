using System.Text;
using Backend.GraphQL.Schemas;
using Backend.Other;
using DataAccess.Contexts;
using DataAccess.IManagers;
using DataAccess.Managers;
using DataService.IServices;
using DataService.Services;
using GraphQL;
using GraphQL.Server;
using GraphQL.Server.Ui.Playground;
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
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			var appSettingsSection = Configuration.GetSection(nameof(AppSettings));
			services.Configure<AppSettings>(appSettingsSection);

			services.Configure<CookiePolicyOptions>(options => {
				// This lambda determines whether user consent for non-essential cookies is needed for a given request.
				options.CheckConsentNeeded = context => true;
				options.MinimumSameSitePolicy = SameSiteMode.None;
			});

			services.AddDbContext<MainContext>(opt =>
												   opt.UseSqlServer(Configuration.GetConnectionString("MainDatabase")));

			services.AddHttpContextAccessor();

#region Managers

			services.AddScoped<IUserManager, UserManager>();

#endregion

#region Services

			services.AddScoped<IUserService, UserService>();

#endregion


			// GraphQL
			services.AddScoped<IDependencyResolver>(s => new FuncDependencyResolver(s.GetRequiredService));
			services.AddScoped<AppSchema>();

			services.AddGraphQL(options => {
						options.EnableMetrics = true;
						options.ExposeExceptions = true;
					}).AddGraphTypes(ServiceLifetime.Scoped)
					.AddUserContextBuilder(ctx => ctx.User)
					.AddDataLoader();

			// kestrel
			services.Configure<KestrelServerOptions>(options => { options.AllowSynchronousIO = true; });

			// IIS
			services.Configure<IISServerOptions>(options => { options.AllowSynchronousIO = true; });

			services.Configure<FormOptions>(options => { options.MultipartBodyLengthLimit = long.MaxValue; });
			// MVC
			services.AddRazorPages().AddNewtonsoftJson();
			services.AddControllers();


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
					IssuerSigningKey = new SymmetricSecurityKey(key)
				};
			});

			services.AddAuthentication(options => {
				options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
				options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
			});

			services.AddMvc();
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

			app.UseGraphQL<AppSchema>();
			app.UseGraphQLPlayground(options: new GraphQLPlaygroundOptions());

			app.UseWebSockets();

			app.UseRouting();

			app.UseAuthentication();
			app.UseAuthorization();

			app.UseEndpoints(endpoints => {
				endpoints.MapControllers();
				endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
			});
		}
	}
}