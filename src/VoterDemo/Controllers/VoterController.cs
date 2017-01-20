using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VoterDemo.Models;
using VoterDemo.DAL;
using VoterDemo.Helpers;
namespace VoterDemo.Controllers
{
    public class VoterController : Controller
    {
        // GET: Voter
        public ActionResult Index()
        {
            VoterDAL DAL = new VoterDAL();
            List<voterModel> voters = new List<voterModel>();
            voters = DAL.GetallVoter();
            return View(voters);
        }
        public ActionResult AddVoter()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddVoter(voterModel voter)
        {
            if (ModelState.IsValid)
            {
                VoterDAL DAL = new VoterDAL();
                List<voterModel> voters = new List<voterModel>();
                voterModel vt1 = new voterModel();
                vt1 = DAL.GetallVoterWithDeleted().Find(x => x.voter_id == voter.voter_id);

                List<voterModel> VoterCheck = DAL.GetvoterbyID(voter.voter_id);
                if (vt1 == null)
                {
                    DAL.Addvoter(voter);
                    return RedirectToAction("Index", "Voter");
                }
                else
                {
                    ModelState.AddModelError("", "VoterID Is Already Exists ");
                    return View(voter);

                }
            }
            return View(voter);
        }

        public ActionResult Edit(string id)
        {
            VoterDAL DAL = new VoterDAL();
            List<voterModel> voters = new List<voterModel>();
            voters = DAL.GetvoterbyID(id);
            voterModel v = new voterModel();
            foreach (var k in voters)
            {

                v.ID = k.ID;
                v.voter_id = k.voter_id;
                v.lastname = k.lastname;
                v.firstname = k.firstname;
                v.middlename = k.middlename;
                v.WardId = k.WardId;
                v.AreaId = k.AreaId;
            }
            return View(v);
        }
        [HttpPost]
        public ActionResult Edit(voterModel v)
        {
            VoterDAL DAL = new VoterDAL();
            List<voterModel> Voters = new List<voterModel>();
            DAL.UpdateVoter(v);
            return RedirectToAction("Index", "Voter");
        }
        public void Excel()
        {
            VoterDAL DAL = new VoterDAL();
            var model = DAL.getvoters();
            Export export = new Export();
            export.ToExcel(Response, model);
        }

        public ActionResult Details(string id)
        {
            VoterDAL DAL = new VoterDAL();
            List<voterModel> voters = new List<voterModel>();
            voters = DAL.GetvoterbyID(id);
            voterModel v = new voterModel();
            foreach (var k in voters)
            {

                v.ID = k.ID;
                v.voter_id = k.voter_id;
                v.lastname = k.lastname;
                v.firstname = k.firstname;
                v.middlename = k.middlename;
                v.WardId = k.WardId;
                v.AreaId = k.AreaId;
                v.WardName = k.WardName;
                v.AreaName = k.AreaName;
            }
            return View(v);
        }
        public ActionResult Delete(string id)
        {
            VoterDAL DAL = new VoterDAL();
            List<voterModel> voters = new List<voterModel>();
            voters = DAL.GetvoterbyID(id);
            voterModel v = new voterModel();
            foreach (var k in voters)
            {

                v.ID = k.ID;
                v.voter_id = k.voter_id;
                v.lastname = k.lastname;
                v.firstname = k.firstname;
                v.middlename = k.middlename;
                v.WardId = k.WardId;
                v.AreaId = k.AreaId;
            }
            DAL.DeleteVoter(v);
            return RedirectToAction("Index", "Voter");
        }
    }
}