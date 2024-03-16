﻿// <auto-generated />
using System;
using Advance_SQL_SERVER_with_API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Advance_SQL_SERVER_with_API.Migrations
{
    [DbContext(typeof(StudentDBcontext))]
    partial class StudentDBcontextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Advance_SQL_SERVER_with_API.Data.Student", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("age")
                        .HasColumnType("int");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("students");

                    b.HasData(
                        new
                        {
                            id = new Guid("19564871-b6a2-4a05-86f9-f2f96871eed1"),
                            age = 21,
                            name = "Test"
                        },
                        new
                        {
                            id = new Guid("c37c1af0-5c94-448b-b3ac-05c6f1a12231"),
                            age = 22,
                            name = "Test2"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
