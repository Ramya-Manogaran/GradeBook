using System;
using System.Collections.Generic;

namespace GradeBook
{
    public delegate void GradeAddedDelegate(object sender, EventArgs args);

    public class NamedObject{
        public NamedObject(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
    }

    public interface IBook{
        void AddGrade(double grade);
        Statistics GetStatistics();
        string Name{get;}
        event GradeAddedDelegate GradeAdded;
    }
    public abstract class Book : NamedObject, IBook
    {
        public Book(string name) : base(name)
        {
        }

        public abstract event GradeAddedDelegate GradeAdded;

        public abstract void AddGrade(double grade);

        public abstract Statistics GetStatistics();
    }
    public class InMemoryBook : Book
    {
        //ctor
         public InMemoryBook(string name) : base(name)
        {
            grades = new List<double>();
            Name = name;
        }
        private List<double> grades;//this is a field
        //  public string Name { 
        //     get; set;
        // }//this prop is inherited
        #region Property
        //Getter setter    
        // public string Name{
        //     get{
        //         return name.ToUpper();//when someone calls book.Name, value of name in uppercase will be returned
        //     }
        //     set{
        //         if(String.IsNullOrEmpty(value))//value is the implicit property of setter, whatever we receive in book.Name = "setter", "setter" is value
        //         {
        //             name = value;//keep a private field and assign to it based on checks so that name can't be externally set with corrupt data
        //         }
        //     }
        // } 
        // private string name;
        // public string Name{
        //     get{
        //         return name;
        //     }
        //     set{
        //         name = value;
        //     }
        // }
         //this is know as auto property in c#
        //same as above code except no extra logic for get and set
        //different between public field and public property is behaviour of property in places like reflection and serialization is different 
        //than a field

        //another advantage is if you want Name to be set only by the constructor then no change should be made, we can make it private set like below
        // public string Name{
        //     get; 
        //     private set;
        // }//book.Name = "" is not allowed in this case. it can be set only in the constructor
        #endregion

        
    //Readonly (only initialize or change in a constructor)
        readonly string category;//this can be set only in constructor or initialized here then it can never change
    //Const (stricter than readonly; can only be initialized. can never change after that)
        public const string CATEGORY = "Science";//convention: should be name all upper case
        //const can also be used like a static member of a class because it never changes for each object; Book.Category
        public override event GradeAddedDelegate GradeAdded;
       

        //overloading
        public void AddGrade(char letter){
            //map a char into a number
            switch(letter){
                case 'A':
                    AddGrade(90);
                    break;

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
        public override void AddGrade(double grade){
            if(grade <= 100 && grade >= 0){
                grades.Add(grade);
                if(GradeAdded != null){
                    GradeAdded(this, new EventArgs());
                }
            }
            else{
                throw new ArgumentException($"Invalid {nameof(grade)}");
            }
        }
       
        public override Statistics GetStatistics(){

            var result = new Statistics();
             foreach(var grade in grades){
               result.Add(grade);                        
            }
            return result;
        }
    }
}