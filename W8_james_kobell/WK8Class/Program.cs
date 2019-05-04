/********************
Author: James Kobell
Date Created: 02/31/2019
Description: This a class to be tested using xUnit .NET Core for ENTD463_Assignment_WK8.
Source File: Program.cs [for unit testing with UnitTest1.cs ]
To run test: navigate to the xUnitTestProject1 directory.
At command line, run: dotnet test
********************/

using System;

namespace WK8Class
{
    public class Program
    {
        static void Main(string[] args)
        {
            //unit testing methods only                                  
        }

        //Method1
        public string ConStr(string strArg1, string strArg2)
        {
            string str1 = strArg1;
            string str2 = strArg2;
            return str1 + str2;
        }

        //Method2
        public string ToLowerStr(string strArg2)
        {           
            string str2 = strArg2;            
            string lowStr2 = str2.ToLower();
            return lowStr2;
        }

        //Method3
        public string StrToInt(int intNum)
        {
            int intNum1 = intNum;
            string strNum1 = Convert.ToString(intNum1);
            return strNum1;
        }

        //Method4
        public string StartWith(string strNum, string preF )
        {
            string modifiedStr = preF + "-" + strNum;
            return modifiedStr;
        }

        //Method5
        public string ContainSub(string strName, string strStType)
        {
            string strApp = strName + " " + char.ToUpper(strStType[0]) + strStType.Substring(1);            
            return strApp;
        }

        //Method6
        public string StrPre(string domain, string pre)
        {
            string toLow = pre.ToLower();
            string strStart = toLow;
            return strStart;
        }

        //Method7
        public string StrEnd(string strWeb)
        {
            string strEnd = strWeb.Substring(strWeb.Length - 3);
            return strEnd;
        }

        //Method8
        public int IfAdult(bool adult)
        {
            if (adult == true)
            {
                int ageMin = 18;
                return ageMin;
            }
            else
            {
                return 0;
            }
        }

        //Method9
        public bool IsPaid(string paid)
        {
            if(paid == "yes")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Method10
        public bool IsReady(string ordStatus)
        {
            if(ordStatus == "pending")
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
