﻿// <auto-generated />
using System;
using Devon4Net.Application.WebAPI.Implementation.Domain.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Devon4Net.Application.WebAPI.Implementation.Migrations.Sqlite
{
    [DbContext(typeof(ModelContextSqlite))]
    [Migration("20220831135050_initialModelContextSqlite")]
    partial class initialModelContextSqlite
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.8");

            modelBuilder.Entity("Devon4Net.Application.WebAPI.Implementation.Domain.Entities.Booking", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("Assistants")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("BookingDate")
                        .HasColumnType("datetime");

                    b.Property<bool?>("Canceled")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasDefaultValueSql("((0))");

                    b.Property<string>("Comments")
                        .HasMaxLength(255)
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("CreationDate")
                        .HasColumnType("datetime");

                    b.Property<string>("Email")
                        .HasMaxLength(255)
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("ExpirationDate")
                        .HasColumnType("datetime");

                    b.Property<int?>("IdBookingType")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasMaxLength(120)
                        .HasColumnType("TEXT");

                    b.Property<string>("ReservationToken")
                        .HasMaxLength(60)
                        .HasColumnType("TEXT");

                    b.Property<long?>("TableId")
                        .HasColumnType("INTEGER");

                    b.Property<long?>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.HasIndex("TableId");

                    b.HasIndex("UserId");

                    b.ToTable("Booking");
                });

            modelBuilder.Entity("Devon4Net.Application.WebAPI.Implementation.Domain.Entities.Category", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasMaxLength(255)
                        .HasColumnType("TEXT");

                    b.Property<int?>("ModificationCounter")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasMaxLength(120)
                        .HasColumnType("TEXT");

                    b.Property<int?>("ShowOrder")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("Devon4Net.Application.WebAPI.Implementation.Domain.Entities.Dish", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(4000)");

                    b.Property<long?>("IdImage")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasMaxLength(120)
                        .HasColumnType("TEXT");

                    b.Property<decimal?>("Price")
                        .HasColumnType("decimal(16, 10)");

                    b.HasKey("Id");

                    b.HasIndex("IdImage");

                    b.ToTable("Dish");
                });

            modelBuilder.Entity("Devon4Net.Application.WebAPI.Implementation.Domain.Entities.DishCategory", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<long>("IdCategory")
                        .HasColumnType("INTEGER");

                    b.Property<long>("IdDish")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ModificationCounter")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("IdCategory");

                    b.HasIndex("IdDish");

                    b.ToTable("DishCategory");
                });

            modelBuilder.Entity("Devon4Net.Application.WebAPI.Implementation.Domain.Entities.DishIngredient", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<long>("IdDish")
                        .HasColumnType("INTEGER");

                    b.Property<long>("IdIngredient")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ModificationCounter")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("IdDish");

                    b.HasIndex("IdIngredient");

                    b.ToTable("DishIngredient");
                });

            modelBuilder.Entity("Devon4Net.Application.WebAPI.Implementation.Domain.Entities.Image", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Content")
                        .HasColumnType("TEXT");

                    b.Property<int?>("ContentType")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Extension")
                        .HasMaxLength(20)
                        .HasColumnType("TEXT");

                    b.Property<string>("MimeType")
                        .HasMaxLength(10)
                        .HasColumnType("TEXT");

                    b.Property<int?>("ModificationCounter")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Image");
                });

            modelBuilder.Entity("Devon4Net.Application.WebAPI.Implementation.Domain.Entities.Ingredient", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasMaxLength(120)
                        .HasColumnType("TEXT");

                    b.Property<decimal?>("Price")
                        .HasColumnType("decimal(16, 10)");

                    b.HasKey("Id");

                    b.ToTable("Ingredient");
                });

            modelBuilder.Entity("Devon4Net.Application.WebAPI.Implementation.Domain.Entities.InvitedGuest", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool?>("Accepted")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .HasMaxLength(60)
                        .HasColumnType("TEXT");

                    b.Property<string>("GuestToken")
                        .HasMaxLength(60)
                        .HasColumnType("TEXT");

                    b.Property<long>("IdBooking")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("ModificationDate")
                        .HasColumnType("datetime");

                    b.HasKey("Id");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.HasIndex("IdBooking");

                    b.ToTable("InvitedGuest");
                });

            modelBuilder.Entity("Devon4Net.Application.WebAPI.Implementation.Domain.Entities.Order", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<long?>("IdInvitationGuest")
                        .HasColumnType("INTEGER");

                    b.Property<long?>("IdReservation")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("IdInvitationGuest");

                    b.HasIndex("IdReservation");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("Devon4Net.Application.WebAPI.Implementation.Domain.Entities.OrderDishExtraIngredient", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<long>("IdIngredient")
                        .HasColumnType("INTEGER");

                    b.Property<long>("IdOrderLine")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("IdIngredient");

                    b.HasIndex("IdOrderLine");

                    b.ToTable("OrderDishExtraIngredient");
                });

            modelBuilder.Entity("Devon4Net.Application.WebAPI.Implementation.Domain.Entities.OrderLine", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("Amount")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Comment")
                        .HasMaxLength(255)
                        .HasColumnType("TEXT");

                    b.Property<long>("IdDish")
                        .HasColumnType("INTEGER");

                    b.Property<long>("IdOrder")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("IdDish");

                    b.HasIndex("IdOrder");

                    b.ToTable("OrderLine");
                });

            modelBuilder.Entity("Devon4Net.Application.WebAPI.Implementation.Domain.Entities.Table", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("SeatsNumber")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Table");
                });

            modelBuilder.Entity("Devon4Net.Application.WebAPI.Implementation.Domain.Entities.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .HasMaxLength(60)
                        .HasColumnType("TEXT");

                    b.Property<long>("IdRole")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Password")
                        .HasMaxLength(255)
                        .HasColumnType("TEXT");

                    b.Property<string>("UserName")
                        .HasMaxLength(120)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("IdRole");

                    b.ToTable("User");
                });

            modelBuilder.Entity("Devon4Net.Application.WebAPI.Implementation.Domain.Entities.UserFavourite", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<long>("IdDish")
                        .HasColumnType("INTEGER");

                    b.Property<long>("IdUser")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("IdDish");

                    b.HasIndex("IdUser");

                    b.ToTable("UserFavourite");
                });

            modelBuilder.Entity("Devon4Net.Application.WebAPI.Implementation.Domain.Entities.UserRole", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool?>("Active")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasMaxLength(120)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("UserRole");
                });

            modelBuilder.Entity("Devon4Net.Application.WebAPI.Implementation.Domain.Entities.Booking", b =>
                {
                    b.HasOne("Devon4Net.Application.WebAPI.Implementation.Domain.Entities.Table", "Table")
                        .WithMany("Booking")
                        .HasForeignKey("TableId")
                        .HasConstraintName("FK_Reservation_table");

                    b.HasOne("Devon4Net.Application.WebAPI.Implementation.Domain.Entities.User", "User")
                        .WithMany("Booking")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK_Reservation_0_0");

                    b.Navigation("Table");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Devon4Net.Application.WebAPI.Implementation.Domain.Entities.Dish", b =>
                {
                    b.HasOne("Devon4Net.Application.WebAPI.Implementation.Domain.Entities.Image", "IdImageNavigation")
                        .WithMany("Dish")
                        .HasForeignKey("IdImage")
                        .HasConstraintName("FK_Dish_image");

                    b.Navigation("IdImageNavigation");
                });

            modelBuilder.Entity("Devon4Net.Application.WebAPI.Implementation.Domain.Entities.DishCategory", b =>
                {
                    b.HasOne("Devon4Net.Application.WebAPI.Implementation.Domain.Entities.Category", "IdCategoryNavigation")
                        .WithMany("DishCategory")
                        .HasForeignKey("IdCategory")
                        .IsRequired()
                        .HasConstraintName("FK_DishCategory_0_0");

                    b.HasOne("Devon4Net.Application.WebAPI.Implementation.Domain.Entities.Dish", "IdDishNavigation")
                        .WithMany("DishCategory")
                        .HasForeignKey("IdDish")
                        .IsRequired()
                        .HasConstraintName("FK_DishCategory_1_0");

                    b.Navigation("IdCategoryNavigation");

                    b.Navigation("IdDishNavigation");
                });

            modelBuilder.Entity("Devon4Net.Application.WebAPI.Implementation.Domain.Entities.DishIngredient", b =>
                {
                    b.HasOne("Devon4Net.Application.WebAPI.Implementation.Domain.Entities.Dish", "IdDishNavigation")
                        .WithMany("DishIngredient")
                        .HasForeignKey("IdDish")
                        .IsRequired()
                        .HasConstraintName("FK_DishIngredient_1_0");

                    b.HasOne("Devon4Net.Application.WebAPI.Implementation.Domain.Entities.Ingredient", "IdIngredientNavigation")
                        .WithMany("DishIngredient")
                        .HasForeignKey("IdIngredient")
                        .IsRequired()
                        .HasConstraintName("FK_DishIngredient_0_0");

                    b.Navigation("IdDishNavigation");

                    b.Navigation("IdIngredientNavigation");
                });

            modelBuilder.Entity("Devon4Net.Application.WebAPI.Implementation.Domain.Entities.InvitedGuest", b =>
                {
                    b.HasOne("Devon4Net.Application.WebAPI.Implementation.Domain.Entities.Booking", "IdBookingNavigation")
                        .WithMany("InvitedGuest")
                        .HasForeignKey("IdBooking")
                        .IsRequired()
                        .HasConstraintName("FK_InvitationGuest_0_0");

                    b.Navigation("IdBookingNavigation");
                });

            modelBuilder.Entity("Devon4Net.Application.WebAPI.Implementation.Domain.Entities.Order", b =>
                {
                    b.HasOne("Devon4Net.Application.WebAPI.Implementation.Domain.Entities.InvitedGuest", "IdInvitationGuestNavigation")
                        .WithMany("Order")
                        .HasForeignKey("IdInvitationGuest")
                        .HasConstraintName("FK_Order_0_1");

                    b.HasOne("Devon4Net.Application.WebAPI.Implementation.Domain.Entities.Booking", "IdReservationNavigation")
                        .WithMany("Order")
                        .HasForeignKey("IdReservation")
                        .HasConstraintName("FK_Order_0_0");

                    b.Navigation("IdInvitationGuestNavigation");

                    b.Navigation("IdReservationNavigation");
                });

            modelBuilder.Entity("Devon4Net.Application.WebAPI.Implementation.Domain.Entities.OrderDishExtraIngredient", b =>
                {
                    b.HasOne("Devon4Net.Application.WebAPI.Implementation.Domain.Entities.Ingredient", "IdIngredientNavigation")
                        .WithMany("OrderDishExtraIngredient")
                        .HasForeignKey("IdIngredient")
                        .IsRequired()
                        .HasConstraintName("FK_OrderDIshExtraIngredient_1_0");

                    b.HasOne("Devon4Net.Application.WebAPI.Implementation.Domain.Entities.OrderLine", "IdOrderLineNavigation")
                        .WithMany("OrderDishExtraIngredient")
                        .HasForeignKey("IdOrderLine")
                        .IsRequired()
                        .HasConstraintName("FK_OrderDIshExtraIngredient_0_0");

                    b.Navigation("IdIngredientNavigation");

                    b.Navigation("IdOrderLineNavigation");
                });

            modelBuilder.Entity("Devon4Net.Application.WebAPI.Implementation.Domain.Entities.OrderLine", b =>
                {
                    b.HasOne("Devon4Net.Application.WebAPI.Implementation.Domain.Entities.Dish", "IdDishNavigation")
                        .WithMany("OrderLine")
                        .HasForeignKey("IdDish")
                        .IsRequired()
                        .HasConstraintName("FK_OrderLine_1_0");

                    b.HasOne("Devon4Net.Application.WebAPI.Implementation.Domain.Entities.Order", "IdOrderNavigation")
                        .WithMany("OrderLine")
                        .HasForeignKey("IdOrder")
                        .IsRequired()
                        .HasConstraintName("FK_OrderLine_0_0");

                    b.Navigation("IdDishNavigation");

                    b.Navigation("IdOrderNavigation");
                });

            modelBuilder.Entity("Devon4Net.Application.WebAPI.Implementation.Domain.Entities.User", b =>
                {
                    b.HasOne("Devon4Net.Application.WebAPI.Implementation.Domain.Entities.UserRole", "IdRoleNavigation")
                        .WithMany("User")
                        .HasForeignKey("IdRole")
                        .IsRequired()
                        .HasConstraintName("FK_User_0_0");

                    b.Navigation("IdRoleNavigation");
                });

            modelBuilder.Entity("Devon4Net.Application.WebAPI.Implementation.Domain.Entities.UserFavourite", b =>
                {
                    b.HasOne("Devon4Net.Application.WebAPI.Implementation.Domain.Entities.Dish", "IdDishNavigation")
                        .WithMany("UserFavourite")
                        .HasForeignKey("IdDish")
                        .IsRequired()
                        .HasConstraintName("FK_UserFavourite_0_0");

                    b.HasOne("Devon4Net.Application.WebAPI.Implementation.Domain.Entities.User", "IdUserNavigation")
                        .WithMany("UserFavourite")
                        .HasForeignKey("IdUser")
                        .IsRequired()
                        .HasConstraintName("FK_UserFavourite_1_0");

                    b.Navigation("IdDishNavigation");

                    b.Navigation("IdUserNavigation");
                });

            modelBuilder.Entity("Devon4Net.Application.WebAPI.Implementation.Domain.Entities.Booking", b =>
                {
                    b.Navigation("InvitedGuest");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("Devon4Net.Application.WebAPI.Implementation.Domain.Entities.Category", b =>
                {
                    b.Navigation("DishCategory");
                });

            modelBuilder.Entity("Devon4Net.Application.WebAPI.Implementation.Domain.Entities.Dish", b =>
                {
                    b.Navigation("DishCategory");

                    b.Navigation("DishIngredient");

                    b.Navigation("OrderLine");

                    b.Navigation("UserFavourite");
                });

            modelBuilder.Entity("Devon4Net.Application.WebAPI.Implementation.Domain.Entities.Image", b =>
                {
                    b.Navigation("Dish");
                });

            modelBuilder.Entity("Devon4Net.Application.WebAPI.Implementation.Domain.Entities.Ingredient", b =>
                {
                    b.Navigation("DishIngredient");

                    b.Navigation("OrderDishExtraIngredient");
                });

            modelBuilder.Entity("Devon4Net.Application.WebAPI.Implementation.Domain.Entities.InvitedGuest", b =>
                {
                    b.Navigation("Order");
                });

            modelBuilder.Entity("Devon4Net.Application.WebAPI.Implementation.Domain.Entities.Order", b =>
                {
                    b.Navigation("OrderLine");
                });

            modelBuilder.Entity("Devon4Net.Application.WebAPI.Implementation.Domain.Entities.OrderLine", b =>
                {
                    b.Navigation("OrderDishExtraIngredient");
                });

            modelBuilder.Entity("Devon4Net.Application.WebAPI.Implementation.Domain.Entities.Table", b =>
                {
                    b.Navigation("Booking");
                });

            modelBuilder.Entity("Devon4Net.Application.WebAPI.Implementation.Domain.Entities.User", b =>
                {
                    b.Navigation("Booking");

                    b.Navigation("UserFavourite");
                });

            modelBuilder.Entity("Devon4Net.Application.WebAPI.Implementation.Domain.Entities.UserRole", b =>
                {
                    b.Navigation("User");
                });
#pragma warning restore 612, 618
        }
    }
}
