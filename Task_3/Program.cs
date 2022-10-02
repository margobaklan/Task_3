using System;

namespace Task3
{
    class Converter
    {
        public decimal Dollar;
        public decimal Euro;

        public Converter(decimal dollar, decimal euro)
        {
            Dollar = dollar;
            Euro = euro;
        }
        public decimal UsdToGrn(decimal dollar)
        {
            return dollar * Dollar;
        }
        public decimal EuroToGrn(decimal euro)
        {
            return euro * Euro;
        }
        public decimal GrnToUsd(decimal grn)
        {
            return grn / Dollar;
        }
        public decimal GrnToEuro(decimal grn)
        {
            return grn / Euro;
        }
    }

    class Program
    {
        static decimal ReadNumber() //перевірка чи ввели саме число, чи є число додатнім
        {
            decimal a = 0;
            try
            {
                a = Convert.ToDecimal(Console.ReadLine());
                if (a <= 0)
                {
                    throw new Exception("Треба ввести число більше 0");
                }
                return a;
            }
            catch (FormatException)
            {
                Console.WriteLine("Треба ввести число");
                a = ReadNumber();
                return a;
            }
            catch (Exception e)
            {
                Console.WriteLine($"{e.Message}");
                a = ReadNumber();
                return a;
            }
        }
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Default;

            Console.WriteLine("Введіть курс Долара");
            decimal d;
            d = ReadNumber();

            Console.WriteLine("Введіть курс Євро");
            decimal e;
            e = ReadNumber();

            Converter convert = new(d, e);
            do
            {
                Console.WriteLine("1 - Перевести ГРН в ДОЛАРИ");
                Console.WriteLine("2 - Перевести ГРН в ЄВРО");
                Console.WriteLine("3 - Перевести ДОЛАРИ в ГРН");
                Console.WriteLine("4 - Перевести ЄВРО в ГРН");

                int i;
                i = Convert.ToInt32(ReadNumber());
                if (i == 1)
                {
                    Console.WriteLine("Введіть сумму в ГРН");
                    decimal sum;
                    sum = ReadNumber();
                    Console.WriteLine("{0} usd", convert.GrnToUsd(sum));
                }
                else if (i == 2)
                {
                    Console.WriteLine("Введіть сумму в ГРН");
                    decimal sum;
                    sum = ReadNumber();
                    Console.WriteLine("{0} euro", convert.GrnToEuro(sum));
                }
                else if (i == 3)
                {
                    Console.WriteLine("Введіть сумму в ДОЛАРАХ");
                    decimal sum;
                    sum = ReadNumber();
                    Console.WriteLine("{0} грн", convert.UsdToGrn(sum));
                }
                else if (i == 4)
                {
                    Console.WriteLine("Введіть сумму в ЭВРО");
                    decimal sum;
                    sum = ReadNumber();
                    Console.WriteLine("{0} грн", convert.EuroToGrn(sum));
                }
            } while (true);
        }
    }
}
