using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Plantopia.WebApi.Data.Model.Person
{
    public class User
    {
        [ForeignKey("Account")] public int UserId { get; set; }

        [StringLength(32)] public string NickName { get; set; }

        public string AvatarPath { get; set; }

        public int Experience { get; set; }

        public virtual Account Account { get; set; }
    }
}
