using System;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace PeriodicTableService
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum Phase
    {
        [EnumMember(Value = "Gas")]
        Gas,
        [EnumMember(Value = "Liquid")]
        Liquid,
        [EnumMember(Value = "Solid")]
        Solid
    }
}