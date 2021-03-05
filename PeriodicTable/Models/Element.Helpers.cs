using System;
using System.Linq;

namespace Periodic.Models
{
    public sealed partial class Element
    {
        public int ValenceElectrons => Shells.Last();

        public override string ToString()
        {
            return $"{Name}:\n" +
                    $"Symbol: {Symbol}\n" +
                    $"Valence Electrons: {ValenceElectrons}";
        }
    }
}