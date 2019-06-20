using SiteNewsApi.Models.Entities.Abstract;
using System;
using System.Collections.Generic;
namespace SiteNewsApi.Models.Entities
{
    public class News : IEntity
    {
        public News()
        {
            UsersNews = new HashSet<UsersNews>();
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Text { get; set; }
        public string Url { get; set; }
        public  DateTime? CreateDate { get; set; }
        public  DateTime? ModDate { get; set; }

        public virtual ICollection<UsersNews> UsersNews { get; set; }

    }
}
