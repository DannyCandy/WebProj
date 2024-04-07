using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

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
        [Column(TypeName = "nvarchar(max)")]
        public string? HinhAnhChungNhan { get; set; } = null!;

        public virtual ICollection<SanPham> SanPhams { get; set; }
    }
}
