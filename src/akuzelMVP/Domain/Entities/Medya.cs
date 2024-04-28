using Domain.Enums;
using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
/// <summary>
/// Sitedeki herkese açık içeriklerin medyaları
/// </summary>
public class Medya : Entity<Guid>
{
    /// <summary>
    /// medyanın formatı
    /// </summary>
    public MedyaType MedyaType { get; set; }

    /// <summary>
    /// medyanın dosya yolu
    /// </summary>
    public string Path { get; set; }

    /// <summary>
    /// medyanın ait olduğu site içeriğinin türü
    /// </summary>
    public MedyaAidiyet AidiyetType { get; set; }

    public Guid AidiyetId { get; set; }

    public Guid DuzenleyenId { get; set; }

    #region VIRTUAL REFERENCES
    /// <summary>
    /// Takım kurucusu
    /// </summary>
    public virtual User? Kullanici { get; set; }
    #endregion

}
