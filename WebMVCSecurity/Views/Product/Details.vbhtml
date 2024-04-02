@ModelType WebMVCSecurity.product
@Code
    ViewData("Title") = "Details"
    Layout = "~/Views/Shared/_Layout.vbhtml"
End Code

<h2>Details</h2>

<div class="container my-5">
    <div class="row">
        <div class="col-md-5">
            <div class="main-img">
                <img class="img-fluid" src="@Model.image" alt="ProductS">
            </div>
        </div>
        <div class="col-md-7">
            <div class="main-description px-2">
                <div class="category font-weight-bold">Category: @Model.category.name</div>
                <h1 class="product-title">@Model.name</h1>
                <div class="product-description">Price: @Model.price$</div>
                <p class="product-description"> Quantity in warehouse: @Model.quantity</p>
            </div>
            <div>
                @If Request.IsAuthenticated AndAlso User.IsInRole("Admin") Then
                    @Html.ActionLink("Edit", "Edit", New With {.id = Model.product_id})
                End If
                @Html.ActionLink("Back to List", "About", "Home")
            </div>
        </div>
        @*comment*@
        <section>
            <div class="container my-5 py-5">
                <div class="row d-flex justify-content-center">
                    <div class="col-md-12 col-lg-10">
                        <div class="card text-dark">
                            <div class="card-body p-4">
                                <h4 class="mb-0">Recent comments</h4>
                                <p class="fw-light mb-4 pb-2">Latest Comments section by users</p>
                                @For Each item In Model.Comments
                                    @<div Class="d-flex flex-start">
                                        <img Class="rounded-circle shadow-1-strong me-3"
                                             src="https://w7.pngwing.com/pngs/177/551/png-transparent-user-interface-design-computer-icons-default-stephen-salazar-graphy-user-interface-design-computer-wallpaper-sphere-thumbnail.png" alt="avatar" width="60"
                                             height="60" />
                                        <div>
                                            <h6 Class="fw-bold mb-1">@item.user.UserName</h6>
                                            <p Class="mb-0">
                                                @item.commentString
                                            </p>
                                        </div>
                                    </div>
                                    @<hr />
                                Next
                                @If Request.IsAuthenticated Then

                                    @Using (Html.BeginForm("Comment", "Product"))
                                        @Html.AntiForgeryToken()
                                        @<div Class="d-flex flex-start">
                                            <img Class="rounded-circle shadow-1-strong me-3"
                                                 src="https://w7.pngwing.com/pngs/177/551/png-transparent-user-interface-design-computer-icons-default-stephen-salazar-graphy-user-interface-design-computer-wallpaper-sphere-thumbnail.png" alt="avatar" width="60"
                                                 height="60" />
                                            <div class="w-100">
                                                <h6 Class="fw-bold mb-1">POST YOUR COMMENT</h6>
                                                @Html.Hidden("productId", Model.product_id)
                                                @Html.TextArea("commentString", Nothing, New With {.class = "form-control", .id = "comment", .style = "width:100%; heigth: 100%"})
                                                <Button type="submit" onclick="checkComment(event)" Class="btn btn-warning mt-2 w-20">Comment</Button>
                                            </div>
                                            

                                        </div>
                                    End Using
                                End If


                            </div>
                        </div>
                    </div>
                </div>
                <div>

                </div>
            </div>
        </section>

    </div>
</div>
<Script>
                                Function checkComment(event) {
                                            let commentStr = document.getElementById("comment").value;
                                            If (commentStr.trim() === "") Then {
                                                alert("Please comment something!");
                                               Event.preventDefault();
                                            }
                                        }
</Script>
