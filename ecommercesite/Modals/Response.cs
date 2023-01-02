namespace ecommercesite.Modals
{
    public class Response
    {
        public int StatueCode { get; set; }
        public string StatusMessage { get; set; }

        public List<Users> ListUsers { get; set; }
        public Users user { get; set; }

        public List<Items> ListItems { get; set; }
        public Items item { get; set; }

        public List<Cart> ListCart { get; set; }
        public Cart cart { get; set; }
    }
}
