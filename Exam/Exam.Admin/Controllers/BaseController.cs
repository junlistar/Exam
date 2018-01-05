using Exam.Admin.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Exam.Admin.Controllers
{
    [AccountAuthorize]
    public class BaseController : Controller
    {
      
    }
}