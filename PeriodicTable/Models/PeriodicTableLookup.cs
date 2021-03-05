using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Periodic.Models
{
    public class IndexedPeriodicTable : PeriodicTable
    {

        private Dictionary<string, Element> nameIndex;
        private Dictionary<string, Element> symbolIndex;

        [JsonConstructor]
        public IndexedPeriodicTable(Element[] elements) : base(elements)
        {
            nameIndex = new Dictionary<string, Element>();
            symbolIndex = new Dictionary<string, Element>();

            foreach (var element in Elements)
            {
                nameIndex.Add(element.Name.ToLower(), element);
                nameIndex.Add(element.Symbol.ToLower(), element);
            }
        }

        public bool TryGetElementByName(string name, out Element result, bool ignoreCase = true)
            => nameIndex.TryGetValue(ignoreCase ? name.ToLower() : name, out result);

        public bool TryGetElementBySymbol(string symbol, out Element result, bool ignoreCase = true)
            => nameIndex.TryGetValue(ignoreCase ? symbol.ToLower() : symbol, out result);
    }
}