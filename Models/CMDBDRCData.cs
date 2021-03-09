using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KendoUIApp_Test.Models
{

    public partial class CMDBDRC
    {
        public string HOSPITAL_ID { get; set; }
        public string PAT_IDNO { get; set; }
        public string REC_TYPE { get; set; }
        public string REC_NO { get; set; }
        public string SOURCE { get; set; }
        public string NHI_YM { get; set; }
        public string SECTION { get; set; }
        public string SECTION_NAMEC { get; set; }
        public string MAIN_DIAGNOSIS { get; set; }
        public string MAIN_DIAGNOSIS_NAME { get; set; }
        public string REC_CODE { get; set; }
        public string REC_NAME { get; set; }
        public string NHI_CODE { get; set; }
        public string NHI_NAME { get; set; }
        public string REGION { get; set; }
        public string EXECUTE_DATE { get; set; }
        public string REPORT_DATE { get; set; }
        public string QTY { get; set; }
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
        public string ENCNT_DATE_START { get; set; }
        public string ENCNT_DATE_END { get; set; }
        public string HOSPITAL_ID_ORI { get; set; }
        public string HOSPITAL_SNAME_ORI { get; set; }
        public string OPDDATE { get; set; }
        public string TREATMENT_SITE { get; set; }

        public string HospitalId { get; set; }
        public string RECTypeId { get; set; }
        public string SourceId { get; set; }

        public string Text { get; set; }
        public string Value { get; set; }



    }

}