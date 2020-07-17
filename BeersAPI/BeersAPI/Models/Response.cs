using BeersAPI.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeersAPI.Models
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class Volume
    {
        [JsonProperty("value")]
        public double? value { get; set; }
        [JsonProperty("unit")]
        public string unit { get; set; }

    }

    public class BoilVolume
    {
        [JsonProperty("value")]
        public double? value { get; set; }
        [JsonProperty("unit")]
        public string unit { get; set; }

    }

    public class Temp
    {
        [JsonProperty("value")]
        public double? value { get; set; }
        [JsonProperty("unit")]
        public string unit { get; set; }

    }

    public class MashTemp
    {
        [JsonProperty("temp")]
        public Temp temp { get; set; }
        [JsonProperty("duration")]
        public double? duration { get; set; }

    }

    public class Temp2
    {
        [JsonProperty("value")]
        public double? value { get; set; }
        [JsonProperty("unit")]
        public string unit { get; set; }

    }

    public class Fermentation
    {
        [JsonProperty("temp")]
        public Temp2 temp { get; set; }

    }

    public class Method
    {
        [JsonProperty("mash_temp")]
        public List<MashTemp> mash_temp { get; set; }
        [JsonProperty("fermentation")]
        public Fermentation fermentation { get; set; }
        [JsonProperty("twist")]
        public object twist { get; set; }

    }

    public class Amount
    {
        [JsonProperty("value")]
        public double? value { get; set; }
        [JsonProperty("unit")]
        public string unit { get; set; }

    }

    public class Malt
    {
        [JsonProperty("name")]
        public string name { get; set; }
        [JsonProperty("amount")]
        public Amount amount { get; set; }

    }

    public class Amount2
    {
        [JsonProperty("value")]
        public double? value { get; set; }
        [JsonProperty("unit")]
        public string unit { get; set; }

    }

    public class Hop
    {
        [JsonProperty("name")]
        public string name { get; set; }
        [JsonProperty("amount")]
        public Amount2 amount { get; set; }
        [JsonProperty("add")]
        public string add { get; set; }
        [JsonProperty("attribute")]
        public string attribute { get; set; }

    }

    public class Ingredients
    {
        [JsonProperty("malt")]
        public List<Malt> malt { get; set; }
        [JsonProperty("hops")]
        public List<Hop> hops { get; set; }
        [JsonProperty("yeast")]
        public string yeast { get; set; }

    }

    public class Response
    {
        [JsonProperty("id")]
        public double? id { get; set; }
        [JsonProperty("name")]
        public string name { get; set; }
        [JsonProperty("tagline")]
        public string tagline { get; set; }
        [JsonProperty("first_brewed")]
        public string first_brewed { get; set; }
        [JsonProperty("description")]
        public string description { get; set; }
        [JsonProperty("image_url")]
        public string image_url { get; set; }
        [JsonProperty("abv")]
        public double? abv { get; set; }
        [JsonProperty("ibu")]
        public double? ibu { get; set; }
        [JsonProperty("target_fg")]
        public double? target_fg { get; set; }
        [JsonProperty("target_og")]
        public double? target_og { get; set; }
        [JsonProperty("ebc")]
        public double? ebc { get; set; }
        [JsonProperty("srm")]
        public double? srm { get; set; }
        [JsonProperty("ph")]
        public double? ph { get; set; }
        [JsonProperty("attenuation_level")]
        public double? attenuation_level { get; set; }
        [JsonProperty("volume")]
        public Volume volume { get; set; }
        [JsonProperty("boil_volume")]
        public BoilVolume boil_volume { get; set; }
        [JsonProperty("method")]
        public Method method { get; set; }
        [JsonProperty("ingredients")]
        public Ingredients ingredients { get; set; }
        [JsonProperty("food_pairing")]
        public List<string> food_pairing { get; set; }
        [JsonProperty("brewers_tips")]
        public string brewers_tips { get; set; }
        [JsonProperty("contributed_by")]
        public string contributed_by { get; set; }

    }


}

