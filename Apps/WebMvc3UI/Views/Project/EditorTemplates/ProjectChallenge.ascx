<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<ProjectStatusReporting.MVCModel.ProjectChallenge>" %>
<%=Html.HiddenFor(x => x.ProjectChallengeId) %>
<%=Html.HiddenFor(x => x.ProjectChallengeVersion) %>
Challenge: <%=Html.TextBoxFor(x => x.ProjectChallengeText) %>
Delete: <%= Html.CheckBoxFor(x => x.ProjectChallengeIsDeleted) %>
