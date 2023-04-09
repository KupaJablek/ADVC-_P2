using System.Numerics;
using System.Text.RegularExpressions;
using System.Xml;


namespace Project2_Group_15 {
    public class Program { 
        public static void Main(string[] args) {

            CSVFile csv = new();
            Postfix postfix = new();
            Prefix prefix = new();
            ExpressionEvaluation expEval = new();
            CompareExpressions compExp = new();

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

                string match = Match(postfixResults[i], prefixResults[i]);

                Console.WriteLine("|{0, 5}|{1,21}|{2,19}|{3,19}|{4,11}|{5,11}|{6,6}|", 
                    i + 1, firstList[i], postfixList[i], prefixList[i],
                    postfixResults[i], prefixResults[i], match);
            }
            Console.WriteLine("");
            Console.WriteLine("====================================================================================================");

            Console.WriteLine("\n\n");
            // main display is completed
            // generate and save an xml file in directory

            using (XmlWriter writer = XmlWriter.Create("../../../Data/ExpressionResults.xml")) {
                XMLExtension.WriteStartDocument(writer);

                XMLExtension.WriteStartRootElement(writer, "root");

                for(int i = 0; i < firstList.Count; i++) {
                    XMLExtension.WriteStartElement(writer, "element");
                    XMLExtension.WriteAttribute(writer, "sno", (i + 1).ToString());
                    XMLExtension.WriteAttribute(writer, "infix", firstList[i]);
                    XMLExtension.WriteAttribute(writer, "prefix", prefixList[i]);
                    XMLExtension.WriteAttribute(writer, "postfix", postfixList[i]);
                    XMLExtension.WriteAttribute(writer, "evaluation", postfixResults[i]);
                    string match = Match(postfixResults[i], prefixResults[i]);
                    XMLExtension.WriteAttribute(writer, "comparison", match);
                    XMLExtension.WriteEndElement(writer);
                }
                XMLExtension.WriteEndRootElement(writer);
                writer.WriteEndDocument();
                writer.Flush();
                writer.Close();
            }

            Console.WriteLine("Would you like to open the file in a browser (yes/no)?");
            var input = Console.ReadLine();
            while(input != "yes" && input != "no") {

                Console.WriteLine("Invalid entry enter yes or no");
                input = Console.ReadLine();
            
            }
            
            if (input == "yes")
            {
                string filePath = "../../../Data/ExpressionResults.xml";
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                {
                    FileName = "cmd",
                    Arguments = $"/c start \"\" \"{filePath}\"",
                    WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden,
                    CreateNoWindow = true,
                    UseShellExecute = false
                });
            }
            

            //else exit
            
        }

        public static string Match(string first, string second) {
            CompareExpressions compExp = new();
           return compExp.Compare(Double.Parse(first), Double.Parse(second)) == 0 ? "True" : "False";
        }
    }
}