// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Servera_puse.Helpers;

namespace Servera_puse.Migrations
{
    [DbContext(typeof(Konteksts))]
    partial class KontekstsModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Servera_puse.Entities.Extension", b =>
                {
                    b.Property<string>("Extension_name")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Extension_name");

                    b.ToTable("Extension");
                });

            modelBuilder.Entity("Servera_puse.Entities.File", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descryption")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Extension_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Link")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Size")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("Extension_name");

                    b.HasIndex("UserId");

                    b.ToTable("Datnes");
                });

            modelBuilder.Entity("Servera_puse.Entities.Parametr", b =>
                {
                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Value")
                        .HasColumnType("int");

                    b.HasKey("Name");

                    b.ToTable("Parametrs");

                    b.HasData(
                        new
                        {
                            Name = "Size",
                            Value = 5
                        },
                        new
                        {
                            Name = "a_max",
                            Value = 300
                        },
                        new
                        {
                            Name = "b_max",
                            Value = 300
                        },
                        new
                        {
                            Name = "a_min",
                            Value = 100
                        },
                        new
                        {
                            Name = "b_min",
                            Value = 100
                        });
                });

            modelBuilder.Entity("Servera_puse.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Token")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Password = "wcIksDzZvHtqhtd/XazkAZF2bEhc1V3EjK+ayHMzXW8=",
                            Role = "Admin",
                            Username = "Admin"
                        },
                        new
                        {
                            Id = 2,
                            Password = "tRLZfny/l8Jz5NsHO7tUeqZahFiSJ/jz2eSnK5Nyok0=",
                            Role = "User",
                            Username = "User"
                        });
                });

            modelBuilder.Entity("Servera_puse.Entities.File", b =>
                {
                    b.HasOne("Servera_puse.Entities.Extension", "Extension")
                        .WithMany()
                        .HasForeignKey("Extension_name")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Servera_puse.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
