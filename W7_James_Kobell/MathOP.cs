/********************
Author: James Kobell
Date Created: 02/24/2019
Description: This is a class in ENTD463_Assignment_WK7.
Source File: MathOP.cs
Application: Test.exe
Note: must be compiled with TestDriver.cs, MathOP2.cs and RWClass.cs  
********************/
using System;

namespace Week4
{
    public class MathOP
    {
        //attributes    
        private float inNum1;
        private float inNum2;

        //constructor
        public MathOP(float firstNum, float secNum)
        {
            inNum1 = firstNum;
            inNum2 = secNum;
        }

        //addition method
        public float MathAdd()
        {
            return(inNum1 + inNum2);
        }  

        //subtraction method
        public float MathSub()
        {
            return(inNum1 - inNum2);
        }
    }
}