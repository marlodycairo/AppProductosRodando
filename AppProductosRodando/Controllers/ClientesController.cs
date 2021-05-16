using AppProductosRodando.Data;
using AppProductosRodando.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppProductosRodando.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public ClientesController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public IEnumerable<Clientes> GetClientes()
        {
            return context.Clientes.ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<Clientes> GetClienteById(int id)
        {
            var cliente = context.Clientes.Find(id);

            if (cliente == null)
            {
                return NotFound();
            }

            return cliente;
        }

        [HttpPost]
        public ActionResult CreateClientes(Clientes clientes)
        {
            try
            {
                context.Clientes.Add(clientes);
                context.SaveChanges();

                return Ok(clientes);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpPut]
        public ActionResult PutClientes(int id, Clientes clientes)
        {
            if (clientes.Identificacion == id)
            {
                context.Entry(clientes).State = EntityState.Modified;
                context.SaveChanges();

                return Ok();
            }
            return BadRequest();
        }

        [HttpDelete]
        public ActionResult DeleteClientes(int id)
        {
            var cliente = context.Clientes.FirstOrDefault(p => p.Identificacion == id);

            if (cliente != null)
            {
                context.Clientes.Remove(cliente);
                context.SaveChanges();
                return Ok();
            }
            return BadRequest();
        }
    }
}
