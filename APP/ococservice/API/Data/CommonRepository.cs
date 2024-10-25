using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using API.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class CommonRepository<TEntity> :  ICommonRepository<TEntity> where TEntity : class
    {
        private readonly DataContex _context;
        private readonly IMapper _mapper;

        public CommonRepository(DataContex context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Add(TEntity objEntity)
        {
            _context.Set<TEntity>().Add(objEntity);
            // _context.SaveChanges();
        }

        public void AddRange(IEnumerable<TEntity> objEntity)
        {
            _context.Set<TEntity>().AddRange(objEntity);
            // _context.SaveChanges();
        }

        public int Count()
        {
            return _context.Set<TEntity>().Count();
        }

        public Task<int> CountAsync()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public TEntity Get(Expression<Func<TEntity, bool>> predicate)
        {
            return _context.Set<TEntity>().FirstOrDefault(predicate);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _context.Set<TEntity>().ToList();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _context.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _context.Set<TEntity>().FirstOrDefaultAsync(predicate);
        }

        public TEntity GetId(int id)
        {
            return _context.Set<TEntity>().Find(id);
        }

        public async Task<TEntity> GetIdAsync(int id)
        {
            return await _context.Set<TEntity>().FindAsync(id);
        }

        public IEnumerable<TEntity> GetList(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _context.Set<TEntity>().Where<TEntity>(predicate).ToListAsync();
        }

        public void Remove(TEntity objEntity)
        {
            _context.Set<TEntity>().Remove(objEntity);
            // _context.SaveChanges();
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public void Update(TEntity objEntity)
        {
            _context.Entry(objEntity).State = EntityState.Modified;
            // _context.SaveChanges();
        }
    }

}