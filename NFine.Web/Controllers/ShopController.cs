using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NFine.Application.ShopManage;
using NFine.Domain.Entity.ShopManage;

namespace NFine.Web.Controllers
{
    public class ShopController : Controller
    {
        //
        // GET: /Shop/

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        public bool CheckLogin(string txtUserName,string txtPassword)
        {
            ShopUserApp.Shop_User sp = new ShopUserApp.Shop_User();
            int id=sp.CheckLogin(txtUserName, txtPassword);
            if (id != 0)
            {
                Session["UserName"] = txtUserName;
                Session["UserID"] = id;
                return true;
            }
            else 
            {
                return false;
            }
        }
    }
}
