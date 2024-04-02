using System;
using System.Collections.Generic;

namespace WebApp.Models
{
    public partial class ThongTinLienHe
    {
        public string UserId { get; set; } = null!;
        public string Idttlh { get; set; } = null!;
        public string? Phone { get; set; }
        public string? DcgiaoHang { get; set; }

        //Thêm khóa ngoại ánh xạ tới User
        public ApplicationUser User { get; set; } = null!;
    }
}
