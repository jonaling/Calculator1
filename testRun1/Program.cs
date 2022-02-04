using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using Calculator1;


namespace testRun1
{
    class Program
    {
        
        static void Main(string[] args) { 
            string line;
            var rx = new Regex(@"[0-9]+\.?[0-9]*|\.[0-9]+", RegexOptions.Compiled);

            Console.WriteLine("Hello, Welcome to the calculator. Please type in your equation:");
            line = Console.ReadLine();
            line = Regex.Replace(line, @"\s", "");
            

           
            if (Validation(line)) {
                line = NumberPad(line);
                NumberStock numStock = new NumberStock( line.Split(new Char[] { '+','-','/','*','x'}));
                OperationStock opStock =new OperationStock( rx.Split(line));
                /*   
                Console.WriteLine("numStock index 0: "+numStock.Nums[0]);
                Console.WriteLine("numStock length: "+ numStock.GetLength());
                Console.WriteLine("opStock length: " + opStock.GetLength());
                Console.WriteLine("opStock index 1: "+opStock.Ops[1]);
                */

                BasicCalc toSolve = new BasicCalc(numStock, opStock, numStock.GetLength(), opStock.GetLength());
                
                Console.WriteLine(toSolve.Solve());

            }

            Console.ReadLine();
        }

        public static Boolean Validation(string line){ 
            if(line.Length < 1)
            {
                Console.WriteLine("Please enter an input.");
                return false;
            }

            if ( !line.StartsWith("-") && ! Char.IsNumber(line,0) ) {
                
                Console.WriteLine("Please do not start with an invalid operator");
                return false;
            }
            return true;
        }

        public static String NumberPad(String line) {
            if (!Char.IsNumber(line, 0)) {
                return "0" + line;
            }

            return line;
        }

   
}
}
