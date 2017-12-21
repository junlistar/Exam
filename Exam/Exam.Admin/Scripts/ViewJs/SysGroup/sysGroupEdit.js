$(function () {
    $('#btnSave').click(function () {
        var id = $('#id'),
            name = $('#name'),
            type = $('#type'),
            sortNo = $('#sortNo');
        //数据校验
        if (name.val() == '' || name.val() == null) {
            name.focus();
            return false;
        }
        var dataArr = {
            SysGroupId: id.val(),
            Name: name.val(),
            Type: type.val(),
            SortNo: sortNo.val()
        };
        window.parent.showModal();
        //提交
        $.post('/SysGroup/Edit', dataArr, function (data) {
            if (data.Status == 200) {
                swal("提示", "操作成功");
                setTimeout(function () {
                    window.location.href = '/SysGroup/List';
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