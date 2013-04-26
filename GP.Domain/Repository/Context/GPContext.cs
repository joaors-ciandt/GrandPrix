using System.Collections.Generic;
using System.Data.Entity;
using CustomFramework.Enumerations;
using CustomFramework.Security.Membership.Model;



namespace GP.Domain.Repository.Context
{
    internal class GPContext : DbContext
    {

        public GPContext()
            : base("DefaultConnectionString")
        {
            //if (!this.Database.Exists())
            //{
            //    this.Database.Create();
                

            //    this.Features.Add(new Feature() { Name = "Inicio" });
            //    this.Features.Add(new Feature() { Name = "Funcionalidade" });
            //    this.Features.Add(new Feature() { Name = "Usuario" });
            //    this.Features.Add(new Feature() { Name = "Perfil" });           


            //    this.Roles.Add(new Role() { Name = "Convidado" });
            //    this.Permissions.Add(new Permission() { Feature = this.Features.Local[0], Role = this.Roles.Local[0], AccessLevelType = RolePermissionType.Read, HierarchyLevelType = HierarchyLevelAccess.Ownership });
            //    this.Permissions.Add(new Permission() { Feature = this.Features.Local[1], Role = this.Roles.Local[0], AccessLevelType = RolePermissionType.Read, HierarchyLevelType = HierarchyLevelAccess.Ownership });
            //    this.Permissions.Add(new Permission() { Feature = this.Features.Local[2], Role = this.Roles.Local[0], AccessLevelType = RolePermissionType.Read, HierarchyLevelType = HierarchyLevelAccess.Ownership });
            //    this.Permissions.Add(new Permission() { Feature = this.Features.Local[3], Role = this.Roles.Local[0], AccessLevelType = RolePermissionType.Read, HierarchyLevelType = HierarchyLevelAccess.Ownership });


            //    this.Roles.Add(new Role() { Name = "Administrador" });
            //    this.Permissions.Add(new Permission() { Feature = this.Features.Local[0], Role = this.Roles.Local[1], AccessLevelType = RolePermissionType.Full, HierarchyLevelType = HierarchyLevelAccess.Hierarchy });
            //    this.Permissions.Add(new Permission() { Feature = this.Features.Local[1], Role = this.Roles.Local[1], AccessLevelType = RolePermissionType.Full, HierarchyLevelType = HierarchyLevelAccess.Hierarchy });
            //    this.Permissions.Add(new Permission() { Feature = this.Features.Local[2], Role = this.Roles.Local[1], AccessLevelType = RolePermissionType.Full, HierarchyLevelType = HierarchyLevelAccess.Hierarchy });
            //    this.Permissions.Add(new Permission() { Feature = this.Features.Local[3], Role = this.Roles.Local[1], AccessLevelType = RolePermissionType.Full, HierarchyLevelType = HierarchyLevelAccess.Hierarchy });
                
            //    this.Users.Add(new User() { FirstName = "Usuario", UserName = "Admin", Password = "Admin", LastName = "Padrão" });

            //    this.Users.Local[0].Roles = new List<Role>();
            //    this.Users.Local[0].Roles.Add(this.Roles.Local[0]);
            //    this.Users.Local[0].Roles.Add(this.Roles.Local[1]);

            //    this.SaveChanges();

            //}
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasMany(r => r.Roles).WithMany(u => u.Users).Map(m =>
            {
                m.ToTable("UserRoles");
                m.MapLeftKey("UserId");
                m.MapRightKey("RoleId");
            });         

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<Feature> Features { get; set; }
        

    }
}
