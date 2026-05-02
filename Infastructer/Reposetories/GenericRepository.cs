using Application.Reposetories;
using Infastructer.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infastructer.Reposetories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {

        private readonly AppDbContext _context;
        private readonly DbSet<T> _dbSet;   
        public GenericRepository(AppDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }





        public void Delete(T input)
        {
           _dbSet.Remove(input);
        }

        public IQueryable<T> GetAll()
        {
            var data = _dbSet.AsQueryable();
            return data;

                  }

        public T Getbuid(Guid id)
        {
            var data = _dbSet.Find(id);
                        return data;
        }

      

        public async Task<T> GetByIdAsync(Guid id)
        {
            var data=await _dbSet.FindAsync(id);
            return data;
        }

        public void Insert(T input)
        {
            _dbSet.Add(input);
        }

        public async Task InsertAsync(T input)
        {
           await _dbSet.AddAsync(input);
        }

        public void  InsertRange(List<T> input)
        {
             _dbSet.AddRange(input);
        }

        public async Task InsertRangeAsync(List<T> input)
        {
           await _dbSet.AddRangeAsync(input);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();  
        }

        public void Update(T input)
        {
           _dbSet.Update(input);
        }

        public async Task UpdateAsync(T input)
        {
             _dbSet.Update(input);

        }
    }
}
