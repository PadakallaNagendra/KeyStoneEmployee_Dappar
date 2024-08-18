using KeyStoneEmployee_Dappar.Entities;
using KeyStoneEmployee_Dappar.InterFace;
using KeyStoneEmployee_Dappar.ModelDTO;

namespace KeyStoneEmployee_Dappar.Service
{
    public class HotelService : IHotelService
    {
        IHotelRepositary _hotelRepositary;
        public HotelService(IHotelRepositary hotelRepositary)
        {
            _hotelRepositary = hotelRepositary;
        }

        public async Task<int> AddHotel(HotelDTO hoteldetailDto)
        {
            Hotel obj = new Hotel();
            obj.hotelId = hoteldetailDto.hotelId;
            obj.hotelName= hoteldetailDto.hotelName;
            obj.hotelImage= hoteldetailDto.hotelImage;
            obj.hotelLocation=hoteldetailDto.hotelLocation;
            obj.hotelDescription = hoteldetailDto.hotelDescription;
             var res=await _hotelRepositary.AddHotel(obj);
            return res;
        }

        public async Task<bool> DeleteHotelByHotelid(int hotelId)
        {
            await _hotelRepositary.DeleteHotelByHotelid(hotelId);
            return true;

        }

        public async Task<List<HotelDTO>> GetHotelDetails()
        {
            List<HotelDTO> lst = new List<HotelDTO>();
            var result = await _hotelRepositary.GetHotelDetails();
            foreach (Hotel htl in result)
            {
                HotelDTO htldto = new HotelDTO();
                htldto.hotelId = htl.hotelId;
                htldto.hotelDescription = htl.hotelDescription;
                htldto.hotelName = htl.hotelName;
                htldto.hotelLocation = htl.hotelLocation;
                htldto.hotelImage = htl.hotelImage;
                lst.Add(htldto);
            }
            return lst;
        }

        public async Task<HotelDTO> GetHotelDetailsByHotelid(int hotelId)
        {
            var result = await _hotelRepositary.GetHotelDetailsByHotelid(hotelId);

            HotelDTO htldto = new HotelDTO();
            htldto.hotelId = result.hotelId;
            htldto.hotelDescription = result.hotelDescription;
            htldto.hotelLocation = result.hotelLocation;
            htldto.hotelName = result.hotelName;
            htldto.hotelImage = result.hotelImage;

            return htldto;
        }

        public async Task<bool> UpdateHotel(HotelDTO hoteldetailDto)
        {
            Hotel htldto = new Hotel();
            htldto.hotelId = hoteldetailDto.hotelId;
            htldto.hotelDescription = hoteldetailDto.hotelDescription;
            htldto.hotelLocation = hoteldetailDto.hotelLocation;
            htldto.hotelName = hoteldetailDto.hotelName;
            htldto.hotelImage = hoteldetailDto.hotelImage;
            await _hotelRepositary.UpdateHotel(htldto);
            return true;
        }
    }
}
