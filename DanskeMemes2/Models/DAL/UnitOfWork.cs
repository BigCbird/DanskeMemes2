using DanskeMemes2.Models.DAL.Interfaces;
using DanskeMemes2.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DanskeMemes2.Models.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public IRepository<Meme> Memes { get; }
        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Memes = new Repository<Meme>(_context);
        }
        public void Dispose()
        {
            _context.Dispose();
        }
        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
