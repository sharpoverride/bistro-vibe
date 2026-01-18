using System;

namespace CulinaryVault.Shared
{
    public class Instruction
    {
        public Guid Id { get; set; }
        public int StepNumber { get; set; }
        public string Text { get; set; } = string.Empty;      // Required
    }
}
