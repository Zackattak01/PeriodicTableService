using System;
using Newtonsoft.Json;

namespace Periodic.Models
{
    public class PeriodicTable
    {
        [JsonProperty("elements")]
        public Element[] Elements { get; internal set; }

        [JsonConstructor]
        internal PeriodicTable(Element[] elements)
        {
            Elements = elements;
        }
    }
}