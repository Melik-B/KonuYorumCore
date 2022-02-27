namespace KonuYorumCore.Models
{
    public class KonuYorumLeftOuterJoinModel // KonuYorumLeftOuterJoinDTO, DTO: Data Transfer Object
    {
        #region Konu entitty'sinden gelen özelliler
        public string Baslik { get; set; }
        public string Aciklama { get; set; }
        #endregion

        #region Yorum entity'sinden gelen özellikler
        public string Icerik { get; set; }
        public string Yorumcu { get; set; }
        public int? Puan { get; set; }
        #endregion
    }
}
