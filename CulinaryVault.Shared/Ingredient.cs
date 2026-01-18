using System;

namespace CulinaryVault.Shared
{
    public class Ingredient
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;      // Required
        public double Amount { get; set; }
        public string Unit { get; set; } = string.Empty;
        public int Order { get; set; }
    }
}
