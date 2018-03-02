$(function () {
    $('#btnSave').click(function () {
        var id = $('#id'),
            imgInfoId = $('#imgInfoId'),
            oldImgInfoId = $('#oldImgInfoId'),
            advertisementTypeId = $('#advertisementTypeId'),
            isTop = $('#divIsTop'),
            isHot = $('#divIsHot'),
            title = $('#title'),
            author = $('#author'), 
            contents = UE.getEditor('contents').getContent(),
            sortNo = $('#sortNo');
        //校验
        if (id.val() <= 0 && (imgInfoId.val() == '' || imgInfoId.val() == null)) {
            swal("提示", "请上传资讯图片");
            return false;
        }
        if (advertisementTypeId.val() <= 0) {
            swal("提示", "请选择资讯类型");
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
            NewsInfoId: id.val(),
            ImageInfoId: imgInfoId.val(),
            NewsCategoryId: advertisementTypeId.val(),
            Title: title.val(),
            Author: author.val(), 
            Content: contents,
            Sort: sortNo.val(),
            isTop: isTop.val(),
            isHot: isHot.val()
        };
        window.parent.showModal();
        //提交
        $.post('/NewsInfo/Edit', dataArr, function (data) {
            if (data.Status == 200) {
                swal("提示", "操作成功");
                setTimeout(function () {
                    window.location.href = '/NewsInfo/List';
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