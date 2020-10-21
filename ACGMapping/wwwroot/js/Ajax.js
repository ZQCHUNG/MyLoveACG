var DebugObj = "";
function Mutate(data, url) {
    var res = false;
    $.ajax({
        type: "GET",
        url: url,
        data: data,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: false,
        cache: false,
        success: function (result) {
            if (result.Result !== "Success") {
                alert(result.Message, "");
                return null;
            }

            res = true;
        },
        failure: function (response) {
            alert("操作時發生錯誤", "");
        }
    });

    return res;
}

function AjaxSearch(data, url) {
    var response;
    $.ajax({
        type: "GET",
        url: url,
        data: data,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: false,
        cache: false,
        success: function (result) {
            response = result;
        },
        error: function (response) {
            alert('查詢錯誤時發生錯誤', '');
        }
    });

    return response;
}