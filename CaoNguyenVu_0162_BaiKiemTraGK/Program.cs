using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaoNguyenVu_0162_BaiKiemTraGK
{
    class Program
    {
        static List<HoGiaDinh> listHDG = new List<HoGiaDinh> {
                    new HoGiaDinh(4,1,1,"48 Cao Thang", 1,1),
                    new HoGiaDinh(9,4,3,"9 Ton Dan", 3,2),
                    new HoGiaDinh(5,1,2,"40 Ton Duc Thang", 2,3),
                    new HoGiaDinh(10,1,7,"90 Ham Nghi", 1,4),
                    new HoGiaDinh(3,1,0,"123 Nguyen Tri Phuong", 4,5)
            };
        static List<KhuPho> listKP = new List<KhuPho> {
                    new KhuPho(1,"Khu pho A"),
                    new KhuPho(2,"Khu pho B"),
                    new KhuPho(3,"Khu pho C"),
                    new KhuPho(4,"Khu pho D"),
                    new KhuPho(5,"Khu pho E")
            };
        static List<Nguoi> listNguoi = new List<Nguoi>
            {
                new Nguoi("Cao Nguyen Vu", 21,"Sinh vien", "12345",1),
                new Nguoi("Nguyen Van B", 34,"Bac si", "12945",1),
                new Nguoi("Hoang Quoc A", 25,"Nhan vien", "18985",2),
                new Nguoi("Dang Van C", 16,"Hoc sinh", "78987",1),
                new Nguoi("Van Thi F", 18,"Hoc sinh", "34532",3),
                new Nguoi("Tran Thi N", 22,"Dau bep", "56383",2),
                new Nguoi("Nguyen Quoc K", 30,"Ky su", "64745",3),
                new Nguoi("Vo Dang Hung", 50,"Giam doc", "15357",4),
                new Nguoi("Tran Hung Q", 20,"Sinh vien", "84673",1),
            };
        public static void Bai3()
        {
            int n = 0;
            Console.WriteLine("Nhap so ho");
            n = Convert.ToInt32(Console.ReadLine());
            HoGiaDinh[] arrayHoGiaDinh = new HoGiaDinh[n];
            Console.WriteLine("-----------------------");
            for (int i = 0; i < n; i++)
            {
                arrayHoGiaDinh[i] = new HoGiaDinh();
                Console.WriteLine("\nNhap ma khu pho: ");
                arrayHoGiaDinh[i].MaKP = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Nhap ma ho gia dinh: ");
                arrayHoGiaDinh[i].MaHGD = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Nhap so thanh vien ");
                arrayHoGiaDinh[i].SoThanhVien = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Nhap so con trai: ");
                arrayHoGiaDinh[i].SoConTrai = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Nhap so con gai: ");
                arrayHoGiaDinh[i].SoConGai = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Nhap so nha: ");
                arrayHoGiaDinh[i].SoNha = Console.ReadLine();
            }
            Console.WriteLine("\n----- Danh sach vua nhap -----");
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine(arrayHoGiaDinh[i].ToString());
            }
        }
        public static void Bai4()
        {
             
            var listResultWithNumberMale = listHDG.Where(o => o.SoConTrai >= 2);
            var listResultWithNumberChildren = listHDG.Where(o => ((o.SoConTrai + o.SoConGai) > 5 
                                                    && (o.SoConTrai + o.SoConGai) < 10));

            Console.WriteLine("----------  Ho gia đinh co so con trai >=2\n\n");
            foreach ( var item in listResultWithNumberMale)
            {
                Console.WriteLine(item.ToString());
            }

            Console.WriteLine("\n---------- Ho gia đinh co so con tu 5 đen 10\n\n");
            foreach (var item in listResultWithNumberChildren)
            {
                Console.WriteLine(item.ToString());
            }

        }
        public static void Bai5()
        {
           
            var listResult = listKP.Join(listHDG, lkp => lkp.MaKP,
                               lhgd => lhgd.MaKP, (lkp, lhgd) => new { lkp, lhgd })
                .GroupBy(o => o.lkp.MaKP).Select(
                    group => new
                    {
                        MaKP = group.Key,
                        TenKP = group.First().lkp.TenKP,
                        total = group.Sum(o=> o.lhgd.SoThanhVien)
                    }
            ); ;
             
            foreach (var item in listResult)
            {
                Console.WriteLine("Ma khu pho: '" + item.MaKP + "' - Ten khu pho: '" + item.TenKP + "' - So thanh vien: '" + item.total+"'");
            }

        }
        public static void Bai6()
        {          
            var listResult = listHDG.Join(listKP, lhgd => lhgd.MaKP,
                               lkp => lkp.MaKP, (lhgd, lkp) => new {  lhgd, lkp }).
                               Join(listNguoi, hgd => hgd.lhgd.MaHGD,
                               ng => ng.MaHGD, (hdg, ng) => new { hdg, ng }).Where(o => o.ng.HoTen.EndsWith("Hung"));

            foreach (var item in listResult)
            {
                Console.WriteLine("Ho ten: '"+item.ng.HoTen + "' - Nghe nghiep: '" + item.ng.NgheNghiep + 
                    "' - So CMND: '" + item.ng.SoCMND + "' - Tuoi: '" + item.ng.Tuoi + "' - So nha: '" + item.hdg.lhgd.SoNha
                    + "' - Ten khu pho: '" + item.hdg.lkp.TenKP + "'");
            }

        }
        public static void Bai7()
        {
            var listResult = listHDG.Join(listKP, lhgd => lhgd.MaKP,
                               lkp => lkp.MaKP, (lhgd, lkp) => new { lhgd, lkp }) 
                               .GroupBy(o => o.lkp.MaKP).Select(
                                    group => new
                                    {
                                        MaKP = group.Key,
                                        TenKP = group.First().lkp.TenKP,
                                        totalMale = group.Sum(o => o.lhgd.SoConTrai),
                                        totalFeMale = group.Sum(o => o.lhgd.SoConGai) 
                                    });

            foreach (var item in listResult)
            {
                Console.WriteLine("Ten khu pho: '" + item.TenKP + "' - So con trai: '" + item.totalMale
                                                        + "' - So con gai: '" + item.totalFeMale+"'");
            }

        }
        static void Main(string[] args)
        {
            
            Console.WriteLine("---------------------------------------------------------------------");
            Console.WriteLine(" \t Bai 3\n\n");
            Bai3();
            Console.WriteLine("\n---------------------------------------------------------------------");
            Console.WriteLine(" \t Bai 4\n\n");
            Bai4();
            Console.WriteLine("\n---------------------------------------------------------------------");
            Console.WriteLine(" \t Bai 5\n\n");
            Console.WriteLine(" \t Tinh tong so thanh vien trong khu pho\n");
            Bai5();
            Console.WriteLine("\n---------------------------------------------------------------------");
            Console.WriteLine(" \t Bai 6\n\n");
            Console.WriteLine(" \t Tim cac ho gia đinh co nguoi ten 'Hung'\n");
            Bai6();
            Console.WriteLine("\n---------------------------------------------------------------------");
            Console.WriteLine(" \t Bai 7\n\n");
            Console.WriteLine(" \t Thong ke so con nam, nu trong khu pho.\n");
            Bai7();
            Console.ReadLine();
        }
    }
}
