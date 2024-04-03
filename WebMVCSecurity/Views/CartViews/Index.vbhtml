@ModelType IEnumerable(Of WebMVCSecurity.CartView)
@Code
    ViewData("Title") = "Index"
    Layout = "~/Views/Shared/_Layout.vbhtml"
End Code

<h2>Your Cart</h2>

<section class="h-100 h-custom" style="background-color: #eee;">
    <div class="container py-5 h-100">
        <div class="row d-flex justify-content-center align-items-center h-100">
            <div class="col">
                <div class="card">
                    <div class="card-body p-4">

                        <div class="row">

                            <div class="col-lg-7">
                                <h5 class="mb-3">
                                    <a href="@Url.Action("About", "Home")" class="text-body">
                                        <i class="fas fa-long-arrow-alt-left me-2"></i>Continue shopping
                                    </a>
                                </h5>
                                <hr>

                                <div class="d-flex justify-content-between align-items-center mb-4">
                                    <div>
                                        <p class="mb-1">Shopping cart</p>
                                        <p class="mb-0">You have @Session("numberOfCart") items in your cart</p>
                                    </div>
                                    <div>
                                        <p class="mb-0">
                                            <span class="text-muted">Sort by:</span> <a href="#!"
                                                                                        class="text-body">price <i class="fa fa-angle-down mt-1"></i></a>
                                        </p>
                                    </div>
                                </div>
                                @Code
                                    Dim SubTotal As Integer
                                    Dim ShippingFee As Integer = 20
                                End Code
                                @For Each item In Model
                                    @Code
                                        SubTotal += item.quantity * item.Product.price
                                    End Code
                                    @<div Class="card mb-3">
                                        <div Class="card-body">
                                            <div Class="d-flex justify-content-between">
                                                <div Class="d-flex flex-row align-items-center">
                                                    <div>
                                                        <img src="@item.Product.image"
                                                             Class="img-fluid rounded-3" alt="Shopping item" style="width: 65px;">
                                                    </div>
                                                    <div Class="ms-3">
                                                        <h5>@item.Product.name</h5>
                                                        <p Class="small mb-0">256GB, Navy Blue</p>
                                                    </div>

                                                </div>

                                                <div Class="d-flex flex-row align-items-center">
                                                    @Using Html.BeginForm("Edit", "CartViews", New With {.productId = item.product_id}, FormMethod.Post)
                                                        @Html.AntiForgeryToken()
                                                        @<div style="width: 50px;" class="d-flex mx-4">
                                                            <button class="btn btn-danger pt-1 px-1 h-25" value="decrease" type="submit" name="submitButton"> <i class="fa fa-minus" aria-hidden="true"></i></button>
                                                            <h5 class="fw-normal p-1">@item.quantity</h5>
                                                            <button class="pt-1 px-1 btn btn-warning h-25" value="increase" type="submit" name="submitButton"> <i class="fa fa-plus" aria-hidden="true"></i></button>
                                                        </div>
                                                    End Using


                                                    <div style="width: 80px;" class="text-end">
                                                        <h5 class="mb-0">
                                                            @Code
                                                                Dim TotalProduct = item.Product.price * item.quantity
                                                            End Code
                                                            @TotalProduct.ToString("0,0$")
                                                        </h5>

                                                    </div>
                                                    <a href="#!" style="color: #cecece;"><i Class="fas fa-trash-alt"></i></a>
                                                </div>
                                            </div>
                                        </div>
                                        @Using (Html.BeginForm("Delete", "CartViews", New With {.productId = item.product_id}, FormMethod.Post))
                                            @Html.AntiForgeryToken()
                                            @<div Class="col-md-1 text-end p-1 w-100">
                                                <button type="submit" Class="btn btn-danger"><i Class="fa fa-trash"></i></button>
                                            </div>
                                        End Using


                                    </div>

                                Next
                            </div>
                            <div Class="col-lg-5">

                                <div Class="card bg-primary text-white rounded-3">
                                    <div Class="card-body">
                                        <div Class="d-flex justify-content-between align-items-center mb-4">
                                            <h5 Class="mb-0">Card details</h5>
                                            <img src="https://mdbcdn.b-cdn.net/img/Photos/Avatars/avatar-6.webp"
                                                 Class="img-fluid rounded-3" style="width: 45px;" alt="Avatar">
                                        </div>

                                        <p Class="small mb-2">Card type</p>
                                        <a href="#!" type="submit" Class="text-white">
                                            <i Class="fa fa-cc-mastercard fa-2x" aria-hidden="true"></i>

                                        </a>
                                        <a href="#!" type="submit" Class="text-white">
                                            <i Class="fa fa-cc-visa fa-2x me-2"></i>
                                        </a>
                                        <a href="#!" type="submit" Class="text-white">
                                            <i Class="fa fa-cc-amex fa-2x me-2"></i>
                                        </a>
                                        <a href="#!" type="submit" Class="text-white"><i Class="fa fa-cc-paypal fa-2x"></i></a>

                                        <form Class="mt-4">
                                            <div Class="form-outline form-white mb-4">
                                                <input type="text" id="typeName" Class="form-control form-control-lg" siez="17"
                                                       placeholder="Cardholder's Name" />
                                                <Label Class="form-label" for="typeName">Cardholder's Name</Label>
                                            </div>

                                            <div Class="form-outline form-white mb-4">
                                                <input type="text" id="typeText" Class="form-control form-control-lg" siez="17"
                                                       placeholder="1234 5678 9012 3457" minlength="19" maxlength="19" />
                                                <Label Class="form-label" for="typeText">Card Number</Label>
                                            </div>

                                            <div Class="row mb-4">
                                                <div Class="col-md-6">
                                                    <div Class="form-outline form-white">
                                                        <input type="text" id="typeExp" Class="form-control form-control-lg"
                                                               placeholder="MM/YYYY" size="7" id="exp" minlength="7" maxlength="7" />
                                                        <Label Class="form-label" for="typeExp">Expiration</Label>
                                                    </div>
                                                </div>
                                                <div Class="col-md-6">
                                                    <div Class="form-outline form-white">
                                                        <input type="password" id="typeText" Class="form-control form-control-lg"
                                                               placeholder="&#9679;&#9679;&#9679;" size="1" minlength="3" maxlength="3" />
                                                        <Label Class="form-label" for="typeText">Cvv</Label>
                                                    </div>
                                                </div>
                                            </div>

                                        </form>

                                        <hr Class="my-4">

                                        <div Class="d-flex justify-content-between">
                                            <p Class="mb-2">Subtotal</p>
                                            <p Class="mb-2">@SubTotal.ToString("0,0$")</p>
                                        </div>

                                        <div Class="d-flex justify-content-between">
                                            <p Class="mb-2">Shipping</p>
                                            <p Class="mb-2">@ShippingFee.ToString("0,0$")</p>
                                        </div>
                                        @Code
                                            Dim Total = SubTotal + ShippingFee
                                        End Code
                                        <div Class="d-flex justify-content-between mb-4">
                                            <p Class="mb-2">Total(Of Incl. taxes)</p>
                                            <p Class="mb-2">@Total.ToString("0,0$")</p>
                                        </div>
                                        @Using (Html.BeginForm("CreateOrder", "OrdersView"))
                                            @<Button type="button" Class="btn btn-info btn-block btn-lg">
                                                <div Class="d-block justify-content-between">

                                                    <button type="submit"><Span> Checkout <i Class="fas fa-long-arrow-alt-right ms-2"></i></Span></button>
                                                </div>
                                            </Button>
                                        End Using


                                    </div>
                                </div>

                            </div>

                        </div>

                    </div>
                </div>
            </div>
        </div>
    </div>
</section>
