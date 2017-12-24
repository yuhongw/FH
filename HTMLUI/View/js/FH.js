//同步请求
function getText(txtUrl) {
    var html = $.ajax({
        url: txtUrl,
        async: false,
        dataType: 'TEXT'
    }).responseText;
    return html;
}

function LoadTxt(txtUrl) {
    $.ajax({
        url: txtUrl,
        type: 'GET',
        dataType: 'TEXT',
        success: function (data) {
            alert(data);
        },
        error: function (req, text, error) {
            alert(error);
        }
    });
}