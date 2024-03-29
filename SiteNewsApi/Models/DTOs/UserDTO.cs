﻿using System.Collections.Generic;

namespace SiteNewsApi.Models.DTOs
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
        public IList<NewsDTO> NewsList { get; set; }

    }
}
