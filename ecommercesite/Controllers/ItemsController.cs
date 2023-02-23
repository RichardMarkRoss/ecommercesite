using ecommercesite.Modals;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using ecommercesite.Modals;

namespace ecommercesite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public ItemsController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost]
        [Route("addToCart")]
        public Response addToCart(Cart cart) {
            DAL dal = new DAL();
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("Itemsdb").ToString());
            Response response = dal.addToCart(cart, connection);
            return response;
        }

        [HttpPost]
        [Route("placeOrder")]
        public Response placeOrder(Users user)
        {
            DAL dal = new DAL();
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("Itemsdb").ToString());
            Response response = dal.placeOrder(user, connection);
            return response;
        }

        [HttpPost]
        [Route("orderList")]
        public Response orderList(Users user)
        {
            DAL dal = new DAL();
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("Itemsdb").ToString());
            Response response = dal.orderList(user, connection);
            return response;
        }
    }

}
