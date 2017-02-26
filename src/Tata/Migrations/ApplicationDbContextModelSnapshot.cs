using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Tata.Data;

namespace Tata.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.0-rtm-22752")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("NormalizedName")
                        .HasAnnotation("MaxLength", 256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("TaTa.DataAccess.Entities.User", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("NormalizedUserName")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasAnnotation("MaxLength", 256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Tata.Entities.Billing", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<string>("City");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("CreatedUserId");

                    b.Property<string>("Email");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<string>("Phone");

                    b.Property<DateTime?>("UpdatedDate");

                    b.HasKey("Id");

                    b.HasIndex("CreatedUserId");

                    b.ToTable("Billings");
                });

            modelBuilder.Entity("Tata.Entities.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BillingId");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("CreatedUserId");

                    b.Property<string>("OrderCode");

                    b.Property<int>("OrderNumber");

                    b.Property<int>("OrderStatus");

                    b.Property<DateTime?>("UpdatedDate");

                    b.HasKey("Id");

                    b.HasIndex("BillingId");

                    b.HasIndex("CreatedUserId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Tata.Entities.OrderItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("CreatedUserId");

                    b.Property<int>("OrderId");

                    b.Property<int>("ProductPriceId");

                    b.Property<int>("Quantity");

                    b.Property<DateTime?>("UpdatedDate");

                    b.HasKey("Id");

                    b.HasIndex("CreatedUserId");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductPriceId");

                    b.ToTable("OrderItems");
                });

            modelBuilder.Entity("Tata.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CategoryId");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("CreatedUserId");

                    b.Property<string>("Description");

                    b.Property<string>("MetaTagDescription");

                    b.Property<string>("MetaTagKeywords");

                    b.Property<string>("MetaTagTitle");

                    b.Property<string>("Name");

                    b.Property<int>("Priority");

                    b.Property<int>("Quantity");

                    b.Property<int>("Status");

                    b.Property<DateTime?>("UpdatedDate");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("CreatedUserId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Tata.Entities.ProductCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("CreatedUserId");

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.Property<int>("Priority");

                    b.Property<DateTime?>("UpdatedDate");

                    b.HasKey("Id");

                    b.HasIndex("CreatedUserId");

                    b.ToTable("ProductCategories");
                });

            modelBuilder.Entity("Tata.Entities.ProductPrice", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("CreatedUserId");

                    b.Property<int>("Currency");

                    b.Property<bool>("IsDefault");

                    b.Property<bool>("IsDisabled");

                    b.Property<string>("Name");

                    b.Property<decimal>("Price");

                    b.Property<int>("Priority");

                    b.Property<int>("ProductId");

                    b.Property<int>("Quantity");

                    b.Property<string>("Unit");

                    b.Property<DateTime?>("UpdatedDate");

                    b.HasKey("Id");

                    b.HasIndex("CreatedUserId");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductPrices");
                });

            modelBuilder.Entity("Tata.Entities.ProductProperty", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("CreatedUserId");

                    b.Property<int>("Currency");

                    b.Property<string>("Description");

                    b.Property<bool>("IsDisabled");

                    b.Property<bool>("IsHighlight");

                    b.Property<string>("Name");

                    b.Property<int?>("OrderItemId");

                    b.Property<decimal>("Price");

                    b.Property<int>("Priority");

                    b.Property<int>("ProductId");

                    b.Property<int>("Type");

                    b.Property<string>("Unit");

                    b.Property<DateTime?>("UpdatedDate");

                    b.Property<string>("Value");

                    b.HasKey("Id");

                    b.HasIndex("CreatedUserId");

                    b.HasIndex("OrderItemId");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductProperties");
                });

            modelBuilder.Entity("Tata.Entities.ProductPropertyGroup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("CreatedUserId");

                    b.Property<string>("Description");

                    b.Property<bool>("ForDefaultSetup");

                    b.Property<bool>("ForUserCustomize");

                    b.Property<string>("Name");

                    b.Property<int>("ProductCategoryId");

                    b.Property<int>("Type");

                    b.Property<DateTime?>("UpdatedDate");

                    b.HasKey("Id");

                    b.HasIndex("CreatedUserId");

                    b.HasIndex("ProductCategoryId");

                    b.ToTable("ProductPropertyGroup");
                });

            modelBuilder.Entity("Tata.Entities.ProductPropertyGroupValue", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("CreatedUserId");

                    b.Property<int>("Currency");

                    b.Property<string>("Description");

                    b.Property<int>("GroupId");

                    b.Property<string>("Name");

                    b.Property<decimal>("Price");

                    b.Property<string>("Unit");

                    b.Property<DateTime?>("UpdatedDate");

                    b.Property<string>("Value");

                    b.HasKey("Id");

                    b.HasIndex("CreatedUserId");

                    b.HasIndex("GroupId");

                    b.ToTable("ProductPropertyGroupValue");
                });

            modelBuilder.Entity("Tata.Entities.Setting", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("CreatedUserId");

                    b.Property<string>("Name");

                    b.Property<int>("Priority");

                    b.Property<string>("Section");

                    b.Property<int>("TypeValue");

                    b.Property<DateTime?>("UpdatedDate");

                    b.Property<string>("Value")
                        .HasColumnType("ntext");

                    b.HasKey("Id");

                    b.HasIndex("CreatedUserId");

                    b.ToTable("Settings");
                });

            modelBuilder.Entity("Tata.Entities.UserProduct", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("CreatedUserId");

                    b.Property<DateTime>("DueDate");

                    b.Property<DateTime>("InvoiceDate");

                    b.Property<int>("ProductId");

                    b.Property<DateTime?>("UpdatedDate");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("CreatedUserId");

                    b.HasIndex("ProductId");

                    b.HasIndex("UserId");

                    b.ToTable("UserProducts");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
                        .WithMany("Claims")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("TaTa.DataAccess.Entities.User")
                        .WithMany("Claims")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("TaTa.DataAccess.Entities.User")
                        .WithMany("Logins")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TaTa.DataAccess.Entities.User")
                        .WithMany("Roles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Tata.Entities.Billing", b =>
                {
                    b.HasOne("TaTa.DataAccess.Entities.User", "CreatedUser")
                        .WithMany()
                        .HasForeignKey("CreatedUserId");
                });

            modelBuilder.Entity("Tata.Entities.Order", b =>
                {
                    b.HasOne("Tata.Entities.Billing", "Billing")
                        .WithMany()
                        .HasForeignKey("BillingId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TaTa.DataAccess.Entities.User", "CreatedUser")
                        .WithMany()
                        .HasForeignKey("CreatedUserId");
                });

            modelBuilder.Entity("Tata.Entities.OrderItem", b =>
                {
                    b.HasOne("TaTa.DataAccess.Entities.User", "CreatedUser")
                        .WithMany()
                        .HasForeignKey("CreatedUserId");

                    b.HasOne("Tata.Entities.Order", "Order")
                        .WithMany("OrderItems")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Tata.Entities.ProductPrice", "ProductPrice")
                        .WithMany()
                        .HasForeignKey("ProductPriceId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Tata.Entities.Product", b =>
                {
                    b.HasOne("Tata.Entities.ProductCategory", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TaTa.DataAccess.Entities.User", "CreatedUser")
                        .WithMany()
                        .HasForeignKey("CreatedUserId");
                });

            modelBuilder.Entity("Tata.Entities.ProductCategory", b =>
                {
                    b.HasOne("TaTa.DataAccess.Entities.User", "CreatedUser")
                        .WithMany()
                        .HasForeignKey("CreatedUserId");
                });

            modelBuilder.Entity("Tata.Entities.ProductPrice", b =>
                {
                    b.HasOne("TaTa.DataAccess.Entities.User", "CreatedUser")
                        .WithMany()
                        .HasForeignKey("CreatedUserId");

                    b.HasOne("Tata.Entities.Product", "Product")
                        .WithMany("Prices")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Tata.Entities.ProductProperty", b =>
                {
                    b.HasOne("TaTa.DataAccess.Entities.User", "CreatedUser")
                        .WithMany()
                        .HasForeignKey("CreatedUserId");

                    b.HasOne("Tata.Entities.OrderItem")
                        .WithMany("ExtraProperties")
                        .HasForeignKey("OrderItemId");

                    b.HasOne("Tata.Entities.Product", "Product")
                        .WithMany("Properties")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Tata.Entities.ProductPropertyGroup", b =>
                {
                    b.HasOne("TaTa.DataAccess.Entities.User", "CreatedUser")
                        .WithMany()
                        .HasForeignKey("CreatedUserId");

                    b.HasOne("Tata.Entities.ProductCategory", "ProductCategory")
                        .WithMany("PropertyGroups")
                        .HasForeignKey("ProductCategoryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Tata.Entities.ProductPropertyGroupValue", b =>
                {
                    b.HasOne("TaTa.DataAccess.Entities.User", "CreatedUser")
                        .WithMany()
                        .HasForeignKey("CreatedUserId");

                    b.HasOne("Tata.Entities.ProductPropertyGroup", "Group")
                        .WithMany("Values")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Tata.Entities.Setting", b =>
                {
                    b.HasOne("TaTa.DataAccess.Entities.User", "CreatedUser")
                        .WithMany()
                        .HasForeignKey("CreatedUserId");
                });

            modelBuilder.Entity("Tata.Entities.UserProduct", b =>
                {
                    b.HasOne("TaTa.DataAccess.Entities.User", "CreatedUser")
                        .WithMany()
                        .HasForeignKey("CreatedUserId");

                    b.HasOne("Tata.Entities.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TaTa.DataAccess.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });
        }
    }
}
