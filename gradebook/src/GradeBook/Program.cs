
using System;

namespace GradeBook
{

    class Program
    {

        static void Main(string[] args)
        {
            var book = new InMemoryBook("Shane's Grade Book");
            book.GradeAdded += OnGradeAdded;
            book.GradeAdded += OnGradeAdded;
            book.GradeAdded -= OnGradeAdded;
            

            // the next 8 lines of code can be deleted but I've left them there for learnings sake.
            try
            {
                book.Name = "Shane's Grade Book";
            }
            catch (ArgumentException exName)
            {
                System.Console.WriteLine((exName.Message));
            }

            EnterGrades(book);

            var stats = book.GetStatistics();

            System.Console.WriteLine($"Category: {InMemoryBook.CATEGORY}"); // CATEGORY was set up as a const field 'constant'
            System.Console.WriteLine($"For the book named {book.Name}");
            Console.WriteLine($"The average grade is {stats.Average:N1}");
            Console.WriteLine($"The highest grade in {stats.High}");
            Console.WriteLine($"The lowest grade is {stats.Low}");
            System.Console.WriteLine($"The average letter grade is {stats.Letter}");
        }
    // public double[] numbers = new double[3];
        private static void EnterGrades(IBook book)
        {
            while (true)
            {
                Console.WriteLine("Please enter a grade or 'q' to quit");
                
                var input = Console.ReadLine();
                if (input == "q")
                    break;

                try
                {   
                    if (input == "A" || input == "B" || input == "C" || input == "D")
                    {
                        var grade = char.Parse(input);
                        book.AddGrade(grade);
                    }
                    else
                    {
                        var grade = double.Parse(input);
                        book.AddGrade(grade);
                    }
                    
                }
                catch (ArgumentException ex)
                {
                    System.Console.WriteLine(ex.Message);
                }
                catch (FormatException ex)
                {
                    System.Console.WriteLine(ex.Message);
                }
                finally
                {
                    System.Console.WriteLine("This sentence is printing because I am testing the the 'finally' block here can be useful to close a file, close a network socket, clean something up etc.");
                }
            }
        }
        static void OnGradeAdded(object sender, EventArgs e)
        {
            System.Console.WriteLine("A grade was added");
        }
    }
}