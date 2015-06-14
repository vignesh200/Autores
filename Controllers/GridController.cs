using Autores.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace Autores.Controllers
{
    public class GridController : Controller
    {
        // GET: Grid
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Rejection()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RejectResult(RejectModel m)
        { 
            return View("Result",m);
        }


        public ActionResult RejectionData()
        {
            string[] RejectHead = new string[] { "Legal Description and/or Address Problem", " County Assessor's Number Problem",
                "Owner/Buyer needs to complete the following items on the Declaration Attachment:" };
            string[] RejectionList1 = new string[]{"Address does not coincide with the legal description."," Address and legal description are not located in City of Los Angeles. Therefore, this report is not required by the City of Los Angelas.",
            "Incorrect/incomplete legal description.","lncorrectlincomplete address.","Other"};
            string[] RejectionList2 = new string[]{"The County Assessor's map book, page, and parcel number does not match the address andlor legal description.",
            "Provide the County Assessor's map book, page, and parcel number as it appears on the County tax bill."," Provide a separate application and fee for each County Assessor's parcel number.","Other"};
            string[] RejectionList3 = new string[]{"Complete the water conservation device information","Complete the lights and locks information.","Complete the seismic gas shutoff valve information.",
            "Complete the security bar information.","Complete the smoke detector information.","Complete the impact glazinglapproved film information.","Complete the oak tree information.","Owner or buyer, as applicable, must sign andlor date the Declaration Attachment. This cannot be signed by the owner's or buyer's agent.",
            "Provide original wet signature on the Declaration. Photocopied and faxed signatures are not acceptable.","Provide proof for the seller signature. Please send a copy of Purchase Agreement (only two pages showing the seller name) or Grand Deed.","Provide Certificate of Occupancy.","Other"};
            string[][] RejectData = new string[][] {RejectionList1,RejectionList2,RejectionList3 };
            var jsonh = new JavaScriptSerializer().Serialize(RejectData);
            return Json(new {metadata=RejectHead, data = RejectData}, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Sample()
        {
            return View();
        }
    }
}