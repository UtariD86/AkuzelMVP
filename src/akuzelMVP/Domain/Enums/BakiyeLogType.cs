using Domain.Utilities.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Enums;
public enum BakiyeLogType
{
    [EnumTitle("Satın Alma")]
    SatinAlma =1,

    [EnumTitle("İade")]
    Iade,

    [EnumTitle("Para Yükleme")]
    ParaYukleme,

    [EnumTitle("Para Çekme")]
    ParaCekme,

    [EnumTitle("Ödeme")]
    Odeme,
}
