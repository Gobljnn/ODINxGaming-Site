const myInfo = new Object();
const myInstructor = new Object();
const myCourse = new Object();

function clearStorage() {
    localStorage.clear();
}


function setInfo(id, firstNames, lastNames, email, phoneNum, course) {

    myStudent.id = id;
    myStudent.fname = firstNames;
    myStudent.lastName = lastNames;
    myStudent.email = email;
    myStudent.phoneNum = phoneNum;
    myStudent.course = course;

    //window.onload

    localStorage.setItem("studentID", id);
    localStorage.setItem("studentFname", firstNames);
    localStorage.setItem("studentLname", lastNames);
    localStorage.setItem("studentEmail", email);
    localStorage.setItem("studentPhoneNum", phoneNum);
    localStorage.setItem("studentCourse", course);


    console.log(myStudent);
}

function getStudents() {
    id = localStorage.getItem("studentID");
    firstName = localStorage.getItem("studentFname");
    lastName = localStorage.getItem("studentLname");
    email = localStorage.getItem("studentEmail");
    phoneNum = localStorage.getItem("studentPhoneNum");
    course = localStorage.getItem("studentCourse");

    console.log("local storage my id: " + phoneNum)
    //using $ sign to access jQuery library
}

function setInstructors(id, firstNames, lastNames, email, course) {

    myInstructor.id = id;
    myInstructor.fname = firstNames;
    myInstructor.lastName = lastNames;
    myInstructor.email = email;
    myInstructor.course = course;

    localStorage.setItem("instructorID", id);
    localStorage.setItem("instructorFname", firstNames);
    localStorage.setItem("instructorLname", lastNames);
    localStorage.setItem("instructorEmail", email);
    localStorage.setItem("instructorCourse", course);


    console.log(myInstructor);
}

function getInstructors() {
    id = localStorage.getItem("instructorID");
    firstName = localStorage.getItem("instructorFname");
    lastName = localStorage.getItem("instructorLname");
    email = localStorage.getItem("instructorEmail");
    course = localStorage.getItem("instructorCourse");

    console.log("local storage my id: " + phoneNum)
    //using $ sign to access jQuery library
}

function setCourses(id, courseNames, courseDescs) {

    myCourse.id = id;
    myCourse.name = courseNames;
    myCourse.desc = courseDescs;

    localStorage.setItem("courseID", id);
    localStorage.setItem("courseName", courseNames);
    localStorage.setItem("courseDesc", courseDescs);

    console.log(myCourse);
}

function getCourses() {

    id = localStorage.getItem("courseID");
    courseName = localStorage.getItem("courseName");
    courseDesc = localStorage.getItem("courseDesc");

    localStorage.setItem("courseID", id);
    localStorage.setItem("courseName", courseName);
    localStorage.setItem("courseDesc", courseDesc);

    console.log(myCourse);
}