@ModelType WebMVCSecurity.ComputerDevice
@Code
    ViewData("Title") = "Details"
    Layout = "~/Views/Shared/_Layout.vbhtml"
End Code

<h2>Details</h2>

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
</div>
<p>
    @Html.ActionLink("Edit", "Edit", New With { .id = Model.id }) |
    @Html.ActionLink("Back to List", "Index")
</p>
