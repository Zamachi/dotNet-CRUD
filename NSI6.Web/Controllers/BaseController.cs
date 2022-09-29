using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;

namespace NSI6.Web.Controllers
{
    public class BaseController : Controller
    {
        #region Culture management

        /// <summary>
        ///     Culture management - post method
        /// </summary>
        /// <returns></returns>
        public IActionResult CultureManagement(string culture, string returnUrl)
        {
            Response.Cookies.Append(CookieRequestCultureProvider.DefaultCookieName, CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions { Expires = DateTimeOffset.Now.AddDays(30) });

            return LocalRedirect(returnUrl);
        }

        /// <summary>
        /// Set culture management
        /// </summary>
        /// <param name="culture"></param>
        public void SetCultureManagement(string culture)
        {
            Response.Cookies.Append(CookieRequestCultureProvider.DefaultCookieName, CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions { Expires = DateTimeOffset.Now.AddDays(30) });
        }

        #endregion Culture management
    }
}