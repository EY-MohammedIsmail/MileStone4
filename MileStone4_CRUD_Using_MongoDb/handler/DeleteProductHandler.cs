using MediatR;
using MileStone4_CRUD_Using_MongoDb.Commands;
using MileStone4_CRUD_Using_MongoDb.DataAccess;

namespace MileStone4_CRUD_Using_MongoDb.handler
{
    public class DeleteProductHandler : IRequestHandler<DeleteProductCommand, string>
    {
        private readonly IProduct _product;

        public DeleteProductHandler(IProduct product)
        {
            _product = product;
        }

        public Task<string> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_product.DeleteProduct(request.id));
        }
    }
}
