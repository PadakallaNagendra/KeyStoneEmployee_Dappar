using KeyStoneEmployee_Dappar.Entities;
using KeyStoneEmployee_Dappar.ModelDTO;

namespace KeyStoneEmployee_Dappar.InterFace
{
    public interface IHotelService
    {
        Task<List<HotelDTO>> GetHotelDetails();
        Task<HotelDTO> GetHotelDetailsByHotelid(int hotelId);
        Task<int> AddHotel(HotelDTO hoteldetailDto);
        Task<bool> UpdateHotel(HotelDTO hoteldetailDto);
        Task<bool> DeleteHotelByHotelid(int hotelId);
    }
}
