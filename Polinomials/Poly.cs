using System;
using System.Collections;
using System.Text;

namespace Polinomials
{
    public class Poly : IEnumerable, ICloneable
    {
        private readonly double eps = 0.0000001;
        private Dictionary<int, double> DegreeCoeff = new Dictionary<int, double>();

        public Poly() { }
        public Poly((double, int)[] table)
        {
            foreach (var row in table)
            {
                this[row.Item2] = row.Item1;
            }
        }

        public bool ContainsKey(int key) => DegreeCoeff.ContainsKey(key);

        public double this[int index]
        {
            get { return DegreeCoeff[index]; }
            set
            {
                if (DegreeCoeff.ContainsKey(index))
                {
                    DegreeCoeff[index] = value;
                }

                else
                {
                    DegreeCoeff.Add(index, value);
                }

                if (DegreeCoeff[index] < eps)
                {
                    DegreeCoeff.Remove(index);
                }
            }
        }

        public void Add(double coeff, int degree) => DegreeCoeff.Add(degree, coeff);
        public void AddOrCoeffSum(double coeff, int degree)
        {
            if (DegreeCoeff.ContainsKey(degree))
            {
                DegreeCoeff[degree] += coeff;
            }
            else
            {
                DegreeCoeff.Add(degree, coeff);
            }

            if (DegreeCoeff[degree] < eps)
            {
                DegreeCoeff.Remove(degree);
            }
        }

        public int MaxDegree => DegreeCoeff.Max(x => x.Key);

        public int Count => DegreeCoeff.Count;

        public IEnumerator<KeyValuePair<int, double>> GetEnumerator()
        {
            return DegreeCoeff.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            foreach (var item in DegreeCoeff.OrderByDescending(x => x.Key))
            {
                stringBuilder.AppendLine($"{item.Value} {item.Key}");
            }

            return stringBuilder.ToString();
        }

        public Poly Clone()
        {
            Poly p = new Poly();
            foreach (var item in this)
            {
                p[item.Key] = item.Value;
            }
            return p;
        }

        object ICloneable.Clone() => Clone();

        public override bool Equals(object? obj)
        {
            if (obj is Poly p)
            {
                return DegreeCoeff.SequenceEqual(p.DegreeCoeff);
            }

            return false;
        }

        public override int GetHashCode()
        {
            return DegreeCoeff.GetHashCode();
        }
    }
}
