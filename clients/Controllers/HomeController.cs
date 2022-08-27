using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using clients.Models;
using clients.Data;
using clients.Repo;


namespace clients.Controllers
{
    [ApiController]
    [Route("api/{controller}")]
    public class HomeController: ControllerBase
    {
        private readonly IClient _clientInterfaceRepo;
        private readonly ApplicationDbContext _databaseContext;

        public HomeController(IClient clientInterfaceRepo, ApplicationDbContext databaseContext)
        {
            _clientInterfaceRepo = clientInterfaceRepo;
            _databaseContext = databaseContext;
        }

        [HttpGet]
        [Route("status")]
        public string Status()
        {
            return _clientInterfaceRepo.ApiStatus();
        }


        [HttpGet]
        public ActionResult<IEnumerable<Client>> GetClients()
        {
            return Ok(_clientInterfaceRepo.GetListOfClients());
        }

        [HttpPost]
        public ActionResult CreateClient(Client dataInput)
        {

            _clientInterfaceRepo.CreateClient(dataInput);
            return CreatedAtAction(nameof(GetClient), new {id = dataInput.Id}, dataInput);
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<Client> GetClient(int id)
        {
            if(id == 0 )
            {
                return NotFound();
            }
            var client = _databaseContext.clients.FirstOrDefault(a => a.Id == id);
            if(client == null)
            {
                return NotFound();
            }
            return client;
        }

        [HttpDelete]
        [Route("{id}")]
        public ActionResult DeleteClient(int id)
        {
            if(id == 0)
            {
                return BadRequest();
            }
            var data = _databaseContext.clients.FirstOrDefault(a => a.Id == id);
            if(data == null)
            {
                return NotFound();
            }
            _clientInterfaceRepo.DeleteClient(data);
            return NoContent();
        }


        [HttpPut]
        [Route("{id}")]
        public ActionResult updateClient(int id, Client dataInput)
        {
            if(id != dataInput.Id && id == 0)
            {
                return BadRequest();
            }
            _clientInterfaceRepo.UpdateClient(dataInput);
            return NoContent();

        }

    }
}