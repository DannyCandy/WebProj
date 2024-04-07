namespace WebApp.Models
{
    public partial class Order
    {
        public string OrderId { get; set; } = null!;
        public string UserId { get; set; } = null!;
        public string TotalPrice { get; set; } = null!;
        public DateTime OrderTime { get; set; }
        public string? Message { get; set; }

        //Thêm khóa ngoại ánh xạ tới user
        public ApplicationUser? User { get; set; } = null!;

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
