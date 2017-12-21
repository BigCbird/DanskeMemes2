using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DanskeMemes2.Models.DAL.Interfaces
{
    public interface IStorageService
    {
        Task<ICloudBlob> UploadStream(Stream input, string storageContainer, string blobName);
    }
}
