@ModelType WebMVCSecurity.news
@Code
    ViewData("Title") = "Edit"
    Layout = "~/Views/Shared/_Layout.vbhtml"
End Code
<script src="https://cdn.ckeditor.com/4.16.2/standard/ckeditor.js"></script>
<h2>Edit</h2>

@Using (Html.BeginForm())
    @Html.AntiForgeryToken()

    @<div class="form-horizontal">
        <h4>news</h4>
        <hr />
        @Html.ValidationSummary(True, "", New With {.class = "text-danger"})
        @Html.HiddenFor(Function(model) model.id)

        <div class="form-group">
            @Html.LabelFor(Function(model) model.title, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.title, New With {.htmlAttributes = New With {.class = "form-control"}})
                @Html.ValidationMessageFor(Function(model) model.title, "", New With {.class = "text-danger"})
            </div>
        </div>
        <div class="form-group">
            @Html.LabelFor(Function(model) model.imageTitle, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.EditorFor(Function(model) model.imageTitle, New With {.htmlAttributes = New With {.class = "form-control"}})
                @Html.ValidationMessageFor(Function(model) model.imageTitle, "", New With {.class = "text-danger"})
            </div>
        </div>
        <div class="form-group">
            @Html.LabelFor(Function(model) model.text, htmlAttributes:=New With {.class = "control-label col-md-2"})
            <div class="col-md-10">
                @Html.TextAreaFor(Function(model) model.text, New With {.class = "form-control", .id = "text-editor"})
                @Html.ValidationMessageFor(Function(model) model.text, "", New With {.class = "text-danger"})
            </div>
        </div>

        <script>
            // Initialize CKEditor
            CKEDITOR.replace('text-editor');
        </script>
        <div class="form-group">
            <div class="col-md-offset-2 col-md-10 p-2">
                <input type="submit" value="Save" class="btn btn-primary" />
            </div>
        </div>
    </div>
End Using

<div>
    @Html.ActionLink("Back to List", "Index")
</div>
