using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        [Column(TypeName = "nvarchar(max)")]
        public string? HinhAnhNPP { get; set; } = null!;
        public TimeSpan GioMoCua { get; set; }
        public TimeSpan GioDongCua { get; set; }
        [Required]
        public string PhoneNpp { get; set; } = null!;

        public virtual ICollection<SanPham> SanPhams { get; set; }
    }
}
