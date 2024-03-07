@ModelType WebMVCSecurity.ComputerDevice
@Code
    ViewData("Title") = "Delete"
    Layout = "~/Views/Shared/_Layout.vbhtml"
End Code

<h2>Delete</h2>

<h3>Are you sure you want to delete this?</h3>
<div>
    <h4>ComputerDevice</h4>
    <hr />
    <dl class="dl-horizontal">
        <dt>
            @Html.DisplayNameFor(Function(model) model.name)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.name)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.quantity)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.quantity)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.import_date)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.import_date)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.include_deleted)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.include_deleted)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.sort)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.sort)
        </dd>

    </dl>
    @Using (Html.BeginForm())
        @Html.AntiForgeryToken()

        @<div class="form-actions no-color">
            <input type="submit" value="Delete" class="btn btn-default" /> |
            @Html.ActionLink("Back to List", "Index")
        </div>
    End Using
</div>
