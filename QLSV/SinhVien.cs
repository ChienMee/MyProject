using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSV
{
    internal class SinhVien
    {
        #region Properties
        public int ID { get; set; }
        public string Ten { get; set; }
        public string GioiTinh { get; set; }
        public int Tuoi { get; set; }
        public float DiemToan { get; set; }
        public float DiemLy { get; set; }
        public float DiemHoa { get; set; }
        public double DiemTB { get; set; }

        public string HocLuc { get; set; }
        #endregion

        #region Constructor
        public SinhVien()
        {

        }

        #endregion

        #region Check Methods
        public void KTTen()
        {
            do
            {
                Ten = Console.ReadLine();
                if (Ten.Any(char.IsDigit) == true)
                {
                    Console.WriteLine("tên không được chứa số,xin hãy nhập lại !");
                }
            } while (Ten.Any(char.IsDigit) == true);
        }
        public void KTTuoi()
        {
            do
            {
                Tuoi = int.Parse(Console.ReadLine());
                if (Tuoi < 0)
                {
                    Console.WriteLine("tuổi phải là số dương,hãy nhập lại");
                }
            } while (Tuoi < 0);
        }
        public void KTTDiemToan()
        {
            do
            {
                DiemToan = float.Parse(Console.ReadLine());
                if (DiemToan < 0 || DiemToan > 10)
                {
                    Console.WriteLine("điểm không không hợp lệ,hãy nhập lại.");
                }
            } while (DiemToan < 0 || DiemToan > 10);
        }
        public void KTTDiemLy()
        {
            do
            {
                DiemLy = float.Parse(Console.ReadLine());
                if (DiemToan < 0 || DiemToan > 10)
                {
                    Console.WriteLine("điểm không không hợp lệ,hãy nhập lại.");
                }
            } while (DiemLy < 0 || DiemLy > 10);
        }
        public void KTTDiemHoa()
        {
            do
            {
                DiemHoa = float.Parse(Console.ReadLine());
                if (DiemToan < 0 || DiemToan > 10)
                {
                    Console.WriteLine("điểm không không hợp lệ,hãy nhập lại.");
                }
            } while (DiemHoa < 0 || DiemHoa > 10);
        }
        #endregion

        #region Methods
        public double DTB()
        {
            DiemTB = (DiemToan + DiemLy + DiemHoa)/3;
            return DiemTB;
        }

        public string HL()
        {
            if(DiemTB > 8)
            {
                return "G";
            }
            else if (DiemTB >=6.5)
            {
                return "K";
            }
            else if (DiemTB >=5 )
            {
                return "TB";
            }
            else
            {
                return "Y";
            }
        }
        public void ChonGioiTinh()
        {
            int choice;
            do
            {
                Console.WriteLine("1.Nam");
                Console.WriteLine("2.Nữ");
                Console.WriteLine("3.Khác");
                Console.Write("hãy nhập số để chọn giới tính :");
                choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        GioiTinh = "Nam";
                        Console.WriteLine("Giới tính: Nam");
                        break;
                    case 2:
                        GioiTinh = "Nữ";
                        Console.WriteLine("Giới tính: Nữ");
                        break;
                    case 3:
                        GioiTinh = "Khác";
                        Console.WriteLine("Giới tính: Khác");
                        break;
                    default:
                        Console.WriteLine("hãy nhập 1 hoặc 2 hoặc 3 để chọn giới tính");
                        break;
                }
            } while (choice < 1 || choice > 2);
        }
        public void Nhap()
        {
            Console.Write("nhập tên sinh viên: ");
            KTTen();
            Console.WriteLine("Giới tính: ");
            ChonGioiTinh();
            Console.Write("nhập tuổi: ");
            KTTuoi();
            Console.Write("nhập điểm Toán: ");
            KTTDiemToan();
            Console.Write("nhập điểm Lý: ");
            KTTDiemLy();
            Console.Write("nhập điểm Hóa: ");
            KTTDiemHoa();
        }
        
        public void Xuat()
        {
            // chỉ lấy 2 số sau dấu phẩy của kết quả điểm trung bình
            double DiemTB = DTB();
            string FormattedDiemTB = DiemTB.ToString("F2");

            /* 
             * xuất thông tin sinh viên bao gồm ID, tên, giới tính,
             * điểm toán, điểm Lý, điểm hóa, điểm trung bình và học lực
             * theo hàng ngang để tạo ra dữ liệu dạng bảng
            */
            Console.WriteLine($"{ID,-10}{Ten,-20}{GioiTinh,-15}{Tuoi,-10}{DiemToan,-12}{DiemLy,-10}{DiemHoa,-10}{FormattedDiemTB,-10}{HL(),-10}");
        }
        #endregion
    }
}
