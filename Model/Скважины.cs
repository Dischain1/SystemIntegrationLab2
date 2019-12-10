namespace Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Скважины
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Скважины()
        {
            Добыча = new HashSet<Добыча>();
        }

        public Guid ID { get; set; }

        [Required]
        [StringLength(10)]
        public string Номер { get; set; }

        public int Глубина { get; set; }

        [Required]
        [StringLength(15)]
        public string Тип { get; set; }

        [Column("Дата бурения", TypeName = "date")]
        public DateTime Дата_бурения { get; set; }

        public Guid ID_Месторождения { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Добыча> Добыча { get; set; }

        public virtual Месторождения Месторождения { get; set; }
    }
}
