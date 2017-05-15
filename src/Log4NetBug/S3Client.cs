using Amazon;
using Amazon.S3;
using Amazon.S3.Model;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Log4NetBug
{
    public static class S3Client
    {
		public static AmazonS3Client CreateS3Client(string accessKeyId, string secretAccessKey)
		{
			var config = new AmazonS3Config
			{
				DisableLogging = true,
				RegionEndpoint = RegionEndpoint.USEast1
			};
			return new AmazonS3Client(accessKeyId, secretAccessKey, config);
		}

		public async static Task ListBucketObjects(AmazonS3Client client, string bucketName)
		{
			var request = new ListObjectsRequest
			{
				BucketName = bucketName
			};

			await client.ListObjectsAsync(request)
				.ConfigureAwait(continueOnCapturedContext: false);
		}

		public async static Task<string> GetObject(AmazonS3Client client, string bucketName, string objectName)
		{
			var request = new GetObjectRequest
			{
				BucketName = bucketName,
				Key = objectName
			};

			using (var response = await client.GetObjectAsync(request)
				.ConfigureAwait(continueOnCapturedContext: false))
			{
				using (var streamReader = new StreamReader(response.ResponseStream))
				{
					return streamReader.ReadToEnd();
				}
			}
		}
	}
}
