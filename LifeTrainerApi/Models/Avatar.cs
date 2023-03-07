using LifeTrainerApi.DTO;

namespace LifeTrainerApi.Models
{
    public class Avatar
    {
        public int AvatarId { get; set; }
        public string Email { get; set; }
        public string AvatarName { get; set; }
        public int XPLevel { get; set; }
        public int XP { get; set; }
        public virtual ICollection<Item> Items { get; set; }
        public Avatar() { }
        public Avatar(AvatarDTO dto)
        {
            this.Email = dto.Email;
            this.AvatarName = dto.AvatarName;
            this.XPLevel = dto.XPLevel;
            this.XP = dto.XP;
            this.Items = new List<Item>();
        }

        public Avatar(AvatarDTO dto, int id)
        {
            this.AvatarId = id;
            this.Email = dto.Email;
            this.AvatarName = dto.AvatarName;
            this.XPLevel = dto.XPLevel;
            this.XP = dto.XP;
            this.Items = new List<Item>();
        }
    }
}
