﻿namespace SiteNewsApi.Models.Entities
{
    public class UsersNews
    {
        public int IdUser { get; set; }
        public int IdNews { get; set; }
        public string LikedLevel { get; set; }
        public virtual User User { get; set; }
        public virtual News News { get; set; }
    }
}
