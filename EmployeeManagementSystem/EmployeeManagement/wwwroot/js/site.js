
function getNotification() {
    $.ajax({
        url: "/Notification/getNofication",
        method: "GET",
        success: function (result) {
            $("notificationCount").html(result.Count);
            console.log(result);
        },
        error: function (error) {
            console.log(error);
        }
    });
    }

    getNotification();

