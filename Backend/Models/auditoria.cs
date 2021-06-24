namespace Backend.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("auditoria")]
    public partial class auditoria
    {
        public int id { get; set; }

        public DateTime? fecha_hora { get; set; }

        [StringLength(20)]
        public string ip_consulta { get; set; }

        [StringLength(200)]
        public string descripcion { get; set; }
    }
}
