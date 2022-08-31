using System;
using SQLite.Net.Attributes;

namespace test3.Models
{
	[Table("Users")]
    public class UserModel
    {
			[PrimaryKey, AutoIncrement]
			public int Id
			{
				get;
				set;
			}
			public string Username
			{
				get;
				set;
			}

			public string Pwd
			{
				get;
				set;
			}
	
	}
}
