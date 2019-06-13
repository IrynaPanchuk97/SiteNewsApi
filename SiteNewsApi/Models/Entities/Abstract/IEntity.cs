using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiteNewsApi.Models.Entities.Abstract
{
    public interface IEntity
    {
        int Id { get; set; }
        int? CreateId { get; set; }
        int? ModId { get; set; }
    }
}

