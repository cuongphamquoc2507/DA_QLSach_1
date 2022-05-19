using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DA_QLSach.Models
{
    public class GioHang
    {
        dbSach db = new dbSach();
        public int iMasp { get; set; }
        public string sTensp { get; set; }
        public string sAnhBia { get; set; }
        public double dDonGia { get; set; }
        public int iSoLuong { get; set; }
        public double ThanhTien
        {
            get { return iSoLuong * dDonGia; }
        }
        //Hàm tạo cho giỏ hàng
        public GioHang(int Masp)
        {
            iMasp = Masp;
            Sach sp = db.Saches.Single(n => n.MaSach == iMasp);
            sTensp = sp.TenSach;
            sAnhBia = sp.anh;
            dDonGia = double.Parse(sp.Gia.ToString());
            iSoLuong = 1;
        }
    }
}