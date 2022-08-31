using System;
using System.Collections.Generic;
using Foundation;
using test3.DataSource;
using test3.Interface;
using test3.Models;
using UIKit;

namespace test3.Adapter
{
    public class BookTableViewAdapter : UITableViewSource
    {
        private IList<BookModel> books;
        IBooks myBooks;

        public BookTableViewAdapter()
        {
            myBooks = new BookLocalDatabase();
            books = myBooks.GetListBooks();
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            UITableViewCell cell = tableView.DequeueReusableCell("BookCell");
            var bookx = books[indexPath.Row];
            cell.TextLabel.Text = bookx.Name;
            cell.DetailTextLabel.Text = bookx.Author;
            Console.WriteLine("Reading Books Data");
            foreach (var book in books)
            {
                Console.WriteLine(book.Id + " " + book.Name + " " + book.Author);
            }
            return cell;
        }

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return books.Count;
        }

        public BookModel GetItem(int id)
        {
            return books[id];
        }
    }
}
