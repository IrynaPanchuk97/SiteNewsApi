using SiteNewsApi.Models;

namespace RabbitMqConsumer
{
    class Program
    {
        static void Main()
        {
            using (var context = new NewsContext())
            {
                context.News.RemoveRange();
                context.SaveChanges();
            }
            var listener = new Listener();
            listener.Register();
        }
    }
}
