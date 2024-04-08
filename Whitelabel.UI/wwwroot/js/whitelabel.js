async function handleOnClickTrigger() {
    $.ajax({
        url: '/whitelabel/create',
        type: 'POST',
        success: function(result) {4
            debugger;
            if (result.isSuccess) {
                connection.invoke("RefreshPage").catch(function (err) {
                    console.error(err.toString());
                });
            }else {
               
            }
        }
    });
}

async function handleOnClickReset() {
    $.ajax({
        url: '/whitelabel/reset',
        type: 'POST',
        success: function(result) {4
            debugger;
            if (result.isSuccess) {
                connection.invoke("RefreshPage").catch(function (err) {
                    console.error(err.toString());
                });
            }else {

            }
        }
    });
}