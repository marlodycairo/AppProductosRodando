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
    public class ProductosController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public ProductosController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public IEnumerable<Productos> GetProductos()
        {
            return context.Productos.ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<Productos> GetProductoById(int id)
        {
            var producto = context.Productos.Find(id);

            if (id == null)
            {
                return NotFound();
            }

            return producto;
        }

        [HttpPost]
        public ActionResult ProductosPost(Productos productos)
        {
            if (ModelState.IsValid)
            {
                context.Productos.Add(productos);
                context.SaveChanges();

                return Ok();
            }

            return BadRequest();
        }

        [HttpPut]
        public ActionResult PutProductos(int id, Productos productos)
        {
            if (productos.IdProducto == id)
            {
                context.Entry(productos).State = EntityState.Modified;
                context.SaveChanges();
                return Ok();
            }

            return BadRequest();
        }

        [HttpDelete]
        public ActionResult DeleteProducto(int id)
        {
            var producto = context.Productos.FirstOrDefault(p => p.IdProducto == id);

            if (producto != null)
            {
                context.Productos.Remove(producto);
                context.SaveChanges();

                return Ok();
            }

            return BadRequest();
        }
    }
}
