using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

using Valence.Web;
using Valence.Web.ViewModels;
using Valence.Entities;
using Valence.Commands;

namespace Valence.Web.Controllers
{
    public class OrganizationController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Organization
        public ActionResult Index()
        {
            int ContextMemberId = User.Identity.GetUserId<int>();
            
            OrganizationCommand ocmd = new OrganizationCommand(db);
            OrganizationViewModelList ovmlist = new OrganizationViewModelList(ocmd.GetMemberOrganizations(ContextMemberId));

            ApplicationCommand acmd = new ApplicationCommand(db);
            ovmlist.ApplicationUserInfo.SetApplicationInfo(acmd.GetApplicationActions(ContextMemberId), "Jeff");
            
            return View(ovmlist);
        }

        // GET: Organization/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            OrganizationViewModel organizationViewModel = db.OrganizationViewModels.Find(id);

            if (organizationViewModel == null)
            {
                return HttpNotFound();
            }
            return View(organizationViewModel);
        }

        // GET: Organization/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Organization/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OrganizationId,OrganizationName,Description,WebPageUrl,IsServicesVendor,IsProductVendor,IsNonProfit,IsEducational")] OrganizationViewModel organizationViewModel)
        {
            if (ModelState.IsValid)
            {
                db.OrganizationViewModels.Add(organizationViewModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(organizationViewModel);
        }

        // GET: Organization/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrganizationViewModel organizationViewModel = db.OrganizationViewModels.Find(id);
            if (organizationViewModel == null)
            {
                return HttpNotFound();
            }
            return View(organizationViewModel);
        }

        // POST: Organization/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OrganizationId,OrganizationName,Description,WebPageUrl,IsServicesVendor,IsProductVendor,IsNonProfit,IsEducational")] OrganizationViewModel organizationViewModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(organizationViewModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(organizationViewModel);
        }

        // GET: Organization/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrganizationViewModel organizationViewModel = db.OrganizationViewModels.Find(id);
            if (organizationViewModel == null)
            {
                return HttpNotFound();
            }
            return View(organizationViewModel);
        }

        // POST: Organization/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OrganizationViewModel organizationViewModel = db.OrganizationViewModels.Find(id);
            db.OrganizationViewModels.Remove(organizationViewModel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
