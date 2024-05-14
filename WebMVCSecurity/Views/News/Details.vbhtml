@ModelType WebMVCSecurity.news
@Code
    ViewData("Title") = "Details"
    Layout = "~/Views/Shared/_Layout.vbhtml"
End Code

<div>
    <h4>NEWS</h4>
    <hr />
    <dl class="dl-horizontal">
        <dd>
            <h1>@Html.DisplayFor(Function(model) model.title)</h1>
        </dd>
        <dd>
            <i> @Html.DisplayFor(Function(model) model.releaseDate)</i>
        </dd>
        <dd>
            @MvcHtmlString.Create(Model.text)
        </dd>
    </dl>
</div>

