using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuoApiClientGUI.Models.Api
{


    public class QueryParameters
{
        public string Name { get; set; }
        public string Path { get; set; }
        public string Method { get; set; }
        public string[] RawParameters{ get; set; }
        public Dictionary<string, string> Parameters = new Dictionary<string, string>();
        public bool AddParametersToUri { get; set; }

        public void SetParameters(string[] values)
        {
            if (values.Length != RawParameters.Length)
            {
                throw new ArgumentException("The value array must have the same length as the parameter array.");
            }

            for (int i = 0; i<RawParameters.Length;i++)
            {
                Parameters.Add(RawParameters[i],values[i]);
            }

            if (AddParametersToUri)
            {
                var sb = new StringBuilder();
                for (int i = 0; i < Parameters.Count; i++)
                {
                    sb.Append(Parameters.Keys.ElementAt(i));
                    sb.Append('=');
                    sb.Append(Parameters.Values.ElementAt(i));
                    while (i != Parameters.Count - 1)
                    { sb.Append('&'); }
                }
                this.Path = Path + '?' + sb.ToString();
            }
        }

}


}
