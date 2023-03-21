using MileStone4_CRUD_Using_MongoDb.Models;

namespace MileStone4_CRUD_Using_MongoDb.DataAccess
{
    public interface IProduct
    {
        List<Product> GetAll();
        Product GetById(string id);
        string CreateNewProduct(Product newProduct);
        string UpdateProduct(Product productUpdate);
        string DeleteProduct(string id);
    }
}
