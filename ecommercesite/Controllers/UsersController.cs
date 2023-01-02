﻿using ecommercesite.Modals;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace ecommercesite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public UsersController(IConfiguration configuration)
        {
            _configuration= configuration;
        }

        [HttpPost]
        [Route("registration")]
        public Response register(Users users) { 
            Response response = new Response();
            DAL dal = new DAL();
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("EItemCS").ToString());
            response = dal.register(users, connection);
            return response;

        }
    }
}
