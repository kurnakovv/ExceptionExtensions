
# ExceptionExtensions
 
 ![Visitors](http://estruyf-github.azurewebsites.net/api/VisitorHit?user=KurnakovMaksim&repo=ExceptionExtensions&countColor=%237B1E7A&style=flat)
  [![MIT License](https://img.shields.io/github/license/KurnakovMaksim/ExceptionExtensions?color=%230b0&style=flat)](https://github.com/KurnakovMaksim/ExceptionExtensions/blob/main/LICENSE)
 [![Build/Test](https://github.com/KurnakovMaksim/ExceptionExtensions/actions/workflows/build-test.yml/badge.svg)](https://github.com/KurnakovMaksim/ExceptionExtensions/actions/workflows/build-test.yml)

# Description
ExceptionExtensions is open source library with useful methods for working with exceptions

# How is it work
If you need handle exception, you actialy do something like that:
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
It is not useful and readable, but you can use this library:
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