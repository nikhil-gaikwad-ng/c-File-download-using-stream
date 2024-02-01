using Microsoft.AspNetCore.Mvc;

namespace Test.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class UniquStringGeneratorController : Controller
    {
        readonly List<char> CHARSET = new List<char>() { 'a','b','c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z', '1', '2', '3', '4', '5', '6', '7', '8', '9', '0', '@', '#' };
        [HttpGet]
        public IActionResult uniqueString()
        {
       
            System.Text.StringBuilder unique = new ("aaaa");
            int range = unique.Length-1;
            int count = 0;
            for (int i = range; i >= 0; i--)
            {
                Console.WriteLine(count);
                for (int j = 0; j < CHARSET.Count; j++)
                {
                    unique[i] = CHARSET[j];
                    Console.WriteLine(unique);
                    count++;
                }

                if (unique[0] == '#' && unique[1] == '#') break;

                for (int k = range; k >= 0; k--)
                    {
                        if (unique[k] == '#')
                        {
                            unique[k] = CHARSET[0];
                        }
                        else
                        {
                            i = k;
                            break;
                        }
                    }
                    char preChar = unique[i];
                    int index = CHARSET.IndexOf(preChar) + 1;
                    unique[i] = CHARSET[index];
                    i = range + 1;
            }

            return Ok(count);
        }
    }
}
