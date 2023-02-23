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
        Public Response addToCart(Cart cart) {
            DAL dal = new DAL();
            sqlConnection connection = new sqlConnection(_configuration.GetConnectionString("Itemsdb").toString());
            Response response = dal.addToCart(cart, connection);
            return response;
        }

        [HttpPost]
        [Route("placeOrder")]
        Public Response placeOrder(Users user)
        {
            DAL dal = new DAL();
            sqlConnection connection = new sqlConnection(_configuration.GetConnectionString("Itemsdb").toString());
            Response response = dal.placeOrder(user, connection);
            return response;
        }

        [HttpPost]
        [Route("orderList")]
        Public Response orderList(Users user)
        {
            DAL dal = new DAL();
            sqlConnection connection = new sqlConnection(_configuration.GetConnectionString("Itemsdb").toString());
            Response response = dal.orderList(user, connection);
            return response;
        }
    }

}
