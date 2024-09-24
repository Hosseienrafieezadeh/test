using FluentMigrator;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apps.migrations

{

    [Migration(202409241012)]
    public class AddUserTable_202409241012:Migration
    {
      
          public override void Up()
        {
            Create.Table("ApplicationUsers")
                .WithColumn("Id").AsString().PrimaryKey()
                .WithColumn("FirstName").AsString(50).NotNullable()
                .WithColumn("LastName").AsString(50).NotNullable()
                .WithColumn("Email").AsString(100).NotNullable();
        }

    

    public override void Down()
        {
            Delete.Table("ApplicationUsers");
        }
    }
}
