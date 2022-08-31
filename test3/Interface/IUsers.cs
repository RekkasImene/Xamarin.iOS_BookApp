using System;
using System.Collections.Generic;
using test3.Models;

namespace test3.Interface
{
    public interface IUsers
    {
        bool CreateDb();
        IList<UserModel> GetListUsers();
        bool AddUser(UserModel u);
        bool DeleteUser(UserModel u);
        bool UpdateUser(UserModel u);
        UserModel GetSingleUser(int id);
        bool ValidUser(string username, string pwd);
    }
}
