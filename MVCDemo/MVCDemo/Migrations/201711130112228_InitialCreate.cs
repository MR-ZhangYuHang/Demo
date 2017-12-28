namespace MVCDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SysRole",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        RoleName = c.String(),
                        RoleDesc = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.SysUserRole",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        SysUserID = c.String(),
                        SysRoleID = c.String(),
                        SysRole_ID = c.Int(),
                        SysUser_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.SysRole", t => t.SysRole_ID)
                .ForeignKey("dbo.SysUser", t => t.SysUser_ID)
                .Index(t => t.SysRole_ID)
                .Index(t => t.SysUser_ID);
            
            CreateTable(
                "dbo.SysUser",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        Email = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SysUserRole", "SysUser_ID", "dbo.SysUser");
            DropForeignKey("dbo.SysUserRole", "SysRole_ID", "dbo.SysRole");
            DropIndex("dbo.SysUserRole", new[] { "SysUser_ID" });
            DropIndex("dbo.SysUserRole", new[] { "SysRole_ID" });
            DropTable("dbo.SysUser");
            DropTable("dbo.SysUserRole");
            DropTable("dbo.SysRole");
        }
    }
}
