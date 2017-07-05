using EntityFrameworkExtras.EF6;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TIROERP.Infrastructure.DBModel
{
    [UserDefinedTableType("UDT_TICKET_DETAILS")]
    public class UDT_TICKET_DETAILS
    {

        [UserDefinedTableTypeColumn(1)]
        public int? USER_REQUIREMENT_ID { get; set; }

        [UserDefinedTableTypeColumn(2)]
        public int? AirlinesID { get; set; }

        [UserDefinedTableTypeColumn(3)]
        public bool? IsDirect { get; set; }

        [UserDefinedTableTypeColumn(4)]
        public string PnrNumber { get; set; }

        [UserDefinedTableTypeColumn(5)]
        public string TicketNumber { get; set; }

        [UserDefinedTableTypeColumn(6)]
        public string FlightNumber { get; set; }

        [UserDefinedTableTypeColumn(7)]
        public bool? IsBooked { get; set; }

        [UserDefinedTableTypeColumn(8)]
        public bool? IsCancelled { get; set; }

        [UserDefinedTableTypeColumn(9)]
        public string DepartureCityCode { get; set; }

        [UserDefinedTableTypeColumn(10)]
        public DateTime? DepartureDate { get; set; }

        [UserDefinedTableTypeColumn(11)]
        public string DepartureTime { get; set; }

        [UserDefinedTableTypeColumn(12)]
        public string DestinationCityCode { get; set; }

        [UserDefinedTableTypeColumn(13)]
        public DateTime? ArivalDate { get; set; }

        [UserDefinedTableTypeColumn(14)]
        public string ArrivalTime { get; set; }

        [UserDefinedTableTypeColumn(15)]
        public string ReportPath { get; set; }

        [UserDefinedTableTypeColumn(16)]
        public string Remark { get; set; }

        [UserDefinedTableTypeColumn(17)]
        public string createdBy { get; set; }

        [UserDefinedTableTypeColumn(18)]
        public string Conn_PnrNumber { get; set; }

        [UserDefinedTableTypeColumn(19)]
        public string Conn_TicketNumber { get; set; }

        [UserDefinedTableTypeColumn(20)]
        public string Conn_FlightNumber { get; set; }

        [UserDefinedTableTypeColumn(21)]
        public bool? Conn_IsBooked { get; set; }

        [UserDefinedTableTypeColumn(22)]
        public bool? Conn_IsCancelled { get; set; }

        [UserDefinedTableTypeColumn(23)]
        public string Conn_DepartureCityCode { get; set; }

        [UserDefinedTableTypeColumn(24)]
        public DateTime? Conn_DepartureDate { get; set; }

        [UserDefinedTableTypeColumn(25)]
        public string Conn_DepartureTime { get; set; }

        [UserDefinedTableTypeColumn(26)]
        public string Conn_DestinationCityCode { get; set; }

        [UserDefinedTableTypeColumn(27)]
        public DateTime? Conn_ArivalDate { get; set; }

        [UserDefinedTableTypeColumn(28)]
        public string Conn_ArrivalTime { get; set; }

        [UserDefinedTableTypeColumn(29)]
        public int TicketId { get; set; }
    }
}
