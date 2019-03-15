using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public string UserName { get; set; }
        public UserStatus UserStatus { get; set; }

        [InverseProperty("CreatedUser")]
        public List<Document> CreatedDocuments { get; set; }
}

    public enum UserStatus
    {
        Active,
        Expire,

    }
}
