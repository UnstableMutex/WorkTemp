using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentMigrator;

namespace Migrations
{
    [Migration(20170406)]
    public class AddSubTable:Migration
    {
        public override void Up()
        {
     
            Create.Table("SubTable").
                WithColumn("ID").AsInt32().Identity().
                WithColumn("Name").AsString(50).NotNullable().
                WithColumn("MainTable_ID").AsInt32().ForeignKey("MainTable", "ID");
        }

        public override void Down()
        {
            Delete.Table("SubTable");
        }
    }
    [Migration(20170407)]
   public  class AddMainTableData:Migration
    {
        public override void Up()
        {
            Insert.IntoTable("MainTable").Row(new {Name = "SampleData"});
        }

        public override void Down()
        {
           Delete.FromTable("MainTable").AllRows();
        }
    }
}
