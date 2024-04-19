﻿// <auto-generated />
using System;
using LapTrinhWebAPIBuoi1.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LapTrinhWebAPIBuoi1.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240416020409_sach")]
    partial class sach
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("LapTrinhWebAPIBuoi1.Models.Domain.Authors", b =>
                {
                    b.Property<int>("AuthorsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AuthorsId"));

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AuthorsId");

                    b.ToTable("Authors");

                    b.HasData(
                        new
                        {
                            AuthorsId = 1,
                            FullName = "Fujiko Fujio"
                        },
                        new
                        {
                            AuthorsId = 2,
                            FullName = "Trần Cao Duyên "
                        });
                });

            modelBuilder.Entity("LapTrinhWebAPIBuoi1.Models.Domain.Book_Author", b =>
                {
                    b.Property<int>("BooksId")
                        .HasColumnType("int");

                    b.Property<int>("AuthorsId")
                        .HasColumnType("int");

                    b.Property<int>("Book_AuthorId")
                        .HasColumnType("int");

                    b.HasKey("BooksId", "AuthorsId");

                    b.HasIndex("AuthorsId");

                    b.ToTable("Books_Author");

                    b.HasData(
                        new
                        {
                            BooksId = 1,
                            AuthorsId = 1,
                            Book_AuthorId = 1
                        },
                        new
                        {
                            BooksId = 2,
                            AuthorsId = 2,
                            Book_AuthorId = 2
                        });
                });

            modelBuilder.Entity("LapTrinhWebAPIBuoi1.Models.Domain.Books", b =>
                {
                    b.Property<int>("BooksId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BooksId"));

                    b.Property<string>("CoverUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateAdded")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateRead")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Genre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("IsRead")
                        .HasColumnType("bit");

                    b.Property<int>("PublishersId")
                        .HasColumnType("int");

                    b.Property<int>("Rate")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BooksId");

                    b.HasIndex("PublishersId");

                    b.ToTable("Books");

                    b.HasData(
                        new
                        {
                            BooksId = 1,
                            DateAdded = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Doraemon",
                            Genre = "Nam",
                            PublishersId = 1,
                            Rate = 0,
                            Title = "Book 1"
                        },
                        new
                        {
                            BooksId = 2,
                            DateAdded = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Cây Khế",
                            Genre = "Nam",
                            PublishersId = 2,
                            Rate = 0,
                            Title = "Book 2"
                        });
                });

            modelBuilder.Entity("LapTrinhWebAPIBuoi1.Models.Domain.Publishers", b =>
                {
                    b.Property<int>("PublishersId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PublishersId"));

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PublishersId");

                    b.ToTable("Publishers");

                    b.HasData(
                        new
                        {
                            PublishersId = 1,
                            Name = "Nhà Xuất Bản Kim Đồng"
                        },
                        new
                        {
                            PublishersId = 2,
                            Name = "Bộ Giáo Dục"
                        });
                });

            modelBuilder.Entity("LapTrinhWebAPIBuoi1.Models.Domain.Book_Author", b =>
                {
                    b.HasOne("LapTrinhWebAPIBuoi1.Models.Domain.Authors", "Authors")
                        .WithMany("Book_Authors")
                        .HasForeignKey("AuthorsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LapTrinhWebAPIBuoi1.Models.Domain.Books", "Books")
                        .WithMany("Book_Authors")
                        .HasForeignKey("BooksId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Authors");

                    b.Navigation("Books");
                });

            modelBuilder.Entity("LapTrinhWebAPIBuoi1.Models.Domain.Books", b =>
                {
                    b.HasOne("LapTrinhWebAPIBuoi1.Models.Domain.Publishers", "Publishers")
                        .WithMany("Books")
                        .HasForeignKey("PublishersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Publishers");
                });

            modelBuilder.Entity("LapTrinhWebAPIBuoi1.Models.Domain.Authors", b =>
                {
                    b.Navigation("Book_Authors");
                });

            modelBuilder.Entity("LapTrinhWebAPIBuoi1.Models.Domain.Books", b =>
                {
                    b.Navigation("Book_Authors");
                });

            modelBuilder.Entity("LapTrinhWebAPIBuoi1.Models.Domain.Publishers", b =>
                {
                    b.Navigation("Books");
                });
#pragma warning restore 612, 618
        }
    }
}