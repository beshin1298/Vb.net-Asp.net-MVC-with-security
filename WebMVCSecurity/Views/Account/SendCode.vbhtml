@ModelType SendCodeViewModel
@Code
    ViewBag.Title = "Send"
End Code

<main aria-labelledby="title">
    <h2 id="title">@ViewBag.Title.</h2>

    @Using Html.BeginForm("SendCode", "Account", New With { .ReturnUrl = Model.ReturnUrl }, FormMethod.Post, New With { .role = "form" })
        @Html.AntiForgeryToken()
        @Html.Hidden("rememberMe", Model.RememberMe)
        @<text>
        <h4>Send verification code</h4>
        <hr />
        <div class="row">
            <div class="col-md-8">
                Select Two-Factor Authentication Provider:
                @Html.DropDownListFor(Function(model) model.SelectedProvider, Model.Providers)
                <input type="submit" value="Submit" class="btn btn-outline-dark" />
            </div>
        </div>
        </text>
    End Using
</main>

@Section Scripts
    @Scripts.Render("~/bundles/jqueryval")
End Section
