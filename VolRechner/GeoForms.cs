using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
namespace VolRechner
{
    public class GeoForms
    {
        string? entry = Console.ReadLine();
        string[,] ausgabeHuelle = new string[2, 3] { { " Der Umfang beträgt: ", " Die Fläche beträgt: ", " Das Volumen beträgt: " }, { "cm", "cm²", "cm³" } };
        int stringArrayCounter = 0;
        public bool entryException = false;
        public double[] paramCol = new double[4] { 0, 0, 0, 0 };
        string currentMethodName = "";
        public string correctedEntry1 = "";
        int[] lengthCount = new int[3] { 0, 0, 0 };
        public int paramCount = 0;
        public ParameterInfo[] paramInfo;
        public string universalizeEntry()
        {
            entry = entry.ToUpper();
            string methodEntry = entry;
            int lastentryChar = entry.Length - 1;
            int middleEntry = entry.Length - 2;
            if (lastentryChar > 0 && middleEntry > 0)
            {
                methodEntry = entry.Substring(0, 1) + entry.Substring(1, middleEntry).ToLower() + entry.Substring(lastentryChar);
            }
            entry = methodEntry;
            return methodEntry;
        }
        public void dictUtility(IDictionary<string, Delegate> _methodDict)
        {
            int taube = entry.Length;
            if (taube >= 4)
            {
                taube = 2;
            }
            foreach (KeyValuePair<string, Delegate> kvp in _methodDict)
            {
                if (kvp.Key.Substring(0, taube).Contains(entry) || kvp.Key.Contains(entry))
                {
                    currentMethodName = kvp.Key;
                    entryException = true;
                    lengthCount[0] = currentMethodName.Length - 1;
                    lengthCount[1] = currentMethodName.Length - 2;
                    lengthCount[2] = currentMethodName.IndexOf(":") + 1;
                    correctedEntry1 = currentMethodName.Substring(lengthCount[2], 1).ToUpper() + currentMethodName.Substring(lengthCount[2] + 1, lengthCount[1] - lengthCount[2]) + currentMethodName.Substring(lengthCount[0], 1).ToUpper();
                    break;
                }
            }
        }
        public void MethodReflections()
        {
            Type type = typeof(MyCalculations);
            MethodInfo methodInfo = type.GetMethod(correctedEntry1, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            int _paramCount = methodInfo.GetParameters().Count();
            ParameterInfo[] _paramInfo = methodInfo.GetParameters();
            paramInfo = _paramInfo;
            paramCount = _paramCount;
        }
        public void outputLineNumber()
        {
            if (currentMethodName.Substring(lengthCount[0], 1).Equals("V"))
            {
                stringArrayCounter = 2;
            }
            else if (currentMethodName.Substring(lengthCount[0], 1).Equals("F"))
            {
                stringArrayCounter = 1;
            }
        }
        public void Ausgabe(IDictionary<string, Delegate> _myDictionary)
        {
            foreach (KeyValuePair<string, Delegate> kvp in _myDictionary)
            {
                if (currentMethodName == kvp.Key)
                {
                    switch (paramCount)
                    {
                        case 1:
                            Console.WriteLine(ausgabeHuelle[0, stringArrayCounter] + _myDictionary[currentMethodName].DynamicInvoke(paramCol[0]) + ausgabeHuelle[1, stringArrayCounter]);
                            break;
                        case 2:
                            Console.WriteLine(ausgabeHuelle[0, stringArrayCounter] + _myDictionary[currentMethodName].DynamicInvoke(paramCol[0], paramCol[1]) + ausgabeHuelle[1, stringArrayCounter]);
                            break;
                        case 3:
                            Console.WriteLine(ausgabeHuelle[0, stringArrayCounter] + _myDictionary[currentMethodName].DynamicInvoke(paramCol[0], paramCol[1], paramCol[2]) + ausgabeHuelle[1, stringArrayCounter]);
                            break;
                        case 4:
                            Console.WriteLine(ausgabeHuelle[0, stringArrayCounter] + _myDictionary[currentMethodName].DynamicInvoke(paramCol[0], paramCol[1], paramCol[2], paramCol[3]) + ausgabeHuelle[1, stringArrayCounter]);
                            break;
                    }
                }
            }
        }
    }
}
