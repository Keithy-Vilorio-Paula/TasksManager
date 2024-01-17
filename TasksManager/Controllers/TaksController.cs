using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TasksManager;

namespace TasksManager.Controllers
{
    public class TaksController : Controller
    {
        private TaskManagerDBEntities db = new TaskManagerDBEntities();


        // GET: Taks
        public ActionResult Index()
        {
            return View(db.Tasks.ToList());
        }

        // GET: Taks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Task task = db.Tasks.Find(id);
            if (task == null)
            {
                return HttpNotFound();
            }
            return View(task);
        }

        // GET: Taks/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Taks/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Descripcion,FechaCreacion,Estado,Prioridad")] Task task)
        {
            if (ModelState.IsValid)
            {
                db.Tasks.Add(task);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(task);
        }

        // GET: Taks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Task task = db.Tasks.Find(id);
            if (task == null)
            {
                return HttpNotFound();
            }
            return View(task);
        }

        // POST: Taks/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Descripcion,FechaCreacion,Estado,Prioridad")] Task task)
        {
            if (ModelState.IsValid)
            {
                db.Entry(task).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(task);
        }

        // GET: Taks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Task task = db.Tasks.Find(id);
            if (task == null)
            {
                return HttpNotFound();
            }
            return View(task);
        }

        public ActionResult DownloadPDF(int id)
        {
            byte[] pdfBytes = ObtenerPDFDesdeReportingService(id);

            if (pdfBytes != null)
            {
                // Configurar el encabezado para forzar la descarga
                Response.AddHeader("Content-Disposition", "attachment; filename=Informe.pdf");

                return File(pdfBytes, "application/pdf");
            }
            else
            {
                // Manejar el caso en el que no se pueda obtener el PDF
                return HttpNotFound();
            }
        }

        private byte[] ObtenerPDFDesdeReportingService(int id)
        {
            // Lógica para llamar al servicio web de Reporting Services y obtener el PDF
            // Reemplaza este código con la lógica específica de tu aplicación y servicio

            using (var client = new WebClient())
            {
                // Ejemplo de URL del servicio web de Reporting Services
                string serviceUrl = "http://tu-servicio-reporting-service/ReportService.asmx/GetReportAsPdf";

                // Reemplaza los parámetros según tus necesidades
                var parameters = new NameValueCollection();
                parameters["id"] = id.ToString();

                // Llama al servicio web y obtén el PDF como bytes
                byte[] pdfBytes = client.UploadValues(serviceUrl, parameters);

                return pdfBytes;
            }
        }
    


        // POST: Taks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Task task = db.Tasks.Find(id);
            db.Tasks.Remove(task);
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
