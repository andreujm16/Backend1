namespace Backend.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tipo_transaccion
    {
        public int id { get; set; }

        [StringLength(5)]
        public string tipo { get; set; }

        [StringLength(20)]
        public string nombre { get; set; }
    }
}
