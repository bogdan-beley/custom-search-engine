﻿// <auto-generated />
using System;
using CustomSearchEngine.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CustomSearchEngine.Migrations
{
    [DbContext(typeof(CustomSearchEngineContext))]
    [Migration("20210110110541_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("CustomSearchEngine.Models.GoogleCustomSearchItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("GoogleCustomSearchRootObjectId")
                        .HasColumnType("int");

                    b.Property<string>("Link")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Snippet")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("GoogleCustomSearchRootObjectId");

                    b.ToTable("GoogleCustomSearchItems");
                });

            modelBuilder.Entity("CustomSearchEngine.Models.GoogleCustomSearchRootObject", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.HasKey("Id");

                    b.ToTable("GoogleCustomSearchRootObjects");
                });

            modelBuilder.Entity("CustomSearchEngine.Models.GoogleCustomSearchItem", b =>
                {
                    b.HasOne("CustomSearchEngine.Models.GoogleCustomSearchRootObject", null)
                        .WithMany("Items")
                        .HasForeignKey("GoogleCustomSearchRootObjectId");
                });

            modelBuilder.Entity("CustomSearchEngine.Models.GoogleCustomSearchRootObject", b =>
                {
                    b.Navigation("Items");
                });
#pragma warning restore 612, 618
        }
    }
}