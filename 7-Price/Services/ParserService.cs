using HtmlAgilityPack;
using NewsParser.Models;
using System.Net;
using System.Text;

namespace NewsParser.Services
{
    public class ParserService
    {

        private readonly ApplicationContext _context;
        private readonly IConfiguration _iConfig;

        public ParserService(ApplicationContext context, IConfiguration iConfig)
        {
            _iConfig = iConfig;
            _context = context;
        }

        public async Task ParseNews()
        {
            List<string> urls = new List<string>
            {
                "https://news.liga.net/",
                "https://www.unian.ua/",
                "https://www.rbc.ua/ukr/news"
            };
            foreach (string url in urls)
            {
                HtmlWeb web = new HtmlWeb();
                HtmlDocument document = web.Load(url);
                if (url.Contains("news.liga.net"))
                {
                    HtmlNodeCollection newsItems = document.DocumentNode.SelectNodes("//div[@class='news-nth']");
                    foreach (HtmlNode item in newsItems)
                    {
                        string title = "";
                        string newsTime = "";
                        title = item.SelectSingleNode(".//a")?.InnerText.Trim();
                        newsTime = item.SelectSingleNode(".//div[@class='news-nth-time']")?.InnerText.Trim();
                        if (title != null && newsTime != null)
                        {
                            var existingNews = _context.News.Where(e => e.NewsTime == newsTime).FirstOrDefault();
                            if (existingNews == null)
                            {
                                var news = new News
                                {
                                    Id = new Guid(),
                                    Name = title,
                                    NewsTime = newsTime,
                                    Site = url,
                                    ParseDate = DateTime.UtcNow,
                                };
                                _context.News.Add(news);
                                _context.SaveChanges();

                                string urlString = "https://api.telegram.org/bot{0}/sendMessage?chat_id={1}&text={2}";
                                string apiToken = "5831435193:AAEe7J-_WZqYWl37x6cjOKeuIBKFWCOw4qs";
                                string chatId = "@aostapnews";
                                urlString = String.Format(urlString, apiToken, chatId, news.Name);
                                WebRequest request = WebRequest.Create(urlString);
                                Stream rs = request.GetResponse().GetResponseStream();
                                StreamReader reader = new StreamReader(rs);
                                string line = "";
                                StringBuilder sb = new StringBuilder();
                                while (line != null)
                                {
                                    line = reader.ReadLine();
                                    if (line != null)
                                        sb.Append(line);
                                }
                                string response = sb.ToString();
                            }
                        }
                    }
                }
                else if (url.Contains("unian.ua"))
                {
                    HtmlNodeCollection newsItems = document.DocumentNode.SelectNodes("//li[@class='newsfeed__item ']");
                    foreach (HtmlNode item in newsItems)
                    {
                        string title = "";
                        string newsTime = "";
                        title = item.SelectSingleNode(".//a")?.InnerText.Trim();
                        newsTime = item.SelectSingleNode(".//span[@class='newsfeed__time']")?.InnerText.Trim();
                        if (title != null && newsTime != null)
                        {
                            var existingNews = _context.News.Where(e => e.NewsTime == newsTime).FirstOrDefault();
                            if (existingNews == null)
                            {
                                var news = new News
                                {
                                    Id = new Guid(),
                                    Name = title,
                                    NewsTime = newsTime,
                                    Site = url,
                                    ParseDate = DateTime.UtcNow,
                                };
                                _context.News.Add(news);
                                _context.SaveChanges();

                                string urlString = "https://api.telegram.org/bot{0}/sendMessage?chat_id={1}&text={2}";
                                string apiToken = "5831435193:AAEe7J-_WZqYWl37x6cjOKeuIBKFWCOw4qs";
                                string chatId = "@aostapnews";
                                urlString = String.Format(urlString, apiToken, chatId, news.Name);
                                WebRequest request = WebRequest.Create(urlString);
                                Stream rs = request.GetResponse().GetResponseStream();
                                StreamReader reader = new StreamReader(rs);
                                string line = "";
                                StringBuilder sb = new StringBuilder();
                                while (line != null)
                                {
                                    line = reader.ReadLine();
                                    if (line != null)
                                        sb.Append(line);
                                }
                                string response = sb.ToString();

                            }
                        }
                    }
                }
                else if (url.Contains("rbc.ua/ukr/news"))
                {
                    HtmlNodeCollection newsItems = document.DocumentNode.SelectNodes("//div[@class='newsline']//div");
                    foreach (HtmlNode item in newsItems)
                    {
                        string title = "";
                        string newsTime = "";
                        title = item.SelectSingleNode(".//a")?.InnerText.Trim();
                        newsTime = item.SelectSingleNode(".//span[@class='time']")?.InnerText.Trim();
                        if (title != null && newsTime != null)
                        {
                            var existingNews = _context.News.Where(e => e.NewsTime == newsTime).FirstOrDefault();
                            if (existingNews == null)
                            {
                                var news = new News
                                {
                                    Id = new Guid(),
                                    Name = title,
                                    NewsTime = newsTime,
                                    Site = url,
                                    ParseDate = DateTime.UtcNow,
                                };
                                _context.News.Add(news);
                                _context.SaveChanges();

                                string urlString = "https://api.telegram.org/bot{0}/sendMessage?chat_id={1}&text={2}";
                                string apiToken = "5831435193:AAEe7J-_WZqYWl37x6cjOKeuIBKFWCOw4qs";
                                string chatId = "@aostapnews";
                                urlString = String.Format(urlString, apiToken, chatId, news.Name);
                                WebRequest request = WebRequest.Create(urlString);
                                Stream rs = request.GetResponse().GetResponseStream();
                                StreamReader reader = new StreamReader(rs);
                                string line = "";
                                StringBuilder sb = new StringBuilder();
                                while (line != null)
                                {
                                    line = reader.ReadLine();
                                    if (line != null)
                                        sb.Append(line);
                                }
                                string response = sb.ToString();
                            }
                        }
                    }
                }
            }
        }
    }
}
