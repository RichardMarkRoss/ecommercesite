namespace ecommercesite.Modals
{
    public class Response
    {
        public int StatueCode { get; set; }
        public string StatusMessage { get; set; }

        public List<Users> ListUsers { get; set; }
        public Users users { get; set; }

        public List<Items> ListItems { get; set; }
        public Items items { get; set; }

        public List<Cart> ListCart { get; set; }
        public Cart cart { get; set; }

        public List<Orders> ListOrders { get; set; }
        public Orders orders { get; set; }

        public List<OrderItems> ListOrderItems { get; set; }
        public OrderItems orderItems { get; set; }
    }
}
