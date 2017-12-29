$(function () {
    $('#btnSave').click(function () {
        var id = $('#id'),
            imgInfoId = $('#imgInfoId'),
            oldImgInfoId = $('#oldImgInfoId'), 
            title = $('#title'),
            position = $('#position'),
            abstracts = $('#abstracts'),
            contents = UE.getEditor('contents').getContent(),
            sortNo = $('#sortNo');
        //校验
        if (id.val() <= 0 && (imgInfoId.val() == '' || imgInfoId.val() == null)) {
            swal("提示", "请上传资讯图片");
            return false;
        } 
        if (title.val() == null || title.val() == '') {
            title.focus();
            return false;
        }
        //重新上传图片时删除旧的图片
        if (imgInfoId.val() != null && imgInfoId.val() != '' && oldImgInfoId.val() != null && oldImgInfoId.val() != '' && imgInfoId.val() != oldImgInfoId.val()) {
            $.post("/Uploader/DeleteFile", { Id: oldImgInfoId.val() }, function (data) { });
        }
        var dataArr = {
            LecturerId: id.val(),
            ImageInfoId: imgInfoId.val(),
            Name: title.val(),
            Position: position.val(),
            Abstracts: abstracts.val(),
            Introduce: contents,
            Sort: sortNo.val()
        };
        window.parent.showModal();
        //提交
        $.post('/Lecturer/Edit', dataArr, function (data) {
            if (data.Status == 200) {
                swal("提示", "操作成功");
                setTimeout(function () {
                    window.location.href = '/Lecturer/List';
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