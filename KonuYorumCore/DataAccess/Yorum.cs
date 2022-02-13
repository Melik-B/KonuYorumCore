using System;
using System.Collections.Generic;

namespace KonuYorumCore.DataAccess
{
    public partial class Yorum
    {
        public int Id { get; set; }
        public string Icerik { get; set; }
        public string Yorumcu { get; set; }
        public byte? Puan { get; set; }
        public int KonuId { get; set; }

        public virtual Konu Konu { get; set; }
    }
}
