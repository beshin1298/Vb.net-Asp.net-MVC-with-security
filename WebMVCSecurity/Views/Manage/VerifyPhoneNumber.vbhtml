@ModelType VerifyPhoneNumberViewModel
@Code
    ViewBag.Title = "Verify Phone Number"
End Code

<main aria-labelledby="title">
    <h2 id="title">@ViewBag.Title.</h2>

    @Using Html.BeginForm("VerifyPhoneNumber", "Manage", FormMethod.Post, New With { .role = "form" })
        @Html.AntiForgeryToken()
        @Html.Hidden("phoneNumber", Model.PhoneNumber)
        @<text>
        <h4>Enter verification code</h4>
        <h5>@ViewBag.Status</h5>
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
                <input type="submit" class="btn btn-outline-dark" value="Submit" />
            </div>
        </div>
        </text>
    End Using
</main>

@Section Scripts
    @Scripts.Render("~/bundles/jqueryval")
End Section
