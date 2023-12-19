using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Net.NetworkInformation;

namespace Test01_Hello
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Program pgm = new Program();
            //int i = pgm.function();
            Test01 Sub=new Test01();
            Sub.MainFunc();
        }
        //int function()
        //{
        //    while (true)
        //    {
                
        //    }
        //    return 1; 
        //}
    }
    class Test01 //main class
    {
        public void MainFunc()
        {
            int i = 10, j=20;
            double d = 1.5, e = 3.1;
            Object o = i + 1;
            //Console.WriteLine("Hello World({0},{1})\nMain Function({1},{0})", i, j); //.WriteLine() = printf() //{} 속 숫자는 뒤에 붙는 arg의 number. 0울 넣어줬으므로 0번째 arg인 i의 값이 들어감.
            WriteLine("Hello World({0},{1})\nMain Function({2},{3},{4})", i, j, d, e, o); //using static System.Console;를 넣어줬으므로 앞에 Console을 빼도 무방.
            o = d + 0.5;
            WriteLine("Hello World({0},{4})\nMain Function({2},{3},{1})", i, j, d, e, o); 
            while (true)
            {
                try
                {
                    WriteLine("Input 2 Integer: ");
                    string str = ReadLine(); //.ReadLine()=scanf() --> string //str = "10 20"
                    i = int.Parse(str.Split(' ')[0]); //입력받은 str값을 i에 대입
                    j = int.Parse(str.Split(' ')[1]);
                    WriteLine($"입력한 정수는 ({i},{j})입니다.");

                    WriteLine("Input 2 Double: ");
                    str = ReadLine(); //10.1 20.2
                    d = double.Parse(str.Split(' ')[0]);
                    e = double.Parse(str.Split(' ')[1]);
                    WriteLine($"입력한 실수는 ({d},{e})입니다.");
                    //string str = "STX" + i.ToString() + "ETX";
                    //string st1 = $"STX{i, 5}ETX"; //i의 자릿수 지정
                    //WriteLine(str);
                    //Console.WriteLine(st1);
                }
                catch (Exception e1)
                {
                    WriteLine(e1.Message);
                }
            }
        }
    }
}
