﻿using Database;
using Microsoft.EntityFrameworkCore;
using Repository.Interface;

namespace Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        public readonly APIDbContext _context;

        private readonly DbSet<T> _dbSet;

        public Repository(APIDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }
        public void Add(T entity)
        {
            _context.AddAsync(entity);

            _context.SaveChangesAsync();
        }

        public void Delete(T entity)
        {
            _context.Remove(entity);

            _context.SaveChanges();
        }

        public IEnumerable<T> GetAll()
        {
            return _dbSet.ToList();
        }

        public T GetById(int? id)
        {
            return _dbSet.Find(id);
        }

        public void Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
