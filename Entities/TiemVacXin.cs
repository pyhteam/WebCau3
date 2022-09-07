using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebCau3.Entities
{
    public class TiemVacXin
    {
        public int Id { get; set; }
        public string HoTen { get; set; }
        public int XiNghiepId { get; set; }
        public bool GioiTinh { get; set; }
        public bool Status { get; set; }
    }
}