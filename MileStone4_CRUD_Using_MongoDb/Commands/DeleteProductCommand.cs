using MediatR;

namespace MileStone4_CRUD_Using_MongoDb.Commands
{
    public record DeleteProductCommand(string id):IRequest<string>
    {
    }
}
