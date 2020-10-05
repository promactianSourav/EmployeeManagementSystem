//import { signalR } from "./signalr/dist/browser/signalr";

//import { signalR } from "./signalr/dist/browser/signalr";

//signalR = require('./signalr/dist/browser/signalr');
$('[data-toggle="popover"]').popover({
    placement: "bottom",
    content: function () {
        return $("#notification-content").html();
    },
    html: true
});

$("body").append('<div id="notification-content" class="hide" hidden></div>');
$("#notification-content").append('<ul id="list" class="list-group"></ul>');
//function getNotification() {
//    //var res = "<ul class='list-group' id=''>";
//    $.ajax({
//        url: "/Notification/GetNotification",
//        method: "GET",
//        success: function (result) {
//            if (result.count != 0) {
//                $("#notificationCount").html(result.count);
//                $("#notificationCount").show("slow");
//            } else {
//                $("#notificationCount").html();
//                $("#notificationCount").hide("slow");
//                $("#notificationCount").popover("hide");
//            }
            
 
//            var notifications = result.notificationUser;
//            $.each(notifications, function (index, element) {
//                $("#list").append('<li class="list-group-item notification-text" id=' + element.id + '>' + element.text + '</li>');
//                //res = res + "<li data-id='";
//                //res = res + element.id;
//                //res = res + "' class='list-group-item notification-text'>" + element.text + "</li>";
//            });
           

//            //res = res + "</ul>";
 
//            //$("#notification-content").html(res);
//            console.log(result);

//        },
//        error: function (error) {
//            console.log(error);
//        }
//    });
//    }

//$(document).on("click", "li.notification-text", function (e) {
//    var target = e.target;
//    var id = $(target).attr("id");
//    console.log(id);
   
//    readNotification(id,target);
//});



//function readNotification(id,target) {

//    $.ajax({
//        url: "/Notification/ReadNotification",
//        method: "GET",
//        data: { NotificationId: id },
//        success: function (result) {
//            getNotification();
//            $(target).fadeOut("slow");
//        },
//        error: function (error) {
//            console.log(error);
//        }
//    });
//}

//getNotification();
////let con = new signalR.HubConnection("/signalServer");
////let connection = new signalR.HubConnection("/signalServer");
////let con = new signalR.HubConnection("/signalServer");
//const connection = new signalR.HubConnectionBuilder()
//    .withUrl("/signalServer")
//    .configureLogging(signalR.LogLevel.Information)
//    .build();

//connection.on("displayNotification", () => {
//    getNotification();
//});

//connection.start();


