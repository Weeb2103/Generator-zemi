using System.Runtime.InteropServices;

zacatek:
string obsah_textaku = File.ReadAllText("zeme.txt");
Console.WriteLine(obsah_textaku);
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
Console.WriteLine("Chcete vygenerovat náhodnou zemi Y/N/C");
Console.WriteLine("Y=Ano N=Ne C=Lze vybrat rozsah pomocí čísla" );
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
        Console.WriteLine("Chceš znovu?Y/N/C");
        Console.WriteLine("Y=Ano N=Ne C=Lze vybrat rozsah pomocí čísla");
        ConsoleKeyInfo znovu = Console.ReadKey(true);
        switch (znovu.Key)
        {
            case ConsoleKey.Y:
                goto start;
            case ConsoleKey.N:
                goto konec;
            case ConsoleKey.C:
                goto rozmezi;
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
        Console.WriteLine("Chceš znovu?Y/N/C");
        Console.WriteLine("Y=Ano N=Ne C=Lze vybrat rozsah pomocí čísla");
        ConsoleKeyInfo znovu1 = Console.ReadKey(true);
        switch (znovu1.Key)
        {
            case ConsoleKey.Y:
                goto start;
            case ConsoleKey.N:
                goto konec;
            case ConsoleKey.C:
                goto rozmezi;
            default:
                Console.Clear();
                goto zacatek;
        }

    default:
        Console.Clear();
        goto zacatek;
}