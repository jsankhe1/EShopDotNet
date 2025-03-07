﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProductMicroservice.Infrastructure.Data;

#nullable disable

namespace ProductMicroservice.Infrastructure.Migrations
{
    [DbContext(typeof(ProductDbContext))]
    [Migration("20250224003403_InitialMigration")]
    partial class InitialMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ProductMicroservice.Core.Entities.CategoryVariation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("CategoryVariations");
                });

            modelBuilder.Entity("ProductMicroservice.Core.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,4)");

                    b.Property<string>("ProductImage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Qty")
                        .HasColumnType("int");

                    b.Property<string>("SKU")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("ProductMicroservice.Core.Entities.ProductCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int?>("ParentCategoryId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ParentCategoryId");

                    b.ToTable("ProductCategories");
                });

            modelBuilder.Entity("ProductMicroservice.Core.Entities.ProductVariationValues", b =>
                {
                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("VariationValueId")
                        .HasColumnType("int");

                    b.HasKey("ProductId", "VariationValueId");

                    b.HasIndex("VariationValueId");

                    b.ToTable("ProductVariationValues");
                });

            modelBuilder.Entity("ProductMicroservice.Core.Entities.VariationValue", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("VariationId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("VariationId");

                    b.ToTable("VariationValues");
                });

            modelBuilder.Entity("ProductMicroservice.Core.Entities.CategoryVariation", b =>
                {
                    b.HasOne("ProductMicroservice.Core.Entities.ProductCategory", "ProductCategory")
                        .WithMany("CategoryVariations")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProductCategory");
                });

            modelBuilder.Entity("ProductMicroservice.Core.Entities.Product", b =>
                {
                    b.HasOne("ProductMicroservice.Core.Entities.ProductCategory", "ProductCategory")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("ProductCategory");
                });

            modelBuilder.Entity("ProductMicroservice.Core.Entities.ProductCategory", b =>
                {
                    b.HasOne("ProductMicroservice.Core.Entities.ProductCategory", "ParentCategory")
                        .WithMany("SubCategories")
                        .HasForeignKey("ParentCategoryId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("ParentCategory");
                });

            modelBuilder.Entity("ProductMicroservice.Core.Entities.ProductVariationValues", b =>
                {
                    b.HasOne("ProductMicroservice.Core.Entities.Product", "Product")
                        .WithMany("ProductVariationValues")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProductMicroservice.Core.Entities.VariationValue", "VariationValue")
                        .WithMany("ProductVariationValues")
                        .HasForeignKey("VariationValueId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("VariationValue");
                });

            modelBuilder.Entity("ProductMicroservice.Core.Entities.VariationValue", b =>
                {
                    b.HasOne("ProductMicroservice.Core.Entities.CategoryVariation", "CategoryVariation")
                        .WithMany("VariationValues")
                        .HasForeignKey("VariationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CategoryVariation");
                });

            modelBuilder.Entity("ProductMicroservice.Core.Entities.CategoryVariation", b =>
                {
                    b.Navigation("VariationValues");
                });

            modelBuilder.Entity("ProductMicroservice.Core.Entities.Product", b =>
                {
                    b.Navigation("ProductVariationValues");
                });

            modelBuilder.Entity("ProductMicroservice.Core.Entities.ProductCategory", b =>
                {
                    b.Navigation("CategoryVariations");

                    b.Navigation("Products");

                    b.Navigation("SubCategories");
                });

            modelBuilder.Entity("ProductMicroservice.Core.Entities.VariationValue", b =>
                {
                    b.Navigation("ProductVariationValues");
                });
#pragma warning restore 612, 618
        }
    }
}
