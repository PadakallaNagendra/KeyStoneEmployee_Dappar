using Dapper;
using KeyStoneEmployee_Dappar.Entities;
using KeyStoneEmployee_Dappar.InterFace;
using KeyStoneEmployee_Dappar.Utils;
using Microsoft.AspNetCore.Connections;
using System.Data;
using static KeyStoneEmployee_Dappar.Utils.StorePrpcedureStaticMessages;

namespace KeyStoneEmployee_Dappar.Repositary
{
    public class HotelRepositary : IHotelRepositary
    {
        IKHTConnectionFactary _connctionfactory;
        public HotelRepositary(IKHTConnectionFactary connctionfactory)
        {
            _connctionfactory = connctionfactory;
        }

        public async Task<int> AddHotel(Hotel hoteldetail)
        {
            using(IDbConnection conn = _connctionfactory.GetHotal())
            {
                var res = new DynamicParameters();
                res.Add("@hotelName", hoteldetail.hotelName);
                res.Add("@hotelLocation", hoteldetail.hotelLocation);
                res.Add("@hotelImage", hoteldetail.hotelImage);
                res.Add("@hotelDescription", hoteldetail.hotelDescription);
                res.Add("@insertedidvalue", DbType.Int32, direction: ParameterDirection.Output);
                await conn.ExecuteScalarAsync<int>(StorePrpcedureStaticMessages.AddHotelDetails, res, commandType: CommandType.StoredProcedure);
                int insertedId = res.Get<int>("@insertedidvalue");

                return insertedId;


            }
        }

        public async Task<bool> DeleteHotelByHotelid(int hotelId)
        {
            using (IDbConnection conn = _connctionfactory.GetHotal())
            {
                var p = new DynamicParameters();

                p.Add("@hotelId", hotelId);
                await conn.ExecuteScalarAsync(StorePrpcedureStaticMessages.DeleteHotel, p, commandType: CommandType.StoredProcedure);
                return true;
            }
        }

        public async Task<List<Hotel>> GetHotelDetails()
        {
            List<Hotel> result;
            //IDbConnection Object to store the sqlconnection.
            using (IDbConnection conn = _connctionfactory.GetHotal())
            {
                var queryResult = await conn.QueryAsync<Hotel>(StorePrpcedureStaticMessages.GetHotelDetails, CommandType.StoredProcedure);
                result = queryResult.ToList();
                return result;
            }
        }

        public async Task<Hotel> GetHotelDetailsByHotelid(int hotelId)
        {
            Hotel result;
            using (IDbConnection conn = _connctionfactory.GetHotal())
            {
                var p = new DynamicParameters();
                p.Add("@hotelId", hotelId);
                var hotelResult = await conn.QueryAsync<Hotel>(StorePrpcedureStaticMessages.GetHotelDetailsById, p, commandType: CommandType.StoredProcedure);
                result = hotelResult.FirstOrDefault();
                return result;
            }
        }

        public async Task<bool> UpdateHotel(Hotel hoteldetail)
        {
            using (IDbConnection conn = _connctionfactory.GetHotal())
            {
                var p = new DynamicParameters();
                p.Add("@hotelId", hoteldetail.hotelId);
                p.Add("@hotelName", hoteldetail.hotelName);
                p.Add("@hotelLocation", hoteldetail.hotelLocation);
                p.Add("@hotelImage", hoteldetail.hotelImage);
                p.Add("@hotelDescription", hoteldetail.hotelDescription);
                await conn.ExecuteScalarAsync(StorePrpcedureStaticMessages.UpdateHotel, p, commandType: CommandType.StoredProcedure);
                return true;
            }
        }
    }
}
