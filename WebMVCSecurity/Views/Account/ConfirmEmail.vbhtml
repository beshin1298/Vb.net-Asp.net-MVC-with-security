@Code
    ViewBag.Title = "Confirm Email"
End Code

<main aria-labelledby="title">
    <h2 id="title">@ViewBag.Title.</h2>
    <div>
        <p>
            Thank you for confirming your email. Please @Html.ActionLink("Click here to Log in", "Login", "Account", routeValues:=Nothing, htmlAttributes:=New With {Key .id = "loginLink"})
        </p>
    </div>
</main>
