using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KendoUIApp_Test.Models
{
    using System;
    using System.Collections.Generic;

    public partial class CMDEXAMREPORT
    {
        public string HOSPITAL_ID { get; set; }
        public string PAT_IDNO { get; set; }
        public string REC_NO { get; set; }
        public string EXAM_TYPE { get; set; }
        public string SOURCE { get; set; }
        public string NHI_YM { get; set; }
        public string SECTION { get; set; }
        public string SECTION_NAMEC { get; set; }
        public string MAIN_DIAGNOSIS { get; set; }
        public string MAIN_DIAGNOSIS_NAME { get; set; }
        public string REGION { get; set; }
        public string EXAM_TYPE_CODE { get; set; }
        public string EXAM_TYPE_NAME { get; set; }
        public string NHI_CODE { get; set; }
        public string NHI_NAME { get; set; }
        public string EXAM_NAME { get; set; }
        public string EXAM_PROCEDURE { get; set; }
        public string EXAM_REPORT01 { get; set; }
        public string UNIT { get; set; }
        public string REFERENCE { get; set; }
        public string EXAM_REPORT02 { get; set; }
        public string SPECIMEN { get; set; }
        public string ORDER_DATE { get; set; }
        public string EXECUTE_DATE { get; set; }
        public string REPORT_DATE { get; set; }
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
        public string CERTIFICATION { get; set; }
        public string VIDEO_MATERIAL { get; set; }

        public string HospitalId { get; set; }
        public string SourceId { get; set; }

        public string Text { get; set; }
        public string Value { get; set; }
    }
}
