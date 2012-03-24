using System.Collections.Generic;
using System.Linq;

namespace Ideastrike.Models.Repositories
{
    public class ImageRepository : IImageRepository
    {
        private readonly IdeastrikeContext _dataContext;

        public ImageRepository(IdeastrikeContext dataContext)
        {
            _dataContext = dataContext;
        }

        public IEnumerable<Image> GetAll()
        {
            return _dataContext.Images.ToList();
        }

        public Image Get(int id)
        {
            return _dataContext.Images.FirstOrDefault(i => i.Id == id);
        }

        public void Add(Image image)
        {
            _dataContext.Images.Add(image);
            _dataContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var image = Get(id);
            if(image == null)
            {
                return;
            }

            _dataContext.Images.Remove(image);
            _dataContext.SaveChanges();
        }
    }
}