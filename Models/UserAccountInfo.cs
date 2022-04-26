using System;
using System.Collections.Generic;

namespace FacebookTEST.Models
{
    public partial class UserAccountInfo
    {
        public UserAccountInfo()
        {
            FriendListFriends = new HashSet<FriendList>();
            FriendListUsers = new HashSet<FriendList>();
            PostLikes = new HashSet<PostLike>();
            Posts = new HashSet<Post>();
        }

        public int UserIdNumber { get; set; }
        public string? UserName { get; set; }
        public string? EmailAddress { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? City { get; set; }
        public byte? Gender { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? ProfileDescription { get; set; }
        public DateTime? DateMade { get; set; }

        public virtual ICollection<FriendList> FriendListFriends { get; set; }
        public virtual ICollection<FriendList> FriendListUsers { get; set; }
        public virtual ICollection<PostLike> PostLikes { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
    }
}
