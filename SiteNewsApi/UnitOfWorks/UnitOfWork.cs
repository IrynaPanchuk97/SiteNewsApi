﻿using Microsoft.EntityFrameworkCore;
using SiteNewsApi.Repositories.InterfaceRepository;
using System.Threading.Tasks;

namespace SiteNewsApi.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext _context;

        public INewsRepository NewsRepository { get; }

        public IUserRepository UserRepository { get; }

        public UnitOfWork(
            DbContext context,
            INewsRepository newsRepository,
            IUserRepository userRepository)
        {
            _context = context;
            NewsRepository = newsRepository;
            UserRepository = userRepository;
        }
        public Task<int> SaveAsync()
        {
            return _context.SaveChangesAsync();
        }
    }
}
