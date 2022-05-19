namespace DA_QLSach.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Sach")]
    public partial class Sach
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Sach()
        {
            CT_HoaDon = new HashSet<CT_HoaDon>();
        }

        [Key]
        public int MaSach { get; set; }

        public int MaTG { get; set; }

        [Required]
        [StringLength(1000)]
        public string TenSach { get; set; }

        [Required]
        [StringLength(100)]
        public string anh { get; set; }

        [Required]
        [StringLength(100)]
        public string Mota { get; set; }

        public int Gia { get; set; }

        public int? SoLuong { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CT_HoaDon> CT_HoaDon { get; set; }

        public virtual TacGia TacGia { get; set; }
    }
}
