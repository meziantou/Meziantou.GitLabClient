namespace Meziantou.GitLabClient.Generator
{
    internal class Documentation
    {
        public string Summary { get; set; }
        public string Remark { get; set; }
        public string Returns { get; set; }
        public string HelpLink { get; set; }

        public static implicit operator Documentation(string summary) => new Documentation { Summary = summary };
    }
}
