$(function () {
    $('#btnSave').click(function () {
        var id = $('#id'),
            name = $('#name'),
            sortNo = $('#sortNo');

        //数据校验
        if (name.val() == '' || name.val() == null) {
            name.focus();
            return false;
        } 
        var dataArr = {
            NewsCategoryId: id.val(),
            Title: name.val(),
            Sort: sortNo.val()
        };
        window.parent.showModal();
        //提交
        $.post('/NewsCategory/Edit', dataArr, function (data) {
            if (data.Status == 200) {
                swal("提示", "操作成功");
                setTimeout(function () {
                    window.location.href = '/NewsCategory/List';;
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