using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

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

            int total = Students.Count;
            int pos = total - Students.OrderByDescending(x => x.AverageGrade).SkipWhile(x => x.AverageGrade == averageGrade).Count();
            double porc = (pos * 100) / total;

            if (porc <= 20)
                return 'A';
            if (porc >= 20 && porc < 40)
                return 'B';
            if (porc >= 40 && porc < 60)
                return 'C';
            if (porc >= 60 && porc < 80)
                return 'D';
            return 'F';
        }
    }
}
