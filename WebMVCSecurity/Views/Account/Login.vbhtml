@ModelType LoginViewModel
@Code
    ViewBag.Title = "Log in"
End Code

<main aria-labelledby="title">
    <h2 id="title">@ViewBag.Title.</h2>
    <div class="row">
        <div class="col-md-8">
            <section id="loginForm">
                @Using Html.BeginForm("Login", "Account", New With { .ReturnUrl = ViewBag.ReturnUrl }, FormMethod.Post, New With {.role = "form"})
                    @Html.AntiForgeryToken()
                    @<text>
                    <h4>Use a local account to log in.</h4>
                    <hr />
                    @Html.ValidationSummary(True, "", New With {.class = "text-danger"})
                    <div class="row">
                        @Html.LabelFor(Function(m) m.Email, New With {.class = "col-md-2 col-form-label"})
                        <div class="col-md-10">
                            @Html.TextBoxFor(Function(m) m.Email, New With {.class = "form-control"})
                            @Html.ValidationMessageFor(Function(m) m.Email, "", New With {.class = "text-danger"})
                        </div>
                    </div>
                    <div class="row">
                        @Html.LabelFor(Function(m) m.Password, New With {.class = "col-md-2 col-form-label"})
                        <div class="col-md-10">
                            @Html.PasswordFor(Function(m) m.Password, New With {.class = "form-control"})
                            @Html.ValidationMessageFor(Function(m) m.Password, "", New With {.class = "text-danger"})
                        </div>
                    </div>
                    <div class="row">
                        <div class="offset-md-2 col-md-10">
                            <div class="checkbox">
                                @Html.CheckBoxFor(Function(m) m.RememberMe)
                                @Html.LabelFor(Function(m) m.RememberMe)
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="offset-md-2 col-md-10">
                            <input type="submit" value="Log in" class="btn btn-outline-dark" />
                        </div>
                    </div>
                    <p>
                        @Html.ActionLink("Register as a new user", "Register")
                    </p>
                    @* Enable this once you have account confirmation enabled for password reset functionality
                        <p>
                            @Html.ActionLink("Forgot your password?", "ForgotPassword")
                        </p>*@
                    </text>
                End Using
            </section>
        </div>
        <div class="col-md-4">
            <section id="socialLoginForm">
                @Html.Partial("_ExternalLoginsListPartial", New ExternalLoginListViewModel With {.ReturnUrl = ViewBag.ReturnUrl})
            </section>
        </div>
    </div>
</main>

@Section Scripts
    @Scripts.Render("~/bundles/jqueryval")
End Section
