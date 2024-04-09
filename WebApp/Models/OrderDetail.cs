using System;
using System.Collections.Generic;

namespace WebApp.Models
{
    public partial class OrderDetail
    {
        public string OrderDetailId { get; set; } = null!;
        public int Quantity { get; set; }
        public string Idsp { get; set; } = null!;

        public string OrderId { get; set; } = null!;

        public virtual SanPham IdspNavigation { get; set; } = null!;

        //Thêm khóa ngoại nhiều nhiều tới Order
        public virtual Order OrderIdNavigation { get; set; } = null!;


    }
}
