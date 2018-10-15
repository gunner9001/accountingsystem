using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AccountingSytmWArsh.Controllers
{
    [Route ("/Delete/{id}/{MoreID}")]
    public class DeleteInfoController : Controller
    {
        public string Valuess;
        [Route ("")] [HttpGet]
        public IActionResult DeleteInfoView(string id, string MoreID)
        {
            MySqlConnection CheckCon = new MySqlConnection("server = localhost; user id = root; persistsecurityinfo = True; database = restuarantdata; password = loler9001");
            CheckCon.Open();
            MySqlCommand Gett = new MySqlCommand("select PasswordAttempts from accountsystem_passwordattempts where ID=2", CheckCon);
            var ICheckVar = Gett.ExecuteScalar();
            CheckCon.Close();
            string ICheck = Convert.ToString(ICheckVar);
            if(id==ICheck)
            {
                return View();
            }
            else
            {
                return View("WrongPasswordView");
            }
        }
        [HttpPost]
        public IActionResult DeleteInfoView(string IDValue)
        {
            MySqlConnection bobeatsBhinda = new MySqlConnection("server = localhost; user id = root; persistsecurityinfo = True; database = restuarantdata; password = loler9001");
            bobeatsBhinda.Open();
            MySqlCommand ChangeToday = new MySqlCommand("delete from accountsystem_moneyinfo where ID ='"+ IDValue +"' ", bobeatsBhinda);
            ChangeToday.ExecuteNonQuery();
            bobeatsBhinda.Close();
            
           
            return View("Index");
        }
    }
}
