using EntityFrameworkExtras.EF6;
using System;

namespace TIROERP.Infrastructure.DBModel
{
    [UserDefinedTableType("UDT_USER_DRIVING")]
    public class UDT_USER_DRIVING
    {
        [UserDefinedTableTypeColumn(1)]
        public string DRIVING_LICENCE_NUMBER { get; set; }

        [UserDefinedTableTypeColumn(2)]
        public DateTime? DATE_OF_ISSUE { get; set; }

        [UserDefinedTableTypeColumn(3)]
        public string PLACE_OF_ISSUE { get; set; }

        [UserDefinedTableTypeColumn(4)]
        public DateTime? DATE_OF_EXPIRY { get; set; }

        [UserDefinedTableTypeColumn(5)]
        public int? VEHICLE_TYPE_ID { get; set; }

        [UserDefinedTableTypeColumn(6)]
        public string CREATED_BY { get; set; }

        [UserDefinedTableTypeColumn(7)]
        public string MODIFIED_BY { get; set; }

        [UserDefinedTableTypeColumn(8)]
        public string REMARK { get; set; }

        [UserDefinedTableTypeColumn(9)]
        public string REGISTRATION_NO { get; set; }

        [UserDefinedTableTypeColumn(10)]
        public int DRIVING_LICENCE_ID { get; set; }
        

    }
}
