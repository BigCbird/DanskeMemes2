using DanskeMemes2.Models.DAL.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DanskeMemes2.Models.DAL
{
    public class CloudStorageService : IStorageService
    {
        private readonly CloudBlobClient _cloudBlobClient;

        public CloudStorageService(IConfiguration options)
        {
            var storageAccount = CloudStorageAccount.Parse(options.GetConnectionString("DanskeMemes"));
            _cloudBlobClient = storageAccount.CreateCloudBlobClient();
        }
        public async Task<ICloudBlob> UploadStream(Stream inputStream, string storageContainer, string blobName)
        {
            var blobContainer = _cloudBlobClient.GetContainerReference(storageContainer.ToLowerInvariant());
            await blobContainer.CreateIfNotExistsAsync();

            await blobContainer.SetPermissionsAsync(new BlobContainerPermissions { PublicAccess = BlobContainerPublicAccessType.Container });

            var blob = blobContainer.GetBlockBlobReference(blobName);
            blob.Properties.ContentType = "image/jpg";

            await blob.UploadFromStreamAsync(inputStream);
            return blob;
        }
    }
}
