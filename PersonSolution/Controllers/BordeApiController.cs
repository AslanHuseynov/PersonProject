using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace PersonSolution.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class BordeApiController : ControllerBase
    {

        [HttpGet]
        public async Task<List<Comment>> GetExternalData()
        {
            string html = string.Empty;
            string url = @"https://jsonplaceholder.typicode.com/posts/1/comments";

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.AutomaticDecompression = DecompressionMethods.GZip;

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                html = reader.ReadToEnd();
            }

            var myDeserializedClass = JsonConvert.DeserializeObject<List<Comment>>(html);


            return myDeserializedClass;
        }
    }
}
