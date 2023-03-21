using MediatR;
using MileStone4_CRUD_Using_MongoDb.DataAccess;
using MileStone4_CRUD_Using_MongoDb.Models;
using MileStone4_CRUD_Using_MongoDb.Query;

namespace MileStone4_CRUD_Using_MongoDb.handler
{
    public class GetProductByIdHandler : IRequestHandler<GetProductByIdQuery, Product>
    {
        private readonly IProduct _product;

        public GetProductByIdHandler(IProduct product)
        {
            _product = product;
        }

        public Task<Product> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_product.GetById(request.id));
        }
    }
}
