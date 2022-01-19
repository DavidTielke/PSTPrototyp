using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ServerBackend.Data;
using ServerBackend.Models;

namespace ServerBackend.Logic
{
    public class PersonManager : IPersonManager
    {
        private readonly IPersonRepository _repository;

        public PersonManager(IPersonRepository repository)
        {
            _repository = repository;
        }

        public IQueryable<Person> GetAllAdults()
        {
            return _repository.Query.Where(p => p.Age >= 18);
        }

        public IQueryable<Person> GetAllChildren()
        {
            return _repository.Query.Where(p => p.Age < 18);
        }

        public void Add(Person person)
        {
            if(person.Name == null) throw new ArgumentException(nameof(person.Name), "Name darf nicht null sein");
            if(person.Age < 0) throw new ArgumentException(nameof(person.Age), "Alter darf nicht negativ sein");
            

            _repository.Insert(person);
        }

        public void Remove(int id)
        {
            _repository.Delete(id);
        }

        public void Update(Person person)
        {
            _repository.Update(person);
        }

        public IQueryable<Person> LoadAll()
        {
            return _repository.Query;
        }
    }
}
