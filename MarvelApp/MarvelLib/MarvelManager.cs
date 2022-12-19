using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MarvelLib
{
    public class MarvelManager
    {
        private NetworkManager networkManager;
        public MarvelManager()
        {
            networkManager = new NetworkManager();
        }
        
        public List<Character> GetCharacters(int f,int s)
        {
            long ts = MarvelConfig.TimeStamp;
            string apikey = MarvelConfig.PublicKey;
            string hash = MarvelConfig.MD5Hash();
            string url = $"{MarvelConfig.BaseUrl}characters?limit={s-f}&offset={f}&ts={ts}&apikey={apikey}&hash={hash}";
            string json = networkManager.GetJson(url);

            JObject marvelSearch = JObject.Parse(json);
            IList<JToken> results = marvelSearch["data"]["results"].Children().ToList();

            var characters = new List<Character>();

            foreach (JToken result in results)
            {
                characters.Add(new Character
                {
                    Id = Convert.ToInt32(result["id"]),
                    Name = result["name"].ToString(),
                    ImageUrl = $"{result["thumbnail"]["path"]}.{result["thumbnail"]["extension"]}",
                    Description = result["description"].ToString()
                });
            }

            return characters;

        }
    }
}
