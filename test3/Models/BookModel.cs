using System;
using SQLite.Net.Attributes;

namespace test3.Models
{
	[Table("Books")]
    public class BookModel
    {
		[PrimaryKey, AutoIncrement]
		public int Id
		{
			get;
			set;
		}
		public string Name
		{
			get;
			set;
		}

		public string Author
		{
			get;
			set;
		}
		
	}
}
