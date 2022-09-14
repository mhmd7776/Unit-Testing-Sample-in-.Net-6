using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculateLayer
{
    public class GradeCalculator
    {
        public GradeType CalculateGrade(int score, int attendancePercentage)
        {
            return score switch
            {
                >= 90 when attendancePercentage >= 70 => GradeType.A,
                >= 70 when attendancePercentage >= 60 => GradeType.B,
                >= 50 when attendancePercentage >= 50 => GradeType.C,
                _ => GradeType.F
            };
        }
    }

    public enum GradeType
    {
        A,
        B,
        C,
        F
    }
}
