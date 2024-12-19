using Edi.Captcha;
using Microsoft.AspNetCore.Mvc;

namespace feedback.Controllers;

public class CaptchaController :Controller
{
    private readonly ISessionBasedCaptcha _captcha;

    public CaptchaController(ISessionBasedCaptcha captcha)
    {
        _captcha = captcha;
    }
    
    [Route("get-captcha-image")]
    public IActionResult GetCaptchaImage()
    {
        var s = _captcha.GenerateCaptchaImageFileStream(
            HttpContext.Session,
            100,
            36
        );
        
        return s;
    }
}