using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HelloMVC.Controllers
{
    public class HelloController : Controller
    {
        // GET: /<controller>/
        [HttpGet]
        public IActionResult Index()
        {
            string html = "<form method='post'>" +
                "<label for='name'>Enter name: </label>" +
                "<input type='text' name='name'/>" +
                "<select name = 'languages' id = 'language-select'>" +
                "<option value = ''> --Please choose a language-- </option>" +
                "<option value = 'french'> French </option>" +
                "<option value = 'wolof'> Wolof </option>" +
                "<option value = 'spanish'> Spanish </option>" +
                "<option value = 'japanese'> Japanese </option>" +
                "<option value = 'german'> German </option>" + 
                "</select>" +
                "<input type='submit' value='Greet me!'/>" +
                "</form>";
            
            return Content(html, "text/html");
            //return Redirect("/Hello/Goodbye");
        }

        public static string CreateMessage(string name, string languages)
        {
            string result = "";
            if(languages == "french")
            {
                result = "Bonjour, ";
            }
            else if (languages == "wolof")
            {
                result = "Na nga def, ";
            }
            else if (languages == "spanish")
            {
                result = "Hola, ";
            }
            else if (languages == "japanese")
            {
                result = "こんにちは (Kon\'nichiwa), ";
            }
            else 
            {
                result = "Hallo, ";
            }
            name += "!";
            result += name;

            return result;
        }


        [Route("/Hello")]
        [HttpPost]
        public IActionResult Display(string name, string languages)
        {
            if (string.IsNullOrEmpty(name))
            {
                name = "Stranger";
            }

            return Content(String.Format("<h1>{0}</h1>", CreateMessage(name, languages)), "text/html");
        }



        //---------------------------------------------------------------------------


        // handle requests to /Hello/NAME (URL segment)
        [Route("/Hello/{name}")]
        public IActionResult Index2(string name)
        {
            return Content(String.Format("<h1>Hello {0}</h1>", name), "text/html");
        }

        // /Hello/Goodbye
        // alter the route to: /Hello/Aloha
        [Route("/Hello/Aloha")]
        public IActionResult Goodbye(string name = "Superstar")
        {
            return Content(String.Format("Goodbye {0}", name));
        }
    }
}
