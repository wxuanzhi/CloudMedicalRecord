using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//
namespace KendoUIApp_Test.Models
{

    public partial class CMDALLERGY
    {
        public string HOSPITAL_ID { get; set; }
        public string PAT_IDNO { get; set; }
        public string REC_NO { get; set; }
        public string UPLOAD_DTTM { get; set; }
        public string SOURCE { get; set; }
        public string SOURCE_IDNO { get; set; }
        public string UPLOAD_MARK { get; set; }
        public string DRUG { get; set; }
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
        public string HOSPITAL_ID_ORI { get; set; }
        public string HOSPITAL_SNAME_ORI { get; set; }

        public string HospitalId { get; set; }
        public string SourceId { get; set; }
        public string AllergyDrugId { get; set; }

        public string Text { get; set; }
        public string Value { get; set; }
    }
}