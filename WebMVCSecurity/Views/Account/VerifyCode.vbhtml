@ModelType VerifyCodeViewModel
@Code
    ViewBag.Title = "Verify"
End Code

<main aria-labelledby="title">
    <h2 id="title">@ViewBag.Title.</h2>

    @using Html.BeginForm("VerifyCode", "Account", New With { .ReturnUrl = Model.ReturnUrl }, FormMethod.Post, New With { .role = "form" })
        @Html.AntiForgeryToken()
        @Html.Hidden("provider", Model.Provider)
        @Html.Hidden("rememberMe", Model.RememberMe)
        @<text>
        <h4>Enter verification code</h4>
        <hr />
        @Html.ValidationSummary("", New With { .class = "text-danger" })
        <div class="row">
            @Html.LabelFor(Function(m) m.Code, New With { .class = "col-md-2 col-form-label" })
            <div class="col-md-10">
                @Html.TextBoxFor(Function(m) m.Code, New With { .class = "form-control" })
            </div>
        </div>
        <div class="row">
            <div class="offset-md-2 col-md-10">
                <div class="checkbox">
                    @Html.CheckBoxFor(Function(m) m.RememberBrowser)
                    @Html.LabelFor(Function(m) m.RememberBrowser)
                </div>
            </div>
        </div>
        <div class="row">
            <div class="offset-md-2 col-md-10">
                <input type="submit" class="btn btn-outline-dark" value="Submit" />
            </div>
        </div>
        </text>
    End Using
</main>

@Section Scripts
    @Scripts.Render("~/bundles/jqueryval")
End Section
