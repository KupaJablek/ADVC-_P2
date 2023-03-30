using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project2_Group_15 {
    internal class ExpressionEvaluation {
        // contain methods to implement the evaluation processes
        
        // delagates for operations -> will handle conversion to and from doubles for operations. Returns string
        private Func<string, string, string> add = (left, right) => (Double.Parse(left) + Double.Parse(right)).ToString();
        private Func<string, string, string> subtract = (left, right) => (Double.Parse(left) - Double.Parse(right)).ToString();
        private Func<string, string, string> multiply = (left, right) => (Double.Parse(left) * Double.Parse(right)).ToString();
        private Func<string, string, string> divide = (left, right) => (Double.Parse(left) / Double.Parse(right)).ToString();

        public string EvaluatePrefix(string expression) {

            Console.WriteLine(expression);

            Stack<string> operands = new();

            for (int i = expression.Length - 1; i >= 0; i--)
            {
                char c = expression[i];

                if (Char.IsDigit(c))
                {
                    // is operand push to stack
                    operands.Push(c.ToString());
                }
                else
                {
                    // is operator

                    // pop last two operands from stack
                    string operand1 = operands.Pop();
                    string operand2 = operands.Pop();

                    string result = "";

                    switch (c)
                    {
                        case '+':
                            result = add(operand1, operand2);
                            break;
                        case '-':
                            result = subtract(operand1, operand2);
                            break;
                        case '*':
                            result = multiply(operand1, operand2);
                            break;
                        case '/':
                            result = divide(operand1, operand2);
                            break;
                    }

                    operands.Push(result);
                }
            }
            return operands.Pop();
        }

        public string EvaluatePostfix(string expression) {
            Stack<string> operands = new();

            for (int i = 0; i < expression.Length; i++) { 
                char c = expression[i];

                if (Char.IsDigit(c)) {
                    // is operand push to stack
                    operands.Push(c.ToString());
                } else {
                    // is operator

                    // pop last two operands from stack
                    string operand2 = operands.Pop();
                    string operand1 = operands.Pop();

                    string result = "";

                    switch (c) {
                        case '+':
                            result = add(operand1, operand2);
                            break;
                        case '-':
                            result = subtract(operand1, operand2);
                            break;
                        case '*':
                            result = multiply(operand1, operand2);
                            break;
                        case '/':
                            result = divide(operand1, operand2);
                            break;
                    }

                    operands.Push(result);
                }
            }
            return operands.Pop();
        }
    }
}
