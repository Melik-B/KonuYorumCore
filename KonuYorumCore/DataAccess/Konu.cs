using System;
using System.Collections.Generic;

namespace KonuYorumCore.DataAccess
{
    public partial class Konu
    {
        public Konu()
        {
            Yorum = new HashSet<Yorum>();
        }

        public int Id { get; set; }
        public string Baslik { get; set; }
        public string Aciklama { get; set; }

        public virtual ICollection<Yorum> Yorum { get; set; }
    }
}
