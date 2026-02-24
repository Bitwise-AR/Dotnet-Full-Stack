using Microsoft.AspNetCore.Mvc;
using MVCCrud.Models;
using Microsoft.Data.SqlClient;

namespace MVCCrud.Controllers
{
    public class HomeController : Controller
    {
        private string connectionString =
            "Data Source=AYUSH\\SQLEXPRESS;Database=MVC_With_ADO;Trusted_Connection=True;TrustServerCertificate=True;";

        // LOAD PAGE
        public IActionResult Index()
        {
            ViewBag.EditUser = new User();
            return View(GetUsers());
        }

        // GET ALL USERS
        private List<User> GetUsers()
        {
            List<User> users = new List<User>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Users", conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    users.Add(new User
                    {
                        Id = (int)reader["Id"],
                        Name = reader["Name"].ToString(),
                        Email = reader["Email"].ToString(),
                        Age = (int)reader["Age"]
                    });
                }
            }

            return users;
        }

        // CREATE OR UPDATE
        [HttpPost]
        public IActionResult Save(User user)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.EditUser = user;
                return View("Index", GetUsers());
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd;

                if (user.Id == 0)
                {
                    cmd = new SqlCommand(
                        "INSERT INTO Users VALUES (@Name,@Email,@Age)", conn);
                }
                else
                {
                    cmd = new SqlCommand(
                        "UPDATE Users SET Name=@Name,Email=@Email,Age=@Age WHERE Id=@Id", conn);
                    cmd.Parameters.AddWithValue("@Id", user.Id);
                }

                cmd.Parameters.AddWithValue("@Name", user.Name);
                cmd.Parameters.AddWithValue("@Email", user.Email);
                cmd.Parameters.AddWithValue("@Age", user.Age);

                cmd.ExecuteNonQuery();
            }

            return RedirectToAction("Index");
        }

        // DELETE
        public IActionResult Delete(int id)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM Users WHERE Id=@Id", conn);
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.ExecuteNonQuery();
            }

            return RedirectToAction("Index");
        }

        // LOAD EDIT DATA
        public IActionResult Edit(int id)
        {
            User user = new User();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Users WHERE Id=@Id", conn);
                cmd.Parameters.AddWithValue("@Id", id);

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    user.Id = (int)reader["Id"];
                    user.Name = reader["Name"].ToString();
                    user.Email = reader["Email"].ToString();
                    user.Age = (int)reader["Age"];
                }
            }

            ViewBag.EditUser = user;
            return View("Index", GetUsers());
        }
    }
}