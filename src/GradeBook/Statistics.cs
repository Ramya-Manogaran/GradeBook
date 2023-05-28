using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GradeBook
{
    public class Statistics
    {
        public Statistics()
        {
            Count = 0;
            Sum = 0.0;
            High = double.MinValue;
            Low = double.MaxValue;
        }
        public double Average
        {
            get
            {
                return Sum / Count;
            }
        }
        public char Letter
        {
            get
            {
                switch (Average)
                {
                    case var d when d >= 90.0:
                        return 'A';

                    case var d when d >= 80.0:
                        return 'B';

                    case var d when d >= 70.0:
                        return 'C';

                    case var d when d >= 60.0:
                        return 'D';

                    default:
                        return 'F';
                }
            }
        }
        public double High;
        public double Low;
        public double Sum;
        public int Count;
        public void Add(double number)
        {
            Sum += number;
            Count += 1;
            Low = Math.Min(Low, number);
            High = Math.Max(High, number);
        }

        #region Looping statements
        //do while will execute at least once
        // int i=0;
        // do{
        //     result.High = Math.Max(result.High, grades[i]);
        //     result.Low = Math.Min(result.Low, grades[i]);
        //     result.Average += grades[i];   
        //     i++;              
        // } while(i<grades.Count);

        // while will check condition and then execute
        // int i = 0;
        // while(i <grades.Count){
        //     result.High = Math.Max(result.High, grades[i]);
        //     result.Low = Math.Min(result.Low, grades[i]);
        //     result.Average += grades[i];   
        //     i++;              
        // }

        //for loop will have initialization, condition and increment/decrement in a single line
        // for(int i=0; i< grades.Count; i++){
        //     result.High = Math.Max(result.High, grades[i]);
        //     result.Low = Math.Min(result.Low, grades[i]);
        //     result.Average += grades[i];   
        // }



        //jumping statements: 
        // break-break the flow and go to next line
        // continue-break that particular iteration and continue looping
        // goto label;
        // label: line 48
        #endregion
    }
}