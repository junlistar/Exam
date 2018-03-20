$(function () {
    $('#btnSave').click(function () {
        var id = $('#id'),
            title = $('#title'),
            sortNo = $('#sortNo');
        //校验
        
        if (title.val() == null || title.val() == '') {
            title.focus();
            return false;
        } 
        var dataArr = {
            VideoClassId: id.val(),
            Title: title.val(),
            Sort: sortNo.val(),
        };
        window.parent.showModal();
        //提交
        $.post('/VideoClass/Edit', dataArr, function (data) {
            if (data.Status == 200) {
                swal("提示", "操作成功");
                setTimeout(function () {
                    window.location.href = '/VideoClass/List';
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