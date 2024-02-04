namespace RunicApi.Message
{
    public class Response
    {
        public string status { get; set; } = "";
        public string? errormsg { get; set; }
        public Response()
        {
            status = "Success";
        }
        public Response(string error)
        {
            status = "error";
            errormsg = error;
        }
        public Response(string status, string? errormsg)
        {
            this.status = status;
            this.errormsg = errormsg;
        }
    }
    public class PostResponse : Response
    {
        public string? key { get; set; }
        public PostResponse() : base() { }
        public PostResponse(string error) : base(error) { }
        public PostResponse(string key, string status = "Success", string? error = null): base(status,error)
        {
            this.key = key;
        }
    }
    public class LanguageResponse : Response
    {
        public string[]? languages { get; set; }
        public LanguageResponse(string error) : base(error) { }
        public LanguageResponse(string[] languages, string status = "Success", string? error = null) : base(status, error)
        {
            this.languages = languages;
        }
    }
    public class TranslationResponse : Response
    {
        public string? language { get; set; }
        public string? version { get; set; }
        public List<Translation>? translations { get; set; }
        public TranslationResponse(string error) : base(error) { }
        public TranslationResponse(string languages, string version, List<Translation> translations) : base()
        {
            this.version = version;
            this.translations = translations;
            this.language = language;
        }
        public TranslationResponse(RunicData data, string status = "Success", string? error = null): base(status, error)
        {
            this.version = data.Version;
            this.translations = data.Data;
            this.language = data.Language;
        }
    }
}
