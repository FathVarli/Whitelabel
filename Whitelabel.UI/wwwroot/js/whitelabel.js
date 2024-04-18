async function handleOnClickTrigger() {
    $.ajax({
        url: '/whitelabel/create',
        type: 'POST',
        success: function(result) {
            if (result.isSuccess) {
            }else {
               
            }
        }
    });
}

async function handleOnClickReset() {
    $.ajax({
        url: '/whitelabel/reset',
        type: 'POST',
        success: function(result) {
            if (result.isSuccess) {
            }else {

            }
        }
    });
}