using LifeTrainerApi.Models;

namespace LifeTrainerApi.DTO
{
    public class AvatarDTO
    {
        public string Email { get; set; }
        public string AvatarName { get; set; }
        public int XPLevel { get; set; }
        public int XP { get; set; }
    }
}