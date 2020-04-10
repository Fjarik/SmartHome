using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.IManagers;
using Backend.Managers;
using DataAccess.IRepositories;
using DataAccess.Repositories;
using DataService.IServices;
using DataService.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Backend.Other
{
	public static class AppExtensions
	{
		public static IServiceCollection AddRepositories(this IServiceCollection services)
		{
			return services
				   .AddScoped<IUserRepository, UserRepository>()
				   .AddScoped<IFoodRepository, FoodRepository>()
				   .AddScoped<ICategoryRepository, CategoryRepository>()
				   .AddScoped<IMealRepository, MealRepository>()
				   .AddScoped<ISideDishRepository, SideDishRepository>()
				   .AddScoped<ITokenRepository, TokenRepository>();
		}

		public static IServiceCollection AddServices(this IServiceCollection services)
		{
			return services
				   .AddScoped<IUserService, UserService>()
				   .AddScoped<ITokenService, TokenService>()
				   .AddScoped<IFoodService, FoodService>()
				   .AddScoped<ICategoryService, CategoryService>()
				   .AddScoped<IMealService, MealService>()
				   .AddScoped<ISideDishService, SideDishService>()
				   .AddScoped<IAuthService, AuthService>();
		}

		public static IServiceCollection AddManagers(this IServiceCollection services)
		{
			return services
				.AddScoped<IAuthManager, AuthManager>();
		}
	}
}