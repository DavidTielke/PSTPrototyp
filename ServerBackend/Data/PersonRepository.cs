using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ServerBackend.Models;

namespace ServerBackend.Data
{
    public class PersonRepository : IPersonRepository
    {
        private static List<Person> _persons = new List<Person>
        {
            new Person(1, "David", 38),
            new Person(2, "Lena", 34),
            new Person(3, "Maximilian", 9),
        };

        public IQueryable<Person> Query => _persons.AsQueryable();

        public void Insert(Person person)
        {
            if (person.Id != 0) throw new ArgumentException(nameof(person.Age), "Alter darf nicht negativ sein");

            person.Id = _persons.Max(p => p.Id) + 1;
            _persons.Add(person);
        }

        public void Delete(int id)
        {
            var personToDelete = _persons.Single(p => p.Id == id);
            _persons.Remove(personToDelete);
        }

        public void Update(Person person)
        {
            var personToUpdate = _persons.Single(p => p.Id == person.Id);
            personToUpdate.Name = person.Name;
            personToUpdate.Age = person.Age;
        }
    }
}
