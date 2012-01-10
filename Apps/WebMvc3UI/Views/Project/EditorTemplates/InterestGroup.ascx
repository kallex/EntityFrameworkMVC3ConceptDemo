<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<ProjectStatusReporting.MVCModel.InterestGroup>" %>
<%=Html.HiddenFor(x => x.InterestGroupId) %>
<%=Html.HiddenFor(x => x.InterestGroupVersion) %>
Interest Group: <%=Html.TextBoxFor(x => x.InterestGroupName) %>
Delete: <%= Html.CheckBoxFor(x => x.InterestGroupIsDeleted) %>
