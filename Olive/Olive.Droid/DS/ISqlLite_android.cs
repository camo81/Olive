using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLite;
using System.IO;
using Xamarin.Forms;
using Olive.Droid.DS;

[assembly: Dependency(typeof(ISqlLite_android))]

namespace Olive.Droid.DS
{
    class ISqlLite_android : Olive.Model.ISqlLite
    {
        public SQLiteConnection getConnection()
        {
            var sqliteFilename = "Settings.db3";
            string documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal); // Documents folder
            var path = Path.Combine(documentsPath, sqliteFilename);
            // Create the connection
            var conn = new SQLite.SQLiteConnection(path);
            // Return the database connection
            return conn;
        }
    }


}