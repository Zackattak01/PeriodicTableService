using System;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace Periodic.Models
{
    public sealed partial class Element
    {

        [JsonProperty("name")]
        public string Name { get; internal set; }

        [JsonProperty("appearance")]
        public string Appearance { get; internal set; }

        [JsonProperty("atomic_mass")]
        public double AtomicMass { get; internal set; }

        [JsonProperty("boil")]
        public double? Boil { get; internal set; }

        [JsonProperty("category")]
        public string Category { get; internal set; }

        [JsonProperty("color")]
        [Obsolete("This property is currently always null")]
        public string Color { get; internal set; }

        [JsonProperty("density")]
        public double? Density { get; internal set; }

        [JsonProperty("discovered_by")]
        public string DiscoveredBy { get; internal set; }

        [JsonProperty("melt")]
        public double? Melt { get; internal set; }

        [JsonProperty("molar_heat")]
        public double? MolarHeat { get; internal set; }

        [JsonProperty("named_by")]
        public string NamedBy { get; internal set; }

        [JsonProperty("number")]
        public int Number { get; internal set; }

        [JsonProperty("period")]
        public int Period { get; internal set; }

        [JsonProperty("phase")]
        public Phase Phase { get; internal set; }

        [JsonProperty("source")]
        public Uri Source { get; internal set; }

        [JsonProperty("spectral_img")]
        public Uri SpectralImg { get; internal set; }

        [JsonProperty("summary")]
        public string Summary { get; internal set; }

        [JsonProperty("symbol")]
        public string Symbol { get; internal set; }

        [JsonProperty("xpos")]
        public int Xpos { get; internal set; }

        [JsonProperty("ypos")]
        public int Ypos { get; internal set; }

        [JsonProperty("shells")]
        public int[] Shells { get; internal set; }

        [JsonProperty("electron_configuration")]
        public string ElectronConfiguration { get; internal set; }

        [JsonProperty("electron_configuration_semantic")]
        public string ElectronConfigurationSemantic { get; internal set; }

        [JsonProperty("electron_affinity")]
        public double? ElectronAffinity { get; internal set; }

        [JsonProperty("electronegativity_pauling")]
        public double? ElectronegativityPauling { get; internal set; }

        [JsonProperty("ionization_energies")]
        public double[] IonizationEnergies { get; internal set; }

        [JsonProperty("cpk-hex")]
        public string CpkHex { get; internal set; }
    }
}
