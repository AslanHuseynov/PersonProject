using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PersonSolution.Domain;
using PersonSolution.Domain.Interfaces;
using PersonSolution.Domain.Requests;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PersonSolution.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class PersonController : ControllerBase
    {
        private readonly ILogger<PersonController> _logger;
        private readonly IPersonRepository PersonRepository;
        private readonly ISexRepository SexRepository;
        private readonly IMapper Mapper;
        public PersonController(ILogger<PersonController> logger, IPersonRepository personRepository, IMapper mapper, ISexRepository sexRepository)
        {
            _logger = logger;
            PersonRepository = personRepository;
            Mapper = mapper;
            SexRepository = sexRepository;
        }
        

        //დამატება
        [HttpPost]
        public async Task<ActionResult> CreatePerson(PersonDto createPersonRequest)
        {
            var person = Mapper.Map<Person>(createPersonRequest);
            var validationResult = await Validation(person);
            if (!string.IsNullOrEmpty(validationResult))
            {
                return BadRequest(validationResult);
            }
            var personId = await PersonRepository.CreateAsync(person);
            return Ok(personId);
        }

        //ფილტრაცია სახელის გვარისა და პირადი ნომრის მიხედვით
        [HttpGet]
        public async Task<IEnumerable<Person>> FilterPersons(string name, string surname, string personalnumber)
        {
            return await PersonRepository.ReadAsync(x => x.Name == name && x.Surname == surname && x.PersonalN == personalnumber);
        }


        [HttpGet]
        public async Task<Person> GetPerson(int id)
        {
            var person = await PersonRepository.ReadAsync(id);
            return person;
        }

        //რედაქტირება
        [HttpPut]
        public async Task<ActionResult> UpdatePerson(UpdatePersonDto updatePerson)
        {
            var person = Mapper.Map<Person>(updatePerson);
            if (person == null)
                return BadRequest("Person with this id doesn't exists!");
            var validationResult = await Validation(person);
            if (!string.IsNullOrEmpty(validationResult))
            {
                return BadRequest(validationResult);
            }
            var personId = await PersonRepository.UpdateAsync(person);
            return Ok(personId);
        }

        private async Task<string> Validation(Person person)
        {
            if (person.SexId == default)
                return "გთხოვთ მიუთითეთ სქესი";
            var sex = await SexRepository.ReadAsync(person.SexId);
            if (sex == null)
                return "ასეთი სქესი არ არსებობს";

            return string.Empty;
                
        }
    }
}
