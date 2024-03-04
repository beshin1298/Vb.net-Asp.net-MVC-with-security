@ModelType IEnumerable(Of WebMVCSecurity.product)
@Code
    ViewData("Title") = "About"
End Code

<main aria-labelledby="title">
    <h2 id="title">@ViewData("Title").</h2>
    <h3>@ViewData("Message")</h3>

    <div class="container mt-5">
        <h1 class="mb-4">Danh sách sản phẩm</h1>
        <div class="row">
            @For Each item In Model

                @<div Class="col-md-4 pb-5">
                    <div Class="card">
                        <img src="@item.image" Class="card-img-top" alt="Product 1" height="369">
                        <div Class="card-body">
                            <h5 Class="card-title">@item.name</h5>
                            <p Class="card-text">Phân loại: @item.category.name</p>
                            <p Class="card-text">Số lượng trong kho: @item.quantity</p>
                            <div class="form-row align-items-center d-flex gap-2">
                                <div class="col-auto">
                                    <a href='@Url.Action("Details", "Product", New With {.id = item.product_id})' Class="btn btn-primary">Xem chi tiết</a>
                                </div>

                                <div class="col-auto w-26">
                                    <input type="number" class="form-control" min="0" id="txtQuantity-@item.product_id" placeholder="Input quantity" required>
                                </div>
                                <div class="col-auto">
                                    <button Class="btn bg-warning" type="submit" onclick="addToCart(@item.product_id)"><i class="fa fa-cart-plus fa-lg" aria-hidden="true"></i></button>
                                </div>
                            </div>

                        </div>
                    </div>
                </div>

            Next

        </div>
    </div>

</main>
<script>
    function gettoken() {
        var token = '@Html.AntiForgeryToken()';
        token = $(token).val();
        return token;
   }
    function addToCart(id) {
        var token = gettoken();

        let quantity = document.getElementById("txtQuantity-" + id).value;
        var myHeaders = new Headers();

        var formdata = new FormData();
        formdata.append("product_id", id);
        formdata.append("quantity", quantity);
        formdata.append("__RequestVerificationToken", token);

        var requestOptions = {
            method: 'POST',
            headers: myHeaders,
            body: formdata,
            redirect: 'follow'
        };

        fetch("https://localhost:44304/CartViews/AddToCart", requestOptions)
            .then(response => response.text())
            .then(result => console.log(result))
            .catch(error => console.log('error', error));
    }



</script>
