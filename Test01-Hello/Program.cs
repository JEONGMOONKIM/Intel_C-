using System;
using static System.Console;
using static System.Math;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Net.NetworkInformation;
using System.Globalization;

namespace Test01_Hello
{
    static class myLib
    {
        public static string GetToken(String str, int n, char ch) //string으로 리턴. public으로 외부 참조 가능. //str: "1 2 3" "1,2,3", (n)번째, (ch)
        {
            return str.Split(ch)[n]; //string[]로 반환
        }
    }
    class Point
    {
        int x, y;
        public Point(int x = 0, int y = 0)
        {
            this.x = x;
            this.y = y;
        }
        public double Dist(Point p1) 
        {
            int d1 = p1.x - x;
            int d2 = p1.y - y;
            //return Math.Sqrt(d1 * d1 + d2 * d2);
            return d1 * d2;
        }
        public static double operator-(Point p1, Point p2) 
        {
            int d1 = p1.x - p2.x;
            int d2 = p1.y - p2.y;
            //return Math.Sqrt(d1*d1 + d2 * d2);
            return Sqrt(d1*d1 + d2 * d2);
        }
        public static double operator *(Point p1, Point p2)
        {
            int d1 = p1.x - p2.x;
            int d2 = p1.y - p2.y;
            return Math.Abs(d1 * d2);
            
        }
    }
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
        delegate void cbTest();
        void f1() { WriteLine("delegate Test 01"); }
        void f2() { WriteLine("delegate Test 02"); }
        void f3() { WriteLine("delegate Test 03"); }
        void Func_DelegateTest()
        {
            cbTest cb;
            cb = new cbTest(f1); cb();
            cb = new cbTest(f2); cb();
            cb = new cbTest(f3); cb();
        }
        public void Func1_PointTest()
        {
            //Point p = new Point(10, 20);
            //Point p1 = new Point(30, 40);
            //WriteLine($"두 점 p1(10,20), p2(30,40) 사이의 거리는 {(p1 - p)}입니다.");
            string s1 = "Good";
            string s2 = "morning!";
            string s3 = s1 + s2;
            Point p = new Point(10, 20);
            Point p1 = new Point(30, 40);
            WriteLine($"두 점 p1(10,20), p2(30,40)의 거리는 [{p1-p}], 면적은 [{p1*p}]입니다.");
        }
        public void Func_ReadWrite()
        {
            int i = 10, j = 20;
            double d = 1.5, e = 3.1;
            Object o = i + 1; //Object는 변수의 종류 무관.
            var v = i * 10; //var라는 데이터 타입은 없음. v는 int로 간주.
            //Console.WriteLine("Hello World({0},{1})\nMain Function({1},{0})", i, j); //.WriteLine() = printf() //{} 속 숫자는 뒤에 붙는 arg의 number. 0울 넣어줬으므로 0번째 arg인 i의 값이 들어감.
            WriteLine("Hello World({0},{1},{5})\nMain Function({2},{3},{4})", i, j, d, e, o, v); //using static System.Console;를 넣어줬으므로 앞에 Console을 빼도 무방.
            o = d + 0.5;
            //v = d * 10; //v는 int이므로 d를 넣으면 오류. 
            v = j * 10;
            WriteLine("Hello World({0},{4})\nMain Function({2},{3},{1})", i, j, d, e, o);
            WriteLine("i:{0}, j:{1}, d:{2}, e:{3}, o:{4}", i, j, d, e, o);
            WriteLine($"i:{sizeof(int)}, d:{sizeof(double)}");


            //int[] arr = new int[100]; //배열 선언
            int[] arr = new int[i]; //c와 비교했을 때, 배열 선언을 변수로 할 수 있는 차이가 있음.
            for (int ii = 0; ii < 10; ii++) arr[ii] = i;
            //arr[1].

            //myLib my = new myLib();
            while (true)
            {
                try
                {
                    WriteLine("Input 2 Integer: ");
                    string str = ReadLine(); //.ReadLine()=scanf() --> string //str = "10 20"
                    //i = int.Parse(str.Split(' ')[0]); //입력받은 str값을 i에 대입
                    i = int.Parse(myLib.GetToken(str, 0, ' ')); //입력받은 str값을 i에 대입
                    //j = int.Parse(str.Split(' ')[1]);
                    j = int.Parse(myLib.GetToken(str, 1, ' '));
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
        int ArrSum1(int[] arr) //int 배열요소의 합
        {
            int sum = arr[0];
            for (int i = 0; i < arr.Length; i++)
                sum += arr[i];
            return sum;
        }
        T ArrSum<T>(T[] arr) //<int>int 배열요소의 합을 구하는 제네릭 함수
        {
            T sum = (dynamic) 0;
            foreach (T a in arr)
                sum = (dynamic) arr;
            return sum;
        }
        void PrinArr<T>(T[] arr)
        {
            int i = 0;
            foreach (T a in arr)
            {
                Write($"[i++]{a}  ");
            }
        }
        void InitArr(out int[] arr, int n) //out: 포인터처럼 arr를 다루고자할 때 사용
        {
            arr = new int[n];
            foreach (int a in arr) arr[a] = 0;
        }
        void CallArr(int[] arr)
        {
            arr[2] = 100;
            arr[4] = 200;
            for (int i = 0; i < 10; i++)
                Write($"arr[{i}]:{arr[i]}  ");
            WriteLine();
        }
        public void Func_ArrayTest()
        {
            string s1 = "Good ";
            string s2 = "morning";

            int[] arr; //= new int[10]; //1차원 배열 객체. 객체의 초기화
            int[] arr1 = { 0, 1, 2, 3, 4 }; //{}를 통해 초기화 가능.
            Point[] parr = new Point[10];
            
            int[,] brr = { { 10, 11, 12, 13, 14 }, { 20, 21, 22, 23, 24 } }; //2차원 객체 선언.
            int[][] crr =
            {
                new int[] { 10, 11, 12, 13, 14 },
                new int[] { 20, 21, 22, 23, 24, 25, 26 }
            };
            InitArr(out arr, 10); for (int i = 0; i < 10; i++) Write($"arr[{i}]:{arr[i]}  ");WriteLine();
            crr[0].CopyTo(arr, 0); for (int i = 0; i < 10; i++) Write($"arr[{i}]:{arr[i]}  "); WriteLine();
            CallArr(arr);         for (int i = 0; i < 10; i++) Write($"arr[{i}]:{arr[i]}  ");WriteLine();
            //arr.CopyTo(brr, 0); //arr은 1차원 배열, brr은 2차원 배열이므로 수행될 수 없음. 수행상의 오류는 컴파일러가 잡아주지 못하며 수행단계(.NET framework)에서 걸러짐.
            //arr.CopyTo(crr[0], 6); //배열의 길이가 달라 오류.
            


            for (int i = 0; i < 2; i++)
            { 
                for (int j = 0; j < 5; j++)
                {
                    Write($"brr[{i},{j}]:{brr[i, j]}  ");
                }
                WriteLine("");
            } 
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    Write($"crr[{i}][{j}]:{crr[i][j]}  ");
                }
                WriteLine("");
            }

            WriteLine($"Length of [arr] : {arr.Length}");
            WriteLine($"Sum of [arr] : {ArrSum(arr)}");
            arr.Append<int>(1);
            WriteLine(s1 + s2); //== string s3 = s1 + s2;
            WriteLine($"Length of [arr] : {arr.Length}");
        }
        public void MainFunc() //주 진입점(실행함수)
        {
            //Func1_PointTest(); return; //Point Test
            //Func_ReadWrite(); return;
            Func_ArrayTest(); return;
        }
    }
}
