$(function(){
    console.log("jQuery on");
    var petName = prompt("Welcome to Dachi Pet! Please name your Dachi!");
    console.log(petName);
    $.get("/setName/" + petName, function(response){
        console.log("changed pet name");
    })
    $('#game-start a').click(function(event){
        event.preventDefault();
        var choice = event.target.id;
        var rightNow = new Date();
        $.get("/process/" + choice, function(response){
            console.log(response);
            $("#fullness span").html(response.fullness);
            $("#happiness span").html(response.happiness);
            $("#meals span").html(response.meals);
            $("#energy span").html(response.energy);
            $("#status p").html(response.status);
            if(response.emotion == "sad"){
                $("#sad").css("display", "block");
                $("#happy").css("display", "none");
            }
            else{
                $("#happy").css("display", "block");
                $("#sad").css("display", "none");
            }
            if(response.alive == false){
                $("#game-start").css("display", "none");
                $("#game-over").css("display", "block");
                $("#sad").css("display", "none");
                $("#happy").css("display", "none");
                $("#dead").css("display", "block");
            }
            if(response.status.includes("WON")){
                $("#game-start").css("display", "none");
                $("#game-over").css("display", "block");
                $("#sad").css("display", "none");
                $("#happy").css("display", "block");
                $("#dead").css("display", "none");
            }
        })
    })

    var modal = document.getElementById("my-modal");
    // var button = document.getElementById("modal-button");
    // var span = document.getElementsByClassName("close")[0];

    // button.onclick = function(){
    //     modal.style.display = "block";
    // }
    $("#modal-button").click(function(){
        $(modal).css("display", "block");
    })

    // span.onclick = function(){
    //     modal.style.display = "none";
    // }
    $(".close").click(function(){
        $(modal).css("display", "none");
    })

    // window.onclick = function(event){
    //     if(event.target == modal){
    //         modal.style.display = "none";
    //     }
    // }
    $(window).click(function(event){
        if(event.target == modal){
            $(modal).css("display", "none");
        }
    })
})