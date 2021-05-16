using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AppProductosRodando.Model
{
    public class Facturas
    {
        [Key]
        public int IdFactura { get; set; }
        public DateTime Fecha { get; set; }
        public int IdDocumentoCliente { get; set; }
        public int IdProducto { get; set; }
        public int Cantidad { get; set; }
        public double SubTotal { get; set; }
        public double Total { get; set; }
        public bool Pagado { get; set; }
    }
}
