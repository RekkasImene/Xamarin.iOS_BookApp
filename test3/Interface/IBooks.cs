using System;
using System.Collections.Generic;
using test3.Models;

namespace test3.Interface
{
    public interface IBooks
    {
        bool CreateDb();
        IList<BookModel> GetListBooks();
        bool AddBook(BookModel b);
        bool DeleteBook(BookModel b);
        bool UpdateBook(BookModel b);
        BookModel GetSingleBook(int id);
    }
}
