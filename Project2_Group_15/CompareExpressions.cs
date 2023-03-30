using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project2_Group_15 {
    public class CompareExpressions : IComparer<double> {
        // compare the results from conversion process
        public int Compare(double result1, double result2) {
            return result1.CompareTo(result2);
        }
    }
}
