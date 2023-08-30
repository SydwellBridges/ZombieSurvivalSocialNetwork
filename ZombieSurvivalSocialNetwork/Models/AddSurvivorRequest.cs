namespace ZombieSurvivalSocialNetwork.Models
{
    public class AddSurvivorRequest
    {
        public string? Name { get; set; }
        public int Age { get; set; }
        public string? Gender { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public bool Infected { get; set; }
        public Inventory? Inventory { get; set; }
    }
}
