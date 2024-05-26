$(function () {


    $(document).on("click", "#products .add-basket", function () {
        let id = parseInt($(this).attr("data-id"));

        $.ajax({
            type: "POST",
            url: `home/AddProductToBasket?id=${id}`,
            success: function (response) {
                $(".rounded-circle").text(response.count)
                $(".rounded-circle").next().text(`CART($${response.totalPrice})`)
            }
        })
    })


    $(document).on("click", "#cart-page .fa-trash-alt", function () {
        let id = parseInt($(this).attr("data-id"));

        $.ajax({
            type: "POST",
            url: `home/DeleteProductFromBasket?id=${id}`,
            success: function (response) {
                $(".rounded-circle").text(response.count);
                $(".rounded-circle").next().text(`CART($${response.totalPrice})`);
                $(".cart - total").text(`$${response.totalPrice}`);
                $(".total-basketCount").text(`You have ${response.basketCount} items in your cart`);
                $(`[data-id=${id}]`).closest(".card").remove();
            }
        })
    })
})
