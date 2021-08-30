using System.Collections.Generic;
using System.Linq;

namespace Core.Entities
{
    public class Znamenitost : BaseEntity
    {
        
        public string Naziv { get; set; }

        public string Opis { get; set; }

        public bool Aktivan { get; set; }

        public string Koordinate { get; set; }

 
        public Veomaznamenito Veomaznamenito { get; set; }
        public int VeomaznamenitoId { get; set; }

        public Nezaobilazno Nezaobilazno { get; set; }
        public string PictureUrl { get; set; }
        public int NezaobilaznoId { get; set; }
        public List<Photo> Photos => _photos.ToList();
 private readonly List<Photo> _photos = new List<Photo>();
        public void AddPhoto(string pictureUrl, string fileName, bool isMain = false)
        {
            var photo = new Photo
            {
                FileName = fileName,
                PictureUrl = pictureUrl
            };

            if (_photos.Count == 0) photo.IsMain = true;

            _photos.Add(photo);
        }

        public void RemovePhoto(int id)
        {
            var photo = _photos.Find(x => x.Id == id);
            _photos.Remove(photo);
        }

        public void SetMainPhoto(int id)
        {
            var currentMain = _photos.SingleOrDefault(item => item.IsMain);
            foreach (var item in _photos.Where(item => item.IsMain))
            {
                item.IsMain = false;
            }

            var photo = _photos.Find(x => x.Id == id);
            if (photo != null)
            {
                photo.IsMain = true;
                if (currentMain != null) currentMain.IsMain = false;
            }
        }
       
    }
}