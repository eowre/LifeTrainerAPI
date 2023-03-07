using LifeTrainerApi.DTO;

namespace LifeTrainerApi.Models
{
    public class Item
    {
        public int ItemId { get; set; }
        public int AvatarID { get; set; }
        public string ItemName { get; set; }
        public string description {  get; set; }
        public int RewardAmount { get; set; }
        public int CompletionCount { get; set; }

        public Item() { }
        public Item(ItemsDTO dto)
        {

            this.AvatarID = dto.AvatarID;
            this.ItemName = dto.ItemName;
            this.description = dto.Description;
            this.RewardAmount = dto.RewardAmount;
            this.CompletionCount = dto.CompletionCount;
        }

        public Item(ItemsDTO dto, int id)
        {
            this.ItemId = id;
            this.AvatarID = dto.AvatarID;
            this.ItemName = dto.ItemName;
            this.description = dto.Description;
            this.RewardAmount = dto.RewardAmount;
            this.CompletionCount = dto.CompletionCount;
        }
    }
}
