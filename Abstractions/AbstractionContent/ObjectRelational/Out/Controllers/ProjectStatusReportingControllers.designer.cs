using System;
using System.Collections.Generic;
using System.Web.Mvc;
using BL = ProjectStatusReporting.BusinessLogic;
using MAP = ProjectStatusReporting.MVCModel.MappingToBL;

		namespace ProjectStatusReporting.MVCModel
{
	public partial class ProjectController
	{
	}
}		
		namespace ProjectStatusReporting.MVCModel
{
			public class EditProjectMeasurementData
		{
			public Guid ProjectId { get; set; }
	        public List<ProjectMeasurement> ProjectMeasurementList { get; set; }
	        public string returnViewName { get; set; }
		}
				public class EditProjectActionData
		{
			public Guid ProjectId { get; set; }
	        public List<ProjectAction> ProjectActionList { get; set; }
	        public string returnViewName { get; set; }
		}
				public class EditInterestGroupData
		{
			public Guid ProjectId { get; set; }
	        public List<InterestGroup> InterestGroupList { get; set; }
	        public string returnViewName { get; set; }
		}
				public class EditProjectResultData
		{
			public Guid ProjectId { get; set; }
	        public List<ProjectResult> ProjectResultList { get; set; }
	        public string returnViewName { get; set; }
		}
				public class EditProjectChallengeData
		{
			public Guid ProjectId { get; set; }
	        public List<ProjectChallenge> ProjectChallengeList { get; set; }
	        public string returnViewName { get; set; }
		}
				public class EditCounterActionData
		{
			public Guid ProjectId { get; set; }
	        public List<CounterAction> CounterActionList { get; set; }
	        public string returnViewName { get; set; }
		}
			partial class ProjectController
	{
		        public ActionResult EditProjectMeasurement(Guid id, string returnUrl)
        {
            Project entity = GetProject(id);
            return View("EditProjectMeasurement", new EditProjectMeasurementData {
                                                         ProjectId = id, ProjectMeasurementList = entity.ProjectStatusInfo.Measurements, returnViewName = returnUrl
                                                     });
        }

        [HttpPost]
        public ActionResult EditProjectMeasurement(EditProjectMeasurementData model, string button, List<ProjectMeasurement> ProjectMeasurementList, string returnViewName)
        {
            // TODO: Version concurrency check
			            if(button.StartsWith("Add"))
            {
                model.ProjectMeasurementList.Add(new ProjectMeasurement());
                return View(model);
            }
			            Guid ProjectId = model.ProjectId;
            Project entity = GetProject(ProjectId);
            entity.ProjectStatusInfo.Measurements = ProjectMeasurementList;
            BL.Project blProject = MAP.MapProject.MapMvcToBusiness(entity);
            MAP.MapSupport.ActiveCtx.SaveChanges();
            entity = GetProject(ProjectId);
            return View(returnViewName, entity);
        }
		        public ActionResult EditProjectAction(Guid id, string returnUrl)
        {
            Project entity = GetProject(id);
            return View("EditProjectAction", new EditProjectActionData {
                                                         ProjectId = id, ProjectActionList = entity.ProjectStatusInfo.Actions, returnViewName = returnUrl
                                                     });
        }

        [HttpPost]
        public ActionResult EditProjectAction(EditProjectActionData model, string button, List<ProjectAction> ProjectActionList, string returnViewName)
        {
            // TODO: Version concurrency check
			            if(button.StartsWith("Add"))
            {
                model.ProjectActionList.Add(new ProjectAction());
                return View(model);
            }
			            Guid ProjectId = model.ProjectId;
            Project entity = GetProject(ProjectId);
            entity.ProjectStatusInfo.Actions = ProjectActionList;
            BL.Project blProject = MAP.MapProject.MapMvcToBusiness(entity);
            MAP.MapSupport.ActiveCtx.SaveChanges();
            entity = GetProject(ProjectId);
            return View(returnViewName, entity);
        }
		        public ActionResult EditInterestGroup(Guid id, string returnUrl)
        {
            Project entity = GetProject(id);
            return View("EditInterestGroup", new EditInterestGroupData {
                                                         ProjectId = id, InterestGroupList = entity.ProjectStatusInfo.InterestGroups, returnViewName = returnUrl
                                                     });
        }

        [HttpPost]
        public ActionResult EditInterestGroup(EditInterestGroupData model, string button, List<InterestGroup> InterestGroupList, string returnViewName)
        {
            // TODO: Version concurrency check
			            if(button.StartsWith("Add"))
            {
                model.InterestGroupList.Add(new InterestGroup());
                return View(model);
            }
			            Guid ProjectId = model.ProjectId;
            Project entity = GetProject(ProjectId);
            entity.ProjectStatusInfo.InterestGroups = InterestGroupList;
            BL.Project blProject = MAP.MapProject.MapMvcToBusiness(entity);
            MAP.MapSupport.ActiveCtx.SaveChanges();
            entity = GetProject(ProjectId);
            return View(returnViewName, entity);
        }
		        public ActionResult EditProjectResult(Guid id, string returnUrl)
        {
            Project entity = GetProject(id);
            return View("EditProjectResult", new EditProjectResultData {
                                                         ProjectId = id, ProjectResultList = entity.ProjectStatusInfo.Results, returnViewName = returnUrl
                                                     });
        }

        [HttpPost]
        public ActionResult EditProjectResult(EditProjectResultData model, string button, List<ProjectResult> ProjectResultList, string returnViewName)
        {
            // TODO: Version concurrency check
			            if(button.StartsWith("Add"))
            {
                model.ProjectResultList.Add(new ProjectResult());
                return View(model);
            }
			            Guid ProjectId = model.ProjectId;
            Project entity = GetProject(ProjectId);
            entity.ProjectStatusInfo.Results = ProjectResultList;
            BL.Project blProject = MAP.MapProject.MapMvcToBusiness(entity);
            MAP.MapSupport.ActiveCtx.SaveChanges();
            entity = GetProject(ProjectId);
            return View(returnViewName, entity);
        }
		        public ActionResult EditProjectChallenge(Guid id, string returnUrl)
        {
            Project entity = GetProject(id);
            return View("EditProjectChallenge", new EditProjectChallengeData {
                                                         ProjectId = id, ProjectChallengeList = entity.ProjectStatusInfo.ChallengesAndExceptions, returnViewName = returnUrl
                                                     });
        }

        [HttpPost]
        public ActionResult EditProjectChallenge(EditProjectChallengeData model, string button, List<ProjectChallenge> ProjectChallengeList, string returnViewName)
        {
            // TODO: Version concurrency check
			            if(button.StartsWith("Add"))
            {
                model.ProjectChallengeList.Add(new ProjectChallenge());
                return View(model);
            }
			            Guid ProjectId = model.ProjectId;
            Project entity = GetProject(ProjectId);
            entity.ProjectStatusInfo.ChallengesAndExceptions = ProjectChallengeList;
            BL.Project blProject = MAP.MapProject.MapMvcToBusiness(entity);
            MAP.MapSupport.ActiveCtx.SaveChanges();
            entity = GetProject(ProjectId);
            return View(returnViewName, entity);
        }
		        public ActionResult EditCounterAction(Guid id, string returnUrl)
        {
            Project entity = GetProject(id);
            return View("EditCounterAction", new EditCounterActionData {
                                                         ProjectId = id, CounterActionList = entity.ProjectStatusInfo.CounterActions, returnViewName = returnUrl
                                                     });
        }

        [HttpPost]
        public ActionResult EditCounterAction(EditCounterActionData model, string button, List<CounterAction> CounterActionList, string returnViewName)
        {
            // TODO: Version concurrency check
			            if(button.StartsWith("Add"))
            {
                model.CounterActionList.Add(new CounterAction());
                return View(model);
            }
			            Guid ProjectId = model.ProjectId;
            Project entity = GetProject(ProjectId);
            entity.ProjectStatusInfo.CounterActions = CounterActionList;
            BL.Project blProject = MAP.MapProject.MapMvcToBusiness(entity);
            MAP.MapSupport.ActiveCtx.SaveChanges();
            entity = GetProject(ProjectId);
            return View(returnViewName, entity);
        }
			}
}
		
		