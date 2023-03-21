using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MileStone4_CRUD_Using_MongoDb.Models
{
    public class Product
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("productName")]
        public string productName { get; set; }


        public int productCost { get; set; }


        public int productQuantity { get; set; }


        public string productCategory { get; set; }

    }
}
