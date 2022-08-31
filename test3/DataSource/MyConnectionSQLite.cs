using System;
using System.IO;
using SQLite.Net;

namespace test3.DataSource
{
    public class MyConnectionSQLite
    {
        private string _dbName = "TestDB-DEV.db3";
        private static MyConnectionSQLite _instance = null;

		public static SQLiteConnection GetConnection
		{
            get{
				if(_instance == null)
                {
					_instance = new MyConnectionSQLite();
                }
                return _instance.GetConnectionSQLite();
            }
			
		}

        private SQLiteConnection GetConnectionSQLite()
        {
            Console.WriteLine("Connection SQLite Database");
            string folder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string libraryPath = Path.Combine(folder, "..", "Library");
            var path = Path.Combine(libraryPath, _dbName);
            var platform = new SQLite.Net.Platform.XamarinIOS.SQLitePlatformIOS();
            SQLiteConnection db = new SQLiteConnection(platform, path);

            return db;
            
        }
    }
}
