<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<ProjectStatusReporting.MVCModel.ProjectAction>" %>
<%=Html.HiddenFor(x => x.ProjectActionId) %>
<%=Html.HiddenFor(x => x.ProjectActionVersion) %>
Action: <%=Html.TextBoxFor(x => x.ProjectActionText) %>
Status: <%=Html.TextBoxFor(x => x.ProjectActionStatus) %>
Delete: <%= Html.CheckBoxFor(x => x.ProjectActionIsDeleted) %>
