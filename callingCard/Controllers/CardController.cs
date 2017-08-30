using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace callingCard
{

    public class CardController : Controller
    {
        [HttpGet]
        [Route("")]
        public string Index()
        {
            return "Welcome to my Calling Card! Please add the following to the url '/yourFirstName/yourNickName/yourAge/yourLastName'";
        }

        [HttpGet]
        [Route("{firstName}/{nickName}/{age}/{faveColor}")]
        public JsonResult Card(string firstName, string nickName, string age, string faveColor)
        {
            var customCard = new {
                FirstName = firstName,
                NickName = nickName,
                Age = age,
                FavoriteColor = faveColor
            };

            return Json(customCard);
        }
    }

}