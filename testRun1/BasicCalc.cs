using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Calculator1
{
    public class BasicCalc
    {
        string[] nums, ops;
        
        int numLength, opsLength;
        Queue<Double> numQueue;
        Queue<String> opsQueue;
        Stack<String> opsStack, postfix;
        

        public BasicCalc(NumberStock numStock,OperationStock opStock, int numLength, int opsLength)
        {
            this.nums = numStock.Nums;
            this.ops = opStock.Ops;
            this.numLength = numLength;
            this.opsLength = opsLength;
            postfix = new Stack<string>();
            opsStack = new Stack<string>();
        }

        public double solve() {

            
            if (opsLength < 1) {
                return Double.Parse(nums[0]);
            }
            int i = 0;
            while (i < opsLength) {
                if (ops[i].Equals(""))
                {
                    if (numLength - 1 > i)
                    {
                        Console.WriteLine("nums[i]: " + nums[i]);
                        postfix.Push(nums[i]);
                    }

                } else
                if (compareOps(ops[i]) && !ops[i].Equals("")) {
                    postfix.Push(nums[i]);
                    opsStack.Push(ops[i]);
                } else {
                    for (int j = 0; j < opsStack.Count; j++) {
                        postfix.Push(opsStack.Pop());
                    }
                    postfix.Push(nums[i]);
                    opsStack.Push(ops[i]);
                }
                i++;
            }

            while (i < numLength)
            {
                postfix.Push(nums[i]);
                i++;
            }

            while (opsStack.Count() > 0) {
                postfix.Push(opsStack.Pop());
            }

            Console.WriteLine("This is the stack:");
            Console.WriteLine("====");
            while (postfix.Count() > 0) {
                Console.WriteLine(postfix.Pop());
            }
            Console.WriteLine("====");
            return 1.0;

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

      /*  private double PolishNotation(Stack<string> opsStack,) {
            
        }*/

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
