using ContractsApp.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ContractsApp.Models
{
    public class MinSalaryEntry
    {
        public MinSalaryEntry()
        {

        }
        public MinSalaryEntry(string level, JobPosition position, decimal salary)
        {
            Position = position;
            Salary = salary;
            MinSalaryEntryLevelName = level + " " + position.ToString();
        }

        public MinSalaryEntry SetUpperBound(int bound, bool inclusive = true)
        {
            UpperBound = bound;
            UpperBoundInclusive = inclusive;
            return this;
        }

        public MinSalaryEntry SetLowerBound(int bound, bool inclusive = true)
        {
            LowerBound = bound;
            LowerBoundInclusive = inclusive;
            return this;
        }

        [Key]
        public string MinSalaryEntryLevelName { get; set; }

        public JobPosition Position { get; set; }

        public int? LowerBound { get; set; }

        public bool LowerBoundInclusive { get; set; }

        public int? UpperBound { get; set; }

        public bool UpperBoundInclusive { get; set; }

        public decimal Salary { get; set; }

        public bool InRange(uint value)
        {
            return (!LowerBound.HasValue || LowerBound < value || (LowerBoundInclusive && LowerBound == value))
                && (!UpperBound.HasValue || value < UpperBound || (UpperBoundInclusive && UpperBound == value));
        }
        
    }
}