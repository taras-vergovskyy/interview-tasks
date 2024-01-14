using Newtonsoft.Json;


namespace Articles
{

    public partial class ArticlesSolution
    {
        const string authorUrl = "https://jsonmock.hackerrank.com/api/article_users?username=";
        const string articlesUrl = "https://jsonmock.hackerrank.com/api/articles?author=";

        public static List<string> getAuthorHistory(string author)
        {
            List<string> history = new List<string>();

            //load author data and grab about
            var abouts = LoadAuthorAsync(author).GetAwaiter().GetResult(); 
            history.AddRange(abouts);

            //load articles
            var articles = LoadArticlesAsync(author).GetAwaiter().GetResult();
            history.AddRange(articles);


            return history;

        }

        private async static Task<List<string>> LoadAuthorAsync(string author)
        {
            var res = new List<string>();
            
            using (HttpClient client = new HttpClient())
            {
                var json = await client.GetStringAsync(authorUrl + author);

                if (string.IsNullOrEmpty(json))
                    throw new Exception("empty service responce");

                var data = JsonConvert.DeserializeObject<AuthorResponse>(json);

                if(data!=null && data.data.Any())
                {
                    foreach (var item in data.data)
                        if(!string.IsNullOrEmpty(item.about))
                            res.Add(item.about);
                }               

            }
            return res;
        }

        private async static Task<List<string>> LoadArticlesAsync(string author)
        {
            var res = new List<string>();

            using (HttpClient client = new HttpClient())
            {
                var json = await client.GetStringAsync(articlesUrl + author);

                if (string.IsNullOrEmpty(json))
                    throw new Exception("empty service responce");

                var data = JsonConvert.DeserializeObject<ArticleResponse>(json);
                if (data == null)
                    throw new Exception("no responce");

                for (int i = 1; i <= data.total_pages; i++)
                {
                    using (HttpClient wc = new HttpClient())
                    {
                        var article_json = await wc.GetStringAsync(articlesUrl + author + "&page=" + i.ToString());

                        var article_data = JsonConvert.DeserializeObject<ArticleResponse>(article_json);

                        if (article_data != null )
                            foreach (var item in article_data.data)
                            {
                                if (!string.IsNullOrEmpty(item.title))
                                {
                                    res.Add(item.title);
                                }
                                else if (!string.IsNullOrEmpty(item.story_title))
                                {
                                    res.Add(item.story_title);

                                }

                            }

                    }

                }

            }
            
            return res;
        }

    }

}
