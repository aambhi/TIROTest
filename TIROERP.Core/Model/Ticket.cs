using System;
using System.ComponentModel.DataAnnotations;

namespace TIROERP.Core.Model
{
    public class Ticket
    {
        public int TicketID { get; set; }

        [Required(ErrorMessage = "Please select passport")]
        public int USER_REQUIREMENT_ID { get; set; }
        public int? AirlinesID { get; set; }

        [MaxLength(50, ErrorMessage = "Length should not be more than 50 characters")]
        public string OtherAirlines { get; set; }

        [Required(ErrorMessage = "Please select Ticket Type options")]
        public string IsDirect { get; set; }

        [MaxLength(20, ErrorMessage = "Length should not be more than 20 characters")]
        [Required(ErrorMessage = "Please enter your PNR number")]
        public string PnrNumber { get; set; }

        [MaxLength(20, ErrorMessage = "Length should not be more than 20 characters")]
        public string TicketNumber { get; set; }

        [MaxLength(20, ErrorMessage = "Length should not be more than 20 characters")]
        public string FlightNumber { get; set; }
        public string IsBooked { get; set; }
        public string IsCancelled { get; set; }

        [Required(ErrorMessage = "Please select departure country")]
        public string DepartureCountryCode { get; set; }

        [Required(ErrorMessage = "Please select departure city")]
        public string DepartureCityCode { get; set; }

        [Required(ErrorMessage = "Please enter departure date")]
        public string DepartureDate { get; set; }

        [Required(ErrorMessage = "Please select departure time")]
        public string DepartureTime { get; set; }

        [Required(ErrorMessage = "Please select destination country")]
        public string DestinationCountryCode { get; set; }

        [Required(ErrorMessage = "Please select destination city")]
        public string DestinationCityCode { get; set; }

        [Required(ErrorMessage = "Please enter arrival date")]
        public string ArivalDate { get; set; }

        [Required(ErrorMessage = "Please enter arrival time")]
        public string ArrivalTime { get; set; }
        public string ReportPath { get; set; }
        public string Remark { get; set; }
        public string createdBy { get; set; }
        public DateTime? CreatedDate { get; set; }

        public int? ConnectTicketID { get; set; }

        [MaxLength(20, ErrorMessage = "Length should not be more than 20 characters")]
        public string Conn_PnrNumber { get; set; }

        [MaxLength(20, ErrorMessage = "Length should not be more than 20 characters")]
        public string Conn_TicketNumber { get; set; }

        [MaxLength(20, ErrorMessage = "Length should not be more than 20 characters")]
        public string Conn_FlightNumber { get; set; }
        public string Conn_IsBooked { get; set; }
        public string Conn_IsCancelled { get; set; }

        public string Conn_DestinationCountryCode { get; set; }
        public string Conn_ArivalDate { get; set; }
        public string Conn_DepartureCityCode { get; set; }
        public string Conn_DepartureDate { get; set; }
        public string Conn_DepartureTime { get; set; }
        public string Conn_DepartureCountryCode { get; set; }
        //public DateTime? Conn_ArrivalDate { get; set; }
        public string Conn_ArrivalTime { get; set; }
        public DateTime? Conn_CreatedDate { get; set; }
        public string Conn_CreatedBy { get; set; }
        public string Conn_DestinationCityCode { get; set; }

        public string TravelStatus { get; set; }
        public string AirlinesName { get; set; }
        public string DestinationCity { get; set; }
        public string DepartureCity { get; set; }
        public string CANDIDATE_NAME { get; set; }
        public string REGISTRATION_NO { get; set; }
        public string PASSPORT_NUMBER { get; set; }
    }
}