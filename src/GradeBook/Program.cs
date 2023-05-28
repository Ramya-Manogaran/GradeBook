using System;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Notes
            // if (args.Length > 0)
            // {
            // Console.WriteLine($"Hello {args[0]}!");
            // }
            // else
            // {
            // Console.WriteLine($"Hello!");
            // }
            //ADDITION
            // var x = 2;
            // var y =34.1;
            // System.Console.WriteLine(x+y);
            //ARRAYS
            // double[] numbers = new double[3];
            // numbers[0] = 12.7;
            // numbers[1] = 10.3;
            // numbers[1] = 60.1;

            // double[] numbers = new double[] {12.7, 10.3, 6.11};
            // double[] numbers2 = new[] {12.7, 10.3, 6.11};

            //  var result = numbers[0];
            //  result = result + numbers[1];
            //  result += numbers[2];
            //  Console.WriteLine(result);
            //LOOP
            // var result = 0.0;
            // foreach(var number in numbers){
            //     result +=number;
            // }
            // Console.WriteLine(result);
            //LIST
            // List<double> grades = new List<double>{12.7, 10.3, 6.11};
            // grades.Add(4.1);
            // var sum = 0.0;
            // foreach(var grade in grades){
            //     sum += grade;
            // }
            // var average =sum/grades.Count;
            // System.Console.WriteLine($"Average: {average}");
            #endregion

            var book = new InMemoryBook("Ramya's InMemory GradeBook");
            var diskBook = new DiskBook("Ramya's DiskBook");
            book.GradeAdded += OnGradeAdded;//subscribing to an event
                                            // book.GradeAdded += OnGradeAdded;
                                            // book.GradeAdded -= OnGradeAdded;
                                            // book.GradeAdded += OnGradeAdded;
            diskBook.GradeAdded += OnGradeAdded;

            // book.AddGrade(10.7);
            // book.AddGrade(6.11);
            // EnterGrades(book);

            // var stats = book.GetStatistics();           

            // Console.WriteLine($"Highest grade: {stats.High}");
            // Console.WriteLine($"Lowest grade: {stats.Low}");
            // Console.WriteLine($"Average grade: {stats.Average}");
            // System.Console.WriteLine($"The letter grade is {stats.Letter}");

            EnterGrades(diskBook);

            var diskStats = diskBook.GetStatistics();

            Console.WriteLine($"Highest grade: {diskStats.High}");
            Console.WriteLine($"Lowest grade: {diskStats.Low}");
            Console.WriteLine($"Average grade: {diskStats.Average}");
            System.Console.WriteLine($"The letter grade is {diskStats.Letter}");
        }

        //private static void EnterGrade(InMemoryBook book)
        private static void EnterGrades(IBook book)
        {
            while (true)
            {
                Console.WriteLine("Enter a grade or 'q' to quit:");
                var input = Console.ReadLine();
                if (input == "q")
                {
                    break;
                }
                try
                {
                    var grade = double.Parse(input);
                    book.AddGrade(grade);
                }
                catch (ArgumentException ex)
                {
                    //keep the loop running after logging
                    System.Console.WriteLine(ex.Message);
                    //continue  to rethrow 
                    //throw();
                }
                catch (FormatException ex)
                {
                    System.Console.WriteLine((ex.Message));
                }
                finally
                {
                    // execute at all times, whether ex is throw or not
                    //like closing socket connections, disposing objects etc
                }

            }
        }

        static void OnGradeAdded(object sender, EventArgs e)
        {
            System.Console.WriteLine("A grade was added");
        }
    }
}
