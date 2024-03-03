using System;
using LibrarySystem_V3;
using System.Collections.Generic;
using LibrarySystem_V3.Repository;

namespace LibrarySystem_V3.Services
{
    public class Library
    {
        private Filesystem _filesystem;

        public Library(Filesystem filesystem)
        {
            _filesystem = filesystem;
        }

        public List<Book> GetAllBooks()
        {
            return _filesystem.GetAllBooks();
        }

        public void AddBook(Book book)
        {
            _filesystem.AddBook(book);
            Console.WriteLine($"Boken {book.Title} er lagt til i biblioteket.");
        }

        public void RemoveBook(string isbn)
        {
            Book bookToRemove = _filesystem.GetBook(isbn);
            if (bookToRemove != null)
            {
                _filesystem.RemoveBook(bookToRemove.Id);
                Console.WriteLine($"Boken '{bookToRemove.Title}' er fjernet fra biblioteket.");
            }
            else
            {
                Console.WriteLine($"Boken med ISBN '{isbn}' ble ikke funnet i biblioteket.");
            }
        }

        public void CheckOutBook(string isbn)
        {
            Book bookToCheckOut = _filesystem.GetBook(isbn);
            if (bookToCheckOut != null)
            {
                bookToCheckOut.IsCheckedOut = true;
                _filesystem.SaveChanges();
                Console.WriteLine($"Boken '{bookToCheckOut.Title}' er sjekket ut.");
            }
            else
            {
                Console.WriteLine($"Boken med ISBN '{isbn}' ble ikke funnet i biblioteket.");
            }
        }

        public void ReturnBook(Book book)
        {
            book.IsCheckedOut = false;
            _filesystem.AddBook(book);
            _filesystem.SaveChanges();
            Console.WriteLine($"Boken '{book.Title}' er returnert.");
        }

        public void PrintBookInfo(Book book)
        {
            Console.WriteLine($"Tittel: {book.Title}");
            Console.WriteLine($"Forfatter: {book.Author}");
            Console.WriteLine($"ISBN: {book.ISBN}");

            if (book is EBook ebook)
            {
                Console.WriteLine($"Filsti: {ebook.FilePath}");
                Console.WriteLine($"Filformat: {ebook.FileFormat}");
            }

            Console.WriteLine();
        }
    }
}
