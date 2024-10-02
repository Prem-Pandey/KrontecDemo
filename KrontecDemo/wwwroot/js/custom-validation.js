$(document).ready(function () {
    $.validator.setDefaults({
        errorClass: 'text-danger',
        highlight: function (element) {
            $(element).addClass('is-invalid');
        },
        unhighlight: function (element) {
            $(element).removeClass('is-invalid');
        },
        errorPlacement: function (error, element) {
            error.appendTo(element.parent());
        }
    });

    $("#createCustomerForm").validate({
        rules: {
            FirstName: { required: true },
            LastName: { required: true },
            Email: { required: true, email: true },
            PhoneNumber: { required: true, minlength: 10, maxlength: 10, digits: true },
            Address: { required: true }
        },
        messages: {
            FirstName: "Please enter your first name.",
            LastName: "Please enter your last name.",
            Email: "Please enter a valid email address.",
            PhoneNumber: {
                required: "Please enter your phone number.",
                minlength: "Phone number must be 10 digits long.",
                maxlength: "Phone number must be 10 digits long.",
                digits: "Please enter a valid phone number."
            },
            Address: "Please enter your address."
        }
    });

    $("#editCustomerForm").validate({
        rules: {
            FirstName: { required: true },
            LastName: { required: true },
            Email: { required: true, email: true },
            PhoneNumber: { required: true, minlength: 10, maxlength: 10, digits: true },
            Address: { required: true }
        },
        messages: {
            FirstName: "Please enter your first name.",
            LastName: "Please enter your last name.",
            Email: "Please enter a valid email address.",
            PhoneNumber: {
                required: "Please enter your phone number.",
                minlength: "Phone number must be 10 digits long.",
                maxlength: "Phone number must be 10 digits long.",
                digits: "Please enter a valid phone number."
            },
            Address: "Please enter your address."
        }
    });
    $('#createCustomerForm input').on('blur keyup', function () {
        $(this).valid();
    });

    $('#editCustomerForm input').on('blur keyup', function () {
        $(this).valid();
    });
});

