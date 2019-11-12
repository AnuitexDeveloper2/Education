using EducationApp.BusinessLogicLayer.Models.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EducationApp.PresentationLayer.Helpers
{
    public class RefreshToken
    {
        [Key]
        public string token { get; set; }
        public string JwtId { get; set; }
        public DateTime CreationData { get; set; }
        public DateTime ExpireDate { get; set; }
        public bool Used { get; set; }
        public bool InValided { get; set; }
        public long UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        public UserItemModel UserItemModel { get; set; }
    }
}
