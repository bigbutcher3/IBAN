using System;
using System.Security.AccessControl;

namespace IBAN
{
    class Pruefziffern
    {
        public static string IbanTest(string blz, string konto, string isoa2)
        {
            string dings = isoa2.Substring(0,1);
            string bumms = isoa2.Substring(1,1);
            
            switch (dings)
            {
                case "A":
                    dings = "10";
                    break;
                case "B":
                    dings = "11";
                    break;
                case "C":
                    dings = "12";
                    break;
                case "D":
                    dings = "13";
                    break;
                case "E":
                    dings = "14";
                    break;
                case "F":
                    dings = "15";
                    break;
                case "G":
                    dings = "16";
                    break;
                case "H":
                    dings = "17";
                    break;
                case "I":
                    dings = "18";
                    break;
                case "J":
                    dings = "19";
                    break;
                case "K":
                    dings = "20";
                    break;
                case "L":
                    dings = "21";
                    break;
                case "M":
                    dings = "22";
                    break;
                case "N":
                    dings = "23";
                    break;
                case "O":
                    dings = "24";
                    break;
                case "P":
                    dings = "25";
                    break;
                case "Q":
                    dings = "26";
                    break;
                case "R":
                    dings = "27";
                    break;
                case "S":
                    dings = "28";
                    break;
                case "T":
                    dings = "29";
                    break;
                case "U":
                    dings = "30";
                    break;
                case "V":
                    dings = "31";
                    break;
                case "W":
                    dings = "32";
                    break;
                case "X":
                    dings = "33";
                    break;
                case "Y":
                    dings = "34";
                    break;
                case "Z":
                    dings = "35";
                    break;
                default:
                    dings = "00";
                    break;
            }
            switch (bumms)
            {
                case "A":
                    bumms = "10";
                    break;
                case "B":
                    bumms = "11";
                    break;
                case "C":
                    bumms = "12";
                    break;
                case "D":
                    bumms = "13";
                    break;
                case "E":
                    bumms = "14";
                    break;
                case "F":
                    bumms = "15";
                    break;
                case "G":
                    bumms = "16";
                    break;
                case "H":
                    bumms = "17";
                    break;
                case "I":
                    bumms = "18";
                    break;
                case "J":
                    bumms = "19";
                    break;
                case "K":
                    bumms = "20";
                    break;
                case "L":
                    bumms = "21";
                    break;
                case "M":
                    bumms = "22";
                    break;
                case "N":
                    bumms = "23";
                    break;
                case "O":
                    bumms = "24";
                    break;
                case "P":
                    bumms = "25";
                    break;
                case "Q":
                    bumms = "26";
                    break;
                case "R":
                    bumms = "27";
                    break;
                case "S":
                    bumms = "28";
                    break;
                case "T":
                    bumms = "29";
                    break;
                case "U":
                    bumms = "30";
                    break;
                case "V":
                    bumms = "31";
                    break;
                case "W":
                    bumms = "32";
                    break;
                case "X":
                    bumms = "33";
                    break;
                case "Y":
                    bumms = "34";
                    break;
                case "Z":
                    bumms = "35";
                    break;
                default:
                    bumms = "00";
                    break;
            }

            Int32.TryParse(blz + konto + dings + bumms + "00", out int iban);
            int prüfziffer = 98 - (iban % 97);
            return (isoa2 + prüfziffer + blz + konto);
        }
    }
}