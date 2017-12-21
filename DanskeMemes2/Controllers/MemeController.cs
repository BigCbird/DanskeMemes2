using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DanskeMemes2.Models.DAL.Interfaces;
using DanskeMemes2.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DanskeMemes2.Controllers
{
    [Produces("application/json")]
    [Route("api/Meme")]
    public class MemeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IStorageService _storageService;
        public MemeController(IUnitOfWork unitOfWork, IStorageService storageService)
        {
            _unitOfWork = unitOfWork;
            _storageService = storageService;
        }

        [HttpPost]
        public async Task<int> Post(IFormCollection formCollection)
        {
            var meme = new Meme();
            using (var stream = formCollection.Files["file"].OpenReadStream())
            {
                var blob = await _storageService.UploadStream(stream, "memes", Guid.NewGuid().ToString());
                meme.ImageUrl = blob.Uri.ToString();
                meme.Description = formCollection["description"];
                meme.Title = formCollection["title"];
            }

             _unitOfWork.Memes.Add(meme);
            return await _unitOfWork.CompleteAsync();
        }
    }
}