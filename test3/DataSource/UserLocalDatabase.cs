using System;
using System.Collections.Generic;
using test3.Interface;
using test3.Models;
using System.Diagnostics;
using SQLite.Net;
using System.Linq;

namespace test3.DataSource
{
    public class UserLocalDatabase : IUsers
    {
        bool IUsers.AddUser(UserModel u)
        {
            try
            {
                MyConnectionSQLite.GetConnection.Insert(u);
                return true;

            }catch(SQLiteException ex)
            {
                Debug.WriteLine("SQLite No Row Inserted, SQLiteEx !", ex.Message);
                return false;
            }
        }

        bool IUsers.CreateDb()
        {
            try
            {
                MyConnectionSQLite.GetConnection.CreateTable<UserModel>();
                return true;

            }
            catch (SQLiteException ex)
            {
                Debug.WriteLine("No SQLite DB, SQLiteEx !", ex.Message);
                return false;
            }
        }

        bool IUsers.DeleteUser(UserModel u)
        {
            try
            {
                MyConnectionSQLite.GetConnection.Delete(u);
                return true;

            }
            catch (SQLiteException ex)
            {
                Debug.WriteLine("SQLite No Row Deleted, SQLiteEx !", ex.Message);
                return false;
            }
        }

        IList<UserModel> IUsers.GetListUsers()
        {
            return MyConnectionSQLite.GetConnection.Table<UserModel>().ToList();
        }

        UserModel IUsers.GetSingleUser(int id)
        {
            UserModel user = (from u in MyConnectionSQLite.GetConnection.Table<UserModel>()
                              where u.Id == id
                              select u).FirstOrDefault();
            return user;
        }

        bool IUsers.UpdateUser(UserModel u)
        {
            try
            {
                /*
                MyConnectionSQLite.GetConnection.Query<UserModel>
                    ("UPDATE Users set Username=?,Pwd=? WHERE Id=?", u.Username, u.Pwd, u.Id);
                */
                MyConnectionSQLite.GetConnection.Update(u);
                return true;

            }
            catch (SQLiteException ex)
            {
                Debug.WriteLine("SQLite No Row Updated, SQLiteEx !", ex.Message);
                return false;
            }
        }

        bool IUsers.ValidUser(string username, string pwd)
        {
            try
            {
                int cpt= MyConnectionSQLite.GetConnection.Query<UserModel>
                    ("SELECT * FROM Users WHERE Username = ? AND Pwd = ?", username, pwd).Count();
                if (cpt == 0)
                {
                    return false;
                }
                else return true;

            }
            catch (SQLiteException ex)
            {
                Debug.WriteLine("SQLite No Such User, SQLiteEx !", ex.Message);
                return false;
            }
        }
    }
}
