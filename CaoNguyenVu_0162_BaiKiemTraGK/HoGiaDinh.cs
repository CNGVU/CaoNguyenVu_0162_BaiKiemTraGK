using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaoNguyenVu_0162_BaiKiemTraGK
{
    class HoGiaDinh
    {
        public int SoThanhVien { set; get; }
        public int SoConTrai { set; get; }
        public int SoConGai { set; get; }
        public string SoNha { set; get; }
        public int MaKP { set; get; }

        public int MaHGD { set; get; }
        public HoGiaDinh( int sothanhvien, int socontrai, int socongai, string sonha, int makp, int mahgd)
        {
            this.SoThanhVien = sothanhvien;
            this.SoConTrai = socontrai;
            this.SoConGai = socongai;
            this.SoNha = sonha;
            this.MaKP = makp;
            this.MaHGD = mahgd;
        }

        public HoGiaDinh()
        {
        }

        public override string  ToString()
        {
            return string.Format("So thanh vien: '{0}' || So con trai: '{1}' || So con gai: '{2}' || So nha : '{3}' || Ma khu pho: '{4}' || Ma ho gia dinh: '{5}'", this.SoThanhVien, this.SoConTrai, this.SoConGai,
                this.SoNha, this.MaKP, this.MaHGD);
        }
    }
}
