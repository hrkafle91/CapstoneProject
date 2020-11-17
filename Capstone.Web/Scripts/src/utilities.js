function LogOut() {
    alert('Logging Out...')
    $.ajax({
        type: 'POST',
        url: '/LoginAccount/LogOut',
        contentType: 'application/json',
        success: function (data) {
            if (data == true) {
                window.location.href = '/LoginAccount/Index';
            }
        }
    });
}