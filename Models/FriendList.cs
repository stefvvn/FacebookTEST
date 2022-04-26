using System;
using System.Collections.Generic;

namespace FacebookTEST.Models
{
    public partial class FriendList
    {
        public int FriendListId { get; set; }
        public int? UserId { get; set; }
        public int? FriendId { get; set; }

        public virtual UserAccountInfo? Friend { get; set; }
        public virtual UserAccountInfo? User { get; set; }
    }
}
