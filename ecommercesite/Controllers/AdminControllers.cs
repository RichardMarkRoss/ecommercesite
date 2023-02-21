using ecommercesite.Modals;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using UsersController.Modals;

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
        Public Response addUpdateItems(Items item)
        {
            DAL dal = new DAL();
            sqlConnection connection = new sqlConnection(_configuration.GetConnectionString("Itemsdb").toString());
            Response response = dal.addUpdateItems(item, connection);
            return response;
        }

        [HttpPost]
        [Route("userList")]
        Public Response userList(Items item)
        {
            DAL dal = new DAL();
            sqlConnection connection = new sqlConnection(_configuration.GetConnectionString("Itemsdb").toString());
            Response response = dal.userList(item, connection);
            return response;
        }
