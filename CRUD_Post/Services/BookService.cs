using CRUD_Post.Models;

namespace CRUD_Post.Services;

public class BookService
{
    private List<Book> books;

    public BookService()
    {
        books = new List<Book>();
    }

    public Book Add(Book book)
    {
        book.Id = new Guid();
        books.Add(book);
        return book;
    }
    public Book GetById(Guid id)
    {
        foreach (var book in books)
        {
            if (book.Id == id)
            {
                return book;
            }
        }
        return null;
    }
    public bool Delete(Guid id)
    {
        var result = GetById(id);
        if (result is null)
        {
            return false;
        }

        var index = books.IndexOf(result);
        books.Remove(books[index]);

        return true;
    }
    public bool Update(Book book)
    {
        var result = GetById(book.Id);
        if (result is null)
        {
            return false;
        }
        var index = books.IndexOf(book);
        books[index] = book;

        return true;
    }
    public List<Book> GetAll()
    {
        return books;
    }
    public Book GetExpensiveBook()
    {
        var book = new Book();
        foreach (var bookFromDb in books)
        {
            if (bookFromDb.Price > book.Price)
            {
                book = bookFromDb;
            }
        }

        return book;
    }
    public Book GetMostPagedBook()
    {
        var book = new Book();
        foreach (var bookFromDb in books)
        {
            if (bookFromDb.PageNumber > book.PageNumber)
            {
                book = bookFromDb;
            }
        }

        return book;
    }
    public Book GetMostReadBook()
    {
        var book = new Book();
        foreach (var bookFromDb in books)
        {
            if (bookFromDb.ReadersName.Count > book.ReadersName.Count)
            {
                book = bookFromDb;
            }
        }

        return book;
    }
    public List<Book> GetBooksByReaderName(string readerName)
    {
        var booksWithReaderName = new List<Book>();
        foreach (var bookFromDb in books)
        {
            if (bookFromDb.ReadersName.Contains(readerName))
            {
                booksWithReaderName.Add(bookFromDb);
            }
        }

        return booksWithReaderName;
    }
    public List<Book> GetBooksByAuthorName(string authorName)
    {
        var booksWithAuthorName = new List<Book>();
        foreach (var bookFromDb in books)
        {
            if (bookFromDb.AuthorsName.Contains(authorName))
            {
                booksWithAuthorName.Add(bookFromDb);
            }
        }

        return booksWithAuthorName;
    }
    public bool AddReaderToBook(Guid bookId, string readerName)
    {
        var book = GetById(bookId);
        if (book is null)
        {
            return false;
        }
        var index = books.IndexOf(book);
        books[index].ReadersName.Add(readerName);

        return true;
    }
    public bool AddAuthorToBook(Guid bookId, string authorName)
    {
        var book = GetById(bookId);
        if (book is null)
        {
            return false;
        }
        var index = books.IndexOf(book);
        books[index].AuthorsName.Add(authorName);

        return true;
    }
}

