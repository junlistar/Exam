document.onkeydown = function (event) {
    ee = event ? event : (window.event ? window.event : null);
    if (ee.keyCode == 13) {
        document.getElementById("btnLogin").click();
    }
}
if (window.top !== window.self) {
    window.top.location = window.location;
}
$(function () {
    var _account = $('#account'),
        _password = $('#password');
    _account.focus();
    $('#btnLogin').click(function () {
        if (_account.val() == '' || _account.val() == null) {
            _account.focus();
            return false;
        }
        if (_password.val() == '' || _password.val() == null) {
            _password.focus();
            return false;
        }

        $.ajax({
            type: "post",
            url: "/Login/Login",
            data: {
                Account: _account.val().trim(), Password: _password.val().trim()
            },
            dataType: "json",
            success: function (data) {
                if (data.Status === 1) {
                   
                    setTimeout(function () {
                        window.location.href = '/Home/Index';
                    }, 1000);
                }
                if (data.Status === -1) {
                    swal("提示", "账号或密码错误");
                }
                if (data.Status === -2) {
                    swal("提示", "账号已被禁用");
                }
            }
        });
    });
});