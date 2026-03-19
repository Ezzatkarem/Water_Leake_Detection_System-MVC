

namespace Profissonal.PPL.Service.Implement
{
    public class MediaItemService : IMediaItemservice
    {
        private readonly IUnitOfWork unitOfWork;

        public MediaItemService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
            public async  Task<Response<bool>> AddAsync(MediaItemVM model,string uploadspath)
            {
                try
                {
                    if(model==null||model.ImageFile==null)
                    {
                        return new Response<bool>(false, false, "اختار صوره");
                    }
                    var filename=Guid.NewGuid()+Path.GetExtension(model.ImageFile.FileName);
                    var fullpath=Path.Combine(uploadspath,filename);
                    using (var stream=new FileStream(fullpath,FileMode.Create))
                        await model.ImageFile.CopyToAsync(stream);

                    var res = new MediaItem
                    {
                        Id = model.Id,
                        Title = model.Title,
                        FilePath = "/uploads/" + filename,
                        CreatedAt = DateTime.UtcNow,
                    };
                    await unitOfWork.mediaItemRepo.AddAsync(res);
                    await unitOfWork.CompleteAsync();
                    return new Response<bool>(true, true, null);


                }
            catch (Exception ex)
            {
                return new Response<bool>(false, false, "خطأ في رفع الصورة");

            }
        }

            public async Task<Response<bool>> DeleteAsync(int id,string uploadspath)
            {
                try
                {
                    var model=await unitOfWork.mediaItemRepo.GetByIdAsync(id);
                    if (model == null )
                    {
                        return new Response<bool>(false, false,"الصورة غير موجودة");
                    }
                    var fullpath = Path.Combine(uploadspath, Path.GetFileName(model.FilePath));
                    if (File.Exists(fullpath))
                        File.Delete(fullpath);
              

               
                    await unitOfWork.mediaItemRepo.DeleteAsync(model);
                    await unitOfWork.CompleteAsync();
                    return new Response<bool>(true, true, null);


                }
                catch (Exception ex)
                {
                    return new Response<bool>(false, false, "حدث خطأ أثناء الحذف");

                }
            }

    
        public async  Task<Response<IEnumerable<MediaItemVM>>> GetAllAsync()
        {
            try
            {
                var res=await unitOfWork.mediaItemRepo.GetAllAsync();
                if(res == null)
                {
                    return new Response<IEnumerable<MediaItemVM>>(null, false, "لا توجد بيانات");

                }
                var ress=res.Select(p=>new MediaItemVM
                {
                    Id = p.Id,
                    Title = p.Title,
                    FilePath=p.FilePath,
                    CreatedAt = p.CreatedAt,

                }).ToList();

                return new Response<IEnumerable<MediaItemVM>>(ress, true, null);

            }
            catch (Exception ex)
            {
                return new Response<IEnumerable<MediaItemVM>>(null, false, "حدث خطأ أثناء تحميل البيانات");
            }
        }

    }
}
