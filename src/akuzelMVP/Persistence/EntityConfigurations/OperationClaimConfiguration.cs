using Application.Features.Auth.Constants;
using Application.Features.OperationClaims.Constants;
using Application.Features.UserOperationClaims.Constants;
using Application.Features.Users.Constants;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NArchitecture.Core.Security.Constants;
using Application.Features.BakiyeGecmisis.Constants;
using Application.Features.BankaHesaps.Constants;
using Application.Features.Bildirims.Constants;
using Application.Features.Degerlendirmes.Constants;
using Application.Features.Ilans.Constants;
using Application.Features.IlanListes.Constants;
using Application.Features.KullaniciAyars.Constants;
using Application.Features.KullaniciBildirims.Constants;
using Application.Features.KullaniciTakims.Constants;
using Application.Features.Kupons.Constants;
using Application.Features.Listes.Constants;
using Application.Features.ListeVeris.Constants;
using Application.Features.Medyas.Constants;
using Application.Features.Mesajs.Constants;
using Application.Features.MesajEks.Constants;

namespace Persistence.EntityConfigurations;

public class OperationClaimConfiguration : IEntityTypeConfiguration<OperationClaim>
{
    public void Configure(EntityTypeBuilder<OperationClaim> builder)
    {
        builder.ToTable("OperationClaims").HasKey(oc => oc.Id);

        builder.Property(oc => oc.Id).HasColumnName("Id").IsRequired();
        builder.Property(oc => oc.Name).HasColumnName("Name").IsRequired();
        builder.Property(oc => oc.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(oc => oc.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(oc => oc.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(oc => !oc.DeletedDate.HasValue);

        builder.HasData(_seeds);

        builder.HasBaseType((string)null!);
    }

    public static int AdminId => 1;
    private IEnumerable<OperationClaim> _seeds
    {
        get
        {
            yield return new() { Id = AdminId, Name = GeneralOperationClaims.Admin };

            IEnumerable<OperationClaim> featureOperationClaims = getFeatureOperationClaims(AdminId);
            foreach (OperationClaim claim in featureOperationClaims)
                yield return claim;
        }
    }

#pragma warning disable S1854 // Unused assignments should be removed
    private IEnumerable<OperationClaim> getFeatureOperationClaims(int initialId)
    {
        int lastId = initialId;
        List<OperationClaim> featureOperationClaims = new();

        #region Auth
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = AuthOperationClaims.Admin },
                new() { Id = ++lastId, Name = AuthOperationClaims.Read },
                new() { Id = ++lastId, Name = AuthOperationClaims.Write },
                new() { Id = ++lastId, Name = AuthOperationClaims.RevokeToken },
            ]
        );
        #endregion

        #region OperationClaims
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = OperationClaimsOperationClaims.Admin },
                new() { Id = ++lastId, Name = OperationClaimsOperationClaims.Read },
                new() { Id = ++lastId, Name = OperationClaimsOperationClaims.Write },
                new() { Id = ++lastId, Name = OperationClaimsOperationClaims.Create },
                new() { Id = ++lastId, Name = OperationClaimsOperationClaims.Update },
                new() { Id = ++lastId, Name = OperationClaimsOperationClaims.Delete },
            ]
        );
        #endregion

        #region UserOperationClaims
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = UserOperationClaimsOperationClaims.Admin },
                new() { Id = ++lastId, Name = UserOperationClaimsOperationClaims.Read },
                new() { Id = ++lastId, Name = UserOperationClaimsOperationClaims.Write },
                new() { Id = ++lastId, Name = UserOperationClaimsOperationClaims.Create },
                new() { Id = ++lastId, Name = UserOperationClaimsOperationClaims.Update },
                new() { Id = ++lastId, Name = UserOperationClaimsOperationClaims.Delete },
            ]
        );
        #endregion

        #region Users
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = UsersOperationClaims.Admin },
                new() { Id = ++lastId, Name = UsersOperationClaims.Read },
                new() { Id = ++lastId, Name = UsersOperationClaims.Write },
                new() { Id = ++lastId, Name = UsersOperationClaims.Create },
                new() { Id = ++lastId, Name = UsersOperationClaims.Update },
                new() { Id = ++lastId, Name = UsersOperationClaims.Delete },
            ]
        );
        #endregion

        
        #region BakiyeGecmisis CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = BakiyeGecmisisOperationClaims.Admin },
                new() { Id = ++lastId, Name = BakiyeGecmisisOperationClaims.Read },
                new() { Id = ++lastId, Name = BakiyeGecmisisOperationClaims.Write },
                new() { Id = ++lastId, Name = BakiyeGecmisisOperationClaims.Create },
                new() { Id = ++lastId, Name = BakiyeGecmisisOperationClaims.Update },
                new() { Id = ++lastId, Name = BakiyeGecmisisOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region BankaHesaps CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = BankaHesapsOperationClaims.Admin },
                new() { Id = ++lastId, Name = BankaHesapsOperationClaims.Read },
                new() { Id = ++lastId, Name = BankaHesapsOperationClaims.Write },
                new() { Id = ++lastId, Name = BankaHesapsOperationClaims.Create },
                new() { Id = ++lastId, Name = BankaHesapsOperationClaims.Update },
                new() { Id = ++lastId, Name = BankaHesapsOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region Bildirims CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = BildirimsOperationClaims.Admin },
                new() { Id = ++lastId, Name = BildirimsOperationClaims.Read },
                new() { Id = ++lastId, Name = BildirimsOperationClaims.Write },
                new() { Id = ++lastId, Name = BildirimsOperationClaims.Create },
                new() { Id = ++lastId, Name = BildirimsOperationClaims.Update },
                new() { Id = ++lastId, Name = BildirimsOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region Degerlendirmes CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = DegerlendirmesOperationClaims.Admin },
                new() { Id = ++lastId, Name = DegerlendirmesOperationClaims.Read },
                new() { Id = ++lastId, Name = DegerlendirmesOperationClaims.Write },
                new() { Id = ++lastId, Name = DegerlendirmesOperationClaims.Create },
                new() { Id = ++lastId, Name = DegerlendirmesOperationClaims.Update },
                new() { Id = ++lastId, Name = DegerlendirmesOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region Ilans CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = IlansOperationClaims.Admin },
                new() { Id = ++lastId, Name = IlansOperationClaims.Read },
                new() { Id = ++lastId, Name = IlansOperationClaims.Write },
                new() { Id = ++lastId, Name = IlansOperationClaims.Create },
                new() { Id = ++lastId, Name = IlansOperationClaims.Update },
                new() { Id = ++lastId, Name = IlansOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region IlanListes CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = IlanListesOperationClaims.Admin },
                new() { Id = ++lastId, Name = IlanListesOperationClaims.Read },
                new() { Id = ++lastId, Name = IlanListesOperationClaims.Write },
                new() { Id = ++lastId, Name = IlanListesOperationClaims.Create },
                new() { Id = ++lastId, Name = IlanListesOperationClaims.Update },
                new() { Id = ++lastId, Name = IlanListesOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region KullaniciAyars CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = KullaniciAyarsOperationClaims.Admin },
                new() { Id = ++lastId, Name = KullaniciAyarsOperationClaims.Read },
                new() { Id = ++lastId, Name = KullaniciAyarsOperationClaims.Write },
                new() { Id = ++lastId, Name = KullaniciAyarsOperationClaims.Create },
                new() { Id = ++lastId, Name = KullaniciAyarsOperationClaims.Update },
                new() { Id = ++lastId, Name = KullaniciAyarsOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region KullaniciBildirims CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = KullaniciBildirimsOperationClaims.Admin },
                new() { Id = ++lastId, Name = KullaniciBildirimsOperationClaims.Read },
                new() { Id = ++lastId, Name = KullaniciBildirimsOperationClaims.Write },
                new() { Id = ++lastId, Name = KullaniciBildirimsOperationClaims.Create },
                new() { Id = ++lastId, Name = KullaniciBildirimsOperationClaims.Update },
                new() { Id = ++lastId, Name = KullaniciBildirimsOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region KullaniciTakims CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = KullaniciTakimsOperationClaims.Admin },
                new() { Id = ++lastId, Name = KullaniciTakimsOperationClaims.Read },
                new() { Id = ++lastId, Name = KullaniciTakimsOperationClaims.Write },
                new() { Id = ++lastId, Name = KullaniciTakimsOperationClaims.Create },
                new() { Id = ++lastId, Name = KullaniciTakimsOperationClaims.Update },
                new() { Id = ++lastId, Name = KullaniciTakimsOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region Kupons CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = KuponsOperationClaims.Admin },
                new() { Id = ++lastId, Name = KuponsOperationClaims.Read },
                new() { Id = ++lastId, Name = KuponsOperationClaims.Write },
                new() { Id = ++lastId, Name = KuponsOperationClaims.Create },
                new() { Id = ++lastId, Name = KuponsOperationClaims.Update },
                new() { Id = ++lastId, Name = KuponsOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region Listes CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = ListesOperationClaims.Admin },
                new() { Id = ++lastId, Name = ListesOperationClaims.Read },
                new() { Id = ++lastId, Name = ListesOperationClaims.Write },
                new() { Id = ++lastId, Name = ListesOperationClaims.Create },
                new() { Id = ++lastId, Name = ListesOperationClaims.Update },
                new() { Id = ++lastId, Name = ListesOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region ListeVeris CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = ListeVerisOperationClaims.Admin },
                new() { Id = ++lastId, Name = ListeVerisOperationClaims.Read },
                new() { Id = ++lastId, Name = ListeVerisOperationClaims.Write },
                new() { Id = ++lastId, Name = ListeVerisOperationClaims.Create },
                new() { Id = ++lastId, Name = ListeVerisOperationClaims.Update },
                new() { Id = ++lastId, Name = ListeVerisOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region Medyas CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = MedyasOperationClaims.Admin },
                new() { Id = ++lastId, Name = MedyasOperationClaims.Read },
                new() { Id = ++lastId, Name = MedyasOperationClaims.Write },
                new() { Id = ++lastId, Name = MedyasOperationClaims.Create },
                new() { Id = ++lastId, Name = MedyasOperationClaims.Update },
                new() { Id = ++lastId, Name = MedyasOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region Mesajs CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = MesajsOperationClaims.Admin },
                new() { Id = ++lastId, Name = MesajsOperationClaims.Read },
                new() { Id = ++lastId, Name = MesajsOperationClaims.Write },
                new() { Id = ++lastId, Name = MesajsOperationClaims.Create },
                new() { Id = ++lastId, Name = MesajsOperationClaims.Update },
                new() { Id = ++lastId, Name = MesajsOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region MesajEks CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = MesajEksOperationClaims.Admin },
                new() { Id = ++lastId, Name = MesajEksOperationClaims.Read },
                new() { Id = ++lastId, Name = MesajEksOperationClaims.Write },
                new() { Id = ++lastId, Name = MesajEksOperationClaims.Create },
                new() { Id = ++lastId, Name = MesajEksOperationClaims.Update },
                new() { Id = ++lastId, Name = MesajEksOperationClaims.Delete },
            ]
        );
        #endregion
        
        return featureOperationClaims;
    }
#pragma warning restore S1854 // Unused assignments should be removed
}
