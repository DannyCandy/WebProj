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

        public string Idnpp { get; set; } 
        public string TenNpp { get; set; } 
        public string DiaChiNpp { get; set; }
        [Column(TypeName = "nvarchar(max)")]
        public string? HinhAnhNPP { get; set; } = null!;
        public TimeSpan GioMoCua { get; set; }
        public TimeSpan GioDongCua { get; set; }
        [Required]
        public string PhoneNpp { get; set; } = null!;

        public virtual ICollection<SanPham> SanPhams { get; set; }
    }
}
