using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CardfightVanguardCapstone.Common;
using CardfightVanguardCapstone.Models;
using DataAccessLayer;
using DataAccessLayer.DataClasses;

namespace CardfightVanguardCapstone.Controllers
{
    public class AdminController : Controller
    {
        public DataAccess da { get; set; }
        // GET: Adimin view of the users table
        [HttpGet]
        public ActionResult SelectUsers()
        {
            List<Users> model = new List<Users>();
            da = new DataAccess();
            try
            {
                
                int userID = 0;
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
            catch
            {

            }
            return View();
        } 
        
        [HttpGet]
        public ActionResult  Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(Users model)
        {
            ActionResult oResponse = null;


            try
            {
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
            finally
            {
                oResponse = RedirectToAction("LoginOut", "Admin");
            }
        }

        [HttpGet]
        public ActionResult DeactivateUsers(int UsersToDeactivate)
        {
            List<Users> model = new List<Users>();
            return View("Users", model);
        }
        [HttpGet]
        public ActionResult EditUsers()
        {
            List<Users> model = new List<Users>();
            return View("Users", model);

        }

        [HttpGet]
        public ActionResult LogInOut()
        {
            try
            {
                if (ModelState.IsValid)
                {
                    return View();
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
        [HttpPost]
        public ActionResult LogInOut(Users model)
        {
            
            ActionResult oResponse = null;                                   
            try
            {
                if (ModelState.IsValid)
                {
                   // UserDO 
                    
                    if (//user.Username != null )
                    {
                        //Session["Username"] = user.Username;
                        //Session["Password"] = user.Password;
                        //Session.Timeout = 10;


                        oResponse = RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        oResponse = RedirectToAction("Register", "Admin");
                    }
                    
                }
                else
                {
                    oResponse = RedirectToAction("Register", "Admin");
                }
            }
            catch (Exception error)
            {
                da.LogError(error);
                return View();
            }
            finally
            {
                
            }
            return oResponse;
        }

        [HttpGet]
        public ActionResult EditUsers(int UserstoEdit)
        {
            List<Users> model = new List<Users>();
            return View("Users", model);
        }

    

    }
}

























