


namespace Profissonal.PPL.Service.Implement
{
    public class LeakRequestService : ILeakRequestService
    {
        private readonly IUnitOfWork unitOfWork;

        public LeakRequestService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<int> AddAsync(LeakRequestVM model)
        {
           
                if (model == null)
                {
                return 0;
                }
                var New = new LaekRequest
                {
                    Id=model.Id,
                    ClientName=model.ClientName,
                    ProplemType=model.ProplemType,
                    Phone=model.Phone,
                    Address=model.Address,
                    Description=model.Description,
                    Status=model.Status,
                    CreatedAt=DateTime.UtcNow,
                };
                await unitOfWork.leakRequestRepo.AddAsync(New);
                await unitOfWork.CompleteAsync();
                return New.Id;

          
        }

        public Task<Response<bool>> AddRangeAsync(IEnumerable<LeakRequestVM> model)
        {
            throw new NotImplementedException();
        }

        public async Task<Response<bool>> DeleteAsync(LeakRequestVM model)
        {
            try
            {
                // Fetch the tracked entity directly — do NOT create a new object,
                // as that causes EF tracking conflicts when GetByIdAsync was already calxxxled.
                var entity = await unitOfWork.leakRequestRepo.GetByIdAsync(model.Id);
                if (entity == null)
                    return new Response<bool>(false, false, "Not Found");

                await unitOfWork.leakRequestRepo.DeleteAsync(entity);
                await unitOfWork.CompleteAsync();
                return new Response<bool>(true, true, null);
            }
            catch (Exception ex)
            {
                return new Response<bool>(false, false, ex.Message);
            }
        }

        public Task<Response<bool>> DeleteRangeAsync(IEnumerable<LeakRequestVM> values)
        {
            throw new NotImplementedException();
        }

        public Task<Response<IEnumerable<LeakRequestVM>>> FindAsync(Expression<Func<LeakRequestVM, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public async Task<Response<IEnumerable<LeakRequestVM>>> GetAllAsync()
        {
            try
            {
                var result=await unitOfWork.leakRequestRepo.GetAllAsync ();
                if (result == null)
                {
                    return new Response<IEnumerable<LeakRequestVM>> (null,false,"Not Found");
                }
                var res=result.Select(leak=>  new LeakRequestVM
                {
                    Id=leak.Id,
                    Phone=leak.Phone,
                    Address=leak.Address,
                    ClientName=leak.ClientName,
                    Description=leak.Description,
                    ProplemType=leak.ProplemType,
                    Status=leak.Status,
                    CreatedAt=leak.CreatedAt,
                }).ToList();
                return new Response<IEnumerable<LeakRequestVM>>(res, true, null);


            }
            catch (Exception ex)
            {
                return new Response<IEnumerable<LeakRequestVM>>(null, false, "Not Found");

            }
        }

        public async Task<Response<LeakRequestVM>> GetByIdAsync(int id)
        {
            try
            {
                var leak =await unitOfWork.leakRequestRepo.GetByIdAsync(id);
                if(leak == null)
                {
                    return new Response<LeakRequestVM>(null, false, null);
                }
                var NewLeak = new LeakRequestVM
                {
                    Id = leak.Id,
                    ClientName = leak.ClientName,
                    ClientNote=leak.ClientNote,
                    ProplemType = leak.ProplemType,
                    Phone = leak.Phone,
                    Address = leak.Address,
                    Description =leak.Description,
                    Status = leak.Status,
                    CreatedAt = leak.CreatedAt
                };
                return new Response<LeakRequestVM>(NewLeak, true, null);
            }
            catch (Exception ex)
            {
                return new Response<LeakRequestVM>(null, false, null);

            }
        }

        public async Task<Response<List<LeakRequestVM>>> GetLeakByPhoneAsync(string phone)
        {
            try
            {
                var leaks = await unitOfWork.leakRequestRepo.GetByPhoneNumber(phone);

                if (leaks == null || !leaks.Any())
                    return new Response<List<LeakRequestVM>>(null, false, "مفيش طلبات بالرقم ده");

                var result = leaks.Select(leak => new LeakRequestVM
                {
                    Id = leak.Id,
                    ClientName = leak.ClientName,
                    ProplemType = leak.ProplemType,
                    Phone = leak.Phone,
                    Address = leak.Address,
                    Description = leak.Description,
                    Status = leak.Status,
                    CreatedAt = leak.CreatedAt
                }).ToList();

                return new Response<List<LeakRequestVM>>(result, true, null);
            }
            catch (Exception ex)
            {
                return new Response<List<LeakRequestVM>>(null, false, ex.Message);
            }
        }

        public Task<Response<bool>> UpdateAsync(LeakRequestVM model)
        {
            throw new NotImplementedException();
        }
        // LeakRequestService.cs
        public async Task AddNoteAsync(int id, string note)
        {
            try
            {
                var leak = await unitOfWork.leakRequestRepo.GetByIdAsync(id);
                if (leak == null) return;

                leak.ClientNote = note;
                await unitOfWork.leakRequestRepo.UpdateAsync(leak);
                await unitOfWork.CompleteAsync();
            }
            catch (Exception ex)
            {
                // log error
            }
        }

        public async Task<Response<bool>> UpdateStatusAsync(int id)
        {
            try
            {

            var leak = await unitOfWork.leakRequestRepo.GetByIdAsync(id);
                if(leak==null)
                {
                    return new Response<bool>(false, false, "Not Found");
                }
                if (leak.Status == "Pending") leak.Status = "InProgress";
                else leak.Status = "Completed";
                await unitOfWork.leakRequestRepo.UpdateAsync(leak);
                await unitOfWork.CompleteAsync();
                return new Response<bool>(true, true, null);


            }
            catch (Exception ex)
            {
                return new Response<bool>(false, false, "Not Found");

            }

        }

        public async Task<Response<List<LaekRequest>>> GetAllcompleteAsync(Expression<Func<LaekRequest, bool>> predicate)
        {
            try
            {
                var result = await unitOfWork.leakRequestRepo.GetAllcAsync(p=>p.Status=="Completed");
                if (result == null)
                {
                    return new Response<List<LaekRequest>>(null, false, "Not Found");
                }
                var res = result.Select(leak => new LaekRequest
                {
                    Id = leak.Id,
                    Phone = leak.Phone,
                    Address = leak.Address,
                    ClientName = leak.ClientName,
                    Description = leak.Description,
                    ProplemType = leak.ProplemType,
                    Status = leak.Status,
                    CreatedAt = leak.CreatedAt,
                }).ToList();
                return new Response<List<LaekRequest>>(res, true, null);


            }
            catch (Exception ex)
            {
                return new Response<List<LaekRequest>>(null, false, "Not Found");

            }
        }

        public async Task<Response<List<LaekRequest>>> GetAllPendingAsync(Expression<Func<LaekRequest, bool>> predicate)
        {
            try
            {
                var result = await unitOfWork.leakRequestRepo.GetAllcAsync(p => p.Status == "Pending");
                if (result == null)
                {
                    return new Response<List<LaekRequest>>(null, false, "Not Found");
                }
                var res = result.Select(leak => new LaekRequest
                {
                    Id = leak.Id,
                    Phone = leak.Phone,
                    Address = leak.Address,
                    ClientName = leak.ClientName,
                    Description = leak.Description,
                    ProplemType = leak.ProplemType,
                    Status = leak.Status,
                    CreatedAt = leak.CreatedAt,
                }).ToList();
                return new Response<List<LaekRequest>>(res, true, null);


            }
            catch (Exception ex)
            {
                return new Response<List<LaekRequest>>(null, false, "Not Found");

            }
        }

        public async Task<Response<List<LaekRequest>>> GetAllinprogressAsync(Expression<Func<LaekRequest, bool>> predicate)
        {
            try
            {
                var result = await unitOfWork.leakRequestRepo.GetAllcAsync(p => p.Status == "InProgress");
                if (result == null)
                {
                    return new Response<List<LaekRequest>>(null, false, "Not Found");
                }
                var res = result.Select(leak => new LaekRequest
                {
                    Id = leak.Id,
                    Phone = leak.Phone,
                    Address = leak.Address,
                    ClientName = leak.ClientName,
                    Description = leak.Description,
                    ProplemType = leak.ProplemType,
                    Status = leak.Status,
                    CreatedAt = leak.CreatedAt,
                }).ToList();
                return new Response<List<LaekRequest>>(res, true, null);


            }
            catch (Exception ex)
            {
                return new Response<List<LaekRequest>>(null, false, "Not Found");

            }
        }
    }
}
