@Imports Newtonsoft.Json
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
        @Code
            Dim checked As Boolean = Session("deletedSearch")
            Dim searchName As String = Session("searchName")
        End Code
        <div>
            <div class="p-1">
                @Html.TextBox("SearchString", searchName, New With {.class = "form-control"})

            </div>

            <div class="p-1">
                @Html.CheckBox("IncludeDeleted", checked, New With {.class = "form-check-input"}) <label>Include Deleted</label>

            </div>
        </div>

        <div class="p-1">
            <button type="submit" class="btn btn-primary pa">
                <i class="fa fa-search" aria-hidden="true"></i>
            </button>
        </div>


    </div>

            End Using

@Using (Html.BeginForm("Save", "ComputerDevices"))
        @<div Class="container mx-auto p-4 h-full">
            <div Class="flex justify-center items-center h-full">
                <!-- Table -->
                <Table Class="table" id="my-table">
                    <thead>
                        <!-- Resizable area -->
                        <tr Class="text-sm font-semibold">
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
                    </thead>
                    <tbody>
                        @For i As Integer = 0 To Model.Count - 1
                            @<tr>
                                <td>
                                    <input type="number" readonly name="[@i].id" id="[@i].id" value="@Model(i).id" class="form-control" />
                                </td>
                                <td>
                                    <input type="text" name="[@i].name" value="@Model(i).name" id="[@i].name" class="form-control" />
                                </td>
                                <td>
                                    <input type="number" name="[@i].quantity" id="[@i].quantity" value="@Model(i).quantity" class="form-control" required />
                                </td>
                                <td>
                                    <input type="date" name="[@i].import_date" id="[@i].import_date" value="@Model(i).import_date.ToString("yyyy-MM-dd")" class="form-control" />
                                </td>
                                <td class="text-center">
                                    <input type="checkbox" name="[@i].include_deleted" id="[@i].include_deleted" checked="@Model(i).include_deleted" value="@Model(i).include_deleted" onchange="test(@i)" class="form-check-input input-lg" />
                                </td>
                                <td>
                                    <input type="hidden" name="[@i].sort" id="[@i].sort" value="@Model(i).sort" class="form-check-input" />
                                </td>

                                <td class="text-center">
                                    @Code
                                        If Model(i).id Is Nothing Then
                                            @<Button type="button" Class="btn btn-danger" onclick="removeColumn(@i)"><i class="fa fa-trash"></i></Button>
                                        End If
                                    End Code

                                </td>
                                <td>
                                    <button class="btn btn-toolbar" type="button">
                                        <i class="fa fa-bars" aria-hidden="true"></i>
                                    </button>
                                </td>
                            </tr>Next
                    </tbody>
                </table>
            </div>
        </div>

    @<button class="btn btn-primary" type="submit" onclick="saveData()">Save</button>
    @<button class="btn btn-success" type="submit">Export to excel</button>
                                        End Using



<script>
    var model = @Html.Raw(JsonConvert.SerializeObject(Model))
    for(let i = 0; i < model.length; i++) {
        var checked = document.getElementById(`[${i}].include_deleted`).checked;
        document.getElementById(`[${i}].include_deleted`).value = checked
    }
        function readData() {
            for (let i = 0; i < model.length; i++) {
                model[i].id = document.getElementById(`[${i}].id`).value;
                model[i].import_date = document.getElementById(`[${i}].import_date`).value;
                model[i].include_deleted = document.getElementById(`[${i}].include_deleted`).value;
                model[i].name = document.getElementById(`[${i}].name`).value;
                model[i].quantity = document.getElementById(`[${i}].quantity`).value;
                model[i].sort = document.getElementById(`[${i}].sort`).value;
            }
        }
        async function addColumn() {
            this.readData();
            model.push({ id: null, import_date: getTodayFormat(), include_deleted: false, name: "", quantity: 1, sort: null })
            this.renderView(model)
        }
     async function removeColumn(index) {

        if (index > -1) { // only splice array when item is found
            model.splice(index, 1); // 2nd parameter means remove one item only
        }
        this.renderView(model)


    }
    async function renderView(model) {
        const response = await fetch("https://localhost:44304/ComputerDevices/Add-Column", {
            method: "POST",
            headers: { "Content-Type": "application/json" },
            credentials: "include",
            body: JSON.stringify({
                computerDevices: model,
            }),
        });

        if (response.ok) {
            const result = await response.text();
            document.getElementById("text").innerHTML = result; // Hiển thị phản hồi trên giao diện
        } else {
            console.error("Lỗi khi gửi yêu cầu.");
        }
    }
    function getTodayFormat() {
        const today = new Date();
        const yyyy = today.getFullYear();
        let mm = today.getMonth() + 1; // Months start at 0!
        let dd = today.getDate();

        if (dd < 10) dd = '0' + dd;
        if (mm < 10) mm = '0' + mm;

        return yyyy + '-' + mm + '-' + dd;

    }
    function saveData() {
        for (let i = 0; i < model.length; i++) {
            var checked = document.getElementById(`[${i}].include_deleted`).checked;
            document.getElementById(`[${i}].include_deleted`).value = checked
        }
    }
    function test(i) {
        var checked = document.getElementById(`[${i}].include_deleted`).checked;
        document.getElementById(`[${i}].include_deleted`).value = checked
    }
    //////////////////////
    (function () {
        // Get the table and its rows
        var table = document.getElementById('my-table');
        var rows = table.rows;
        // Initialize the drag source element to null
        var dragSrcEl = null;

        // Loop through each row (skipping the first row which contains the table headers)
        for (var i = 1; i < rows.length; i++) {
            var row = rows[i];
            // Make each row draggable
            row.draggable = true;

            // Add an event listener for when the drag starts
            row.addEventListener('dragstart', function (e) {
                // Set the drag source element to the current row
                dragSrcEl = this;
                // Set the drag effect to "move"
                e.dataTransfer.effectAllowed = 'move';
                // Set the drag data to the outer HTML of the current row
                e.dataTransfer.setData('text/html', this.outerHTML);
                // Add a class to the current row to indicate it is being dragged
                this.classList.add('bg-gray-100');
            });

            // Add an event listener for when the drag ends
            row.addEventListener('dragend', function (e) {
                // Remove the class indicating the row is being dragged
                this.classList.remove('bg-gray-100');
                // Remove the border classes from all table rows
                table.querySelectorAll('.border-t-2', '.border-blue-300').forEach(function (el) {
                    el.classList.remove('border-t-2', 'border-blue-300');
                });
            });

            // Add an event listener for when the dragged row is over another row
            row.addEventListener('dragover', function (e) {
                // Prevent the default dragover behavior
                e.preventDefault();
                // Add border classes to the current row to indicate it is a drop target
                this.classList.add('border-t-2', 'border-blue-300');
            });

            // Add an event listener for when the dragged row enters another row
            row.addEventListener('dragenter', function (e) {
                // Prevent the default dragenter behavior
                e.preventDefault();
                // Add border classes to the current row to indicate it is a drop target
                this.classList.add('border-t-2', 'border-blue-300');
            });

            // Add an event listener for when the dragged row leaves another row
            row.addEventListener('dragleave', function (e) {
                // Remove the border classes from the current row
                this.classList.remove('border-t-2', 'border-blue-300');
            });

            // Add an event listener for when the dragged row is dropped onto another row
            row.addEventListener('drop', function (e) {
                
                // Prevent the default drop behavior
                e.preventDefault();
                // If the drag source element is not the current row
                if (dragSrcEl != this) {
                    // Get the index of the drag source element
                    var sourceIndex = dragSrcEl.rowIndex;
                    // Get the index of the target row
                    var targetIndex = this.rowIndex;
                    // If the source index is less than the target index
                    if (sourceIndex < targetIndex) {
                        // Insert the drag source element after the target row
                        table.tBodies[0].insertBefore(dragSrcEl, this.nextSibling);
                    } else {
                        // Insert the drag source element before the target row
                        table.tBodies[0].insertBefore(dragSrcEl, this);
                    }
                    console.log("choose: " + sourceIndex + " target: " + targetIndex)
                }
                // Remove the border classes from all table rows
                table.querySelectorAll('.border-t-2', '.border-blue-300').forEach(function (el) {
                    el.classList.remove('border-t-2', 'border-blue-300');
                });
            });
        }
    })();

</script>



