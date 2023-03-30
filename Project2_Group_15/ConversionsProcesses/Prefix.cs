using Project2_Group_15.ConversionsProcesses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Project2_Group_15 {
    public class Prefix {
        // will contain conversion process from indix to prefix notation
        // (a-b) *c is represented as *-abc
        public List<string> ConvertToPrefix(List<string> InFix) { 
            List<string> PreFix = new List<string>();
            /*foreach (string ex in InFix) {
                char[] reverseEx = ex.Reverse();

                string prefixExp = "";
                Stack<char> operatorStack = new();

                for (int i = 0; i < reverseEx.Count(); i++) {
                     char c = reverseEx[i];
                // if operand add to prefix expression
                    if(Char.IsDigit(c)) {
                        prefixExp += c;
                    }
                // if operator and operator stack empty,
                // push to operator stack
                    else if (operatorStack.Count <= 0) {
                        operatorStack.Push(c);
                    }
                // operator stack is not empty
                    else {

                    }
                }
            }*/
            
            foreach (string expression in InFix) {
                // convert expression to prefix and add to convertedList
                
                Stack<char> operators = new Stack<char>();
                Stack<string> operands = new Stack<string>();

                char[] exp = expression.Reverse().ToArray();

                for (int i = 0; i < exp.Length; i++) {
                    char c = exp[i];

                    if (c == '(') {
                        operators.Push(c);
                    } else if (c == '(') {
                        while (operators.Count > 0 &&
                        operators.Peek() != ')') {

                            string operand1 = operands.Peek();
                            operands.Pop();

                            string operand2 = operands.Peek();
                            operands.Pop();

                            char op = operators.Peek();
                            operators.Pop();

                            // Add operands and operator
                            // in form operator +
                            // operand1 + operand2.
                            string tmp = op + operand1 + operand2;
                            operands.Push(tmp);
                        }
                        operators.Push(c);
                    } else if (Char.IsDigit(c)) {
                        operands.Push(c + "");
                    } else {
                        while (operators.Count > 0 &&
                            Util.GetOperandPriority(operators.Peek()) <=
                            Util.GetOperandPriority(c)) {
                            string op1 = operands.Peek();
                            operands.Pop();

                            string op2 = operands.Peek();
                            operands.Pop();

                            char op = operators.Peek();
                            operators.Pop();

                            string tmp = op + op2 + op1;
                            operands.Push(tmp);
                        }
                        operators.Push(c);
                    }

                    while (operators.Count() > 0) {
                        string op1 = operands.Peek();
                        operands.Pop();

                        string op2 = operands.Peek();
                        operands.Pop();

                        char op = operators.Peek();
                        operators.Pop();

                        string tmp = op + op2 + op1;
                        operands.Push(tmp);
                    }

                    PreFix.Add(operands.Peek());
                }
            }

            return PreFix;
        }
    }
}
