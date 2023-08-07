using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSV
{
    internal class SXSVTheoGPA : IComparer<QLSV.SinhVien>
    {
        public int Compare(QLSV.SinhVien x, QLSV.SinhVien y)
        {
            SinhVien sv1 = x as SinhVien;
            SinhVien sv2 = y as SinhVien;
            if (sv1 == null || sv2 == null)
            {
                throw new InvalidOperationException();
            }
            else
            {
                if (sv1.DTB() < sv2.DTB())
                {
                    return 1;
                }
                else if (sv1.DTB() == sv2.DTB())
                {
                    return 0;
                }
                else
                {
                    return -1;
                }
            }
        }
    }
}
