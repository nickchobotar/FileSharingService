using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace FileSharingService.Controllers
{
    public class DownloadController : Controller
    {
        public FileResult Download(string fileID)
        {
            var path = Path.Combine(Server.MapPath("~/App_Data/uploads"), fileID);
            byte[] fileBytes = System.IO.File.ReadAllBytes(path);
            string fileName = fileID;
            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);

        }
    }
}
