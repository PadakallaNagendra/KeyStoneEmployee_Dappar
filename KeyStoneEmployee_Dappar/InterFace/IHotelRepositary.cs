using KeyStoneEmployee_Dappar.Entities;

namespace KeyStoneEmployee_Dappar.InterFace
{
    public interface IHotelRepositary
    {
        Task<List<Hotel>> GetHotelDetails();
        Task<Hotel> GetHotelDetailsByHotelid(int hotelId);
        Task<int> AddHotel(Hotel hoteldetail);
        Task<bool> UpdateHotel(Hotel hoteldetail);
        Task<bool> DeleteHotelByHotelid(int hotelId);
    }
}
