using MediatR;
using MileStone4_CRUD_Using_MongoDb.Commands;
using MileStone4_CRUD_Using_MongoDb.DataAccess;

namespace MileStone4_CRUD_Using_MongoDb.handler
{
    public class UpdateProductHandler : IRequestHandler<UpdateProductCommand, string>
    {
        private readonly IProduct _product;

        public UpdateProductHandler(IProduct product)
        {
            _product = product;
        }

        public Task<string> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_product.UpdateProduct(request.updateProduct));
        }
    }
}
