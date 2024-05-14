@ModelType IEnumerable(Of WebMVCSecurity.news)
@Code
ViewData("Title") = "Index"
Layout = "~/Views/Shared/_Layout.vbhtml"
End Code

<h2>Index</h2>

<p>
    @Html.ActionLink("Create New", "Create")
</p>
<table class="table">
    <tr>
        <th>
            @Html.DisplayNameFor(Function(model) model.title)
        </th>
       
        <th>
            @Html.DisplayNameFor(Function(model) model.releaseDate)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.imageTitle)
        </th>
        <th></th>
    </tr>

@For Each item In Model
    @<tr>
        <td>
            @Html.DisplayFor(Function(modelItem) item.title)
        </td>
        
        <td>
            @Html.DisplayFor(Function(modelItem) item.releaseDate)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.imageTitle)
        </td>
        <td>
            @Html.ActionLink("Edit", "Edit", New With {.id = item.id}) |
            @Html.ActionLink("Details", "Details", New With {.id = item.id}) |
            @Html.ActionLink("Delete", "Delete", New With {.id = item.id})
        </td>
    </tr>
Next

</table>
