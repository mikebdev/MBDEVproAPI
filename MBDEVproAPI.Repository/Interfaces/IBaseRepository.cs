
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
        /// <param name="BusinessID"></param>
        /// <param name="obj"></param>
        void Remove(int BusinessID, T obj);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="BusinessID"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        T GetByID(int BusinessID, int? id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="BusinessID"></param>
        /// <returns></returns>
        IEnumerable<T> GetAll(int BusinessID);

        /// <summary>
        /// 
        /// </summary>
        void SaveChanges();

    }
}
