using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MyBookkeeping.filter
{
    public class AuthorizePlusAttribute : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            base.OnAuthorization(filterContext);

            #region 要有這段擴充才有用

            //支援 MVC5 新增的 AllowAnonymous
            var skipAuthorization =
                filterContext.ActionDescriptor.IsDefined(typeof(AllowAnonymousAttribute), inherit: true) ||
                filterContext.ActionDescriptor.ControllerDescriptor.IsDefined(typeof(AllowAnonymousAttribute),
                                                                              inherit: true);

            //有設定 AllowAnonymous 就跳過
            if (skipAuthorization)
            {
                return;
            }

            #endregion

            //驗證是否是授權的連線。
            if (filterContext.HttpContext.User.Identity.IsAuthenticated == false)
            {
                filterContext.Result = new HttpUnauthorizedResult();
            }

            //驗證是否是授權的連線
            if (filterContext.Result is HttpUnauthorizedResult && filterContext.IsChildAction)
            {
                ContentResult cr = new ContentResult();
                cr.Content = "<p class=\"alert alert-danger\">您尚未登入無法觀看!! 請先登入後再嘗試。</p>";
                filterContext.Result = cr;
            }

            foreach (AuthorizePlusAttribute attribute in filterContext.ActionDescriptor.GetCustomAttributes(typeof(AuthorizePlusAttribute), inherit: true))
            {
                var allowRole = attribute.Roles;
                var roles = new List<string>() { allowRole };
                if (allowRole.Contains(","))
                {
                    roles = allowRole.Split(',').ToList();
                }
                if (!roles.Any(role => HttpContext.Current.User.IsInRole(role)))
                {
                    //停在沒權限的controller的Index
                    //var routevalueDictionary = filterContext.RouteData.DataTokens;
                    //routevalueDictionary.Add("action", "Index");

                    RedirectToRouteResult rtrr = new RedirectToRouteResult(new RouteValueDictionary
                    {
                        {"action", "Index"},
                        {"controller", "Home"},
                        {"area", ""},
                    });
                    filterContext.Result = rtrr;
                }
            }
        }
    }
}