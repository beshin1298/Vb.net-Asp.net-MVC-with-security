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
                            <a href="#" Class="btn btn-primary">Xem chi tiết</a>
                        </div>
                    </div>
                </div>
            Next
            
        </div>
    </div>

</main>
