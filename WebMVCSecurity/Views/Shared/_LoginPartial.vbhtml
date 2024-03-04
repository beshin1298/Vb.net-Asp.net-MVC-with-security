@Imports Microsoft.AspNet.Identity

@If Request.IsAuthenticated Then
    @Using Html.BeginForm("LogOff", "Account", FormMethod.Post, New With {.id = "logoutForm", .class = "navbar-right"})
        @Html.AntiForgeryToken()
        @<ul class="navbar-nav navbar-right">
            <li>
                <button class="btn btn-outline-warning" type="button" onclick="viewCart()">
                   
                    <span class="d-block" style="margin-bottom:-9px">@Session("numberOfCart")</span>
                    <i class="fa fa-shopping-cart fa-2x d-block" aria-hidden="true"></i>

                </button>
            </li>
            <li>
                @Html.ActionLink("Hello " + User.Identity.GetUserName() + "!", "Index", "Manage", routeValues:=Nothing, htmlAttributes:=New With {.title = "Manage", .class = "nav-link"})
            </li>
            <li><a class="nav-link" href="javascript:document.getElementById('logoutForm').submit()">Log off</a></li>
        </ul>   End Using
Else
    @<ul class="navbar-nav navbar-right">
        <li>@Html.ActionLink("Register", "Register", "Account", routeValues:=Nothing, htmlAttributes:=New With {.id = "registerLink", .class = "nav-link"})</li>
        <li>@Html.ActionLink("Log in", "Login", "Account", routeValues:=Nothing, htmlAttributes:=New With {.id = "loginLink", .class = "nav-link"})</li>
    </ul>
End If
<script>
    function viewCart() {
        console.log("hello");
    }
</script>

