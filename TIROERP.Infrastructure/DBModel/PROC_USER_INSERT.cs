using EntityFrameworkExtras.EF6;
using System.Collections.Generic;

namespace TIROERP.Infrastructure.DBModel
{
    [StoredProcedure("PROC_USER_INSERT")]
    public class PROC_USER_INSERT
    {
        [StoredProcedureParameter(System.Data.SqlDbType.Int, ParameterName = "USER_TYPE_ID")]
        public int USER_TYPE_ID { get; set; }

        [StoredProcedureParameter(System.Data.SqlDbType.Udt, ParameterName = "USER_DETAIL")]
        public List<UDT_USER_DETAILS> UDT_USER_DETAIL { get; set; }

        [StoredProcedureParameter(System.Data.SqlDbType.Udt, ParameterName = "USER_EMAIL")]
        public List<UDT_USER_EMAIL> UDT_USER_EMAIL { get; set; }

        [StoredProcedureParameter(System.Data.SqlDbType.Udt, ParameterName = "USER_CONTACT")]
        public List<UDT_USER_CONTACT> UDT_USER_CONTACT { get; set; }

        [StoredProcedureParameter(System.Data.SqlDbType.Udt, ParameterName = "USER_ADDRESS")]
        public List<UDT_USER_ADDRESS> UDT_USER_ADDRESS { get; set; }

        [StoredProcedureParameter(System.Data.SqlDbType.Udt, ParameterName = "USER_EDUCATION")]
        public List<UDT_USER_EDUCATION> UDT_USER_EDUCATION { get; set; }

        [StoredProcedureParameter(System.Data.SqlDbType.Udt, ParameterName = "USER_CERTIFICATION")]
        public List<UDT_USER_CERTIFICATION> UDT_USER_CERTIFICATION { get; set; }

        [StoredProcedureParameter(System.Data.SqlDbType.Udt, ParameterName = "USER_EXPERIENCE")]
        public List<UDT_USER_EXPERIENCE> UDT_USER_EXPERIENCE { get; set; }

        [StoredProcedureParameter(System.Data.SqlDbType.Udt, ParameterName = "USER_DOCUMENT")]
        public List<UDT_USER_DOCUMENT> UDT_USER_DOCUMENT { get; set; }

        [StoredProcedureParameter(System.Data.SqlDbType.Udt, ParameterName = "USER_PASSPORT")]
        public List<UDT_USER_PASSPORT> UDT_USER_PASSPORT { get; set; }

        [StoredProcedureParameter(System.Data.SqlDbType.Udt, ParameterName = "USER_DRIVING")]
        public List<UDT_USER_DRIVING> UDT_USER_DRIVING { get; set; }

        [StoredProcedureParameter(System.Data.SqlDbType.Udt, ParameterName = "USER_LANGUAGE")]
        public List<UDT_USER_LANGUAGE> UDT_USER_LANGUAGE { get; set; }

    }
}
