using Microsoft.AspNetCore.Mvc;
using ProductsProject.Core.CQRS.Products.Commands.Models;
using ProductsProject.Core.CQRS.Products.Queries.Models;
using ProductsProject.Data.AppMetaData;
using SchoolManagementSystem.api.Base;

namespace ProductsManagementSystem.Controllers
{
    [ApiController]
    public class ProductController : AppControllerBase
    {


        [HttpGet(Router.Product.GetProduct)]
        public async Task<IActionResult> GetProduct(int id)
            => NewResult(await Mediator.Send(new GetProductByIdQuery() { ProductId = id }));


        [HttpGet(Router.Product.GetAllProducts)]
        public async Task<IActionResult> GetAllProducts()
            => NewResult(await Mediator.Send(new GetAllProducts()));

        [HttpPost(Router.Product.AddProduct)]
        public async Task<IActionResult> AddProduct([FromForm] AddProductCommand addProduct)
            => NewResult(await Mediator.Send(addProduct));

        [HttpPost(Router.Product.AddCategoriesToProduct)]
        public async Task<IActionResult> AddCategoriesToProduct(AddCategoriesToProductCommand addCategoriesToProduct)
            => NewResult(await Mediator.Send(addCategoriesToProduct));

        [HttpPut(Router.Product.UpdateProduct)]
        public async Task<IActionResult> UpdateProduct([FromForm] UpdateProductCommand updateProduct)
           => NewResult(await Mediator.Send(updateProduct));

        [HttpPut(Router.Product.SetProductCategories)]
        public async Task<IActionResult> SetProductCategories(SetProductCategoriesCommand setProductCategories)
            => NewResult(await Mediator.Send(setProductCategories));

        [HttpDelete(Router.Product.DeleteProduct)]
        public async Task<IActionResult> DeleteProduct(int id)
          => NewResult(await Mediator.Send(new DeleteProductCommand() { ProductId = id }));
    }
}
