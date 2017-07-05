
$(document).ready(function () {
    $(document).on("click", "#SaveRequirement", function () {
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
            return true;
        }

    });

    $(document).on("change", "#directConn", function () {
        $("#directConn").attr("checked", "true");

    });

    $(document).on("change", "#IsDirect", function () {
        $("#directConn").attr("checked", "false");

    });


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

        var Passport_id = $("#USER_REQUIREMENT_ID").val();
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


        if (Passport_id == '') {
            $("#USER_REQUIREMENT_ID").after('<span class="error redClassForDirect">Please select passport number</span>');
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