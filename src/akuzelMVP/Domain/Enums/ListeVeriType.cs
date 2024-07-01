using Domain.Utilities.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Enums;
public enum ListeVeriType
{

    [EnumTitle("İl İlçe")]
    IlIlce = 1,


    [EnumTitle("Departman")]
    Departman,


    [EnumTitle("Hizmet Durumu")]
    HizmetDurum,


    [EnumTitle("Sosyal Medya")]
    SosyalMedya,


    [EnumTitle("Slayt")]
    Slayt,

    [EnumTitle("Ürün Kategori")]
    UrunKategori,

    [EnumTitle("Site Sayfa")]
    SiteSayfa,

    [EnumTitle("Ek Özellikler")]
    EkOzellikler
}
