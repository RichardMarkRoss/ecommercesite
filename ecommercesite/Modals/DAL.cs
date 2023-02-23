using System.Data.SqlClient;
using System.Data;

namespace ecommercesite.Modals
{
    public class DAL
    {
        public Response register(Users users, SqlConnection connection)
        {
            Response response = new Response();
            SqlCommand cmd = new SqlCommand("sp_register", connection);
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
            da.SelectCommand.Parameters.AddWithValue("@Email", users.Email);
            da.SelectCommand.Parameters.AddWithValue("@Password", users.Password);
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

                response.StatueCode = 200;
                response.StatusMessage = "User is valid!";
                response.users = user;
            }
            else {
                response.StatueCode = 100;
                response.StatusMessage = "User is invalid!";
                response.users = null;
            }
            return response;

        }
        public Response viewUser(Users users, SqlConnection connection)
        {
            SqlDataAdapter da = new SqlDataAdapter("p_viewUser", connection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.AddWithValue("@ID", users.ID);
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
                response.StatueCode = 200;
                response.StatusMessage = "User exist";
                response.users = user;
            }
            else {
                response.StatueCode = 100;
                response.StatusMessage = "User does not exist!";
                response.users = null;
            }
            return response;
        }
        public Response updateProfile(Users users, SqlConnection connection)
        {
            Response response = new Response();
            SqlCommand cmd = new SqlCommand("sp_updateProfile", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FirstName", users.FirstName);
            cmd.Parameters.AddWithValue("@LasrName", users.LastName);
            cmd.Parameters.AddWithValue("@Password", users.Password);
            cmd.Parameters.AddWithValue("@Email", users.Email);
            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();
            if (i > 0) {
                response.StatueCode = 200;
                response.StatusMessage = "Record Updated Successfully!";
            }
            else {
                response.StatueCode = 100;
                response.StatusMessage = "Record Update Failed!";
            }
            return response;
        }
        public Response addToCart(Cart cart, SqlConnection connection)
        {
            Response response = new Response();
            SqlCommand cmd = new SqlCommand("sp_AddToCart", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@userID", cart.UserID);
            cmd.Parameters.AddWithValue("@ItemsID", cart.ItemsID);
            cmd.Parameters.AddWithValue("@UnitPrice", cart.UnitPrice);
            cmd.Parameters.AddWithValue("@Discount", cart.Discount);
            cmd.Parameters.AddWithValue("@Quantity", cart.Quantity);
            cmd.Parameters.AddWithValue("@TotalPrice", cart.TotalPrice);
            cmd.Parameters.AddWithValue("@ItemID", cart.ItemID);
            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();
            if (i > 0) {
                response.StatueCode = 200;
                response.StatusMessage = "Item Added Successfully!";
            }
            else {
                response.StatueCode = 100;
                response.StatusMessage = "item Failed to add!";
            }
            return response;
        }
        public Response placeOrder(Users users, SqlConnection connection)
        {
            Response response = new Response();
            SqlCommand cmd = new SqlCommand("sp_PlaceOrder", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID", users.ID);
            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();
            if (i > 0) {
                response.StatueCode = 200;
                response.StatusMessage = "Order placed Successfully!";
            }
            else {
                response.StatueCode = 100;
                response.StatusMessage = "Order Failed to add!";
            }
            return response;
        }
        public Response orderList(Users users, SqlConnection connection)
        {
            Response response = new Response();
            List<Orders> listOrders = new List<Orders>();
            SqlDataAdapter da = new SqlDataAdapter("sp_OrderList", connection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.AddWithValue("@Type", users.Type);
            da.SelectCommand.Parameters.AddWithValue("@Id", users.ID);
            da.SelectCommand.ExecuteNonQuery();

            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0) {
                for (int i = 0; i > dt.Rows.Count; i++)
                {
                    Orders orders = new Orders();
                    orders.ID = Convert.ToInt32(dt.Rows[i]["ID"]);
                    orders.OrderNo = Convert.ToString(dt.Rows[i]["OrderNumber"]);
                    orders.OrderTotal = Convert.ToDecimal(dt.Rows[i]["OrderTotal"]);
                    orders.Orderstatus = Convert.ToString(dt.Rows[i]["OrderStatus"]);
                    listOrders.Add(orders);
                    if (listOrders.Count > 0)
                    {
                        response.StatueCode = 200;
                        response.StatusMessage = "Order Details Fetched!";
                        response.ListOrders = listOrders;
                    }
                    else
                    {
                        response.StatueCode = 100;
                        response.StatusMessage = "Order Details not available!";
                        response.ListOrders = null;
                    }
                }
            } else {
                response.StatueCode = 100;
                response.StatusMessage = "Order Details not available!";
                response.ListOrders = null;
            }
            return response;
        }
        public Response addUpdateItems(Items item, SqlConnection connection)
        {
            Response response = new Response();
            SqlCommand cmd = new SqlCommand("sp_AddUpdateItems", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Name", item.Name);
            cmd.Parameters.AddWithValue("@Manufacturer", item.Manufacturer);
            cmd.Parameters.AddWithValue("@UnitPrice", item.UnitPrice);
            cmd.Parameters.AddWithValue("@Quantity", item.Quantity);
            cmd.Parameters.AddWithValue("@ExpDate", item.ExpDate);
            cmd.Parameters.AddWithValue("@ImageUrl", item.ImageURL);
            cmd.Parameters.AddWithValue("@Status", item.Status);
            cmd.Parameters.AddWithValue("@Type", item.Type);
            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();
            if (i > 0)
            {
                response.StatueCode = 200;
                response.StatusMessage = "Items inserted successfully!";
            }
            else
            {
                response.StatueCode = 100;
                response.StatusMessage = "Items Failed to be inserted!";
            }
            return response;
        }
        public Response userList(Items item, SqlConnection connection)
        {
            Response response = new Response();
            List<Users> listUsers = new List<Orders>();
            SqlDataAdapter da = new SqlDataAdapter("sp_UserList", connection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.AddWithValue("@Type", item.Type);
            da.SelectCommand.Parameters.AddWithValue("@Id", item.ID);
            da.SelectCommand.ExecuteNonQuery();

            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i > dt.Rows.Count; i++)
                {
                    Users user = new Users();
                    user.ID = Convert.ToInt32(dt.Rows[i]["ID"]);
                    user.FirstName = Convert.ToString(dt.Rows[i]["FirstName"]);
                    user.LastName = Convert.ToString(dt.Rows[i]["LastName"]);
                    user.Password = Convert.ToString(dt.Rows[i]["Password"]);
                    user.Email = Convert.ToString(dt.Rows[i]["Email"]);
                    user.Funds = Convert.ToDecimal(dt.Rows[i]["Fund"]);
                    user.Status = Convert.ToInt32(dt.Rows[i]["status"]);
                    user.CreatedOn = Convert.ToDateTime(dt.Rows[i]["CreatedOn"]);
                    listUsers.Add(user);
                    if (listUsers.Count > 0)
                    {
                        response.StatueCode = 200;
                        response.StatusMessage = "User Details Fetched!";
                        response.ListUsers = listUsers;
                    }
                    else
                    {
                        response.StatueCode = 100;
                        response.StatusMessage = "User Details not available!";
                        response.ListUsers = null;
                    }
                }
            }
            else
            {
                response.StatueCode = 100;
                response.StatusMessage = "User Details not available!";
                response.ListUsers = null;
            }
            return response;
        }
    }
 }
