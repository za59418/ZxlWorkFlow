function formatDatebox(value) {
    var date = new Date(parseInt(value.replace("/Date(", "").replace(")/", ""), 10));

    var month = date.getMonth() + 1 < 10 ? "0" + (date.getMonth() + 1) : date.getMonth() + 1;

    var currentDate = date.getDate() < 10 ? "0" + date.getDate() : date.getDate();

    return date.getFullYear() + "-" + month + "-" + currentDate;
    return dt.format("yyyy-MM-dd"); //扩展的Date的format方法(上述插件实现)  
}

function DateFormat(date, format) {
    if (date == null) return "";
    date = date.replace('T', ' ');
    date = new Date(date);
    var map = {
        "M": date.getMonth() + 1, //月份
        "d": date.getDate(), //日
        "h": date.getHours(), //小时
        "m": date.getMinutes(), //分
        "s": date.getSeconds(), //秒
        "q": Math.floor((date.getMonth() + 3) / 3), //季度
        "S": date.getMilliseconds() //毫秒
    };
    format = format.replace(/([yMdhmsqS])+/g, function (all, t) {
        var v = map[t];
        if (v !== undefined) {
            if (all.length > 1) {
                v = '0' + v;
                v = v.substr(v.length - 2);
            }
            return v;
        }
        else if (t === 'y') {
            return (date.getFullYear() + '').substr(4 - all.length);
        }
        return all;
    });
    return format;
}