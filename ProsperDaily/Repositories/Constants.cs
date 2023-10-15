using System.IO;
using Microsoft.Maui.Storage;
using SQLite;


namespace ProsperDaily.Repositories
{
     public static class Constants
     {
          private const string _dbFileName = "ProsperDaily.db3";

          public const SQLiteOpenFlags Flags =
               SQLiteOpenFlags.ReadWrite |
               SQLiteOpenFlags.Create |
               SQLiteOpenFlags.SharedCache;

          public static string DatabasePath
               => Path.Combine(FileSystem.AppDataDirectory, _dbFileName);
     }
}
