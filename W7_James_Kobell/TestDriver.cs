using System.Security.AccessControl;
/********************
Author: James Kobell
Date Created: 02/24/2019
Description: This is a class in ENTD463_Assignment_WK7.
Source File: TestDriver.cs [must compile with MathOP.cs, MathOP2.cs and RWClass.cs]
Application: Test.exe
Note: to complile - 'csc /t:exe /out:Test.exe *.cs' [MathOP.cs, MathOP2.cs and RWClass.cs must be in same folder]
********************/
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Reflection.Emit;
using System;
using System.Data;
using System.Dynamic;
using System.Text.RegularExpressions;
using Internal;

//MathOP.cs, MathOP2.cs and RWClass.cs is also in namespace Week4
namespace Week4
{
    public class TestMathOP
    {
        static void Main(string[] args)
        {
        //object required if called method is non-static        
        TestMathOP obj = new TestMathOP();

        //call to non-static input method
        obj.Input();            
        }

        //method to valiate input and convert to float
        public void Input()
        {
        //declare local scope variables
        string firstNumIn = "";
        string secNumIn = ""; 
        float firstNum = 0;
        float secNum = 0;
       
        //regex pattern to match number digits and an optional decimal (only)
        string pattern = @"^\d*\.?\d*$";

        //object required if called method is non-static
        TestMathOP obj = new TestMathOP();

        //object for RegEx
        Regex matchObj = new Regex(pattern);

        Console.WriteLine("\nPlease enter first number.");
        firstNumIn = Console.ReadLine();

        //validate input for number digits and optional decimal
        bool validIn1 = matchObj.IsMatch(firstNumIn);
            if(validIn1 == true && firstNumIn != "")
            {
            firstNum = Convert.ToSingle(firstNumIn);
            }
            else 
            {
                if(firstNumIn == "")
                {                    
                 Console.WriteLine("\nA number must be entered!");
                }
                else
                {                    
                 Console.WriteLine("\nOnly number digits and optional decimal point are allowed!");
                }
            //call method to run another operation    
            obj.Repeat();
            }


        Console.WriteLine("\nPlease enter second number.");
        secNumIn = Console.ReadLine();

        //validate input for number digits and optional decimal
        bool validIn2 = matchObj.IsMatch(secNumIn);
            if(validIn2 == true && secNumIn != "")
            {
            secNum = Convert.ToSingle(secNumIn);
            }
            else 
            {
            if(secNumIn == "")
                {                    
                 Console.WriteLine("\nA number must be entered!");
                }
                else
                {                    
                 Console.WriteLine("\nOnly number digits and optional decimal point are allowed!");
                }
            
            //call method to run another operation
            obj.Repeat();
            }

        //call operation method, pass validated float(s)
        obj.RunOper(firstNum, secNum);           
        }

        //method choose to run another operation
        public void Repeat()
        {
        //object required if called method is non-static
        TestMathOP obj = new TestMathOP();
        Console.WriteLine("\nDo you want another operation (Y/N)?");
        string run = Console.ReadLine();
            if(run == "N" || run == "n")
            {         
            Console.WriteLine("\nThanks for using our system.");
            Console.WriteLine("\nPress any key to exit.");
            Console.ReadKey();
            Environment.Exit(0);
            }
            else if(run == "Y" || run == "y")
            {
            //call input method    
            obj.Input();      
            }
            else
            {
            Console.WriteLine("\nA (Y/N) was not entered.");
            Console.WriteLine("\nPress any key to exit.");
            Console.ReadKey();
            Environment.Exit(0);
            }
        }

        //operation method that creates object of MathOP class
        //values passed in from input method 
        public void RunOper(float first, float sec)
        {
        //local scope variables
        float firstNum = first;
        float secNum = sec;

            //Instantiate object of MathOP2
            MathOP2 mathObj = new MathOP2(firstNum, secNum);

            //read input choice of operation       
            Console.WriteLine("\nEnter '+' or '-' or '*' or '/' for operation or '!' for All-In-One.");
            string oper = Console.ReadLine();
        
        //object required if called method is non-static
        TestMathOP obj = new TestMathOP();
            if(oper == "+")
            {
            float addRes = mathObj.MathAdd();

            //also format numbers to four decimal places
            Console.WriteLine("\nThe sum of {0:F4} + {1:F4} = {2:F4}", firstNum, secNum, addRes);

                obj.Wresults(Convert.ToString(firstNum), oper, Convert.ToString(secNum), Convert.ToString(addRes));
                //obj.Repeat();
            }
            else if (oper == "-")
            {
            float subRes = mathObj.MathSub();

            //also format numbers to four decimal places
            Console.WriteLine("\nThe difference of {0:F4} - {1:F4} = {2:F4}", firstNum, secNum, subRes);

            obj.Wresults(Convert.ToString(firstNum), oper, Convert.ToString(secNum), Convert.ToString(subRes));
                              
            }
            else if (oper == "*")
            {
            float multRes = mathObj.MathMult();

             //also format numbers to four decimal places
             Console.WriteLine("\nThe product of {0:F4} * {1:F4} = {2:F4}", firstNum, secNum, multRes);

                obj.Wresults(Convert.ToString(firstNum), oper, Convert.ToString(secNum), Convert.ToString(multRes));
                
            }
            else if (oper == "/")
            {
             float divRes = mathObj.MathDiv();
                
                   //also format numbers to four decimal places
                    Console.WriteLine("\nThe quotient of {0:F4} / {1:F4} = {2:F4}", firstNum, secNum, divRes);

                obj.Wresults(Convert.ToString(firstNum), oper, Convert.ToString(secNum), Convert.ToString(divRes));
                                         
            }
            else if (oper == "!")
            {
             float[] allRes = new float[4];
             allRes = mathObj.MathAllInOne();
             
             //also format numbers to four decimal places
             Console.WriteLine("\nThe sum of {0:F4} + {1:F4} = {2:F4}", firstNum, secNum, allRes[0]);
             Console.WriteLine("\nThe difference of {0:F4} - {1:F4} = {2:F4}", firstNum, secNum, allRes[1]);
             Console.WriteLine("\nThe product of {0:F4} * {1:F4} = {2:F4}", firstNum, secNum, allRes[2]);
             Console.WriteLine("\nThe quotient of {0:F4} / {1:F4} = {2:F4}", firstNum, secNum, allRes[3]);
                

                //Dictionary object to hold operation as key and operation result as value pairs
                Dictionary<string, string> allList = new Dictionary<string, string>();

                allList.Add("+",Convert.ToString(allRes[0]));
                allList.Add("-",Convert.ToString(allRes[1]));
                allList.Add("*",Convert.ToString(allRes[2]));
                allList.Add("/",Convert.ToString(allRes[3]));

                obj.AllInOneWresults(Convert.ToString(firstNum), oper, Convert.ToString(secNum), allList);
            }
            else 
            {
            Console.WriteLine("\nA (+/-) was not entered.");
            obj.Repeat();
            }
        }

        //call to RWClass.method to write the lines to the csv file
        public void Wresults(string n1, string op, string n2, string rs)
        {
            RWClass RWobj = new RWClass();

            TestMathOP obj = new TestMathOP();
            Console.WriteLine("\nDo you want to save the results (Y/N)?");
            string run = Console.ReadLine();
            if (run == "N" || run == "n")
            {
                obj.Repeat();
            }
            else if (run == "Y" || run == "y")
            {
                string num1 = n1;
                string oper = op;
                string num2 = n2;
                string res = rs;
                RWobj.WRFile(num1, oper, num2, res);
                obj.Rresults();
            }
            else
            {
                Console.WriteLine("\nA (Y/N) was not entered.");
                Console.WriteLine("\nPress any key to exit.");
                Console.ReadKey();
                Environment.Exit(0);
            } 
        }

        //call to RWClass.method to read the lines from the csv file
        public void Rresults()
        {
            TestMathOP obj = new TestMathOP();
            Console.WriteLine("\nDo you want to review the results (Y/N)?");
            string run = Console.ReadLine();
            if (run == "N" || run == "n")
            {
                obj.Repeat();
            }
            else if (run == "Y" || run == "y")
            {

                Dictionary<string, string> RDDict = new Dictionary<string, string>();

                RWClass RWobj = new RWClass();

                RDDict = RWobj.RDFile();
                foreach(KeyValuePair<string, string> eqRes in RDDict)
                {
                    Console.WriteLine(eqRes.Key + eqRes.Value);

                }
                obj.Repeat();               
            }
        }

        //call to RWClass.method to write the All-In-One lines to the csv file
        public void AllInOneWresults(string n1, string op, string n2, Dictionary<string, string> rs)
        {
            RWClass RWobj = new RWClass();

            TestMathOP obj = new TestMathOP();
            Console.WriteLine("\nDo you want to save the results (Y/N)?");
            string run = Console.ReadLine();
            if (run == "N" || run == "n")
            {
                obj.Repeat();
            }
            else if (run == "Y" || run == "y")
            {
                string num1 = n1;
                string oper = op;
                string num2 = n2;                

                foreach(KeyValuePair<string, string> res in rs)
                {
                    RWobj.WRFile(num1, res.Key, num2, res.Value);
                }
                
                //call to read results this.method
                obj.Rresults();
            }
            else
            {
                Console.WriteLine("\nA (Y/N) was not entered.");
                Console.WriteLine("\nPress any key to exit.");
                Console.ReadKey();
                Environment.Exit(0);
            }
        }

    }
}
