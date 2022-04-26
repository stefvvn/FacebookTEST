using System;
using System.Collections.Generic;

namespace FacebookTEST.Models
{
    public partial class PostLike
    {
        public int PostLikeId { get; set; }
        public int? PostId { get; set; }
        public int? UserId { get; set; }
        public byte? PostLikeStatus { get; set; }

        public virtual Post? Post { get; set; }
        public virtual UserAccountInfo? User { get; set; }
    }
}
