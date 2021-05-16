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
    public class PedidosController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public PedidosController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public IEnumerable<Pedidos> GetPedidos()
        {
            return context.Pedido.ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<Pedidos> GetPedidoById(int id)
        {
            var pedido = context.Pedido.Find(id);

            if (pedido != null)
            {
                return pedido;
            }
            return NotFound();
        }

        [HttpPost]
        public ActionResult PostPedidos(Pedidos pedidos)
        {
            if (ModelState.IsValid)
            {
                context.Pedido.Add(pedidos);
                context.SaveChanges();

                return Ok();
            }
            return BadRequest();
        }

        [HttpPut]
        public ActionResult PutPedidos(int id, Pedidos pedidos)
        {
            if (pedidos.IdPedido == id)
            {
                context.Entry(pedidos).State = EntityState.Modified;
                context.SaveChanges();

                return Ok();
            }

            return BadRequest();
        }


        [HttpDelete]
        public ActionResult DeletePedido(int id)
        {
            var pedido = context.Pedido.FirstOrDefault(p => p.IdPedido == id);

            if (pedido != null)
            {
                context.Remove(pedido);
                context.SaveChanges();

                return Ok();
            }
            return BadRequest();
        }
    }
}
