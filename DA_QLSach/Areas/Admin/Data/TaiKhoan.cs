namespace DA_QLSach.Areas.Admin.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TaiKhoan")]
    public partial class TaiKhoan
    {
        [Key]
        public int MaTK { get; set; }

        [Required]
        [StringLength(20)]
        public string TenDN { get; set; }

        [Required]
        [StringLength(20)]
        public string MatKhau { get; set; }

        [StringLength(20)]
        public string PhanQuyen { get; set; }
    }
}
