@ModelType WebMVCSecurity.news
@Code
    ViewData("Title") = "Delete"
    Layout = "~/Views/Shared/_Layout.vbhtml"
End Code

<h2>Delete</h2>

<h3>Are you sure you want to delete this?</h3>
<div>
    <h4>news</h4>
    <hr />
    <dl class="dl-horizontal">
        <dt>
            @Html.DisplayNameFor(Function(model) model.title)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.title)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.text)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.text)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model._date)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model._date)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.imageTitle)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.imageTitle)
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
