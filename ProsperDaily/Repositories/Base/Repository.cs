using System.Linq.Expressions;
using SQLite;
using SQLiteNetExtensions.Extensions;


namespace ProsperDaily.Repositories.Base;
public class Repository<T> : IBaseRepository<T>
where T : TableData, new()
{
     private readonly SQLiteConnection _connection;
     public string StatusMessage { get; set; }

     public Repository()
     {
          _connection = new (Constants.DatabasePath, Constants.Flags);
          _connection.CreateTable<T>();
     }

     public void Save(T item)
     {
          try
          {
               var result = 0;
               if(item.Id != 0)
               {
                    result = _connection.Update(item);
                    StatusMessage = $"{result} row(s) updated";
               }
               else
               {
                    result = _connection.Insert(item);
                    StatusMessage = $"{result} row(s) added";
               }

          }
          catch(Exception ex)
          {
               StatusMessage = $"Error: {ex.Message}";
          }
     }
     public void SaveWithChildren(T item, bool recursive = false)
     {
          _connection.InsertWithChildren(item, recursive);
     }

     public T Get(int id)
     {
          try
          {
               return _connection.Table<T>().FirstOrDefault(x => x.Id == id);
          }
          catch (Exception ex)
          {
               StatusMessage = $"Error: {ex.Message}";
          }

          return null;
     }
     public T Get(Expression<Func<T, bool>> predicate)
     {
          try
          {
               return _connection.Table<T>().Where(predicate).FirstOrDefault();
          }
          catch (Exception ex)
          {
               StatusMessage = $"Error: {ex.Message}";
          }

          return null;
     }

     public List<T> GetList()
     {
          try
          {
               return _connection.Table<T>().ToList();
          }
          catch (Exception ex)
          {
               StatusMessage = $"Error: {ex.Message}";
          }

          return null;
     }
     public List<T> GetList(Expression<Func<T, bool>> predicate)
     {
          try
          {
               return _connection.Table<T>().Where(predicate).ToList();
          }
          catch (Exception ex)
          {
               StatusMessage = $"Error: {ex.Message}";
          }
          return null;
     }
     public List<T> GetListWithChildren()
     {
          try
          {
               return _connection.GetAllWithChildren<T>().ToList();
          }
          catch (Exception ex)
          {
               StatusMessage = $"Error: {ex.Message}";
          }
          return null;
     }

     public void Delete(T item)
     {
          try
          {
               _connection.Delete(item, true);
          }
          catch (Exception ex)
          {
               StatusMessage = $"Error: {ex.Message}";
          }
     }

     public void Dispose()
          => _connection.Close();
}

public class TableData
{
     [PrimaryKey, AutoIncrement]
     public int Id { get; set; }
}

