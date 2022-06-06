using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DefiningClasses
{
    public class DateModifier
    {
        public DateModifier()
        {

        }

        public int TimeDifferenceInDays { get; set; }

        public void SetTimeDifferenceInDays(string firstDate, string secondDate)
        {
            int[] splittedFirstDate = firstDate.Split(' ').Select(int.Parse).ToArray();

            DateTime firstDateTime = new DateTime(splittedFirstDate[0], splittedFirstDate[1], splittedFirstDate[2]);

            int[] splittedSecondtDate = secondDate.Split(' ').Select(int.Parse).ToArray();

            DateTime secondDateTime = new DateTime(splittedSecondtDate[0], splittedSecondtDate[1], splittedSecondtDate[2]);

            TimeDifferenceInDays = (int)Math.Abs((secondDateTime - firstDateTime).TotalDays);
        }
    }
}
