using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Methods
{
    class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string OtherInfo { get; set; }

        public bool IsOlderThan(Student other)
        {
            Match firstDateMatch = Regex.Match(this.OtherInfo, @"(\d+(\.|\\|\:)\d+(\.|\\|\:)\d+)");
            DateTime firstDate = DateTime.Parse(firstDateMatch.Groups[1].Value, new CultureInfo("bg-BG"));
            Match secondDateMatch = Regex.Match(other.OtherInfo, @"(\d+(\.|\\|\:)\d+(\.|\\|\:)\d+)");
            DateTime secondDate = DateTime.Parse(secondDateMatch.Groups[1].Value, new CultureInfo("bg-BG"));
            return firstDate > secondDate;
        }
    }
}
