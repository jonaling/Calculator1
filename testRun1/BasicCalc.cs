using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


namespace Calculator1
{
    [Serializable]
    public class BasicCalc
    {
        string[] nums, ops;
        
        int numLength, opsLength;
        
        Stack<String> opsStack, postfix;
        Regex rx = new Regex(@"[0-9]+\.?[0-9]*|\.[0-9]+", RegexOptions.Compiled);


        public BasicCalc(NumberStock numStock,OperationStock opStock, int numLength, int opsLength)
        {
            this.nums = numStock.Nums;
            this.ops = opStock.Ops;
            this.numLength = numLength;
            this.opsLength = opsLength;
            postfix = new Stack<string>();
            opsStack = new Stack<string>();
        }

        public double Solve() {

            
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
                if (CompareOps(ops[i]) && !ops[i].Equals("")) {
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

            
            return PolishNotation();

        }

        private Boolean CompareOps(string op) {
            if (opsStack.Count()>0 && OpPriority(op) >= OpPriority(opsStack.Peek())) {
                return true;
            }
            return false;
        }

        private int OpPriority(string op)
        {
            switch (op) {
                case "+":
                    return 1;
                case "-":
                    return 1;
                case "−":
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

        private Double operationSolve (string op,Double firstNum, Double secondNum) {
            switch (op) {
                case "+":
                    return Addition(firstNum,secondNum);
                case "-":
                    return Subtraction(firstNum,secondNum);
                case "−":
                    return Subtraction(firstNum, secondNum);
                case "*":
                    return Multiply(firstNum, secondNum);
                case "/":
                    return Divide(firstNum, secondNum);
                case "x":
                    return Multiply(firstNum, secondNum);
                default:
                    Console.WriteLine("solver did not recieve the correct sign");
                    return 1;

            }

        }

        private double PolishNotation() {

            Console.WriteLine("This is the stack:");
            Console.WriteLine("====");

            if ( postfix.Count < 1) {
                Console.WriteLine("Something went wrong");
                return 0;
            }

            string currObject = postfix.Pop();
            Double firstNum,secondNum;


            Console.WriteLine(currObject);

            if (rx.IsMatch(currObject))
            {
                return Double.Parse(currObject);
            }
            else
            {

                secondNum = PolishNotation();
                firstNum = PolishNotation();

                return operationSolve(currObject, firstNum, secondNum);



            }

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

        //subtraction
        private double Subtraction(string num1, string num2)
        {

            return Double.Parse(num1) - Double.Parse(num2);
        }

        private double Subtraction(string num1, double num2)
        {

            return Double.Parse(num1) - num2;
        }

        private double Subtraction(double num1, double num2)
        {

            return num1 - num2;
        }

        //multiplication
        public double Multiply(string num1, string num2)
        {

            return Double.Parse(num1) * Double.Parse(num2);
        }

        public double Multiply(string num1, double num2)
        {

            return Double.Parse(num1) * num2;
        }

        public double Multiply(double num1, double num2)
        {

            return num1 * num2;
        }

        //division
        public double Divide(string num1, string num2)
        {

            return Double.Parse(num1) / Double.Parse(num2);
        }

        public double Divide(string num1, int num2)
        {

            return Double.Parse(num1) / num2;
        }

        public double Divide(double num1, double num2)
        {

            return num1 / num2;
        }

    }
}
