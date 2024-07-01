using WebAPI.Controllers.Dtos;
using WebAPI.Helpers.Abstract;

namespace WebAPI.Helpers.Concrete
{
    public class ImageHelper : IImageHelper
    {
        private readonly IWebHostEnvironment _env;

        public ImageHelper(IWebHostEnvironment env)
        {
            _env = env;
        }

        private readonly string wwwroot = "wwwroot";
        private readonly string imgFolder = "images";
        public ImageDeletedDto DeleteImg(string pictureName)
        {
            var fileToDelete = Path.Combine($"{wwwroot}/{imgFolder}/", pictureName);
            if (System.IO.File.Exists(fileToDelete))
            {
                var fileInfo = new FileInfo(fileToDelete);//FileInfon'nun çalışması için dosyanın bulunması lazım
                var imageDeletedDto = new ImageDeletedDto// o yüzden fileInfo'daki bilgileri burada yedekliyorum
                {
                    FullName = pictureName,
                    Extensions = fileInfo.Extension,
                    Path = fileInfo.FullName,
                    Size = fileInfo.Length
                };
                System.IO.File.Delete(fileToDelete);
                return imageDeletedDto;
            }
            else
            {
                return null;
            }
        }

        public async Task<ImageUploadedDto> UploadUserImg(string userName, IFormFile pictureFile, string folderName = "avatar")
        {
            if (!Directory.Exists($"{wwwroot}/{imgFolder}/{folderName}"))
            {
                Directory.CreateDirectory($"{wwwroot}/{imgFolder}/{folderName}");
            }
            // ~/img/user,Picture şeklinde kullanacağız
            //ahmetciftci
            string oldFileName = Path.GetFileNameWithoutExtension(pictureFile.FileName);
            //.png
            string fileExtensions = Path.GetExtension(pictureFile.FileName);
            DateTime dateTime = DateTime.Now;
            string newFileName = $"{userName}-{$"{dateTime.Millisecond}-{dateTime.Second}-{dateTime.Minute}-{dateTime.Hour}-{dateTime.Day}-{dateTime.Month}-{dateTime.Year}"}{fileExtensions}";
            var path = Path.Combine($"{wwwroot}/{imgFolder}/{folderName}", newFileName);
            await using (var stream = new FileStream(path, FileMode.Create))
            {
                await pictureFile.CopyToAsync(stream);
            }

            return new ImageUploadedDto
            {
                FullName = $"{folderName}/{newFileName}",
                FileName = newFileName,
                OldName = oldFileName,
                Extension = fileExtensions,
                FolderName = folderName,
                Path = path,
                Size = pictureFile.Length

            }; //ahmetciftci_564_5_38_26_10_22.png
        }
    }
}
