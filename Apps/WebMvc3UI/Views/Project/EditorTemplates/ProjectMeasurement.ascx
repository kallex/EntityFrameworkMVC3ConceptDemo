<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<ProjectStatusReporting.MVCModel.ProjectMeasurement>" %>
<%=Html.HiddenFor(x => x.ProjectMeasurementId) %>
<%=Html.HiddenFor(x => x.ProjectMeasurementVersion) %>
Measurement: <%=Html.TextBoxFor(x => x.ProjectMeasurementText) %>
Status: <%=Html.TextBoxFor(x => x.ProjectMeasurementStatus) %>
Delete: <%= Html.CheckBoxFor(x => x.ProjectMeasurementIsDeleted) %>
