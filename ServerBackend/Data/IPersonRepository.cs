using System.Linq;
using ServerBackend.Models;

namespace ServerBackend.Data
{
    public interface IPersonRepository
    {
        IQueryable<Person> Query { get; }
        void Insert(Person person);
        void Delete(int id);
        void Update(Person person);
    }
}