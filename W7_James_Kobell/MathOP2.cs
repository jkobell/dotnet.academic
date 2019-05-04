using System.ComponentModel;
using Internal;
/********************
Author: James Kobell
Date Created: 02/24/2019
Description: This is a class in ENTD463_Assignment_WK7.
Source File: MathOP2.cs
Application: Test.exe
Note: must be compiled with TestDriver.cs, MathOP.cs and RWClass.cs 
********************/
using System;
using System.Collections.Generic;
//System.Exception; 

namespace Week4
{
    public class MathOP2 : MathOP
    {
        //attributes    
        private float inNum1;
        private float inNum2;        
                     
        //constructor
        public MathOP2(float firstNum, float secNum) : base(firstNum, secNum)
        {
            inNum1 = firstNum;
            inNum2 = secNum;            
        }

        //addition method
        public float MathMult()
        {
            return (inNum1 * inNum2);
        }

        //division method
        public float MathDiv()
        {
            float quot = 0;
            string err = null;
            //begin try-catch-finally
            try
            {                
            quot = (inNum1 / inNum2);

                if(Single.IsNaN(quot) || Single.IsInfinity(quot))
                 {
                     //create a throw if true
                     throw new ArgumentNullException("Divisor");                    
                }
                else
                {
                    return quot; 
                 }
            }

            //use throw
            //note: DivideByZeroException is not valid for Single or Double in C#
            catch(ArgumentNullException e)
            {
                  //stream this to log
                  string elog = e.ToString();                
                  
                  Console.WriteLine("\nAn ERROR has occured. Press any key to display error message.");
                  Console.ReadKey();                   
                  err = "true";
                  return quot;                   
            }

            finally
            {
                if (err == null)
                {
                    Console.WriteLine("\nThe division operation was successful.\n\n");                    
                }
                else
                {
                    Console.WriteLine("\nDivide by zero is not allowed!");
                }
            }
        }

        //allinone method
        //returning all operations as array
        public float[] MathAllInOne()
            
        {
            float[] allMeth = new float[4];
            
            //superclass methods
            allMeth[0] = base.MathAdd();
            allMeth[1] = base.MathSub();

            //subclass methods
            allMeth[2] = MathMult();
            allMeth[3] = MathDiv();
            
            return (allMeth);            
        }
    }
}