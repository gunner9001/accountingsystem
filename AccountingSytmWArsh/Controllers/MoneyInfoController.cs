using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using System.Security.Cryptography;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AccountingSytmWArsh.Controllers
{
    [Route("/Money")]
    public class MoneyInfoController : Controller
    {
        [Route("MoneyPage/{id}")] [HttpGet]
        public IActionResult MoneyInfoView(string id)
        {
            MySqlConnection HeLetftowun = new MySqlConnection("server=localhost;user id=root;persistsecurityinfo=True;database=restuarantdata;password=loler9001");
            HeLetftowun.Open();
            MySqlCommand Findhim = new MySqlCommand("select PasswordAttempts from accountsystem_passwordattempts where ID=2", HeLetftowun);
            var blahab = Findhim.ExecuteScalar();
            string blob = Convert.ToString(blahab);
            HeLetftowun.Close();
            if (id == blob)
            {
                return View();
               
            }
            else
            {
                return View("WrongPasswordView");
            }
        }
        [Route ("MoneyPage/{id}")] [HttpPost]
        public IActionResult MoneyInfoView(string State,string Date, string What, string Where, string Amount, string id)
        {

          if(State == "Coming")
          {
                MySqlConnection Connecting = new MySqlConnection("server=localhost;user id=root;persistsecurityinfo=True;database=restuarantdata;password=loler9001");
                Connecting.Open();
                MySqlCommand Flush = new MySqlCommand("INSERT INTO `restuarantdata`.`accountsystem_moneyinfo` (`Date`, `What`, `Wheres`, `Amount`) VALUES ('" + Date+"', '"+What+"', '"+Where+ "', '" + Amount + "');", Connecting);
                Flush.ExecuteNonQuery();
                MySqlCommand UpdateAdd = new MySqlCommand("select Current from accountsystem_currentmoney where ID=1",Connecting);
                var Uper = UpdateAdd.ExecuteScalar();
                string Uperint = Convert.ToString(Uper);
                int UperRint = Convert.ToInt32(Uperint);
                int better = UperRint + Convert.ToInt32(Amount);
                MySqlCommand Uperman = new MySqlCommand("UPDATE `restuarantdata`.`accountsystem_currentmoney` SET `Current` = '"+better+"' WHERE (`ID` = '1');",Connecting);
                Uperman.ExecuteNonQuery();
                Connecting.Close();
          }
          else if(State == "Going")
          {
                MySqlConnection Bobbsconn = new MySqlConnection("server=localhost;user id=root;persistsecurityinfo=True;database=restuarantdata;password=loler9001");
                Bobbsconn.Open();
                MySqlCommand Fh = new MySqlCommand("INSERT INTO `restuarantdata`.`accountsystem_moneyinfo` (`Date`, `What`, `Wheres`, `Amount`) VALUES ('" + Date + "', '" + What + "', '" + Where + "', '" + Amount + "');", Bobbsconn);
                Fh.ExecuteNonQuery();

                MySqlCommand UpdateAdd = new MySqlCommand("select Current from accountsystem_currentmoney where ID=1", Bobbsconn);
                var Uper = UpdateAdd.ExecuteScalar();
                string Uperint = Convert.ToString(Uper);
                int UperRint = Convert.ToInt32(Uperint);
                int better = UperRint - Convert.ToInt32(Amount);
                MySqlCommand Uperman = new MySqlCommand("UPDATE `restuarantdata`.`accountsystem_currentmoney` SET `Current` = '" + better + "' WHERE (`ID` = '1');", Bobbsconn);
                Uperman.ExecuteNonQuery();
                Bobbsconn.Close();
            }
            return View("Index");
        }
    }
}
