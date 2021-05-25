using System;

using System.Text;
using System.Linq;
using System.Collections.Generic;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook: BaseGradeBook
    {
        public RankedGradeBook(string name, bool isWeighted) : base(name, isWeighted)
        {
            Type = Enums.GradeBookType.Ranked;
        }
        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count > 5)
            {
                throw new InvalidOperationException();

            }

            var threshold = (int)Math.Ceiling(Students.Count * 0.2);
            var grades = Students.OrderByDescending(x => x.AverageGrade).Select(e => e.AverageGrade).ToList();
            
            if(averageGrade >= grades[threshold-1])
                return 'A';
            if (averageGrade < grades[threshold - 1] && averageGrade >= grades[threshold * 2 - 1])
                return 'B';
            if (averageGrade < grades[threshold * 2 - 1] && averageGrade >= grades[threshold * 3 - 1])
                return 'C';
            if (averageGrade < grades[threshold * 3 - 1] && averageGrade >= grades[threshold * 4 - 1])
                return 'D';
            return 'F';
        }

        public override void CalculateStatistics()
        {
            if (Students.Count < 5)
            {
                Console.Write("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
                return;
            }
            else
            {
                base.CalculateStatistics();
            }
        }
        public override void CalculateStudentStatistics(string name)
        {
            if(Students.Count < 5)
            {
                Console.Write("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
                return;
            }
            else
            {
                base.CalculateStudentStatistics(name);
            }

        }
    }
}
