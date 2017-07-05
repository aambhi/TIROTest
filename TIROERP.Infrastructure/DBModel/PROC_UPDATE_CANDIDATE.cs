using EntityFrameworkExtras.EF6;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TIROERP.Infrastructure.DBModel;

namespace TIROERP.Infrastructure.DBModel
{
    [StoredProcedure("PROC_UPDATE_CANDIDATE")]
    public class PROC_UPDATE_CANDIDATE
    {
        [StoredProcedureParameter(System.Data.SqlDbType.Udt, ParameterName = "USER_DETAIL")]
        public List<UDT_USER_DETAILS> UDT_USER_DETAIL { get; set; }

        [StoredProcedureParameter(System.Data.SqlDbType.VarChar, ParameterName = "CONDITIONAL_OPERATOR")]
        public string Conditional_Operator { get; set; }

        [StoredProcedureParameter(System.Data.SqlDbType.Udt, ParameterName = "USER_PASSPORT")]
        public List<UDT_USER_PASSPORT> UDT_USER_PASSPORT { get; set; }

        [StoredProcedureParameter(System.Data.SqlDbType.Udt, ParameterName = "USER_DRIVING")]
        public List<UDT_USER_DRIVING> UDT_USER_DRIVING { get; set; }

        [StoredProcedureParameter(System.Data.SqlDbType.Udt, ParameterName = "USER_EDUCATION")]
        public List<UDT_USER_EDUCATION> UDT_USER_EDUCATION { get; set; }

        [StoredProcedureParameter(System.Data.SqlDbType.Udt, ParameterName = "USER_CERTIFICATION")]
        public List<UDT_USER_CERTIFICATION> UDT_USER_CERTIFICATION { get; set; }

        [StoredProcedureParameter(System.Data.SqlDbType.Udt, ParameterName = "USER_ADDRESS")]
        public List<UDT_USER_ADDRESS> UDT_USER_ADDRESS { get; set; }

        [StoredProcedureParameter(System.Data.SqlDbType.Udt, ParameterName = "USER_CONTACT")]
        public List<UDT_USER_CONTACT> UDT_USER_CONTACT { get; set; }

        [StoredProcedureParameter(System.Data.SqlDbType.Udt, ParameterName = "USER_EMAIL")]
        public List<UDT_USER_EMAIL> UDT_USER_EMAIL { get; set; }

        [StoredProcedureParameter(System.Data.SqlDbType.Udt, ParameterName = "USER_DOCUMENTS")]
        public List<UDT_USER_DOCUMENT> UDT_USER_DOCUMENTS { get; set; }

        [StoredProcedureParameter(System.Data.SqlDbType.Udt, ParameterName = "USER_EXPERIENCE")]
        public List<UDT_USER_EXPERIENCE> UDT_USER_EXPERIENCE { get; set; }

        [StoredProcedureParameter(System.Data.SqlDbType.Udt, ParameterName = "USER_LANGUAGES")]
        public List<UDT_USER_LANGUAGE> UDT_USER_LANGUAGE { get; set; }

        [StoredProcedureParameter(System.Data.SqlDbType.Udt, ParameterName = "PROCESS_MEDICAL")]
        public List<UDT_PROCESS_MEDICAL> UDT_PROCESS_MEDICAL { get; set; }

        [StoredProcedureParameter(System.Data.SqlDbType.Udt, ParameterName = "PROCESS_MOFA")]
        public List<UDT_PROCESS_MOFA> UDT_PROCESS_MOFA { get; set; }

        [StoredProcedureParameter(System.Data.SqlDbType.Udt, ParameterName = "PROCESS_VISA_ENDORSEMENT")]
        public List<UDT_PROCESS_VISA_ENDORSEMENT> UDT_PROCESS_VISA_ENDORSEMENT { get; set; }

        [StoredProcedureParameter(System.Data.SqlDbType.Udt, ParameterName = "PROCESS_POLICY")]
        public List<UDT_PROCESS_POLICY> UDT_PROCESS_POLICY { get; set; }

        [StoredProcedureParameter(System.Data.SqlDbType.Udt, ParameterName = "PROCESS_TICKET")]
        public List<UDT_TICKET_DETAILS> UDT_TICKET_DETAILS { get; set; }

        [StoredProcedureParameter(System.Data.SqlDbType.Udt, ParameterName = "PROCESS_EMIGRATION")]
        public List<UDT_PROCESS_EMIGRATION> UDT_PROCESS_EMIGRATION { get; set; }
    }
}
