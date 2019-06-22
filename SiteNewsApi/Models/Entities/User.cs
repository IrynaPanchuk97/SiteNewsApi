using SiteNewsApi.Models.Entities.Abstract;
using System;
using System.Collections.Generic;

namespace SiteNewsApi.Models.Entities
{
    [Serializable]
    public class User : IEntity
    {
        public User() => UsersNews = new HashSet<UsersNews>();
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? ModDate { get; set; }

        public virtual ICollection<UsersNews> UsersNews { get; set; }

    }
}
