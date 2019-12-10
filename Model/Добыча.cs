namespace Model
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Добыча
    {
        [Key]
        public Guid ID_Добычи { get; set; }

        [Column(TypeName = "date")]
        public DateTime Дата { get; set; }

        public int Значение { get; set; }

        public Guid ID_Скважины { get; set; }

        public virtual Скважины Скважины { get; set; }
    }
}
