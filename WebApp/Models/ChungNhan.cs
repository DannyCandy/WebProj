using System;
using System.Collections.Generic;

namespace WebApp.Models
{
    public partial class ChungNhan
    {
        public ChungNhan()
        {
            SanPhams = new HashSet<SanPham>();
        }

        public string IdchungNhan { get; set; } = null!;
        public string MoTa { get; set; } = null!;
        public byte[] HinhAnhChungNhan { get; set; } = null!;

        public virtual ICollection<SanPham> SanPhams { get; set; }
    }
}
