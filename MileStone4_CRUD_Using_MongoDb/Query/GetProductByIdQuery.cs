using MediatR;
using MileStone4_CRUD_Using_MongoDb.Models;

namespace MileStone4_CRUD_Using_MongoDb.Query
{
    public record GetProductByIdQuery(string id):IRequest<Product>
    {
    }
}
