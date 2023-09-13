using OSKI_Test.Models;

namespace OSKI_Test.Services
{
    public interface IService<T> 
    {
        void Create(T entity);
        void Delete(int id);

        T GetById(int id);
        List<T> GetAll(); 
    }
}
