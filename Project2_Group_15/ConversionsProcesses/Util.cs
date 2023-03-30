using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project2_Group_15.ConversionsProcesses {
    public static class Util {
        public static int GetOperandPriority(char operand) {
            switch (operand) {
                case '+':
                case '-':
                    return 1;
                case '*':
                case '/':
                    return 2;
                default: 
                    return -1;
            }
        }
    }
}
