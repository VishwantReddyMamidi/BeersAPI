using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using BeersAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Json;
using System.Net;
using BeersAPI.Filters;

namespace BeersAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BeerRatingsController : ControllerBase
    {
        [HttpPost("{id}")]
        [ServiceFilter(typeof(VerifyUsernameFilter))]
        public async Task<IActionResult> AddRating(int id,Ratings rating)
        {
            if (rating.Rating > 0 && rating.Rating < 6)
            {
                HttpClient client = new HttpClient();
                HttpResponseMessage responseMessage = await client.GetAsync($"https://api.punkapi.com/v2/beers/{id}");

                if (responseMessage.StatusCode == HttpStatusCode.NotFound)
                {
                    return NotFound("Nomatching beer ID found");
                }
                else
                {
                    var stringData = await responseMessage.Content.ReadAsStringAsync();
                    var myObject = JsonConvert.DeserializeObject<List<Response>>(stringData);
                    dynamic convertedJson1;
                    using (StreamReader r = new StreamReader("./RatingDB/database.json"))
                    {
                        string json = r.ReadToEnd();
                        var settings = new JsonSerializerSettings
                        {
                            NullValueHandling = NullValueHandling.Ignore,
                        };
                        List<Ratings> items = JsonConvert.DeserializeObject<List<Ratings>>(json, settings);

                        items.Add(rating);
                        
                        var convertedJson = JsonConvert.SerializeObject(items, Formatting.Indented);
                        convertedJson1 = convertedJson;

                    }
                        TextWriter writer;
                        using (writer = new StreamWriter("./RatingDB/database.json", append: false))
                        {
                            writer.WriteLine(convertedJson1);
                        }

                    return Ok("Successfully rating added");
                }
            }
            else
            {
                return BadRequest("make sure rating is between 1 and 5");
            }

        }

        [HttpGet("{BeerName}")]
        public async Task<IActionResult> GetBeerandRating(string BeerName)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage responseMessage = await client.GetAsync($"https://api.punkapi.com/v2/beers?beer_name={BeerName}");
            if (responseMessage.StatusCode == HttpStatusCode.NotFound)
            {
                return NotFound("Nomatching beer name found");
            }
            else
            {
                var stringData = await responseMessage.Content.ReadAsStringAsync();
                var myObject = JsonConvert.DeserializeObject<List<Response>>(stringData);

                using (StreamReader r = new StreamReader("./RatingDB/database.json"))
                {
                    string json = r.ReadToEnd();
                    List<Ratings> items = JsonConvert.DeserializeObject<List<Ratings>>(json);
                    List<ResponseOut> responseOut = new List<ResponseOut>();
                    foreach (var beer in myObject)
                    {
                        responseOut.Add(new ResponseOut() { id = beer.id, name = beer.name, description = beer.description, userRatings = items });
                    }

                    return Ok(responseOut);
                }
            }
        }
    }
}