using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using ServerBackend.Logic;
using ServerBackend.Models;
using ServerBackend.Validators;

namespace ServerBackend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PeopleController : ControllerBase
    {
        private readonly IPersonManager _manager;
        private readonly IPersonPostValidator _validator;

        public PeopleController(IPersonManager manager, IPersonPostValidator validator)
        {
            _manager = manager;
            _validator = validator;
        }

        [HttpGet]
        public IEnumerable<Person> Get()
        {
            return _manager.LoadAll();
        }

        [HttpGet]
        [Route("/People/Adults")]
        public IEnumerable<Person> GetAdults()
        {
            return _manager.GetAllAdults();
        }
        
        [HttpGet]
        [Route("/People/Children")]
        public IEnumerable<Person> GetChildren()
        {
            return _manager.GetAllChildren();
        }

        [HttpPost]
        public IActionResult Post(Person person)
        {
            _validator.ValidateAndThrow(person);

            _manager.Add(person);
            return Created($"https://localhost:44361/People/{person.Id}", person);
        }

        [HttpDelete]
        [Route("/People/{id}")]
        public IActionResult Delete(int id)
        {

            _manager.Remove(id);
            return Ok(id);
        }

        [HttpPut]
        public IActionResult Put(Person person)
        {
            _manager.Update(person);
            return Ok();
        }
    }
}
