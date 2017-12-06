using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Olive.Model
{
    class Database
    {
    }

    public class Settings
    {
        [PrimaryKey, AutoIncrement]
        public int IdSetting { get; set; }

        [Unique]
        public string SettingName { get; set; }

        public string SettingValue { get; set; }

        public override string ToString()
        {
            return string.Format("[Numbers: IdSetting={0}, SettingName={1}, SettingValue={2}", IdSetting, SettingName, SettingValue);
        }
    }

    public interface ISqlLite { SQLiteConnection getConnection(); }

    public static class ManageData
    {
        public const string TabellaSettings = "Settings";
        static SQLiteConnection database = DependencyService.Get<ISqlLite>().getConnection();


        public static void CreaDataBase()
        {
            database.CreateTable<Settings>();
        }

        public static int InsertSettings(Settings dati)
        {
            return database.Insert(dati);
        }

        public static Settings getValue(string SettingName)
        {

            string query = $"SELECT * FROM [{TabellaSettings}] WHERE [SettingName] = \"{SettingName}\"";
            var lista = database.Query<Settings>(query);
            return lista.FirstOrDefault();
        }

        public static int UpdateSettings(Settings dati)
        {
            int i = database.Update(dati);
            return i;
        }
    }

}
