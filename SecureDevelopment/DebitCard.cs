using System;

namespace SecureDevelopment
{
    public class DebitCard
    {
        public int Id { get; set; }
        public string CardHolderName { get; set; }
        public string CardNumber { get; set; }
        public DateTime DateOfUse { get; set; }
    }
}