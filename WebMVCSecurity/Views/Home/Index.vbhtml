@Code
    ViewData("Title") = "Home Page"
End Code
@ModelType IEnumerable(Of WebMVCSecurity.news)
<main>
    <section class="row" aria-labelledby="aspnetTitle">
        <h1 id="title">FANATIC COMPUTERS</h1>

    </section>
    <div class="grid-container">
        @For i As Integer = 0 To Model.Count - 1
            @<div Class="grid-item item_@i">
                <img src="@Model(i).imageTitle" style="width:100%; height:100%" class="image" />
                <a href="@Url.Action("Details", "News", New With {.id = Model(i).id})" style="text-decoration:none; color:black">
                    <h2>@Model(i).title</h2>
                </a>

            </div>
        Next
    </div>

</main>
<Style>
    .grid-container {
        height: 500px;
        width: 500px;
        display: flex;
        flex-direction: column;
        justify-content: space-between;
        flex-wrap: wrap;
        gap: 3%
    }
</Style>
