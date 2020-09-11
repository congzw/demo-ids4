using System.Net.Http;
using System.Threading.Tasks;

namespace NbSites.Web.Services
{
    public interface IImageGalleryHttpClient
    {
        Task<HttpClient> GetClient();
    }
}
