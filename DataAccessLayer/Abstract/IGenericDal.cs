namespace DataAccessLayer.Abstract
{
    public interface IGenericDal<T> where T : class
    {
        void Add(T t);
        void Delete(T t);
        void Update(T t);
        List<T> GetAllQuery();
        T GetQueryById(int id);
        void AddRange(List<T> t);
    }
}
