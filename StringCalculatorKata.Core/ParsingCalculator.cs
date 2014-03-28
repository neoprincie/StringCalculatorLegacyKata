using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculatorKata.Core
{
    public class ParsingCalculator
    {
        private const String ADD = "+";
        private const String DIVIDE = "/";
        private const String SUBTRACT = "-";
        private const String MULTIPLY = "*";
        private const String MODULUS = "%";
        private List<String> expressionList = new List<String>();

        public Double Compute(String expression)
        {
            expressionList = ParseExpression(expression);

            return EvaluateExpression();
        }

        private Double EvaluateExpression()
        {
            PerformSpecifiedOperation(MULTIPLY);
            PerformSpecifiedOperation(DIVIDE);
            PerformSpecifiedOperation(MODULUS);

            if (expressionList.Count() == 1)
                return Convert.ToDouble(expressionList[0]);

            return PerformAnyAdditionAndSubtraction(expressionList);
        }

        private void PerformSpecifiedOperation(String operation)
        {
            var location = expressionList.IndexOf(operation);

            while (location != -1)
            {
                expressionList[location - 1] = InvokeOperation(expressionList, location, operation);

                expressionList.RemoveAt(location + 1);
                expressionList.RemoveAt(location);

                location = expressionList.IndexOf(operation);
            }
        }

        private String InvokeOperation(List<String> expressionList, Int32 location, String operation)
        {
            if (operation == DIVIDE)
                return Convert.ToString(Convert.ToDouble(expressionList[location - 1]) / Convert.ToDouble(expressionList[location + 1]));
            else if (operation == MULTIPLY)
                return Convert.ToString(Convert.ToDouble(expressionList[location - 1]) * Convert.ToDouble(expressionList[location + 1]));
            else
                return Convert.ToString(Convert.ToDouble(expressionList[location - 1]) % Convert.ToDouble(expressionList[location + 1]));
        }

        private Double PerformAnyAdditionAndSubtraction(List<String> expressionList)
        {
            var results = Convert.ToDouble(expressionList[0]);

            while (expressionList.Count > 1)
            {
                if (expressionList[1].Equals(ADD))
                    results += Convert.ToDouble(expressionList[2]);
                else if (expressionList[1].Equals(SUBTRACT))
                    results -= Convert.ToDouble(expressionList[2]);

                expressionList.RemoveAt(2);
                expressionList.RemoveAt(1);
                expressionList[0] = Convert.ToString(results);
            }

            return results;
        }

        private List<String> ParseExpression(String expression)
        {
            var currentPart = new StringBuilder();
            expressionList = new List<String>();

            for (var i = 0; i < expression.Length; i++)
            {
                if (IsOperator(expression, i))
                {
                    if (IsOperator(expression, i - 1))
                        currentPart.Append(expression[i]);
                    else
                    {
                        expressionList.Add(currentPart.ToString());
                        expressionList.Add(Convert.ToString(expression[i]));
                        currentPart.Clear();
                    }
                }
                else
                {
                    currentPart.Append(expression[i]);
                }
            }

            if (currentPart.Length > 0)
                expressionList.Add(currentPart.ToString());

            return expressionList;
        }

        private static bool IsOperator(String expression, Int32 i)
        {
            return expression[i].Equals(Convert.ToChar(ADD)) ||
                                expression[i].Equals(Convert.ToChar(SUBTRACT)) ||
                                expression[i].Equals(Convert.ToChar(MULTIPLY)) ||
                                expression[i].Equals(Convert.ToChar(DIVIDE)) ||
                                expression[i].Equals(Convert.ToChar(MODULUS));
        }
    }
}
