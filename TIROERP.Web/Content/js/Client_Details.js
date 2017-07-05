
$(document).on("click", "#UpdateClientDetails", function () {
    $('#progressBar').show();
    //fetch agent details
    var FIRST_NAME = $("#FIRST_NAME").val();
    var MIDDLE_NAME = $("#MIDDLE_NAME").val();
    var LAST_NAME = $("#LAST_NAME").val();

    var INDUSTRY = $("#INDUSTRY").val();
    var DESIGNATION = $("#DESIGNATION").val();
    var REFERENCE = $("#REFERENCE").val();
    var REMARK = $("#REMARK").val();
    var FILE_PATH = $("#FILE_PATH").val();
    var REGISTRATION_NO = $("#REGISTRATION_NO").val();
    var COMPANY_NAME = $("#COMPANY_NAME").val();
    var CIVILIAN_NO = $("#CIVILIAN_NO").val();

    var formData = JSON.stringify({
        "FIRST_NAME": FIRST_NAME,
        "MIDDLE_NAME": MIDDLE_NAME,
        "LAST_NAME": LAST_NAME,
        "REFERENCE": REFERENCE,
        "REGISTRATION_NO": REGISTRATION_NO,
        "FILE_PATH": FILE_PATH,
        "REMARK": REMARK,
        "INDUSTRY": INDUSTRY,
        "DESIGNATION": DESIGNATION,
        "COMPANY_NAME": COMPANY_NAME,
        "CIVILIAN_NO": CIVILIAN_NO,
        "CONDITIONAL_OPERATOR": "UPDATE_CLIENT_PERSONAL_DETAILS"
    });
    callAjaxFunctionAndLoadData(formData);
    return false;


});

//save contact details
$(document).on("click", "#submitContactDetails", function () {
    $('#progressBar').show();
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
    $('#progressBar').hide();
    return false;
})

function callAjaxFunctionAndLoadData(formData) {

    var urlPath = "/StatusSearch/Update";
    $.ajax({
        url: urlPath,
        data: formData,
        type: 'POST',
        contentType: "application/json",
        traditional: true,
        success: function (d) {
            if (d.CONDITIONAL_OPERATOR === "UPDATE_CLIENT_PERSONAL_DETAILS") {

                //BINDING VIEW PAGE VALUES
                $(".candidate-name").text(d.Candidate_Name);
                if (d.INDUSTRY_TYPE == null) {
                    $(".industry-type").text('');
                } else {
                    $(".industry-type").text(d.INDUSTRY_TYPE);
                }

                if (d.DESIGNATION_NAME == null) {
                    $(".designation-name").text('');
                }
                else {
                    $(".designation-name").text(d.DESIGNATION_NAME);
                }

                if (d.REMARK == null) {
                    $(".remark").text('');
                } else {
                    $(".remark").text(d.REMARK);
                }
                if (d.COMPANY_NAME!=null){
                $(".company-name").text(d.COMPANY_NAME);
                }
                if (d.CIVILIAN_NO != null) {
                    $(".civilian-no").text(d.CIVILIAN_NO);
                }
                if (d.REFERENCE != null) {
                    $(".reference-name").text(d.REFERENCE);
                }
                

                if (d.FILE_PATH !== null && d.FILE_PATH.length > 0) {
                    var fullFilePath = '/Uploads/ClientUploadedFiles/' + d.FILE_PATH;
                    //case when new image is uploaded by user
                    if ($(".image-div").length === 0) {
                        var addNewElement = "<div class='panel-body col-md-3 col-sm-3 image-div' style='padding-left: 50px;'>";
                        addNewElement += "<div class='fileinput fileinput-new' data-provides='fileinput'>";
                        addNewElement += "<img src='" + fullFilePath + "' class='candidate-img agent-img' style='width: 200px; height: 150px;' alt=" + d.Candidate_Name + " />";
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
                }

                
                $(".personal-details").modal("hide");
                $("#divSuccessMsg").show();
            }
            else if (d.CONDITIONAL_OPERATOR === "UPDATE_CONTACT_DETAILS") {
                $("#tblAddDetails").empty();
                //Address Details Bind
                var contactno = "";
                var email = "";
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
            $("body").scrollTop(0);
            $('#progressBar').hide();
        },
        error: function (error) {
            $("#divSuccessMsg").hide();
            $('#progressBar').hide();
        }
    });
}