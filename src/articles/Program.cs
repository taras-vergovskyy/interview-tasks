// See https://aka.ms/new-console-template for more information
using Articles;



var res = ArticlesSolution.getAuthorHistory("epaga");
res.ForEach(item => Console.WriteLine(item));
