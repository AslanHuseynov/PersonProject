using Microsoft.AspNetCore.Mvc;
using PersonSolution.Domain;
using PersonSolution.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonSolution.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class SexController : ControllerBase
    {
        private readonly ISexRepository SexRepository;
        public SexController(ISexRepository sexRepository)
        {
            SexRepository = sexRepository;
        }

        [HttpPost]
        public async Task<ActionResult> CreateSex(SexType value)
        {
            var sex = await SexRepository.ReadAsync(x => x.Value == value);
            if (sex.Any())
                return BadRequest("Sex has already created");
            var newSex = new Sex() { Value = value };
            await SexRepository.CreateAsync(newSex);
            return Ok(newSex);
        }
    }
}
