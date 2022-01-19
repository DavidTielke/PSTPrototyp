using System.Linq;
using ServerBackend.Models;

namespace ServerBackend.Logic
{
    public interface IPersonManager
    {
        IQueryable<Person> LoadAll();
        IQueryable<Person> GetAllAdults();
        IQueryable<Person> GetAllChildren();
        void Add(Person person);
        void Remove(int id);
        void Update(Person person);
    }
}