using System.Data.SqlClient;
using Dapper;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]/[action]")]
public class UsersController : ControllerBase
{
    // private const string connectionString = $"Server=localhost;Database=LibraryDB;User Id=admin;Password=admin;";
    private const string connectionString = $"Server=localhost;Database=LibraryDB;User Id=sa;Password=admin;";

    [HttpGet]
    public async Task<User> GetDetailedUser(int id)
    {
        var connection = new SqlConnection(connectionString);

        var sql = "select * from Users where Id = Id";

        var user = await connection.QueryFirstOrDefaultAsync<User>(sql, new { Id = id });

        user.Books = await GetBooks(id);

        return user;
    }

    [HttpGet]
    public async Task<List<Book>> GetBooks(int id)
    {
        var httpClient = new HttpClient();

        var response = await httpClient.GetFromJsonAsync<List<Book>>($"http://localhost:5273/api/Books/GetBookByUserId?id={id}");

        return response;
    }
}