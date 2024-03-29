﻿// <auto-generated />
using Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(DddInPracticeContext))]
    [Migration("20240107205941_InitialMigration")]
    partial class InitialMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Core.Entities.SnackMachine", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.HasKey("Id");

                    b.ToTable("SnackMachines", (string)null);
                });

            modelBuilder.Entity("Core.Entities.SnackMachine", b =>
                {
                    b.OwnsOne("Core.ValueObjects.Money", "MoneyInside", b1 =>
                        {
                            b1.Property<long>("SnackMachineId")
                                .HasColumnType("bigint");

                            b1.Property<int>("FiveDollarCount")
                                .HasColumnType("int")
                                .HasColumnName("FiveDollarCount");

                            b1.Property<int>("OneCentCount")
                                .HasColumnType("int")
                                .HasColumnName("OneCentCount");

                            b1.Property<int>("OneDollarCount")
                                .HasColumnType("int")
                                .HasColumnName("OneDollarCount");

                            b1.Property<int>("QuarterCount")
                                .HasColumnType("int")
                                .HasColumnName("QuarterCount");

                            b1.Property<int>("TenCentCount")
                                .HasColumnType("int")
                                .HasColumnName("TenCentCount");

                            b1.Property<int>("TwentyDollarCount")
                                .HasColumnType("int")
                                .HasColumnName("TwentyDollarCount");

                            b1.HasKey("SnackMachineId");

                            b1.ToTable("SnackMachines");

                            b1.WithOwner()
                                .HasForeignKey("SnackMachineId");
                        });

                    b.Navigation("MoneyInside")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
