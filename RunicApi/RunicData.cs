using System.Numerics;

namespace RunicApi
{
    public class Data
    {
        public static Data Instance { get; } = new Data();
        public Dictionary<string, List<string>> KeyLanguage { get; set; } = new Dictionary<string, List<string>>();
        public Dictionary<string, RunicData> Translations { get; set; } = new Dictionary<string, RunicData>();
    }
    public class RunicData
    {
        public string Language { get; set; } = "";
        public string Version { get; set; } = "";
        public List<Translation> Data { get; set; } = new();
    }

    public class Translation
    {
        public string glyph { get; set; } = "00000000000000000000000000";
        public string[] Translations { get; set; } = { "" };
    }
}
