

namespace Profissonal.PPL.Service.Implement
{

    public class CommentService : ICommentSrevice
    {
        private readonly IUnitOfWork unitOfWork;

        public CommentService(IUnitOfWork unitOfWork )
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<Response<bool>> AddAsync(CommentVM model)
        {
            try
            { 
                if(model==null)
                {
                    return new Response<bool> ( false, false,"Error" );
                }
                var leak = new Comment
                {
                    ID = model.ID,
                    Content = model.Content,
                    Author = model.Author,
                    CreatedAT = DateTime.Now,
                    isRead=false,
                    
                    
                };
                 await unitOfWork.commentRepo.AddAsync(leak);
                await unitOfWork.CompleteAsync();
                return new Response<bool>(true, true,null);

            }
            catch
            {
                return new Response<bool>(false, false, "Error");

            }
        }

        public async Task<Response<bool>> DeleteAsync(CommentVM model)
        {
            try
            {
                if (model == null)
                {
                    return new Response<bool>(false, false, "Error");
                }
                var leak = new Comment
                {
                    ID = model.ID,
                    Content = model.Content,
                    CreatedAT = DateTime.Now,
                    Author=model.Author

                };
                await unitOfWork.commentRepo.DeleteAsync(leak);
                await unitOfWork.CompleteAsync();
                return new Response<bool>(true, true, null);

            }
            catch
            {
                return new Response<bool>(false, false, "Error");

            }
        }

        public async Task<Response<IEnumerable<CommentVM>>> GetAllAsync()
        {
            try
            {

                var res = await unitOfWork.commentRepo.GetAllAsync();
               
                if(res == null)
                {
                    return new Response<IEnumerable< CommentVM >> (null, false, "Error");
                }
                    var leak=res.Select(leak => new CommentVM
                    {
                        ID = leak.ID,
                        Content = leak.Content,
                        CreatedAt = leak.CreatedAT,
                        Author=leak.Author,
                        isread = leak.isRead // ← ضيف السطر ده ✅



                    }).ToList();
                    return new Response<IEnumerable<CommentVM>>(leak, true, null);

            }
            catch
            {
                return new Response<IEnumerable<CommentVM>>(null, false, "Error");


            }
        }

        public async Task<Response<IEnumerable<CommentVM>>> GetAllByuserAsync()
        {
            try
            { 
            var res = await unitOfWork.commentRepo.GetAllByuserAsync();

            if (res == null)
            {
                return new Response<IEnumerable<CommentVM>>(null, false, "Error");
            }
            var leak = res.Select(leak => new CommentVM
            {
                ID = leak.ID,
                Content = leak.Content,
                CreatedAt = leak.CreatedAT,
                Author = leak.Author,
                isread = leak.isRead // ← ضيف السطر ده ✅



            }).ToList();
            return new Response<IEnumerable<CommentVM>>(leak, true, null);

        }
            catch
            {
                return new Response<IEnumerable<CommentVM>>(null, false, "Error");


            }
}

        // CommentService.cs
        public async Task SetVisibilityAsync(int id, bool isVisible)
        {
            try
            {
                var comment = await unitOfWork.commentRepo.GetByIdAsync(id);
                if (comment == null) return;

                comment.isRead = isVisible;
                await unitOfWork.commentRepo.UpdateAsync(comment);
                await unitOfWork.CompleteAsync();
            }
            catch (Exception ex)
            {
                // log error
            }
        }
    }
}
