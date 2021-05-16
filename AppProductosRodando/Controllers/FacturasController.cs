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
    public class FacturasController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public FacturasController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public IEnumerable<Facturas> GetFacturas()
        {
            return context.Facturas.ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<Facturas> GetFacturaById(int id)
        {
            var factura = context.Facturas.Find(id);

            if (factura != null)
            {
                return factura;
            }
            return NotFound();
        }

        [HttpPost]
        public ActionResult PostFacturas(Facturas facturas)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            context.Facturas.Add(facturas);
            context.SaveChanges();

            return Ok();
        }

        [HttpPut]
        public ActionResult PutFacturas(int id, Facturas facturas)
        {
            if (facturas.IdFactura == id)
            {
                context.Entry(facturas).State = EntityState.Modified;
                context.SaveChanges();

                return Ok();
            }
            return BadRequest();
        }

        [HttpDelete]
        public ActionResult DeleteFactura(int id)
        {
            var factura = context.Facturas.FirstOrDefault(p => p.IdFactura == id);

            if (factura != null)
            {
                context.Remove(factura);
                context.SaveChanges();

                return Ok();
            }
            return BadRequest();
        }
    }
}
