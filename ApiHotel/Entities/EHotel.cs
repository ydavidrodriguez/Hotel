using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiHotel.Entities
{
    public class EHotel
    {

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public Pais Pais { get; set; }
        public Ciudad ciudad { get; set; }


    }
}
