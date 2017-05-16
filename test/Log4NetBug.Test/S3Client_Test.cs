using System;
using Xunit;

namespace Log4NetBug
{
	public class S3Client_Test
	{
		const string COGNITO_IDENTITY_POOL_ID = "us-east-1:dd75cc64-ca66-40b6-bfe8-f63d10ff3e5a";
		
		const string BUCKET_NAME = "public.log4netbug";
		const string OBJECT_NAME = "success.txt";

		[Fact]
		public void LogIn()
		{
			var credentials = S3Client.GetCredentials(COGNITO_IDENTITY_POOL_ID);
			var immutableCreds = credentials.GetCredentials();
		}

		[Fact]
		public void CreateS3Client()
		{
			var credentials = S3Client.GetCredentials(COGNITO_IDENTITY_POOL_ID);
			S3Client.CreateS3Client(credentials);
		}

		[Fact]
		public void ListBucketObjects()
		{
			var credentials = S3Client.GetCredentials(COGNITO_IDENTITY_POOL_ID);
			var client = S3Client.CreateS3Client(credentials);
			S3Client.ListBucketObjects(client, BUCKET_NAME).Wait();
		}

		[Fact]
		public void GetObject()
		{
			var credentials = S3Client.GetCredentials(COGNITO_IDENTITY_POOL_ID);
			var client = S3Client.CreateS3Client(credentials);
			var contents = S3Client.GetObject(client, BUCKET_NAME, OBJECT_NAME).Result;
			Assert.Equal("Success!", contents);
		}
	}
}
