using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Takims.Queries.GetFilteredList;
public class GetFilteredListTakimFilterDto
{
    public Guid? KurucuId { get; set; }

    public string? Adi { get; set; }

    public string? KurucuAdi { get; set; }
}
