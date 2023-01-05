using System.Data.SqlClient;
using System.Data;

namespace ecommercesite.Modals
{
    public class DAL
    {
        public Response register(Users users, SqlConnection connection)
        {
            Response response = new Response();
            SqlCommand cmd= new SqlCommand("sp_register", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FirstName", users.FirstName);
            cmd.Parameters.AddWithValue("@LastName", users.LastName);
            cmd.Parameters.AddWithValue("@Email", users.Email);
            cmd.Parameters.AddWithValue("@Username", users.Username);
            cmd.Parameters.AddWithValue("@Password", users.Password);
            cmd.Parameters.AddWithValue("@Funds", 0);
            cmd.Parameters.AddWithValue("@Type", "Users");
            cmd.Parameters.AddWithValue("@Status", "pending");

            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();
            if (i > 0)
            {
                response.StatueCode = 200;
                response.StatusMessage = "User Registered Successfully!";
            }
            else {
                response.StatueCode = 200;
                response.StatusMessage = "User Registration Failed!";
            }

            return response;    

        }
        public Response login(Users users, SqlConnection connection) 
        {
            SqlDataAdapter da = new SqlDataAdapter("sp_login", connection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.AddWithValue("@Email", Users.Email);
            da.SelectCommand.Parameters.AddWithValue("@Password", Users.Password);
            DataTable dt = new DataTable();
            da.Fill(dt);
            Response response = new Response();
            Users user = new Users();
            if (dt.Rows.Count > 0) {
                user.ID = Convert.ToInt32(dt.Rows[0]["ID"]);
                user.FirstName = Convert.ToString(dt.Rows[0]["FirstName"]);
                user.LastName = Convert.ToString(dt.Rows[0]["LastName"]);
                user.Email = Convert.ToString(dt.Rows[0]["Email"]);
                user.Type = Convert.ToString(dt.Rows[0]["Type"]);

                response.StatueCode=200;
                response.StatusMessage = "User is valid!";
                response.user = user;
            }
            else { 
                response.StatueCode=100;
                response.StatusMessage = "User is invalid!";
                response.user = null;
            }
            return response;
           
        }
        public Response viewUser(Users users, SqlConnection connection) 
        {
            SqlDataAdapter da = new SqlDataAdapter("p_viewUser", connection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.AddWithValue("@ID", Users.ID);
            DataTable dt = new DataTable();
            da.Fill(dt);
            Response response = new Response();
            Users user = new Users();
            if (dt.Rows.Count > 0) {
                user.ID = Convert.ToInt32(dt.Rows[0]["ID"]);
                user.FirstName = Convert.ToString(dt.Rows[0]["FirstName"]);
                user.LastName = Convert.ToString(dt.Rows[0]["LastName"]);
                user.Email = Convert.ToString(dt.Rows[0]["Email"]);
                user.Type = Convert.ToString(dt.Rows[0]["Type"]);
                user.Funds = Convert.ToDecimal(dt.Rows[0]["Funds"]);
                user.CreatedOn = Convert.ToDateTime(dt.Rows[0]["CreatedOn"]);
                user.Password = Convert.ToString(dt.Rows[0]["Password"]);
                response.StatueCode=200;
                response.StatusMessage = "User exist";
                response.user = user;
            }
            else { 
                response.StatueCode=100;
                response.StatusMessage = "User does not exist!";
                response.user = null;
            }
            return response;
        }
        public Response updateProfile(Users users, SqlConnection connection) 
        {
            Response response = new Response();
            SqlCommand cmd = new SqlCommand("sp_updateProfile", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FirstName", users.FirstName);
            cmd.Parameters.AddWithValue("@LasrName", users.LasrName);
            cmd.Parameters.AddWithValue("@Password", users.Password);
            cmd.Parameters.AddWithValue("@Email", users.Email);
            connection.Open();
            int i cmd.ExecuteNonQuery();
            connection.Close();
            if (i>0) {
                response.StatueCode = 200;
                response.StatusMessage = "Record Updated Successfully!";
            }
            else {
                response.StatueCode = 100;
                response.StatusMessage = "Record Update Failed!";
            }
            return response;
        }
    }
}
