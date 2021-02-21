using System;
using System.Collections.Generic;
using System.IO;

namespace GradeBook
{
    public interface IBook
    {
        // note that public is not required here as it is public by default; types that implement an interface must have these methods available.
        void AddGrade(double grade);
        void AddGrade(char letter);
        Statistics GetStatistics();
        string Name { get; set; }
        // event GradeAddedDelegate GradeAdded;
    }
    public abstract class Book : NamedObject, IBook
    {
        public Book(string name) : base(name)
        {
        }
        public abstract Statistics GetStatistics();
        public abstract void AddGrade(double grade);
        public void AddGrade(char letter)
        {
            switch (letter)
            {
                case 'A':
                    AddGrade(90);
                    break; // required to control flow, ie, break out of the switch.
                case 'B':
                    AddGrade(80);
                    break;
                case 'C':
                    AddGrade(70);
                    break;
                case 'D':
                    AddGrade(60);
                    break;
                default:
                    AddGrade(0);
                    break;
            }
        }
    }
    public class DiskBook : Book
    {
        public DiskBook(string name) : base(name)
        {
        }
        public override void AddGrade(double grade)
        {
            using (var writer = File.AppendText($"{Name}.txt"))
            {
                writer.WriteLine(grade);
                if (GradeAdded != null)
                {
                    GradeAdded(this, new EventArgs());
                }
            }
        }
        public override Statistics GetStatistics()
        {
            var result = new Statistics();

            using (var reader = File.OpenText($"{Name}.txt"))
            {
                var line = reader.ReadLine();
                while (line != null)
                {
                    var number = double.Parse(line);
                    result.Add(number);
                    line = reader.ReadLine();
                }
            }
            return result;
        }
        public event GradeAddedDelegate GradeAdded;
    }
    public class InMemoryBook : Book
    {
        // make an explicite constructor (as opposed to implicate, which .NET runtime uses by default to construct a class)
        public InMemoryBook(string name) : base(name)
        {
            category = "";
            // Name = name;
            grades = new List<double>();
        }

        public override void AddGrade(double grade)
        {
            if (grade >= 0 && grade <= 100)
            {
                grades.Add(grade);
                if (GradeAdded != null)
                {
                    GradeAdded(this, new EventArgs());
                }
            }
            else
            {
                throw new ArgumentException($"Invalid {nameof(grade)}");
            }
        }
        public event GradeAddedDelegate GradeAdded;
        public override Statistics GetStatistics()
        {
            var result = new Statistics();

            foreach (var grade in grades)
            {
                result.Add(grade);
            }
            return result;
        }

        // the below alternatives for loops would not need to be refactored given the transfer of stats calculations into the Statistics class.
        // public Statistics GetStatistics1() // using a while loop
        // {
        //     var result = new Statistics();

        //     result.Low = double.MaxValue;
        //     result.High = double.MinValue;
        //     result.Average = 0.0;

        //     var index = 0;

        //     while(index < grades.Count)
        //     {
        //         result.High = Math.Max(result.High, grades[index]);
        //         result.Low = Math.Min(result.Low, grades[index]);
        //         result.Average += grades[index];
        //         index += 1;
        //     } 
        //     result.Average /= grades.Count;

        //     return result; 
        // }

        // public Statistics GetStatistics2() // using a for loop
        // {
        //     var result = new Statistics();

        //     result.Low = double.MaxValue;
        //     result.High = double.MinValue;
        //     result.Average = 0.0;

        //     for(var index = 0; index < grades.Count; index++)
        //     {
        //         result.High = Math.Max(result.High, grades[index]);
        //         result.Low = Math.Min(result.Low, grades[index]);
        //         result.Average += grades[index];
        //     } 
        //     result.Average /= grades.Count;

        //     return result; 
        // }        

        // public void ShowStatistics()
        // {

        // }

        // fields
        public const string CATEGORY = "Science";
        readonly string category;
        private List<double> grades;
        // private string name; // this was commented out as not necessary using the get set autoproperty below.

        // properties
        // public string Name
        // {
        //     get
        //     {
        //         return name.ToUpper();
        //     }
        //     set
        //     {
        //         if(!String.IsNullOrEmpty(value))
        //         {
        //             name = value;
        //         }
        //         else
        //         {
        //             throw new ArgumentNullException("The program attempted to update the name but it was invalid because it was null");
        //         }
        //     }
        // }

        // in fact microsoft has an auto-property for get and set as shown below and the field 'private string name;' can be deleted.
        // the autoproperty was commented out when we introduced the class NamedObject which became the base class for Book.
        // public string Name
        // {
        //     get;
        //     set; // you could add 'private' to set for example.
        // }
    }
}