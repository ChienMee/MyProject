using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSV
{
    internal class QLSinhVIen
    {
        #region Initialization
        private List<SinhVien> qlsv = new List<SinhVien>();
        #endregion
        #region Methods

        // hàm kiểm tra để trả về vị trí của sinh viên trong danh sách theo ID
        public int KTID(int id)
        {
            for(int i = 0; i < qlsv.Count;i++)
            {
                SinhVien sv = (SinhVien)qlsv[i];
                if (sv.ID == id)
                {
                    return i;
                }
            }
            return -1;
        }

        // hàm nhập thông tin sinh viên
        public void NhapDSSV()
        {
            Console.Write("Nhập số lượng sinh viên: ");
            int slsv = int.Parse(Console.ReadLine());
            for (int i = 0; i < slsv; i++)
            {
                Console.WriteLine($"nhập thông tin sinh viên thứ {i+1}");
                SinhVien sv = new SinhVien();
                sv.Nhap();
                qlsv.Add(sv);
                sv.ID = qlsv.IndexOf(sv) + 1;
                Console.Clear();
            }
        }

        // hiển thị toàn bộ danh sách sinh viên
        public void XuatDSSV()
        {
            Console.WriteLine($"{"ID",-10}{"Tên",-20}{"Giới Tính",-15}{"Tuổi",-10}{"Điểm Toán",-12}{"Điểm Lý",-10}{"Điểm Hóa",-10}{"Điểm TB",-10}{"Học lực",-10}");
            foreach (SinhVien sv in qlsv)
            {
                sv.Xuat();
            }
        }

        // Hàm cập nhật sinh viên theo ID đã nhập
        public void CapNhatSVTheoID()
        {
            Console.Write("nhập ID sinh viên cần cập nhật : ");
            int id = int.Parse(Console.ReadLine());
            int index = KTID(id);
            if (KTID(id) != -1)
            {
                SinhVien cursv = (SinhVien)qlsv[index];
                Console.Write("Cập nhật tên sinh viên: ");
                cursv.KTTen();
                Console.WriteLine("Cập nhật giới tính: ");
                cursv.ChonGioiTinh();
                Console.Write("Cập nhật điểm toán: ");
                cursv.KTTDiemToan();
                Console.Write("Cập nhật điểm Lý: ");
                cursv.KTTDiemLy();
                Console.Write("Cập nhật điểm Hóa: ");
                cursv.KTTDiemHoa();
            }
            else
            {
                Console.WriteLine("id nhập không hợp lệ");
            }
        }

        // Xóa sinh viên theo ID
        public void XoaSVTheoID()
        {
            Console.Write("Nhập ID của Sinh Viên Cần Xóa: ");
            int id = int.Parse(Console.ReadLine());
            int index = KTID(id);
            if(index != -1)
            {
                qlsv.RemoveAt(index);
            }
            else
            {
                Console.WriteLine("ID không tồn tại");
            }
        }

        // tìm kiếm sinh viên theo tên
        public void TimKiemSVTheoten()
        {
            Console.Write("Nhập tên sinh viên cần tìm kiếm: ");
            string fname = Console.ReadLine();
            Console.WriteLine($"{"ID",-10}{"Tên",-20}{"Giới Tính",-15}{"Tuổi",-10}{"Điểm Toán",-12}{"Điểm Lý",-10}{"Điểm Hóa",-10}{"Điểm TB",-10}{"Học lực",-10}");
            for (int i = 0;i < qlsv.Count; i++)
            {
                if(fname == qlsv[i].Ten)
                {
                    qlsv[i].Xuat();
                }
            }
        }

        // Sắp xếp sinh viên theo điểm trung bình (GPA)
        public void FSXSVtheoGPA()
        {
            qlsv.Sort(new SXSVTheoGPA());
        }

        // Sắp xếp sinh viên theo tên
        public void FSXSVtheoTen()
        {
            qlsv.Sort(new SXSVTheoTen());
        }

        // Sắp xếp sinh viên theo ID
        public void FSXSVtheoID()
        {
            qlsv.Sort(new SXSVtheoID());
        }

        // Menu chức năng để người dụng có thể lựa chọn
        public void Menu()
        {
            int choice;
            do
            {
                Console.OutputEncoding = Encoding.UTF8;
                Console.InputEncoding = Encoding.UTF8;
                Console.WriteLine("-----------------------------------------------");
                Console.WriteLine("Quản lý sinh viên");
                Console.WriteLine("1.Nhập danh sách sinh viên.");
                Console.WriteLine("2.Cập nhật thông tin sinh viên theo ID.");
                Console.WriteLine("3.Xóa sinh viên theo ID.");
                Console.WriteLine("4.Tìm kiếm sinh viên theo Tên.");
                Console.WriteLine("5.Sắp xêp sinh viên theo điểm trung bình (GPA).");
                Console.WriteLine("6.Sắp xếp sinh viên theo tên.");
                Console.WriteLine("7.Sắp xếp sinh viên theo ID.");
                Console.WriteLine("8.Hiển thị danh sách sinh viên.");
                Console.WriteLine("9.thoát.");
                Console.WriteLine("-----------------------------------------------");
                Console.Write("hãy chọn chức năng: ");
                choice = int.Parse(Console.ReadLine());
                Console.Clear();
                switch (choice)
                {
                    case 1:
                        NhapDSSV();
                        Console.WriteLine("Nhập danh sách thành công. ");
                        break;
                    case 2:
                        CapNhatSVTheoID();
                        Console.WriteLine("Cập nhật thành công. ");
                        break;
                    case 3:
                        XoaSVTheoID();
                        Console.WriteLine("Xóa thông tin sinh viên thành công. ");
                        break;
                    case 4:
                        TimKiemSVTheoten();
                        Console.WriteLine();
                        break;
                    case 5:
                        FSXSVtheoGPA();
                        Console.WriteLine("Sắp xếp sinh viên theo điểm trung bình thành công. ");
                        break;
                    case 6:
                        FSXSVtheoTen();
                        Console.WriteLine("Sắp xếp sinh viên theo tên thành công. ");
                        break;
                    case 7:
                        FSXSVtheoID();
                        Console.WriteLine("Sắp xếp sinh viên theo ID thành công");
                        break;
                    case 8:
                        XuatDSSV();
                        Console.WriteLine();
                        break;
                    case 9:
                        Console.WriteLine("tạm biệt, hẹn gặp lại");
                        break;
                    default:
                        Console.WriteLine("không có chức năng trên,Xin hãy chọn lại !");
                        break;
                }
                Console.ReadKey();
                Console.Clear();
            } while (choice != 9);
        }
        #endregion
    }
}
