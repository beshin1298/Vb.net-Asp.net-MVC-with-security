<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>@ViewBag.Title - My ASP.NET Application</title>
    @Styles.Render("~/Content/css")
    @Styles.Render("~/Content/font-awesome")




</head>
<body id="text">
    <nav class="navbar navbar-expand-lg navbar-toggleable-sm navbar-dark bg-danger">
        <div class="container">
            @Html.ActionLink("BESHIN APPLICATION", "Index", "Home", New With {.area = ""}, New With {.class = "navbar-brand"})
            <button type="button" class="navbar-toggler" data-bs-toggle="collapse" data-bs-target=".navbar-collapse" title="Toggle navigation" aria-controls="navbarSupportedContent"
                    aria-expanded="false" aria-label="Toggle navigation">
                <span class="navbar-toggler-icon"></span>
            </button>
            <div class="collapse navbar-collapse d-sm-inline-flex justify-content-between">
                <ul class="navbar-nav flex-grow-1">
                    <li>@Html.ActionLink("About", "About", "Home", New With {.area = ""}, New With {.class = "nav-link"})</li>
                    @If Request.IsAuthenticated AndAlso (User.IsInRole("Sub-Admin") Or User.IsInRole("Admin")) Then
                        If User.IsInRole("Admin") Then
                            @<li>@Html.ActionLink("Roles", "Index", "Roles", New With {.area = ""}, New With {.class = "nav-link"})</li>
                            @<li>@Html.ActionLink("Users", "Index", "AspNetUsers", New With {.area = ""}, New With {.class = "nav-link"})</li>
                            @<li>@Html.ActionLink("User role", "Index", "AspNetUserRoles", New With {.area = ""}, New With {.class = "nav-link"})</li>
                            @<li>@Html.ActionLink("Categories", "Index", "Category", New With {.area = ""}, New With {.class = "nav-link"})</li>
                            @<li>@Html.ActionLink("Products", "Index", "Product", New With {.area = ""}, New With {.class = "nav-link"})</li>
                            @<li>@Html.ActionLink("Computer Devices", "Index", "ComputerDevices", New With {.area = ""}, New With {.class = "nav-link"})</li>
                        End If


                    End If
                    <li>@Html.ActionLink("Contact", "Contact", "Home", New With {.area = ""}, New With {.class = "nav-link"})</li>

                </ul>
                @Html.Partial("_LoginPartial")
            </div>
        </div>
    </nav>
    <div Class="container body-content">
        @RenderBody()
        <hr />
        <footer>
            <p>&copy; @DateTime.Now.Year - My ASP.NET Application</p>
        </footer>
    </div>

    @Scripts.Render("~/bundles/jquery")
    @Scripts.Render("~/bundles/bootstrap")
    @Scripts.Render("~/bundles/modernizr")
    @RenderSection("scripts", required:=False)
</body>
</html>
