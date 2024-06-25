using System;

namespace IBAN
{
    class Import
    {
        public static List<Kunde> kunden = new List<Kunde>();
        public static object ReadData(string filename)
        {
            using (StreamReader reader = new StreamReader(filename))
            {
                
                string line = reader.ReadLine();
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split(';');
                    Kunde kunde = new Kunde
                    {
                        Kundennr = parts[0],
                        Vorname = parts[1],
                        Nachname = parts[2],
                        Strasse = parts[3],
                        PLZ = parts[4],
                        Ort = parts[5],
                        ISOA2Code = parts[6],
                        Land = parts[7],
                        Kontonummer = parts[8],
                        BLZ = parts[9],
                        BIC = parts[10],
                        IBAN = parts[11],
                        Flag = parts[12]
                    };
                    kunden.Add(kunde);
                }
            }
            return kunden;
        }
    }
}