namespace Promp.Models.Prom
{
    public class PromApiTokenModel
    {
        public string Id { get; set; }
        public string Token { get; set; }
        public string ShopName { get; set; }
        public bool IsValid { get; set; }
        public string UserId { get; set; }
    }
}
