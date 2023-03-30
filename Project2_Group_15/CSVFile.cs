using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project2_Group_15 {
    public class CSVFile {

        // dump contents of csv into list
        public List<string> CSVDeserialize() {
            List<string> inFix = new List<string>();

            using (StreamReader sr = new StreamReader("../../../Data/" + "Project 2_INFO_5101.csv")) {

                string line = sr.ReadLine(); // skip header
                while ((line = sr.ReadLine()) != null) {
                    string[] data = line.Split(",");
                    inFix.Add(data[1]);
                }
            }
            return inFix;
        }
    }
}
