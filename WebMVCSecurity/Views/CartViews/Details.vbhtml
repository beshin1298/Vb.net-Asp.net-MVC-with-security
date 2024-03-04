@ModelType WebMVCSecurity.CartView
@Code
    ViewData("Title") = "Details"
    Layout = "~/Views/Shared/_Layout.vbhtml"
End Code

<h2>Details</h2>

<div>
    <h4>CartView</h4>
    <hr />
    <dl class="dl-horizontal">
        <dt>
            @Html.DisplayNameFor(Function(model) model.product_id)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.product_id)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.quantity)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.quantity)
        </dd>

    </dl>
</div>
<p>
    @Html.ActionLink("Edit", "Edit", New With { .id = Model.cart_id }) |
    @Html.ActionLink("Back to List", "Index")
</p>
