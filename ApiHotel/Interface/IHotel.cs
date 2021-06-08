using ApiHotel.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiHotel.Interface
{
    public interface IHotel
    {

        Task<List<EHotel>> GetListHoteles();
        Task<List<EHotel>> GetByHotelName(string nombre);


    }
}
