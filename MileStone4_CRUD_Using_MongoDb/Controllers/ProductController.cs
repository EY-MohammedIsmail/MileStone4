using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MileStone4_CRUD_Using_MongoDb.Commands;
using MileStone4_CRUD_Using_MongoDb.Models;
using MileStone4_CRUD_Using_MongoDb.Query;

namespace MileStone4_CRUD_Using_MongoDb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("angular")]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("getAllProducts")]
        public async Task<IActionResult> GetAllProducts()
        {
            var productList = await _mediator.Send(new GetAllProductsQuery());
            return Ok(productList);
        }

        [HttpGet]
        [Route("getProductById")]
        public async Task<IActionResult> GetProductById(string id)
        {
            var product = await _mediator.Send(new GetProductByIdQuery(id));
            return Ok(product);
        }

        [HttpPost]
        [Route("createProduct")]
        public async Task<IActionResult> CreateProduct([FromBody] Product newProduct)
        {
            var message = await _mediator.Send(new AddProductCommand(newProduct));
            return StatusCode(201);
        }
        [HttpPut]
        [Route("updateProduct")]
        public async Task<IActionResult> UpdateProduct([FromBody] Product updateProduct)
        {
            await _mediator.Send(new UpdateProductCommand(updateProduct));
            return StatusCode(201);
        }

        [HttpDelete]
        [Route("deleteProduct")]
        public async Task<IActionResult> DeleteProduct(string id)
        {
            await _mediator.Send(new DeleteProductCommand(id));
            return StatusCode(200);

        }
    }
}
