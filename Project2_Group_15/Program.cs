namespace Project2_Group_15 {
    public class Program { 
        public static void Main(string[] args) {

            CSVFile csv = new();
            Postfix postfix = new();
            Prefix prefix = new();
            ExpressionEvaluation expEval = new();

            List<string> firstList = csv.CSVDeserialize();


            // converted expression lists
            List<string> postfixList = postfix.ConvertToPostfix(firstList);
            List<string> prefixList = prefix.ConvertToPrefix(firstList);

            // result lists
            List<string> postfixResults = new();
            List<string> prefixResults = new();

            // populate the results lists
            foreach (string exp in postfixList) {
                postfixResults.Add(expEval.EvaluatePostfix(exp));
            }

            foreach (string exp in prefix.ConvertToPrefix(firstList)) {
                prefixResults.Add(expEval.EvaluatePrefix(exp));
            }

            Console.WriteLine("Welcome to Project 2 by Group 15\n");

            Console.WriteLine("====================================================================================================");
            Console.WriteLine("*                                      Summary  Report                                             *");
            Console.WriteLine("====================================================================================================");

            Console.WriteLine("");

            // formatted output for each expression at all stages
            Console.WriteLine("|{0, 5}|{1,21}|{2,19}|{3,19}|{4,11}|{5,11}|{6,6}|", "Sno", "Infix", "Postfix", "Prefix", "Postfix Res", "Prefix Res", "Match");
            Console.WriteLine("====================================================================================================");

            for (int i = 0; i < firstList.Count(); i++) {

                string match = postfixResults[i].CompareTo(prefixResults[i]) == 1 ? "True" : "False"; 

                Console.WriteLine("|{0, 5}|{1,21}|{2,19}|{3,19}|{4,11}|{5,11}|{6,6}|", 
                    i + 1, firstList[i], postfixList[i], prefixList[i],
                    postfixResults[i], prefixResults[i], match);
            }
            Console.WriteLine("");
            Console.WriteLine("====================================================================================================");
        }
    }
}