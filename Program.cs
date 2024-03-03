using System;
using LibrarySystem_V3;
using LibrarySystem_V3.Services;
using LibrarySystem_V3.Repository;

Filesystem filesystem = new Filesystem();
Library library = new Library(filesystem);

while (true)
{
    Console.WriteLine("Velg en handling:");
    Console.WriteLine("1. Legg til bok");
    Console.WriteLine("2. Fjern bok");
    Console.WriteLine("3. Sjekk ut bok");
    Console.WriteLine("4. Returner bok");
    Console.WriteLine("5. Vis alle bøker");
    Console.WriteLine("6. Avslutt");

    string choice = Console.ReadLine();

    switch (choice)
    {
        case "1":
            Book newBook = Book.CreateBook();
            library.AddBook(newBook);
            filesystem.SaveChanges();
            break;
        case "2":
            Console.WriteLine("Hvilken bok vil du fjerne? Fjern med hjelp av ISBN nummer.");
            string isbnRemove = Console.ReadLine();
            library.RemoveBook(isbnRemove);
            filesystem.SaveChanges();
            break;
        case "3":
            Console.WriteLine("Hvilken bok vil du sjekke ut? Sjekk ut med hjelp av ISBN nummer.");
            string isbnCheckOut = Console.ReadLine();
            library.CheckOutBook(isbnCheckOut);
            filesystem.SaveChanges();
            break;
        case "4":
            Book returnedBook = Book.CreateBook();
            library.ReturnBook(returnedBook);
            filesystem.SaveChanges();
            break;
        case "5":
            foreach (var book in library.GetAllBooks())
            {
                Console.WriteLine($"Tittel: {book.Title}");
                Console.WriteLine($"Forfatter: {book.Author}");
                Console.WriteLine($"ISBN: {book.ISBN}");
                Console.WriteLine("____________________");
            }
            break;
        case "6":
            Console.WriteLine("Avslutter programmet.");
            filesystem.SaveChanges();
            return;
        default:
            Console.WriteLine("Ugyldig valg. Prøv igjen.");
            break;
    }
}
