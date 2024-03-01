@ModelType IEnumerable(Of WebMVCSecurity.AspNetUsers)
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
            @Html.DisplayNameFor(Function(model) model.Email)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.EmailConfirmed)
        </th>
       
        <th>
            @Html.DisplayNameFor(Function(model) model.SecurityStamp)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.PhoneNumber)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.PhoneNumberConfirmed)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.TwoFactorEnabled)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.LockoutEndDateUtc)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.LockoutEnabled)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.AccessFailedCount)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.UserName)
        </th>
        <th></th>
    </tr>

@For Each item In Model
    @<tr>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Email)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.EmailConfirmed)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.SecurityStamp)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.PhoneNumber)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.PhoneNumberConfirmed)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.TwoFactorEnabled)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.LockoutEndDateUtc)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.LockoutEnabled)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.AccessFailedCount)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.UserName)
        </td>
        <td>
            @Html.ActionLink("Edit", "Edit", New With {.id = item.Id}) |
            @Html.ActionLink("Details", "Details", New With {.id = item.Id}) |
            @Html.ActionLink("Delete", "Delete", New With {.id = item.Id})
        </td>
    </tr>
Next

</table>
