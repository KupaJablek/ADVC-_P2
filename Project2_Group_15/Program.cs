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

            foreach (string exp in postfix.ConvertToPostfix(firstList)) {
                Console.WriteLine(exp);
            }
        }
    }
}