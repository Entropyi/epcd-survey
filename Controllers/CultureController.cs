using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;

namespace feedback.Controllers;

public class CultureController : Controller
{
    // GET
    public IActionResult ToggleCulture(string returnUrl)    { 
        // Determine the current culturevar
      var  currentCulture = HttpContext.Features.Get<IRequestCultureFeature>().RequestCulture.Culture.Name; 
        // Toggle between the two culturesvar
     var   newCulture = currentCulture == "en" ? "ar" : "en";     
        // Set the new culture in the cookie
        Response.Cookies.Append(
            CookieRequestCultureProvider.DefaultCookieName,
            CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(newCulture)), 
            new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) } );
        return LocalRedirect(returnUrl); 
    }
}