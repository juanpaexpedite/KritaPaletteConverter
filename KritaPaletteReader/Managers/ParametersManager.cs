using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KritaPaletteReader.Managers
{
    public class ParametersManager
    {
        public static void CallAction(string[] parameters)
        {
            #region Error Handling
            if (!parameters.Any() || parameters.First() == "-h" || parameters.Count() > 4)
            {
                ErrorsManager.HandleError<ParametersManager>(nameof(CallAction), ErrorModes.Parameters);
            }
            else
            {
                var pairs = GetPairs(parameters);

                if(pairs == null || !CheckPairs(pairs))
                {
                    return;
                }
                #endregion

                string input = pairs["-i"];
                string output = pairs["-o"];

                ColorsManager.Process(input, output);
            }
        }

        private static bool CheckPairs(Dictionary<string,string> pairs)
        {
            if (!pairs.ContainsKey("-i") || !pairs.ContainsKey("-o"))
            {
                return false;
            }

            return true;
        }

        private static Dictionary<string, string> GetPairs(string[] parameters)
        {
            //Multipurpose way
            Dictionary<string, string> pairs = new Dictionary<string, string>();

            for(int i=0;i<parameters.Length;i+=2)
            {
                var key = parameters[i];
                var value = parameters[i+1];

                pairs.Add(key, value);
            }

            return pairs;

        }

       
    }
}
