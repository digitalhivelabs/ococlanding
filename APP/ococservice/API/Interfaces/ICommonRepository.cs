using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace API.Interfaces
{
    public interface ICommonRepository<T> where T : class
    {
        void Add(T objEntity);
        void AddRange(IEnumerable<T> objEntity);
        T? GetId(int id);
        Task<T?> GetIdAsync(int id);
        T? Get(Expression<Func<T, bool>> predicate);
        Task<T?> GetAsync(Expression<Func<T, bool>> predicate);
        IEnumerable<T> GetList(Expression<Func<T, bool>> predicate);
        Task<IEnumerable<T>> GetListAsync(Expression<Func<T, bool>> predicate);
        IEnumerable<T> GetAll();
        Task<IEnumerable<T>> GetAllAsync();
        int Count();
        Task<int> CountAsync();
        void Update(T objEntity);
        void Remove(T objEntity);
        void Dispose();
        Task<bool> SaveAllAsync();
           
    }
}