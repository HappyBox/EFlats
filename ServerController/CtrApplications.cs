using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerController
{
    public class CtrApplications
    {
        public static int CalculateScoreDate(DateTime date)
        {
            return Convert.ToInt32(((DateTime.Now - date).TotalDays)-1)*24;
        }

        public static int SumScores(int scoreDate, int profileScore)
        {
            return scoreDate + profileScore;
        }
    }
}
