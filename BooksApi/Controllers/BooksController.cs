using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

[ApiController]
[Route("api/[controller]/[action]")]
public class BooksController() : ControllerBase
{
    [HttpGet]
    public async Task<IEnumerable<Book>> GetBookByUserId(int id)
    {
        var mongoDbConnectionoString = "mongodb://localhost:27017";

        var client = new MongoClient(mongoDbConnectionoString);

        var booksDb = client.GetDatabase("BooksDb");

        booksDb.CreateCollection("BooksCollection");

        var booksCollection = booksDb.GetCollection<Book>("BooksCollection");

        return await booksCollection.Find(Builders<Book>.Filter.Eq("UserId", id)).ToListAsync();
    }
}