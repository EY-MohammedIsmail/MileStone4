using MediatR;
using MileStone4_CRUD_Using_MongoDb.DataAccess;
using MileStone4_CRUD_Using_MongoDb.Models;
using MileStone4_CRUD_Using_MongoDb.Query;

namespace MileStone4_CRUD_Using_MongoDb.handler
{
    public class GetAllProductsHandler : IRequestHandler<GetAllProductsQuery, List<Product>>
    {
        private readonly IProduct _product;

        public GetAllProductsHandler(IProduct product)
        {
            _product = product;
        }

        public Task<List<Product>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_product.GetAll());
        }
    }
}
