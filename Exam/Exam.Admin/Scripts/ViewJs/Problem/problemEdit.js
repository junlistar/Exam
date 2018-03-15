$(function () {
    $('#btnSave').click(function () {
        var id = $('#id'),
            name = $('#name'),
            problemCategory = $('#problemCategoryId'),
            belongId = $('#belongId'),
            chapterId = $('#chapterId'),
            subjectInfoId = $('#subjectInfoId'),
            isHot = $('#divIsHot'),
            sortNo = $('#sortNo');
        //数据校验
        if (name.val() == '' || name.val() == null) {
            name.focus();
            return false;
        }
        var dataArr = {
            ProblemId: id.val(),
            Title: name.val(),
            ProblemCategoryId: problemCategory.val(),
            BelongId: belongId.val(),
            ChapterId: chapterId.val(),
            SubjectInfoId: subjectInfoId.val(),
            IsHot: isHot.val(),
            Sort: sortNo.val()
        };
        window.parent.showModal();
        //提交
        $.post('/Problem/Edit', dataArr, function (data) {
            if (data.Status == 200) {
                swal("提示", "操作成功");
                setTimeout(function () {
                    window.location.href = '/Problem/List?RefreshFlag=1';
                    //history.go(-1);
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