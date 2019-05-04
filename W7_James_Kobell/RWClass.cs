/********************
Author: James Kobell
Date Created: 02/24/2019
Description: This is a class in ENTD463_Assignment_WK7.
Source File: RWClass.cs
Application: Test.exe
Note: must be compiled with TestDriver.cs, MathOP.cs and MathOP2.cs 
********************/
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Week4
{
    public class RWClass
    {        
        //constructor
        public RWClass()
        {

        }

        //write to file method
        public void WRFile(string n1, string op, string n2, string rs)
        {
            string num1 = n1;
            string oper = op;
            string num2 = n2;
            string res = rs;
            string eq = num1 + " " + op + " " + num2 + " = " + res; 

            StreamWriter sw = new StreamWriter("Math_Results.csv", true);
            try
            {
                sw.WriteLine(eq);
                sw.Close();
            }
            catch (FileNotFoundException e)
            {
                string trap = Convert.ToString(e);
                
            }
            catch (DirectoryNotFoundException e)
            {
                string trap = Convert.ToString(e);
                
            }
            catch (IOException e)
            {
                string trap = Convert.ToString(e);
                
            }
            finally
            {
                sw.Close();
            }

        }

        //read from file method
        public Dictionary<string, string> RDFile()
        {
            Dictionary<string, string> RDDict = new Dictionary<string, string>();
            StreamReader sr = new StreamReader("Math_Results.csv");
            try
            {
                int i = 1;
                while (sr.Peek() >= 0)
                {
                    string strI = Convert.ToString(i) + ". ";
                    RDDict.Add(strI, sr.ReadLine());
                    i = i + 1;
                }
                sr.Close();
                return RDDict;
            }
            catch(FileNotFoundException e)
            {
                string trap = Convert.ToString(e);
                return null;
            }
            catch (DirectoryNotFoundException e)
            {
                string trap = Convert.ToString(e);
                return null;
            }
            catch (IOException e)
            {
                string trap = Convert.ToString(e);
                return null;
            }
            finally
                {
                sr.Close();
            }
        }

    }
}


