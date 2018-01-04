$(function () {
    $('#btnSave').click(function () {
        var id = $('#id'),
            fid = $('#fid'),
            name = $('#name'),
            isCorrect = $('#isCorrect');
        //数据校验
        if (name.val() == '' || name.val() == null) {
            name.focus();
            return false;
        }
        var dataArr = {
            AnswerId: id.val(),
            Title: name.val(), 
            IsCorrect: isCorrect.val()
        };
        window.parent.showModal();
        //提交
        $.post('/Answer/Edit', dataArr, function (data) {
            if (data.Status == 200) {
                swal("提示", "操作成功");
                setTimeout(function () {
                    //history.go(-1);
                    //history.back();
                    window.location.href = "/Problem/AnswerList/" + fid.val();
                }, 1500);
            }
            if (data.Status == 202) {
                swal("提示", "操作失败");
            }
            if (data.Status == 203) {
                swal("提示", "数据重复");
            }
        }).complete(function () { window.parent.hideModal(); });
    });
});