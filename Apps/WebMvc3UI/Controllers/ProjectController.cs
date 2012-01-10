using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Xml.Serialization;
using ProjectStatusReporting.MVCModel;
using StatusTracking_v1_0;
using WebMvc3UI.Models;
using BL = ProjectStatusReporting.BusinessLogic;
using MAP = ProjectStatusReporting.MVCModel.MappingToBL;

namespace ProjectStatusReporting.MVCModel
{
    public partial class ProjectController : Controller
    {
        //
        // GET: /Project/

        public ActionResult StatusReport(Guid id)
        {

            Project project = GetProject(id);
            return View("ProjectStatusReport", project);
        }

        public ActionResult Index()
        {
            var projectList = MAP.MapProject.MapBusinessToMvcList(MAP.MapSupport.ActiveCtx.Project);
            return View(projectList);
        }


        public ActionResult Details(Guid id)
        {
            Project project = GetProject(id);
            return View(project);
        }

        private Project GetProject(Guid id)
        {
            Project project =  MAP.MapProject.MapBusinessToMvc(MAP.MapSupport.ActiveCtx.Project.Single(item => item.Id == id));
            return project;
        }

        //
        // GET: /Project/Create

        public ActionResult Create()
        {
            return View(new Project()
                            {
                                ProjectId = Guid.NewGuid(),
                                ProjectInfo = new ProjectInfo(),
                                ProjectStatusInfo = new ProjectStatusInfo() {ProjectStatusInfoUpdated = DateTime.Now}
                            });
        } 

        //
        // POST: /Project/Create

        [HttpPost]
        public ActionResult Create(Project project, ProjectInfo projectInfo, ProjectStatusInfo projectStatusInfo)
        {
            try
            {
                project.ProjectInfo = projectInfo;
                project.ProjectStatusInfo = projectStatusInfo;
                BL.Project blProject = MAP.MapProject.MapMvcToBusiness(project);
                MAP.MapSupport.ActiveCtx.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        
        //
        // GET: /Project/Edit/5
 
        public ActionResult Edit(Guid id)
        {
            return View(GetProject(id));
        }

        //
        // POST: /Project/Edit/5

        [HttpPost]
        public ActionResult Edit(Guid id, string button, Project project)
        {
            try
            {
                if (button != null && button.StartsWith("Add"))
                    return handleEditButton(button, project);
                // TODO: Add update logic here
                BL.Project blProject = MAP.MapProject.MapMvcToBusiness(project);
                MAP.MapSupport.ActiveCtx.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        private ActionResult handleEditButton(string button, Project project)
        {
            if (button == "Add Action")
                project.ProjectStatusInfo.Actions.Add(new ProjectAction());
            else if (button == "Add Measurement")
                project.ProjectStatusInfo.Measurements.Add(new ProjectMeasurement());
            else if (button == "Add Interest Group")
                project.ProjectStatusInfo.InterestGroups.Add(new InterestGroup());
            else if (button == "Add Result")
                project.ProjectStatusInfo.Results.Add(new ProjectResult());
            else if (button == "Add Challenge")
                project.ProjectStatusInfo.ChallengesAndExceptions.Add(new ProjectChallenge());
            else if (button == "Add Counter Action")
                project.ProjectStatusInfo.CounterActions.Add(new CounterAction());
            else
                throw new NotImplementedException("Add button not implemented: " + button);
            return View("Edit", project);
        }

        //
        // GET: /Project/Delete/5
 
        public ActionResult Delete(Guid id)
        {
            return View();
        }

        //
        // POST: /Project/Delete/5

        [HttpPost]
        public ActionResult Delete(Guid id, Project project)
        {
            try
            {
                BL.Project blProject = MAP.MapSupport.ActiveCtx.Project.Single(item => item.Id == id);
                MAP.MapSupport.ActiveCtx.Project.Remove(blProject);
                if(blProject.ProjectInfo != null)
                    MAP.MapSupport.ActiveCtx.ProjectInfo.Remove(blProject.ProjectInfo);
                if(blProject.ProjectStatusInfo != null)
                {
                    MAP.MapSupport.ActiveCtx.ProjectStatusInfo.Remove(blProject.ProjectStatusInfo);
                    foreach (var ig in blProject.ProjectStatusInfo.InterestGroups)
                        MAP.MapSupport.ActiveCtx.InterestGroup.Remove(ig);
                    foreach (var measurement in blProject.ProjectStatusInfo.Measurements)
                        MAP.MapSupport.ActiveCtx.ProjectMeasurement.Remove(measurement);
                    foreach (var act in blProject.ProjectStatusInfo.Actions)
                        MAP.MapSupport.ActiveCtx.ProjectAction.Remove(act);
                    foreach (var ca in blProject.ProjectStatusInfo.CounterActions)
                        MAP.MapSupport.ActiveCtx.CounterAction.Remove(ca);
                    foreach (var cae in blProject.ProjectStatusInfo.ChallengesAndExceptions)
                        MAP.MapSupport.ActiveCtx.ProjectChallenge.Remove(cae);
                    foreach (var result in blProject.ProjectStatusInfo.Results)
                        MAP.MapSupport.ActiveCtx.ProjectResult.Remove(result);
                    MAP.MapSupport.ActiveCtx.Project.Remove(blProject);
                }
                MAP.MapSupport.ActiveCtx.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult DelLink(Project project, Guid id)
        {
            return View("Edit");
        }

        readonly TimeSpan UpdateTreshold = new TimeSpan(0, 0, 5, 0);

        public ActionResult RefreshStatus(Guid id)
        {
            BL.Project blProject = MAP.MapSupport.ActiveCtx.Project.Single(item => item.Id == id);
            if (blProject.TrackingUpdateTime.GetValueOrDefault() + UpdateTreshold > DateTime.Now)
            {
                return RedirectToAction("Index");
            }
            StatusTrackingAbstractionType abs = null;
            if (String.IsNullOrWhiteSpace(blProject.StatusTrackingUrl) == false)
            {
                try
                {
                    // https://raw.github.com/abstractiondev/Demo/master/LogicalOperationDemo/Abstractions/AbstractionContent/StatusTracking/In/OperationToStatusTracking/StatusTracking_FromOperationContent_v1_0.xml
                WebRequest webRequest = WebRequest.Create(blProject.StatusTrackingUrl);
                webRequest.Timeout = 5000;
                WebResponse webResponse = webRequest.GetResponse();
                XmlSerializer serializer = new XmlSerializer(typeof(StatusTrackingAbstractionType));
                abs = (StatusTrackingAbstractionType)serializer.Deserialize(webResponse.GetResponseStream());                    
                }
                catch (Exception)
                {
                    return RedirectToAction("Index");
                }
            }
            blProject.StatusData = abs;
            blProject.TrackingUpdateTime = DateTime.Now;
            MAP.MapSupport.ActiveCtx.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
