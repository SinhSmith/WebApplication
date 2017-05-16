using System.Collections.Generic;
using System.Linq;
using WebApplication.Infractructure.Utilities;
using WebApplication.Model.Context;
using WebApplication.Repository.Interfaces;

namespace WebApplication.Repository.Implements
{
    public class ImageRepository : RepositoryBase<share_Images>, IImageRepository
    {
        public ImageRepository(OnlineStoreMVCEntities context) : base(context)
        {
        }
    }
}
