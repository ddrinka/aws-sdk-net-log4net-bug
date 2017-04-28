A repro of the XUnit Log4Net bug with aws-sdk-net

Environment
-------------------
```dos
C:\src\aws-sdk-net-log4net-bug>dotnet --info
.NET Command Line Tools (1.0.0)

Product Information:
 Version:            1.0.0
 Commit SHA-1 hash:  e53429feb4

Runtime Environment:
 OS Name:     Windows
 OS Version:  10.0.14393
 OS Platform: Windows
 RID:         win10-x64
 Base Path:   C:\Program Files\dotnet\sdk\1.0.0
```
Installed runtimes:
- 1.0.1
- 1.0.4
- 1.1.0
- 1.1.1

Exception
------------------
```
{System.Reflection.TargetInvocationException: Exception has been thrown by the target of an invocation. ---> System.MissingMethodException: Method not found: 'Boolean System.Reflection.Assembly.op_Equality(System.Reflection.Assembly, System.Reflection.Assembly)'.
   at log4net.Core.LoggerManager.GetLogger(Assembly repositoryAssembly, Type type)
   --- End of inner exception stack trace ---
   at System.RuntimeMethodHandle.InvokeMethod(Object target, Object[] arguments, Signature sig, Boolean constructor)
   at System.Reflection.RuntimeMethodInfo.UnsafeInvokeInternal(Object obj, Object[] parameters, Object[] arguments)
   at System.Reflection.RuntimeMethodInfo.Invoke(Object obj, BindingFlags invokeAttr, Binder binder, Object[] parameters, CultureInfo culture)
   at Amazon.Runtime.Internal.Util.InternalLog4netLogger..ctor(Type declaringType) in E:\JenkinsWorkspaces\v3-trebuchet-release\AWSDotNetPublic\sdk\src\Core\Amazon.Runtime\Internal\Util\Logger.Log4net.cs:line 147
   at Amazon.Runtime.Internal.Util.Logger..ctor(Type type) in E:\JenkinsWorkspaces\v3-trebuchet-release\AWSDotNetPublic\sdk\src\Core\Amazon.Runtime\Internal\Util\Logger.cs:line 46
   at Amazon.Runtime.Internal.Util.Logger.GetLogger(Type type) in E:\JenkinsWorkspaces\v3-trebuchet-release\AWSDotNetPublic\sdk\src\Core\Amazon.Runtime\Internal\Util\Logger.cs:line 111
   at Amazon.Runtime.AmazonServiceClient..ctor(AWSCredentials credentials, ClientConfig config) in E:\JenkinsWorkspaces\v3-trebuchet-release\AWSDotNetPublic\sdk\src\Core\Amazon.Runtime\AmazonServiceClient.cs:line 149
   at Amazon.S3.AmazonS3Client..ctor(String awsAccessKeyId, String awsSecretAccessKey) in E:\JenkinsWorkspaces\v3-trebuchet-release\AWSDotNetPublic\sdk\src\Services\S3\Generated\_mobile\AmazonS3Client.cs:line 144
   at Log4NetBug.S3Client.CreateS3Client(String accessKeyId, String secretAccessKey) in C:\src\aws-sdk-net-log4net-bug\src\Log4NetBug\S3Client.cs:line 10
   at Log4NetBug.S3Client_Test.CreateS3Client() in C:\src\aws-sdk-net-log4net-bug\test\Log4NetBug.Test\S3Client_Test.cs:line 12}
```
