﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using TarefaNinja.DAL;

#nullable disable

namespace TarefaNinja.API.Migrations
{
    [DbContext(typeof(DefaultContext))]
    [Migration("20240304055259_SoftDelete")]
    partial class SoftDelete
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("TarefaNinja.DAL.Models.CompanyModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("created");

                    b.Property<DateTime?>("Deleted")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("deleted");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<DateTime?>("Updated")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("updated");

                    b.HasKey("Id")
                        .HasName("pk_companies");

                    b.ToTable("companies", (string)null);
                });

            modelBuilder.Entity("TarefaNinja.DAL.Models.LabelModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("color");

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("created");

                    b.Property<DateTime?>("Deleted")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("deleted");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<Guid>("ProjectId")
                        .HasColumnType("uuid")
                        .HasColumnName("project_id");

                    b.Property<DateTime?>("Updated")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("updated");

                    b.HasKey("Id")
                        .HasName("pk_labels");

                    b.HasIndex("ProjectId")
                        .HasDatabaseName("ix_labels_project_id");

                    b.ToTable("labels", (string)null);
                });

            modelBuilder.Entity("TarefaNinja.DAL.Models.ProjectModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<Guid>("CompanyId")
                        .HasColumnType("uuid")
                        .HasColumnName("company_id");

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("created");

                    b.Property<DateTime?>("Deleted")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("deleted");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<Guid>("OwnerId")
                        .HasColumnType("uuid")
                        .HasColumnName("owner_id");

                    b.Property<int>("Status")
                        .HasColumnType("integer")
                        .HasColumnName("status");

                    b.Property<DateTime?>("Updated")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("updated");

                    b.HasKey("Id")
                        .HasName("pk_projects");

                    b.HasIndex("CompanyId")
                        .HasDatabaseName("ix_projects_company_id");

                    b.HasIndex("OwnerId")
                        .HasDatabaseName("ix_projects_owner_id");

                    b.ToTable("projects", (string)null);
                });

            modelBuilder.Entity("TarefaNinja.DAL.Models.TaskModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<Guid?>("AssigneeId")
                        .IsRequired()
                        .HasColumnType("uuid")
                        .HasColumnName("assignee_id");

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("created");

                    b.Property<DateTime?>("Deleted")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("deleted");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<Guid>("ProjectId")
                        .HasColumnType("uuid")
                        .HasColumnName("project_id");

                    b.Property<int>("Status")
                        .HasColumnType("integer")
                        .HasColumnName("status");

                    b.Property<DateTime?>("Updated")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("updated");

                    b.HasKey("Id")
                        .HasName("pk_tasks");

                    b.HasIndex("AssigneeId")
                        .HasDatabaseName("ix_tasks_assignee_id");

                    b.HasIndex("ProjectId")
                        .HasDatabaseName("ix_tasks_project_id");

                    b.ToTable("tasks", (string)null);
                });

            modelBuilder.Entity("TarefaNinja.DAL.Models.UserCompanyModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<Guid>("CompanyId")
                        .HasColumnType("uuid")
                        .HasColumnName("company_id");

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("created");

                    b.Property<DateTime?>("Deleted")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("deleted");

                    b.Property<int>("Role")
                        .HasColumnType("integer")
                        .HasColumnName("role");

                    b.Property<DateTime?>("Updated")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("updated");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid")
                        .HasColumnName("user_id");

                    b.HasKey("Id")
                        .HasName("pk_users_companies");

                    b.HasIndex("CompanyId")
                        .HasDatabaseName("ix_users_companies_company_id");

                    b.HasIndex("UserId")
                        .HasDatabaseName("ix_users_companies_user_id");

                    b.ToTable("users_companies", (string)null);
                });

            modelBuilder.Entity("TarefaNinja.DAL.Models.UserModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("created");

                    b.Property<DateTime?>("Deleted")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("deleted");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("email");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("password");

                    b.Property<DateTime?>("Updated")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("updated");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("username");

                    b.HasKey("Id")
                        .HasName("pk_users");

                    b.ToTable("users", (string)null);
                });

            modelBuilder.Entity("TaskModelUserModel", b =>
                {
                    b.Property<Guid>("FollowersId")
                        .HasColumnType("uuid")
                        .HasColumnName("followers_id");

                    b.Property<Guid>("FollowingId")
                        .HasColumnType("uuid")
                        .HasColumnName("following_id");

                    b.HasKey("FollowersId", "FollowingId")
                        .HasName("pk_task_followers");

                    b.HasIndex("FollowingId")
                        .HasDatabaseName("ix_task_followers_following_id");

                    b.ToTable("TaskFollowers", (string)null);
                });

            modelBuilder.Entity("TarefaNinja.DAL.Models.LabelModel", b =>
                {
                    b.HasOne("TarefaNinja.DAL.Models.ProjectModel", "Project")
                        .WithMany("Labels")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_labels_projects_project_id");

                    b.Navigation("Project");
                });

            modelBuilder.Entity("TarefaNinja.DAL.Models.ProjectModel", b =>
                {
                    b.HasOne("TarefaNinja.DAL.Models.CompanyModel", "Company")
                        .WithMany()
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_projects_companies_company_id");

                    b.HasOne("TarefaNinja.DAL.Models.UserModel", "Owner")
                        .WithMany("Projects")
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_projects_users_owner_id");

                    b.Navigation("Company");

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("TarefaNinja.DAL.Models.TaskModel", b =>
                {
                    b.HasOne("TarefaNinja.DAL.Models.UserModel", "Assignee")
                        .WithMany("Tasks")
                        .HasForeignKey("AssigneeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_tasks_users_assignee_id");

                    b.HasOne("TarefaNinja.DAL.Models.ProjectModel", "Project")
                        .WithMany("Tasks")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_tasks_projects_project_id");

                    b.Navigation("Assignee");

                    b.Navigation("Project");
                });

            modelBuilder.Entity("TarefaNinja.DAL.Models.UserCompanyModel", b =>
                {
                    b.HasOne("TarefaNinja.DAL.Models.CompanyModel", "Company")
                        .WithMany("UserCompanies")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_users_companies_companies_company_id");

                    b.HasOne("TarefaNinja.DAL.Models.UserModel", "User")
                        .WithMany("UserCompanies")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_users_companies_users_user_id");

                    b.Navigation("Company");

                    b.Navigation("User");
                });

            modelBuilder.Entity("TaskModelUserModel", b =>
                {
                    b.HasOne("TarefaNinja.DAL.Models.UserModel", null)
                        .WithMany()
                        .HasForeignKey("FollowersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_task_followers_users_followers_id");

                    b.HasOne("TarefaNinja.DAL.Models.TaskModel", null)
                        .WithMany()
                        .HasForeignKey("FollowingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_task_followers_tasks_following_id");
                });

            modelBuilder.Entity("TarefaNinja.DAL.Models.CompanyModel", b =>
                {
                    b.Navigation("UserCompanies");
                });

            modelBuilder.Entity("TarefaNinja.DAL.Models.ProjectModel", b =>
                {
                    b.Navigation("Labels");

                    b.Navigation("Tasks");
                });

            modelBuilder.Entity("TarefaNinja.DAL.Models.UserModel", b =>
                {
                    b.Navigation("Projects");

                    b.Navigation("Tasks");

                    b.Navigation("UserCompanies");
                });
#pragma warning restore 612, 618
        }
    }
}
