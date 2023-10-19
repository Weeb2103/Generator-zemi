using System.Runtime.InteropServices;

zacatek:
Console.WriteLine(@" _____                    _                      _____                      _                
 |  __ \                  | |                    / ____|                    | |               
 | |__) | __ _  _ __    __| |  ___   _ __ ___   | |      ___   _   _  _ __  | |_  _ __  _   _ 
 |  _  / / _` || '_ \  / _` | / _ \ | '_ ` _ \  | |     / _ \ | | | || '_ \ | __|| '__|| | | |
 | | \ \| (_| || | | || (_| || (_) || | | | | | | |____| (_) || |_| || | | || |_ | |   | |_| |
 |_|  \_\\__,_||_| |_| \__,_| \___/ |_| |_| |_|  \_____|\___/  \__,_||_| |_| \__||_|    \__, |
                                                                                         __/ |
                                                                                        |___/ ");
string obsah_textaku = File.ReadAllText("zeme.txt");
Console.WriteLine("-------------------------");
string[] zeme = obsah_textaku.Split(new[] {'\n'}, StringSplitOptions.None);
List<string> seznam_zemi = zeme.ToList();
foreach (var jedna_zeme in seznam_zemi)
{
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("---Země---");
    Console.ForegroundColor= ConsoleColor.Blue;
    Console.WriteLine(jedna_zeme);
    Console.ResetColor();
}
Console.WriteLine("Chcete vygenerovat náhodnou zemi Y/N/C/D");
Console.WriteLine("Y=Ano N=Ne C=Lze vybrat rozsah pomocí čísla D=Lze vybrat pomocí písmena" );
ConsoleKeyInfo volba = Console.ReadKey(true);
switch (volba.Key)
{
    case ConsoleKey.Y:
    start:
        Console.ForegroundColor = ConsoleColor.Red;
        Random generator = new Random();
        int nahodna_pozice = generator.Next(0, seznam_zemi.Count);
        Console.WriteLine(seznam_zemi[nahodna_pozice]);
        Console.ResetColor();
        Console.WriteLine("Chceš znovu?Y/N/C/D");
        Console.WriteLine("Y=Ano N=Ne C=Lze vybrat rozsah pomocí čísla D=Lze vybrat pomocí písmena");
        ConsoleKeyInfo znovu = Console.ReadKey(true);
        switch (znovu.Key)
        {
            case ConsoleKey.Y:
                goto start;
            case ConsoleKey.N:
                goto konec;
            case ConsoleKey.C:
                goto rozmezi;
            case ConsoleKey.D:
                goto pismeno;
            default:
                Console.Clear();
                goto zacatek;
        }   
    case ConsoleKey.N:
        konec:
        Console.Clear();
        Console.ForegroundColor= ConsoleColor.Yellow;
        Console.WriteLine("Konec");
        Console.ResetColor();
        break;
    case ConsoleKey.C:
        rozmezi:
        Console.ForegroundColor = ConsoleColor.Red;
        Random generator1 = new Random();
        int cislo_min;
        int cislo_max;
        Console.WriteLine("Napiš spodní hranici");
        string cislo1 = Console.ReadLine();
        Console.WriteLine("Zadej horní hranici");
        string cislo2 = Console.ReadLine();
        cislo_min = Convert.ToInt32(cislo1);
        cislo_max = Convert.ToInt32(cislo2); 
        int nahodna_pozice1 = generator1.Next(cislo_min, cislo_max);
        Console.ForegroundColor= ConsoleColor.Red;
        Console.WriteLine(seznam_zemi[nahodna_pozice1]);
        Console.ResetColor();
        Console.WriteLine("Chceš znovu?Y/N/C/D");
        Console.WriteLine("Y=Ano N=Ne C=Lze vybrat rozsah pomocí čísla D= Lze vybrat pomocí písmena");
        ConsoleKeyInfo znovu1 = Console.ReadKey(true);
        switch (znovu1.Key)
        {
            case ConsoleKey.Y:
                goto start;
            case ConsoleKey.N:
                goto konec;
            case ConsoleKey.C:
                goto rozmezi;
            case ConsoleKey.D:
                goto pismeno;
            default:
                Console.Clear();
                goto zacatek;
        }
    case ConsoleKey.D:
    pismeno:
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Zadej písmeno");
        char pismeno = char.ToUpper(Console.ReadKey(true).KeyChar);
        List<string> nalezene_zeme = new List<string>();
        foreach (string country in seznam_zemi)
            if (country.StartsWith(pismeno.ToString()))
            {
                nalezene_zeme.Add(country);
            }
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("Země začínající na písmeno " + pismeno);
        foreach (string country in nalezene_zeme)
        {
            Console.ForegroundColor= ConsoleColor.Magenta;
            Console.WriteLine(country);
        }
        Console.ResetColor();
        Console.WriteLine("Chceš znovu?Y/N/C/D");
        Console.WriteLine("Y=Ano N=Ne C=Lze vybrat rozsah pomocí čísla D= Lze vybrat pomocí písmena");
        ConsoleKeyInfo znovu2 = Console.ReadKey(true);
        switch (znovu2.Key)
        {
            case ConsoleKey.Y:
                goto start;
            case ConsoleKey.N:
                goto konec;
            case ConsoleKey.C:
                goto rozmezi;
            case ConsoleKey.D:
                goto pismeno;
            default:
                Console.Clear();
                goto zacatek;
        }

    default:
        Console.Clear();
        goto zacatek;
}