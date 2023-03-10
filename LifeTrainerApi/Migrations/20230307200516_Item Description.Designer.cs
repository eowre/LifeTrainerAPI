// <auto-generated />
using System;
using LifeTrainerApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LifeTrainerApi.Migrations
{
    [DbContext(typeof(LTcontext))]
    [Migration("20230307200516_Item Description")]
    partial class ItemDescription
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("LifeTrainerApi.Models.Avatar", b =>
                {
                    b.Property<int>("AvatarId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AvatarId"), 1L, 1);

                    b.Property<string>("AvatarName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("XP")
                        .HasColumnType("int");

                    b.Property<int>("XPLevel")
                        .HasColumnType("int");

                    b.HasKey("AvatarId");

                    b.ToTable("avatars");
                });

            modelBuilder.Entity("LifeTrainerApi.Models.Item", b =>
                {
                    b.Property<int>("ItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ItemId"), 1L, 1);

                    b.Property<int?>("AvatarId")
                        .HasColumnType("int");

                    b.Property<int>("CompletionCount")
                        .HasColumnType("int");

                    b.Property<string>("ItemName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RewardAmount")
                        .HasColumnType("int");

                    b.Property<string>("description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ItemId");

                    b.HasIndex("AvatarId");

                    b.ToTable("items");
                });

            modelBuilder.Entity("LifeTrainerApi.Models.Item", b =>
                {
                    b.HasOne("LifeTrainerApi.Models.Avatar", null)
                        .WithMany("Items")
                        .HasForeignKey("AvatarId");
                });

            modelBuilder.Entity("LifeTrainerApi.Models.Avatar", b =>
                {
                    b.Navigation("Items");
                });
#pragma warning restore 612, 618
        }
    }
}
