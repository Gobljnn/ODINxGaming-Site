const myInfo = new Object();


function clearStorage() {
    localStorage.clear();
}


function setInfo(id) {

    myInfo.id = id;
   

    //window.onload

    localStorage.setItem("ID", id);


    console.log(myInfo);
}

function getInfo() {
    id = localStorage.getItem("ID");
    console.log("local storage my id: " + id)
    //using $ sign to access jQuery library
}


