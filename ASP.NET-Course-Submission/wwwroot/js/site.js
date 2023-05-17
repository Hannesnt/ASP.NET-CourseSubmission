const toggleMenuButton = (attribute) => {
    const btn = document.querySelector(attribute)

    btn.addEventListener('click', function () {
        const element = document.querySelector(btn.getAttribute('data-target'))
        const contains = element.classList.contains('open-menu')

        element.classList.toggle('open-menu', !contains)
        btn.classList.toggle('btn-outline-dark', !contains)
        btn.classList.toggle('btn-toggle-white', !contains)
    })
}


const pswValidation = () => {
    const myInput = document.getElementById("psw");
    const letter = document.getElementById("letter");
    const capital = document.getElementById("specialchar");
    const number = document.getElementById("number");
    const length = document.getElementById("length");


    myInput.onfocus = function () {
        document.getElementById("message").style.display = "block";
    }

    myInput.onblur = function () {
        document.getElementById("message").style.display = "none";
    }


    myInput.onkeyup = function () {

        const lowerCaseLetters = /[a-z]/g;
        if (myInput.value.match(lowerCaseLetters)) {
            letter.classList.remove("invalid");
            letter.classList.add("valid");
        } else {
            letter.classList.remove("valid");
            letter.classList.add("invalid");
        }

        const upperCaseLetters = /[@$!%*#?&]/g;
        if (myInput.value.match(upperCaseLetters)) {
            capital.classList.remove("invalid");
            capital.classList.add("valid");
        } else {
            capital.classList.remove("valid");
            capital.classList.add("invalid");
        }

        const numbers = /[0-9]/g;
        if (myInput.value.match(numbers)) {
            number.classList.remove("invalid");
            number.classList.add("valid");
        } else {
            number.classList.remove("valid");
            number.classList.add("invalid");
        }

        if (myInput.value.length >= 8) {
            length.classList.remove("invalid");
            length.classList.add("valid");
        } else {
            length.classList.remove("valid");
            length.classList.add("invalid");
        }
    }

}

const ConfirmPsw = () => {
    const psw = document.getElementById("psw");
    const confirmInput = document.getElementById("ConfirmPassword");
    const matchMsg = document.getElementById("matchMsg");



    confirmInput.onblur = function () {
        document.getElementById("confirmMessage").style.display = "none";
    }

    confirmInput.onkeyup = function () {
        if (confirmInput.value.match(psw.value)) {
            document.getElementById("confirmMessage").style.display = "none";
        } else {
            document.getElementById("confirmMessage").style.display = "block";
            matchMsg.innerHTML = "Password Doesnt Match";
        }
    }
}

const NameValidation = () => {

    const firstName = document.getElementById("FirstName");
    const lastName = document.getElementById("LastName");
    const regEx = /^[a-öA-Ö]+(?:[é'-][a-öA-Ö]+)*$/;


    firstName.onblur = function () {
        if (firstName.value.match(regEx))
        {
            document.getElementById("firstNameMsg").style.display = "none";
        }

    }
    lastName.onblur = function () {
        if (lastName.value.match(regEx)) {
            document.getElementById("lastNameMsg").style.display = "none";
        }
 
    }


    firstName.onkeyup = function () {
        if (firstName.value.match(regEx)) {
            document.getElementById("firstNameMsg").style.display = "none";
        } else {
            document.getElementById("firstNameMsg").style.display = "inline";
            document.getElementById("firstNameMsg").style.width = "50%";
            document.getElementById("firstNameMsg").style.color = "red";
            document.getElementById("firstNameWarning").innerHTML = "Only letters"
        }
    }

    lastName.onkeyup = function () {
        if (lastName.value.match(regEx)) {
            document.getElementById("lastNameMsg").style.display = "none";
        } else {
            document.getElementById("lastNameMsg").style.display = "inline";
            document.getElementById("lastNameMsg").style.width = "50%";
            document.getElementById("lastNameMsg").style.color = "red";
            document.getElementById("lastNameWarning").innerHTML = "Only letters"
        }
    }
}

const emailValidation = () => {
    const regEx = /^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+.[a-zA-Z]{2,}$/;
    const email = document.getElementById("Email");

    email.onblur = function () {
        if (email.value.match(regEx)) {
            document.getElementById("emailMsg").style.display = "none";
        }
    }

    email.onkeyup = function () {
        if (email.value.match(regEx)) {
            document.getElementById("emailMsg").style.display = "none";
        }
        else {
            document.getElementById("emailMsg").style.display = "block";
            document.getElementById("emailMsg").style.color = "red";
            document.getElementById("emailWarning").innerHTML = "ingen gilltig email"
        }
    }
}

const postalCodeValidation = () => {
    const regEx = /^(?:SE-)?\d{3}\s?\d{2}$/;
    const postCode = document.getElementById("PostalCode");

    postCode.onblur = function () {
        if (postCode.value.match(regEx)) {
            document.getElementById("postCodeMsg").style.display = "none";
        }
    }
    postCode.onkeyup = function () {
        if (postCode.value.match(regEx)) {
            document.getElementById("postCodeMsg").style.display = "none";
        }
        else {
            document.getElementById("postCodeMsg").style.display = "block";
            document.getElementById("postCodeMsg").style.color = "red";
            document.getElementById("postCodeWarning").innerHTML = "ingen gilltig postkod"
        }
    }
}
const cityValidation = () => {
    const regEx = /^[a-zA-ZåäöÅÄÖ]{3,}$/;
    const city = document.getElementById("City");

    city.onblur = function () {
        if (city.value.match(regEx)) {
            document.getElementById("cityMsg").style.display = "none";
        }
    }
    city.onkeyup = function () {
        if (city.value.match(regEx)) {
            document.getElementById("cityMsg").style.display = "none";
        }
        else {
            document.getElementById("cityMsg").style.display = "block";
            document.getElementById("cityMsg").style.color = "red";
            document.getElementById("cityWarning").innerHTML = "ingen gilltig stad"
        }
    }
}

const descriptionValidation = () => {
    const regEx = /^[\s\S]{1,500}$/;
    const description = document.getElementById("Description");

    description.onblur = function () {
        if (description.value.match(regEx)) {
            document.getElementById("descriptionMsg").style.display = "none";
        }
    }
    description.onkeyup = function () {
        if (description.value.match(regEx)) {
            document.getElementById("descriptionMsg").style.display = "none";
        }
        else {
            document.getElementById("descriptionMsg").style.display = "block";
            document.getElementById("descriptionMsg").style.color = "red";
            document.getElementById("descriptionWarning").innerHTML = "Meddelandet är inte gilltigt, tänk på att det måste vara mellan 1-500 tecken"
        }
    }
}

const priceValidation = () => {
    const regEx = /^[0-9,]+$/;
    const price = document.getElementById("Price");

    price.onblur = function () {
        if (price.value.match(regEx)) {
            document.getElementById("priceMsg").style.display = "none";
        }
    }
    price.onkeyup = function () {
        if (price.value.match(regEx)) {
            document.getElementById("priceMsg").style.display = "none";
        }
        else {
            document.getElementById("priceMsg").style.display = "block";
            document.getElementById("priceMsg").style.color = "red";
            document.getElementById("priceWarning").innerHTML = "Priset får bara bestå av nummer"
        }
    }
}

const discountValidation = () => {
    const regEx = /^(?:100|\d{1,2})$/;
    const discount = document.getElementById("Discount");

    discount.onblur = function () {
        if (discount.value.match(regEx)) {
            document.getElementById("discountMsg").style.display = "none";
        }
    }
    discount.onkeyup = function () {
        if (discount.value.match(regEx)) {
            document.getElementById("discountMsg").style.display = "none";
        }
        else {
            document.getElementById("discountMsg").style.display = "block";
            document.getElementById("discountMsg").style.color = "red";
            document.getElementById("discountWarning").innerHTML = "Rabatt mellan 0-100"
        }
    }
}