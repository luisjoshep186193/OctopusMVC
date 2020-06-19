using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Octopus.Models;

namespace Octopus.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public virtual DbSet<Lada> Ladas{ get; set; }
        public virtual DbSet<Region> Regions { get; set; }
        public virtual DbSet<WebService> WebServices { get; set; }
       
        public virtual DbSet<WebServRegion> WebServRegions { get; set; }
        public virtual DbSet<Carrier> Carriers { get; set; }
        public virtual DbSet<WebServDesc> WebServDescs { get; set; }
        public virtual DbSet<Monto> Montos { get; set; }
        public virtual DbSet<Log> Logs { get; set; }
        public virtual DbSet<Grupo> Grupos { get; set; }
        public virtual DbSet<UsuarioGrupo> UsuarioGrupos { get; set; }
        public virtual DbSet<UsuarioRegion> UsuarioRegions { get; set; }
        public virtual DbSet<Status> Statues { get; set; }

        public virtual DbSet<User> User { get; set; }
        //public virtual DbSet<Wallet> Wallets { get; set; }
        

        public virtual DbSet<Recarga> Recargas { get; set; }
        //20200510151230_addUserOwner
        public virtual DbSet<Cartera> Carteras { get; set; }
        //20200510151230_addCarteraTransactions
        public virtual DbSet<CarteraTransaction> CarteraTransactions { get; set; }
        public virtual DbSet<Rol> Rols { get; set; }

        public virtual DbSet<Producto> Productos { get; set; }
        public virtual DbSet<PType> PTypes { get; set; }
        public virtual DbSet<Image> Images { get; set; }
        public virtual DbSet<Folder> Folders { get; set; }


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<WebService>().Ignore(p => p.WSDesc);
            modelBuilder.Entity<User>().Ignore(p => p.UserDesc);
            modelBuilder.Entity<Recarga>().Ignore(p => p.ConfirmPhone);
            modelBuilder.Entity<Producto>().Ignore(p => p.File);
            modelBuilder.Entity<User>().Ignore(p => p.ComisionTAE);
            modelBuilder.Entity<Monto>().Ignore(p => p.MontoDesc);
            modelBuilder.Entity<Recarga>().Ignore(p => p.MontoCant);
            modelBuilder.Entity<Lada>().Ignore(p => p.ladasInit);
            modelBuilder.Entity<User>().Ignore(p => p.Rol);
            modelBuilder.Entity<Recarga>().Ignore(p => p.Ok);
            modelBuilder.Entity<Recarga>().Ignore(p => p.WSTempName);
            modelBuilder.Entity<Image>().Ignore(p => p.File);
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Octopus.Models.Image> Image { get; set; }
    }
}
