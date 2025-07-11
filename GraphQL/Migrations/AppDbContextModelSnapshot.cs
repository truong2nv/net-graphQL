﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GraphQL.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("GraphQL.Models.Author", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Authors");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "J.R.R. Tolkien"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Jane Austen"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Douglas Adams"
                        });
                });

            modelBuilder.Entity("GraphQL.Models.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Author")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("AuthorId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.ToTable("Books");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AuthorId = 1,
                            Title = "The Lord of the Rings"
                        },
                        new
                        {
                            Id = 2,
                            AuthorId = 1,
                            Title = "The Hobbit"
                        },
                        new
                        {
                            Id = 3,
                            AuthorId = 2,
                            Title = "Pride and Prejudice"
                        },
                        new
                        {
                            Id = 4,
                            AuthorId = 3,
                            Title = "The Hitchhiker's Guide to the Galaxy"
                        });
                });

            modelBuilder.Entity("GraphQL.Models.Book", b =>
                {
                    b.HasOne("GraphQL.Models.Author", null)
                        .WithMany("Books")
                        .HasForeignKey("AuthorId");
                });

            modelBuilder.Entity("GraphQL.Models.Author", b =>
                {
                    b.Navigation("Books");
                });
#pragma warning restore 612, 618
        }
    }
}
