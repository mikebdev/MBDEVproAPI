
namespace MBDEVproAPI.Repository.Interfaces
{
    public interface IBaseRepository<T>
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        void Add(T obj);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        void Remove(int id, T obj);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        T GetByID(int? id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        IEnumerable<T> GetAll(int id);

        /// <summary>
        /// 
        /// </summary>
        void SaveChanges();

    }
}
