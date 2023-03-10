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
    public class AdminController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public AdminController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost]
        [Route("addUpdateItems")]
        public Response addUpdateItems(Items item)
        {
            DAL dal = new DAL();
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("ItemsdbLocal").ToString());
            Response response = dal.addUpdateItems(item, connection);
            return response;
        }

        [HttpPost]
        [Route("userList")]
        public Response userList(Users users)
        {
            DAL dal = new DAL();
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("ItemsdbLocal").ToString());
            Response response = dal.viewUser(users, connection);
            return response;
        }
    }
}