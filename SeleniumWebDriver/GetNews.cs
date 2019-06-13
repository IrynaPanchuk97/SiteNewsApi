using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SiteNewsApi.Models.Entities;
using System;
using System.Collections.Generic;

namespace SeleniumWebDriver
{
    public class GetNews
    {
        private static readonly string Url = "https://www.pravda.com.ua/";
        private static readonly string ChromeDriverPath = @"C:\Users\rusa1\Downloads\chromedriver_win32";
        public List<News> Crawl()
        {
            IWebDriver driver = new ChromeDriver(ChromeDriverPath)
            {
                Url = Url
            };
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            var elements = driver.FindElements(By.CssSelector(".jspContainer .news div a"));
            List<string> urlString = new List<string>();

            foreach (var el in elements)
            {
                string _url = el.GetAttribute("href");
                if (_url.Contains("https://www.pravda.com.ua/news"))
                {
                    urlString.Add(_url);
                }
            }
            List<News> listNews = new List<News>();

             foreach (var el in urlString)
            {
                driver.Navigate().GoToUrl(el);
                var title = driver.FindElements(By.CssSelector(".post_news__title"));
                var date = driver.FindElements(By.CssSelector(".post_news__date"));
                var text = driver.FindElements(By.CssSelector(".post_news__text"));

                listNews.Add(
                    new News
                    {
                        Title = title[0].Text ?? "",
                        Text = text[0].Text ?? "",
                        Url = el,
                        Author = "pravda.com.ua",
                    });

            }
            driver.Close();
            return listNews;
        }
    }
}
