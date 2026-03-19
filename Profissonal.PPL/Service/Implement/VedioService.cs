using Professonal.DAL.Migrations;
using Professonal.DAL.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Profissonal.PPL.Service.Implement
{
    public class VedioService : IvedioService
    {
        private readonly IUnitOfWork unitOfWork;

        public VedioService( IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<Response<bool>> AddAsync(VedioVM vedio)
        {
            try
            {
                if (vedio == null)
                {
                    return new Response<bool>(false, false, "Error");
                }
                var leak = new Vedio
                {
                    Id = vedio.Id,
                    YoutubeUrl = ConvertToEmbed(vedio.YoutubeUrl),
                    Description = vedio.Dsecription,
                   


                };
                await unitOfWork.vedioRepo.AddAsync(leak);
                await unitOfWork.CompleteAsync();
                return new Response<bool>(true, true, null);

            }
            catch
            {
                return new Response<bool>(false, false, "Error");

            }
        }

        public async Task<Response<bool>> DeleteAsync(int id)
        {
            try
            {
                var vedio=await unitOfWork.vedioRepo.GetByIdAsync(id);
                if (vedio == null)
                {
                    return new Response<bool>(false, false, "Error");
                }
              
                await unitOfWork.vedioRepo.DeleteAsync(vedio);
                await unitOfWork.CompleteAsync();
                return new Response<bool>(true, true, null);

            }
            catch
            {
                return new Response<bool>(false, false, "Error");

            }

        }

        public async Task<Response<IEnumerable<VedioVM>>> GetAllAsync()
        {
            try
            {
                var res = await unitOfWork.vedioRepo.GetAllAsync();

                if (res == null)
                    return new Response<IEnumerable<VedioVM>>(null, false, "Error");

                var result = res.Select(v => new VedioVM
                {
                    Id = v.Id,
                    Dsecription = v.Description,
                    YoutubeUrl = v.YoutubeUrl,
                }).ToList();

                return new Response<IEnumerable<VedioVM>>(result, true, null);
            }
            catch
            {
                return new Response<IEnumerable<VedioVM>>(null, false, "Error");
            }
        }
        private string ConvertToEmbed(string url)
        {
            var videoId = "";

            if (url.Contains("watch?v="))
                videoId = url.Split("watch?v=")[1].Split("&")[0];
            else if (url.Contains("youtu.be/"))
                videoId = url.Split("youtu.be/")[1].Split("?")[0];

            return $"https://www.youtube.com/embed/{videoId}";
        }
    }
}
