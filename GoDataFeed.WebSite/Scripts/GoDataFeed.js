$(document).ready(function() {

});


function CallWebAPI() {
    //var uri = '/api/GDFApiRetail/GetRetailer/3';
    var uri = '/api/GDFApiRetail/GetViaEf/3';
    $.getJSON(uri).done(
        function (data) {
            debugger;
            alert('sucess calling ' + uri);
        }
        ).fail(
            function (jqXHR, textStatus, err) {
                debugger;
                alert(err);
            }
        );
}