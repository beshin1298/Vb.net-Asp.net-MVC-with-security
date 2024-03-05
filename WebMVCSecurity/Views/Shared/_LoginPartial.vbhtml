@Imports Microsoft.AspNet.Identity

@If Request.IsAuthenticated Then
    @Using Html.BeginForm("LogOff", "Account", FormMethod.Post, New With {.id = "logoutForm", .class = "navbar-right"})
        @Html.AntiForgeryToken()
        @<ul class="navbar-nav navbar-right form-row align-items-center d-flex gap-2">

            <li class="p-1 nav-item">
                <a class="d-block text-decoration-none text-warning" href="@Url.Action("Index", "CartViews")">
                    <span class="d-block text-center h4" style="margin-bottom:-9px">@Session("numberOfCart")</span>
                    <img src="https://cdn-icons-png.flaticon.com/128/1170/1170678.png" width="40" height="40" class="d-block"/>
                </a>
            </li>
            <li class="p-1 nav-item">
                @Html.ActionLink("Hello " + User.Identity.GetUserName() + "!", "Index", "Manage", routeValues:=Nothing, htmlAttributes:=New With {.title = "Manage", .class = "nav-link"})
            </li>
            <li class="p-1 nav-item"><a class="nav-link" href="javascript:document.getElementById('logoutForm').submit()">Log off</a></li>
        </ul>   
    End Using
Else
    @<ul class="navbar-nav navbar-right">
        <li>@Html.ActionLink("Register", "Register", "Account", routeValues:=Nothing, htmlAttributes:=New With {.id = "registerLink", .class = "nav-link"})</li>
        <li>@Html.ActionLink("Log in", "Login", "Account", routeValues:=Nothing, htmlAttributes:=New With {.id = "loginLink", .class = "nav-link"})</li>
    </ul>
End If
<script>
    function viewCart() {

    }
</script>

