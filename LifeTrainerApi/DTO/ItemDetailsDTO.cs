namespace LifeTrainerApi.DTO
{
    public class ItemDetailsDTO
    {
        public int ItemId { get; set; }
        public int AvatarID { get; set; }
        public string ItemName { get; set; }
        public string Description { get; set; }
        public int RewardAmount { get; set; }
        public int CompletionCount { get; set; }
    }
}
