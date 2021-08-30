using System.IO;
using System;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Http;

namespace Infrastructure.Service
{
    public class PhotoService : IPhotoService
    {
         public async Task<Photo> SaveToDiskAsync(IFormFile file)
          {
               var photo = new Photo();
               if (file.Length > 0)
               {
                    var fileName = Guid.NewGuid() + Path.GetExtension(file.FileName);
                    var filePath = Path.Combine("Content/images/znamenitosti", fileName);
                    await using var fileStream = new FileStream(filePath, FileMode.Create);
                    await file.CopyToAsync(fileStream);

                    photo.FileName = fileName;
                    photo.PictureUrl = "images/znamenitosti/" + fileName;

                    return photo;
               }

               return null;
          }

          public void DeleteFromDisk(Photo photo)
          {
               if (File.Exists(Path.Combine("Content/images/znamenitosti", photo.FileName)))
               {
                    File.Delete("Content/images/znamenitosti/" + photo.FileName);
               }
          }

        public void DeleteCarouselPhoto(Carousel photo)
        {
            if (File.Exists(Path.Combine("Content/images/znamenitosti", photo.FileName)))
               {
                    File.Delete("Content/images/znamenitosti/" + photo.FileName);
               }
        }

        public async Task<Carousel> SaveCarouselToDiskAsync(IFormFile file)
        {
            var photo = new Carousel();
               if (file.Length > 0)
               {
                    var fileName = Guid.NewGuid() + Path.GetExtension(file.FileName);
                    var filePath = Path.Combine("Content/images/znamenitosti", fileName);
                    await using var fileStream = new FileStream(filePath, FileMode.Create);
                    await file.CopyToAsync(fileStream);

                    photo.FileName = fileName;
                    photo.PictureUrl = "images/znamenitosti/" + fileName;

                    return photo;
               }

               return null;
        }
    }
}