using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphQLApi.Graph.Model
{
    public class DocumentModel
    {
        public int DocumentId { get; set; }
        public string Body { get; set; }
        public string ReferenceId { get; set; }

        public int CreateUserId { get; set; }
        public UserModel CreatedUser { get; set; }
    }
}
