using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AccountingSytmWArsh.Models;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AccountingSytmWArsh.Controllers
{
    [Route ("")]
    public class PasswordController : Controller
    {
        [Route ("")] [HttpGet]
        public IActionResult PasswordView()
        {
            MySqlConnection SeeCheck = new MySqlConnection("server=localhost;user id=root;persistsecurityinfo=True;database=restuarantdata;password=loler9001");
            SeeCheck.Open();
            MySqlCommand RetrieveCheck = new MySqlCommand("select PasswordAttempts from accountsystem_passwordattempts where ID=1", SeeCheck);
            var SeeVar = RetrieveCheck.ExecuteScalar();
            int SeeInt = Convert.ToInt32(SeeVar);
            SeeCheck.Close();
            if (SeeInt >= 10)
            {
                return View("Lockout");
            }
            else
            {
                return View();
            }
        }

        
        [HttpPost]
        public IActionResult PasswordView(string Password)
        {
            MySqlConnection boblefttowntoeatpizza = new MySqlConnection("server=localhost;user id=root;persistsecurityinfo=True;database=restuarantdata;password=loler9001");
            boblefttowntoeatpizza.Open();
            MySqlCommand bobthelittleboy = new MySqlCommand("select CurrentPassword from accountsystem_currentpassword where ID=1",boblefttowntoeatpizza);
           var chocolate = bobthelittleboy.ExecuteScalar();
            string Snickers = Convert.ToString(chocolate);
            boblefttowntoeatpizza.Close();
            string decrypted = Eramake.eCryptography.Decrypt(Snickers);
            if (Password == decrypted)
            {
                MySqlConnection Bobgurgle = new MySqlConnection("server=localhost;user id=root;persistsecurityinfo=True;database=restuarantdata;password=loler9001");
                Bobgurgle.Open();
                MySqlCommand fatboybobleftown = new MySqlCommand("UPDATE `restuarantdata`.`accountsystem_passwordattempts` SET `PasswordAttempts` = '0' WHERE (`ID` = '1');",Bobgurgle);
                fatboybobleftown.ExecuteNonQuery();
                Bobgurgle.Close();
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
                MySqlCommand UpdateAtt = new MySqlCommand("UPDATE `restuarantdata`.`accountsystem_passwordattempts` SET `PasswordAttempts` = '"+NewPassInt+"' WHERE (`ID` = '1')",PasswordGet);
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
