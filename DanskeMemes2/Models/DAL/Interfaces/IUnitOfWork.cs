using DanskeMemes2.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DanskeMemes2.Models.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Meme> Memes { get; }
        Task<int> CompleteAsync();
    }
}
