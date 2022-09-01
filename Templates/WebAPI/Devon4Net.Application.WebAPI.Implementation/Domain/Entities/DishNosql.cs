using Devon4Net.Application.WebAPI.Implementation.Domain.Entities;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

public class DishNosql
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? _id { get; set; }

    [BsonElement("Name")]
    public string Name { get; set; }

    [BsonElement("Price")]
    public decimal Price { get; set; }

    [BsonElement("Description")]
    public string Description { get; set; }

    [BsonElement("Image")]
    public ImageNosql[] Image { get; set; }

    [BsonElement("Category")]
    public CategoryNosql[][] Category { get; set; }
}

