using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebAPIDemo.Data
{
    public interface IRepository
    {
        //get all items
        Task<List<T>> FindAll<T>() where T:class; 
        //get one item
        Task<T> FindById<T>(int Id) where T:class;
        //create item
        Task CreateAsync<T>(T Entity) where T:class;
        //modify item
        Task UpdateAsync<T>(T Entity) where T:class;
        //delete item
        Task DeleteAsync<T>(T Entity) where T:class;
    }
}