using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDManagerSolution.Model
{
    public enum Expression
    {
        Addition,
        Subtraction,
        Division,
        Multiplication
    }

    public static class StringMath
    {
        public static string CalculateFromExpression(string expression)
        {
            // Find a delimiter
            Expression operationType = Expression.Subtraction;

            int positionOfOperator = 0;

            if (expression.Contains('+'))
            {
                positionOfOperator = expression.IndexOf('+');
                operationType = Expression.Addition;
            }
            else if (expression.Contains('-'))
            {
                positionOfOperator = expression.IndexOf('-');
            }

            string leftHandValue = expression.Substring(0, positionOfOperator);
            string rightHandValue = expression.Substring(positionOfOperator);

            leftHandValue = leftHandValue.Trim();
            rightHandValue = rightHandValue.Trim();

            int value1;
            int value2;

            int.TryParse(leftHandValue, out value1);
            int.TryParse(rightHandValue, out value2);

            switch(operationType)
            {
                case Expression.Addition:
                    return (value1 + value2).ToString();
                case Expression.Subtraction:
                    return (value1 + value2).ToString();
            }

            return string.Empty;
        }
    }
}
