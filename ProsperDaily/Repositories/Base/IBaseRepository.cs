using System.Linq.Expressions;


namespace ProsperDaily.Repositories.Base;
public interface IBaseRepository<T> : IDisposable
where T : TableData, new()
{
     string StatusMessage { get; set; }

     void Save(T item);
     void SaveWithChildren(T item, bool recursive = false);
     T Get(int id);
     T Get(Expression<Func<T, bool>> predicate);
     List<T> GetList();
     List<T> GetList(Expression<Func<T, bool>> predicate);
     List<T> GetListWithChildren();
     void Delete(T item);
}