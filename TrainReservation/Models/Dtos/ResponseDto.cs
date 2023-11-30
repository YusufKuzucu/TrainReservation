namespace TrainReservation.Models.Dtos
{
    public class ResponseDto
    {
        public bool RezervasyonYapilabilir { get; set; }
        public YerlesimAyrinti[] YerlesimAyrinti { get; set; }
    }
    public class YerlesimAyrinti
    {
        public string VagonAdi { get; set; }
        public int KisiSayisi { get; set; }
    }
}
