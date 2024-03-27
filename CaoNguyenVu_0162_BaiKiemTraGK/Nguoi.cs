using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaoNguyenVu_0162_BaiKiemTraGK
{
    class Nguoi
    {
        public string HoTen { set; get; }
        public int Tuoi { set; get; }
        public string NgheNghiep { set; get; }
        public string SoCMND { set; get; }
        public int MaHGD { set; get; }
        public Nguoi(string hoten, int tuoi, string nghenghiep, string socmnd, int mahgd)
        {
            this.HoTen = hoten;
            this.Tuoi = tuoi;
            this.NgheNghiep = nghenghiep;
            this.SoCMND = socmnd;
            this.MaHGD = mahgd;
        }
        public override string ToString()
        {
            return string.Format("Ho ten: '{0}' || Tuoi: '{1}' || Nghe nghiep: '{2}' || So CMND: '{3}' || Ma ho gia dinh: '{4}'", this.HoTen, this.Tuoi, this.NgheNghiep, this, SoCMND,
                this.MaHGD);
        }

    }
}
