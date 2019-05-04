/********************
Author: James Kobell
Date Created: 02/31/2019
Description: This is an xUnit class using .NET Core for ENTD463_Assignment_WK8.
Source File: UnitTest1.cs [for unit testing Program.cs]
To run test: navigate to the xUnitTestProject1 directory.
At command line, run: dotnet test
********************/

using System;
using Xunit;
using WK8Class;

namespace XUnitTestProject1
{
    public class UnitTest1
    {
        private readonly Program _program;
        public UnitTest1()
        {
            _program = new Program();
        }

        //Test1 Assert.Equal
        [Fact]
        public void Task_Concatenate()
        {
            //arrange test set
            string str1 = "apple";
            string str2 = "sauce";
            string expected = "applesauce";

            //test action
            var conStr = _program.ConStr(str1, str2);

            //Assert
            Assert.Equal(expected, conStr);
        }

        //Test2 Assert.NotSame
        [Fact]
        public void Task_StringToLower()
        {
            //arrange test set
            string name1 = "William";
            string name2 = "William";

            //test action
            var toLower = _program.ToLowerStr(name2);

            //Assert            
            Assert.NotSame(name1, toLower);
        }

        //Test3 - Assert.Equal
        [Fact]
        public void Task_IntToString()
        {
            //arrange test set
            string strNum1 = "8";
            int num1 = 8;
            
            //test action
            var toStr = _program.StrToInt(num1);

            //Assert            
            Assert.Equal(strNum1, toStr);
            
        }

        //Test4 - StartsWith
        [Fact]
        public void Task_Prefix()
        {
            //arrange test set
            string strNum = "234-567-8910";
            string strPre = "1";
            string pass = "1-234-567-8910";

            //test action
            var startWith = _program.StartWith(strNum, strPre);

            //Assert
            Assert.StartsWith(strPre, pass);

        }

        //Test5 - Contains
        [Fact]
        public void Task_contains_SubString()
        {
            //arrange test set
            string stName = "Central";
            string stType = "blvd";
            string pass = "Blvd";

            //test action
            var cSub = _program.ContainSub(stName, stType);

            //Assert
            Assert.Contains(pass, cSub);

        }

        //Test6 - StartsWith
        [Fact]
        public void Task_String_Begin()
        {
            //arrange test set
            string strWeb = "Mr. Jones";
            string strPre = "Mr.";
            string pass = "mr.";

            //test action
            var strStart = _program.StrPre(strWeb, strPre);

            //Assert
            Assert.StartsWith(pass, strStart);
        }

        //Test7 - EndsWith
        [Fact]
        public void Task_String_End()
        {
            //arrange test set
            string strSuffix = "John Smith Sr.";
            string pass = "Sr.";

            //test action
            var nameSuffix = _program.StrEnd(strSuffix);

            //Assert
            Assert.EndsWith(pass, nameSuffix);

           

        }

        //Test8 - InRange
        [Fact]
        public void Task_Int_Range()
        {
            //arrange test set
            bool usrAdult = true;
            int passMin = 18;
            int passMax = 120;

            //test action
            var IsAdult = _program.IfAdult(usrAdult);

            //Assert
            Assert.InRange(IsAdult, 18, 120);


        }

        //Test9 - True
        [Fact]
        public void Task_Return_true()
        {
            //arrange test set
            string invoicePd = "yes";

            //test action
            var isPd = _program.IsPaid(invoicePd);

            //Assert
            Assert.True(isPd);
        }

        //Test10 - False
        [Fact]
        public void Task_Return_false()
        {
            //arrange test set
            string ordStatus = "pending";

            //test action
            var status = _program.IsReady(ordStatus);

            //Assert
            Assert.False(status);
        }
    }
}
