using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AccountingSytmWArsh.Controllers
{
    [Route ("/ChangePassword")]
    public class ChangePasswordController : Controller
    {
        [Route ("")] [HttpGet]
        public IActionResult ChangePasswordView()
        {
            return View();
        }
        [HttpPost]
        public IActionResult ChangePasswordView(string Oldone, string Newone)
        {
            string oknow = Oldone;
            string Arshisfat = Eramake.eCryptography.Encrypt(oknow);
            MySqlConnection bobthebuilder = new MySqlConnection("server=localhost;user id=root;persistsecurityinfo=True;database=restuarantdata;password=loler9001");
            bobthebuilder.Open();
            MySqlCommand WOwfatgy = new MySqlCommand("select CurrentPassword from accountsystem_currentpassword where ID=1",bobthebuilder);
            var fatman = WOwfatgy.ExecuteScalar();
            string fatmandude = Convert.ToString(fatman);
            bobthebuilder.Close();
            if(Arshisfat == fatmandude)
            {
                string NewNewOne = Eramake.eCryptography.Encrypt(Newone);
                MySqlConnection fatboyarsh = new MySqlConnection("server=localhost;user id=root;persistsecurityinfo=True;database=restuarantdata;password=loler9001");
                fatboyarsh.Open();
                MySqlCommand boyfatarsh = new MySqlCommand("UPDATE `restuarantdata`.`accountsystem_currentpassword` SET `CurrentPassword` = '"+NewNewOne+"' WHERE (`ID` = '1');", fatboyarsh);
                boyfatarsh.ExecuteNonQuery();
                return View("Index");
            }
            else
            {
                MySqlConnection PasswordGet = new MySqlConnection("server=localhost;user id=root;persistsecurityinfo=True;database=restuarantdata;password=loler9001");
                PasswordGet.Open();
                MySqlCommand RetrieveAttempts = new MySqlCommand("select PasswordAttempts from accountsystem_passwordattempts where ID=1", PasswordGet);
                var PassVar = RetrieveAttempts.ExecuteScalar();
                int PassInt = Convert.ToInt32(PassVar);
                int NewPassInt = PassInt + 1;
                MySqlCommand UpdateAtt = new MySqlCommand("UPDATE `restuarantdata`.`accountsystem_passwordattempts` SET `PasswordAttempts` = '" + NewPassInt + "' WHERE (`ID` = '1')", PasswordGet);
                UpdateAtt.ExecuteNonQuery();
                PasswordGet.Close();
                if (NewPassInt >= 10)
                {
                    return View("Lockout");
                }
                else
                {
                    return View("WrongPasswordView");
                }

                
            }
        }
    }
}
