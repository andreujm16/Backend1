namespace Backend.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("configuracion")]
    public partial class configuracion
    {
        public int id { get; set; }

        public decimal? porc_gmf { get; set; }

        public decimal? divisor { get; set; }

        public decimal? base_retiro_gmf { get; set; }
    }
}
