using Project2_Group_15.ConversionsProcesses;

namespace Project2_Group_15 {
    public class Prefix {
        // will contain conversion process from indix to prefix notation
        // (a-b) *c is represented as *-abc
        public List<string> ConvertToPrefix(List<string> InFix) {
            List<string> PreFix = new();

            // will be used to store operators and operands during conversion
            Stack<char> operators = new();
            Stack<string> operands = new();

            foreach (var expression in InFix) {
                // convert expression to prefix and add to convertedList
                for (int i = expression.Length - 1; i >= 0; i--) {
                    char c = expression[i];

                    if (Char.IsDigit(c)) {
                        // is operand
                        operands.Push(c.ToString());
                    } else if (c == ')') {
                        // push to stack
                        operators.Push(c);
                    } else if (c == '(') {
                        while (operators.Count > 0 && operators.Peek() != ')') {
                            string operand1 = operands.Pop();
                            string operand2 = operands.Pop();

                            char op = operators.Pop();

                            string tmp = op + operand1 + operand2;
                            operands.Push(tmp);
                        }
                        operators.Pop();
                    } else { // operator
                        while (operators.Count > 0 && Util.GetOperandPriority(c) < Util.GetOperandPriority(operators.Peek())) {
                            string operand1 = operands.Pop();
                            string operand2 = operands.Pop();

                            char op = operators.Pop();

                            string tmp = op + operand1 + operand2;
                            operands.Push(tmp);
                        }
                        operators.Push(c);
                    }
                }

                // add all remaining items on stack to output
                while (operators.Count() > 0) {
                    string op1 = operands.Pop();

                    string op2 = operands.Pop();

                    char op = operators.Pop();

                    string tmp = op + op1 + op2;
                    operands.Push(tmp);
                }

                PreFix.Add(operands.Pop());
            }

            return PreFix;
        }
    }
}
