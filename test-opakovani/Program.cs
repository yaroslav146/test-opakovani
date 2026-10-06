namespace test_opakovani
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("-----NAKUPNI SEZNAM-----");

            string souborovaCesta;
            Console.WriteLine("zadejte souborovou cestu");
            souborovaCesta = Console.ReadLine();

            if (File.Exists(souborovaCesta))
            {
                Console.WriteLine("cesta existuje");
            }
            else
            {
                Console.WriteLine("cesta neexistuje, ukladam do dokumentu");
                souborovaCesta = Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                    "nakupni_seznam.txt");
            }


            Console.WriteLine("zadej pocet polozek nakupniho seznamu: ");
            int pocetPolozek = 0;
            while (int.TryParse(Console.ReadLine(), out pocetPolozek) == false || pocetPolozek < 0)
            {
                Console.Write("zadejte opravdovy pocet polozek: ");
            }

            try
            {
                using (StreamWriter writer = new StreamWriter(souborovaCesta))
                {
                    for (int i = 0; i < pocetPolozek; i++)
                    {
                        Console.WriteLine($"Polozka {i + 1}");
                        Console.Write("Zadejte název polozky: ");
                        string polozka = Console.ReadLine();

                        Console.Write("Zadejte počet kusu polozky: ");
                        string pocetKusu = Console.ReadLine();

                        Console.WriteLine();
                        writer.WriteLine("-------------------");
                        writer.WriteLine($"Polozka: {polozka}");
                        writer.WriteLine($"Pocet kusu: {pocetKusu}");

                    }
                    writer.WriteLine("-------------------");
                }
                Console.WriteLine("nakupni seznam byl uspěšně vytvořen");
            }
            catch (Exception ex) {
                Console.WriteLine("nastala chyby pry praci s souborem!");
                Console.WriteLine(ex.Message);
            }
            Console.Clear();
            using (StreamReader reader = new StreamReader(souborovaCesta))
            {
                string? radek = reader.ReadLine();

                while (radek != null)
                {
                    Console.WriteLine(radek);
                    radek = reader.ReadLine();
                }
                /*
                string? radek;
                while ((radek = reader.readLine()) != null)
                {
                Console.WriteLine(radek);
                }
                */
            }
        }
    }
}
