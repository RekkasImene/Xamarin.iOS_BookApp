using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using SQLite.Net;
using test3.Interface;
using test3.Models;

namespace test3.DataSource
{
    public class BookLocalDatabase : IBooks
    {
        bool IBooks.AddBook(BookModel b)
        {
            try
            {
                MyConnectionSQLite.GetConnection.Insert(b);
                return true;

            }
            catch (SQLiteException ex)
            {
                Debug.WriteLine("SQLite No Row Inserted, SQLiteEx !", ex.Message);
                return false;
            }
        }

        bool IBooks.CreateDb()
        {
            try
            {
                MyConnectionSQLite.GetConnection.CreateTable<BookModel>();
                return true;

            }
            catch (SQLiteException ex)
            {
                Debug.WriteLine("No SQLite DB, SQLiteEx !", ex.Message);
                return false;
            }
        }

        bool IBooks.DeleteBook(BookModel b)
        {
            try
            {
                MyConnectionSQLite.GetConnection.Delete(b);
                return true;

            }
            catch (SQLiteException ex)
            {
                Debug.WriteLine("SQLite No Row Deleted, SQLiteEx !", ex.Message);
                return false;
            }
        }

        IList<BookModel> IBooks.GetListBooks()
        {
            return MyConnectionSQLite.GetConnection.Table<BookModel>().ToList();
        }

        BookModel IBooks.GetSingleBook(int id)
        {
            BookModel book = (from b in MyConnectionSQLite.GetConnection.Table<BookModel>()
                              where b.Id == id
                              select b).FirstOrDefault();
            return book ;
        }

        bool IBooks.UpdateBook(BookModel b)
        {
            try
            {
                /*
                MyConnectionSQLite.GetConnection.Query<BookModel>
                    ("UPDATE Books set Name=?,Author=? WHERE Id=?", b.Name, b.Author, b.Id);
                */
                MyConnectionSQLite.GetConnection.Update(b);
                return true;

            }
            catch (SQLiteException ex)
            {
                Debug.WriteLine("SQLite No Row Updated, SQLiteEx !", ex.Message);
                return false;
            }
        }
    }
}
