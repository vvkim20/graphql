using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{

    [Serializable]
    public class Document
    {
        [Key]
        public int DocumentId { get; set;  }
        public string Body { get; set; }
        public string ReferenceId { get; set; }
        public TypeofDocument TypeofDocument { get; set; }

        public int CreateUserId { get; set; }
        public User CreatedUser { get; set; }
    }
}
