using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace VolRechner
{
    public class Program
    {
        // Das Programm ist als Übungsprogramm gedacht und absichtlich für den Lerneffekt verüberkompliziert. Es wurde versucht im Code Redundanzen zu vermeiden und gegen mögliche Fehleingaben abzusichern.
        static void Main(string[] args)
        {
            do
            {
                Console.Clear();
                Console.WriteLine(@" Bitte geben Sie die Nummer für die zu berechnende Form ein.
 Jeweils ungerade Zahlen für den Umfang und gerade Zahlen für den Flächeninhalt 
 (1-2) RechteckU/F | (3-4) QuadratU/F | (5-6) ParallelogrammU/F 
 (7-8) TrapezU/F | (9-10) DeltoidU/F | (11-12) DreieckU/F 
 (13-14) RechtwinkligesDreieckU/F | (15-16) GleichseitigesDreieckU/F | (17-18) KreisU/F 
 (19-20) KreissektorU/F | Ausnahme: (21) DodekaederV (Volumen)");
                Console.Write("\n Ihre Auswahl:");
                MyCalculations calc = new MyCalculations();
                GeoForms filter = new GeoForms();
                string entry = filter.universalizeEntry();
                //Delegat Directory für dynamischen Methoden call
                IDictionary<string, Delegate> methodDict = new Dictionary<string, Delegate>()
                {
                    { "1:RechteckU",  new Func<double,double>(calc.RechteckU) },
                    { "2:RechteckF", new Func<double, double>(calc.RechteckF) },
                    { "3:QuadratU", new Func<double, double, double>(calc.QuadratU) },
                    { "4:QuadratF", new Func<double,double, double>(calc.QuadratF) },
                    { "5:ParallelogrammU", new Func<double, double,double>(calc.ParallelogrammU) },
                    { "6:ParallelogrammF", new Func<double,double,double>(calc.ParallelogrammF) },
                    { "7:TrapezU", new Func<double, double, double, double, double>(calc.TrapezU) },
                    { "8:TrapezF", new Func<double, double, double, double>(calc.TrapezF) },
                    { "9:DeltoidU", new Func<double, double, double>(calc.DeltoidU) },
                    { "10:DeltoidF", new Func<double, double, double>(calc.DeltoidF) },
                    { "11:DreieckU", new Func<double, double, double, double>(calc.DreieckU) },
                    { "12:DreieckF", new Func<double, double, double>(calc.DreieckF) },
                    { "13:RechtwinkligesdreieckU", new Func <double, double, double, double>(calc.RechtwinkligesdreieckU) },
                    { "14:RechtwinkligesdreieckF", new Func<double, double, double>(calc.RechtwinkligesdreieckF) },
                    { "15:GleichseitigesdreieckU", new Func<double, double>(calc.GleichseitigesdreieckU) },
                    { "16:GleichseitigesdreieckF", new Func<double, double>(calc.GleichseitigesdreieckF) },
                    { "17:KreisU", new Func<double, double>(calc.KreisU) },
                    { "18:KreisF", new Func<double, double>(calc.KreisF) },
                    { "19:KreissektorU", new Func<double, double, double>(calc.KreissektorU) },
                    { "20:KreissektorF", new Func<double, double, double>(calc.KreissektorF) },
                    { "21:DodekaederV", new Func<double, double>(calc.DodekaederV) }
                };
                filter.dictUtility(methodDict);
                if (filter.entryException == false || entry == "")
                {
                    Console.WriteLine(" False input");
                    goto Restart;
                }
                filter.MethodReflections();
                string[] paramName;
                paramName = new string[4];
                for (int i = 0; i < filter.paramCount; i++)
                {
                    paramName[i] = Convert.ToString(filter.paramInfo[i]).Remove(0, 7);
                    Console.Write(" " + paramName[i] + ":");
                    try
                    {
                        filter.paramCol[i] = Convert.ToDouble(Console.ReadLine());
                    }
                    catch
                    {
                        Console.WriteLine(" False input");
                        goto Restart;
                    }
                }
                filter.outputLineNumber();
                filter.Ausgabe(methodDict);
            Restart:
                Console.WriteLine("\n Want to stop? Press E");
            }
            while (Console.ReadKey().Key != ConsoleKey.E);
        }
    }
}
