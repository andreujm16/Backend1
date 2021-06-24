namespace Backend.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("cuenta")]
    public partial class cuenta
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public cuenta()
        {
            transaccion = new HashSet<transaccion>();
        }

        public int id { get; set; }

        [StringLength(20)]
        public string nombre { get; set; }

        public int? id_usuario { get; set; }

        public int? id_banco { get; set; }

        public decimal? saldo { get; set; }

        public virtual banco banco { get; set; }

        public virtual usuario usuario { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<transaccion> transaccion { get; set; }
    }
}
