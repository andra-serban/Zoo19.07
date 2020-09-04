using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Zoo19._07.BlobHelper
{
    public class BlobUpload
    {
        public async Task<string> uploadToBlobAsync(string localFilePath)
        {
            string connectionString = "DefaultEndpointsProtocol=https;AccountName=zooblob;AccountKey=+fTi/SMxwmc0RDAPGKxc7cQSyWymO5UOU3DBGPcFcjwN8ijOwZBJQVdrfifmx14ivyb6o2Jz9skY/6aMav8EIA==;EndpointSuffix=core.windows.net";
            // Create a BlobServiceClient object which will be used to create a container client
            BlobServiceClient blobServiceClient = new BlobServiceClient(connectionString);

            //Create a unique name for the container
            string containerName = "zoo-container";

            // Create the container and return a container client object

            BlobContainerClient containerClient = blobServiceClient.GetBlobContainerClient(containerName);
            string fileName =  null;
            fileName = Path.GetFileName(localFilePath);

            // Write text to the file
            // await File.WriteAllTextAsync(localFilePath, "Hello, World!");

            // Get a reference to a blob

            BlobClient blobClient = containerClient.GetBlobClient(fileName);


            // Open the file and upload its data
            using FileStream uploadFileStream = File.OpenRead(localFilePath);
            await blobClient.UploadAsync(uploadFileStream, true);
            uploadFileStream.Close();


            return blobClient.Uri.ToString();
        }
    }
}
