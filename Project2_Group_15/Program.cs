namespace Project2_Group_15 {
    public class Program { 
        public static void Main(string[] args) {
            Console.WriteLine("Welcome to Group 15s' project");
            CSVFile csv = new();

            List<string> firstList = csv.CSVDeserialize();

            //foreach (string s in firstList) {
            //    Console.WriteLine(s);
            //}

            Postfix postfix = new();
            Prefix prefix = new();

            ExpressionEvaluation expEval = new();

            //foreach (string exp in postfix.ConvertToPostfix(firstList)) {
            //    Console.WriteLine(expEval.EvaluatePostfix(exp));
            //}

            foreach (string exp in prefix.ConvertToPrefix(firstList))
            {
                Console.WriteLine(expEval.EvaluatePrefix(exp));
            }
        }
    }
}