using FileSharingService.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FileSharingService.Controllers
{
    public class UploadController : Controller
    {
        // GET: Upload

        [HttpPost]
        public ActionResult Upload(HttpPostedFileBase file)
        {
            string fileName = Helpers.Helper.RandomString(5);

            if (file.ContentLength > 0)
            {               
                var path = Path.Combine(Server.MapPath("~/App_Data/uploads"), fileName);
                file.SaveAs(path);
            }
            return RedirectToAction("UploadComplete", new {fileID = fileName});
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileID"></param>
        /// <returns></returns>
        public ActionResult UploadComplete(string fileID)
        {
            UploadCompleteViewModel ViewModel = new UploadCompleteViewModel();
            ViewModel.fileID = fileID;

            //string link = HtmlHelper.GenerateLink(
            //    this.ControllerContext.RequestContext, 
            //    System.Web.Routing.RouteTable.Routes, 
            //    "Download", null, "Download", "Download", null, null);


            return View(ViewModel);
        }
            

    }
}