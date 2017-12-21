$(function () {
    $('#btnSave').click(function () {
        var id = $('#id'),
            fId = $('#fId'),
            name = $('#name'),
            url = $('#url'),
            icon = $('#icon'),
            sortNo = $('#sortNo'),
            type = $('#type'),
            v = $('#v').val(),
            path = '/SysMenu/List';

        if (v == 1) {
            path = '/SysMenu/ChildList/' + fId.val();
        }
        //数据校验
        if (name.val() == '' || name.val() == null) {
            name.focus();
            return false;
        }
        if (type.val() <= 0) {
            swal("提示", "请选择菜单类型");
            return false;
        }
        var dataArr = {
            SysMenuId: id.val(),
            FId: fId.val(),
            Name: name.val(),
            Url: url.val(),
            Icon: icon.val(),
            SortNo: sortNo.val(),
            Type: type.val()
        };
        window.parent.showModal();
        //提交
        $.post('/SysMenu/Edit', dataArr, function (data) {
            if (data.Status == 200) {
                swal("提示", "操作成功");
                setTimeout(function () {
                    window.location.href = path;
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