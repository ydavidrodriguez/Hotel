using ApiHotel.Entities;
using ApiHotel.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ApiHotel.Domain
{
    public class HotelService: IHotel
    {
        public string Conexion = "data source = DESKTOP-QL8MRD2\\SQLEXPRESS; initial catalog = hotel; user id = usrDataBases; password = usrDataBases";

        public async Task<List<EHotel>> GetByHotelName(string nombre) 
        {
            List<EHotel> lsthotel = new List<EHotel>();
            try
            {
                using (SqlConnection conexion = new SqlConnection(Conexion))
                {
                    conexion.Open();

                    SqlCommand cmd = new SqlCommand("dbo.FiltrarListhoteles", conexion);
                    cmd.Parameters.AddWithValue("@nombre", nombre);

                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            EHotel hotel = new EHotel();
                            Pais pais = new Pais();
                            Ciudad ciudad = new Ciudad();
                            hotel.Pais = pais;
                            hotel.ciudad = ciudad;
                            hotel.Id = dr.GetInt32(0);
                            hotel.Nombre = dr.GetString(1);
                            hotel.Telefono = dr.GetString(2);
                            hotel.Direccion = dr.GetString(3);
                            hotel.ciudad.Id = dr.GetInt32(4);
                            hotel.ciudad.Nombre = dr.GetString(5);
                            hotel.Pais.Id = dr.GetInt32(6);
                            hotel.Pais.Nombre = dr.GetString(7);

                            lsthotel.Add(hotel);

                        }
                    }
                    else
                    {
                        Console.WriteLine("No rows found.");
                    }



                    conexion.Close();
                }

            }
            catch (ExecutionEngineException ex)
            {


            }

            return lsthotel;

        }


        public async Task<List<EHotel>> GetListHoteles()
        {
            List<EHotel> ListHotel = new List<EHotel>();
            try
            {
                using (SqlConnection conexion = new SqlConnection(Conexion))
                {
                    conexion.Open();

                    SqlCommand cmd = new SqlCommand("dbo.Listhoteles", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            EHotel hotel = new EHotel();
                            Pais pais = new Pais();
                            Ciudad ciudad = new Ciudad();
                            hotel.Pais = pais;
                            hotel.ciudad = ciudad;
                            hotel.Id = dr.GetInt32(0);
                            hotel.Nombre = dr.GetString(1);
                            hotel.Telefono = dr.GetString(2);
                            hotel.Direccion = dr.GetString(3);
                            hotel.ciudad.Id = dr.GetInt32(4);
                            hotel.ciudad.Nombre = dr.GetString(5);
                            hotel.Pais.Id = dr.GetInt32(6);
                            hotel.Pais.Nombre = dr.GetString(7);

                            ListHotel.Add(hotel);

                        }
                    }
                    else
                    {
                        Console.WriteLine("No rows found.");
                    }



                    conexion.Close();
                }

            }
            catch (ExecutionEngineException ex)
            {


            }

            return ListHotel;
        }

    }
}
