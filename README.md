# C-Sharp-Cheat-Sheet

Personal cheat sheet and tidbits for working in the C# .Net framework.

www.nuget.org for packages (search, choose .NET CLI tab for download link).

## Bash Commands
```
dotnet run
dotnet new (console, xunit, sln etc.)
code .
dotnet restore (collect packages in .csproj file)
dotnet build 
dotnet run (does a build and runs)
dotnet run -- parameter (-- pass a parameter to the application, not the cli).
dotnet test
```
## Syntax Conventions
Public members have an uppercase name.
```
public class Book;
public string Name;
private List<double> grades;

```
## File Types
```
.csproj (project file)
.cs (c sharp program file)
.dll (output binary code from the cs compiler)
# the obj and bin folders (object and binary) are created on a restore and build, which means that you only need a .csproj and .cs to get up and running.
.sln (solution file, can be read by VSCode and dotnet CLI, keeps track of projects and tests so projects can be built and tested from one location, usess dotnet new sln).
```
## Reference and Value Types
Reference types store a pointer (a reference) to a location in memory and value types store the actual value itself. Anything invoked by a class is a reference type (although a struct behaves like a value type). Int, float etc are value types (they are in fact type struct Int32 with the alias int).
```
var b = new Book("Grades"); // stores a location, for example 1072.
var x = 3; // stores a value, 3.
```
When passing a parameter to a method in C# it is always pass by value unless using the keyword 'ref' or 'out' (in out you are forced to initialise the parameter).
```
[Fact]
public void CSharpCanPassByRef()
{
    var book1 = GetBook("Book 1");
    GetBookSetName(ref book1, "New Name"); // Pass by reference uses the ref keyword

    Assert.Equal("New Name", book1.Name);
}

private void GetBookSetName(ref Book book, string name) // Pass by reference uses the ref keyword
{
    book = new Book(name);
    book.Name = name;
}

// or 

[Fact]
public void Test1()
{
    var x = GetInt();
    SetInt(ref x);

    Assert.Equal(42, x); // this test passes. To change x in this instance where x is passed as a parameter to the method SetInt it must be explicity passed as a reference type.
}

private void SetInt(ref int z)
{
    z = 42;
}

private int GetInt()
{
    return 3;
}
```

## Arrays
Have a fixed size whereas lists can invoke the .Add() method.
```
# create a double point floating array with a length of three.
double numbers = new [3]; 
```
## Lists
```
List<int> numbers = new List<int>();
numbers.Add(2);

int[] array = new int[] {1, 2, 3};
numbers.AddRange(array);
```
## Dictionaries
```
using System;
using System.Collections.Generic;

public class Hello
{
    public static void Main()
    {
        // TODO: add the inventory dictionary here
        Dictionary<string, long> inventory = new Dictionary<string, long>();
        inventory["apple"] = 3;
        inventory["orange"] = 5;
        inventory["banana"] = 2;

        Console.WriteLine(inventory["apple"]);
        Console.WriteLine(inventory["orange"]);
        Console.WriteLine(inventory["banana"]);

    }
}
```
## Strings
```
string emptyString = String.Empty;
string anotherEmptyString = "";

string firstName = "Shane";
string lastName = "Rich";
string fullName = firstName + " " + lastName;

int x = 1, y = 2;
int sum = x + y;
string sumCalculation = String.Format("{0} + {1} = {2}", x, y, sum);
Console.WriteLine(sumCalculation);
```
## For Loops
For loops take the following format in C#:
```
for( [variable to count iterations] ; [conditions checked for] ; [code to execute every loop])
{

}
```
The following will print even numbers between 0 and 16.
```
for(int i = 0; i < 16; i++)
{

    if(i % 2 == 1)
    {
        continue;
    }

    Console.WriteLine(i);

}
```
## Classes
A class defines a new type. A class makes objects. Classes abstract and encapulate. Contain state(data type, for example a field definition) and behaviours (methods). If calling a class from another project this needs to be added to the .csproj file (dotnet add reference ../path/.../project.csproj). An internal class can only be used inside of that project (public can be seen by other projects.
```
// class 'Book' with an explicite constructor (as opposed to implicate, which .NET runtime uses by default to construct a class).
public class Book
    {
        // explicite constructor (method name same as class)
        public Book(string name)
        {
            this.name = name;
            grades = new List<double>();
        }
        // class fields
        private List<double> grades;
        private string name;
```
## Namespace
If not working in a name space then you are working globally.
```
using system; 

namespace GradeBook;
namespace GradeBook.Math;
```
## .NET exceptions
Null referernce exception = using a field or variable that has not been initialised and thereby == Null.

## Testing - Unit Tests
Test for correct result as well as edge conditions. Automated with test runner. xUnit.net template available (using the API Assert, an xUnit namespace). Studio Code has a test runner extension and the dotnet CLI also has a test runner (dotnet test).
```
using System;
using Xunit;

namespace GradeBook.Tests
{
    public class UnitTest1
    {
        [Fact] // this attribute is attached to the method Test1. An attribute is like a decorator.
        public void Test1()
        {

        }
    }
}
```

