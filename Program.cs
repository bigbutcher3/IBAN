using System;

namespace IBAN
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "IBAN prüfen";
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();

            string filename = "kunden_alt.csv";
            string logfile = "kunden_check.log";

            List<Kunde> kunden = (List<Kunde>)Import.ReadData(filename);

            foreach (Kunde kunde in kunden)
            {
                if (kunde.IBAN == "" || kunde.IBAN == null)
                {
                    Console.WriteLine($"Für Kunde {kunde.Kundennr} ist keine IBAN vorhanden.");
                    SchreibeLog($"Für Kunde {kunde.Kundennr} ist keine IBAN vorhanden.", logfile);
                    kunde.IBAN = kunde.geprüfteIban;
                    kunde.Flag = "2";
                    break;
                }
                kunde.geprüfteIban = Pruefziffern.IbanTest(kunde.BLZ, kunde.Kontonummer, kunde.ISOA2Code);
                if (kunde.geprüfteIban == kunde.IBAN)
                {
                    kunde.Flag = "0";
                }
                else
                {
                    Console.WriteLine($"Die IBAN des Kunden {kunde.Kundennr} ist falsch.");
                    SchreibeLog($"Die IBAN des Kunden {kunde.Kundennr} ist falsch.", logfile);
                    kunde.IBAN = kunde.geprüfteIban;
                    kunde.Flag = "1";
                }
            }
            try
            {
                using (StreamWriter writer = new StreamWriter("kunden_neu.csv"))
                {
                    writer.WriteLine("Kundennr;Vorname;Nachname;Strasse;PLZ;Ort;ISOA2Code;Land;Kontonummer;BLZ;BIC;IBAN;Flag");
                    foreach (Kunde kunde in kunden)
                    {
                        writer.WriteLine($"{kunde.Kundennr};{kunde.Vorname};{kunde.Nachname};{kunde.Strasse};{kunde.PLZ};{kunde.Ort};{kunde.ISOA2Code};{kunde.Land};{kunde.Kontonummer};{kunde.BLZ};{kunde.BIC};{kunde.IBAN};{kunde.Flag}");
                    }
                }
            } catch (Exception ex)
            {
                Console.WriteLine($"Fehler beim Speichern: {ex.Message}");
                SchreibeLog($"Fehler beim Speichern: {ex.Message}", logfile);
            }
            Console.WriteLine("\"L\" zum Löschen der Log-Datei\nBeliebige Taste zum Beenden");
            ConsoleKey key = Console.ReadKey().Key;
            if (key == ConsoleKey.L) LoescheLog(logfile);
        }

        static void LoescheLog(string logfile)
        {
            File.Delete(logfile);
        }

        static void SchreibeLog(string message, string logfile)
        {
            StreamWriter writer = new StreamWriter(logfile, true);
            writer.WriteLine(message);
            writer.Close();
        }
    }
}