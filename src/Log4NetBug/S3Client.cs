using System.IO;
using System.Threading.Tasks;
using Amazon;
using Amazon.CognitoIdentity;
using Amazon.Runtime;
using Amazon.S3;
using Amazon.S3.Model;

namespace Log4NetBug
{
	public static class S3Client
    {
		public static AWSCredentials GetCredentials(string identityPoolId)
		{
			var credentials = new CognitoAWSCredentials(identityPoolId, RegionEndpoint.USEast1);
		
			return credentials;
		}

		public static AmazonS3Client CreateS3Client(AWSCredentials credentials)
		{
			var config = new AmazonS3Config
			{
				DisableLogging = true,
				RegionEndpoint = RegionEndpoint.USEast1
			};
			return new AmazonS3Client(credentials, config);
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
