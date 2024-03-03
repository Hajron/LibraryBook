using System;


namespace LibrarySystem_V3;
public class Book
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public string ISBN { get; set; }
    public bool IsCheckedOut { get; set; }
    
    public Book(string title, string author, string isbn)
    {
        Title = title;
        Author = author;
        ISBN = isbn;
    }

    public static Book CreateBook()
    {
        Console.WriteLine("Oppgi tittel på bok: ");
        string title = Console.ReadLine();
        
        Console.WriteLine(("Oppgi forfatter: "));
        string author = Console.ReadLine();
        
        Console.WriteLine("Oppgi ISBN nummer: ");
        string isbn = Console.ReadLine();

        return new Book(title, author, isbn);
    }
}