using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebCau3.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string HoTen { get; set; }
        public GioiTinh GioiTinh { get; set; }
    }
}