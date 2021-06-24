namespace Backend.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("usuario")]
    public partial class usuario
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public usuario()
        {
            cuenta = new HashSet<cuenta>();
        }

        public int id { get; set; }

        [StringLength(50)]
        public string nombre { get; set; }

        [Column("usuario")]
        [StringLength(20)]
        public string usuario1 { get; set; }

        [StringLength(20)]
        public string clave { get; set; }

        public bool? exento { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<cuenta> cuenta { get; set; }
    }
}
