using Amazon.S3;
using System;
using Xunit;

namespace Log4NetBug
{
    public class S3Client_Test
    {
        [Fact]
        public void CreateS3Client()
        {
			S3Client.CreateS3Client("accessKeyId", "secretAccessKey");
        }
    }
}
