namespace _26_11
{
    using System;

    public class Store
    {
        private readonly double _initialArea;
        public double Area { get; private set; }

        public Store(double area)
        {
            if (area < 0)
                throw new ArgumentException("Area cannot be negative.");

            _initialArea = area;
            Area = area;
        }

        public static Store operator +(Store store, double area)
        {
            if (area < 0)
                throw new ArgumentException("Cannot increase area by a negative number.");

            store.Area += area;
            return store;
        }

        public static Store operator -(Store store, double area)
        {
            if (area < 0)
                throw new ArgumentException("Cannot decrease area by a negative number.");

            if (store.Area - area < 0)
                throw new InvalidOperationException("Area cannot be negative.");

            store.Area -= area;
            return store;
        }

        public static bool operator ==(Store s1, Store s2)
        {
            const double tolerance = 0.0001;
            return Math.Abs(s1.Area - s2.Area) < tolerance;
        }

        public static bool operator !=(Store s1, Store s2)
        {
            const double tolerance = 0.0001;
            return Math.Abs(s1.Area - s2.Area) >= tolerance;
        }

        public static bool operator <(Store s1, Store s2)
        {
            return s1.Area < s2.Area;
        }

        public static bool operator >(Store s1, Store s2)
        {
            return s1.Area > s2.Area;
        }

        public override bool Equals(object? obj)
        {
            if (obj is Store otherStore)
            {
                const double tolerance = 0.0001;
                return Math.Abs(Area - otherStore.Area) < tolerance;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return Math.Round(_initialArea, 4).GetHashCode();
        }

        public override string ToString()
        {
            return $"Store with {Area} square meters.";
        }
    }
}
