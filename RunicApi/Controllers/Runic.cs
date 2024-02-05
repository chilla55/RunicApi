using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RunicApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Runic : ControllerBase
    {
        // GET api/<Runic>/5
        [HttpGet()]
        public Message.LanguageResponse Get()
        {
            string[] languages = RunicApi.Data.Instance.Translations.Keys.ToArray<string>();
            return new(languages);
        }
        // GET api/<Runic>/5
        [HttpGet("{Language}")]
        public Message.TranslationResponse Get(string Language)
        {
            if (RunicApi.Data.Instance.Translations.ContainsKey(Language.ToString()))
            {
                return new(Utils.GetNewest(RunicApi.Data.Instance.Translations[Language.ToString()]));
            }
            return new("Language Not Found");
        }

        // PUT api/<Runic>/5
        [HttpPost("{key}")]
        [HttpPost()]
        public Message.PostResponse Post([FromBody] RunicData value, string key = "")
        {
            if (value is null)  return new("Body Empty");
            if (key != "" && RunicApi.Data.Instance.Translations.ContainsKey(value.Language))
            {
                if (RunicApi.Data.Instance.KeyLanguage.ContainsKey(key))
                {
                    if (RunicApi.Data.Instance.KeyLanguage[key].Contains(value.Language))
                    {
                        if (RunicApi.Data.Instance.Translations[value.Language].ContainsKey(value.Version))
                            return new("Version Already Exists");
                        RunicApi.Data.Instance.Translations[value.Language].Add(value.Version, value);
                    }
                    else
                        return new("Not Authorized");
                }
                else
                    return new("Not Authorized");
                return new Message.PostResponse();
            }
            else
            {
                if (key == "")
                {
                    if (RunicApi.Data.Instance.Translations.ContainsKey(value.Language))
                    {
                        return new("Not Authorized");
                    }
                    key = Utils.generateKey();
                    RunicApi.Data.Instance.KeyLanguage.Add(key, new List<string> { value.Language });
                }
                else
                {
                    if (RunicApi.Data.Instance.KeyLanguage.ContainsKey(key))
                    {
                        if (!RunicApi.Data.Instance.KeyLanguage[key].Contains(value.Language))
                        {
                            RunicApi.Data.Instance.KeyLanguage[key].Add(value.Language);
                        }
                    }
                    else
                    {
                        return new("Not Authorized");
                    }
                }
                Dictionary<string, RunicData> ret = new();
                ret.Add(value.Version, value);
                RunicApi.Data.Instance.Translations.Add(value.Language, ret);
            }
            return new Message.PostResponse(key, "Success");
        }
    }
}
