using LifeTrainerApi.Models;

namespace LifeTrainerApi.DTO
{
    public class AvatarDetailsDTO
    {
        public int AvatarId { get; set; }
        public string Email { get; set; }
        public string AvatarName { get; set; }
        public int XPLevel { get; set; }
        public int XP { get; set; }
        public List<Item> Items { get; set; }
    }
}
