using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Profissonal.PPL.ModelVM;
using Profissonal.PPL.Service.Abstract;
using Profissonal.PPL.Service.Implement;

namespace Professonal.pl.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private readonly IvedioService ivedioService;
        private readonly IWebHostEnvironment webHostEnvironment;

        public ILeakRequestService LeakRequestService { get; }
        public ICommentSrevice CommentSrevice { get; }
        public IMediaItemservice MediaItemservice { get; }
        private readonly string _uploadsPath;


        public AdminController(
            ILeakRequestService leakRequestService,
            ICommentSrevice commentSrevice,
            IMediaItemservice mediaItemservice,IvedioService ivedioService ,IWebHostEnvironment webHostEnvironment )
        {
            LeakRequestService = leakRequestService;
            CommentSrevice = commentSrevice;
            MediaItemservice = mediaItemservice;
            this.ivedioService = ivedioService;
            this.webHostEnvironment = webHostEnvironment;
            _uploadsPath = Path.Combine(webHostEnvironment.WebRootPath, "uploads");

        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var requests = await LeakRequestService.GetAllAsync();
            return View(requests);
        }
        [HttpPost]
        public async Task<IActionResult> DeleteLeak(int id)
        {
            var res = await LeakRequestService.GetByIdAsync(id);
            await LeakRequestService.DeleteAsync(res.Result);

            TempData["Success"] = "تمت حذف الطلب ✅";

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var request = await LeakRequestService.GetByIdAsync(id);
            if (request.Secsses==false)
                return NotFound();
            return View(request);
        }
        [HttpPost]
        public async Task<IActionResult> updateStatus(int id)
        {
            await LeakRequestService.UpdateStatusAsync(id);
            return RedirectToAction("Index");

        }

        [HttpGet]
        public async Task<IActionResult> Comments()
        {
            var res = await CommentSrevice.GetAllAsync();
            return View(res);
        }

        [HttpGet]
        public async Task< IActionResult> AddComment() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddComment(CommentVM model)
        {
            if (!ModelState.IsValid)
                return View(model);

            await CommentSrevice.AddAsync(model);
            TempData["Success"] = "تمت إضافة التعليق ✅";
            return RedirectToAction("Comments");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> addcommentTouser(int id)
        {
            await CommentSrevice.SetVisibilityAsync(id, true);
            TempData["Success"] = "تمت إضافة التعليق للعملاء ✅";
            return RedirectToAction("Comments");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> hidecommentTouser(int id)
        {
            await CommentSrevice.SetVisibilityAsync(id, false);
            TempData["Success"] = "تم إخفاء التعليق ✅";
            return RedirectToAction("Comments");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteComment(int id)
        {
            var res = await CommentSrevice.GetAllAsync();
            var comment = res.Result.FirstOrDefault(c => c.ID == id);
            if (comment != null)
            {
                await CommentSrevice.DeleteAsync(comment);
                TempData["Success"] = "تم حذف التعليق ✅";
            }
            return RedirectToAction("Comments");
        }
        [HttpGet]
        public async Task<IActionResult> Vedios()
        {
            var res = await ivedioService.GetAllAsync();
            return View(res);
        }

        [HttpGet]
        public IActionResult AddVedio()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddVedio(VedioVM model)
        {
            ModelState.Remove("ThumbnailUrl");

            if (ModelState.IsValid)
            {
                // استخراج YouTube Video ID إذا لم يتم تعبئته تلقائياً
                if (string.IsNullOrEmpty(model.YoutubeVideoId))
                {
                    model.YoutubeVideoId = ExtractYouTubeVideoId(model.YoutubeUrl);
                }

                await ivedioService.AddAsync(model);

                TempData["Success"] = "تمت إضافة الفيديو ✅";

                return RedirectToAction("Vedios");
            }

            return View(model);
        }

        private string ExtractYouTubeVideoId(string url)
        {
            // نفس المنطق الموجود في JavaScript
            if (string.IsNullOrEmpty(url)) return null;

            var patterns = new[]
            {
        @"(?:youtube\.com\/watch\?v=|youtu\.be\/|youtube\.com\/embed\/)([^&\n?#]+)",
        @"youtube\.com\/watch\?.*v=([^&\n?#]+)",
        @"youtu\.be\/([^&\n?#]+)"
    };

            foreach (var pattern in patterns)
            {
                var match = System.Text.RegularExpressions.Regex.Match(url, pattern);
                if (match.Success)
                {
                    return match.Groups[1].Value;
                }
            }

            return null;
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteVedio(int id)
        {
            await ivedioService.DeleteAsync(id);
            TempData["Success"] = "تم حذف الفيديو ✅";
            return RedirectToAction("Vedios");
        }
        public async Task<IActionResult> Images()
        {
           var res= await MediaItemservice.GetAllAsync();
            return View(res.Result);

        }
        public async Task< IActionResult> AddImage()
        {
            return View(new MediaItemVM());
        }

        // POST: إضافة وسيط جديد
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddImage(MediaItemVM model)
        {
            try
            {
                ModelState.Remove("TitleEn");

                // التحقق من صحة البيانات
                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                // التأكد من وجود مجلد uploads
                if (!Directory.Exists(_uploadsPath))
                {
                    Directory.CreateDirectory(_uploadsPath);
                }

                // استدعاء الدالة بتاعتك
                var result = await MediaItemservice.AddAsync(model, _uploadsPath);

                if (result.Secsses==true)
                {
                    TempData["Success"] = "تم إضافة الوسيط بنجاح";
                    return RedirectToAction("Images");
                }
                else
                {
                    ModelState.AddModelError("", result.MessageError);
                    return View(model);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"حدث خطأ: {ex.Message}");
                return View(model);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                // استدعاء دالة الحذف مع تمرير المسار
                var result = await MediaItemservice.DeleteAsync(id, _uploadsPath);

                if (result.Secsses==true)
                {
                    TempData["Success"] = "تم حذف العنصر بنجاح";
                    return RedirectToAction(nameof(Images));
                }
                else
                {
                    TempData["Error"] = result.MessageError;
                    return RedirectToAction(nameof(Images));
                }
            }
            catch (Exception ex)
            {
                TempData["Error"] = $"حدث خطأ: {ex.Message}";
                return RedirectToAction(nameof(Images));
            }
        }


    }
}