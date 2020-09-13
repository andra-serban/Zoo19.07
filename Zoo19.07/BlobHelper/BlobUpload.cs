using Azure.Storage.Blobs;
using System.IO;
using System.Threading.Tasks;

namespace Zoo19._07.BlobHelper
{
    public class BlobUpload
    {
        readonly string containerName = "zoo-container";
        public async Task<string> uploadToBlobAsync(string localFilePath)
        {
            string connectionString = "DefaultEndpointsProtocol=https;AccountName=zooblob;AccountKey=+fTi/SMxwmc0RDAPGKxc7cQSyWymO5UOU3DBGPcFcjwN8ijOwZBJQVdrfifmx14ivyb6o2Jz9skY/6aMav8EIA==;EndpointSuffix=core.windows.net";
            // Create a BlobServiceClient object which will be used to create a container client
            BlobServiceClient blobServiceClient = new BlobServiceClient(connectionString);

            // Create the container and return a container client object
            BlobContainerClient containerClient = blobServiceClient.GetBlobContainerClient(containerName);
            string fileName = Path.GetFileName(localFilePath);

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
