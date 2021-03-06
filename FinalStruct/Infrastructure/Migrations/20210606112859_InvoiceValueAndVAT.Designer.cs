// <auto-generated />
using System;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infrastructure.Migrations
{
    [DbContext(typeof(AccountingAppDbContext))]
    [Migration("20210606112859_InvoiceValueAndVAT")]
    partial class InvoiceValueAndVAT
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Domain.Invoicing.Invoice", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Number")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int>("ThirdPartyPersonId")
                        .HasColumnType("int");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.Property<double>("VATValue")
                        .HasColumnType("float");

                    b.Property<double>("Value")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("ThirdPartyPersonId");

                    b.ToTable("Invoices");

                    b.HasDiscriminator<int>("Type").HasValue(0);
                });

            modelBuilder.Entity("Domain.Position", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<double>("Quantity")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("Positions");
                });

            modelBuilder.Entity("Domain.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Domain.ThirdParty.ThirdPartyPerson", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsArchived")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TaxId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("ThirdParties");

                    b.HasDiscriminator<int>("Type").HasValue(0);
                });

            modelBuilder.Entity("InvoicePosition", b =>
                {
                    b.Property<int>("InvoicesId")
                        .HasColumnType("int");

                    b.Property<int>("PositionsId")
                        .HasColumnType("int");

                    b.HasKey("InvoicesId", "PositionsId");

                    b.HasIndex("PositionsId");

                    b.ToTable("InvoicePosition");
                });

            modelBuilder.Entity("Domain.Invoicing.PurchasesInvoice", b =>
                {
                    b.HasBaseType("Domain.Invoicing.Invoice");

                    b.HasDiscriminator().HasValue(2);
                });

            modelBuilder.Entity("Domain.Invoicing.SalesInvoice", b =>
                {
                    b.HasBaseType("Domain.Invoicing.Invoice");

                    b.HasDiscriminator().HasValue(1);
                });

            modelBuilder.Entity("Domain.ThirdParty.Customer", b =>
                {
                    b.HasBaseType("Domain.ThirdParty.ThirdPartyPerson");

                    b.HasDiscriminator().HasValue(1);
                });

            modelBuilder.Entity("Domain.ThirdParty.Supplier", b =>
                {
                    b.HasBaseType("Domain.ThirdParty.ThirdPartyPerson");

                    b.HasDiscriminator().HasValue(2);
                });

            modelBuilder.Entity("Domain.Invoicing.Invoice", b =>
                {
                    b.HasOne("Domain.ThirdParty.ThirdPartyPerson", "ThirdPartyPerson")
                        .WithMany("Invoices")
                        .HasForeignKey("ThirdPartyPersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ThirdPartyPerson");
                });

            modelBuilder.Entity("Domain.Position", b =>
                {
                    b.HasOne("Domain.Product", "Product")
                        .WithMany("Positions")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("InvoicePosition", b =>
                {
                    b.HasOne("Domain.Invoicing.Invoice", null)
                        .WithMany()
                        .HasForeignKey("InvoicesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Position", null)
                        .WithMany()
                        .HasForeignKey("PositionsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Product", b =>
                {
                    b.Navigation("Positions");
                });

            modelBuilder.Entity("Domain.ThirdParty.ThirdPartyPerson", b =>
                {
                    b.Navigation("Invoices");
                });
#pragma warning restore 612, 618
        }
    }
}
