namespace MBDEVproAPI.API.Controllers  
{

    [ApiController, AllowAnonymous, Route("api/[controller]/[action]")]

    public class BaseController : Controller
    {

        #region variables and constructors

        public BaseController() { }

        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            // our code before action executes
        }

    }
}
