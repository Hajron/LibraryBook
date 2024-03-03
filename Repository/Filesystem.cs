using System;
using System.Collections.Generic;
using System.IO;
using LibrarySystem_V3;
using Newtonsoft.Json;

namespace LibrarySystem_V3.Repository;

public class Filesystem
{
    private const string FilePath = "books.json";
    private List<Book> _books;

    public Filesystem()
    {
        if (File.Exists(FilePath))
        {
            var content = File.ReadAllText(FilePath);
            _books = JsonConvert.DeserializeObject<List<Book>>(content);
        }
        else
        {
            _books = new List<Book>();
        }
    }

    public void SaveChanges()
    {
        var content = JsonConvert.SerializeObject(_books);
        File.WriteAllText(FilePath, content);
    }

    public void AddBook(Book book)
    {
        book.Id = _books.Any() ? _books.Max(b => b.Id) + 1 : 1;
        _books.Add(book);
        SaveChanges();
    }

    public void RemoveBook(int id)
    {
        var book = _books.FirstOrDefault(b => b.Id == id);
        if (book != null)
        {
            _books.Remove(book);
            SaveChanges();
        }
    }

    public List<Book> GetAllBooks()
    {
        return _books;
    }

    public Book GetBook(int id)
    {
        return _books.FirstOrDefault(b => b.Id == id);
    }

    public Book GetBook(string isbn)
    {
        return _books.FirstOrDefault(b => b.ISBN == isbn);
    }
}
