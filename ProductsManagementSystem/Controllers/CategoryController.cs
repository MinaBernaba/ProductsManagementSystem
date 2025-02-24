using Microsoft.AspNetCore.Mvc;
using ProductsProject.Core.CQRS.Categories.Commands.Models;
using ProductsProject.Core.CQRS.Categories.Queries.Models;
using ProductsProject.Data.AppMetaData;
using SchoolManagementSystem.api.Base;

namespace ProductsManagementSystem.Controllers
{
    [ApiController]
    public class CategoryController : AppControllerBase
    {

        [HttpGet(Router.Category.GetAllCategories)]
        public async Task<IActionResult> GetAllCategories()
         => NewResult(await Mediator.Send(new GetAllCategories()));

        [HttpGet(Router.Category.GetCategory)]
        public async Task<IActionResult> GetCategory(int id)
          => NewResult(await Mediator.Send(new GetCategoryByIdQuery() { CategoryId = id }));


        [HttpPost(Router.Category.AddCategory)]
        public async Task<IActionResult> AddCategory(AddCategoryCommand addCategory)
           => NewResult(await Mediator.Send(addCategory));


        [HttpPut(Router.Category.UpdateCategory)]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryCommand updateCategory)
           => NewResult(await Mediator.Send(updateCategory));

        [HttpDelete(Router.Category.DeleteCategory)]
        public async Task<IActionResult> DeleteCategory(int id)
           => NewResult(await Mediator.Send(new DeleteCategoryCommand() { CategoryId = id }));
    }
}
