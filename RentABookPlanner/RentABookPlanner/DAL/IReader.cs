
namespace RentABookPlanner.DAL
{
    public interface IReader<T> where T:class
    {
        T Read();
    }
}
