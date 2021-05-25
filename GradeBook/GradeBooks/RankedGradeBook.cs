using System;

using System.Text;
using System.Linq;
using System.Collections.Generic;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook: BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
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
    }
}
