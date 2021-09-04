using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Functionality.BusinessObjects
{
    public class PhotoBO
    {
        public int Id { get; set; }
        public int MemberId { get; set; }
        public string PhotoFileName { get; set; }
    }
}
