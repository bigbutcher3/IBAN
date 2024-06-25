namespace IBAN
{
    class Kunde
    {
        public required string Kundennr { get; set; }
        public required string Vorname { get; set; }
        public required string Nachname { get; set; }
        public required string Strasse { get; set; }
        public required string PLZ { get; set; }
        public required string Ort { get; set; }
        public required string ISOA2Code { get; set; }
        public required string Land { get; set; }
        public required string Kontonummer { get; set; }
        public required string BLZ { get; set; }
        public required string BIC { get; set; }
        public string ?IBAN { get; set; }
        public string ?Flag { get; set; }
        public string ?geprüfteIban { get; set; }
    }
}