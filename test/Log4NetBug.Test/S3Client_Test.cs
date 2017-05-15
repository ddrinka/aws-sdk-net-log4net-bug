using Amazon.S3;
using System;
using Xunit;

namespace Log4NetBug
{
	public class S3Client_Test
	{
		const string ACCESS_KEY_ID = "AKIAI6F4JAQVLPRAOPNA";                                //Note, these are real credentials with access to a temporary S3 bucket
		const string SECRET_ACCESS_KEY = "QYdblrEH1WflUXzbC2NOskYd6FEPUEm5b3BbwKQD";
		const string BUCKET_NAME = "public.log4netbug";
		const string OBJECT_NAME = "success.txt";

		[Fact]
		public void CreateS3Client()
		{
			S3Client.CreateS3Client(ACCESS_KEY_ID, SECRET_ACCESS_KEY);
		}

		[Fact]
		public void ListBucketObjects()
		{
			var client = S3Client.CreateS3Client(ACCESS_KEY_ID, SECRET_ACCESS_KEY);
			S3Client.ListBucketObjects(client, BUCKET_NAME).Wait();
		}

		[Fact]
		public void GetObject()
		{
			var client = S3Client.CreateS3Client(ACCESS_KEY_ID, SECRET_ACCESS_KEY);
			var contents = S3Client.GetObject(client, BUCKET_NAME, OBJECT_NAME).Result;
			Assert.Equal("Success!", contents);
		}
	}
}
