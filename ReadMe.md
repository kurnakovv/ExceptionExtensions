<div align="center">
 <img src="icon.png" weight="500px" />
 <h2>ExceptionExtensions</h2>
 
 [![NuGet](https://img.shields.io/nuget/v/Kurnakov.ExceptionExtensions.svg)](https://www.nuget.org/packages/Kurnakov.ExceptionExtensions)
 [![NuGet download](https://img.shields.io/nuget/dt/Kurnakov.ExceptionExtensions.svg)](https://www.nuget.org/packages/Kurnakov.ExceptionExtensions) 
 ![Visitors](https://api.visitorbadge.io/api/visitors?path=https%3A%2F%2Fgithub.com%kurnakovv%ExceptionExtensions&countColor=%23263759&style=flat)
  [![MIT License](https://img.shields.io/github/license/KurnakovMaksim/ExceptionExtensions?color=%230b0&style=flat)](https://github.com/KurnakovMaksim/ExceptionExtensions/blob/main/LICENSE)
 [![Build/Test](https://github.com/KurnakovMaksim/ExceptionExtensions/actions/workflows/build-test.yml/badge.svg)](https://github.com/KurnakovMaksim/ExceptionExtensions/actions/workflows/build-test.yml)
 [![CodeQL](https://github.com/KurnakovMaksim/ExceptionExtensions/workflows/CodeQL/badge.svg)](https://github.com/KurnakovMaksim/ExceptionExtensions/actions?query=workflow%3ACodeQL)
 [![Code Smells](https://sonarcloud.io/api/project_badges/measure?project=kurnakovv_ExceptionExtensions&metric=code_smells)](https://sonarcloud.io/summary/new_code?id=kurnakovv_ExceptionExtensions) [![Coverage](https://sonarcloud.io/api/project_badges/measure?project=kurnakovv_ExceptionExtensions&metric=coverage)](https://sonarcloud.io/summary/new_code?id=kurnakovv_ExceptionExtensions)

</div>

# Description
<b>ExceptionExtensions</b> is open source library with useful methods for working with exceptions

# For what
If you need to handle an exception, you do something like this:
``` cs
try
{
    // Some code with exception
}
catch (Exception ex)
{
    string message = ex.ToString();
    // Work with message.
}
```
Message will look something like this (depends on your exception and environment):
```
System.IndexOutOfRangeException: Index was outside the bounds of the array.
   at JustApplicationWebApi.Services.ThirdService.Run() in D:\C#\Asp Net Core\JustApplicationWebApi\JustApplicationWebApi\Services\ThirdService.cs:line 8
   at JustApplicationWebApi.Services.SecondService.Run() in D:\C#\Asp Net Core\JustApplicationWebApi\JustApplicationWebApi\Services\SecondService.cs:line 7
   at JustApplicationWebApi.Services.FirstService.Run() in D:\C#\Asp Net Core\JustApplicationWebApi\JustApplicationWebApi\Services\FirstService.cs:line 7
   at JustApplicationWebApi.Controllers.ExceptionHandlerController.Get() in D:\C#\Asp Net Core\JustApplicationWebApi\JustApplicationWebApi\Controllers\ExceptionHandlerController.cs:line 19
```
If it's ok for you, use it. But IMHO it's unreadable, because it looks like monolithic text without normal delimeters, espetially when you read a lot of exceptions, or when you combine many exceptions into one file. Well, for such situations I wrote this library.
Just use `ex.GetFullInfo()` instead `ex.ToString()`
``` cs
try
{
    // Some code with exception
}
catch (Exception ex)
{
    string message = ex.GetFullInfo();
    // Work with full message.
}
```
Output:
```
Source: JustApplicationWebApi
#############################
Index was outside the bounds of the array.
==========================================
Type: "System.IndexOutOfRangeException"
***************************************
--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
   at JustApplicationWebApi.Services.ThirdService.Run() in D:\C#\Asp Net Core\JustApplicationWebApi\JustApplicationWebApi\Services\ThirdService.cs:line 8
   at JustApplicationWebApi.Services.SecondService.Run() in D:\C#\Asp Net Core\JustApplicationWebApi\JustApplicationWebApi\Services\SecondService.cs:line 7
   at JustApplicationWebApi.Services.FirstService.Run() in D:\C#\Asp Net Core\JustApplicationWebApi\JustApplicationWebApi\Services\FirstService.cs:line 7
   at JustApplicationWebApi.Controllers.ExceptionHandlerController.Get() in D:\C#\Asp Net Core\JustApplicationWebApi\JustApplicationWebApi\Controllers\ExceptionHandlerController.cs:line 19
--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
```

### Another examples
``` cs
object[] numbers = new object[] { 1, 2, 3, 4, 5, "6" };

// Act
var squares = from n in numbers.AsParallel()
              let x = (int)n
              select Square(x);
int Square(int n) => n * n;
```
ToString()
```
System.AggregateException: One or more errors occurred. (Unable to cast object of type 'System.String' to type 'System.Int32'.)
 ---> System.InvalidCastException: Unable to cast object of type 'System.String' to type 'System.Int32'.
   at JustApplicationWebApi.Services.ThirdService.<>c.<Run>b__0_0(Object n) in D:\C#\Asp Net Core\JustApplicationWebApi\JustApplicationWebApi\Services\ThirdService.cs:line 12
   at System.Linq.Parallel.SelectQueryOperator`2.SelectQueryOperatorResults.GetElement(Int32 index)
   at System.Linq.Parallel.QueryResults`1.get_Item(Int32 index)
   at System.Linq.Parallel.PartitionedDataSource`1.ListContiguousIndexRangeEnumerator.MoveNext(T& currentElement, Int32& currentKey)
   at System.Linq.Parallel.ForAllOperator`1.ForAllEnumerator`1.MoveNext(TInput& currentElement, Int32& currentKey)
   at System.Linq.Parallel.ForAllSpoolingTask`2.SpoolingWork()
   at System.Linq.Parallel.SpoolingTaskBase.Work()
   at System.Linq.Parallel.QueryTask.BaseWork(Object unused)
   at System.Threading.ExecutionContext.RunFromThreadPoolDispatchLoop(Thread threadPoolThread, ExecutionContext executionContext, ContextCallback callback, Object state)
--- End of stack trace from previous location ---
   at System.Threading.ExecutionContext.RunFromThreadPoolDispatchLoop(Thread threadPoolThread, ExecutionContext executionContext, ContextCallback callback, Object state)
   at System.Threading.Tasks.Task.ExecuteWithThreadLocal(Task& currentTaskSlot, Thread threadPoolThread)
   --- End of inner exception stack trace ---
   at System.Linq.Parallel.QueryTaskGroupState.QueryEnd(Boolean userInitiatedDispose)
   at System.Linq.Parallel.SpoolingTask.SpoolForAll[TInputOutput,TIgnoreKey](QueryTaskGroupState groupState, PartitionedStream`2 partitions, TaskScheduler taskScheduler)
   at System.Linq.Parallel.DefaultMergeHelper`2.System.Linq.Parallel.IMergeHelper<TInputOutput>.Execute()
   at System.Linq.Parallel.MergeExecutor`1.Execute()
   at System.Linq.Parallel.MergeExecutor`1.Execute[TKey](PartitionedStream`2 partitions, Boolean ignoreOutput, ParallelMergeOptions options, TaskScheduler taskScheduler, Boolean isOrdered, CancellationState cancellationState, Int32 queryId)
   at System.Linq.Parallel.PartitionedStreamMerger`1.Receive[TKey](PartitionedStream`2 partitionedStream)
   at System.Linq.Parallel.ForAllOperator`1.WrapPartitionedStream[TKey](PartitionedStream`2 inputStream, IPartitionedStreamRecipient`1 recipient, Boolean preferStriping, QuerySettings settings)
   at System.Linq.Parallel.UnaryQueryOperator`2.UnaryQueryOperatorResults.ChildResultsRecipient.Receive[TKey](PartitionedStream`2 inputStream)
   at System.Linq.Parallel.UnaryQueryOperator`2.UnaryQueryOperatorResults.GivePartitionedStream(IPartitionedStreamRecipient`1 recipient)
   at System.Linq.Parallel.UnaryQueryOperator`2.UnaryQueryOperatorResults.GivePartitionedStream(IPartitionedStreamRecipient`1 recipient)
   at System.Linq.Parallel.QueryOperator`1.GetOpenedEnumerator(Nullable`1 mergeOptions, Boolean suppressOrder, Boolean forEffect, QuerySettings querySettings)
   at System.Linq.Parallel.ForAllOperator`1.RunSynchronously()
   at JustApplicationWebApi.Services.ThirdService.Run() in D:\C#\Asp Net Core\JustApplicationWebApi\JustApplicationWebApi\Services\ThirdService.cs:line 15
   at JustApplicationWebApi.Services.SecondService.Run() in D:\C#\Asp Net Core\JustApplicationWebApi\JustApplicationWebApi\Services\SecondService.cs:line 7
   at JustApplicationWebApi.Services.FirstService.Run() in D:\C#\Asp Net Core\JustApplicationWebApi\JustApplicationWebApi\Services\FirstService.cs:line 7
   at JustApplicationWebApi.Controllers.ExceptionHandlerController.Get() in D:\C#\Asp Net Core\JustApplicationWebApi\JustApplicationWebApi\Controllers\ExceptionHandlerController.cs:line 19
```

GetFullInfo()
```
Source: System.Linq.Parallel
############################
Source: JustApplicationWebApi
#############################
Unable to cast object of type 'System.String' to type 'System.Int32'.
=====================================================================
Type: "System.AggregateException"
*********************************
------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
   at JustApplicationWebApi.Services.ThirdService.<>c.<Run>b__0_0(Object n) in D:\C#\Asp Net Core\JustApplicationWebApi\JustApplicationWebApi\Services\ThirdService.cs:line 12
   at System.Linq.Parallel.SelectQueryOperator`2.SelectQueryOperatorResults.GetElement(Int32 index)
   at System.Linq.Parallel.QueryResults`1.get_Item(Int32 index)
   at System.Linq.Parallel.PartitionedDataSource`1.ListContiguousIndexRangeEnumerator.MoveNext(T& currentElement, Int32& currentKey)
   at System.Linq.Parallel.ForAllOperator`1.ForAllEnumerator`1.MoveNext(TInput& currentElement, Int32& currentKey)
   at System.Linq.Parallel.ForAllSpoolingTask`2.SpoolingWork()
   at System.Linq.Parallel.SpoolingTaskBase.Work()
   at System.Linq.Parallel.QueryTask.BaseWork(Object unused)
   at System.Threading.ExecutionContext.RunFromThreadPoolDispatchLoop(Thread threadPoolThread, ExecutionContext executionContext, ContextCallback callback, Object state)
--- End of stack trace from previous location ---
   at System.Threading.ExecutionContext.RunFromThreadPoolDispatchLoop(Thread threadPoolThread, ExecutionContext executionContext, ContextCallback callback, Object state)
   at System.Threading.Tasks.Task.ExecuteWithThreadLocal(Task& currentTaskSlot, Thread threadPoolThread)
------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

One or more errors occurred. (Unable to cast object of type 'System.String' to type 'System.Int32'.)
====================================================================================================
------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
   at System.Linq.Parallel.QueryTaskGroupState.QueryEnd(Boolean userInitiatedDispose)
   at System.Linq.Parallel.SpoolingTask.SpoolForAll[TInputOutput,TIgnoreKey](QueryTaskGroupState groupState, PartitionedStream`2 partitions, TaskScheduler taskScheduler)
   at System.Linq.Parallel.DefaultMergeHelper`2.System.Linq.Parallel.IMergeHelper<TInputOutput>.Execute()
   at System.Linq.Parallel.MergeExecutor`1.Execute()
   at System.Linq.Parallel.MergeExecutor`1.Execute[TKey](PartitionedStream`2 partitions, Boolean ignoreOutput, ParallelMergeOptions options, TaskScheduler taskScheduler, Boolean isOrdered, CancellationState cancellationState, Int32 queryId)
   at System.Linq.Parallel.PartitionedStreamMerger`1.Receive[TKey](PartitionedStream`2 partitionedStream)
   at System.Linq.Parallel.ForAllOperator`1.WrapPartitionedStream[TKey](PartitionedStream`2 inputStream, IPartitionedStreamRecipient`1 recipient, Boolean preferStriping, QuerySettings settings)
   at System.Linq.Parallel.UnaryQueryOperator`2.UnaryQueryOperatorResults.ChildResultsRecipient.Receive[TKey](PartitionedStream`2 inputStream)
   at System.Linq.Parallel.UnaryQueryOperator`2.UnaryQueryOperatorResults.GivePartitionedStream(IPartitionedStreamRecipient`1 recipient)
   at System.Linq.Parallel.UnaryQueryOperator`2.UnaryQueryOperatorResults.GivePartitionedStream(IPartitionedStreamRecipient`1 recipient)
   at System.Linq.Parallel.QueryOperator`1.GetOpenedEnumerator(Nullable`1 mergeOptions, Boolean suppressOrder, Boolean forEffect, QuerySettings querySettings)
   at System.Linq.Parallel.ForAllOperator`1.RunSynchronously()
   at JustApplicationWebApi.Services.ThirdService.Run() in D:\C#\Asp Net Core\JustApplicationWebApi\JustApplicationWebApi\Services\ThirdService.cs:line 15
   at JustApplicationWebApi.Services.SecondService.Run() in D:\C#\Asp Net Core\JustApplicationWebApi\JustApplicationWebApi\Services\SecondService.cs:line 7
   at JustApplicationWebApi.Services.FirstService.Run() in D:\C#\Asp Net Core\JustApplicationWebApi\JustApplicationWebApi\Services\FirstService.cs:line 7
   at JustApplicationWebApi.Controllers.ExceptionHandlerController.Get() in D:\C#\Asp Net Core\JustApplicationWebApi\JustApplicationWebApi\Controllers\ExceptionHandlerController.cs:line 19
------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
```

``` cs
Assembly.LoadFile(@"C:/InvalidFileName");
```

ToString()
```
System.IO.FileNotFoundException: Could not load file or assembly 'C:\InvalidFileName'. The system cannot find the file specified.
File name: 'C:\InvalidFileName'
   at System.Reflection.Assembly.LoadFile(String path)
   at JustApplicationWebApi.Services.ThirdService.Run() in D:\C#\Asp Net Core\JustApplicationWebApi\JustApplicationWebApi\Services\ThirdService.cs:line 9
   at JustApplicationWebApi.Services.SecondService.Run() in D:\C#\Asp Net Core\JustApplicationWebApi\JustApplicationWebApi\Services\SecondService.cs:line 7
   at JustApplicationWebApi.Services.FirstService.Run() in D:\C#\Asp Net Core\JustApplicationWebApi\JustApplicationWebApi\Services\FirstService.cs:line 7
   at JustApplicationWebApi.Controllers.ExceptionHandlerController.Get() in D:\C#\Asp Net Core\JustApplicationWebApi\JustApplicationWebApi\Controllers\ExceptionHandlerController.cs:line 19
```

GetFullInfo()
```
Source: System.Private.CoreLib
##############################
Could not load file or assembly 'C:\InvalidFileName'. The system cannot find the file specified.
================================================================================================
Type: "System.IO.FileNotFoundException"
***************************************
File name: "C:\InvalidFileName"
+++++++++++++++++++++++++++++++
--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
   at System.Reflection.Assembly.LoadFile(String path)
   at JustApplicationWebApi.Services.ThirdService.Run() in D:\C#\Asp Net Core\JustApplicationWebApi\JustApplicationWebApi\Services\ThirdService.cs:line 9
   at JustApplicationWebApi.Services.SecondService.Run() in D:\C#\Asp Net Core\JustApplicationWebApi\JustApplicationWebApi\Services\SecondService.cs:line 7
   at JustApplicationWebApi.Services.FirstService.Run() in D:\C#\Asp Net Core\JustApplicationWebApi\JustApplicationWebApi\Services\FirstService.cs:line 7
   at JustApplicationWebApi.Controllers.ExceptionHandlerController.Get() in D:\C#\Asp Net Core\JustApplicationWebApi\JustApplicationWebApi\Controllers\ExceptionHandlerController.cs:line 19
--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
```
