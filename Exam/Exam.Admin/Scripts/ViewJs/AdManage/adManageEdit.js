$(function () {
    $('#btnSave').click(function () {
        var id = $('#id'),
            imgInfoId = $('#imgInfoId'),
            oldImgInfoId = $('#oldImgInfoId'),
            name = $('#name'),
            typeId = $('#selTypeId'),
            sortNo = $('#sortNo');
        //数据校验 
        if (id.val() <= 0 && (imgInfoId.val() == '' || imgInfoId.val() == null)) {
            swal("提示", "请上传资讯图片");
            return false;
        }
        if (name.val() == '' || name.val() == null) {
            name.focus();
            return false;
        }

        //重新上传图片时删除旧的图片
        if (imgInfoId.val() != null && imgInfoId.val() != '' && oldImgInfoId.val() != null && oldImgInfoId.val() != '' && imgInfoId.val() != oldImgInfoId.val()) {
            $.post("/Uploader/DeleteFile", { Id: oldImgInfoId.val() }, function (data) { });
        }
        var dataArr = {
            AdvertisementId: id.val(),
            ImageInfoId: imgInfoId.val(),
            Title: name.val(),
            TypeId: typeId.val(),
            Sort: sortNo.val()
        };
        window.parent.showModal();
        //提交
        $.post('/AdManage/Edit', dataArr, function (data) {
            if (data.Status == 200) {
                swal("提示", "操作成功");
                setTimeout(function () {
                    window.location.href = '/AdManage/List';
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