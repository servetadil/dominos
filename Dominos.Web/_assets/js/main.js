var ShoppingCart = {

    showLoading: function () {
        $("#ajax-container").show();
    },
    hideLoading: function () {
        $("#ajax-container").hide();
    },
    addToBasket: function (productId, quantity, callback) {
        var self = this;
        $.ajax({
            url: '/ShoppingCart/AddToBasket',
            method: 'POST',
            data: { ProductId: productId, Quantity: quantity },
            success: callback,
            beforeSend: function () {
                self.showLoading();
            },
            complete: function () {
                self.hideLoading();
            }
        });
    },

    setQuantity: function(shoppingCartItemId, quantity, callback)
    {
        var self = this;
        $.ajax({
            url: '/ShoppingCart/SetQuantitiy',
            method: 'POST',
            data: { ShoppingCartItemId: shoppingCartItemId, Quantity: quantity },
            success: callback,
            beforeSend: function () {
                self.showLoading();
            },
            complete: function () {
                self.hideLoading();
            }
        });
    },
}


