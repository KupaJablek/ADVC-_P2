using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project2_Group_15 {
    public class CompareExpressions : IComparer<int> {
        // compare the results from conversion process
        public int Compare(int result1, int result2) {
            return result1.CompareTo(result2);
        }
    }
}
