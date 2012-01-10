<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<ProjectStatusReporting.MVCModel.ProjectResult>" %>
<%=Html.HiddenFor(x => x.ProjectResultId) %>
<%=Html.HiddenFor(x => x.ProjectResultVersion) %>
Result: <%=Html.TextBoxFor(x => x.ProjectResultText) %>
Delete: <%= Html.CheckBoxFor(x => x.ProjectResultIsDeleted) %>
