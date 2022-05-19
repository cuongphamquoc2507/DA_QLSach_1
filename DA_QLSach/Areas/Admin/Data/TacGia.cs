namespace DA_QLSach.Areas.Admin.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TacGia")]
    public partial class TacGia
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TacGia()
        {
            Saches = new HashSet<Sach>();
        }

        [Key]
        public int MaTG { get; set; }

        [Required]
        [StringLength(50)]
        public string TenTG { get; set; }

        [StringLength(1000)]
        public string Anh { get; set; }

        [StringLength(20)]
        public string Ngaysinh { get; set; }

        [StringLength(100)]
        public string Quequan { get; set; }

        [StringLength(1000)]
        public string Tieusu { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Sach> Saches { get; set; }
    }
}
