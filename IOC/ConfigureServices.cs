﻿using DataMsSql;
using Domain.Models;
using Microsoft.Extensions.DependencyInjection;
using Services;
using Services.Contracts;

namespace IOC
{
	public static class ConfigureServices
	{

		public static void ConfigureWebAPI(this IServiceCollection serviceCollection)
		{
			serviceCollection.ConfigureCommon();
		}

		private static void ConfigureCommon(this IServiceCollection serviceCollection)
		{
			serviceCollection.AddScoped<IRecipeRepository, RecipeRepository>();
			serviceCollection.AddScoped<IRecipeService, RecipeService>();
			serviceCollection.AddScoped<IIngredientService, IngredientService>();
			serviceCollection.AddScoped<IIngredientRepository, IngredientRepository>();
			
		}
	}
}
