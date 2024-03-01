@ModelType WebMVCSecurity.AspNetUsers
@Code
    ViewData("Title") = "Delete"
    Layout = "~/Views/Shared/_Layout.vbhtml"
End Code

<h2>Delete</h2>

<h3>Are you sure you want to delete this?</h3>
<div>
    <h4>AspNetUsers</h4>
    <hr />
    <dl class="dl-horizontal">
        <dt>
            @Html.DisplayNameFor(Function(model) model.Email)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Email)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.EmailConfirmed)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.EmailConfirmed)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.PasswordHash)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.PasswordHash)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.SecurityStamp)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.SecurityStamp)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.PhoneNumber)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.PhoneNumber)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.PhoneNumberConfirmed)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.PhoneNumberConfirmed)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.TwoFactorEnabled)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.TwoFactorEnabled)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.LockoutEndDateUtc)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.LockoutEndDateUtc)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.LockoutEnabled)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.LockoutEnabled)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.AccessFailedCount)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.AccessFailedCount)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.UserName)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.UserName)
        </dd>

    </dl>
    @Using (Html.BeginForm())
        @Html.AntiForgeryToken()

        @<div class="form-actions no-color">
            <input type="submit" value="Delete" class="btn btn-default" /> |
            @Html.ActionLink("Back to List", "Index")
        </div>
    End Using
</div>
