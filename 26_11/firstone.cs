namespace _26_11
{
    using System;

    public class Journal
    {
        public int EmployeesCount { get; private set; }
        private readonly int _initialEmployeesCount;

        public Journal(int initialEmployeesCount)
        {
            if (initialEmployeesCount < 0)
                throw new ArgumentException("Employee count cannot be negative.");
            
            _initialEmployeesCount = initialEmployeesCount;
            EmployeesCount = initialEmployeesCount;
        }

        public static Journal operator +(Journal journal, int count)
        {
            if (count < 0)
                throw new ArgumentException("Cannot increase employees by a negative number.");

            journal.EmployeesCount += count;
            return journal;
        }

        public static Journal operator -(Journal journal, int count)
        {
            if (count < 0)
                throw new ArgumentException("Cannot decrease employees by a negative number.");

            if (journal.EmployeesCount - count < 0)
                throw new InvalidOperationException("Employee count cannot be negative.");

            journal.EmployeesCount -= count;
            return journal;
        }

        public static bool operator ==(Journal j1, Journal j2)
        {
            return j1.EmployeesCount == j2.EmployeesCount;
        }

        public static bool operator !=(Journal j1, Journal j2)
        {
            return j1.EmployeesCount != j2.EmployeesCount;
        }

        public static bool operator <(Journal j1, Journal j2)
        {
            return j1.EmployeesCount < j2.EmployeesCount;
        }

        public static bool operator >(Journal j1, Journal j2)
        {
            return j1.EmployeesCount > j2.EmployeesCount;
        }

       public override bool Equals(object? obj)
        {
            if (obj is Journal)
            {
                return EmployeesCount == ((Journal)obj).EmployeesCount;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return _initialEmployeesCount.GetHashCode();
        }

        public override string ToString()
        {
            return $"Journal with {EmployeesCount} employees.";
        }
    }
}
