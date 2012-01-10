<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<ProjectStatusReporting.MVCModel.CounterAction>" %>
<%=Html.HiddenFor(x => x.CounterActionId) %>
<%=Html.HiddenFor(x => x.CounterActionVersion) %>
Counter Action: <%=Html.TextBoxFor(x => x.CounterActionText) %>
Delete: <%= Html.CheckBoxFor(x => x.CounterActionIsDeleted) %>
