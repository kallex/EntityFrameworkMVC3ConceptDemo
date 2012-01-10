<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<ProjectStatusReporting.MVCModel.ProjectInfo>" %>
<%= Html.HiddenFor(model => model.ProjectInfoId) %>
<%= Html.HiddenFor(model => model.ProjectInfoVersion) %>
<fieldset>
    <legend>ProjectInfo</legend>

    <div class="editor-label">
        <%= Html.LabelFor(model => model.ProjectInfoName) %>
    </div>
    <div class="editor-field">
        <%= Html.EditorFor(model => model.ProjectInfoName) %>
        <%= Html.ValidationMessageFor(model => model.ProjectInfoName) %>
    </div>

    <div class="editor-label">
        <%= Html.LabelFor(model => model.ProjectInfoResponsibleUnitName) %>
    </div>
    <div class="editor-field">
        <%= Html.EditorFor(model => model.ProjectInfoResponsibleUnitName) %>
        <%= Html.ValidationMessageFor(model => model.ProjectInfoResponsibleUnitName) %>
    </div>

    <div class="editor-label">
        <%= Html.LabelFor(model => model.ProjectInfoResponsiblePersonName) %>
    </div>
    <div class="editor-field">
        <%= Html.EditorFor(model => model.ProjectInfoResponsiblePersonName) %>
        <%= Html.ValidationMessageFor(model => model.ProjectInfoResponsiblePersonName) %>
    </div>

    <div class="editor-label">
        <%= Html.LabelFor(model => model.ProjectInfoFocusedYear) %>
    </div>
    <div class="editor-field">
        <%= Html.EditorFor(model => model.ProjectInfoFocusedYear) %>
        <%= Html.ValidationMessageFor(model => model.ProjectInfoFocusedYear) %>
    </div>

    <div class="editor-label">
        <%= Html.LabelFor(model => model.ProjectInfoFocusedYearBudgetEuros) %>
    </div>
    <div class="editor-field">
        <%= Html.EditorFor(model => model.ProjectInfoFocusedYearBudgetEuros) %>
        <%= Html.ValidationMessageFor(model => model.ProjectInfoFocusedYearBudgetEuros) %>
    </div>

    <div class="editor-label">
        <%= Html.LabelFor(model => model.ProjectInfoFocusedYearEstimateEuros) %>
    </div>
    <div class="editor-field">
        <%= Html.EditorFor(model => model.ProjectInfoFocusedYearEstimateEuros) %>
        <%= Html.ValidationMessageFor(model => model.ProjectInfoFocusedYearEstimateEuros) %>
    </div>

    <div class="editor-label">
        <%= Html.LabelFor(model => model.ProjectInfoCommittedBudgetForNextYear) %>
    </div>
    <div class="editor-field">
        <%= Html.EditorFor(model => model.ProjectInfoCommittedBudgetForNextYear) %>
        <%= Html.ValidationMessageFor(model => model.ProjectInfoCommittedBudgetForNextYear) %>
    </div>

    <div class="editor-label">
        <%= Html.LabelFor(model => model.ProjectInfoWholeDurationRange, "Whole duration range") %>
    </div>
    <div class="editor-field">
        <%= Html.EditorFor(model => model.ProjectInfoWholeDurationRange) %>
        <%= Html.ValidationMessageFor(model => model.ProjectInfoWholeDurationRange) %>
    </div>
</fieldset>
