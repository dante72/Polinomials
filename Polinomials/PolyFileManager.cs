using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polinomials
{
    public class PolyFileManager
    {
        public static Poly[] ReadFile(string path)
        {
            string[] lines = File.ReadAllLines(path);
            var polynomials = new List<Poly>();
            var currentPolynomial = new Poly();
            polynomials.Add(currentPolynomial);

            foreach (string line in lines)
            {
                if (line == string.Empty)
                {
                    currentPolynomial = new Poly();
                    polynomials.Add(currentPolynomial);
                    continue;
                }
                var coeffDegree = GetCoeffAndDegree(line);
                currentPolynomial.AddOrCoeffSum(coeffDegree.Item1, coeffDegree.Item2);
            }

            return polynomials.ToArray();
        }

        static (double, int) GetCoeffAndDegree(string line)
        {
            string[] words = line.Split(' ');
            double coeff = double.Parse(words[0]);
            int degree = int.Parse(words[1]);
            return (coeff, degree);
        }
    }
}
