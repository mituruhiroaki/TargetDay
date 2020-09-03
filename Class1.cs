using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;

namespace TargetDay{
    public class Class1 {

        #region<クラスフィールド>
        private static int Year = DateTime.Now.Year;
        private static CultureInfo culture = CultureInfo.GetCultureInfo("en-US");
        #endregion


        #region<ファンクション>
        public static Func<int, int, string, int> targetDay = (month, dainann, youbi) => {

            int MonthDays = DateTime.DaysInMonth(Year, month);

            for(int days = 1, count = 1; days <= MonthDays; days++) {
                var forDay = new DateTime(Year, month, days);
                if(forDay.ToString("ddd", culture) == youbi ) {
                    count++;
                }
                if(count == 1) {
                    continue;
                } else if (count <= dainann) {
                    days += 6;
                    continue;
                } else {
                    return days;
                }
            }

            return -1;

        };


        public static Func<int, int, int, string, IEnumerable<int>> targetDayLIst = (startMonth, countMonth, dainann, youbi) => {

            var list = new List<int>();

            for(int c = 0; c < countMonth; c++, startMonth++) {
                if(startMonth > 12) { Year++; startMonth = 1; }
                list.Add(targetDay(startMonth, dainann, youbi));
            }

            IEnumerable<int> result = list;

            return result;
        };

        #endregion 

    }
}
