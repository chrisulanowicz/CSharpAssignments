$(function(){
    console.log("jQuery is up and running");

    $('#ajax').click(function(event){
        event.preventDefault();
        $.get("/ajax", function(response){
            $('#attempt').html(response.attempt);
            $('#code').html(response.passcode);
        })
    })
})
