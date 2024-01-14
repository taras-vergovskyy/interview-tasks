namespace Articles
{

    public partial class ArticlesSolution
    {
        public class AuthorResponse
        {
            public int page { get; set; }
            public int per_page { get; set; }
            public int total { get; set; }
            public int total_pages { get; set; }
            public List<Author> data { get; set; }
        }

    }

}
