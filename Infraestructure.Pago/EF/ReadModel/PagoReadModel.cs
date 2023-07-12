using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infraestructure.Pagos.EF.ReadModel
{
    [Table("pago")]
    internal class PagoReadModel
    {
        [Key]
        [Column("idPago")]
        public Guid IdPago { get; set; }

        [Key]
        [Column("proyectoId")]
        public Guid ProyectoId { get; set; }

        [Required]
        [Column("monto")]
        public decimal Monto { get; set; }

        [Required]
        [Column("estado")]
        [DefaultValue(0)]
        public int Estado { get; set; }

        public PagoReadModel()
        {
        }
    }
}
