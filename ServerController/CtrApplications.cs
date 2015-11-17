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
            //DateTime applicationDate = GetApplicationDate(studentId, flatId);
            //compare date and dat.now and return number of days ( -1 bacause it considers today and multiply by our ratio - score point to day (1 -24)

            return Convert.ToInt32(((DateTime.Now - date).TotalDays)-1)*24;
        }

        //private DateTime GetApplicationDate(int studentId, int flatId)
        //{
        //    ServerDatabase.DbApplications dbApplicationObj = new ServerDatabase.DbApplications();
        //    return Convert.ToDateTime(dbApplicationObj.GetDate(studentId, flatId));
        //}
    }
}
