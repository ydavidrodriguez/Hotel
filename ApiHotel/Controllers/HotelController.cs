using ApiHotel.Domain;
using ApiHotel.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiHotel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelController : ControllerBase
    {
        private IHotel _HotelService;
        public HotelController() 
        {
            _HotelService = new HotelService();
        
        }

        [HttpPost]
        [Route("GetListHoteles")]
        public async Task<OkObjectResult> GetListHoteles()
        {
            try
            {
                var resultado = await this._HotelService.GetListHoteles();

                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return new OkObjectResult(ex.Message);
            }
        }
        [HttpGet]
        [Route("GetByHotelName")]
        public async Task<OkObjectResult> GetByHotelName(string NombreHotel)
        {
            try
            {
                var resultado = await this._HotelService.GetByHotelName(NombreHotel);

                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return new OkObjectResult(ex.Message);
            }
        }




    }
}
