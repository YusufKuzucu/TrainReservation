namespace TrainReservation.Models
{
    public class Vagon
    {
        public string Ad { get; set; }
        public int Kapasite { get; set; }
        public int DoluKoltukAdet { get; set; }
    }

    public class Tren
    {
        public string Ad { get; set; }
        public Vagon[] Vagonlar { get; set; }
    }

    public class RezervasyonBilgisi
    {
        public int RezervasyonYapilacakKisiSayisi { get; set; }
        public bool KisilerFarkliVagonlaraYerlestirilebilir { get; set; }

    }

}
