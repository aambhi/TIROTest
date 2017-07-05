using EntityFrameworkExtras.EF6;

namespace TIROERP.Infrastructure.DBModel
{
    [UserDefinedTableType("UDT_USER_DOCUMENT")]
    public class UDT_USER_DOCUMENT
    {
        [UserDefinedTableTypeColumn(1)]
        public string DOCUMENT_TYPE_ID { get; set; }

        [UserDefinedTableTypeColumn(2)]
        public string DOCUMENT_PATH { get; set; }

        [UserDefinedTableTypeColumn(3)]
        public string CREATED_BY { get; set; }

        [UserDefinedTableTypeColumn(4)]
        public string MODIFIED_BY { get; set; }

		[UserDefinedTableTypeColumn(5)]
        public string REGISTRATION_NO { get; set; }

        [UserDefinedTableTypeColumn(6)]
        public int DOCUMENT_ID { get; set; }

        [UserDefinedTableTypeColumn(7)]
        public bool ISNEW { get; set; }

    }
}
