$(document).ready(function () {
    //Initialise Datepicker
    $("#DATE_OF_BIRTH").datepicker({
        maxDate: "-1D",
        dateFormat: "dd/mm/yy",
        changeMonth: true,
        changeYear: true, yearRange: "-70:+0",
    });

    $(document).on("click", "#submitEmployeeOfficialDetails", function () {

        var BRANCH_CODE = $("#BRANCH_CODE").val();
        var STATUS_ID = $("#STATUS_ID").val();
        var SOURCE_ID = $("#SOURCE_ID").val();
        var OTHER_SOURCE = $("#OTHER_SOURCE").val();
        var REFERRER_NAME = $("#REFERRER_NAME").val();


        var formData = JSON.stringify({

            "SOURCE_ID": SOURCE_ID,
            "OTHER_SOURCE": OTHER_SOURCE,
            "REFERRER_NAME": REFERRER_NAME,
            "STATUS_ID": STATUS_ID,
            "LOGIN_ACCESS": $("#LOGIN_ACCESS").val() === "" ? false : true,
            "BRANCH_CODE": $("#BRANCH_CODE").val(),

            "REGISTRATION_NO": $("#REGISTRATION_NO").val(),
            "CONDITIONAL_OPERATOR": "UPDATE_OFFICIAL_DETAILS"
        });

        var isValidated = validateOfficialDetails();

        if (isValidated) {
            callAjaxFunctionAndLoadData(formData);
        }
        return false;

    });

    function validateOfficialDetails() {

        var isStepValid = true;

        // all step validation logic

        var branch = $("#BRANCH_CODE").val();
        if (branch == "") {
            $("#ErrItem_BRANCH_CODE").text("Please select Branch");
            isStepValid = false;
        }
        else {
            $("#ErrItem_BRANCH_CODE").text("");
        }

        var source = $("#SOURCE_ID").val();
        if (source == "") {
            $("#ErrItem_SOURCE_ID").text("Please select Source");
            isStepValid = false;
        }
        else {
            $("#ErrItem_SOURCE_ID").text("");
        }

        var status = $("#STATUS_ID").val();
        if (status == "") {
            $("#ErrItem_STATUS_ID").text("Please select Status");
            isStepValid = false;
        }
        else {
            $("#ErrItem_STATUS_ID").text("");
        }

        return isStepValid;
    }

    //save education details
    $(document).on("click", "#submitEducationDetails", function () {

        var formData = JSON.stringify({
            "LST_USER_EDUCATION": educationCollection,
            "REGISTRATION_NO": $("#REGISTRATION_NO").val(),
            "CONDITIONAL_OPERATOR": "UPDATE_EDUCATION_DETAILS"
        });

        callAjaxFunctionAndLoadData(formData);
        return false;
    });

    //update personal info
    $(document).on("click", "#UpdatePersonalDetails", function () {
        //fetch all values
        var formData = JSON.stringify({
            "FIRST_NAME": $("#FIRST_NAME").val(),
            "MIDDLE_NAME": $("#MIDDLE_NAME").val(),
            "LAST_NAME": $("#LAST_NAME").val(),
            "FILE_PATH": $("#FILE_PATH").val(),

            "FATHER_NAME": $("#FATHER_NAME").val(),
            "MOTHER_NAME": $("#MOTHER_NAME").val(),
            "GENDER_CODE": $("#GENDER_CODE").val(),
            "DATE_OF_BIRTH": $("#DATE_OF_BIRTH").val(),
            "PLACE_OF_BIRTH": $("#PLACE_OF_BIRTH").val(),
            "MARITAL_STATUS_ID": $("#MARITAL_STATUS_ID").val(),
            "NATIONALITY_ID": $("#NATIONALITY_ID").val(),
            "CURRENT_LOCATION": $("#CURRENT_LOC").val(),

            "RELIGION_ID": $("#RELIGION_ID").val(),
            "REGISTRATION_NO": $("#REGISTRATION_NO").val(),
            "CONDITIONAL_OPERATOR": "UPDATE_PERSONAL_DETAILS"
        });

        callAjaxFunctionAndLoadData(formData);
        return false;
    });

    //save certification details
    $(document).on("click", "#submitCertificationDetails", function () {
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
        var isStepValid = true;
        var tbladdresscount = $('#tblchild').children().length;
        if (tbladdresscount < 1) {
            $("#Err_ADDRESS_TYPE_ID").text("Please select Address Type");
            $("#Err_ADDRESS").text("Please enter Address details");
            $("#Err_COUNTRY_CODE").text("Please select Country");
            $("#Err_STATE_CODE").text("Please select State");
            $("#Err_CITY_CODE").text("Please select City");
            $("#Err_USER_PINCODE").text("Please enter Pin Code");
            isStepValid = false;
        }

        var tblcontactcount = $('#tblcontact').children().length;
        if (tblcontactcount < 1) {
            $("#Err_CONTACT_TYPE_ID").text("Please select Contact Type");
            $("#Err_CONTACT_NO").text("Please enter Contact no.");
            isStepValid = false;
        }

        if (isStepValid) {

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
        return false;
    })

    //save document details
    $(document).on("click", "#submitDocumentDetails", function () {

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



    function callAjaxFunctionAndLoadData(formData) {
        var urlPath = "/StatusSearch/Update";
        $.ajax({
            url: urlPath,
            data: formData,
            type: 'POST',
            contentType: "application/json",
            traditional: true,
            success: function (d) {
                if (d.CONDITIONAL_OPERATOR === "UPDATE_PERSONAL_DETAILS") {
                    $("#divREGISTRATION_NO").html(d.REGISTRATION_NO);
                    $("#divREGISTRATION_DATE").html(ConvertJsonDate(d.REGISTRATION_DATE));
                    $("#divCANDIDATE_NAME").html(d.CANDIDATE_NAME);
                    $("#divPASSPORT_NUMBER").html(d.PASSPORT_NUMBER);
                    $("#divContact_No").html(d.Contact_No);
                    $("#divUSER_EMAIL").html(d.USER_EMAIL);
                    $("#divDOB").html(ConvertJsonDate(d.DATE_OF_BIRTH));
                    $("#divCURRENT_AGE").html(d.Age);

                    if (d.FILE_PATH !== null && d.FILE_PATH.length > 0) {
                        var fullFilePath = '/Uploads/EmployeeUploadedFiles/' + d.FILE_PATH;
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
                        $(".image-div").remove();
                        $("#imageUploadDiv").append("<img src = '/Uploads/CandidateUploadedFiles/no_img.png'/>");
                    }

                    $(".personal-details").modal("hide");
                    $("#divSuccessMsg").show();
                }
                else if (d.CONDITIONAL_OPERATOR === "UPDATE_CONTACT_DETAILS") {

                    $("#tblAddDetails").empty();
                    //Address Details Bind
                    var row = "";
                    _.each(d.LST_USER_ADDRESS, function (value) {
                        row += "<tr id ='tr_add_" + value.ADDRESS_TYPE_ID + "'><td><span class='user-address'>" + value.ADDRESS + "</span></td><td>" + value.USER_COUNTRY + "</td><td>" + value.USER_STATE + "-" + value.USER_CITY + "</td><td>" + value.USER_VILLAGE + "</td><td>" + value.USER_PINCODE + "</td> "

                        $("#divContact_No").html(value.Contact_No);
                        $("#divUSER_EMAIL").html(value.USER_EMAIL);
                    });
                    $("#tblAddDetails").append(row);

                    $(".contact_details").modal("hide");
                    $("#divSuccessMsg").show();
                }
                else if (d.CONDITIONAL_OPERATOR === "UPDATE_OFFICIAL_DETAILS") {

                    //bind data of view
                    $(".source-name").text(d.SOURCE_NAME);
                    $(".branch-name").text(d.BRANCH_NAME);
                    $(".status-name").text(d.STATUS_NAME);

                    //Binding to Modal Popup
                    bindDetailsToOfficialDetailsPopup(d);

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
                    var row = "";
                    _.each(d.LST_USER_EDUCATION, function (value) {
                        var highestqual = "No";
                        if (value.IS_HIGHEST_QUALIFICATION != null)
                            highestqual = "Yes";
                        row += "<tr id ='tr_edu_" + value.EDUCATION_TYPE_ID + "'><td>" + value.EDUCATION_TYPE + "</td><td>" + value.SPECIALIZATION_TYPE + "</td><td>" + value.UNIVERSITY_ID + "</td><td>" + value.UNIVERSITY_YEAR_OF_PASSING + "</td><td>" + highestqual + "</td></tr>";
                    });
                    $("#tblEducationDetails").append(row);

                    $(".education-details").modal("hide");
                    $("#divSuccessMsg").show();
                }
                else if (d.CONDITIONAL_OPERATOR === "UPDATE_EXPERIENCE_DETAILS") {
                    $("#tblWorkExpDetails").empty();
                    var row = "";
                    _.each(d.LST_USER_EXPERIENCE, function (value) {
                        row += "<tr id ='tr_exp_" + value.EXPERIENCE_ID + "'><td class='company-name'>" + value.COMPANY_NAME + "<input type='hidden' class='user_company_name' value='" + value.USER_COMPANY_NAME + "' /></td><td>" + value.DESIGNATION + "</td>";
                        row += "<td>" + value.INDUSTRY_TYPE + "</td><td data-work-period-from = '" + ConvertJsonDate(value.WORK_PERIOD_FROM) + "'>" + ConvertJsonDate(value.WORK_PERIOD_FROM) + "-" + ConvertJsonDate(value.WORK_PERIOD_TO) + "</td>";
                        row += "<td>" + value.STATE_NAME + "-" + value.CITY_NAME + "</td></tr>";

                        $('#divTOTAL_EXPERIENCE').html(value.TOTAL_WORK_EXPERIENCE);
                        $('#divGULF_EXPERIENCE').html(value.TOTAL_GULF_EXPERIENCE);
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
                    var serverpath = "/Medical/Download?filepath=" + d.SERVER_MAP_PATH + "EmployeeUploadedFiles\\";
                    var row = "";
                    _.each(d.LST_USER_DOCUMENT, function (value) {
                        var docname = value.DOCUMENT_PATH.substr(15);
                        row += "<tr id ='tr_doc_" + value.DOCUMENT_ID + "'><td>" + value.DOCUMENT_TYPE_ID + "</td><td class='document-path'><a href='" + serverpath + value.DOCUMENT_PATH + "'>" + docname + "</a> </td></tr>";
                    });

                    $("#tblDocumentDetails").append(row);
                    $(".user-documents").modal("hide");
                    $("#divSuccessMsg").show();
                }
            },
            error: function (error) {
                $("#divSuccessMsg").hide();
            }
        });
    }

    //Popup fields
    function bindDetailsToOfficialDetailsPopup(result) {
        $("#BRANCH_CODE").val(result.BRANCH_CODE);
        $("#STATUS_ID").val(result.STATUS_ID);
        $("#SOURCE_ID").val(result.SOURCE_ID).trigger('change', result.OTHER_SOURCE);
        $("#REFERRER_NAME").val(result.REFERRER_NAME);
    }

});