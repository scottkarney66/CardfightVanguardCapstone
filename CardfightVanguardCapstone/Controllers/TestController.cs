using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//using BuisnessLayer;
using CardfightVanguardCapstone.Common;
using CardfightVanguardCapstone.Models;
using DataAccessLayer;

namespace CardfightVanguardCapstone.Controllers
{

    public class TestController : Controller
    {
        public DataAccess da { get; set; }
        // GET: Test
        public ActionResult DataTableExample()
        {
            return View();
        }

        public ActionResult MessageExample()
        {

            Message m = new Message();
            m.State = "error";
            if (ModelState.IsValid)
            {
                if (m.State == "success")
                {
                    //do something
                    m.Description = "Success message text";
                    return View(m);
                }
                else
                {
                    m.Description = "Error occurred!!!!!!!";
                    return View(m);
                }


            }

            else
            {
                return View();
            }
            //return View();
        }

        public ActionResult SelectUsers()
        {
            List<Users> model = new List<Users>();
            //Users u = new Users();
            da = new DataAccess();
            int userID = 0;
            try
            {
                //testing only
                
                model = Mapper.Map(da.getUserall(userID));
                if (ModelState.IsValid)
                {


                    return View(model);


                }
                else
                {
                    return View();
                }

            }
            catch (Exception error)
            {

                da.LogError(error);
                return View();

            }






        }
        
    }
}