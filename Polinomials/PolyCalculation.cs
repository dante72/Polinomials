using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polinomials
{
    public class PolyCalculation
    {
        public static Poly Mult(Poly p1, Poly p2)
        {
            var result = new Poly();
            foreach (var it1 in p1)
            {
                foreach (var it2 in p2)
                {
                    result.AddOrCoeffSum(it1.Value * it2.Value, it1.Key + it2.Key);
                }
            }

            return result;
        }

        public static Poly[] Div(Poly divisible, Poly divider)
        {
            var remainderOfDiv = divisible.Clone();
            var result = new Poly();
            foreach (var step in DivSteps(remainderOfDiv, divider))
            {
                result.Add(step[step.MaxDegree], step.MaxDegree);
            }

            return [result, remainderOfDiv];
        }

        private static IEnumerable<Poly> DivSteps(Poly divisible, Poly divider)
        {
            while (!DivisionIsCompleted(divisible, divider))
            {
                Poly maxDegree = GetMaxDegree(divisible, divider);
                Subtraction(divisible, Mult(maxDegree, divider));
                yield return maxDegree;
            }
        }
        private static bool DivisionIsCompleted(Poly divisible, Poly divider)
        {
            return divisible.Count == 0 || divisible.MaxDegree < divider.MaxDegree;
        }
        public static void Subtraction(Poly p1, Poly p2)
        {
            //Poly result = p1.Clone();
            foreach (var it1 in p2)
            {
                p1.AddOrCoeffSum(-it1.Value, it1.Key);
            }

            //return result;
        }


        private static Poly GetMaxDegree(Poly divisible, Poly divider)
        {
            return new Poly([(divisible[divisible.MaxDegree] / divider[divider.MaxDegree], divisible.MaxDegree - divider.MaxDegree)]);
        }
    }
}
