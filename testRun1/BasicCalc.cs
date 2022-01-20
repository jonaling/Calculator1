using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Calculator1
{
    public class BasicCalc
    {
        private string[] nums, ops;
        
        int numLength, opsLength;
        Queue<Double> numQueue;
        Queue<string> opsQueue;
        Stack<string> opsStack, postfix;
        

        public BasicCalc(string[] nums,string[]ops, int numLength, int opsLength)
        {
            this.nums = nums;
            this.ops = ops;
            this.numLength = numLength;
            this.opsLength = opsLength;
        }

        public double solve() {
            if (opsLength < 1) {
                return Double.Parse(nums[0]);
            }
            int queuelength = opsLength;

            for (int i = 0;i<queuelength;i++) {
                if (ops[i].Equals(""))
                {
                    postfix.Push(nums[i]);

                } else
                if (compareOps(ops[i]) && !ops[i].Equals("")) {
                    postfix.Push(nums[i]);
                    opsStack.Push(ops[i]);
                } else  {
                    for (int j = 0; j < opsStack.Count; j++) {
                        postfix.Push(opsStack.Pop());
                    }
                    postfix.Push(nums[i]);
                    opsStack.Push(ops[i]);
                }
            }

        
        }

        private Boolean compareOps(string op) {
            if (opsStack.Count()>0 && opPriority(op) >= opPriority(opsStack.Peek())) {
                return true;
            }
            return false;
        }

        private int opPriority(string op)
        {
            switch (op) {
                case "+":
                    return 1;
                case "-":
                    return 1;
                case "*":
                    return 2;
                case "/":
                    return 2;
                case "x":
                    return 2;
                case "":
                    return 1;
                default:
                    return 1;
            
            }
        }

        private double PolishNotation() {
            
        }

        //addition
        private double Addition(string num1, string num2)
        {

            return Double.Parse(num1) + Double.Parse(num2);
        }

        private double Addition(string num1, double num2)
        {

            return Double.Parse(num1) + num2;
        }

        private double Addition(double num1, double num2)
        {

            return num1 + num2;
        }



        //multiplication
        public double multiply(string num1, string num2)
        {

            return Double.Parse(num1) * Double.Parse(num2);
        }

        public double multiply(string num1, double num2)
        {

            return Double.Parse(num1) * num2;
        }

        public double multiply(double num1, double num2)
        {

            return num1 * num2;
        }

        //division
        public double divide(string num1, string num2)
        {

            return Double.Parse(num1) / Double.Parse(num2);
        }

        public double divide(string num1, int num2)
        {

            return Double.Parse(num1) / num2;
        }

        public double divide(double num1, double num2)
        {

            return num1 / num2;
        }

    }
}
