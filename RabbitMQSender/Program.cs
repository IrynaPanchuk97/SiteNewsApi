using SeleniumWebDriver;
using System;
using System.Threading;

namespace RabbitMQSender
{
    class Program
    {
        static void Main()
        {
            var timer = new Timer(Timer, null, 0, 2000000);
            Console.ReadLine();
        }
        static void Timer(object o)
        {
            var dataReader = new GetNews();
            var news = dataReader.Crawl();
            news.ForEach(Sender.Send);
        }
    }
}
