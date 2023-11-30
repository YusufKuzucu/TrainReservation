using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrainReservation.Models;
using TrainReservation.Models.Dtos;
using TrainReservation.Services;

namespace TrainReservation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RezervasyonController : ControllerBase
    {

        [HttpPost]
        [Route("rezervasyon")]
        public IActionResult RezervasyonYap(RezervasyonBilgisi rezervasyonBilgisi)
        {
            //Şöyle düşündüm;
            // İki buton olsaydı ve kullanıcı birini seçmiş olsaydı, senaryosunu kurup tek kontrollırda bitirdim olayı.
            if (rezervasyonBilgisi.KisilerFarkliVagonlaraYerlestirilebilir==true)
            {
                ResponseDto responseDto = RezervasyonService.RezervasyonYap(rezervasyonBilgisi);
                return Ok(responseDto);
            }
            else
            {
                ResponseDto responseDto = RezervasyonService.RezervasyonYap2(rezervasyonBilgisi);
                return Ok(responseDto);
            }
        }
    }
}
