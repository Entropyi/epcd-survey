
const next = document.getElementById("next");
const back = document.getElementById("before");

const section1Container = document.getElementById("section1Container");
const question1Container = document.getElementById("Question1");
const question2Container = document.getElementById("Question2");
const question3Container = document.getElementById("Question3");

const section2Container = document.getElementById("section2Container");
const question4Container = document.getElementById("Question4");
const question5Container = document.getElementById("Question5");
const question6Container = document.getElementById("Question6");
const question7Container = document.getElementById("Question7");
const question8Container = document.getElementById("Question8");
const question9Container = document.getElementById("Question9");
const question10Container = document.getElementById("Question10");
const question11Container = document.getElementById("Question11");
const question12Container = document.getElementById("Question12");
const question13Container = document.getElementById("Question13");

const section3Container = document.getElementById("section3Container");
const question14Container = document.getElementById("Question14");


const Question11length = "@question11".length;
const Question12length = "@question11".length;
const Question13length = "@question11".length;

const locale = document.getElementById("locale");


let AgeGroup = document.querySelectorAll('input[name = "AgeGroup"]')
let Sex = document.querySelectorAll('input[name = "Sex"]')
let Education = document.querySelectorAll('input[name = "Education"]')
let Scale1 = document.querySelectorAll('input[name = "Scale1"]')
let Scale2 = document.querySelectorAll('input[name = "Scale2"]')
let Scale3 = document.querySelectorAll('input[name = "Scale3"]')
let Scale4 = document.querySelectorAll('input[name = "Scale4"]')
let Scale5 = document.querySelectorAll('input[name = "Scale5"]')
let Scale6 = document.querySelectorAll('input[name = "Scale6"]')
let Scale7 = document.querySelectorAll('input[name = "Scale7"]')
let Scale8 = document.querySelectorAll('input[name = "Scale8"]')
let Scale9 = document.querySelectorAll('input[name = "Scale9"]')
let Scale10 = document.querySelectorAll('input[name = "Scale10"]')

section1Container.style.display = "flex"
question1Container.style.display = "flex"


let count = 1;

(function () {
    AgeGroup.forEach(button => {
        button.addEventListener("input", () => {
            nextButtonStatus();
        }, {once: true});
    });
})();

(function () {
    Sex.forEach(button => {
        button.addEventListener("input", () => {
            nextButtonStatus();
        }, {once: true});
    });
})();


(function () {
    Education.forEach(button => {
        button.addEventListener("input", () => {
            nextButtonStatus();
        }, {once: true});
    });
})();


(function () {
    Scale1.forEach(button => {
        button.addEventListener("input", () => {
            nextButtonStatus();
        }, {once: true});
    });
})();


(function () {
    Scale2.forEach(button => {
        button.addEventListener("input", () => {
            nextButtonStatus();
        }, {once: true});
    });
})();


(function () {
    Scale3.forEach(button => {
        button.addEventListener("input", () => {
            nextButtonStatus();
        }, {once: true});
    });
})();


(function () {
    Scale4.forEach(button => {
        button.addEventListener("input", () => {
            nextButtonStatus();
        }, {once: true});
    });
})();


(function () {
    Scale5.forEach(button => {
        button.addEventListener("input", () => {
            nextButtonStatus();
        }, {once: true});
    });
})();


(function () {
    Scale6.forEach(button => {
        button.addEventListener("input", () => {
            nextButtonStatus();
        }, {once: true});
    });
})();


(function () {
    Scale7.forEach(button => {
        button.addEventListener("input", () => {
            nextButtonStatus();
        }, {once: true});
    });
})();


(function () {
    Scale8.forEach(button => {
        button.addEventListener("input", () => {
            nextButtonStatus();
        }, {once: true});
    });
})();

(function () {
    Scale10.forEach(button => {
        button.addEventListener("input", () => {
            nextButtonStatus();
        }, {once: true});
    });
})();


next.addEventListener("click", () => {
    checkChecker(count)
    //&& checkChecker(count)
    console.log(count)

    if (count < 14 ) {
        changeContainerDisplay(count, "none");
        count++;
        next.classList.replace("form2__next", "before-disabled")
        changeContainerDisplay(count, "flex");

        backButtonStatus(count);
        console.log(`inside count${count}`)

    }



})


back.addEventListener("click", () => {
    if(count != 0 && count < 11) {
        next.classList.replace("before-disabled", "form2__next")
        changeContainerDisplay(count, "none");
        count--;
        changeContainerDisplay(count, "flex");
        backButtonStatus(count);
    } else {
        if(count >= 11) {
            let oldCount = count ;
            count--;
            if (Question13length <= 0 && count == 13){
                count--;
                if(Question12length <= 0 && count == 12){
                    count--;
                    if(Question11length <= 0 && count == 11){
                        count--;
                        next.classList.replace("before-disabled", "form2__next")
                        changeContainerDisplay(oldCount, "none");
                        changeContainerDisplay(count, "flex");
                        backButtonStatus(count);
                    } else {
                        next.classList.replace("before-disabled", "form2__next")
                        changeContainerDisplay(oldCount, "none");
                        changeContainerDisplay(count, "flex");
                        backButtonStatus(count);
                    }
                } else {
                    next.classList.replace("before-disabled", "form2__next")
                    changeContainerDisplay(oldCount, "none");
                    changeContainerDisplay(count, "flex");
                    backButtonStatus(count);
                }
            } else {
                next.classList.replace("before-disabled", "form2__next")
                changeContainerDisplay(oldCount, "none");
                changeContainerDisplay(count, "flex");
                backButtonStatus(count);
            }
            
        }
    }
})


const backEvent = () => {
    next.classList.replace("before-disabled", "form2__next")
    changeContainerDisplay(count, "none");
    count--;
    changeContainerDisplay(count, "flex");
    backButtonStatus(count);
}


const checkChecker = (questionNumber) => {
    switch (questionNumber) {
        case 1:
            let ageGroup = document.querySelector('input[name = "AgeGroup"]:checked')
            return checkForNullRadioList(ageGroup);
            break;
        case 2:
            let sex = document.querySelector('input[name = "Sex"]:checked')
            return checkForNullRadioList(sex);
            break;
        case 3:
            let education = document.querySelector('input[name = "Education"]:checked')
            return checkForNullRadioList(education);
            break;
        case 4:
            let scale1 = document.querySelector('input[name = "Scale1"]:checked')
            return checkForNullRadioList(scale1);
            break;
        case 5:
            let scale2 = document.querySelector('input[name = "Scale2"]:checked')
            return checkForNullRadioList(scale2);
            break;
        case 6:
            let scale3 = document.querySelector('input[name = "Scale3"]:checked')
            return checkForNullRadioList(scale3);
            break;
        case 7:
            let scale4 = document.querySelector('input[name = "Scale4"]:checked')
            return checkForNullRadioList(scale4);
            break;
        case 8:
            let scale5 = document.querySelector('input[name = "Scale5"]:checked')
            return checkForNullRadioList(scale5);
            break;
        case 9:
            let scale6 = document.querySelector('input[name = "Scale6"]:checked')
            return checkForNullRadioList(scale6);
            break;
        case 10:
            let scale7 = document.querySelector('input[name = "Scale7"]:checked')
            return checkForNullRadioList(scale7);
            break;
        case 11:
            let scale8 = document.querySelector('input[name = "Scale8"]:checked')
            return checkForNullRadioList(scale8);
            break;
        case 12:
            let scale9 = document.querySelector('input[name = "Scale9"]:checked')
            return checkForNullRadioList(scale9);
            break;
        case 13:
            let scale10 = document.querySelector('input[name = "Scale10"]:checked')
            return checkForNullRadioList(scale10);
            break;
    }
}

const backButtonStatus = (count) => {
    if (count > 1) {
        back.classList.replace("before-disabled", "form2__before")
        back.disabled = false;

    } else {
        back.classList.replace("form2__before", "before-disabled")
        back.disabled = true;


    }
}

const nextButtonStatus = () => {
    next.classList.replace("before-disabled", "form2__next")
    next.disabled = false;
}


const changeContainerDisplay = (number, display) => {

    if (number <= 3) {
        section1Container.style.display = "flex"
        section2Container.style.display = "none"
        section3Container.style.display = "none"
    } else if (number <= 13) {
        section1Container.style.display = "none"
        section2Container.style.display = "flex"
        section3Container.style.display = "none"
    } else {
        section1Container.style.display = "none"
        section2Container.style.display = "none"
        section3Container.style.display = "flex"
    }

    switch (number) {
        case 1:
            question1Container.style.display = display;
            break;
        case 2:
            question2Container.style.display = display;
            break;
        case 3:
            question3Container.style.display = display;
            break;
        case 4:
            question4Container.style.display = display;
            break;
        case 5:
            question5Container.style.display = display;
            break;
        case 6:
            question6Container.style.display = display;
            break;
        case 7:
            question7Container.style.display = display;
            break;
        case 8:
            question8Container.style.display = display;
            break;
        case 9:
            question9Container.style.display = display;
            break;
        case 10:
            question10Container.style.display = display;
            break;
        case 11:
            if (Question11length > 0) {
                question11Container.style.display = display;
            } else {
                count++;
                changeContainerDisplay(count, "flex")

            }
            break;
        case 12:
            if (Question12length > 0) {
                question12Container.style.display = display;
                return;
                break;
            } else {
                number++;
                count++;
                changeContainerDisplay(count, "flex")
            }
            break;
        case 13:
            if (Question13length > 0) {
                question13Container.style.display = display;
                return;
                break;
            } else {
                number++;
                count++;
                changeContainerDisplay(count, "flex")
            }
            break;

        case 14:
            question14Container.style.display = display;
            return;
            break;


    }
}

const checkForNull = (string) => {
    if (!string || string.length <= 0) {
        return "none";
    }
    return "flex";
}

const checkForNullRadioList = (list) => {
    if (list) {
        return true;
    } else {
        return false;
    }

}