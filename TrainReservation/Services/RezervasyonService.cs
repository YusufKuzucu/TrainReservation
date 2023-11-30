using TrainReservation.Models;
using TrainReservation.Models.Dtos;

namespace TrainReservation.Services
{
    public class RezervasyonService
    {
        private static Tren tren = new Tren
        {
            Ad = "Başkent Ekspres",
            Vagonlar = new Vagon[]
            {
                  new Vagon { Ad = "Vagon 1", Kapasite = 100, DoluKoltukAdet = 68 },//70-68=2
                  new Vagon { Ad = "Vagon 2", Kapasite = 90, DoluKoltukAdet = 50 },//63-50=13
                  new Vagon { Ad = "Vagon 3", Kapasite = 80, DoluKoltukAdet = 80 }
            }
        };

        public static ResponseDto RezervasyonYap(RezervasyonBilgisi rezervasyonBilgisi)
        {
            List<YerlesimAyrinti> yerlesimAyrinti = new List<YerlesimAyrinti>();
            int ekleneceKisi = rezervasyonBilgisi.RezervasyonYapilacakKisiSayisi;
            foreach (var vagon in tren.Vagonlar)
            {
                int dolulukOrani = (vagon.DoluKoltukAdet * 100) / vagon.Kapasite;

                if (dolulukOrani <= 70)
                {
                    ekleneceKisi = Math.Min(ekleneceKisi, (int)Math.Ceiling(vagon.Kapasite * 0.7) - vagon.DoluKoltukAdet);

                    vagon.DoluKoltukAdet += ekleneceKisi;

                    yerlesimAyrinti.Add(new YerlesimAyrinti
                    {
                        VagonAdi = vagon.Ad,
                        KisiSayisi = ekleneceKisi
                    });

                    rezervasyonBilgisi.RezervasyonYapilacakKisiSayisi -= ekleneceKisi;

                    if (rezervasyonBilgisi.RezervasyonYapilacakKisiSayisi == 0)
                    {
                        return new ResponseDto
                        {
                            RezervasyonYapilabilir = true,
                            YerlesimAyrinti = yerlesimAyrinti.ToArray()
                        };
                    }
                }
                else
                {
                    continue;
                }
            }
            return new ResponseDto
            {
                RezervasyonYapilabilir = false,
                YerlesimAyrinti = new YerlesimAyrinti[] { }
            };
        }
        public static ResponseDto RezervasyonYap2(RezervasyonBilgisi rezervasyonBilgisi)
        {
            List<YerlesimAyrinti> yerlesimAyrinti = new List<YerlesimAyrinti>();
            int ekleneceKisi = rezervasyonBilgisi.RezervasyonYapilacakKisiSayisi;
            foreach (var vagon in tren.Vagonlar)
            {
                int dolulukOrani = (vagon.DoluKoltukAdet * 100) / vagon.Kapasite;

                if (dolulukOrani <= 70)
                {
                    if ((vagon.DoluKoltukAdet + ekleneceKisi) * 100 / vagon.Kapasite > 70)
                    {
                        continue;
                    }
                    yerlesimAyrinti.Add(new YerlesimAyrinti
                    {
                        VagonAdi = vagon.Ad,
                        KisiSayisi = ekleneceKisi
                    });

                    rezervasyonBilgisi.RezervasyonYapilacakKisiSayisi -= ekleneceKisi;

                    if (rezervasyonBilgisi.RezervasyonYapilacakKisiSayisi == 0)
                    {
                        return new ResponseDto
                        {
                            RezervasyonYapilabilir = true,
                            YerlesimAyrinti = yerlesimAyrinti.ToArray()
                        };
                    }
                }
                else
                {
                    continue;
                }
            }
            return new ResponseDto
            {
                RezervasyonYapilabilir = false,
                YerlesimAyrinti = new YerlesimAyrinti[] { }
            };
        }
    }
}
