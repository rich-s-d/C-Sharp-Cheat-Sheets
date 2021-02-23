# C-Sharp-Cheat-Sheet

Personal cheat sheet and tidbits for working in the C# .Net framework.

## Resources
pluralsight.com (search Scott Allen)
http://wirfs-brock.com (Rebecca Wirfs-Brock, book on Object Oriented Programming). OOP; objects are either knowing things, deciding things or doing things.
www.nuget.org for packages (search, choose .NET CLI tab for download link).

https://devblogs.microsoft.com/dotnet/an-introduction-to-dataframe/ C# take on Pandas dataframes.

## Useful to remember
F12 or right click Go to Definition to see underlying type and source code.
Right click 'change symbol' will refactor the name of a class, method etc through the program.
Right click 'implement interface'.
Generally click on the lightbulb in Studio Code for automated implementations, extractions etc.

## To be aware of
LINQ Language Integrated Query. When this was introduced to C# it introduced some of the biggest changes to the language since it was invented. These changes can be helpful outside of LINQ.
Build in generic collections; Interfaces, Classes, Delegates.
Async C#; using async, await, task.
ASP.Net is the Microsoft Web Framework.

## Common runtime errors I encounter coming from a python background with dynamic typing:
1. 'The name 'employee' does not exist in the current context' - remember to be explicit, use 'var'.
2. 
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
Interfaces begin with an uppercase I.
Constants are in capitals.
Underscores have conventionally be used as a prefix to a private member variable, e.g. _customerId
```
public class Book;
public string Name;
private List<double> grades;

public interface IBook
{
    etc..
}

public const string CATEGORY = "Science"
private void double _customerId;
```
## File Types
```
.csproj (project file)
.cs (c sharp program file)
.dll (output binary code from the cs compiler)
# the obj and bin folders (object and binary) are created on a restore and build, which means that you only need a .csproj and .cs to get up and running.
.sln (solution file, can be read by VSCode and dotnet CLI, keeps track of projects and tests so projects can be built and tested from one location. Add project files (src and test) to solution file. From CLI use 'dotnet new sln'), then dotnet sln (add, list, remove) filepath as need be. 
```
## Reference and Value Types
Reference types store a pointer (a reference) to a location in memory and value types store the actual value itself. Anything invoked by a class is a reference type (although remember that a struct type behaves like a value type). Int, double etc are value types (they are in fact type struct eg, struct Int32 with the alias int or struct Double with alias double). Strings are an exception to the rule, they are reference types (class types, not struct), but sometimes they behave like value types, in other words, strings are immutable in C#.
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
## Collections
note on arguments: the params keyword can be used when building arguments to allow the compiler to build a collection under the hood. If you hover over Split() you will see Split(params char[] etc). See below:
```
// Split() takes an array of characters, but one can simply pass the argument ',' because params is passed in construction of the Split method.
line.Split(var char[] {','};
// is the same as
line.Split(',')
```
StreamReader is a useful class for populating collections. It uses a method ReadLine() to extract each line of a file.
### Arrays
Have a fixed size whereas lists can invoke the .Add() method. This size can never be changed. If you instatiate an array the values will be full of nulls unless you initialise the values. Nulls because an array is a reference type; value types would be zero. If number of instatiated items is unknown a list can be used.
```
# create a double point floating array with a length of three. You can also pass a collection intialiser using {}.
double numbers = new [3]; // numbers == [null, null, null]
double numbers2 = new [] {45.1, 23, 2.3};

// Arrays can be resized, but it may be more memory efficient to use a list.
Array.Resize(ref numbers, 5);

// Length of array
numbers.Length
```
### Lists
As opposed to arrays, lists can be resized and instatiated with an unknown number of values. Collection initialiser can be used (which instantiates an empty list under the hood and repeatedly calls the Add() method. To instatiate a list is as to instatiate any C# type (arrays are an exception because they are part of the .NET Runtime/Framework and lists are a C# type). An array has Lenght, a list has Count.
```
List<int> numbers = new List<int>();
numbers.Add(2);

int[] array = new int[] {1, 2, 3};
numbers.AddRange(array);

//Length of list
numbers.Count
```
### Queue of T (FIFO: first in first out)
When you need to control the order of insertion and retrieval use a queue. The following employees were entered in the order 1) Maike, 2) Schafer and were returned in the same order (FIFO - first in first out):
```
Queue<Employee> line = new Queue<Employee>();
line.Enqueue(new Employee { Name = "Maike" }); // adds to head of queue
line.Enqueue(new Employee { Name = "Schafer"});

while (line.Count != 0) // because dequeue will remove items from the queue.
{
    var employee = line.Dequeue();
    System.Console.WriteLine(employee.Name);
}

// returns
Maike
Schafer
```
Once an item is dequeued it is removed. You can look at the next item in the queue with .Peek(), search with .Contains() and look at everything in the queue with an .ToArray(), which returns a copy of the queue as an array.

### Stack of T (LIFO: last in first out)
Exactly as FIFO above but add with .Push() and dequeue with .Pop(). Used if you need to deal with something else and then come back to what you were working on. You can look at the next item in the queue with .Peek(), search with .Contains() and look at everything in the queue with an .ToArray(), which returns a copy of the queue as an array.

### Hash Set (as in Mathematics a set of unique items).
You can not index into a set as the order is unknown. Sets are nice for doing intersections, ie., returns items in both sets (essentially a spatial join). Or a union (returns a set with all items in both sets (but only unique items of course!). Various other mathematical set operations, such as SymmetricExceptWith (returns a set with items that are only in one set or the other but not both).
```
HashSet<int> set = new HashSet<int>();
set.Add(2);
set.Add(1);
set.Add(2);

foreach(var number in set)
{
    System.Console.WriteLine(number);
}
System.Console.WriteLine($@"There are {set.Count} unique items in this Hash Set
but three items were added");
```
Be aware: if adding an object with the same parameter name, Name = "foo" for example, because the two objects have different reference pointers they will both be added to the set.
### Dictionaries
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
## Controlling execution flow
```
&& \\ and
|| \\ or
```
### Loops (for, foreach, do while and while)
```
for( [variable to count iterations] ; [conditions checked for] ; [code to execute every loop])
{

}
```
The following will print even numbers between 0 and 16.
```
// for
for(int i = 0; i < 16; i++)
{
    if(i % 2 == 1)
    {
        continue;
    }
    Console.WriteLine(i);
}

// foreach
foreach(var grade in grades)
{
    result.High = Math.Max(result.High, grade);
    result.Low = Math.Min(result.Low, grade);
    result.Average += grade;
}
result.Average /= grades.Count;

// do while
var index = 0;
do 
{
    result.High = Math.Max(result.High, grades[index]);
    result.Low = Math.Min(result.Low, grades[index]);
    result.Average += grades[index];
    index += 1;
} while(index < grades.Count);
result.Average /= grades.Count;

// while 
while(index < grades.Count)
{
    result.High = Math.Max(result.High, grades[index]);
    result.Low = Math.Min(result.Low, grades[index]);
    result.Average += grades[index];
    index += 1;
} 
result.Average /= grades.Count;
```
### Jumping statements
break and continue as per python.
```
break; (break out and stop iterating completely)
continue; (skip this one and continue with the next iteration)
```
### Switch
with or without pattern matching.
```
// with
switch(result.Average)
{
    case var d when d >= 90.0: // the declared variable d takes the value provided to switch(result.Average). 
        result.Letter = 'A';
        break;
// without
switch(letter)
{
    case 'A':
        AddGrade(90);
        break;
```
### Exception Classes/Objects
Custom exception or built-in exceptions. General format given:
```
public void AddGrade(double grade)
{   
    if (grade >= 0 && grade <= 100)
    {
        grades.Add(grade);
    }
    else
    {
        throw new ArgumentException($"Invalid {nameof(grade)}");
    }
}
```
Is...
```
try
{
var grade = double.Parse(input);
book.AddGrade(grade);
}
catch(Exception ex) // defining a variable ex of class Exception, the general exception class. Usually better to catch and handle individual exception types, eg, catch an ArgumentException, FormatException, etc (stacking them).
{
    System.Console.WriteLine(ex.Message);
    throw; // throw the exception again if you want to force the program to crash in the case that it should not continue or something else should handle the exception.
}
\\ for example
catch(ArgumentException ex)
{
    Console.WriteLine(ex.Message)
}
catch(FormatException ex)
{
    Console.WriteLine(ex.Message)
}
```
## Classes
A class defines a new type. A class makes objects. Classes abstract and encapulate. Contain state(data type, for example a field definition) and behaviours (methods). If calling a class from another project this needs to be added to the .csproj file (dotnet add reference ../path/.../project.csproj). An internal class can only be used inside of that project (public can be seen by other projects. Constructors can be overloaded (different constructor signatures). Readonly fields can be used in constructors and they are a fantastic way to ensure that information that is set at construction can not be changed elsewhere in the program.
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
### Overloading methods
Just as constructors can be overloaded, methods can too. Constructors and methods can have the same name because the compiler looks at a signature, ie., method name, parameter types and number of parameters, not just the method or constructor name. The return type is not part of the method signature.

### Properties
Encapsulate state to control read and writing (get and set) to a property of a type/class. This encapsulation is an advantage using a property over a field.
```
public string Name
{
    get
    {
        return name;
    }
    set
    {
        if(!String.IsNullOrEmpty(value))
        {
            name = value;
        }
        else
        {
            throw new Exception();
        }
    }
```
### Readonly fields
Can not be assigned to unless in a constructor or initialiser.
```
readonly string category;
```
### Const fields (are static).
Even more restrictive than readonly; defined not able to be set or modified in the constructor. It is a static field that can be accessed from the class, ie., Book.CATEGORY. This makes sense; it never changes to it does not need to be assoicated with each object created by the type but simply the type itself.
```
public const string CATEGORY = "Science";
```
### Delegates and Events
If working with ASP.NET Core to build server side applications on top of .NET Core you may not come accross events. But Desktop or Mobile Frameworks, like WPF, use events, because every UI interaction is an event (when does button click or mouse move are events that you can listen for).
A delegate describes what a method will look like. A delegate points to and invokes different methods; the method has to have a specific shape and structure that is defined by the delegate (ie., return type, types of parameters, numbers of parameters). For example you can implement a variable of delegate type, which can point to various methods with the same structure, but with different implementations, so one could write to a file, another to the console.
```
public delegate string WriteLogDelegate(string logMessage); // delegate describes structure, ie, must return string, takes one parameter of type string.

public class TypeTests
{
    [Fact]
    public void WriteLogDelegateCanPointToMethod()
    {
        WriteLogDelegate log; // declaration of the variable
        log = new WriteLogDelegate(ReturnMessage); // instantiate the variable and pass the delegate method as the parameter. This says, 'point log to ReturnMessage'. Long hand formulation.
        log = ReturnMessage; // short hand form of the above line.
        var result = log("hello"); // the delegate is invoked. Now, if I am off somewhere else and can not see the code above I dont know what delegate method I am invoking but what I do know is that I can invoke that delegate.

        Assert.Equal("hello", result); // this test will return true/pass as the result is the output of ReturnMessage, which is the string "hello' that was passed as the input parameter.
    }

    string ReturnMessage(string message) // a delegate method, it returns a string and takes one parameter of type string.
    {
        return message;
    }
```
Now, delegates can invoke multiple methods. This are called multi-cast delegates.
```
int count = 0;
[Fact]
public void WriteLogDelegateCanPointToMethod2()
{
    WriteLogDelegate log = ReturnMessage;
    log += ReturnMessage; // invoking the first delegate method.
    log += ReturnMessage2; // invoking the second.
    var result = log("hello"); // so here, when the log method is invoked, it will call ReturnMessage twice and ReturnMessage2 once. Count will therefore be 3.
    Assert.Equal(3, count); // Test will pass as true.
    Assert.Equal("HELLO", result); Test will also pass as the last method invoked was ReturnMessage2, which returns the string in upper case.
}
string ReturnMessage(string message)
{
    count ++;
    return message;
}
string ReturnMessage2(string message)
{
    count ++;
    return message.ToUpper();
}
```
Multi-cast delegates are powerful because you can declare a variable of a delegate type and then point it at various methods that perform different tasks.
Events; lets says that we want a logging api to know when a grade is added, or I want to know when a button is clicked on a website. These can be thought of as 'significant' events. Delegates are useful with events because we can define a delegate and at runtime point that delegate to different methods making the desired announcements to other parts of an application, for example that logging api. When declaring an event delegate the convention is to pass 'object sender' as the first parameter and the second parameter is some form of event arguments. An event is a member of a class (and we can use a delegate to define an event member as part of a class).
```
// GradeAddedDelegate.cs // Seperate file for delegates.
using System; 
namespace GradeBook
{
    public delegate void GradeAddedDelegate(object sender, EventArgs args);
}

public event GradeAddedDelegate GradeAdded; // A delegate event of type GradeAddedDelegate with the name GradeAdded. Without the event keyword this would be a field in a class(yoy can do book.GradeAdded() and invoke the delegate method). For all intend and purposes it will work without the keyword 'event', but with 'event' there are some restrictions that are safer to use, ie., back in the program.cs you can not assign a value to the delegate method, ie., book.GradeAdded = null; will not compile. If it did compile, then it would reset anything earlier on the method invocation list and you dont necessarily want that. To allows assignment of book.GradeAdded = null;, then remove the 'event' keyword.

public override void AddGrade(double grade)
{
    if (grade >= 0 && grade <= 100)
    {
        grades.Add(grade);
        if (GradeAdded != null) // is anything 'listening'? If null then no one added a method reference into the delegate so no announcements required because no one is listening.
        {
            // Raise the event (invoke)
            GradeAdded(this, new EventArgs()); // invoke GradeAdded delegate method. Need to pass the arguments that are set in the delegate. The sender is itself, or 'this'. In python this would be 'self'.
        }
    }
```
Raising the event is to invoke it (GradeAdded(this, new EventArgs());, handling an event is to add a method(s) into the invocation list using the +=/-= operator. The below would print "A grade was added" only once (it was added twice and removed once).
```
    var book = new InMemoryBook("Shane's Grade Book");
    book.GradeAdded += OnGradeAdded; // subscribing to an event
    book.GradeAdded += OnGradeAdded;
    book.GradeAdded -= OnGradeAdded;

// the main method is static so the method must also be static as static memebers can only reach other static members.
// this method is invoked by the GradeAdded delegate above. To be invoked by the GradeAdded delegate it must comply; it returns void and takes two parameters, the sender and EventArgs.
static void OnGradeAdded(object sender, EventArgs e)
{
    System.Console.WriteLine("A grade was added"); // Handling an event.
}
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
### Null reference exceptions
A tool to help identify variables and fields that are not pointing to an object and thereby giving null reference exceptions. Class definitions, which are reference types (pointers) are now non-nullable by default.
```
Book book = null; //will cause a linting error in studio code.
```
But if you need to make a reference type nullable, ie., this book has no information so it needs to be instatiated as a null value, use a question mark:
```
Book? book = null;
```
## OOP in C#
1. Encapsulation - hide details using methods and properties, also by using access modifiers public or private give explicit control.
2. Inheritance - reuse code across similar classes.
3. Polymorphism - objects of the same type that can behave differently (also can be considered a form of encapsulation - it can hide details behind an object, ie. how to store data where).

### Encapsulation
Most important of the three pillars! Other than using classes, methods fields and properties to give encapsulation, one can also use interfaces. Interfaces are similar to a class, but they are pure, meaning that unlike a class they do not require implemenation details. So whereas an abstract class (described further below under polymorphism) can contain methods and code, an interface is only going to describe the members that will be available on this type. An unlimited number of interfaces can be added to a class in a comma seperated list after the inherited base class. When you implement an interface, you must have those members in your class - also if those members are abstract. To make methods available in a class use the override keyword. 
```
public interface IBook
{   
    // note that public is not required here as it is public by default; types that implement an interface must have these methods available. Members are defined below.
    void AddGrade(double grade);
    Statistics GetStatistics();
    string Name { get;}
    // event GradeAddedDelegate GradeAdded;

}
public abstract class Book : NamedObject, IBook // Only one base class can be added to a class but zero or more interfaces can be added.
{
    public Book(string name) : base(name)
    {
    }
    // public abstract Statistics GetStatistics();
    public abstract void AddGrade(double grade);
    // Virtual keyword says that a derived class may choose to override this implementation.
    public virtual Statistics GetStatistics()
    {
        throw new NotImplementedException();
    }
}
```
### Inheritance
1. Base class
2. Derived class
```
public class NamedObject
{
    public string Name
    {
        get;
        set;
    }
}
public class Book : NamedObject 
```
In the above example we can describe Book as a NamedOject. NamedOject is the base class, Book is the derived class. Because Book is a NamedOject, it will inherit the property Name. Essentially the derived class inherits methods, properties etc from the base class. To conclude, everything in .NET dervices from the System.Object base class (in the above example, the base class NamedObject could be written as follows; public class NamedObject : System.Object - the keyword shortcut for which is object with a lower case o.

### Polymorphism
The ability of an object to take different forms. To learn this the object class Abstract can be introduced.
```
public abstract class BookBase
{
    public void AddGrade(double grade)
    {
        ...implementation here...
    }
}

// But because we cant say what the implimentation is at this level (the abstract class simply defines a base class from which different implemtations of book can be instantiated), we make the AddGrade method abstract as well: 

public abstract class BookBase
{
    public abstract void AddGrade(double grade); 
}
```
Inherited classes must provide an implementation of the abstract members in the base class. Derived class methods can override abstract and virtual methods. If we make BookBase a NamedObject, we must provide the implementation for the name, in this case a constructor, because NamedObject requires the parameter 'string name' in its constructor.
```
namespace GradeBook
{
    public class NamedObject : System.Object // Usually you would not write System.Object as it is implicitly the Base Class of everything.
    {
        // class constuctor can automatically bw generated with right click 'generate constructor NamedObject'
        public NamedObject(string name)
        {
            Name = name;
        }

        public string Name
        {
            get;
            set;
        }
    }
}

public abstract class BookBase : NamedObject
    {
        public BookBase(string name) : base(name)
        {
        }
        public abstract void AddGrade(double grade); 
    }
    public class Book : BookBase
    {
        // make an explicite constructor (as opposed to implicate, which .NET runtime uses by default to construct a class)
        public Book(string name) : base(name)
        {
            category = "";
            Name = name;
            grades = new List<double>();
        }
        
// override below because AddGrade is an abstract method in the Base Class BookBase.

    public override void AddGrade(double grade)
    {   
        if (grade >= 0 && grade <= 100)
        {
            grades.Add(grade);
        }
        else
        {
            throw new ArgumentException($"Invalid {nameof(grade)}");
        }
    }
```
### IDisposable
.NET has a garbage collector to release unmanaged resources but if we are dealing with a file or something that requires immediate cleaning/closing etc then use IDisposable. If you see IDisposible interface on a class in .NET it suggests that they need something to be freed or released. For example File.AppendText ultimately implements IDisposable so it is something that needs to be cleaned up (using the methods available under IDisposable, namely close() and dispose(). A useful work around is to use the following using statement, as C# will automatically run a finally statement at the end of the bracket to clean/close the file. This is the same process as Python's "with open(day5.txt as f)" statement:
```
public override void AddGrade(double grade)
{
    using(var writer = File.AppendText($"{Name}.txt"))
    {
        writer.WriteLine(grade);
    }
}
```
## Type Casting
Explicit:
```
double myDouble = 9.78;
int myInt = (int) myDouble;    // Manual casting: double to int

Console.WriteLine(myDouble);   // Outputs 9.78
Console.WriteLine(myInt);      // Outputs 9
```
# C# Generics - reuse code with type safety - introduced in version 2.
Generics allow you to paramatarise data types so you dont have to commit to a certain data type (say string, or int, or Country) at compile time. Why? You could commit everything to an object type, but as a reference type, the object will be forced to add value types to the heap at runtime and this is inefficient because the value have to be boxed and then unboxed later when used. Use T, type.
```
public class CircularBuffer<T> // Generic Class. T is the type parameter. This now called "circular buffer of T" not just circular buffer.
{
    private T[] _buffer;
    // private List<T> _buffer2;
}

CircularBuffer buffer = new CircularBuffer<double>(); // <double>, the angular brackets contain the type argument, in this case double. Could be any type of array, <string> for example.
```

