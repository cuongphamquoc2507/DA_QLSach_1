namespace DA_QLSach.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CT_HoaDon
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IDHoaDon { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaSach { get; set; }

        public int? Sluong { get; set; }

        public int? Dongia { get; set; }

        public int? Thanhtien { get; set; }

        public virtual DonHang DonHang { get; set; }

        public virtual Sach Sach { get; set; }
    }
}
