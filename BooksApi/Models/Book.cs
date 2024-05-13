using MongoDB.Bson;

public class Book 
{
    public ObjectId _id { get; set; }
    public int UserId { get; set; }
    public string Name { get; set; }
    public string Author { get; set; }
    public int Pages { get; set; }
    public string[] Tags { get; set; }
}