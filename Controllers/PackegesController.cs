using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevProjeto.API.Entities;
using DevProjeto.API.Models;
using DevProjeto.API.Persistence;
using DevProjeto.API.Persistence.repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace DevProjeto.API.Controllers
{
    [ApiController]
    [Route("api/packeges")]

    public class PackegesController : ControllerBase
    {
        private readonly IPackegeRepository _repository;
        private readonly ISendGridClient _client;
        private ISendGridClient? client;

        public PackegesController (IPackegeRepository repository, ISendGridClient client)
        {
            if (repository is null)
            {
                throw new ArgumentNullException(nameof(repository));
            }

            if (client is null)
            {
                throw new ArgumentNullException(nameof(client));
            }
        }

        public PackegesController(IPackegeRepository repository)
        {
            _repository = repository;
            _client = client ;
        }

        // GET api/packeges
        [HttpGet]
        public IActionResult GetAll()
        {
            var packeges = _repository.GetAll();
         
            return Ok(packeges);
        }

        // GET api/packeges/code
        [HttpGet("{code}")]
        public IActionResult GetByCode(string code)
        {
            var packege = _repository.GetByCode(code);
            if (packege == null) {
                return NotFound();
            }

            return Ok(packege);
        }

        // POST api/packeges
        [HttpPost]
        public async Task <IActionResult> Post(addPackegeInputModels models)
        {
            if (models.Title.Length < 10){
                return BadRequest("O tamanho do titulo ultrapassa de 10 caracteres");
            }
            var packege = new Packege(models.Title, models.Weigth) ;

            _repository.Add(packege);
            var message = new SendGridMessage{
                From = EmailAddress("u26891485.wl236.sendgrid.net" , "CNAME" ),
                Subject = "Seu Pacote foi enviado",
                PlainTextContent = $"Your packege with code (packege.code) was dispached"

            };

            message.AddTo(models.SenderEmail , models.SenderName) ;
            await _client.SendEmailAsync(message);

      

            return CreatedAtAction ("GetByCode" , new { code = packege.Code}, packege ) ;

        }

        private EmailAddress EmailAddress(string v1, string v2)
        {
            throw new NotImplementedException();
            
        }

        // POST api/packeges/code/updates
        [HttpPost("{code}/updates")]
        public IActionResult PostUpdate(string code , addPackegeUpdateInputModel models) {
            var packege = _repository.GetByCode(code);

            packege.AddUpdate(models.Status,models.Delivered);
            
            _repository.Update(packege);
            return NoContent();

        }
    }

    public class Text<T>
    {
    }
}