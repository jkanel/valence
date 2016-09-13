using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Valence.Web;
using Valence.Web.ViewModels;
using Valence.Services;
using Valence.Interactors;
using Valence.Repositories;
using Valence.Models;
using Valence.Entities;

namespace Valence.Web.Controllers
{
    public class OrganizationController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        #region Repositories

        private OrganizationRepository _OrganizationRepository;
        private OrganizationMemberRepository _OrganizationMemberRepository;

        public OrganizationRepository OrganizationRepository { get
            {
                if(this._OrganizationRepository == null)
                {
                    this._OrganizationRepository = new OrganizationRepository(db);
                }
                return this._OrganizationRepository;
            }
        }

        public OrganizationMemberRepository OrganizationMemberRepository
        {
            get
            {
                if (this._OrganizationMemberRepository == null)
                {
                    this._OrganizationMemberRepository = new OrganizationMemberRepository(db);
                }
                return this._OrganizationMemberRepository;
            }
        }

        #endregion

        // GET: Organization
        public ActionResult Index()
        {

            OrganizationInteractor interactor = new OrganizationInteractor(db);
            OrganizationService service = new OrganizationService();
            service.OrganizationInteractor = interactor;
         

            return View();
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
