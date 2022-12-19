using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TP3.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            Debug.WriteLine("Opening connection ");
            SQLiteConnection dbCon = new SQLiteConnection(@"Data Source=C:\\Users\\USER\\Desktop\\.NET\\TP3.db;");
            dbCon.Open();

            using (dbCon)
            {
                SQLiteCommand cmd = new SQLiteCommand("SELECT * FROM personal_info", dbCon);
                SQLiteDataReader reader = cmd.ExecuteReader();
                using (reader)
                {
                    while (reader.Read())
                    {
                        int id = (int)reader["id"];
                        string first_name = (string)reader["first_name"];
                        string last_name = (string)reader["last_name"];
                        string email = (string)reader["email"];
                        //   DateTime date_birth = Convert.ToDateTime((string)reader["date_birth"].ToString());
                        string image = (string)reader["image"];
                        string country = (string)reader["country"];

                        Debug.WriteLine("id = {0} first name = {1}  last name = {2}  email={3}  image= {4}  country= {5}  date=", id, first_name, last_name, email, image, country);
                    }


                }
            }

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}