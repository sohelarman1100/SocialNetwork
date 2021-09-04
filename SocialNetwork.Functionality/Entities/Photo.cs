using SocialNetwork.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Functionality.Entities
{
    public class Photo : IEntity<int>
    {
        public int Id { get; set; }
        public int MemberId { get; set; }
        public string PhotoFileName { get; set; }
        public Member Member { get; set; }
    }
}
