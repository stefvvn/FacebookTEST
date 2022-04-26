using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace FacebookTEST.Models
{
    public partial class FacebookContext : DbContext
    {
        private static string ConnectionString
        {
            get
            {
                //return "Data Source = DESKTOP-ORJTLLV\\SQLEXPRESS; Initial Catalog = praksaDrustvenaMreza; Integrated Security = SSPI;";
                return "Data Source = DESKTOP-ORJTLLV\\SQLEXPRESS; Initial Catalog = Facebook;Integrated Security = SSPI;";
                //return "Server=DESKTOP-ORJTLLV\\SQLEXPRESS;Database=Facebook;Trusted_Connection=True;";
            }
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured)
        //    {
        //        optionsBuilder.UseSqlServer(ConnectionString);
        //    }
    //}

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
            optionsBuilder.UseSqlServer(ConnectionString);
    }

    public FacebookContext()
        {
        }

        public FacebookContext(DbContextOptions<FacebookContext> options)
            : base(options)
        {
        }

        public virtual DbSet<FriendList> FriendLists { get; set; } = null!;
        public virtual DbSet<Post> Posts { get; set; } = null!;
        public virtual DbSet<PostLike> PostLikes { get; set; } = null!;
        public virtual DbSet<UserAccountInfo> UserAccountInfos { get; set; } = null!;

       

        public void SetConnectionString()
        {
        }

     

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FriendList>(entity =>
            {
                entity.ToTable("friendList");

                entity.Property(e => e.FriendListId).HasColumnName("friendListId");

                entity.Property(e => e.FriendId).HasColumnName("friendId");

                entity.Property(e => e.UserId).HasColumnName("userId");

                entity.HasOne(d => d.Friend)
                    .WithMany(p => p.FriendListFriends)
                    .HasForeignKey(d => d.FriendId)
                    .HasConstraintName("FK__friendLis__frien__300424B4");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.FriendListUsers)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__friendLis__userI__2F10007B");
            });

            modelBuilder.Entity<Post>(entity =>
            {
                entity.ToTable("posts");

                entity.Property(e => e.PostId).HasColumnName("postId");

                entity.Property(e => e.Content)
                    .HasColumnType("text")
                    .HasColumnName("content");

                entity.Property(e => e.DateMade)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("dateMade")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Title)
                    .HasColumnType("text")
                    .HasColumnName("title");

                entity.Property(e => e.UserId).HasColumnName("userId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Posts)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__posts__userId__286302EC");
            });

            modelBuilder.Entity<PostLike>(entity =>
            {
                entity.ToTable("postLikes");

                entity.Property(e => e.PostLikeId).HasColumnName("postLikeId");

                entity.Property(e => e.PostId).HasColumnName("postId");

                entity.Property(e => e.PostLikeStatus).HasColumnName("postLikeStatus");

                entity.Property(e => e.UserId).HasColumnName("userId");

                entity.HasOne(d => d.Post)
                    .WithMany(p => p.PostLikes)
                    .HasForeignKey(d => d.PostId)
                    .HasConstraintName("FK__postLikes__postI__2B3F6F97");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.PostLikes)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__postLikes__userI__2C3393D0");
            });

            modelBuilder.Entity<UserAccountInfo>(entity =>
            {
                entity.HasKey(e => e.UserIdNumber)
                    .HasName("PK__userAcco__6677160646D1DAC2");

                entity.ToTable("userAccountInfo");

                entity.Property(e => e.UserIdNumber).HasColumnName("userIdNumber");

                entity.Property(e => e.City)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("city");

                entity.Property(e => e.DateMade)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("dateMade")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DateOfBirth)
                    .HasColumnType("date")
                    .HasColumnName("dateOfBirth");

                entity.Property(e => e.EmailAddress)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("emailAddress");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("firstName");

                entity.Property(e => e.Gender).HasColumnName("gender");

                entity.Property(e => e.LastName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("lastName");

                entity.Property(e => e.ProfileDescription)
                    .HasColumnType("text")
                    .HasColumnName("profileDescription");

                entity.Property(e => e.UserName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("userName");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
