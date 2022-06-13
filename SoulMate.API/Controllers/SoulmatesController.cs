using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SoulMate.API.data;
using SoulMate.API.Repository;

namespace SoulMate.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SoulmatesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ISoulmateRepository _repository;

        public SoulmatesController(ISoulmateRepository repository, IMapper _mapper)
        {
            this._mapper = _mapper;
            this._repository=repository;
        }

        // GET: api/Soulmates
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OutgoingSoulmateDTO>>> GetSoulmate()
        {
            var soulmate = await _repository.GetAllAsync();
            Console.WriteLine(soulmate);
            var soulmateDTO = _mapper.Map<List<OutgoingSoulmateDTO>>(soulmate);
            return Ok(soulmateDTO);
        }

        // GET: api/Soulmates/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Soulmate>> GetSoulmate(int id)
        {
            var soulmate = await _repository.GetById(id);

            if (soulmate == null)
            {
                return NotFound();
            }

            return soulmate;
        }

        // PUT: api/Soulmates/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSoulmate(int id, Soulmate soulmate)
        {
            if (id != soulmate.Id)
            {
                return BadRequest();
            }

            var existingSoulmate=await _repository.GetById(id);
            if (existingSoulmate == null) {
                return NotFound("Soulmate doesn't exist");
            }
            try
            {
                await _repository.UpdateAsync(existingSoulmate);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await SoulmateExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Soulmates
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Soulmate>> PostSoulmate(IncomingSoulmateDTO soulmateDTO)
        {
            var soulmate = _mapper.Map<Soulmate>(soulmateDTO);
            await _repository.AddAsync(soulmate);

            return CreatedAtAction("GetSoulmate", new { id = soulmate.Id }, soulmate);
        }

        // DELETE: api/Soulmates/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSoulmate(int id)
        {
            var soulmate = await _repository.GetAsync(id);
            if (soulmate == null)
            {
                return NotFound();
            }

            await _repository.DeleteAsync(id); 

            return NoContent();
        }

        private async Task<bool> SoulmateExists(int id)
        {
            return await _repository.Exists(id);
        }
    }
}
