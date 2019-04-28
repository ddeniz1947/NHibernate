using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SBlogA.Migrations
{
    [Migration(1)]
    public class _001_Users_and_Roles : Migration
    {
        public override void Down()
        {
            Delete.Table("role_users");
            Delete.Table("roles");
            Delete.Table("users");
        }

        public override void Up()
        {
            Create.Table("users")
                .WithColumn("id").AsInt32().Identity().PrimaryKey()
                .WithColumn("username").AsString(128)
                .WithColumn("email").AsString(256)
                .WithColumn("password_hash").AsString(256);
                
                
            Create.Table("roles")
                .WithColumn("id").AsInt32().Identity().PrimaryKey()
                .WithColumn("name").AsString(128);


            Create.Table("role_users")
                .WithColumn("user_id").AsInt32().ForeignKey("users", "id").OnDelete(System.Data.Rule.Cascade)
                .WithColumn("role_id").AsInt32().ForeignKey("roles", "id").OnDelete(System.Data.Rule.Cascade);

                
        }
    }
}