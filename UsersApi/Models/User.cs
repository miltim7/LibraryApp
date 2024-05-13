public class User
{
    public int Id { get; set; }
    public string Username { get; set; }
    public DateTime BirthDate { get; set; }
    public IEnumerable<Book> Books { get; set; }
}