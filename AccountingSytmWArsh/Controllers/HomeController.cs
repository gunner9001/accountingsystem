using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AccountingSytmWArsh.Models;
using MySql.Data.MySqlClient;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AccountingSytmWArsh.Controllers
{

    
    public class HomeController : Controller
    {
        public string Check;
        
        public HomeController()
        {
           
        }
        public string Checker()
        {
            return Check;
        }

        [HttpGet]
        public IActionResult Index(string NumberValue)
        {
           
            PasswordAttemptsFormat Dudeit = new PasswordAttemptsFormat();
            MySqlConnection SendUpFiler = new MySqlConnection("server=localhost;user id=root;persistsecurityinfo=True;database=restuarantdata;password=loler9001");
            SendUpFiler.Open();
            MySqlCommand Sending = new MySqlCommand("select PasswordAttempts from accountsystem_passwordattempts where ID=2", SendUpFiler);
            var Whatisit = Sending.ExecuteScalar();
            string WhatIT = Convert.ToString(Whatisit);
            
            if (NumberValue == WhatIT)
            {
                MySqlCommand MakeItNull = new MySqlCommand("UPDATE `restuarantdata`.`accountsystem_passwordattempts` SET `PasswordAttempts` = NULL WHERE (`ID` = '2')", SendUpFiler);
                MakeItNull.ExecuteNonQuery();
                SendUpFiler.Close();
                return View();
                
            }
            else
            {
                SendUpFiler.Close();
                return View("WrongPasswordView");
            }
        }
        [HttpPost]
        public IActionResult Index()
        {
            return Content("Whar");
        }
    }
}
