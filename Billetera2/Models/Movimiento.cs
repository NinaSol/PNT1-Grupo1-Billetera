using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace Billetera2.Models
{
    public class Movimiento
    {
        
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Este campo es requerido")]
        [Range(1, 999999999, ErrorMessage = "El valor debe estar entre {1} y {2}")]
        public double Monto { get; set; }

        [MaxLength(180, ErrorMessage = "El maximo permitido para el {0} es {1}")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "Debe informar la fecha su movimiento")]
        [Display(Name = "Fecha del movimiento")]
        [DataType(DataType.Date)]
        public DateTime Fecha { get; set; }

        [Required(ErrorMessage = "El {0} es requerido")]
        [MaxLength(3, ErrorMessage = "El maximo permitido para el {0} es {1}")]
        public string TipoMovimiento { get; set; }

        [Required]
        [ForeignKey(nameof(Usuario))]
        public Guid UsuarioId { get; set; }
        public Usuario Usuario { get; set; }


    }
}
