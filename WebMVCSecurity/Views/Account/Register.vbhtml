@ModelType RegisterViewModel
@Code
    ViewBag.Title = "Register"
End Code

<main aria-labelledby="title">
    <h2 id="title">@ViewBag.Title.</h2>

    @Using Html.BeginForm("Register", "Account", FormMethod.Post, New With {.role = "form"})

        @Html.AntiForgeryToken()

        @<text>
        <h4>Create a new account.</h4>
        <hr />
        @Html.ValidationSummary("", New With {.class = "text-danger"})
        <div class="row">
            @Html.LabelFor(Function(m) m.Email, New With {.class = "col-md-2 col-form-label"})
            <div class="col-md-10">
                @Html.TextBoxFor(Function(m) m.Email, New With {.class = "form-control"})
            </div>
        </div>
        <div class="row">
            @Html.LabelFor(Function(m) m.Password, New With {.class = "col-md-2 col-form-label"})
            <div class="col-md-10">
                @Html.PasswordFor(Function(m) m.Password, New With {.class = "form-control"})
            </div>
        </div>
        <div class="row">
            @Html.LabelFor(Function(m) m.ConfirmPassword, New With {.class = "col-md-2 col-form-label"})
            <div class="col-md-10">
                @Html.PasswordFor(Function(m) m.ConfirmPassword, New With {.class = "form-control"})
            </div>
        </div>
        <div class="row">
            <div class="offset-md-2 col-md-10">
                <input type="submit" class="btn btn-outline-dark" value="Register" />
            </div>
        </div>
        </text>
    End Using
</main>

@section Scripts
    @Scripts.Render("~/bundles/jqueryval")
End Section
