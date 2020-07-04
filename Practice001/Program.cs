using System;
using System.Linq;

namespace Practice001
{
    class Program
    {
        static void Main(string[] args)
        {
            // Hello World!!を表示
            Console.WriteLine("-----");
            Console.WriteLine("Hello World!!");

            // Hello Worldを10回表示
            Console.WriteLine("-----");
            Enumerable.Range(0, 10).ToList().ForEach(x => { Console.WriteLine("Hello World!!"); });

            // 標準入力
            Console.WriteLine("-----");
            var str = Console.ReadLine();
            Console.WriteLine($"Hello {str}!!");

            // 入力＋分岐
            Console.WriteLine("-----");
            while (true)
            {
                var n = Console.ReadLine();

                if (int.TryParse(n, out int num))
                {
                    if (num == 1)
                    {
                        Console.WriteLine("true");
                        break;
                    }
                    else if (num == 0)
                    {
                        Console.WriteLine("false");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("エラー！1または0を入力してください。");
                    }
                }
                else
                {
                    Console.WriteLine("エラー！1または0を入力してください。");
                }
            }

            // 100回繰り返し
            Console.WriteLine("-----");
            for (int i = 1; i <= 100; i++)
            {
                Console.WriteLine(i);
            }

            // 入力値まで回繰り返し
            Console.WriteLine("-----");
            while (true)
            {
                var n = Console.ReadLine();
                if (int.TryParse(n, out int num) && num > 0)
                {
                    Enumerable.Range(1, num).ToList().ForEach(Console.WriteLine);
                    break;
                }
                else
                {
                    Console.WriteLine("正の整数を入力してください。");
                }
            }

            // 入力値を2倍、2で割ったあまり
            Console.WriteLine("-----");
            while (true)
            {
                var n = Console.ReadLine();
                if (int.TryParse(n, out int num))
                {
                    Console.WriteLine($"2倍　: {num * 2}");
                    Console.WriteLine($"2剰余: {num % 2}");
                    break;
                }
                else
                {
                    Console.WriteLine("整数を入力してください。");
                }
            }

            // 100回繰り返し＋4の倍数で"わ！"と表示させる
            Console.WriteLine("-----");
            Enumerable.Range(1, 100).Select(x => x % 4 == 0 ? "わ！" : x.ToString()).ToList().ForEach(Console.WriteLine);

            // 100回繰り返し＋FIzzBuzz
            Console.WriteLine("-----");
            Enumerable.Range(1, 100)
                .Select(x =>
                    x % 3 == 0 && x % 5 == 0 ? "FizzBuzz"
                    : x % 3 == 0 ? "Fizz"
                    : x % 5 == 0 ? "Buzz"
                    : x.ToString())
                .ToList().ForEach(Console.WriteLine);
            // 1行で書く場合
            // Enumerable.Range(1, 100).Select(x => x % 3 == 0 && x % 5 == 0 ? "FizzBuzz" : x % 3 == 0 ? "Fizz" : x % 5 == 0 ? "Buzz" : x.ToString()).ToList().ForEach(Console.WriteLine);

            // 10進数を2進数と16進数に変換
            Console.WriteLine("-----");
            while (true)
            {
                var n = Console.ReadLine();
                if (int.TryParse(n, out int num))
                {
                    Console.WriteLine($"2進数 : {Convert.ToString(num, 2)}");
                    Console.WriteLine($"16進数: {Convert.ToString(num, 16)}");

                    break;
                }
                else
                {
                    Console.WriteLine("整数を入力してください。");
                }
            }

            // 入力値の数を頂点とするピラミッド（横）
            Console.WriteLine("-----");
            while (true)
            {
                var n = Console.ReadLine();
                if (int.TryParse(n, out int num))
                {
                    foreach (var i in Enumerable.Range(1, num * 2 - 1).Select(x => x <= num ? x : num * 2 - x))
                    {
                        foreach (var j in Enumerable.Range(1, i)) Console.Write("+");
                        // 別の書き方
                        // Enumerable.Range(1, i).ToList().ForEach(_ => { Console.Write("+"); });
                        Console.WriteLine();
                    }

                    break;
                }
                else
                {
                    Console.WriteLine("整数を入力してください。");
                }
            }


        }

    }
}
