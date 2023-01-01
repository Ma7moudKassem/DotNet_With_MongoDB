namespace DotNet_With_MongoDB;

public class Employee
{
    [BsonId, BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    public string Name { get; set; }

    [BsonElement("items"), JsonPropertyName("items")]
    public List<string> SalariesIds { get; set; }
}
