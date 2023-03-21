using MediatR;
using MileStone4_CRUD_Using_MongoDb.Models;

namespace MileStone4_CRUD_Using_MongoDb.Commands
{
    public record AddProductCommand(Product newProduct):IRequest<string>
    {
    }
}
