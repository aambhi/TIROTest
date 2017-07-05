
$(document).ready(function () {

    $(document).on("click", "#SaveVisaEndorsement", function () {

        var isVisaEndorsementError = false;
        $(".redClass").remove();
        isVisaEndorsementError = validateVisaEndorsementData();
        if (isVisaEndorsementError) {
            return false;
        }
        return true;
    });

    function validateVisaEndorsementData() {

        var Passport_id = $("#PassportId").val();
        var SubmissionDate = $("#SubmissionDate").val();
        var SubmissionStatus = $("#SubmissionStatusID").val();
        var hasError = false;

        if (Passport_id == '') {
            $("#PassportId").after('<span class="error redClass">Please select passport number</span>');
            hasError = true;
        }

        if (SubmissionDate == '') {
            $("#SubmissionDate").after('<span class="error redClass">Please select submission date</span>');
            hasError = true;
        }

        if (SubmissionStatus == '') {
            $("#SubmissionStatusID").after('<span class="error redClass">Please select submission status</span>');
            hasError = true;
        }
        
        return hasError
    }
});