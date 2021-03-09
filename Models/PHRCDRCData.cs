using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KendoUIApp_Test.Models
{

    public partial class PHRCDRC
    {
        public string HOSPITAL_ID { get; set; }
        public string PAT_IDNO { get; set; }
        public string REC_NO { get; set; }
        public string CASE_NO { get; set; }
        public string DRUGSOURCE { get; set; }
        public string UDDATC { get; set; }
        public string UDDATCNM { get; set; }
        public string DRUGCOMPCODE { get; set; }
        public string DRUGCOMPCODENM { get; set; }
        public string UDNNHICODE { get; set; }
        public string UDDMDPNAME { get; set; }
        public string BEGIN_DT { get; set; }
        public string END_DT { get; set; }
        public string DSPQTY { get; set; }
        public string DAYS { get; set; }
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
        public string MAIN_DIAGNOSIS { get; set; }
        public string ROUTE { get; set; }
        public string DOSEUNIT { get; set; }
        public string COMPLEX_MARK { get; set; }
        public string INSULOOKSEQ { get; set; }
        public string HOSPITAL_ID_ORI { get; set; }
        public string HOSPITAL_SNAME_ORI { get; set; }
        public string ATC3_NAME { get; set; }
        public string HOSPITAL_ID_CHRONIC { get; set; }
        public string HOSPITAL_SNAME_CHRONIC { get; set; }

        public string HospitalId { get; set; }
        public string DrugSourceId { get; set; }
        public string ID { get; set; }

        public string Text { get; set; }
        public string Value { get; set; }
    }
}
