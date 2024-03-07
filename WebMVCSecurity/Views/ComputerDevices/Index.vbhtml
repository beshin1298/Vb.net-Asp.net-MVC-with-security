@ModelType IEnumerable(Of WebMVCSecurity.ComputerDevice)
@Code
    ViewData("Title") = "Index"
    Layout = "~/Views/Shared/_Layout.vbhtml"
End Code

<h2>LIST DEVICES</h2>

@Using (Html.BeginForm("Search", "ComputerDevices", FormMethod.Post))
    @Html.AntiForgeryToken()
    @<div class="d-flex gap-10">
        <div>
            <label class="h5 pt-2 px-2">Device name: </label>
        </div>

        <div>
            <div class="p-1">
                @Html.TextBox("SearchString", Nothing, New With {.class = "form-control"})

            </div>
            <div class="p-1">
                @Html.CheckBox("IncludeDeleted", Nothing, New With {.class = "form-check-input"}) <label>Include Deleted</label>

            </div>
        </div>

        <div class="p-1">
            <button type="submit" class="btn btn-primary pa">
                <i class="fa fa-search" aria-hidden="true"></i>
            </button>
        </div>


    </div>

End Using

@Using (Html.BeginForm("Action", "ComputerDevices"))
    @<Table Class="table">
        <tr>
            <th>
                @Html.DisplayNameFor(Function(model) model.id)
            </th>
            <th>
                @Html.DisplayNameFor(Function(model) model.name)
            </th>
            <th>
                @Html.DisplayNameFor(Function(model) model.quantity)
            </th>
            <th>
                @Html.DisplayNameFor(Function(model) model.import_date)
            </th>
            <th>
                @Html.DisplayNameFor(Function(model) model.include_deleted)
            </th>


        </tr>

        @For i As Integer = 0 To Model.Count - 1
            @<tr>
                <td>
                    <input type="number" readonly name="[@i].id" value="@Model(i).id" class="form-control" />
                </td>
                <td>
                    <input type="text" name="[@i].name" value="@Model(i).name" class="form-control" />
                </td>
                <td>
                    <input type="number" name="[@i].quantity" value="@Model(i).quantity" class="form-control" />
                </td>
                <td>
                    <input type="date" name="[@i].import_date" value="@Model(i).import_date.ToString("yyyy-MM-dd")" class="form-control" />
                </td>
                <td class="text-center">
                    <input type="checkbox" name="[@i].include_deleted" checked="@Model(i).include_deleted" class="form-check-input input-lg" />
                </td>
                <td>
                    <input type="hidden" name="[@i].sort" value="@Model(i).sort" class="form-check-input" />
                </td>
                <td class="text-center">
                    @Code
                        If Model(i).id Is Nothing Then
                            @<Button type="button" Class="btn btn-danger"><i class="fa fa-trash"></i></Button>
                        End If
                    End Code

                </td>
            </tr>Next
        <tr>
            <td>
                <button type="submit" name="action" value="increase" class="btn btn-outline-success rounded-circle">
                    <i class="fa fa-plus"></i>
                </button>
            </td>
        </tr>

    </Table>
    @<button class="btn btn-primary" type="submit">Save</button>
    @<button class="btn btn-success" type="submit">Export to excel</button>
End Using
<script>

</script>


