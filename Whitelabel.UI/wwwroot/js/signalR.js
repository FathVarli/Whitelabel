const connection = new signalR.HubConnectionBuilder()
    .withUrl("/whiteLabelHub")
    .configureLogging(signalR.LogLevel.Information)
    .build();

connection.start().then(function () {
    connection.on("RefreshPage", function () {
        Swal.fire({
            title: 'Notice',
            text: 'Your design colors have been changed by your administrator. Click "Apply" button or refresh the page to get the changes.',
            showCancelButton: true,
            showConfirmButton: true,
            focusConfirm: false,
            focusCancel: false,
            confirmButtonText: 'Apply',
            
        }).then((result) => {
            if (result.isConfirmed) {
                    window.location.reload();
            }
        });
    });
}).catch(function (err) {
    console.error(err.toString());
});
