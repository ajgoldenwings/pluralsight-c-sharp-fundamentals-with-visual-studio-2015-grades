using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades
{
    public class GradeBook
    {
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                if (_name != value)
                {
                    NameChangedEventArgs args = new NameChangedEventArgs();
                    args.ExistingName = _name;
                    args.NewName = value;

                    NameChanged(this, args);
                }
                if (!String.IsNullOrEmpty(value))
                {
                    _name = value;
                }
            }
        }

        public GradeBook()
        {
            _name = "Name Unassigned";
            grades = new List<float>();
        }

        public GradeStatistics ComputeStatistics()
        {
            GradeStatistics stats = new GradeStatistics();

            float sum = 0;
            foreach(float grade in grades)
            {
                stats.HighestGrade = Math.Max(grade,stats.HighestGrade);
                stats.LowestGrade = Math.Min(grade,stats.LowestGrade);
                sum += grade;
            }
            stats.AverageGrade = sum / grades.Count();

            return stats;
        }

        public void AddGrade(float grade)
        {
            grades.Add(grade);
        }

        public event NameChangedDelegate NameChanged;

        private List<float> grades;
        private string _name;
    }
}
