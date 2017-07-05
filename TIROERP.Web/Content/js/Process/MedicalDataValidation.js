$(document).ready(function () {

    $(document).on("click", "#SaveMedicalData", function () {

        var isError = false;

        isError = validateMedicalData();

        if (isError) {
            return false;
        }

        return true;
    });


    function validateMedicalData() {

        var PassportId = $("#PassportID").val();
        var DoctorId = $("#DoctorID").val();
        var CheckUpDate = $("#CheckupDate").val();
        var medicalStatus = $(".medical-status").is(':checked');
        var hasError = false;

        if (PassportId == '') {
            $("#PassportID").after('<span class="error redClass">Please select passport number</span>');
            hasError = true;
        }

        if (DoctorId == '') {
            $("#DoctorID").after('<span class="error redClass">Please select doctor</span>');
            hasError = true;
        }

        if (CheckUpDate == '') {
            $("#CheckupDate").after('<span class="error redClass">Please select checkup date</span>');
            hasError = true;
        }

        if (!medicalStatus) {
            $($(".medical-status")[2]).after('<span class="error redClass">Please select Medical status</span>');
            hasError = true;
        }

        return hasError;

    }
});