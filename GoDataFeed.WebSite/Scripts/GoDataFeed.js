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

    $.ajax({
        type: "POST",
        url: Person.SaveUrl,
        data: ko.toJSON(Person.ViewModel),
        contentType: 'application/json',
        async: true,
        success: function (result) {
            // Handle the response here.
        },
        error: function (jqXHR, textStatus, errorThrown) {
            // Handle error.
        }
    });
}
