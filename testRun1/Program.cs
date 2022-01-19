using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

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
            Console.WriteLine(line);
           
            if (line != null) {
                string[] numArray = line.Split(new Char[] { '+','-','/','*','x'});
                string[] opArray = rx.Split(line);

                Console.WriteLine(numArray[0]);
                Console.WriteLine(opArray.Length);
                Console.WriteLine(opArray[1]);
            }

            Console.ReadLine();
        }

        public void validation(string line){ 
            if(line.Length < 1)
            {

            }

        }


    //addition
    public double addition(string num1, string num2)
    {

        return Double.Parse(num1) + Double.Parse(num2);
    }

    public double addition(int num1, int num2)
    {

        return Convert.ToDouble(num1) + Convert.ToDouble(num2);
    }

    public double addition(double num1, double num2)
    {

        return num1 + num2;
    }

    //subtraction
    public double subtraction(string num1, string num2)
    {

        return Double.Parse(num1) - Double.Parse(num2);
    }

    public double subtraction(int num1, int num2)
    {

        return Convert.ToDouble(num1) - Convert.ToDouble(num2);
    }

    public double subtraction(double num1, double num2)
    {

        return num1 - num2;
    }


    //multiplication
    public double multiply(string num1, string num2)
    {

        return Double.Parse(num1) * Double.Parse(num2);
    }

    public double multiply(int num1, int num2)
    {

        return Convert.ToDouble(num1) * Convert.ToDouble(num2);
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

    public double divide(int num1, int num2)
    {

        return Convert.ToDouble(num1) / Convert.ToDouble(num2);
    }

    public double divide(double num1, double num2)
    {

        return num1 / num2;
    }
}
}
