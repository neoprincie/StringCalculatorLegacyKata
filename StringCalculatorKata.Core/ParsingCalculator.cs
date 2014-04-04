using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StringCalculatorKata.Core
{
    public class ParsingCalculator
    {
        private const String ADD = "+";
        private const String DIVIDE = "/";
        private const String SUBTRACT = "-";
        private const String MULTIPLY = "*";
        private const String MODULUS = "%";
        private const String EXPONENT = "^";
        private const String DICEROll = "d";
        private List<String> operations = new List<String> { DICEROll, EXPONENT, MODULUS, DIVIDE, MULTIPLY, ADD, SUBTRACT };
        private List<String> expressionList = new List<String>();

        public Double Compute(String expression)
        {
            expressionList = ParseExpression(expression);

            return EvaluateExpression();
        }

        private List<String> ParseExpression(String expression)
        {
            var currentNumber = new StringBuilder();
            expressionList = new List<String>();

            for (var i = 0; i < expression.Length; i++)
            {
                if (IsSingleOperator(expression, i))
                {
                    expressionList.Add(Convert.ToString(currentNumber));
                    expressionList.Add(Convert.ToString(expression[i]));
                    currentNumber.Clear();
                }
                else
                {
                    currentNumber.Append(expression[i]);
                }
            }

            if (currentNumber.Length > 0)
                expressionList.Add(currentNumber.ToString());

            return expressionList;
        }
        
        private Boolean IsSingleOperator(String expression, Int32 i)
        {
            return IsOperator(expression[i]) && !IsOperator(expression[i - 1]);
        }
        
        private Double EvaluateExpression()
        {
            foreach (var operation in operations)
                PerformSpecifiedOperation(operation);

            return Convert.ToDouble(expressionList[0]);
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
            var leftOperand = Convert.ToDouble(expressionList[location - 1]);
            var rightOperand = Convert.ToDouble(expressionList[location + 1]);

            if (operation == DICEROll)
                return RollDice(leftOperand, rightOperand);
            if (operation == EXPONENT)
                return Convert.ToString(Math.Pow(leftOperand, rightOperand));
            if (operation == DIVIDE)
                return Convert.ToString(leftOperand / rightOperand);
            if (operation == MULTIPLY)
                return Convert.ToString(leftOperand * rightOperand);
            if (operation == MODULUS)
                return Convert.ToString(leftOperand % rightOperand);
            if (operation == ADD)
                return Convert.ToString(leftOperand + rightOperand);

            return Convert.ToString(leftOperand - rightOperand);

        }

        private String RollDice(Double leftOperand, Double rightOperand)
        {
            var random = new Random();
            var counter = 0;

            for (int i = 0; i < leftOperand; i++)
                counter += random.Next(1, (Int32)rightOperand);

            return Convert.ToString(counter);

        }

        private Boolean IsOperator(Char expression)
        {
            return expression.Equals(Convert.ToChar(ADD)) ||
                        expression.Equals(Convert.ToChar(SUBTRACT)) ||
                        expression.Equals(Convert.ToChar(MULTIPLY)) ||
                        expression.Equals(Convert.ToChar(DIVIDE)) ||
                        expression.Equals(Convert.ToChar(MODULUS)) ||
                        expression.Equals(Convert.ToChar(EXPONENT)) || 
                        expression.Equals(Convert.ToChar(DICEROll));
        }
    }
}
