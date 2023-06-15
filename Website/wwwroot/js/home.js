// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function toastError(message) {
    Toastify({
        text: message || "Some errors occurred, please contact our support team or try again later",
        duration: 5000,
        style: {
            background: "#dc3545",
        },
    }).showToast();
}

function toastSuccess(message) {
    Toastify({
        text: message,
        duration: 5000,
        style: {
            color: "#212529",
            background: "#d1e7dd",
        },
    }).showToast();
}
let disableForm = false;

$('#form').on("submit", function (e) {
    e.preventDefault();
    if (disableForm) {
        return false;
    }

    disableForm = true; // prevent user from submitting duplication result at once
    $.ajax({
        url: "/prize-draw/submit",
        type: "POST",
        processData: false,
        contentType: false,
        data: new FormData(this),
        headers: {
            RequestVerificationToken: document.querySelector("[name=__RequestVerificationToken]").value,
        }
    })
        .then(response => {
            const { success, message } = response;
            if (success) {
                toastSuccess("Thank you for your submission! We appreciate your contribution and the effort you put into it. The result will be available shortly. If you have any more questions or need further assistance, feel free to ask.");
                this.reset();
            } else {
                toastError(message);
            }
        }, response => {
            if (response.responseJSON && response.responseJSON.validationResult) {
                const validationResult = response.responseJSON.validationResult;
                toastError(JSON.stringify(validationResult));
            }
            else {
                toastError();
            }
        }).always(() => {
            disableForm = false;
        })
});