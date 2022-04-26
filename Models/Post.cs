using System;
using System.Collections.Generic;

namespace FacebookTEST.Models
{
    public partial class Post
    {
        public Post()
        {
            PostLikes = new HashSet<PostLike>();
        }

        public int PostId { get; set; }
        public int? UserId { get; set; }
        public string? Content { get; set; }
        public string? Title { get; set; }
        public DateTime? DateMade { get; set; }

        public virtual UserAccountInfo? User { get; set; }
        public virtual ICollection<PostLike> PostLikes { get; set; }
    }
}
