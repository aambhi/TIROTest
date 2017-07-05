using EntityFrameworkExtras.EF6;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TIROERP.Infrastructure.DBModel
{

    [StoredProcedure("PROC_INSERT_TICKET_DETAILS")]
    public class proc_Insert_Ticket_Details
    {
        [StoredProcedureParameter(System.Data.SqlDbType.Udt, ParameterName = "TicketDetails")]
        public List<UDT_TICKET_DETAILS> UDT_TICKET_DETAILS { get; set; }

        [StoredProcedureParameter(System.Data.SqlDbType.VarChar, ParameterName = "CONDITION_OPERATOR")]
        public String CONDITION_OPERATOR { get; set; }

    }
}
