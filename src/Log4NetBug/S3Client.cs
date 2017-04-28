using Amazon.S3;
using System;

namespace Log4NetBug
{
    public static class S3Client
    {
		public static void CreateS3Client(string accessKeyId, string secretAccessKey)
		{
			var s3Client = new AmazonS3Client(accessKeyId, secretAccessKey);
		}
	}
}
