using Microsoft.EntityFrameworkCore;

namespace ProjetoWeb.Models
{
    public class WebApiContext : DbContext
    {
        public WebApiContext(DbContextOptions options) : base(options) { }

        public DbSet<Profile> Profiles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<PaymentType> PaymentTypes { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<ContentManagement> ContentManagements { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Telephone> Telephones { get; set; }
        public DbSet<StudentPointsClass> StudentPointsClasses { get; set; }
        public DbSet<StudentCheckin> StudentCheckins { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Profile>(entity =>
            {
                entity.ToTable("Profile");
                entity.HasKey(e => e.IdProfile);
                entity.Property(e => e.IdProfile).HasColumnName("id_profile").IsRequired();
                entity.Property(e => e.Name).HasColumnName("name").HasMaxLength(255);
                entity.Property(e => e.NormalizedName)
                    .HasColumnName("normalized_name").HasMaxLength(255);
                entity.Property(e => e.Active).HasColumnName("active").IsRequired();
                entity.Property(e => e.CreatedAt).HasColumnName("created_at")
                    .HasColumnType("datetime").ValueGeneratedOnAdd().IsRequired();
                entity.Property(e => e.UpdatedAt).HasColumnName("updated_at")
                    .HasColumnType("datetime").ValueGeneratedOnAddOrUpdate().IsRequired();
                entity.Property(e => e.DeletedAt).HasColumnName("deleted_at").HasColumnType("datetime");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");
                entity.HasKey(e => e.IdUser);
                entity.Property(e => e.IdUser).HasColumnName("id_user").IsRequired();
                entity.Property(e => e.IdAdmin).HasColumnName("id_admin");
                entity.Property(e => e.IdStudent).HasColumnName("id_student");
                entity.Property(e => e.IdProfile).HasColumnName("id_profile").IsRequired();
                entity.Property(e => e.Email).HasColumnName("email").HasMaxLength(255)
                    .IsRequired().IsUnicode(false);
                entity.Property(e => e.Password).HasColumnName("password").HasMaxLength(255)
                    .IsRequired().IsUnicode(false);
                entity.Property(e => e.CreatedAt).HasColumnName("created_at")
                    .HasColumnType("datetime").ValueGeneratedOnAdd().IsRequired();
                entity.Property(e => e.UpdatedAt).HasColumnName("updated_at")
                    .HasColumnType("datetime").ValueGeneratedOnAddOrUpdate().IsRequired();
                entity.Property(e => e.DeletedAt).HasColumnName("deleted_at").HasColumnType("datetime");

                entity.HasOne(e => e.Profile)
                    .WithMany()
                    .HasForeignKey(e => e.IdProfile)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(u => u.Admin)
                    .WithMany()
                    .HasForeignKey(u => u.IdAdmin);

                entity.HasOne(u => u.Student)
                    .WithMany()
                    .HasForeignKey(u => u.IdStudent);
            });

            modelBuilder.Entity<Address>(entity =>
            {
                entity.ToTable("Address");
                entity.HasKey(e => e.IdAddress);
                entity.Property(e => e.IdAddress).HasColumnName("id_address");
                entity.Property(e => e.Country).HasMaxLength(200).HasColumnName("country");
                entity.Property(e => e.State).HasMaxLength(200).HasColumnName("state");
                entity.Property(e => e.City).HasMaxLength(200).HasColumnName("city");
                entity.Property(e => e.Street).HasMaxLength(200).HasColumnName("street");
                entity.Property(e => e.Number).HasColumnName("number");
                entity.Property(e => e.Neighborhood).HasMaxLength(200).HasColumnName("neighborhood");
                entity.Property(e => e.Complement).HasMaxLength(200).HasColumnName("complement");
                entity.Property(e => e.CreatedAt).HasColumnName("created_at")
                    .HasColumnType("datetime").ValueGeneratedOnAdd().IsRequired();
                entity.Property(e => e.UpdatedAt).HasColumnName("updated_at")
                    .HasColumnType("datetime").ValueGeneratedOnAddOrUpdate().IsRequired();
                entity.Property(e => e.DeletedAt).HasColumnName("deleted_at").HasColumnType("datetime");
            });

            modelBuilder.Entity<Genre>(entity =>
            {
                entity.ToTable("Genre");
                entity.HasKey(e => e.IdGenre);
                entity.Property(e => e.IdGenre).HasColumnName("id_genre");
                entity.Property(e => e.Name).HasColumnName("name");
                entity.Property(e => e.NormalizedName).HasColumnName("normalized_name");
                entity.Property(e => e.Active).HasColumnName("active");
                entity.Property(e => e.CreatedAt).HasColumnName("created_at")
                    .HasColumnType("datetime").ValueGeneratedOnAdd().IsRequired();
                entity.Property(e => e.UpdatedAt).HasColumnName("updated_at")
                    .HasColumnType("datetime").ValueGeneratedOnAddOrUpdate().IsRequired();
                entity.Property(e => e.DeletedAt).HasColumnName("deleted_at").HasColumnType("datetime");
            });

            modelBuilder.Entity<PaymentType>(entity =>
            {
                entity.ToTable("PaymentType");
                entity.HasKey(e => e.IdPaymentType);
                entity.Property(e => e.IdPaymentType).HasColumnName("id_payment_type");
                entity.Property(e => e.Name).HasColumnName("name");
                entity.Property(e => e.CreatedAt).HasColumnName("created_at")
                    .HasColumnType("datetime").ValueGeneratedOnAdd().IsRequired();
                entity.Property(e => e.UpdatedAt).HasColumnName("updated_at")
                    .HasColumnType("datetime").ValueGeneratedOnAddOrUpdate().IsRequired();
                entity.Property(e => e.DeletedAt).HasColumnName("deleted_at").HasColumnType("datetime");
            });

            modelBuilder.Entity<Teacher>(entity =>
            {
                entity.ToTable("Teacher");
                entity.HasKey(e => e.IdTeacher);
                entity.Property(e => e.IdTeacher).HasColumnName("id_teacher");
                entity.Property(e => e.Name).HasColumnName("name");
                entity.Property(e => e.CreatedAt).HasColumnName("created_at")
                    .HasColumnType("datetime").ValueGeneratedOnAdd().IsRequired();
                entity.Property(e => e.UpdatedAt).HasColumnName("updated_at")
                    .HasColumnType("datetime").ValueGeneratedOnAddOrUpdate().IsRequired();
                entity.Property(e => e.DeletedAt).HasColumnName("deleted_at").HasColumnType("datetime");
            });

            modelBuilder.Entity<Admin>(entity =>
            {
                entity.ToTable("Admin");
                entity.HasKey(e => e.IdAdmin);
                entity.Property(e => e.IdAdmin).HasColumnName("id_admin");
                entity.Property(e => e.Name).HasColumnName("name").HasMaxLength(255);
                entity.Property(e => e.SocialName).HasColumnName("social_name").HasMaxLength(255);
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.ToTable("Student");
                entity.HasKey(e => e.IdStudent);
                entity.Property(e => e.IdStudent).HasColumnName("id_student");
                entity.Property(e => e.IdGenre).HasColumnName("id_genre");
                entity.Property(e => e.IdAddress).HasColumnName("id_address");
                entity.Property(e => e.Name).HasColumnName("name").HasMaxLength(255);
                entity.Property(e => e.SocialName).HasColumnName("social_name").HasMaxLength(255);
                entity.Property(e => e.BirthDate).HasColumnName("birth_date");
                entity.Property(e => e.IsBlocked).HasColumnName("is_blocked");
                entity.Property(e => e.BlockDescription).HasColumnName("block_description");
                entity.Property(e => e.ImageProfile).HasColumnName("image_profile");
                entity.HasOne(e => e.Genre).WithMany().HasForeignKey(e => e.IdGenre);
                entity.HasOne(e => e.Address).WithMany().HasForeignKey(e => e.IdAddress);
            });

            modelBuilder.Entity<Status>(entity =>
            {
                entity.ToTable("Status");
                entity.HasKey(e => e.IdStatus);
                entity.Property(e => e.IdStatus).HasColumnName("id_status").IsRequired();
                entity.Property(e => e.Name).HasColumnName("name").HasMaxLength(255);
                entity.Property(e => e.NormalizedName).HasColumnName("normalized_name").HasMaxLength(255);
                entity.Property(e => e.Active).HasColumnName("active");
                entity.Property(e => e.CreatedAt).HasColumnName("created_at")
                    .HasColumnType("datetime").ValueGeneratedOnAdd().IsRequired();
                entity.Property(e => e.UpdatedAt).HasColumnName("updated_at")
                    .HasColumnType("datetime").ValueGeneratedOnAddOrUpdate().IsRequired();
                entity.Property(e => e.DeletedAt).HasColumnName("deleted_at").HasColumnType("datetime");
            });

            modelBuilder.Entity<Exercise>(entity =>
            {
                entity.ToTable("Exercise");
                entity.HasKey(e => e.IdExercise);
                entity.Property(e => e.IdExercise).HasColumnName("id_exercise");
                entity.Property(e => e.Description).HasColumnName("description").HasMaxLength(200);
                entity.Property(e => e.CreatedAt).HasColumnName("created_at")
                    .HasColumnType("datetime").ValueGeneratedOnAdd().IsRequired();
                entity.Property(e => e.UpdatedAt).HasColumnName("updated_at")
                    .HasColumnType("datetime").ValueGeneratedOnAddOrUpdate().IsRequired();
                entity.Property(e => e.DeletedAt).HasColumnName("deleted_at").HasColumnType("datetime");
            });

            modelBuilder.Entity<Class>(entity =>
            {
                entity.ToTable("Class");
                entity.HasKey(e => e.IdClass);
                entity.Property(e => e.IdClass).HasColumnName("id_class");
                entity.Property(e => e.Name).HasColumnName("name").HasMaxLength(200);
                entity.Property(e => e.Date).HasColumnName("date");
                entity.Property(e => e.StartHour).HasColumnName("start_hour");
                entity.Property(e => e.EndHour).HasColumnName("end_hour");
                entity.Property(e => e.Description).HasColumnName("description").HasColumnType("text");
                entity.Property(e => e.CreatedAt).HasColumnName("created_at")
                    .HasColumnType("datetime").ValueGeneratedOnAdd().IsRequired();
                entity.Property(e => e.UpdatedAt).HasColumnName("updated_at")
                    .HasColumnType("datetime").ValueGeneratedOnAddOrUpdate().IsRequired();
                entity.Property(e => e.DeletedAt).HasColumnName("deleted_at").HasColumnType("datetime");
                entity.HasOne(d => d.Status).WithMany().HasForeignKey(d => d.StatusId)
                    .HasConstraintName("fk_class_status");
                entity.HasOne(d => d.Teacher).WithMany().HasForeignKey(d => d.TeacherId)
                    .HasConstraintName("fk_class_teacher");
            });

            modelBuilder.Entity<ContentManagement>(entity =>
            {
                entity.ToTable("ContentManagement");
                entity.HasKey(e => e.IdContentManagement);
                entity.Property(e => e.IdContentManagement).HasColumnName("id_content_management")
                    .IsRequired();
                entity.Property(e => e.IdAddress).HasColumnName("id_address");
                entity.Property(e => e.IdAdmin).HasColumnName("id_admin");
                entity.Property(e => e.Title).HasColumnName("titulo").HasMaxLength(255);
                entity.Property(e => e.SubTitle).HasColumnName("subTitulo").HasMaxLength(200);
                entity.Property(e => e.AboutDescription).HasColumnName("about_description").HasColumnType("text");
                entity.Property(e => e.MainImageUrl).HasColumnName("main_img_url").HasMaxLength(2000);
                entity.Property(e => e.LogoImageUrl).HasColumnName("logo_img_url").HasMaxLength(2000);
                entity.Property(e => e.PageTitle).HasColumnName("page_title").HasMaxLength(200);
                entity.Property(e => e.IsMain).HasColumnName("is_main");
                entity.Property(e => e.Whatsapp).HasColumnName("whatsapp").HasMaxLength(20);
                entity.Property(e => e.Telephone).HasColumnName("telephone").HasMaxLength(20);
                entity.Property(e => e.EmailContact).HasColumnName("email_contact").HasMaxLength(200);
                entity.Property(e => e.CreatedAt).HasColumnName("created_at")
                    .HasColumnType("datetime").ValueGeneratedOnAdd().IsRequired();
                entity.Property(e => e.UpdatedAt).HasColumnName("updated_at")
                    .HasColumnType("datetime").ValueGeneratedOnAddOrUpdate().IsRequired();
                entity.Property(e => e.DeletedAt).HasColumnName("deleted_at").HasColumnType("datetime");
            });

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.ToTable("Payment");
                entity.HasKey(e => e.IdPayment);
                entity.Property(e => e.IdPayment).HasColumnName("id_payment").IsRequired();
                entity.Property(e => e.IdAdmin).HasColumnName("id_admin");
                entity.Property(e => e.IdStudent).HasColumnName("id_student");
                entity.Property(e => e.IdStatus).HasColumnName("id_status");
                entity.Property(e => e.IdPaymentType).HasColumnName("id_payment_type");
                entity.Property(e => e.DueDate).HasColumnName("due_date");
                entity.Property(e => e.Invoice).HasColumnName("invoice").HasMaxLength(255);
                entity.Property(e => e.DatePayment).HasColumnName("date_payment");
                entity.Property(e => e.CreatedAt).HasColumnName("created_at")
                    .HasColumnType("datetime").ValueGeneratedOnAdd().IsRequired();
                entity.Property(e => e.UpdatedAt).HasColumnName("updated_at")
                    .HasColumnType("datetime").ValueGeneratedOnAddOrUpdate().IsRequired();
                entity.Property(e => e.DeletedAt).HasColumnName("deleted_at").HasColumnType("datetime");
                entity.HasOne(e => e.Admin).WithMany().HasForeignKey(e => e.IdAdmin)
                    .OnDelete(DeleteBehavior.Restrict);
                entity.HasOne(e => e.Student).WithMany().HasForeignKey(e => e.IdStudent)
                    .OnDelete(DeleteBehavior.Restrict);
                entity.HasOne(e => e.Status).WithMany().HasForeignKey(e => e.IdStatus)
                    .OnDelete(DeleteBehavior.Restrict);
                entity.HasOne(e => e.PaymentType).WithMany().HasForeignKey(e => e.IdPaymentType)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Telephone>(entity =>
            {
                entity.ToTable("Telephone");
                entity.HasKey(e => e.IdTelephone);
                entity.Property(e => e.IdTelephone).HasColumnName("id_telephone").IsRequired();
                entity.Property(e => e.IdStudent).HasColumnName("id_student");
                entity.Property(e => e.Number).HasColumnName("number").HasMaxLength(20);
                entity.Property(e => e.CreatedAt).HasColumnName("created_at")
                    .HasColumnType("datetime").ValueGeneratedOnAdd().IsRequired();
                entity.Property(e => e.UpdatedAt).HasColumnName("updated_at")
                    .HasColumnType("datetime").ValueGeneratedOnAddOrUpdate().IsRequired();
                entity.Property(e => e.DeletedAt).HasColumnName("deleted_at").HasColumnType("datetime");
                entity.HasOne(d => d.Student).WithMany().HasForeignKey(d => d.IdStudent)
                    .HasConstraintName("FK_Telephone_Student");
            });

            modelBuilder.Entity<StudentPointsClass>(entity =>
            {
                entity.ToTable("StudentPointsClass");
                entity.HasKey(e => new { StudentId = e.IdStudent, ExerciseId = e.IdExercise });
                entity.Property(e => e.Points).HasColumnName("points");
                entity.Property(e => e.CreatedAt).HasColumnName("created_at")
                    .HasColumnType("datetime").ValueGeneratedOnAdd().IsRequired();
                entity.Property(e => e.UpdatedAt).HasColumnName("updated_at")
                    .HasColumnType("datetime").ValueGeneratedOnAddOrUpdate().IsRequired();
                entity.Property(e => e.DeletedAt).HasColumnName("deleted_at").HasColumnType("datetime");
                entity.HasOne(e => e.Student).WithMany().HasForeignKey(e => e.IdStudent);
                entity.HasOne(e => e.Exercise).WithMany().HasForeignKey(e => e.IdExercise);
            });

            modelBuilder.Entity<StudentCheckin>(entity =>
            {
                entity.ToTable("StudentCheckin");
                entity.HasKey(e => new { StudentId = e.IdStudent, ClassId = e.IdClass });
                entity.Property(e => e.DateTime).HasColumnName("date_time").HasColumnType("datetime");
                entity.HasOne(e => e.Student).WithMany().HasForeignKey(e => e.IdStudent)
                    .OnDelete(DeleteBehavior.Restrict);
                entity.HasOne(e => e.Class).WithMany().HasForeignKey(e => e.IdClass)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}