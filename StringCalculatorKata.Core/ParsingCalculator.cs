using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculatorKata.Core
{
    public class ParsingCalculator
    {
        private List<String> expressionList;

        public Double Compute(String expression)
        {
            expressionList = ParseExpression(expression);

            var result = EvaluateExpression(expressionList);

            return result;
        }

        private Double EvaluateExpression(List<String> expressionList)
        {
            expressionList = PerformAnyMultiplication(expressionList);

            //expressionList = PerformAnyDivision(expressionList);

            if (expressionList.Count() < 2)
                return Convert.ToDouble(expressionList[0]);

            var result = PerformAnyAdditionAndSubtraction(expressionList);

            return result;
        }
        private static List<String> PerformAnyMultiplication(List<String> expressionList)
        {
            var location = expressionList.IndexOf("*");

            while (location != -1)
            {
                expressionList[location - 1] = MultiplyStrings(expressionList, location);

                expressionList.RemoveAt(location + 1);
                expressionList.RemoveAt(location);

                location = expressionList.IndexOf("*");
            }

            return expressionList;
        }

        private static String MultiplyStrings(List<String> expressionList, Int32 location)
        {
            return Convert.ToString(Convert.ToDouble(expressionList[location - 1]) * Convert.ToDouble(expressionList[location + 1]));
        }

        private static Double PerformAnyAdditionAndSubtraction(List<String> expressionList)
        {
            var results = Convert.ToDouble(expressionList[0]);

            while (expressionList.Count > 1)
            {
                if (expressionList[1].Equals("+"))
                    results += Convert.ToDouble(expressionList[2]);
                else if (expressionList[1].Equals("-"))
                    results += Convert.ToDouble(String.Format("{0}{1}", "-", expressionList[2]));

                expressionList.RemoveAt(2);
                expressionList.RemoveAt(1);
                expressionList[0] = Convert.ToString(results);
            }

            return results;
        }

        private List<String> ParseExpression(String expression)
        {
            var expressionList = new List<String>();

            var currentPart = new StringBuilder();

            foreach (var character in expression)
            {
                if (character.Equals('+') || character.Equals('-') || character.Equals('*') || character.Equals('/'))
                {
                    expressionList.Add(currentPart.ToString());
                    expressionList.Add(Convert.ToString(character));
                    currentPart.Clear();
                }
                else
                {
                    currentPart.Append(character);
                }
            }

            if (currentPart.Length > 0)
                expressionList.Add(currentPart.ToString());


            return expressionList;
        }
    }
}
