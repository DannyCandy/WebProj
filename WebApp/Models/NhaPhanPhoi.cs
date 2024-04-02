using System;
using System.Collections.Generic;

namespace WebApp.Models
{
    public partial class NhaPhanPhoi
    {
        public NhaPhanPhoi()
        {
            SanPhams = new HashSet<SanPham>();
        }

        public string Idnpp { get; set; } = null!;
        public string TenNpp { get; set; } = null!;
        public string DiaChiNpp { get; set; } = null!;
        public TimeSpan GioMoCua { get; set; }
        public TimeSpan GioDongCua { get; set; }
        public string PhoneNpp { get; set; } = null!;

        public virtual ICollection<SanPham> SanPhams { get; set; }
    }
}
