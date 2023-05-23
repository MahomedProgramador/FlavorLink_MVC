using DataMsSql;
using Domain.Models;
using FlavorLinkWebAPI.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using System.Data.SqlClient;

namespace FlavorLinkWebAPI.Controllers
{

	//POR ISTO NO RECIPEREPOSITORY
	[Route("api/[controller]")]
	[ApiController]
	public class RecipeController : ControllerBase
	{
		//IRecipeS
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

		[HttpDelete("{id}")]
		
		public void Delete(int id) 
		{
			_recipeService.Delete(id);
		}
	}
}



