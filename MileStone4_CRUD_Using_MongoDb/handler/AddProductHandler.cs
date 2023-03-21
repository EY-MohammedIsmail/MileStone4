using MediatR;
using MileStone4_CRUD_Using_MongoDb.Commands;
using MileStone4_CRUD_Using_MongoDb.DataAccess;

namespace MileStone4_CRUD_Using_MongoDb.handler
{
    public class AddProductHandler : IRequestHandler<AddProductCommand, string>
    {
        private readonly IProduct _product;

        public AddProductHandler(IProduct product)
        {
            _product = product;
        }

        public Task<string> Handle(AddProductCommand request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_product.CreateNewProduct(request.newProduct));
        }
    }
}
