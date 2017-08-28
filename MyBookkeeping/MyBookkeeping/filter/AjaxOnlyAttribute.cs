using System;
using System.Web.Mvc;

namespace MyBookkeeping.filter
{
    public sealed class AjaxOnlyAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext == null)
                throw new ArgumentNullException(nameof(filterContext));

            if (!filterContext.HttpContext.Request.IsAjaxRequest())
                filterContext.Result = new HttpNotFoundResult();
        }
    }

}