
### Page 1
<a name="page-1"></a>

Simple Calculator in C  A console-based calculator application written in C# that supports basic and advanced mathematical  operations with support for reusing the previous result using the   ans   keyword.  Features  Addition (   +   )  Subtraction (   -   )  Multiplication (   *   )  Division (   /   )  Modulus (   %   )  Power (   ^   )  Square Root (   sqrt   )  Absolute Value (   abs   )  Maximum of two numbers (   max   )  Minimum of two numbers (   min   )  Reuse the previous result using   ans  Input validation and error handling  Case-insensitive operation names  Interactive menu-driven interface  Supported Operations  Operation   Description   Arguments Required  +   Addition   2  -   Subtraction   2  *   Multiplication   2  /   Division   2  %   Modulus   2  ^   Power   2  sqrt   Square Root   1  abs   Absolute Value   1  max   Maximum   2  min   Minimum   2  exit   Exit the calculator   0  •  •  •  •  •  •  •  •  •  •  •  •  •  •  1


### Page 2
<a name="page-2"></a>

Example Usage  Simple Calculator   (type   'ans' to use the last result)  Available   operations:  +   Addition  -   Subtraction  *   Multiplication  /   Division  %   Modulus  ^   Power  sqrt   Square Root  abs   Absolute Value  max   Maximum  min   Minimum  exit   Exit Calculator  Enter   operation: +  Enter   first   number:   10  Enter   second number: 5  Result = 15  Enter   operation: *  Enter   first   number (or   'ans' for 15): ans  →   Using   last result: 15  Enter   second number   (or   'ans' for 15): 2  Result = 30  Error Handling  The application handles common errors gracefully, including:  Division by zero  Modulus by zero  Square root of a negative number  Invalid operation names  Invalid numeric input  Using   ans   before any result exists  •  •  •  •  •  •  2


### Page 3
<a name="page-3"></a>

Project Structure  Program.cs  │  ├──   OperationRegistry  │   ├──   Stores all supported operations  │   ├──   Defines   argument count   for   each   operation  │   └──   Executes operations   using delegates  │  └──   Program  ├──   Displays the menu  ├──   Reads   user input  ├──   Validates   arguments  ├──   Handles   exceptions  └──   Stores previous   result   for   'ans'  Technologies Used  C#  .NET  Console Application  Delegates (   Func<>   )  Collections (   Dictionary   )  Exception Handling  How to Run  Using Visual Studio  Open the solution in Visual Studio.  Build the project (   Ctrl +   Shift + B   ).  Run the application (   Ctrl +   F5   ).  Using .NET CLI  dotnet   run  •  •  •  •  •  •  1.  2.  3.  3


### Page 4
<a name="page-4"></a>

Future Improvements  Scientific functions (   sin   ,   cos   ,   tan   ,   log   )  Operation history  Memory storage (   M+   ,   MR   ,   MC   )  Support for multiple operands  Graphical User Interface (GUI)  Author  Developed as a C# console application to demonstrate the use of dictionaries, delegates, exception  handling, and user input validation in .NET.  •  •  •  •  •  4

