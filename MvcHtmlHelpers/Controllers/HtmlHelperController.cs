using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcHtmlHelpers.Models;

namespace MvcHtmlHelpers.Controllers
{
    public class HtmlHelperController : Controller
    {
        // Sample User Data
        User register = new User
        {
            Id = 1001,
            Name = "David",
            Nickname = "Bibby",
            Email = "david@gmail.com",
            City = 2,
            Terms = true
        };

        // GET: SampleHelper
        public ActionResult SampleHelpers()
        {
            ViewData.Model = register;

            return View();
        }

        /// <summary>
        /// 顯示
        /// </summary>
        /// <returns></returns>
        public ActionResult ValidateMessage()
        {
            return View();
        }

        /// <summary>
        /// 接收網頁前端表單來的資料
        /// </summary>
        /// <param name="user"> 使用者資訊物件 </param>
        /// <returns>  </returns>
        [HttpPost]
        public ActionResult ValidateMessage(User user)
        {
            if (ModelState.IsValid)
                return Content("成功");
            return View(user);
        }

        /// <summary>
        /// EditorFor Sample View
        /// </summary>
        /// <returns> Register Form </returns>
        public ActionResult EditorFor()
        {
            // Sample Register Data
            List<RegisterDataAnnotations> registers = new List<RegisterDataAnnotations>
            {
                new RegisterDataAnnotations
                {
                    Id          = 1,
                    Name        = "David",
                    Password    = "123456",
                    Email       = "david@gmail.com",
                    Blog        = "https://blog.com.tw",
                    Gender      = Gender.Male,
                    Birthday2   = new DateTime(1980, 5, 22),
                    Income      = 50000,
                    City        = 4,
                    Terms       = true

                }
            };

            return View(registers.FirstOrDefault());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult HelperBootstrap()
        {
            return View(register);
        }
    }
}