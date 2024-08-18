using KeyStoneEmployee_Dappar.InterFace;
using KeyStoneEmployee_Dappar.ModelDTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KeyStoneEmployee_Dappar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelController : ControllerBase
    {
        IHotelService _service;
        public HotelController(IHotelService service)
        {
            _service = service;
        }
        [HttpPost(Name = "AddHotel")]
        public async Task<IActionResult> Post([FromBody] HotelDTO htldto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, ModelState);
                }
                var sipdata = await _service.AddHotel(htldto);
                return StatusCode(StatusCodes.Status200OK, sipdata);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "server error");
            }

        }
        [HttpDelete(Name = "DeleteHotelDetailById/{hotelId}")]
        //        [HttpDelete]
        // [Route("DeleteBookingDetilsById/{id}")]

        public async Task<IActionResult> Delete(int hotelId)
        {
            if (hotelId < 0)
            {
                return StatusCode(StatusCodes.Status400BadRequest, "bad request");
            }
            try
            {
                var htldata = await _service.DeleteHotelByHotelid(hotelId);
                if (htldata == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound, "hotelId not found");
                }
                else
                {
                    return StatusCode(StatusCodes.Status204NoContent, "hotelId is deleted succesfully");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "server not found");
            }
        }
        [HttpGet(Name = "GetHotelDetails")]
        public async Task<IActionResult> GetHotelDetails()
        {
            try
            {
                var htldata = await _service.GetHotelDetails();
                if (htldata == null)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, "bad request");
                }
                else
                {
                    return StatusCode(StatusCodes.Status200OK, htldata);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "server not found");
            }
        }
        // [HttpGet(Name = "GetSipdashboardByPosition/{position}")]
        //        [Route("GetBookingDetailsById/{id}")]
        [HttpGet]
        [Route("GetHotelDetailsByHotelId/{hotelId}")]

        public async Task<IActionResult> Get(int hotelId)
        {
            if (hotelId < 0)
            {
                return StatusCode(StatusCodes.Status400BadRequest, "bad request");
            }
            try
            {
                var htldata = await _service.GetHotelDetailsByHotelid(hotelId);
                if (htldata == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound, "sip position not found");
                }
                else
                {
                    return StatusCode(StatusCodes.Status200OK, htldata);
                }
            }
            catch (Exception ex)

            {
                return StatusCode(StatusCodes.Status500InternalServerError, "server not found");
            }

        }
        [HttpPut(Name = "UpdateHotel")]
        public async Task<IActionResult> Put([FromBody] HotelDTO htldto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, ModelState);
                }
                var countryData = await _service.UpdateHotel(htldto);
                return StatusCode(StatusCodes.Status201Created, "hotel Details Updated Succesfully");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "System or Server Error");
            }
        }
    }
}
