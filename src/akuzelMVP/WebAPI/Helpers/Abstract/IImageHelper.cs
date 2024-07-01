
using WebAPI.Controllers.Dtos;

namespace WebAPI.Helpers.Abstract
{
    /// <summary>
    /// Resim ile ilgili işlemlerin manage edileceği sınıf.
    /// </summary>
    public interface IImageHelper
    {
        Task<ImageUploadedDto> UploadUserImg(string userName, IFormFile pictureFile, string folderName = "userImages");
        ImageDeletedDto DeleteImg(string pictureName);
    }
}
