namespace Backend.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("transaccion")]
    public partial class transaccion
    {
        public int id { get; set; }

        public int? id_tipo_transaccion { get; set; }

        public decimal? monto { get; set; }

        public decimal? valor_gmf { get; set; }

        public int? id_cuenta_destino { get; set; }

        public decimal? saldo_operacion { get; set; }

        public virtual cuenta cuenta { get; set; }
    }
}
