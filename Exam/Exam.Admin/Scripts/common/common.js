//删除
var del = function (url, skipUrl, id) {
    swal({
        title: "您确定要删除这条信息吗",
        text: "删除后将无法恢复，请谨慎操作！",
        type: "warning",
        showCancelButton: true,
        confirmButtonColor: "#DD6B55",
        confirmButtonText: "是的，我要删除！",
        cancelButtonText: "让我再考虑一下…",
        closeOnConfirm: false,
        closeOnCancel: false
    }, function (isConfirm) {
        if (isConfirm) {
            window.parent.showModal();
            $.post(url, { Id: id }, function (data) {
                if (data.Status == 200) {
                    swal("删除成功！", "您已经永久删除了这条信息。", "success");
                    setTimeout(function () {
                        //window.location.href = skipUrl;
                        window.location.href = location.href;
                    }, 1500);
                } else {
                    swal("提示", "删除失败");
                }
            }).complete(function () { window.parent.hideModal(); });
        } else {
            swal("已取消", "您取消了删除操作！", "error");
        }
    });
};

//禁用
var disable = function (url, skipUrl, id, status) {
    swal({
        title: "您确定要禁用这条信息吗",
        text: "禁用后将无法使用，请谨慎操作！",
        type: "warning",
        showCancelButton: true,
        confirmButtonColor: "#DD6B55",
        confirmButtonText: "是的，我要禁用！",
        cancelButtonText: "让我再考虑一下…",
        closeOnConfirm: false,
        closeOnCancel: false
    }, function (isConfirm) {
        if (isConfirm) {
            window.parent.showModal();
            $.post(url, { Id: id, isEnabled: status }, function (data) {
                if (data.Status == 200) {
                    swal("禁用成功！", "您已经禁用了这条信息。", "success");
                    setTimeout(function () {
                        //window.location.href = skipUrl;
                        window.location.href = location.href;
                    }, 1500);
                } else {
                    swal("提示", "禁用失败");
                }
            }).complete(function () { window.parent.hideModal(); });
        } else {
            swal("已取消", "您取消了操作！", "error");
        }
    });
};

//启用
var enable = function (url, skipUrl, id, status) {
    swal({
        title: "您确定要启用这条信息吗",
        text: "请谨慎操作！",
        type: "warning",
        showCancelButton: true,
        confirmButtonColor: "#DD6B55",
        confirmButtonText: "是的，我要启用！",
        cancelButtonText: "让我再考虑一下…",
        closeOnConfirm: false,
        closeOnCancel: false
    }, function (isConfirm) {
        if (isConfirm) {
            window.parent.showModal();
            $.post(url, { Id: id, isEnabled: status }, function (data) {
                if (data.Status == 200) {
                    swal("启用成功！", "您已经启用了这条信息。", "success");
                    setTimeout(function () {
                        //window.location.href = skipUrl;
                        window.location.href = location.href;
                    }, 1500);
                } else {
                    swal("提示", "启用失败");
                }
            }).complete(function () { window.parent.hideModal(); });
        } else {
            swal("已取消", "您取消了操作！", "error");
        }
    });
};
 

//iframe弹窗
var iframe = function (title, url) {
    parent.layer.open({
        type: 2,
        title: title,
        shadeClose: true,
        shade: 0.8,
        area: ['80%', '70%'],
        content: url
    });
};

//初始化编辑器
var initEditor = function (a, b) {
    var editor = new baidu.editor.ui.Editor({
        UEDITOR_HOME_URL: '/Scripts/ueditor/',//配置编辑器路径
        iframeCssUrl: '/Scripts/ueditor/themes/iframe.css',//样式路径
        initialContent: a,//初始化编辑器内容
        autoHeightEnabled: true,//高度自动增长
        minFrameHeight: 720//最小高度
    });
    editor.render(b);
}

/* 公共操作处理 */

//解决IE9下非调试模式console报错问题
var console = console || { log: function () { return; } }

//验证不为空
function check_empty(val) {
    return val.length > 0
}
//验证正整数可以两位小数
function check_price(val) {
    var res = /^\d+(\.\d{1,2})?$/;
    return res.test(val);
}
//验证最大字符长度
function max(dom) {
    var max = parseInt($(dom).attr("max"));
    return $(dom).val().length > max;
}
//验证手机
function isPhone(str) {
    var reg = /^1[34578]\d{9}$/;
    return reg.test(str);
}

jQuery.myPlugin = {

    //正则表达式取url参数值
    getQueryStr: function (name) {
        var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)");
        var r = window.location.search.substr(1).match(reg);;
        if (r != null) return unescape(r[2]);
        return null;
    },

    //encode string
    htmlEncode: function (str) {
        var res = '';
        for (var i = 0; i < str.length; i++) {
            if (i == str.length - 1)
                res = res + str.charCodeAt(i);
            else
                res = res + str.charCodeAt(i) + "%";
        }
        return res;
    },

    //decode string
    htmlDecode: function (str) {
        var s = str.split("%");
        var res = '';
        for (var i = 0; i < s.length; i++)
            res = res + String.fromCharCode(s[i]);
        return res;
    },

    //验证是否手机号码
    isMobile: function (mobile) {
        var myreg = /^(1+\d{10})$/;
        return myreg.test(mobile);
    },

    // 日期格式化 开始
    // 对Date的扩展，将 Date 转化为指定格式的String
    // 月(M)、日(d)、小时(h)、分(m)、秒(s)、季度(q) 可以用 1-2 个占位符， 
    // 年(y)可以用 1-4 个占位符，毫秒(S)只能用 1 个占位符(是 1-3 位的数字) 
    // 例子： 
    // (new Date()).Format("yyyy-MM-dd hh:mm:ss.S") ==> 2006-07-02 08:09:04.423 
    // (new Date()).Format("yyyy-M-d h:m:s.S")      ==> 2006-7-2 8:9:4.18 
    format: function (fmt) { //author: meizz 
        var o = {
            "M+": this.getMonth() + 1, //月份 
            "d+": this.getDate(), //日 
            "h+": this.getHours(), //小时 
            "m+": this.getMinutes(), //分 
            "s+": this.getSeconds(), //秒 
            "q+": Math.floor((this.getMonth() + 3) / 3), //季度 
            "S": this.getMilliseconds() //毫秒 
        };
        if (/(y+)/.test(fmt)) fmt = fmt.replace(RegExp.$1, (this.getFullYear() + "").substr(4 - RegExp.$1.length));
        for (var k in o)
            if (new RegExp("(" + k + ")").test(fmt)) fmt = fmt.replace(RegExp.$1, (RegExp.$1.length == 1) ? (o[k]) : (("00" + o[k]).substr(("" + o[k]).length)));
        return fmt;
    },

    // 格式化json日期
    formatJsonDate: function (date) {
        if (!date) return "";
        return new Date(parseInt(date.substr(6))).format("yyyy-MM-dd hh:mm:ss");
    },

    hostPath: '',
    getPath: function () {
        if (jQuery.myPlugin.hostPath != '') {
            return jQuery.myPlugin.hostPath;
        }
        var host = "http://" + window.location.host;
        var end = host.charAt(host.length - 1);
        if (host != "/") host += "/";
        jQuery.myPlugin.hostPath = host;
        return host;
    }
};

//操作等待，遮罩效果（关闭）
function hideModal() {
    $('#myModal').modal('hide');
}
//操作等待，遮罩效果（开启）
function showModal() {
    $('#myModal').modal({ backdrop: 'static', keyboard: false });
}