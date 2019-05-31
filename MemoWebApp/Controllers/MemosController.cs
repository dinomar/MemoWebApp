using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using MemoWebAppDAL.Repos;
using MemoWebAppDAL.Models;
using MemoWebApp.Models;
using System.Threading.Tasks;

namespace MemoWebApp.Controllers
{
    [Authorize]
    public class MemosController : Controller
    {
        //private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;

        public MemosController()
        {

        }

        public MemosController(ApplicationUserManager userManager)
        {
            UserManager = userManager;
            //SignInManager = signInManager;
        }

        //public ApplicationSignInManager SignInManager
        //{
        //    get
        //    {
        //        return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
        //    }
        //    private set
        //    {
        //        _signInManager = value;
        //    }
        //}

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        // GET: Memos
        public async Task<ActionResult> Index()
        {
            var userId = User.Identity.GetUserId();
            var userName = User.Identity.GetUserName();

            List<Memo> memos = null;
            using (MemosRepo repo = new MemosRepo())
            {
                var results = await repo.GetAllByUserIdAsync(userId);
                memos = results.ToList();
            }

            ViewBag.UserName = userName;
            return View(memos);
        }

        // GET: Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(MemoCreateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var userId = User.Identity.GetUserId();

            using (MemosRepo repo = new MemosRepo())
            {
                await repo.AddAsync(new Memo
                {
                    UserId = userId,
                    Title = model.Title,
                    Text = model.Title,
                    Deleted = false
                });
            }

            return RedirectToAction("Index");
        }

        // GET: Edit
        public async Task<ActionResult> Edit(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return RedirectToAction("Index");
            }

            var userId = User.Identity.GetUserId();

            int memoId;
            if (!int.TryParse(id, out memoId))
            {
                return RedirectToAction("Index");
            }

            MemoEditViewModel memo = new MemoEditViewModel();
            using (MemosRepo repo = new MemosRepo())
            {
                Memo result = await repo.GetOneAsync(memoId);

                if (result.UserId != userId)
                {
                    return RedirectToAction("Index");
                }

                memo.Id = result.Id;
                memo.Text = result.Text;
                memo.Title = result.Title;
            }

            return View(memo);
        }

        // POST: Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(MemoEditViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var userId = User.Identity.GetUserId();

            using (MemosRepo repo = new MemosRepo())
            {
                Memo result = await repo.GetOneAsync(model.Id);

                if (result.UserId != userId)
                {
                    return RedirectToAction("Index");
                }

                result.Title = model.Title;
                result.Text = model.Text;

                await repo.SaveAsync(result);
            }

            return RedirectToAction("Index");
        }

        // POST: Delete
        public async Task<ActionResult> Delete(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return RedirectToAction("Index");
            }

            var userId = User.Identity.GetUserId();

            int memoId;
            if (!int.TryParse(id, out memoId))
            {
                return RedirectToAction("Index");
            }

            using (MemosRepo repo = new MemosRepo())
            {
                Memo result = await repo.GetOneAsync(memoId);
                result.Deleted = true;
                if (result.UserId == userId)
                {
                    await repo.SaveAsync(result);
                }
            }

            return RedirectToAction("Index");
        }
    }
}