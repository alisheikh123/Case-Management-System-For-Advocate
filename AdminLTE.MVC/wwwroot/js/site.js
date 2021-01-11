// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.



// Write your JavaScript code.
$(document).ready(function () {
    $('input').blur(function () {
        if ($(this).val() == 0)
        {
            $('#Alert').show();
        }
    });
    $(".fileno").keyup(function () {

        var value = $(".fileno").val();

        $.ajax({
            type: "POST",
            url: "/tblCases/fileexist",
            data: { fileno: value },
            dataType: "json",
            success: function (result) {
                alert("This File Already Exist!");
            }
        });


    })

});


 
 

