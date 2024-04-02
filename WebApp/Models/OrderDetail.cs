using System;
using System.Collections.Generic;

namespace WebApp.Models
{
    public partial class OrderDetail
    {
        public string OrderDetailId { get; set; } = null!;
        public string UserId { get; set; } = null!;
        public int Quantity { get; set; }
        public string TotalPrice { get; set; } = null!;
        public DateTime OrderTime { get; set; }
        public string? Description { get; set; }
        public string? Message { get; set; }
        public string Phone { get; set; } = null!;
        public string DcgiaoHang { get; set; } = null!;
        public string Idsp { get; set; } = null!;

        public virtual SanPham IdspNavigation { get; set; } = null!;

        //Thêm khóa ngoại ánh xạ tới user
        public ApplicationUser ?User {  get; set; } = null!;


    }
}
