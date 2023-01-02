namespace ecommercesite.Modals
{
    public class Orders
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public string OrderNo { get; set; }
        public string Orderstatus { get; set; }
        public decimal OrderTotal { get; set; }


    }
}
