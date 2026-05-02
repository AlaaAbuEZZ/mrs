using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Reposetories
{
    public interface IGenericRepository<T> where T : class
    {
        public IQueryable<T> GetAll();
        public Task<T> GetByIdAsync(Guid id);
        public T Getbuid(Guid id);
        //----------insert
        public void Insert(T input);
        public Task InsertAsync(T input);
        public void InsertRange(List<T> input);
        public Task InsertRangeAsync(List<T> input);
        //--------------Update

        public void Update(T input);
        public Task UpdateAsync(T input);
       
        //--------------Delete
        public void Delete(T input);
        //-----SaveChanges
        public void SaveChanges();
        public Task SaveChangesAsync();




    }
}
