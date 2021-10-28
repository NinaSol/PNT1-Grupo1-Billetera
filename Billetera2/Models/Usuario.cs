using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


namespace Billetera2.Models
{
    public class Usuario
    {
        
        [Key]
        public Guid Id { get; set; }

        [MaxLength(180, ErrorMessage = "El maximo permitido para el {0} es {1}")]
        public string Nombre { get; set; }

        [MaxLength(180, ErrorMessage = "El maximo permitido para el {0} es {1}")]
        public string Apellido { get; set; }

        public IEnumerable<Movimiento> Movimientos { get; set; }




    }
}
