namespace LifeTrainerApi.Models
{
    public class Item
    {
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public int RewardAmount { get; set; }
        public int CompletionCount { get; set; }
    }
}
