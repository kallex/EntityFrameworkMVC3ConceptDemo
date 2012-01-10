<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<ProjectStatusReporting.MVCModel.ProjectStatusInfo>" %>
<%= Html.HiddenFor(model => model.ProjectStatusInfoId) %>
<%= Html.HiddenFor(model => model.ProjectStatusInfoVersion) %>
<fieldset>
    <legend>ProjectStatusInfo</legend>

    <div class="editor-label">
        <%= Html.LabelFor(model => model.ProjectStatusInfoOwner) %>
    </div>
    <div class="editor-field">
        <%= Html.EditorFor(model => model.ProjectStatusInfoOwner) %>
        <%= Html.ValidationMessageFor(model => model.ProjectStatusInfoOwner) %>
    </div>

    <div class="editor-label">
        <%= Html.LabelFor(model => model.ProjectStatusInfoUpdated) %>
    </div>
    <div class="editor-field">
        <%= Html.EditorFor(model => model.ProjectStatusInfoUpdated) %>
        <%= Html.ValidationMessageFor(model => model.ProjectStatusInfoUpdated) %>
    </div>

    <div class="editor-label">
        <%= Html.LabelFor(model => model.ProjectStatusInfoGoal) %>
    </div>
    <div class="editor-field">
        <%= Html.EditorFor(model => model.ProjectStatusInfoGoal) %>
        <%= Html.ValidationMessageFor(model => model.ProjectStatusInfoGoal) %>
    </div>
    <h2>Project Actions:</h2>
    <p>
    <% for(int i = 0; i < Model.Actions.Count; i++) { %>
        <div>
        <%= Html.EditorFor(x => x.Actions[i], "ProjectAction") %>
        </div>
    <% } %>
        <input type="submit" name="button" value="Add Action" />
    </p>
    <h2>Project Measurements:</h2>
    <p>
    <% for(int i = 0; i < Model.Measurements.Count; i++) { %>
        <div>
        <%= Html.EditorFor(x => x.Measurements[i], "ProjectMeasurement") %>
        </div>
    <% } %>
        <input type="submit" name="button" value="Add Measurement" />
    </p>
    <h2>Project Interest Groups:</h2>
    <p>
    <% for(int i = 0; i < Model.InterestGroups.Count; i++) { %>
        <div>
        <%= Html.EditorFor(x => x.InterestGroups[i], "InterestGroup") %>
        </div>
    <% } %>
        <input type="submit" name="button" value="Add Interest Group" />
    </p>
    <h2>Project Results:</h2>
    <p>
    <% for(int i = 0; i < Model.Results.Count; i++) { %>
        <div>
        <%= Html.EditorFor(x => x.Results[i], "ProjectResult") %>
        </div>
    <% } %>
        <input type="submit" name="button" value="Add Result" />
    </p>
    <h2>Project Challenges And Exceptions:</h2>
    <p>
    <% for(int i = 0; i < Model.ChallengesAndExceptions.Count; i++) { %>
        <div>
        <%= Html.EditorFor(x => x.ChallengesAndExceptions[i], "ProjectChallenge") %>
        </div>
    <% } %>
        <input type="submit" name="button" value="Add Challenge" />
    </p>
    <h2>Project Counter Actions:</h2>
    <p>
    <% for(int i = 0; i < Model.CounterActions.Count; i++) { %>
        <div>
        <%= Html.EditorFor(x => x.CounterActions[i], "ProjectCounterActions") %>
        </div>
    <% } %>
        <input type="submit" name="button" value="Add Counter Action" />
    </p>

</fieldset>
