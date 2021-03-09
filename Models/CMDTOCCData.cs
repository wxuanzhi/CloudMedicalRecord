using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KendoUIApp_Test.Models
{

    public partial class CMDTOCC
    {
        public string HOSPITAL_ID { get; set; }
        public string PAT_IDNO { get; set; }
        public string TOCCMSG { get; set; }
        public string CANCEL_YN { get; set; }
        public string CANCEL_DTTM { get; set; }
        public string CANCEL_USER_ID { get; set; }
        public string CANCEL_NAMEC { get; set; }
        public string PROC_DTTM { get; set; }
        public string PROC_USER_ID { get; set; }
        public string PROC_NAMEC { get; set; }
        public string CREATE_DTTM { get; set; }
        public string CREATE_USER_ID { get; set; }
        public string CREATE_NAMEC { get; set; }

        public string HospitalId { get; set; }
        public string PatientId { get; set; }
        public string CountryId { get; set; }

        public string Text { get; set; }
        public string Value { get; set; }
    }
}
