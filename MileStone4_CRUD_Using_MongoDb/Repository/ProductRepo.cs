using Microsoft.Extensions.Options;
using MileStone4_CRUD_Using_MongoDb.DataAccess;
using MileStone4_CRUD_Using_MongoDb.Models;
using MongoDB.Driver;

namespace MileStone4_CRUD_Using_MongoDb.Repository
{
    public class ProductRepo:IProduct
    {
        private readonly IMongoCollection<Product> _products;

        public ProductRepo(IOptions<ProductsDatabaseSettings> productDatabaseSettings)
        {
            var mongoClient = new MongoClient(productDatabaseSettings.Value.ConectionString);
            var mongoDatabase = mongoClient.GetDatabase(productDatabaseSettings.Value.DatabasName);
            _products = mongoDatabase.GetCollection<Product>(productDatabaseSettings.Value.ProductsCollectionName);
        }

      
        

        public List<Product> GetAll()
        {
             return _products.Find(_ => true).ToList(); 
        }

        public Product GetById(string id)
        {
           return _products.Find(x => x.Id == id).FirstOrDefault(); ;
        }

        public string CreateNewProduct(Product newProduct)
        {
            _products.InsertOne(newProduct);
            return "Added Succefully";
            
        }

        public string UpdateProduct(Product productUpdate)
        {
           _products.ReplaceOneAsync(x => x.Id == productUpdate.Id, productUpdate);
            return "Updated Successfully";
        }

        public string DeleteProduct(string id)
        {
            _products.DeleteOneAsync(x => x.Id == id);
            return "Deleted successfully";
        }

        
    }
}
