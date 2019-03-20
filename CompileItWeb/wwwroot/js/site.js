// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
let vndrServerUrl = "http://localhost:51009/";

$(document).ready(function () {

    let ajaxURL = vndrServerUrl + "api/player";

    $.ajax({
        url: ajaxURL,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        type: "POST",
        data: JSON.stringify({
        name: "chris"
        })
    }).done(function (data) {
        console.log("added player");
    }).fail(function (xhr, status, error) {
        console.log(error);
    });
}); 

//$.ajax({
//    url: ajaxURL,
//    type: "POST",
//    contentType: "application/json; charset=utf-8",
//    dataType: "json",
//    data: JSON.stringify({
//        name: "Chris"
//    })
//}).done(function (data) {
//    console.log("added player");
//}).fail(function (xhr, status, error) {
//    console.log(error);
//});

//function sendMoney(amt) {
//    $.ajax({
//        url: vndrServerUrl + "api/feedmoney",
//        type: "POST",
//        data: {
//            amount: amt
//        }
//    }).done(function (response) {
//        getBalance();
//        feedMessage(amt, response.status);
//        getInventory();
//    });
//}
