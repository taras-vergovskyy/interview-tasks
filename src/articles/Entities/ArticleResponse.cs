namespace Articles
{

    public partial class ArticlesSolution
    {
        public class ArticleResponse
        {
            public int page { get; set; }
            public int per_page { get; set; }
            public int total { get; set; }
            public int total_pages { get; set; }
            public List<Article> data { get; set; }
        }

    }

}
