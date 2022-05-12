using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevProjeto.API.Entities;
using DevProjeto.API.Models;
using DevProjeto.API.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace DevProjeto.API.Controllers
{
    [ApiController]
    [Route("api/packeges")]

    public class PackegesController : ControllerBase
    {
        private readonly devProjContext _context;
        public PackegesController(devProjContext context)
        {
            _context = context;
        }


        // GET api/packeges
        [HttpGet]
        public IActionResult GetAll()
        {
            var packeges = _context.Packeges;
         
            return Ok(packeges);
        }

        // GET api/packeges/code
        [HttpGet("{code}")]
        public IActionResult GetByCode(string code)
        {
            var packege = _context.Packeges.SingleOrDefault(p => p.Code == code);
            if (packege == null) {
                return NotFound();
            }

            return Ok(packege);
        }

        // POST api/packeges
        [HttpPost]
        public IActionResult Post(addPackegeInputModels models)
        {
            if (models.Title.Length < 10){
                return BadRequest("O tamanho do titulo ultrapassa de 10 caracteres");
            }
            var packege = new Packege(models.Title, models.Weigth) ;

            _context.Packeges.Add(packege);
            return CreatedAtAction ("GetByCode" , new { code = packege.Code}, packege ) ;

        }    
        
        // POST api/packeges/code/updates
        [HttpPost("{code}/updates")]
        public IActionResult PostUpdate(string code , addPackegeUpdateInputModel models) {
            var packege = new Packege("Pacote ", 1.2M);

            packege.AddUpdate(models.Status,models.Delivered);
            
            return NoContent();

        }
    }
}