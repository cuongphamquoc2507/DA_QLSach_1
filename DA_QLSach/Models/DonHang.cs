namespace DA_QLSach.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DonHang")]
    public partial class DonHang
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DonHang()
        {
            CT_HoaDon = new HashSet<CT_HoaDon>();
        }

        [Key]
        public int IDHoaDon { get; set; }

        public DateTime? NgayDat { get; set; }

        [StringLength(50)]
        public string TinhTrang { get; set; }

        public int? IDKhachHang { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CT_HoaDon> CT_HoaDon { get; set; }

        public virtual KhachHang KhachHang { get; set; }
    }
}
