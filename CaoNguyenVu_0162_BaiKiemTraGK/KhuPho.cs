using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaoNguyenVu_0162_BaiKiemTraGK
{
    class KhuPho
    {
        public int MaKP { set; get; }
        public string TenKP { set; get; }

        public KhuPho( int makp, string tenkp)
        {
            this.MaKP = makp;
            this.TenKP = tenkp;
        }
        public override string ToString()
        {
            return string.Format("Ma khu pho: '{0}' || Ten khu pho: '{1}'", this.MaKP, this.TenKP);
        }
    }
}
