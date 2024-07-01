using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ChatApp.Domain.Models;

public partial class ChatAppContext : DbContext
{
    public ChatAppContext()
    {
    }

    public ChatAppContext(DbContextOptions<ChatAppContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Session> Sessions { get; set; }

    public virtual DbSet<SessionDetail> SessionDetails { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=ChatApp;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Session>(entity =>
        {
            entity.ToTable("Session");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.EndAt)
                .HasColumnType("datetime")
                .HasColumnName("End_At");
            entity.Property(e => e.ReceiverId).HasColumnName("Receiver_ID");
            entity.Property(e => e.SessionRefId)
                .HasMaxLength(50)
                .HasColumnName("Session_Ref_ID");
            entity.Property(e => e.StartAt)
                .HasColumnType("datetime")
                .HasColumnName("Start_At");
            entity.Property(e => e.UserId).HasColumnName("User_ID");

            entity.HasOne(d => d.Receiver).WithMany(p => p.SessionReceivers)
                .HasForeignKey(d => d.ReceiverId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Session_User1");

            entity.HasOne(d => d.User).WithMany(p => p.SessionUsers)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Session_User");
        });

        modelBuilder.Entity<SessionDetail>(entity =>
        {
            entity.ToTable("Session_Detail");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.ConversationContent)
                .HasColumnType("ntext")
                .HasColumnName("Conversation_Content");
            entity.Property(e => e.SessionId).HasColumnName("Session_ID");

            entity.HasOne(d => d.Session).WithMany(p => p.SessionDetails)
                .HasForeignKey(d => d.SessionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Session_Detail_Session");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("User");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Password)
                .HasMaxLength(128)
                .IsFixedLength();
            entity.Property(e => e.UserName)
                .HasMaxLength(128)
                .IsFixedLength();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
