using Promp.DAL.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Promp.DAL.Entities
{
    public class PromApiToken
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        public string Token { get; set; }
        public string ShopName { get; set; }

        public string UserId { get; set; }
        public User User { get; set; }
    }
}
