using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace CardfightVanguardCapstone.Models
{
    public class AccountLoginViewModel
    {

        public AccountLoginViewModel()
        {
            User = new LoginPO();
            Login = new Login();
            AllUsers = new List<LoginPO>();
        }

        public LoginPO User { get; set; }
        public Login Login { get; set; }
        public List<LoginPO> AllUsers { get; set; }
        public string ErrorMessage { get; set; }
    }
}