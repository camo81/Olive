using System;
using System.IO;
using Xamarin.Forms;
using Olive.iOS.DS;

[assembly: Dependency(typeof(SQLite_iOS))]
namespace Olive.iOS.DS
{
    public class SQLite_iOS : Model.ISqlLite
    {
        public SQLite_iOS() { }
        public SQLite.SQLiteConnection getConnection()
        {
            var sqliteFilename = "Settings.db3";
            string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal); // Documents folder
            string libraryPath = Path.Combine(documentsPath, "..", "Library"); // Library folder
            var path = Path.Combine(libraryPath, sqliteFilename);
            // Create the connection
            var conn = new SQLite.SQLiteConnection(path);
            // Return the database connection
            return conn;
        }
    }
}
