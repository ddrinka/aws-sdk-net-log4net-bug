A repro of the XUnit Log4Net bug with aws-sdk-net

Environment
-------------------
Microsoft Visual Studio Professional 2017  
Version 15.0.26228.9 D15RTWSVC

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

Targeting Microsoft.NETCore.App 1.0.4

Test Results
------------------
```
Test Name:	Log4NetBug.S3Client_Test.CreateS3Client
Test FullName:	Log4NetBug.S3Client_Test.CreateS3Client
Test Source:	C:\src\aws-sdk-net-log4net-bug\test\Log4NetBug.Test\S3Client_Test.cs : line 16
Test Outcome:	Passed
Test Duration:	0:00:00.003



Test Name:	Log4NetBug.S3Client_Test.ListBucketObjects
Test FullName:	Log4NetBug.S3Client_Test.ListBucketObjects (a944ee06e61f752fa2b88936a5b17a55d8d15d76)
Test Source:	C:\src\aws-sdk-net-log4net-bug\test\Log4NetBug.Test\S3Client_Test.cs : line 22
Test Outcome:	Passed
Test Duration:	0:00:00.086



Test Name:	Log4NetBug.S3Client_Test.GetObject
Test FullName:	Log4NetBug.S3Client_Test.GetObject (2f5a3138f6c147a1f34f194995bca863ab50dce6)
Test Source:	C:\src\aws-sdk-net-log4net-bug\test\Log4NetBug.Test\S3Client_Test.cs : line 29
Test Outcome:	Failed
Test Duration:	0:00:00.653

Result StackTrace:	
at System.Threading.Tasks.Task.ThrowIfExceptional(Boolean includeTaskCanceledExceptions)
   at System.Threading.Tasks.Task`1.GetResultCore(Boolean waitCompletionNotification)
   at Log4NetBug.S3Client_Test.GetObject() in C:\src\aws-sdk-net-log4net-bug\test\Log4NetBug.Test\S3Client_Test.cs:line 31
----- Inner Stack Trace -----
   at System.RuntimeMethodHandle.InvokeMethod(Object target, Object[] arguments, Signature sig, Boolean constructor)
   at System.Reflection.RuntimeMethodInfo.UnsafeInvokeInternal(Object obj, Object[] parameters, Object[] arguments)
   at System.Reflection.RuntimeMethodInfo.Invoke(Object obj, BindingFlags invokeAttr, Binder binder, Object[] parameters, CultureInfo culture)
   at Amazon.Runtime.Internal.Util.InternalLog4netLogger..ctor(Type declaringType) in E:\JenkinsWorkspaces\v3-trebuchet-release\AWSDotNetPublic\sdk\src\Core\Amazon.Runtime\Internal\Util\Logger.Log4net.cs:line 147
   at Amazon.Runtime.Internal.Util.Logger..ctor(Type type) in E:\JenkinsWorkspaces\v3-trebuchet-release\AWSDotNetPublic\sdk\src\Core\Amazon.Runtime\Internal\Util\Logger.cs:line 46
   at Amazon.Runtime.Internal.Util.Logger.GetLogger(Type type) in E:\JenkinsWorkspaces\v3-trebuchet-release\AWSDotNetPublic\sdk\src\Core\Amazon.Runtime\Internal\Util\Logger.cs:line 111
   at Amazon.S3.Internal.AmazonS3ResponseHandler.ProcessResponseHandlers(IExecutionContext executionContext) in E:\JenkinsWorkspaces\v3-trebuchet-release\AWSDotNetPublic\sdk\src\Services\S3\Custom\Internal\AmazonS3ResponseHandler.cs:line 89
   at Amazon.S3.Internal.AmazonS3ResponseHandler.<InvokeAsync>d__1`1.MoveNext() in E:\JenkinsWorkspaces\v3-trebuchet-release\AWSDotNetPublic\sdk\src\Services\S3\Custom\Internal\AmazonS3ResponseHandler.cs:line 60
--- End of stack trace from previous location where exception was thrown ---
   at System.Runtime.CompilerServices.TaskAwaiter.ThrowForNonSuccess(Task task)
   at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
   at Amazon.Runtime.Internal.ErrorHandler.<InvokeAsync>d__5`1.MoveNext() in E:\JenkinsWorkspaces\v3-trebuchet-release\AWSDotNetPublic\sdk\src\Core\Amazon.Runtime\Pipeline\ErrorHandler\ErrorHandler.cs:line 107
--- End of stack trace from previous location where exception was thrown ---
   at System.Runtime.CompilerServices.TaskAwaiter.ThrowForNonSuccess(Task task)
   at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
   at Amazon.Runtime.Internal.CallbackHandler.<InvokeAsync>d__9`1.MoveNext()
--- End of stack trace from previous location where exception was thrown ---
   at System.Runtime.CompilerServices.TaskAwaiter.ThrowForNonSuccess(Task task)
   at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
   at Amazon.Runtime.Internal.CredentialsRetriever.<InvokeAsync>d__7`1.MoveNext() in E:\JenkinsWorkspaces\v3-trebuchet-release\AWSDotNetPublic\sdk\src\Core\Amazon.Runtime\Pipeline\Handlers\CredentialsRetriever.cs:line 98
--- End of stack trace from previous location where exception was thrown ---
   at System.Runtime.CompilerServices.TaskAwaiter.ThrowForNonSuccess(Task task)
   at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
   at Amazon.Runtime.Internal.RetryHandler.<InvokeAsync>d__10`1.MoveNext()
--- End of stack trace from previous location where exception was thrown ---
   at Amazon.Runtime.Internal.RetryHandler.<InvokeAsync>d__10`1.MoveNext() in E:\JenkinsWorkspaces\v3-trebuchet-release\AWSDotNetPublic\sdk\src\Core\Amazon.Runtime\Pipeline\RetryHandler\RetryHandler.cs:line 141
--- End of stack trace from previous location where exception was thrown ---
   at System.Runtime.CompilerServices.TaskAwaiter.ThrowForNonSuccess(Task task)
   at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
   at Amazon.Runtime.Internal.CallbackHandler.<InvokeAsync>d__9`1.MoveNext()
--- End of stack trace from previous location where exception was thrown ---
   at System.Runtime.CompilerServices.TaskAwaiter.ThrowForNonSuccess(Task task)
   at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
   at Amazon.Runtime.Internal.CallbackHandler.<InvokeAsync>d__9`1.MoveNext()
--- End of stack trace from previous location where exception was thrown ---
   at System.Runtime.CompilerServices.TaskAwaiter.ThrowForNonSuccess(Task task)
   at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
   at Amazon.S3.Internal.AmazonS3ExceptionHandler.<InvokeAsync>d__1`1.MoveNext() in E:\JenkinsWorkspaces\v3-trebuchet-release\AWSDotNetPublic\sdk\src\Services\S3\Custom\Internal\AmazonS3ExceptionHandler.cs:line 62
--- End of stack trace from previous location where exception was thrown ---
   at System.Runtime.CompilerServices.TaskAwaiter.ThrowForNonSuccess(Task task)
   at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
   at Amazon.Runtime.Internal.ErrorCallbackHandler.<InvokeAsync>d__5`1.MoveNext() in E:\JenkinsWorkspaces\v3-trebuchet-release\AWSDotNetPublic\sdk\src\Core\Amazon.Runtime\Pipeline\Handlers\ErrorCallbackHandler.cs:line 58
--- End of stack trace from previous location where exception was thrown ---
   at System.Runtime.CompilerServices.TaskAwaiter.ThrowForNonSuccess(Task task)
   at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
   at Amazon.Runtime.Internal.MetricsHandler.<InvokeAsync>d__1`1.MoveNext()
--- End of stack trace from previous location where exception was thrown ---
   at System.Runtime.CompilerServices.TaskAwaiter.ThrowForNonSuccess(Task task)
   at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
   at System.Runtime.CompilerServices.ConfiguredTaskAwaitable`1.ConfiguredTaskAwaiter.GetResult()
   at Log4NetBug.S3Client.<GetObject>d__2.MoveNext() in C:\src\aws-sdk-net-log4net-bug\src\Log4NetBug\S3Client.cs:line 41
----- Inner Stack Trace -----
   at log4net.Core.LoggerManager.GetLogger(Assembly repositoryAssembly, Type type)
Result Message:	
System.AggregateException : One or more errors occurred. (Exception has been thrown by the target of an invocation.)
---- System.Reflection.TargetInvocationException : Exception has been thrown by the target of an invocation.
-------- System.MissingMethodException : Method not found: 'Boolean System.Reflection.Assembly.op_Equality(System.Reflection.Assembly, System.Reflection.Assembly)'.
```