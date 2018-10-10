using CarSystem.Data;
using System.Web.Mvc;

namespace CarSystem.Web.Controllers
{
    public class BaseController : Controller
    {
        protected IUnitOfWork Data {get;private set;}

        public BaseController(IUnitOfWork data)
        {
            this.Data = data;
        }
    }
}