$(document).ready(function () {

    //Initialise Datepicker
    $("#DATE_OF_BIRTH").datepicker({
        maxDate: "-1D",
        dateFormat: "dd/mm/yy",
        changeMonth: true,
        changeYear: true, yearRange: "-70:+0",
    });

    $("#DATE_OF_ISSUE").datepicker({
        maxDate: "-1D",
        dateFormat: "dd/mm/yy",
        changeMonth: true,
        changeYear: true, yearRange: "-70:+0",
        numberOfMonths: 1,
        onClose: function (selectedDate) {
            $("#DATE_OF_EXPIRY").datepicker("option", "minDate", selectedDate);
        }
    });

    $("#DATE_OF_EXPIRY").datepicker({

        dateFormat: "dd/mm/yy",
        changeMonth: true,
        changeYear: true, yearRange: "-70:+10",
        numberOfMonths: 1,
        onClose: function (selectedDate) {
            $("#DATE_OF_ISSUE").datepicker("option", "maxDate", selectedDate);
        }
    });

    $("#DRIVING_DATE_OF_ISSUE").datepicker({
        maxDate: "-1D",
        changeMonth: true,
        changeYear: true, yearRange: "-70:+0",
        numberOfMonths: 1,
        dateFormat: "dd/mm/yy",
        onClose: function (selectedDate) {
            $("#DRIVING_EXPIRY_DATE").datepicker("option", "minDate", selectedDate);
        }
    });
    $("#DRIVING_EXPIRY_DATE").datepicker({
        changeMonth: true,
        changeYear: true, yearRange: "-70:+10",
        numberOfMonths: 1,
        dateFormat: "dd/mm/yy",
        onClose: function (selectedDate) {
            $("#DRIVING_DATE_OF_ISSUE").datepicker("option", "maxDate", selectedDate);
        }
    });

    //save education details
    $(document).on("click", "#submitEducationDetails", function () {
        $('#progressBar').show();
        var formData = JSON.stringify({
            "LST_USER_EDUCATION": educationCollection,
            "EDUCATION_REMARK": $("#EDUCATION_REMARK").val(),
            "REGISTRATION_NO": $("#REGISTRATION_NO").val(),
            "CONDITIONAL_OPERATOR": "UPDATE_EDUCATION_DETAILS"
        });

        callAjaxFunctionAndLoadData(formData);
        return false;
    });

    //update personal info
    $("#UpdatePersonalDetails").click(function (e) {
        $('#progressBar').show();
        var isStepValid = true;

        var firstname = $("#FIRST_NAME").val();
        if (firstname == "") {
            $("#ErrItem_FIRST_NAME").text("Please enter First Name");
            isStepValid = false;
        }
        else {
            $("#ErrItem_FIRST_NAME").text("");
        }

        var lastname = $("#LAST_NAME").val();
        if (lastname == "") {
            $("#ErrItem_LAST_NAME").text("Please enter Last Name");
            isStepValid = false;
        }
        else {
            $("#ErrItem_LAST_NAME").text("");
        }

        var gender = $("#GENDER_CODE").val();
        if (gender == "") {
            $("#ErrItem_GENDER_CODE").text("Please select Gender");
            isStepValid = false;
        }
        else {
            $("#ErrItem_GENDER_CODE").text("");
        }

        var dob = $("#DATE_OF_BIRTH").val();
        if (!isDate(dob)) {
            $("#ErrItem_DATE_OF_BIRTH").text("Invalid Date of Birth");
            isStepValid = false;
        }
        else {
            $("#ErrItem_DATE_OF_BIRTH").text("");
        }

        var pob = $("#PLACE_OF_BIRTH").val();
        if (pob == "") {
            $("#ErrItem_PLACE_OF_BIRTH").text("Please enter Place of Birth");
            isStepValid = false;
        }
        else {
            $("#ErrItem_PLACE_OF_BIRTH").text("");
        }

        var nationality = $("#NATIONALITY_ID").val();
        if (nationality == "") {
            $("#ErrItem_NATIONALITY_ID").text("Please select Nationality");
            isStepValid = false;
        }
        else {
            $("#ErrItem_NATIONALITY_ID").text("");
        }

        var location = $("#CURRENT_LOCATION").val();
        if (location == "") {
            $("#ErrItem_CURRENT_LOCATION").text("Please select Location");
            isStepValid = false;
        }
        else {
            $("#ErrItem_CURRENT_LOCATION").text("");
        }

        var religion = $("#RELIGION_ID").val();
        if (religion == "") {
            $("#ErrItem_RELIGION_ID").text("Please select Religion");
            isStepValid = false;
        }
        else {
            $("#ErrItem_RELIGION_ID").text("");
        }

        var passport = $("#PASSPORT_NUMBER").val();
        if (passport != "") {

            var poi = $("#PLACE_OF_ISSUE").val();
            if (poi == "") {
                $("#ErrItem_POI").text("Please enter Place of Issue.");
                isStepValid = false;
            }
            else {
                $("#ErrItem_POI").text("");
            }

            var doi = $("#DATE_OF_ISSUE").val();
            if (!isDate(doi)) {
                $("#ErrItem_DOI").text("Invalid Date of Issue");
                isStepValid = false;
            }
            else {
                $("#ErrItem_DOI").text("");
            }

            var doe = $("#DATE_OF_EXPIRY").val();
            if (!isDate(doe)) {
                $("#ErrItem_DOE").text("Invalid Date of Expiry");
                isStepValid = false;
            }
            else {
                $("#ErrItem_DOE").text("");
            }

            var emigration = $("#EMIGRATION_CLEARANCE_REQUIRED").val();
            if (emigration == "" || emigration == "0") {
                $("#ErrItem_EMIGRATION").text("Please select Emigration Clearance");
                isStepValid = false;
            }
            else {
                $("#ErrItem_EMIGRATION").text("");
            }

        }
        else {
            $("#ErrItem_POI").text("");
            $("#ErrItem_DOI").text("");
            $("#ErrItem_DOE").text("");
            $("#ErrItem_EMIGRATION").text("");
        }

        var driving = $("#DRIVING_LICENCE_NUMBER").val();
        if (driving != "") {

            var dpoi = $("#DRIVING_PLACE_OF_ISSUE").val();
            if (dpoi == "") {
                $("#ErrItem_DPOI").text("Please enter Place of Issue.");
                isStepValid = false;
            }
            else {
                $("#ErrItem_DPOI").text("");
            }

            var ddoi = $("#DRIVING_DATE_OF_ISSUE").val();
            if (!isDate(ddoi)) {
                $("#ErrItem_DDOI").text("Invalid Date of Issue");
                isStepValid = false;
            }
            else {
                $("#ErrItem_DDOI").text("");
            }

            var ddoe = $("#DRIVING_EXPIRY_DATE").val();
            if (!isDate(ddoe)) {
                $("#ErrItem_DDOE").text("Invalid Date of Expiry");
                isStepValid = false;
            }
            else {
                $("#ErrItem_DDOE").text("");
            }

            var vehicletype = $("#VEHICLE_TYPE_ID").val();
            if (vehicletype == "" || vehicletype == "0") {
                $("#ErrItem_VEHICLETYPE").text("Please select Vehicle Type");
                isStepValid = false;
            }
            else {
                $("#ErrItem_VEHICLETYPE").text("");
            }

        }
        else {
            $("#ErrItem_DPOI").text("");
            $("#ErrItem_DDOI").text("");
            $("#ErrItem_DDOE").text("");
            $("#ErrItem_VEHICLETYPE").text("");
        }

        if (isStepValid) {
            //fetch all values
            var formData = JSON.stringify({
                "FIRST_NAME": $("#FIRST_NAME").val(),
                "MIDDLE_NAME": $("#MIDDLE_NAME").val(),
                "LAST_NAME": $("#LAST_NAME").val(),
                "FILE_PATH": $("#FILE_PATH").val(),

                "FATHER_NAME": $("#FATHER_NAME").val(),
                "MOTHER_NAME": $("#MOTHER_NAME").val(),
                "GENDER_CODE": $("#GENDER_CODE").val(),
                "DATE_OF_BIRTH": convertJSDate($("#DATE_OF_BIRTH").val()),
                "PLACE_OF_BIRTH": $("#PLACE_OF_BIRTH").val(),
                "MARITAL_STATUS_ID": $("#MARITAL_STATUS_ID").val(),
                "NATIONALITY_ID": $("#NATIONALITY_ID").val(),
                "CURRENT_LOCATION": $("#CURRENT_LOC").val(),

                "LST_USER_LANGUAGE": languageCollection,

                "RELIGION_ID": $("#RELIGION_ID").val(),
                "PASSPORT_ID": $("#PASSPORT_ID").val(),
                "PASSPORT_NUMBER": $("#PASSPORT_NUMBER").val(),
                "DATE_OF_ISSUE": convertJSDate($("#DATE_OF_ISSUE").val()),
                "PLACE_OF_ISSUE": $("#PLACE_OF_ISSUE").val(),
                "DATE_OF_EXPIRY": convertJSDate($("#DATE_OF_EXPIRY").val()),
                "EMIGRATION_CLEARANCE_REQUIRED": $("#EMIGRATION_CLEARANCE_REQUIRED").val() === "true" ? true : false,

                "DRIVING_LICENCE_ID": $("#DRIVING_LICENCE_ID").val(),
                "DRIVING_LICENCE_NUMBER": $("#DRIVING_LICENCE_NUMBER").val(),
                "DRIVING_PLACE_OF_ISSUE": $("#DRIVING_PLACE_OF_ISSUE").val(),
                "DRIVING_DATE_OF_ISSUE": convertJSDate($("#DRIVING_DATE_OF_ISSUE").val()),
                "DRIVING_EXPIRY_DATE": convertJSDate($("#DRIVING_EXPIRY_DATE").val()),
                "VEHICLE_TYPE_ID": $("#VEHICLE_TYPE_ID").val(),
                "DRIVING_REMARK": $("#DRIVING_REMARK").val(),

                "REGISTRATION_NO": $("#REGISTRATION_NO").val(),
                "CONDITIONAL_OPERATOR": "UPDATE_PERSONAL_DETAILS"
            });

            callAjaxFunctionAndLoadData(formData);
        }
        $("#divPopupPersonal").scrollTop(0);
        $('#progressBar').hide();
        return false;
    });

    //save candidate official details
    $(document).on("click", "#submitCandidateOfficialDetails", function () {
        $('#progressBar').show();
        var isOfficialStepValid = true;

        var availingtype = $("#AVAILING_TYPE_ID").val();
        if (availingtype == "") {
            $("#ErrItem_AVAILING_TYPE_ID").text("Please select Availing Type");
            isOfficialStepValid = false;
        }
        else {
            $("#ErrItem_AVAILING_TYPE_ID").text("");
        }

        var source = $("#SOURCE_ID").val();
        if (source == "" || source == "0") {
            $("#ErrItem_SOURCE_ID").text("Please select Source");
            isOfficialStepValid = false;
        }
        else {
            $("#ErrItem_SOURCE_ID").text("");
        }

        var status = $("#STATUS_ID").val();
        if (status == "") {
            $("#ErrItem_STATUS_ID").text("Please select Status");
            isOfficialStepValid = false;
        }
        else {
            $("#ErrItem_STATUS_ID").text("");
        }

        if (isOfficialStepValid) {
            var formData = JSON.stringify({

                "AVAILING_TYPE_ID": $("#AVAILING_TYPE_ID").val(),
                "SOURCE_ID": $("#SOURCE_ID").val(),
                "OTHER_SOURCE": $("#OTHER_SOURCE").val(),
                "REFERRER_NAME": $("#REFERRER_NAME").val(),
                "STATUS_ID": $("#STATUS_ID").val(),
                "POST_APPLIED_FOR": $("#POST_APPLIED_FOR").val(),
                "FILE_NO": $("#FILE_NO").val(),
                "REQUIREMENT_ID": $("#REQUIREMENT_ID").val(),
                "VISA_ID": $("#VISA_ID").val(),
                "LOGIN_ACCESS": $("#LOGIN_ACCESS").val() === "" ? false : true,
                "REMARK": $("#REMARK").val(),

                "REGISTRATION_NO": $("#REGISTRATION_NO").val(),
                "CONDITIONAL_OPERATOR": "UPDATE_OFFICIAL_DETAILS"
            });

            callAjaxFunctionAndLoadData(formData);
        } else {
            $('#progressBar').hide();
        }
        $("body").scrollTop(0);
        
        return false;
    });

    //save certification details
    $(document).on("click", "#submitCertificationDetails", function () {
        $('#progressBar').show();
        var formData = JSON.stringify({
            "LST_USER_CERTIFICATION": certificationCollection,
            "REGISTRATION_NO": $("#REGISTRATION_NO").val(),
            "CONDITIONAL_OPERATOR": "UPDATE_CERTIFICATION_DETAILS"
        });


        callAjaxFunctionAndLoadData(formData);
        return false;

    });

    //save contact details
    $(document).on("click", "#submitContactDetails", function () {
        $('#progressBar').show();
        var isContactStepValid = true;
        var tbladdresscount = $('#tblchild').children().length;
        if (tbladdresscount < 1) {
            $("#Err_ADDRESS_TYPE_ID").text("Please select Address Type");
            $("#Err_ADDRESS").text("Please enter Address details");
            $("#Err_COUNTRY_CODE").text("Please select Country");
            $("#Err_STATE_CODE").text("Please select State");
            $("#Err_USER_PINCODE").text("Please enter Pin Code");
            isContactStepValid = false;
        }

        var tblcontactcount = $('#tblcontact').children().length;
        if (tblcontactcount < 1) {
            $("#Err_CONTACT_TYPE_ID").text("Please select Contact Type");
            $("#Err_CONTACT_NO").text("Please enter Contact no.");
            isContactStepValid = false;
        }

        if (isContactStepValid) {

            var formData = JSON.stringify({
                "LST_USER_ADDRESS": addressCollection,
                "LST_USER_CONTACT": contactCollection,
                "LST_USER_EMAIL": emailCollection,
                "WEBSITE": $("#WEBSITE").val(),
                "SKYPE": $("#SKYPE").val(),
                "CONTACT_REMARK": $("#CONTACT_REMARK").val(),

                "REGISTRATION_NO": $("#REGISTRATION_NO").val(),
                "CONDITIONAL_OPERATOR": "UPDATE_CONTACT_DETAILS"
            });

            callAjaxFunctionAndLoadData(formData);
        }
        $('#progressBar').hide();
        return false;
    })

    //save document details
    $(document).on("click", "#submitDocumentDetails", function () {
        $('#progressBar').show();
        var formData = JSON.stringify({
            "LST_USER_DOCUMENT": documentCollection,
            "REGISTRATION_NO": $("#REGISTRATION_NO").val(),
            "CONDITIONAL_OPERATOR": "UPDATE_DOCUMENT_DETAILS"
        });

        callAjaxFunctionAndLoadData(formData);
        return false;

    });

    //save experience details
    $(document).on("click", "#submitExpDetails", function () {
        $('#progressBar').show();
        var formData = JSON.stringify({
            "LST_USER_EXPERIENCE": experienceCollection,
            "TOTAL_WORK_EXPERIENCE": $("#TOTAL_WORK_EXPERIENCE").val(),
            "TOTAL_GULF_EXPERIENCE": $("#TOTAL_GULF_EXPERIENCE").val(),
            "SKILLS": $("#SKILLS").val(),
            "WORK_REMARK": $("#WORK_REMARK").val(),

            "REGISTRATION_NO": $("#REGISTRATION_NO").val(),
            "CONDITIONAL_OPERATOR": "UPDATE_EXPERIENCE_DETAILS"
        });

        callAjaxFunctionAndLoadData(formData);
        return false;
    });

    //save process medical details
    $(document).on("click", "#btnSaveMedical", function () {

        var isStepValid = true;

        var DoctorID = $("#DoctorID").val();
        if (DoctorID == "") {
            $("#Err_DoctorID").text("Please select Doctor");
            isStepValid = false;
        }
        else {
            $("#Err_DoctorID").text("");
        }

        var CheckupDate = $("#CheckupDate").val();
        if (CheckupDate == "") {
            $("#Err_CheckupDate").text("Please enter Checkup Date");
            isStepValid = false;
        }
        else {
            $("#Err_CheckupDate").text("");
        }

        var MedicalStatus = $("#MedicalStatus").val();
        if (MedicalStatus == "") {
            $("#Err_MedicalStatus").text("Please Medical Status");
            isStepValid = false;
        }
        else {
            $("#Err_MedicalStatus").text("");
        }

        var ReportDate = $("#ReportDate").val();
        if (ReportDate == "") {
            $("#Err_ReportDate").text("Please enter Report Date");
            isStepValid = false;
        }
        else {
            $("#Err_ReportDate").text("");
        }

        if (isStepValid) {
            var medicalId = $("#MEDICAL_ID").val();
            if (medicalId == "") {
                var statusId = $("#STATUS_ID").val();
                if (statusId != "6" && statusId != "9" && statusId != "8") {
                    alert("You cannot add new Medical Details. First change the status of Candidate to INTERVIEW SELECTED.");
                    return false;
                }
            }

            var medicaldetails = {
                "MedicalId": $("#MedicalId").val(),
                "USER_REQUIREMENT_ID": $("#USER_REQUIREMENT_ID").val(),
                "DoctorID": $("#DoctorID").val(),
                "CheckupDate": convertJSDate($("#CheckupDate").val()),
                "TokenNumber": $("#TokenNumber").val(),
                "ReportDate": convertJSDate($("#ReportDate").val()),
                "MedicalStatus": $("input[name='MedicalStatus']:checked").val(),
                "ReportPath": $("#ReportPath").val(),
                "Remark": $("#Remark").val()
            }

            var formData = JSON.stringify({
                "Medical_Details": medicaldetails,

                "REGISTRATION_NO": $("#REGISTRATION_NO").val(),
                "CONDITIONAL_OPERATOR": "UPDATE_PROCESS_MEDICAL"
            });

            callAjaxFunctionAndLoadData(formData);
        }
        return false;
    });

    //save process mofa details
    $(document).on("click", "#btnSaveMOFA", function () {
        var isStepValid = true;
        var MofaNumber = $("#MofaNumber").val();
        if (MofaNumber == "") {
            $("#Err_MofaNumber").text("Please enter Mofa No.");
            isStepValid = false;
        }
        else {
            $("#Err_MofaNumber").text("");
        }

        var MofaDate = $("#MofaDate").val();
        if (MofaDate == "") {
            $("#Err_MofaDate").text("Please enter Mofa Date");
            isStepValid = false;
        }
        else {
            $("#Err_MofaDate").text("");
        }

        if (isStepValid) {
            var mofaId = $("#MOFA_ID").val();
            if (mofaId == "") {
                var statusId = $("#STATUS_ID").val();
                if (statusId != "19") {
                    alert("You cannot add new MOFA Details. First add Medical Details against Candidate.");
                    return false;
                }
            }

            var mofadetails = {
                "MofaID": $("#MofaID").val(),
                "USER_REQUIREMENT_ID": $("#USER_REQUIREMENT_ID").val(),
                "MofaNumber": $("#MofaNumber").val(),
                "MofaDate": convertJSDate($("#MofaDate").val()),
                "ApplicationNumber": $("#ApplicationNumber").val(),
                "ApplicationDate": convertJSDate($("#ApplicationDate").val()),
                "HealthNumber": $("#HealthNumber").val(),
                "HealthDate": convertJSDate($("#HealthDate").val()),
                "DDNumber": $("#DDNumber").val(),
                "DDDate": convertJSDate($("#DDDate").val()),
                "MofaFilePath": $("#MofaFilePath").val(),
                "MofaRemark": $("#MofaRemark").val(),
                "REGISTRATION_NO": $("#REGISTRATION_NO").val()
            }

            var formData = JSON.stringify({
                "MOFA_Details": mofadetails,

                "REGISTRATION_NO": $("#REGISTRATION_NO").val(),
                "CONDITIONAL_OPERATOR": "UPDATE_PROCESS_MOFA"
            });

            callAjaxFunctionAndLoadData(formData);
        }
        return false;
    });

    //save process VISA details
    $(document).on("click", "#btnSaveVISA", function () {
        var isStepValid = true;

        var SubmissionDate = $("#SubmissionDate").val();
        if (SubmissionDate == "") {
            $("#Err_SubmissionDate").text("Please enter Submission Date");
            isStepValid = false;
        }
        else {
            $("#Err_SubmissionDate").text("");
        }

        var SubmissionStatusID = $("#SubmissionStatusID").val();
        if (SubmissionStatusID == "") {
            $("#Err_SubmissionStatusID").text("Please select Submission Status");
            isStepValid = false;
        }
        else {
            $("#Err_SubmissionStatusID").text("");
        }

        if (isStepValid) {
            var visaId = $("#VISAENDORSEMENT_ID").val();
            if (visaId == "") {
                var statusId = $("#STATUS_ID").val();
                if (statusId != "16" && statusId != "10" && statusId != "11") {
                    alert("You cannot add new VISA Endorsement Details. First add MOFA Details against Candidate.");
                    return false;
                }
            }

            var visadetails = {
                "VisaEndorsementId": $("#VISAENDORSEMENT_ID").val(),
                "USER_REQUIREMENT_ID": $("#USER_REQUIREMENT_ID").val(),
                "SubmissionDate": convertJSDate($("#SubmissionDate").val()),
                "SubmissionStatusID": $("#SubmissionStatusID").val(),
                "VisaEndorsementFilePath": $("#VisaEndorsementFilePath").val()
            }

            var formData = JSON.stringify({
                "VisaEndorsement_Details": visadetails,

                "REGISTRATION_NO": $("#REGISTRATION_NO").val(),
                "CONDITIONAL_OPERATOR": "UPDATE_PROCESS_VISA_ENDORSEMENT"
            });

            callAjaxFunctionAndLoadData(formData);
        }
        return false;
    });

    ////save process Policy details
    //$(document).on("click", "#btnSavePolicy", function () {

    //    var policydetails = {
    //        "POLICYID": $("#POLICY_ID").val(),
    //        "USER_REQUIREMENT_ID": $("#USER_REQUIREMENT_ID").val(),
    //        "PolicyDate": convertJSDate($("#PolicyDate").val()),
    //        "PolicyNumber": $("#Policy").val(),
    //        "PolicyFees": $("#PolicyFees").val(),
    //        "PolicyRemark": $("#PolicyRemark").val()
    //    }

    //    var formData = JSON.stringify({
    //        "Policy_Details": policydetails,

    //        "REGISTRATION_NO": $("#REGISTRATION_NO").val(),
    //        "CONDITIONAL_OPERATOR": "UPDATE_PROCESS_POLICY"
    //    });

    //    callAjaxFunctionAndLoadData(formData);
    //    return false;
    //});

    //save process Policy details
    $(document).on("click", "#btnSaveEmigration", function () {
        var isStepValid = true;

        var isECR = $('input[name=emigrationstatus]:checked').val();
        $("#IS_ECR").val(isECR);

        if (isECR == "true") {

            var dmno = $("#DM_NO").val();
            if (dmno == "") {
                $("#Err_DM_NO").text("Please enter DM No.");
                isStepValid = false;
            }
            else {
                $("#Err_DM_NO").text("");
            }

            var dmdate = $("#DM_DATE").val();
            if (dmdate == "") {
                $("#Err_DM_DATE").text("Please enter DM Date");
                isStepValid = false;
            }
            else {
                $("#Err_DM_DATE").text("");
            }

            var policyno = $("#POLICY_NO").val();
            if (policyno == "") {
                $("#Err_POLICY_NO").text("Please enter Policy No");
                isStepValid = false;
            }
            else {
                $("#Err_POLICY_NO").text("");
            }

            var policydate = $("#POLICY_DATE").val();
            if (policydate == "") {
                $("#Err_POLICY_DATE").text("Please enter Policy Date");
                isStepValid = false;
            }
            else {
                $("#Err_POLICY_DATE").text("");
            }

            var policyamt = $("#POLICY_AMOUNT").val();
            if (policyamt == "") {
                $("#Err_POLICY_AMOUNT").text("Please enter Policy Amount");
                isStepValid = false;
            }
            else {
                $("#Err_POLICY_AMOUNT").text("");
            }

            var policycompname = $("#POLICY_COMPANYNAME").val();
            if (policycompname == "") {
                $("#Err_POLICY_COMPANYNAME").text("Please enter Policy Company Name");
                isStepValid = false;
            }
            else {
                $("#Err_POLICY_COMPANYNAME").text("");
            }

            var SUBMISSION_DATE = $("#SUBMISSION_DATE").val();
            if (SUBMISSION_DATE == "") {
                $("#Err_SUBMISSION_DATE").text("Please enter Submission Date");
                isStepValid = false;
            }
            else {
                $("#Err_SUBMISSION_DATE").text("");
            }

            var EMIGRATION_CLEARANCENO = $("#EMIGRATION_CLEARANCENO").val();
            if (EMIGRATION_CLEARANCENO == "") {
                $("#Err_EMIGRATION_CLEARANCENO").text("Please enter Emigration Clearance No");
                isStepValid = false;
            }
            else {
                $("#Err_EMIGRATION_CLEARANCENO").text("");
            }

            var POE = $("#POE").val();
            if (POE == "") {
                $("#Err_POE").text("Please enter POE");
                isStepValid = false;
            }
            else {
                $("#Err_POE").text("");
            }
        }

        if (isStepValid) {
            var emigrationId = $("#EMIGRATION_ID").val();
            if (emigrationId == "") {
                var statusId = $("#STATUS_ID").val();
                if (statusId != "20") {
                    alert("You cannot add new Emigration Details. First add VISA Endorsement Details against Candidate.");
                    return false;
                }
            }

            var emigrationdetails = {
                "EMIGRATION_ID": $("#EMIGRATION_ID").val(),
                "USER_REQUIREMENT_ID": $("#USER_REQUIREMENT_ID").val(),
                "IS_ECR": $("#IS_ECR").val(),
                "FE_NO": $("#FE_NO").val(),
                "PT_NO": $("#PT_NO").val(),
                "DM_NO": $("#DM_NO").val(),
                "DM_DATE": $("#DM_DATE").val(),
                "POLICY_NO": $("#POLICY_NO").val(),
                "POLICY_DATE": $("#POLICY_DATE").val(),
                "POLICY_AMOUNT": $("#POLICY_AMOUNT").val(),
                "POLICY_COMPANYNAME": $("#POLICY_COMPANYNAME").val(),
                "POLICY_ATTACHMENT": $("#POLICY_ATTACHMENT").val(),
                "SUBMISSION_DATE": $("#SUBMISSION_DATE").val(),
                "EMIGRATION_CLEARANCENO": $("#EMIGRATION_CLEARANCENO").val(),
                "EMIGRATION_ATTACHMENT": $("#EMIGRATION_ATTACHMENT").val(),
                "POE": $("#POE").val(),
                "REMARK": $("#EMIGRATION_REMARK").val(),
            }

            var formData = JSON.stringify({
                "Emigration_Details": emigrationdetails,

                "REGISTRATION_NO": $("#REGISTRATION_NO").val(),
                "CONDITIONAL_OPERATOR": "UPDATE_PROCESS_EMIGRATION"
            });

            callAjaxFunctionAndLoadData(formData);
        }
        return false;
    });

    //save process Ticket details
    $(document).on("click", "#btnSaveTicket", function () {
        var isConnError = false;
        var isDirectError = false;
        $(".redClassForDirect").remove();
        $(".redClass").remove();
        if ($("#directConn").is(':checked')) {
            isConnError = validateConnectionData();

            if (!isConnError) {
                $(".redClass").remove();
            }
        }

        isDirectError = validatDirectData();
        if (!isDirectError) {
            $(".redClassForDirect").remove();
        }

        if (isConnError || isDirectError) {
            return false;
        }
        else {


            var ticketdetails = {
                "TicketID": $("#TICKET_ID").val(),
                "USER_REQUIREMENT_ID": $("#USER_REQUIREMENT_ID").val(),
                "AirlinesID": $("#AirlinesID").val(),
                "OtherAirlines": $("#OtherAirlines").val(),
                "IsDirect": $("#IsDirect").val(),

                "PnrNumber": $("#PnrNumber").val(),
                "TicketNumber": $("#TicketNumber").val(),
                "FlightNumber": $("#FlightNumber").val(),
                "IsBooked": $("#IsBooked").val(),
                "IsCancelled": $("#IsCancelled").val(),
                "DepartureCountryCode": $("#DepartureCountryCode").val(),
                "DepartureCityCode": $("#DepartureCityCode").val(),
                "DepartureDate": convertJSDate($("#DepartureDate").val()),
                "DepartureTime": $("#DepartureTime").val(),
                "DestinationCountryCode": $("#DestinationCountryCode").val(),
                "DestinationCityCode": $("#DestinationCityCode").val(),
                "ArivalDate": convertJSDate($("#ArivalDate").val()),
                "ArrivalTime": $("#ArrivalTime").val(),
                "ReportPath": $("#ticketReportPath").val(),

                "Remark": $("#Remark").val(),
                "Conn_PnrNumber": $("#Conn_PnrNumber").val(),
                "Conn_TicketNumber": $("#Conn_TicketNumber").val(),
                "Conn_FlightNumber": $("#Conn_FlightNumber").val(),
                "Conn_IsBooked": $("#Conn_IsBooked").val(),
                "Conn_IsCancelled": $("#Conn_IsCancelled").val(),
                "Conn_DestinationCountryCode": $("#Conn_DestinationCountryCode").val(),
                "Conn_DepartureCityCode": $("#Conn_DepartureCityCode").val(),
                "Conn_DepartureDate": convertJSDate($("#Conn_DepartureDate").val()),
                "Conn_DepartureTime": $("#Conn_DepartureTime").val(),
                "Conn_DepartureCountryCode": $("#Conn_DepartureCountryCode").val(),
                "Conn_ArivalDate": convertJSDate($("#Conn_ArivalDate").val()),
                "Conn_ArrivalTime": $("#Conn_ArrivalTime").val(),

                "Conn_DestinationCityCode": $("#Conn_DestinationCityCode").val()

            }

            var formData = JSON.stringify({
                "Ticket_Details": ticketdetails,

                "REGISTRATION_NO": $("#REGISTRATION_NO").val(),
                "CONDITIONAL_OPERATOR": "UPDATE_PROCESS_TICKET"
            });

            callAjaxFunctionAndLoadData(formData);
            return false;
        }
    });

    //ajax call
    function callAjaxFunctionAndLoadData(formData) {
        var urlPath = "/StatusSearch/Update";
        $.ajax({
            url: urlPath,
            data: formData,
            type: 'POST',
            contentType: "application/json",
            traditional: true,
            dataType: "json",
            async: true,
            success: function (d) {
                if (d == "SessionTimeout") {
                    window.location.href = '/Login/LogOut';
                }
                if (d.CONDITIONAL_OPERATOR === "UPDATE_PERSONAL_DETAILS") {
                    $("#divREGISTRATION_NO").html(d.REGISTRATION_NO);
                    $("#divREGISTRATION_DATE").html(ConvertJsonDate(d.REGISTRATION_DATE));
                    $("#divCANDIDATE_NAME").html(d.Candidate_Name);
                    $("#divDOB").html(ConvertJsonDate(d.DATE_OF_BIRTH));
                    $("#divCURRENT_AGE").html(d.Age);
                    $("#divFATHER_NAME").html(d.FATHER_NAME);
                    $("#divMOTHER_NAME").html(d.MOTHER_NAME);

                    $("#divGENDER_NAME").html(d.GENDER_NAME);
                    $("#GENDER_CODE").val(d.GENDER_CODE).trigger("chosen:updated");
                    $("#divPLACE_OF_BIRTH").html(d.PLACE_OF_BIRTH);
                    $("#divMARITAL_STATUS").html(d.MARITAL_STATUS);
                    $("#MARITAL_STATUS_ID").val(d.MARITAL_STATUS_ID).trigger("chosen:updated");
                    $("#divNATIONALITY").html(d.NATIONALITY);
                    $("#NATIONALITY_ID").val(d.NATIONALITY_ID).trigger("chosen:updated");
                    $("#divRELIGION_NAME").html(d.RELIGION_NAME);
                    $("#RELIGION_ID").val(d.RELIGION_ID).trigger("chosen:updated");
                    $("#divCURRENT_LOCATION").html(d.CURRENT_LOCATION);
                    
                    $("#PASSPORT_ID").val(d.PASSPORT_ID);
                    $("#divPASSPORT_NUMBER").html(d.PASSPORT_NUMBER);
                    $("#divPLACE_OF_ISSUE").html(d.PLACE_OF_ISSUE);
                    $("#divDATE_OF_ISSUE").html(ConvertJsonDate(d.DATE_OF_ISSUE));
                    $("#divDATE_OF_EXPIRY").html(ConvertJsonDate(d.DATE_OF_EXPIRY));
                    if (d.EMIGRATION_CLEARANCE_REQUIRED) {
                        $("#divEMIGRATION_CLEARANCE_REQUIRED").html("Required");
                    } else {
                        $("#divEMIGRATION_CLEARANCE_REQUIRED").html("Not Required");
                    }
                    $("#DRIVING_LICENCE_ID").val(d.DRIVING_LICENCE_ID);
                    $("#divDRIVING_LICENCE_NUMBER").html(d.DRIVING_LICENCE_NUMBER);
                    $("#divDRIVING_PLACE_OF_ISSUE").html(d.DRIVING_PLACE_OF_ISSUE);
                    $("#divDRIVING_DATE_OF_ISSUE").html(ConvertJsonDate(d.DRIVING_DATE_OF_ISSUE));
                    $("#divDRIVING_EXPIRY_DATE").html(ConvertJsonDate(d.DRIVING_EXPIRY_DATE));
                    $("#divVEHICLE_TYPE").html(d.VEHICLE_TYPE);
                    $("#VEHICLE_TYPE_ID").val(d.VEHICLE_TYPE_ID).trigger("chosen:updated");
                    $("#divDRIVING_REMARK").html(d.DRIVING_REMARK);

                    if (d.LANGUAGES != null || d.LANGUAGES !="") {
                        $("#ulLang").empty();
                        var langarray = d.LANGUAGES.split(',');
                        _.each(langarray, function (value) {
                            var lilang = "<li>" + value + "</li>";
                            $("#ulLang").append(lilang);
                        });
                    }

                    if (d.FILE_PATH !== null && d.FILE_PATH.length > 0) {
                        var fullFilePath = '/Uploads/CandidateUploadedFiles/' + d.FILE_PATH;
                        //case when new image is uploaded by user
                        if ($(".image-div").length === 0) {
                            var addNewElement = "<div class='panel-body col-md-3 col-sm-3 image-div' style='padding-left: 50px;'>";
                            addNewElement += "<div class='fileinput fileinput-new' data-provides='fileinput'>";
                            addNewElement += "<img src='" + fullFilePath + "' class='candidate-img' style='width: 200px; height: 150px;' alt=" + d.Candidate_Name + " />";
                            addNewElement += "<div><input type='hidden' name='FILE_PATH' id='FILE_PATH'></div>";
                            addNewElement += "</div>";
                            $(".details-panel").after(addNewElement);
                        }

                        else {
                            //  add new image
                            $(".candidate-img").attr("src", fullFilePath);

                        }
                        $("#FILE_PATH").val(d.FILE_PATH);
                        $("#imageUploadDiv").remove();
                    }
                    else {
                        $(".candidate-img").attr("src", "/Uploads/CandidateUploadedFiles/no_img.png");
                        //$(".image-div").remove();
                        //$("#imageUploadDiv").append("<img src = '/Uploads/CandidateUploadedFiles/no_img.png'/>");
                    }

                    $(".personal-details").modal("hide");
                    $("#divSuccessMsg").show();
                }
                else if (d.CONDITIONAL_OPERATOR === "UPDATE_CONTACT_DETAILS") {

                    $("#tblAddDetails").empty();
                    //Address Details Bind
                    var row = "";
                    _.each(d.LST_USER_ADDRESS, function (value) {
                        row += "<tr id ='tr_add_" + value.ADDRESS_TYPE_ID + "'><td><span class='user-address'>" + value.ADDRESS + "</span></td><td>" + value.USER_COUNTRY + "</td><td>" + value.USER_STATE + "-" + value.CITY_CODE + "</td><td>" + value.USER_VILLAGE + "</td><td>" + value.USER_PINCODE + "</td> "

                        contactno = value.Contact_No;
                        email = value.USER_EMAIL;
                        if (value.WEBSITE != null) {
                            $(".website").html(value.WEBSITE);
                        }
                        if (value.SKYPE != null) {
                            $(".skype").text(value.SKYPE);
                        }
                        if (value.CONTACT_REMARK != null) {
                            $(".contactremark").text(value.CONTACT_REMARK);
                        }
                    });
                    $("#tblAddDetails").append(row);

                    if (contactno != null) {
                        $("#ulContact").empty();
                        var contactarray = contactno.split(',');
                        _.each(contactarray, function (value) {
                            var licontact = "<li>" + value + "</li>";
                            $("#ulContact").append(licontact);
                        });
                    }

                    if (email != null) {
                        $("#ulEmail").empty();
                        var emailarray = email.split(',');
                        _.each(emailarray, function (value) {
                            var liemail = "<li>" + value + "</li>";
                            $("#ulEmail").append(liemail);
                        });
                    }

                    $(".contact_details").modal("hide");
                    $("#divSuccessMsg").show();
                }
                else if (d.CONDITIONAL_OPERATOR === "UPDATE_OFFICIAL_DETAILS") {
                    $("#divAVAILING_TYPE").html(d.AVAILING_TYPE);
                    $("#AVAILING_TYPE_ID").val(d.AVAILING_TYPE_ID);
                    $("#divSOURCE_NAME").html(d.SOURCE_NAME);
                    $("#SOURCE_ID").val(d.SOURCE_ID);
                    $("#OTHER_SOURCE").val(d.OTHER_SOURCE);
                    $("#REFERRER_NAME").val(d.REFERRER_NAME);
                    $("#divSTATUS_NAME").html(d.STATUS_NAME);
                    $("#STATUS_ID").val(d.STATUS_ID);
                    $("#divPOST_APPLIED_FOR").html(d.POST_APPLIED_FOR);
                    $("#divFILE_NO").html(d.FILE_NO);
                    $("#divREQUIREMENT").html(d.REQUIREMENT);
                    $("#REQUIREMENT_ID").val(d.REQUIREMENT_ID);
                    $("#divVISA_NUMBER").html(d.VISA_NUMBER);
                    $("#VISA_ID").val(d.VISA_ID);
                    $("#divREMARK").html(d.REMARK);

                    
                    $(".current-status").modal("hide");
                    $("#divSuccessMsg").show();
                }
                else if (d.CONDITIONAL_OPERATOR === "UPDATE_CERTIFICATION_DETAILS") {
                    $("#tblCertificationDetails").empty();
                    var row = "";
                    _.each(d.LST_USER_CERTIFICATION, function (value) {
                        row += "<tr id ='tr_cert_" + value.CERTIFICATION_ID + "'><td>" + value.CERTIFICATION + "</td><td>" + value.CERTIFICATION_LEVEL + "</td><td>" + value.INSTITUTE + "</td><td class='yearOfPassing'>" + value.YEAR_OF_PASSING + "</td></tr>";
                    });
                    $("#tblCertificationDetails").append(row);

                    $(".certification-details").modal("hide");
                    $("#divSuccessMsg").show();
                }
                else if (d.CONDITIONAL_OPERATOR === "UPDATE_EDUCATION_DETAILS") {
                    $("#tblEducationDetails").empty();
                    var eduremark = "";
                    var row = "";
                    _.each(d.LST_USER_EDUCATION, function (value) {
                        if (value.EDUCATION_TYPE_ID != 0) {
                            var highestqual = "No";
                            if (value.IS_HIGHEST_QUALIFICATION == true)
                                highestqual = "Yes";
                            row += "<tr id ='tr_edu_" + value.EDUCATION_TYPE_ID + "'><td>" + value.EDUCATION_TYPE + "</td><td>" + value.SPECIALIZATION_TYPE + "</td><td>" + value.UNIVERSITY_ID + "</td><td>" + value.UNIVERSITY_YEAR_OF_PASSING + "</td><td>" + highestqual + "</td></tr>";
                        }
                        eduremark = value.EDUCATION_REMARK;
                    });
                    $("#tblEducationDetails").append(row);

                    if (eduremark != null) {
                        $("#divEDUCATION_REMARK").html(eduremark);
                    }

                    $(".education-details").modal("hide");
                    $("#divSuccessMsg").show();
                }
                else if (d.CONDITIONAL_OPERATOR === "UPDATE_EXPERIENCE_DETAILS") {
                    $("#tblWorkExpDetails").empty();
                    var row = "";
                    _.each(d.LST_USER_EXPERIENCE, function (value) {
                        if (value.EXPERIENCE_ID != 0) {
                            row += "<tr id ='tr_exp_" + value.EXPERIENCE_ID + "'><td class='company-name'>" + value.COMPANY_NAME + "<input type='hidden' class='user_company_name' value='" + value.USER_COMPANY_NAME + "' /></td><td>" + value.DESIGNATION + "</td>";
                            row += "<td>" + value.INDUSTRY_TYPE + "</td><td data-work-period-from = '" + ConvertJsonDate(value.WORK_PERIOD_FROM) + "'>" + ConvertJsonDate(value.WORK_PERIOD_FROM) + "-" + ConvertJsonDate(value.WORK_PERIOD_TO) + "</td>";
                            row += "<td>" + value.STATE_NAME + "-" + value.CITY_NAME + "</td></tr>";
                        }
                        $('#divTOTAL_EXPERIENCE').html(value.TOTAL_WORK_EXPERIENCE);
                        $('#divGULF_EXPERIENCE').html(value.TOTAL_GULF_EXPERIENCE);
                        $('#divSKILLS').html(value.SKILLS);
                        $('#divWORK_REMARK').html(value.REMARK);
                    });

                    if (d.LST_USER_EXPERIENCE.length == 0) {
                        $('#divTOTAL_EXPERIENCE').html("0 year, 0 month, and 0 day");
                        $('#divGULF_EXPERIENCE').html("0 year, 0 month, and 0 day");
                    }

                    $("#tblWorkExpDetails").append(row);
                    $(".user-experience").modal("hide");
                    $("#divSuccessMsg").show();
                }
                else if (d.CONDITIONAL_OPERATOR === "UPDATE_DOCUMENT_DETAILS") {
                    $("#tblDocumentDetails").empty();
                    var serverpath = "/Medical/Download?filepath=" + d.SERVER_MAP_PATH + "CandidateUploadedFiles\\";
                    var row = "";
                    _.each(d.LST_USER_DOCUMENT, function (value) {
                        var docname = value.DOCUMENT_PATH.substr(15);
                        row += "<tr id ='tr_doc_" + value.DOCUMENT_ID + "'><td>" + value.DOCUMENT_TYPE_ID + "</td><td class='document-path'><a href='" + serverpath + value.DOCUMENT_PATH + "'>" + docname + "</a> </td></tr>";
                    });

                    $("#tblDocumentDetails").append(row);
                    $(".user-documents").modal("hide");
                    $("#divSuccessMsg").show();
                }
                else if (d.CONDITIONAL_OPERATOR === "UPDATE_PROCESS_MEDICAL") {
                    $("#divMEDICAL_STATUS").html(d.Medical_Details.STATUS_NAME);
                    $("#divReportDate").html(ConvertJsonDate(d.Medical_Details.CheckupDate));
                    $("#divDoctorName").html(d.Medical_Details.DoctorName);
                    $("#divTokenNumber").html(d.Medical_Details.TokenNumber);
                    $("#MEDICAL_ID").val(d.Medical_Details.MedicalId);

                    $(".medical-status").modal("hide");
                    $("#divSuccessMsg").show();
                }
                else if (d.CONDITIONAL_OPERATOR === "UPDATE_PROCESS_MOFA") {
                    $("#divMOFA_NO").html(d.MOFA_Details.MofaNumber);
                    $("#divMOFA_DATE").html(ConvertJsonDate(d.MOFA_Details.MofaDate));
                    $("#divAPPLICATION_NO").html(d.MOFA_Details.ApplicationNumber);
                    $("#divAPPLICATION_DATE").html(ConvertJsonDate(d.MOFA_Details.ApplicationDate));
                    $("#divHealthNumber").html(d.MOFA_Details.HealthNumber);
                    $("#divHealthDate").html(ConvertJsonDate(d.MOFA_Details.HealthDate));
                    $("#divDDNumber").html(d.MOFA_Details.DDNumber);
                    $("#divDDDate").html(ConvertJsonDate(d.MOFA_Details.DDDate));
                    $("#MOFA_ID").val(d.MOFA_Details.MofaID);

                    $(".mofa-status").modal("hide");
                    $("#divSuccessMsg").show();
                }
                else if (d.CONDITIONAL_OPERATOR === "UPDATE_PROCESS_VISA_ENDORSEMENT") {
                    $("#divVisaSubmissionStatus").html(d.VisaEndorsement_Details.VisaSubmissionStatus);
                    $("#divSubmissionDate").html(ConvertJsonDate(d.VisaEndorsement_Details.SubmissionDate));
                    $("#VISAENDORSEMENT_ID").val(d.VisaEndorsement_Details.VisaEndorsementId);

                    $(".visa-status").modal("hide");
                    $("#divSuccessMsg").show();
                }
                else if (d.CONDITIONAL_OPERATOR === "UPDATE_PROCESS_EMIGRATION") {
                    $("#EMIGRATION_ID").val(d.Emigration_Details.EMIGRATION_ID);
                    $("#divFE_NO").html(d.Emigration_Details.FE_NO);
                    $("#divPT_NO").html(d.Emigration_Details.PT_NO);
                    $("#divDM_NO").html(d.Emigration_Details.DM_NO);
                    $("#divDM_DATE").html(ConvertJsonDate(d.Emigration_Details.DM_DATE));
                    $("#divPOLICY_NO").html(d.Emigration_Details.POLICY_NO);
                    $("#divPOLICY_DATE").html(ConvertJsonDate(d.Emigration_Details.POLICY_DATE));
                    $("#divPOLICY_COMPANYNAME").html(d.Emigration_Details.POLICY_COMPANYNAME);
                    $("#divSUBMISSION_DATE").html(ConvertJsonDate(d.Emigration_Details.SUBMISSION_DATE));
                    $("#divEMIGRATION_CLEARANCENO").html(d.Emigration_Details.EMIGRATION_CLEARANCENO);
                    $("#divPOE").html(d.Emigration_Details.POE);
                    $("#divREMARK").html(d.Emigration_Details.REMARK);

                    $(".emigration-status").modal("hide");
                    $("#divSuccessMsg").show();
                }
                else if (d.CONDITIONAL_OPERATOR === "UPDATE_PROCESS_TICKET") {
                    $("#divTRAVEL_STATUS").html(d.Ticket_Details.TravelStatus);
                    $("#divTRAVEL_DATE").html(ConvertJsonDate(d.Ticket_Details.DepartureDate));
                    $("#divPNR_NO").html(d.Ticket_Details.PnrNumber);
                    $("#divAIRLINES").html(d.Ticket_Details.AirlinesName);
                    $("#divDESTINATION_PLACE").html(d.Ticket_Details.DestinationCity);
                    $("#divDESTINATION_TIME").html(d.Ticket_Details.ArrivalTime);
                    $("#TICKET_ID").val(d.Ticket_Details.TicketID);

                    $(".ticket-status").modal("hide");
                    $("#divSuccessMsg").show();
                }

                $("body").scrollTop(0);
                $('#progressBar').hide();
            },
            error: function (error) {
                $("#divSuccessMsg").hide();
                $('#progressBar').hide();
            }
        });
    }

    function convertJSDate(_date) {
        var dsplit = _date.split("/");
        d = new Date(dsplit[2], dsplit[1] - 1, dsplit[0]);
        return d;
    }

    function validateConnectionData() {

        var Conn_PnrNumber = $("#Conn_PnrNumber").val();
        var Conn_Status = $("input[name='Conn_IsBooked']").is(':checked');
        var Departure_Country = $("#Conn_DepartureCountryCode").val();
        var Departure_City = $("#Conn_DepartureCityCode").val();
        var Departure_Date = $("#Conn_DepartureDate").val();
        var Departure_Time = $("#Conn_DepartureTime").val();
        var Destination_Country = $("#Conn_DestinationCountryCode").val();
        var Destination_City = $("#Conn_DestinationCityCode").val();
        var Arrival_Date = $("#Conn_ArivalDate").val();
        var Arrival_Time = $("#Conn_ArrivalTime").val();
        var hasError = false;


        if (Conn_PnrNumber == '') {
            $("#Conn_PnrNumber").after('<span class="error redClass">Please enter Pnr number</span>');
            hasError = true;
        }

        if (!Conn_Status) {
            $($("input[name='Conn_IsBooked']")[1]).after('<span class="error redClass">Please select either options</span>');
            hasError = true;
        }

        if (Departure_Country == '') {
            $("#Conn_DepartureCountryCode").after('<span class="error redClass">Please select departure country</span>');
            hasError = true;
        }
        if (Departure_City == '') {
            $("#Conn_DepartureCityCode").after('<span class="error redClass">Please select departure city</span>');
            hasError = true;
        }

        if (Departure_Date == '') {
            $("#Conn_DepartureDate").after('<span class="error redClass">Please select departure date</span>');
            hasError = true;
        }

        if (Departure_Time == '') {
            $("#Conn_DepartureDate").after('<span class="error redClass">Please enter departure time</span>');
            hasError = true;
        }

        if (Destination_Country == '') {
            $("#Conn_DestinationCountryCode").after('<span class="error redClass">Please select destination country</span>');
            hasError = true;
        }
        if (Destination_City == '') {
            $("#Conn_DestinationCityCode").after('<span class="error redClass">Please select destination city</span>');
            hasError = true;
        }
        if (Arrival_Date == '') {
            $($("#Conn_ArivalDate")).after('<span class="error redClass">Please enter arrival date</span>');
            hasError = true;
        }
        if (Arrival_Time == '') {
            $("#Conn_ArrivalTime").after('<span class="error redClass">Please enter arrival date</span>');
            hasError = true
        }
        return hasError;
    }

    function validatDirectData() {

        var Airline_id = $("#AirlinesID").val();
        var PnrNumber = $("#PnrNumber").val();
        var Status = $("input[name='IsBooked']").is(':checked');
        var Departure_Country = $("#DepartureCountryCode").val();
        var Departure_City = $("#DepartureCityCode").val();
        var Departure_Date = $("#DepartureDate").val();
        var Departure_Time = $("#DepartureTime").val();
        var Destination_Country = $("#DestinationCountryCode").val();
        var Destination_City = $("#DestinationCityCode").val();
        var Arrival_Date = $("#ArivalDate").val();
        var Arrival_Time = $("#ArrivalTime").val();
        var hasError = false;


        if (Airline_id == '') {
            $("#AirlinesID").after('<span class="error redClassForDirect">Please select Airlines</span>');
            hasError = true;
        }

        if (PnrNumber == '') {
            $("#PnrNumber").after('<span class="error redClassForDirect">Please enter pnr number</span>');
            hasError = true;
        }

        if (!Status) {
            $($("input[name='IsBooked']")[1]).after('<span class="error redClassForDirect">Please select either options</span>');
            hasError = true;
        }

        if (Departure_Country == '') {
            $("#DepartureCountryCode").after('<span class="error redClassForDirect">Please select departure country</span>');
            hasError = true;
        }

        if (Departure_City == '') {
            $("#DepartureCityCode").after('<span class="error redClassForDirect">Please select departure city</span>');
            hasError = true;
        }

        if (Departure_Date == '') {
            $("#DepartureDate").after('<span class="error redClassForDirect">Please select departure date</span>');
            hasError = true;
        }

        if (Departure_Time == '') {
            $("#DepartureTime").after('<span class="error redClassForDirect">Please enter departure time</span>');
            hasError = true;
        }

        if (Destination_Country == '') {
            $("#DestinationCountryCode").after('<span class="error redClassForDirect">Please select destination country</span>');
            hasError = true;
        }
        if (Destination_City == '') {
            $("#DestinationCityCode").after('<span class="error redClassForDirect">Please select destination city</span>');
            hasError = true;
        }
        if (Arrival_Date == '') {
            $($("#ArivalDate")).after('<span class="error redClassForDirect">Please enter arrival date</span>');
            hasError = true;
        }
        if (Arrival_Time == '') {
            $("#ArrivalTime").after('<span class="error redClassForDirect">Please enter arrival date</span>');
            hasError = true
        }
        return hasError;
    }
});