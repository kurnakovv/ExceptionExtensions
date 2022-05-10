<div align="center">
 <img src="icon.png" weight="500px" height="300px" />
 <h2>ExceptionExtensions</h2>
 
 ![Visitors](http://estruyf-github.azurewebsites.net/api/VisitorHit?user=KurnakovMaksim&repo=ExceptionExtensions&countColor=%237B1E7A&style=flat)
 [![Build/Test](https://github.com/KurnakovMaksim/ExceptionExtensions/actions/workflows/build-test.yml/badge.svg)](https://github.com/KurnakovMaksim/ExceptionExtensions/actions/workflows/build-test.yml)
 [![CodeQL](https://github.com/KurnakovMaksim/ExceptionExtensions/workflows/CodeQL/badge.svg)](https://github.com/KurnakovMaksim/ExceptionExtensions/actions?query=workflow%3ACodeQL)
 [![Code Smells](https://sonarcloud.io/api/project_badges/measure?project=KurnakovMaksim_ExceptionExtensions&metric=code_smells)](https://sonarcloud.io/summary/new_code?id=KurnakovMaksim_ExceptionExtensions) [![Coverage](https://sonarcloud.io/api/project_badges/measure?project=KurnakovMaksim_ExceptionExtensions&metric=coverage)](https://sonarcloud.io/summary/new_code?id=KurnakovMaksim_ExceptionExtensions)

</div>

# Description
<b>ExceptionExtensions</b> is open source library with useful methods for working with exceptions

# How is it work
If you need to handle an exception, you do something like this:
``` cs
try
{
    string[] array = new string[4] { "1", "2", "3", "4" };
    int invalidElement = array[5].Length;
}
catch (Exception ex)
{
    string message = $"{ex.Message} {ex.StackTrace} {ex.InnerException}"; // Or something else...
    // Work with message.
}
```
It is not usable and not readable, but you can use this library:
``` cs
try
{
    string[] array = new string[4] { "1", "2", "3", "4" };
    int invalidElement = array[5].Length;
}
catch (Exception ex)
{
    string message = ex.GetFullInfo();
    // Work with full message.
}
```
Output:
```
==========================================
Index was outside the bounds of the array.
==========================================
-------------------------------------------------------------------------------------------------------------
   at JustApplication.Program.Main(String[] args) in D:\C#\JustApplication\JustApplication\Program.cs:line 32
-------------------------------------------------------------------------------------------------------------

```
