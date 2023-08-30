using Microsoft.EntityFrameworkCore;

namespace ZombieSurvivalSocialNetwork.Models
{
    [Owned]
    public class Inventory
    {
        public int Water { get; set; }
        public int Food { get; set; }
        public int Medication { get; set; }
        public int Ammunition { get; set; }
    }
}
