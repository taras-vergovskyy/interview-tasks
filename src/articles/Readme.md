hackerrank challenge

Implement getAuthorHistory methods. 
It accepts STRING author as parameter 
example "epaga"

1 load information from author from  "https://jsonmock.hackerrank.com/api/article_users?username="
2 if "about" field is not empty - add "about" to result
3 load articles from "https://jsonmock.hackerrank.com/api/articles?author="
4 get page count from the responce
5 for each page
  if title is not empty - add title to result
  else if story_title is not empty - add story_title to result