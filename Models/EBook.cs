using System;

namespace LibrarySystem_V3;

public class EBook : Book
{
    public string FilePath { get; set; }
    public string FileFormat { get; set; }

    public EBook(string title, string author, string isbn, string filePath, string fileFormat) : base(title, author,
        isbn)
    {
        FilePath = filePath;
        FileFormat = fileFormat;
    }
}