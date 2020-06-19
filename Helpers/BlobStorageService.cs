using Azure.Storage.Blobs;
using Microsoft.Extensions.Configuration;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using ServiceLayer.AppConfig;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace ServiceLayer
{
    public class BlobStorageService
    {
        string accessKey = string.Empty;
        public IConfiguration Configuration { get; }

        public BlobStorageService(IConfiguration configuration)
        {
            Configuration = configuration;
            accessKey = Configuration.GetConnectionString("AccessKey");
        }

        public string UploadFileToBlob(string strFileName, Stream fileData, string fileMimeType, string blobName)
        {
            try
            {

                var _task = Task.Run(() => this.UploadFileToBlobAsync(strFileName, fileData, fileMimeType, blobName));
                _task.Wait();
                string fileUrl = _task.Result;
                return fileUrl;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public async void DeleteBlobData(string fileUrl)
        {
            Uri uriObj = new Uri(fileUrl);
            string BlobName = Path.GetFileName(uriObj.LocalPath);

            CloudStorageAccount cloudStorageAccount = CloudStorageAccount.Parse(accessKey);
            CloudBlobClient cloudBlobClient = cloudStorageAccount.CreateCloudBlobClient();
            string strContainerName = "productImages";
            CloudBlobContainer cloudBlobContainer = cloudBlobClient.GetContainerReference(strContainerName);

            string pathPrefix = DateTime.Now.ToUniversalTime().ToString("yyyy-MM-dd") + "/";
            CloudBlobDirectory blobDirectory = cloudBlobContainer.GetDirectoryReference(pathPrefix);
            // get block blob refarence    
            CloudBlockBlob blockBlob = blobDirectory.GetBlockBlobReference(BlobName);

            // delete blob from container        
            await blockBlob.DeleteAsync();
        }


        private string GenerateFileName(string fileName)
        {
            string strFileName = string.Empty;
            string[] strName = fileName.Split('.');
            strFileName = DateTime.Now.ToUniversalTime().ToString("yyyy-MM-dd").Replace("-","") + "/" + DateTime.Now.ToUniversalTime().ToString("yyyyMMdd\\THHmmssfff") + "." + strName[strName.Length - 1];
            return strFileName;
        }

        private async Task<string> UploadFileToBlobAsync(string strFileName, Stream fileData, string fileMimeType, string blobName)
        {
            try
            {
                // Create a BlobServiceClient object which will be used to create a container client
                BlobServiceClient blobServiceClient = new BlobServiceClient(accessKey);

                //Create a unique name for the container
                string containerName = blobName;

                // Create the container and return a container client object
                //BlobContainerClient containerClient = blobServiceClient.GetBlobContainerClient(containerName);
                //if (containerClient == null)
                BlobContainerClient containerClient = blobServiceClient.GetBlobContainerClient(containerName);
                if (!containerClient.Exists())
                    containerClient =  blobServiceClient.CreateBlobContainer(containerName);

                //string localPath = "./data/";
                string fileName = strFileName;
               // string localFilePath = Path.Combine(localPath, fileName);


                // Get a reference to a blob
                BlobClient blobClient = containerClient.GetBlobClient(fileName);
                

                Console.WriteLine("Uploading to Blob storage as blob:\n\t {0}\n", blobClient.Uri);

                // Open the file and upload its data
                //using FileStream uploadFileStream = File.OpenRead(localFilePath);
                //Stream stream = new MemoryStream(fileData);
                await blobClient.UploadAsync(fileData);
                //uploadFileStream.Close();

               /*  CloudStorageAccount cloudStorageAccount = CloudStorageAccount.Parse(accessKey);
                 CloudBlobClient cloudBlobClient = cloudStorageAccount.CreateCloudBlobClient();
                 string strContainerName = "imagesforproducts";
                 CloudBlobContainer cloudBlobContainer = cloudBlobClient.GetContainerReference(strContainerName);
                  fileName = GenerateFileName(strFileName);

                 if (await cloudBlobContainer.CreateIfNotExistsAsync())
                 {
                     await cloudBlobContainer.SetPermissionsAsync(new BlobContainerPermissions { PublicAccess = BlobContainerPublicAccessType.Blob });
                 }

                 if (fileName != null && fileData != null)
                 {
                     CloudBlockBlob cloudBlockBlob = cloudBlobContainer.GetBlockBlobReference(fileName);
                     //cloudBlockBlob.Properties.ContentType = fileMimeType;
                    //await cloudBlockBlob.UploadFromByteArrayAsync(fileData, 0, fileData.Length);
                    await cloudBlockBlob.UploadFromStreamAsync(fileData);
                    return cloudBlockBlob.Uri.AbsoluteUri;
                 }*/
                return blobClient.Uri.ToString();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
    }
}