﻿using EntityFrameworkExtras.EF6;
using System;

namespace TIROERP.Infrastructure.DBModel
{
    [UserDefinedTableType("UDT_USER_PASSPORT")]
    public class UDT_USER_PASSPORT
    {
        [UserDefinedTableTypeColumn(1)]
        public string PASSPORT_NUMBER { get; set; }

        [UserDefinedTableTypeColumn(2)]
        public DateTime? DATE_OF_ISSUE { get; set; }

        [UserDefinedTableTypeColumn(3)]
        public string PLACE_OF_ISSUE { get; set; }

        [UserDefinedTableTypeColumn(4)]
        public DateTime? DATE_OF_EXPIRY { get; set; }

        [UserDefinedTableTypeColumn(5)]
        public bool? EMIGRATION_CLEARANCE_REQUIRED { get; set; }

        [UserDefinedTableTypeColumn(6)]
        public string CREATED_BY { get; set; }

        [UserDefinedTableTypeColumn(7)]
        public string MODIFIED_BY { get; set; }

        [UserDefinedTableTypeColumn(8)]
        public int PASSPORT_ID { get; set; }

        [UserDefinedTableTypeColumn(9)]
        public string REGISTATION_NUMBER { get; set; }
    }
}
