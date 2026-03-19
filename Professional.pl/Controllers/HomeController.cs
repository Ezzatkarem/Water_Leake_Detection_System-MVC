using Microsoft.AspNetCore.Mvc;
using Profissonal.PPL.ModelVM;
using Profissonal.PPL.Service.Abstract;
using Profissonal.PPL.Service.Implement;


namespace Profetional.pl.Controllers
{
    public class HomeController : Controller
    {
        public ILeakRequestService LeakRequestService { get; }
        public ICommentSrevice CommentSrevice { get; }
        public IvedioService VedioService { get; }
        public IMediaItemservice MediaItemservice { get; }

        public HomeController(ILeakRequestService leakRequestService, ICommentSrevice commentSrevice, IvedioService vedioService, IMediaItemservice mediaItemservice)
        {
            LeakRequestService = leakRequestService;
            CommentSrevice = commentSrevice;
            VedioService = vedioService;
            MediaItemservice = mediaItemservice;
        }
        [HttpGet]

        public async Task<IActionResult> Index()
        {
            var comments = await CommentSrevice.GetAllByuserAsync();
            ViewBag.Comments = comments.Result;
            var videos = await VedioService.GetAllAsync();
            ViewBag.Videos = videos.Result;
            var photos = await MediaItemservice.GetAllAsync();
            ViewBag.Photos = photos.Result;
            return View(new LeakRequestVM());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(LeakRequestVM model)
        {
            if (!ModelState.IsValid)
            {
                var comments = await CommentSrevice.GetAllAsync();
                ViewBag.Comments = comments.Result;
                var videos = await VedioService.GetAllAsync();
                ViewBag.Videos = videos.Result;
                var photos = await MediaItemservice.GetAllAsync();
                ViewBag.Photos = photos.Result;
                return View(model);
            }

            int id = await LeakRequestService.AddAsync(model);
            TempData["Success"] = "تم استلام طلبك بنجاح هنتواصل معاك قريباً";
            return RedirectToAction("Confirmation", new { id = id });
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddNote(int id, string note, string clientName)
        {
            var comment = new CommentVM
            {
                Content = note,
                ContentEn = note,
                Author = clientName,
            };
            await LeakRequestService.AddNoteAsync(id, note);
            await CommentSrevice.AddAsync(comment);
            TempData["Success"] = "تمت إضافة ملاحظتك ✅";
            return RedirectToAction("GetLeakbyId", new { id });
        }
        [HttpGet]
        public async Task <IActionResult> Confirmation(int id)                  
        {
            var leak = await LeakRequestService.GetByIdAsync(id);

            return View(leak);
        }
        public async Task<IActionResult> GetLeakbyId(int id)
        {
            var leak = await LeakRequestService.GetByIdAsync(id);
            return View(leak);
        }
        [HttpGet]
        
        public async Task<IActionResult> GetByPhone(string phone)
        {
            // لو مفيش phone اب عت null
            if (string.IsNullOrEmpty(phone))
                return View(null);

            var result = await LeakRequestService.GetLeakByPhoneAsync(phone);
            return View(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetComments()
        {

            var res = await CommentSrevice.GetAllByuserAsync();
            return View(res);
        }


        public async Task<IActionResult> ChangeLanquege(string culture,string returnUrl)
        {
            if(culture=="ar")
            culture= "en";
            else culture= "ar";
            Response.Cookies.Append("Lanquege", culture, new CookieOptions
            {
                Expires=DateTime.Now.AddYears(1)

            });
            return LocalRedirect(returnUrl??"/");
        }
        public IActionResult Privacy()
        {
            return View();
        }

      
    }
}
