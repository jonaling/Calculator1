using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator1
{
    public class NumberStock
    {
       
            private string[] nums;

        public NumberStock(string[] nums)
        {
            this.nums = nums;
           
        }

        public string[] Nums { get => nums; set => nums = value; }

        public int getLength() {

            return nums.Length;
        }
        
        
    }
}
