using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Text.RegularExpressions;

namespace _03.StringService
{
    public class StringService : IStringService
    {
        public int GetStringOccurences(string masterString, string childString)
        {
            var match = Regex.Matches(masterString, childString);

            return match.Count;
        }
    }
}
