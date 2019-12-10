namespace Model
{
    using System.Data.Entity;

    public partial class Context : DbContext
    {
        public Context()
            : base("data source=sql.vt.tpu.ru;initial catalog=8IM81_Cherepanov_Copy;persist security info=True;user id=isc4;password=skq97kFz;MultipleActiveResultSets=True;App=EntityFramework")
        {
        }

        public virtual DbSet<Добыча> Добыча { get; set; }
        public virtual DbSet<Месторождения> Месторождения { get; set; }
        public virtual DbSet<Скважины> Скважины { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Месторождения>()
                .HasMany(e => e.Скважины)
                .WithRequired(e => e.Месторождения)
                .HasForeignKey(e => e.ID_Месторождения)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Скважины>()
                .HasMany(e => e.Добыча)
                .WithRequired(e => e.Скважины)
                .HasForeignKey(e => e.ID_Скважины)
                .WillCascadeOnDelete(false);
        }
    }
}
