using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Backend.Models
{
    public class Clases
    {
    }

    public class transaccion_cl
    {
        public int? id_tipo_transaccion { get; set; }
        public decimal? monto { get; set; }
        public decimal? valor_gmf { get; set; }
        public int? id_cuenta { get; set; }
        public decimal? saldo_operacion { get; set; }
        public DateTime? fecha_hora { get; set; }
        public int? id_cuenta_destino { get; set; }
        public int? id_usuario { get; set; }
    }
}