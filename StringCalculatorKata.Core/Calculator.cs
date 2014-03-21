using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculatorKata.Core
{
    public class Calculator
    {
        public Double Compute(String expression)
        {
            if (expression.Contains('*'))
                return Multiply(expression);

            var results = Add(expression);

            return results;
        }

        private static Double Add(String expression)
        {
            var results = 0.0;

            foreach (var number in expression.Split('+'))
                results += Subtract(number);

            return results;
        }

        private static Double Subtract(String expression)
        {
            var numbers = expression.Split('-');
            var results = Convert.ToDouble(numbers[0]);
            
            for (var index = 1; index < numbers.Count(); index++)
                results += Convert.ToDouble(String.Format("{0}{1}", "-", numbers[index]));

            return results;
        }

        private static Double Multiply(String expression)
        {
            var results = 1.0;

            foreach (var number in expression.Split('*'))
                results *= Convert.ToDouble(number);

            return results;
        }
    }
}
