﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ToDoApp.Modules.Tasks.API.Infrastructure.Persistence;
using ToDoApp.Modules.Tasks.Persistence;

#nullable disable

namespace ToDoApp.Modules.Tasks.Persistence.Migrations
{
    [DbContext(typeof(TasksContext))]
	partial class TasksContextModelSnapshot : ModelSnapshot
	{
		protected override void BuildModel(ModelBuilder modelBuilder)
		{
#pragma warning disable 612, 618
			modelBuilder
				.HasDefaultSchema("tasks")
				.HasAnnotation("ProductVersion", "7.0.0")
				.HasAnnotation("Relational:MaxIdentifierLength", 128);

			SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

			modelBuilder.Entity("ToDoApp.Modules.Tasks.Domain.Entities.ToDoItem", b =>
				{
					b.Property<Guid>("Id")
						.ValueGeneratedOnAdd()
						.HasColumnType("uniqueidentifier");

					b.Property<DateTime?>("CompletedDate")
						.HasColumnType("datetime2");

					b.Property<DateTime>("CreatedDate")
						.HasColumnType("datetime2");

					b.Property<string>("Description")
						.IsRequired()
						.HasColumnType("nvarchar(max)");

					b.Property<int>("Status")
						.HasColumnType("int");

					b.Property<string>("Username")
						.IsRequired()
						.HasColumnType("nvarchar(max)");

					b.HasKey("Id");

					b.ToTable("ToDoItems", "tasks");
				});
#pragma warning restore 612, 618
		}
	}
}
