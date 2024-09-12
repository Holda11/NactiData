using System.Linq;
internal class Program
{
    private static void Main(string[] args)
    {
        bool i = false;
        int? x = null;
        int? y = null;
        int? z = null;
        while (i != true)
        {
            Console.Clear();
            if (x == null)
            {
                Console.WriteLine("Zadejte hodnotu A:");
                var result = Values();
                x = result.Item1;
            }
            else if (y == null)
            {
                Console.WriteLine("Zadejte hodnotu B:");
                var result = Values();
                y = result.Item1;
            }
            else
            {
                Console.WriteLine("Zadejte hodnotu C:");
                var result = Values();
                z = result.Item1;
                i = result.Item2;
            }            
        };
        bool final = false;
        while (final != true)
        {
            Console.Clear();
            Console.WriteLine("Zvolte metodu:");
            Console.WriteLine("[1] SOUČET VŠECH 3 ČÍSEL");
            Console.WriteLine("[2] SOUČIN VŠECH 3 ČÍSEL");
            Console.WriteLine("[3] SOUČET PRVNÍCH 2 ČÍSEL DĚLENÝ TŘETÍM");
            string? input = Console.ReadLine();
            switch (input) 
            {
                case "1":
                    Console.Clear();
                    Console.WriteLine(x + y + z);
                    final = true;
                    break;
                case "2":
                    Console.Clear();
                    Console.WriteLine(x * y * z);
                    final = true;
                    break;
                case "3":
                    while (z == 0)
                    {
                        Console.Clear();
                        Console.WriteLine("Nastavte novou hodnotu C");
                        var result = Values();
                        z = result.Item1;
                        Console.WriteLine(z);
                    }
                    Console.Clear();
                    double first = (int)x;
                    double second = (int)y;
                    double third = (int)z;
                    double number = (first + second)/third;
                    Console.WriteLine("Výsledek dělení je:" + number);
                    Console.ReadLine();
                    final = true;
                    break;
                default:
                    Console.WriteLine("Nezadali jste správný výběr");
                    break;
            }
        }
        Console.WriteLine("Děkuji, toto je vše!");
        Console.ReadKey();
    }
    static(int?, bool) Values()
    {
        string? s = Console.ReadLine();
        if (string.IsNullOrEmpty(s))
        {
            Console.WriteLine("Musíte nastavit hodnotu! Zadejte Enter pro pokračování..");
            Console.ReadLine();
            return (null, false);
        }
        else
        {
            var result = Validation(s);
            return (result.Item1, result.Item2);
        }
    }
    static(int?, bool) Validation(string sType)
    {
        if(sType.All(char.IsDigit))
        {
            int value = int.Parse(sType);
            return (value, true);
        }
        else 
        {
            Console.WriteLine("Zadejte číslo");
            return (null,false);
        }
    }
}