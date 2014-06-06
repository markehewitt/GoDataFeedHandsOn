$(document).ready(function() {

});


function CallWebAPI() {
    //var uri = '/api/GDFApi/GetRetailer/3';
    //var uri = '/api/GDFApi/GetAllRetailers';
    //var uri = '/api/GDFApi/GetRetailerViaDapper/3';
    var uri = '/api/GDFApi/GetAllRetailersViaDapper';
    

    
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