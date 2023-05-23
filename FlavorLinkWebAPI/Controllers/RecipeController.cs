using DataMsSql;
using Domain.Models;
using FlavorLinkWebAPI.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using System.Data.SqlClient;

namespace FlavorLinkWebAPI.Controllers
{

	[Route("api/[controller]")]
	[ApiController]
	public class RecipeController : ControllerBase
	{

		private readonly IRecipeService _recipeService;

		public RecipeController(IRecipeService recipeService)
		{
			_recipeService = recipeService;
		}

		[HttpGet]
		public IEnumerable<Recipe> Recipes()
		{
			return _recipeService.GetAll();
		}

		[HttpGet("{id}")]
		public Recipe GetRecipe(int id)
		{
			return _recipeService.GetById(id);
		}

		[HttpDelete("{id}")]
		
		public void Delete(int id) 
		{
			_recipeService.Delete(id);
		}

		[HttpPost("")]
		public Recipe CreateRecipe(Recipe recipe)
		{
			return _recipeService.Add(recipe);
		}
	}
}



