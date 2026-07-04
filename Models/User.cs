namespace bbl_dev_fest_2026_sirasith_klinfuengfu.Models
{
    public class User
    {
        public long id { get; set; }

        public string name { get; set; } = string.Empty;

        public string username { get; set; } = string.Empty;

        public string email { get; set; } = string.Empty;

        public string? phone { get; set; }

        public string? website { get; set; }
    }
}
