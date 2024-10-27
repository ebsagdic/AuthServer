using Microsoft.AspNetCore.Mvc;
using SharedLibrary.DTO_s;

namespace AuthServer.API.Controllers
{
    public class CustomBaseController : ControllerBase
    {
        //API odaklı işlemler için ControllerBase
        //MVC ve Razor View destekli projeler için Controller
        //ControllerBase,Genelde API geliştirmede kullanılır ve return Ok(data);,
        //return NotFound(); gibi JSON veya XML çıktısı veren RESTful cevaplar sağlar.

        //Web uygulamaları veya MVC projeleri için Controller tercih edilir,
        //çünkü Razor View dosyalarıyla birlikte çalışmaya uygundur ve View, ViewBag gibi MVC özelliklerini sağlar.

        public IActionResult ActionResultInstance<T>(Response<T> response) where T : class
        {
            return new ObjectResult(response)
            {
                StatusCode = response.StatusCode
            };
        }
    }
}
