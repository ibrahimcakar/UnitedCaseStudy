// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using UnitedCaseStudy.Data.Context;

#nullable disable

namespace UnitedCaseStudy.Data.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("UnitedCaseStudy.Entity.Entities.Note", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("NoteText")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ParentNoteId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ParentNoteId");

                    b.ToTable("Notes");
                });

            modelBuilder.Entity("UnitedCaseStudy.Entity.Entities.Note", b =>
                {
                    b.HasOne("UnitedCaseStudy.Entity.Entities.Note", "ParentNote")
                        .WithMany()
                        .HasForeignKey("ParentNoteId");

                    b.Navigation("ParentNote");
                });
#pragma warning restore 612, 618
        }
    }
}
