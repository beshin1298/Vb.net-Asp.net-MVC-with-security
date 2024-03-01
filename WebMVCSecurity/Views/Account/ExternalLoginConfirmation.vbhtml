@ModelType ExternalLoginConfirmationViewModel
@Code
    ViewBag.Title = "Register"
End Code

<main aria-labelledby="title">
    <h2 id="title">@ViewBag.Title.</h2>
    <h3>Associate your @ViewBag.LoginProvider account.</h3>

    @Using Html.BeginForm("ExternalLoginConfirmation", "Account", New With { .ReturnUrl = ViewBag.ReturnUrl }, FormMethod.Post, New With {.role = "form"})
        @Html.AntiForgeryToken()

        @<text>
        <h4>Association Form</h4>
        <hr />
        @Html.ValidationSummary(True, "", New With {.class = "text-danger"})
        <p class="text-info">
            You've successfully authenticated with <strong>@ViewBag.LoginProvider</strong>.
            Please enter a user name for this site below and click the Register button to finish
            logging in.
        </p>
        <div class="row">
            @Html.LabelFor(Function(m) m.Email, New With {.class = "col-md-2 col-form-label"})
            <div class="col-md-10">
                @Html.TextBoxFor(Function(m) m.Email, New With {.class = "form-control"})
                @Html.ValidationMessageFor(Function(m) m.Email, "", New With {.class = "text-danger"})
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

@Section Scripts
    @Scripts.Render("~/bundles/jqueryval")
End Section
