using LearningCenter.API.Learning.Domain.Models;
using LearningCenter.API.Security.Domain.Models;
using LearningCenter.API.Shared.Extensions;
using Microsoft.EntityFrameworkCore;

namespace LearningCenter.API.Shared.Persistence.Contexts;

public class AppDbContext : DbContext
{
    public DbSet<Service> Services { get; set; }
    
    public DbSet<User> Users { get; set; }
    public DbSet<Reserva> Reservas { get; set; }

    public DbSet<Payment>Payments { get; set; }
    public DbSet<TypeUser> TypeUsers { get; set; }
    public DbSet<HelpQuestion> HelpQuestions { get; set; }
    public DbSet<State> States { get; set; }
    public DbSet<Review> Reviews { get; set; }
    public DbSet<FAQ> FAQs { get; set; }

    public DbSet<Pet> Pets { get; set; }

    public AppDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        // Pets
        builder.Entity<Pet>().ToTable("Pets");
        builder.Entity<Pet>().HasKey(p => p.Id);
        builder.Entity<Pet>().Property(p => p.Id).UseIdentityColumn();
        builder.Entity<Pet>().Property(p => p.Name).IsRequired().HasMaxLength(20);
        builder.Entity<Pet>().Property(p => p.Description).IsRequired();
        builder.Entity<Pet>().Property(p => p.UserId).IsRequired();
        builder.Entity<Pet>().Property(p => p.Castrado).IsRequired();
        builder.Entity<Pet>().Property(p => p.Edad).IsRequired();

        builder.Entity<Pet>().HasOne(p => p.User).WithMany(p => p.Pet).HasForeignKey(p => p.UserId);

        // Help Questions
        builder.Entity<HelpQuestion>().ToTable("HelpQuestions");
        builder.Entity<HelpQuestion>().HasKey(p => p.HelpQuestionID);
        builder.Entity<HelpQuestion>().Property(p => p.HelpQuestionID).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<HelpQuestion>().Property(p => p.Title).IsRequired().HasMaxLength(255);
        builder.Entity<HelpQuestion>().Property(p => p.Question).IsRequired();
        builder.Entity<HelpQuestion>().Property(p => p.UserId).IsRequired();

        builder.Entity<HelpQuestion>().HasOne(p => p.User).WithMany(p => p.HelpQuestion).HasForeignKey(p => p.UserId);

        // Reserva   
        builder.Entity<Reserva>().ToTable("Reservas");
        builder.Entity<Reserva>().HasKey(p => p.Id);
        builder.Entity<Reserva>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Reserva>().Property(p => p.ClientPaymentId).IsRequired();
        builder.Entity<Reserva>().Property(p => p.Date).IsRequired();
        builder.Entity<Reserva>().Property(p => p.EndHour).IsRequired();
        builder.Entity<Reserva>().Property(p => p.StartHour).IsRequired();
        builder.Entity<Reserva>().Property(p => p.ServiceProviderId).IsRequired();
        builder.Entity<Reserva>().Property(p => p.EstadoId).IsRequired();
        builder.Entity<Reserva>().HasOne(p => p.ClientPayment).WithMany(p => p.Reservas).HasForeignKey(p => p.ClientPaymentId).OnDelete(DeleteBehavior.Restrict);
        builder.Entity<Reserva>().HasOne(p => p.ServiceProvider).WithMany(p => p.Reservas).HasForeignKey(p => p.ServiceProviderId).OnDelete(DeleteBehavior.Restrict);;
        builder.Entity<Reserva>().HasOne(p => p.Estado).WithMany(p => p.Reservas).HasForeignKey(p => p.EstadoId).OnDelete(DeleteBehavior.Restrict);;


        //Payments
        builder.Entity<Payment>().ToTable("Payments");
        builder.Entity<Payment>().HasKey(p=>p.Id);
        builder.Entity<Payment>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Payment>().Property(p => p.Number).IsRequired().HasMaxLength(16);
    
        builder.Entity<Payment>().HasOne(p=>p.User).WithMany(p=>p.Payments).HasForeignKey(p => p.UserId);
        
        // Relationships
        builder.Entity<Service>()
            .HasOne(p => p.User)
            .WithOne(p => p.Service).HasForeignKey<Service>(p => p.UserId);

        // States
        builder.Entity<State>().ToTable("States");
        builder.Entity<State>().HasKey(p => p.StateID);
        builder.Entity<State>().Property(p => p.StateID).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<State>().Property(p => p.Description).IsRequired().HasMaxLength(255);
        
        // Reviews
        builder.Entity<Review>().ToTable("Reviews");
        builder.Entity<Review>().HasKey(p => p.ReviewId);
        builder.Entity<Review>().Property(p => p.ReviewId).IsRequired().UseIdentityColumn();
        builder.Entity<Review>().Property(p => p.Description).IsRequired().HasMaxLength(255);
        builder.Entity<Review>().Property(p => p.Stars).IsRequired();
        builder.Entity<Review>().HasOne(p=>p.User).WithMany(p=>p.Review).HasForeignKey(p => p.UserId).OnDelete(DeleteBehavior.Restrict);;
        builder.Entity<Review>().HasOne(p=>p.Service).WithMany(p=>p.Review).HasForeignKey(p => p.ServiceId).OnDelete(DeleteBehavior.Restrict);;


        //Service
        builder.Entity<Service>().ToTable("Services");
        builder.Entity<Service>().HasKey(p => p.ServiceId);
        builder.Entity<Service>().Property(p => p.ServiceId).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Service>().Property(p => p.Description).IsRequired();
        builder.Entity<Service>().Property(p => p.Location).IsRequired();
        builder.Entity<Service>().Property(p => p.phone).IsRequired();
        builder.Entity<Service>().Property(p => p.dni).IsRequired();
        builder.Entity<Service>().Property(p => p.Cuidador).IsRequired();

        //TypeUser
        builder.Entity<TypeUser>().ToTable("TypeUsers");
        builder.Entity<TypeUser>().HasKey(p => p.TypeUserID);
        builder.Entity<TypeUser>().Property(p => p.TypeUserID).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<TypeUser>().Property(p => p.Type).IsRequired().HasMaxLength(255);
        
        // FAQ   

        builder.Entity<FAQ>().ToTable("FAQs");
        builder.Entity<FAQ>().HasKey(f => f.FAQID);
        builder.Entity<FAQ>().Property(f => f.Question).IsRequired();
        builder.Entity<FAQ>().Property(f => f.Answer).IsRequired();

        // Users
        builder.Entity<User>().ToTable("Users");
        builder.Entity<User>().HasKey(p => p.Id);
        builder.Entity<User>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<User>().Property(p => p.Mail).IsRequired().HasMaxLength(30);
        builder.Entity<User>().Property(p => p.FirstName).IsRequired();
        builder.Entity<User>().Property(p => p.LastName).IsRequired();
        builder.Entity<User>().Property(p => p.Phone).IsRequired();
        builder.Entity<User>().Property(p => p.Dni).IsRequired();
        builder.Entity<User>().Property(p => p.TypeUserId).IsRequired();

        builder.Entity<Service>().Property(p => p.UserId).IsRequired();

        // Apply Snake Case Naming Convention
        
        builder.UseSnakeCaseNamingConvention();
    }
}