@ModelType IEnumerable(Of WebMVCSecurity.category)
@Code
    ViewData("Title") = "Index"
    Layout = "~/Views/Shared/_Layout.vbhtml"
End Code

<h2>DATA LIST</h2>


@Using (Html.BeginForm("Search", "Category", FormMethod.Post))
    @Html.AntiForgeryToken()
    @<div class="d-flex gap-10">
        <div class="p-1">
            @Html.TextBox("SearchString", Nothing, New With {.class = "form-control"})

        </div>
        <div class="p-1">
            <button type="submit" class="btn btn-primary pa">
                <i class="fa fa-search" aria-hidden="true"></i>
            </button>
        </div>
    </div>

End Using
<table class="table">
    <tr>
        <th>
            Category Id
        </th>
        <th>
            Name
        </th>

        <th>
            Action
        </th>
    </tr>
    @If Model.Count = 0 Then
        @<tr>
            <td colspan="3" class="text-center text-danger">List Category is null</td>
        </tr>
    Else
        @For Each item In Model
            @<tr>
                <td>
                    @Html.DisplayFor(Function(modelItem) item.category_id)
                </td>
                <td>
                    @Html.DisplayFor(Function(modelItem) item.name)
                </td>
                <td>
                    <button type="button" class="btn btn-primary" onclick="window.location.href='@Url.Action("Edit", "Category", New With {.id = item.category_id})'">
                        <i class="fa fa-cog" aria-hidden="true"></i>
                    </button>
                    <button type="button" class="btn btn-success" onclick="window.location.href='@Url.Action("Details", "Category", New With {.id = item.category_id})'">
                        <i class="fa fa-info" aria-hidden="true"></i>
                    </button>

                    <button type="button" class="btn btn-danger" onclick="location.href='@Url.Action("Delete", "Category", New With {.id = item.category_id})'">
                        <i class="fa fa-trash-o" aria-hidden="true"></i>

                    </button>
                </td>
            </tr>
        Next
    End If


</table>
<button type="button" Class="btn btn-primary" onclick="window.location.href='@Url.Action("Create", "Category")'">
    <i Class="fa fa-plus" aria-hidden="true"></i>
</button>
