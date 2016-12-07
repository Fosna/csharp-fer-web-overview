using CourseWork.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseWork.Controllers
{
    public class MessageController : Controller
    {
        public IActionResult Index(MessageVm messageModel)
        {
            return View(messageModel);
        }
    }
}
