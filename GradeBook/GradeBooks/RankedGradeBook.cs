using System;
using System.Collections.Generic;
using System.Text;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
        {
            Type = Enums.GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5)
            {
                throw new InvalidOperationException();
            }

            //here
            //create an array of average scores by iterating through Students, 
            //the List of student objects.

            double[] avgGrades = new double[Students.Count];

            for  (int i = 0; i <= Students.Count; i++)
            {
                avgGrades[i] = Students[i].AverageGrade;
            }

            Array.Sort(avgGrades);
            Array.Reverse(avgGrades, 0, Students.Count);
            var x = (Students.Count / 5) - 1;    //needed to account for zero index?  OK?????


            if (averageGrade >= avgGrades[x])
            {
                return 'A';
            }


            //x = top 20% = A
            //x * 2 = top 40% = B
            //x * 3 = top 60% = C


            return 'F';
        }
    }
}
