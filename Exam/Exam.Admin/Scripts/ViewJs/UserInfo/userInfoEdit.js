$(function () {
    $('#btnSave').click(function () {
        var id = $('#id'),
            imgInfoId = $('#imgInfoId'),
            oldImgInfoId = $('#oldImgInfoId'),
            group = $('#selGroups'),
            grade = $('#selGrades'),
            gender = $('#selGender'),
            name = $('#name'),
            mobile = $('#mobile');
            //contents = UE.getEditor('contents').getContent(),
            //sortNo = $('#sortNo');
        //校验
        if (id.val() <= 0 && (imgInfoId.val() == '' || imgInfoId.val() == null)) {
            swal("提示", "请上传资讯图片");
            return false;
        } 
        if (name.val() == null || name.val() == '') {
            name.focus();
            return false;
        }
        //重新上传图片时删除旧的图片
        if (imgInfoId.val() != null && imgInfoId.val() != '' && oldImgInfoId.val() != null && oldImgInfoId.val() != '' && imgInfoId.val() != oldImgInfoId.val()) {
            $.post("/Uploader/DeleteFile", { Id: oldImgInfoId.val() }, function (data) { });
        }
        var dataArr = {
            UserInfoId: id.val(),
            ImageInfoId: imgInfoId.val(),
            NikeName: name.val(),
            Phone: mobile.val(),
            Gender: gender.val(),
            SysGroupId: group.val(),
            GradeId: grade.val()
        };
        window.parent.showModal();
        //提交
        $.post('/UserInfo/Edit', dataArr, function (data) {
            if (data.Status == 200) {
                swal("提示", "操作成功");
                setTimeout(function () {
                    window.location.href = '/UserInfo/List?RefreshFlag=1';
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