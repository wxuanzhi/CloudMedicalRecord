using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;


namespace KendoUIApp_Test.Models
{
    public class CodeService
    {

        /*
         * 連接Sql Server
         */
        private string GetDBConnectionString()
        {
            return System.Configuration.ConfigurationManager.ConnectionStrings["DBConn"].ConnectionString.ToString();
        }

        /*
         * Chart
         */

        ///<summary>
        ///程式說明：取得PHRCDRC BEGIN_DT.END_DT，用在餘藥Chart
        ///</summary>
        public List<Models.ChartModel> GetPHRCDRCBarChart()
        {
            List<Models.ChartModel> result = new List<ChartModel>();
            DataTable dt = new DataTable();
            string sql = $@"SELECT  DRUGCOMPCODENM,
                                    PAT_IDNO AS PAT_IDNO,
                                    CAST(SYSDATETIME() AS date) as TODAY,
                                    CAST(BEGIN_DT as date)as DateBEGIN,
                              DATEADD(day,CAST(DAYS AS int),CAST(BEGIN_DT AS date))AS FINISHDRUG,
                              CASE 
                              WHEN  datediff(day,CAST(SYSDATETIME() AS date),DATEADD(day,CAST(DAYS AS int),CAST(BEGIN_DT AS date))) <0 THEN 0
                              ELSE  datediff(day,CAST(SYSDATETIME() AS date),DATEADD(day,CAST(DAYS AS int),CAST(BEGIN_DT AS date))) 
                              END REMAIN
                              FROM PHRCDRC ;
                                   ;";

            using (SqlConnection conn = new SqlConnection(this.GetDBConnectionString()))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd);
                sqlAdapter.Fill(dt);
                conn.Close();
            }
            return this.MapPHRCDRCBarChart(dt);
        }

        ///<summary>
        ///程式說明：取得PHRCDRC BEGIN_DT.END_DT，用在Range Bar Chart
        ///</summary>
        public List<Models.PHRCDRC> GetPHRCDRCChart()
        {
            List<Models.PHRCDRC> result = new List<PHRCDRC>();
            DataTable dt = new DataTable();                                                                
            string sql = $@"select ROW_NUMBER() OVER (ORDER BY DRUGCOMPCODENM) AS ID,
                                   DRUGCOMPCODENM AS DRUGCOMPCODENM,
                                   BEGIN_DT AS BEGIN_DT,
                                   END_DT AS END_DT,
                                   DAYS AS DAYS,
                                   PAT_IDNO AS PAT_IDNO
                                   From PHRCDRC
                                   ;";

            using (SqlConnection conn = new SqlConnection(this.GetDBConnectionString()))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd);
                sqlAdapter.Fill(dt);
                conn.Close();
            }
            return this.MapPHRCDRCChart(dt);
        }


        ///<summary>
        ///程式說明：顯示PHRCDRC Grid
        ///</summary>
        public List<Models.PHRCDRC> GetPHRCDRC()
        {
            List<Models.PHRCDRC> result = new List<PHRCDRC>();
            DataTable dt = new DataTable();
            string sql = $@"SELECT HOS.HospitalName AS HOSPITAL_ID,
							PHRCDRC.PAT_IDNO AS PAT_IDNO,
							PHRCDRC.REC_NO AS REC_NO,
							PHRCDRC.CASE_NO AS CASE_NO,
	                        DRUGSOURCE.DrugSourceName AS DRUGSOURCE,
							PHRCDRC.UDDATC AS UDDATC,
							PHRCDRC.UDDATCNM AS UDDATCNM,
							PHRCDRC.DRUGCOMPCODE AS DRUGCOMPCODE,
							PHRCDRC.DRUGCOMPCODENM AS DRUGCOMPCODENM,
							PHRCDRC.UDNNHICODE AS UDNNHICODE,
							PHRCDRC.UDDMDPNAME AS UDDMDPNAME,
							PHRCDRC.BEGIN_DT AS BEGIN_DT,
							PHRCDRC.END_DT AS END_DT,
							PHRCDRC.DSPQTY AS DSPQTY,
							PHRCDRC.DAYS AS DAYS,
							PHRCDRC.CANCEL_YN AS CANCEL_YN,
							PHRCDRC.CANCEL_DTTM AS CANCEL_DTTM,
							PHRCDRC.CANCEL_USER_ID AS CANCEL_USER_ID,
							PHRCDRC.CANCEL_NAMEC AS CANCEL_NAMEC,
							PHRCDRC.PROC_DTTM AS PROC_DTTM,
							PHRCDRC.PROC_USER_ID AS PROC_USER_ID,
							PHRCDRC.PROC_NAMEC AS PROC_NAMEC,
							PHRCDRC.CREATE_DTTM AS CREATE_DTTM,
							PHRCDRC.CREATE_USER_ID AS CREATE_USER_ID,
							PHRCDRC.CREATE_NAMEC AS CREATE_NAMEC,
							PHRCDRC.MAIN_DIAGNOSIS AS MAIN_DIAGNOSIS,
							PHRCDRC.ROUTE AS ROUTE,
							PHRCDRC.DOSEUNIT AS DOSEUNIT,
							PHRCDRC.COMPLEX_MARK AS COMPLEX_MARK,
							PHRCDRC.INSULOOKSEQ AS INSULOOKSEQ,
							PHRCDRC.HOSPITAL_ID_ORI AS HOSPITAL_ID_ORI,
							PHRCDRC.HOSPITAL_SNAME_ORI AS HOSPITAL_SNAME_ORI,
							PHRCDRC.ATC3_NAME AS ATC3_NAME,
							PHRCDRC.HOSPITAL_ID_CHRONIC AS HOSPITAL_ID_CHRONIC,
							PHRCDRC.HOSPITAL_SNAME_CHRONIC AS HOSPITAL_SNAME_CHRONIC,

							HOS.HospitalId AS HospitalId,
							DRUGSOURCE.DrugSourceId AS DrugSourceId
	                        FROM PHRCDRC PHRCDRC
							JOIN HOSPITAL HOS ON (PHRCDRC.HOSPITAL_ID = HOS.HospitalId)
	                        JOIN DRUGSOURCE DRUGSOURCE ON (DRUGSOURCE.DrugSourceId = PHRCDRC.DRUGSOURCE)
                            order by BEGIN_DT
                           ; ";

            using (SqlConnection conn = new SqlConnection(this.GetDBConnectionString()))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd);
                sqlAdapter.Fill(dt);
                conn.Close();
            }
            return this.MapPHRCDRC(dt);
        }

        ///<summary>
        ///程式說明：顯示CMDTOCC Grid
        ///</summary>
        public List<Models.CMDTOCC> GetCMDTOCC()
        {
            List<Models.CMDTOCC> result = new List<CMDTOCC>();
            DataTable dt = new DataTable();
            string sql = $@"SELECT HOSPITAL.HospitalName AS HOSPITAL_ID,
							CMDTOCC.PAT_IDNO AS PAT_IDNO,
                            CMDTOCC.TOCCMSG AS TOCCMSG,
							CMDTOCC.CANCEL_YN AS CANCEL_YN,
							CMDTOCC.CANCEL_DTTM AS CANCEL_DTTM,
							CMDTOCC.CANCEL_USER_ID AS CANCEL_USER_ID,
							CMDTOCC.CANCEL_NAMEC AS CANCEL_NAMEC,
							CMDTOCC.PROC_DTTM AS PROC_DTTM,
							CMDTOCC.PROC_USER_ID AS PROC_USER_ID,
							CMDTOCC.PROC_NAMEC AS PROC_NAMEC,
							CMDTOCC.CREATE_DTTM AS CREATE_DTTM,
							CMDTOCC.CREATE_USER_ID AS CREATE_USER_ID,
							CMDTOCC.CREATE_NAMEC AS CREATE_NAMEC,
							HOSPITAL.HospitalId AS HospitalId
	                        FROM CMDTOCC CMDTOCC 
	                        JOIN HOSPITAL HOSPITAL ON (CMDTOCC.HOSPITAL_ID = HOSPITAL.HospitalId)
                           ;";

            using (SqlConnection conn = new SqlConnection(this.GetDBConnectionString()))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd);
                sqlAdapter.Fill(dt);
                conn.Close();
            }
            return this.MapCMDTOCC(dt);
        }

        ///<summary>
        ///程式說明：顯示CMDALLERGY Grid
        ///</summary>
        public List<Models.CMDALLERGY> GetCMDALLERGY()
        {
            List<Models.CMDALLERGY> result = new List<CMDALLERGY>();
            DataTable dt = new DataTable();
            string sql = $@"SELECT HOS.HospitalName AS HOSPITAL_ID,
							CMDALLERGY.PAT_IDNO AS PAT_IDNO,
							CMDALLERGY.REC_NO AS REC_NO,
							CMDALLERGY.UPLOAD_DTTM AS UPLOAD_DTTM,
	                        SOURCE.SourceName AS SOURCE,
							CMDALLERGY.SOURCE_IDNO AS SOURCE_IDNO,
							CMDALLERGY.UPLOAD_MARK AS UPLOAD_MARK,
							ALLERGYDRUG.AllergyDrugName AS DRUG,
							CMDALLERGY.CANCEL_YN AS CANCEL_YN,
							CMDALLERGY.CANCEL_DTTM AS CANCEL_DTTM,
							CMDALLERGY.CANCEL_USER_ID AS CANCEL_USER_ID,
							CMDALLERGY.CANCEL_NAMEC AS CANCEL_NAMEC,
							CMDALLERGY.PROC_DTTM AS PROC_DTTM,
							CMDALLERGY.PROC_USER_ID AS PROC_USER_ID,
							CMDALLERGY.PROC_NAMEC AS PROC_NAMEC,
							CMDALLERGY.CREATE_DTTM AS CREATE_DTTM,
							CMDALLERGY.CREATE_USER_ID AS CREATE_USER_ID,
							CMDALLERGY.CREATE_NAMEC AS CREATE_NAMEC,
							CMDALLERGY.HOSPITAL_ID_ORI AS HOSPITAL_ID_ORI,
							CMDALLERGY.HOSPITAL_SNAME_ORI AS HOSPITAL_SNAME_ORI,
							
							HOS.HospitalId AS HospitalId,
							SOURCE.SourceId AS SourceId,
							ALLERGYDRUG.AllergyDrugId AS AllergyDrugId
	                        FROM CMDALLERGY CMDALLERGY
							JOIN HOSPITAL HOS ON (CMDALLERGY.HOSPITAL_ID = HOS.HospitalId)
	                        JOIN SOURCE SOURCE ON (SOURCE.SourceId = CMDALLERGY.SOURCE)
							JOIN ALLERGYDRUG ALLERGYDRUG ON (ALLERGYDRUG.AllergyDrugId = CMDALLERGY.DRUG)
                           ;";

            using (SqlConnection conn = new SqlConnection(this.GetDBConnectionString()))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd);
                sqlAdapter.Fill(dt);
                conn.Close();
            }
            return this.MapCMDALLERGY(dt);
        }

        ///<summary>
        ///程式說明：顯示CMDBDRC Grid
        ///</summary>
        public List<Models.CMDBDRC> GetCMDBDRC()
        {
            List<Models.CMDBDRC> result = new List<CMDBDRC>();
            DataTable dt = new DataTable();
            string sql = $@"SELECT HOS.HospitalName AS HOSPITAL_ID,
							CMDBDRC.PAT_IDNO AS PAT_IDNO,
							RECTYPE.RECTypeName AS REC_TYPE,
							CMDBDRC.REC_NO AS REC_NO,
	                        SOURCE.SourceName AS SOURCE,
							CMDBDRC.NHI_YM AS NHI_YM,
							CMDBDRC.SECTION AS SECTION,
							CMDBDRC.SECTION_NAMEC AS SECTION_NAMEC,
							CMDBDRC.MAIN_DIAGNOSIS AS MAIN_DIAGNOSIS,
							CMDBDRC.MAIN_DIAGNOSIS_NAME AS MAIN_DIAGNOSIS_NAME,
							CMDBDRC.REC_CODE AS REC_CODE,
							CMDBDRC.REC_NAME AS REC_NAME,
							CMDBDRC.NHI_CODE AS NHI_CODE,
							CMDBDRC.NHI_NAME AS NHI_NAME,
							CMDBDRC.REGION AS REGION,
							CMDBDRC.EXECUTE_DATE AS EXECUTE_DATE,
							CMDBDRC.REPORT_DATE AS REPORT_DATE,
							CMDBDRC.QTY AS QTY,
							CMDBDRC.CANCEL_YN AS CANCEL_YN,
							CMDBDRC.CANCEL_DTTM AS CANCEL_DTTM,
							CMDBDRC.CANCEL_USER_ID AS CANCEL_USER_ID,
							CMDBDRC.CANCEL_NAMEC AS CANCEL_NAMEC,
							CMDBDRC.PROC_DTTM AS PROC_DTTM,
							CMDBDRC.PROC_USER_ID AS PROC_USER_ID,
							CMDBDRC.PROC_NAMEC AS PROC_NAMEC,
							CMDBDRC.CREATE_DTTM AS CREATE_DTTM,
							CMDBDRC.CREATE_USER_ID AS CREATE_USER_ID,
							CMDBDRC.CREATE_NAMEC AS CREATE_NAMEC,
							CMDBDRC.ENCNT_DATE_START AS ENCNT_DATE_START,
							CMDBDRC.ENCNT_DATE_END AS ENCNT_DATE_END,
							CMDBDRC.HOSPITAL_ID_ORI AS HOSPITAL_ID_ORI,
							CMDBDRC.HOSPITAL_SNAME_ORI AS HOSPITAL_SNAME_ORI,
							CMDBDRC.OPDDATE AS OPDDATE,
							CMDBDRC.TREATMENT_SITE AS TREATMENT_SITE,
							
							HOS.HospitalId AS HospitalId,
							SOURCE.SourceId AS SourceId,
							RECTYPE.RECTypeId AS RECTypeId
	                        FROM CMDBDRC CMDBDRC
							JOIN HOSPITAL HOS ON (CMDBDRC.HOSPITAL_ID = HOS.HospitalId)
	                        JOIN SOURCE SOURCE ON (SOURCE.SourceId = CMDBDRC.SOURCE)
							JOIN RECTYPE RECTYPE ON (RECTYPE.RECTypeId = CMDBDRC.REC_TYPE)
	                        order by EXECUTE_DATE
                           ;";

            using (SqlConnection conn = new SqlConnection(this.GetDBConnectionString()))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd);
                sqlAdapter.Fill(dt);
                conn.Close();
            }
            return this.MapCMDBDRC(dt);
        }

        ///<summary>
        ///程式說明：顯示CMDEXAMREPORT Grid
        ///</summary>
        public List<Models.CMDEXAMREPORT> GetCMDEXAMREPORT()
        {
            List<Models.CMDEXAMREPORT> result = new List<CMDEXAMREPORT>();
            DataTable dt = new DataTable();
            string sql = $@"SELECT HOS.HospitalName AS HOSPITAL_ID,
                            CMDEXAMREPORT.PAT_IDNO AS PAT_IDNO,
                            CMDEXAMREPORT.REC_NO AS REC_NO,
                            CMDEXAMREPORT.EXAM_TYPE AS EXAM_TYPE,
                            SOURCE.SourceName AS SOURCE,
                            CMDEXAMREPORT.NHI_YM AS NHI_YM,
                            CMDEXAMREPORT.SECTION AS SECTION,
                            CMDEXAMREPORT.SECTION_NAMEC AS SECTION_NAMEC,
                            CMDEXAMREPORT.MAIN_DIAGNOSIS AS MAIN_DIAGNOSIS,
                            CMDEXAMREPORT.MAIN_DIAGNOSIS_NAME AS MAIN_DIAGNOSIS_NAME,
                            CMDEXAMREPORT.REGION AS REGION,
                            CMDEXAMREPORT.EXAM_TYPE_CODE AS EXAM_TYPE_CODE,
                            CMDEXAMREPORT.EXAM_TYPE_NAME AS EXAM_TYPE_NAME,
                            CMDEXAMREPORT.NHI_CODE AS NHI_CODE,
                            CMDEXAMREPORT.NHI_NAME AS NHI_NAME,
                            CMDEXAMREPORT.EXAM_NAME AS EXAM_NAME,
                            CMDEXAMREPORT.EXAM_PROCEDURE AS EXAM_PROCEDURE,
                            CMDEXAMREPORT.EXAM_REPORT01 AS EXAM_REPORT01,
                            CMDEXAMREPORT.UNIT AS UNIT,
                            CMDEXAMREPORT.REFERENCE AS REFERENCE,
                            CMDEXAMREPORT.EXAM_REPORT02 AS EXAM_REPORT02,
                            CMDEXAMREPORT.SPECIMEN AS SPECIMEN,
                            CMDEXAMREPORT.ORDER_DATE AS ORDER_DATE,
                            CMDEXAMREPORT.EXECUTE_DATE AS EXECUTE_DATE,
                            CMDEXAMREPORT.REPORT_DATE AS REPORT_DATE,
                            CMDEXAMREPORT.CANCEL_YN AS CANCEL_YN,
                            CMDEXAMREPORT.CANCEL_DTTM AS CANCEL_DTTM,
                            CMDEXAMREPORT.CANCEL_USER_ID AS CANCEL_USER_ID,
                            CMDEXAMREPORT.CANCEL_NAMEC AS CANCEL_NAMEC,
                            CMDEXAMREPORT.PROC_DTTM AS PROC_DTTM,
                            CMDEXAMREPORT.PROC_USER_ID AS PROC_USER_ID,
                            CMDEXAMREPORT.PROC_NAMEC AS PROC_NAMEC,
                            CMDEXAMREPORT.CREATE_DTTM AS CREATE_DTTM,
                            CMDEXAMREPORT.CREATE_USER_ID AS CREATE_USER_ID,
                            CMDEXAMREPORT.CREATE_NAMEC AS CREATE_NAMEC,
                            CMDEXAMREPORT.HOSPITAL_ID_ORI AS HOSPITAL_ID_ORI,
                            CMDEXAMREPORT.HOSPITAL_SNAME_ORI AS HOSPITAL_SNAME_ORI,
                            CMDEXAMREPORT.CERTIFICATION AS CERTIFICATION,
                            CMDEXAMREPORT.VIDEO_MATERIAL AS VIDEO_MATERIAL,

                            HOS.HospitalId AS HospitalId,
                            SOURCE.SourceId AS SourceId
                            FROM CMDEXAMREPORT CMDEXAMREPORT
                            JOIN HOSPITAL HOS ON (CMDEXAMREPORT.HOSPITAL_ID = HOS.HospitalId)
                            JOIN SOURCE SOURCE ON (SOURCE.SourceId = CMDEXAMREPORT.SOURCE)
                            order by EXECUTE_DATE
                           ;";

            using (SqlConnection conn = new SqlConnection(this.GetDBConnectionString()))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd);
                sqlAdapter.Fill(dt);
                conn.Close();
            }
            return this.MapCMDEXAMREPORT(dt);
        }

        /*
         *DropDownList Use 
         */


        ///<summary>
        ///程式說明：PHRCDRC HOSPITAL_ID DropDownList
        ///</summary>
        public List<Models.PHRCDRC> PHRCDRCHOSPITAL_IDDropDownList()
        {
            List<Models.PHRCDRC> result = new List<PHRCDRC>();
            DataTable dt = new DataTable();
            string sql = $@"SELECT DISTINCT HOSPITAL.HospitalName AS HospitalName,
							HOSPITAL.HospitalId AS HospitalId,
                            PHRCDRC.PAT_IDNO AS PAT_IDNO
	                        FROM PHRCDRC PHRCDRC
							JOIN HOSPITAL HOSPITAL ON (PHRCDRC.HOSPITAL_ID = HOSPITAL.HospitalId)
                           ; ";

            using (SqlConnection conn = new SqlConnection(this.GetDBConnectionString()))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd);
                sqlAdapter.Fill(dt);
                conn.Close();
            }
            return this.MapPHRCDRCHOSPITAL_ID(dt);
        }


        ///<summary>
        ///程式說明：抓 PHRCDRC DRUGSOURCE(DRUGSOURCE TABLE)的值
        ///</summary>
        public List<Models.PHRCDRC> PHRCDRCDRUGSOURCEDropDownList()
        {
            List<Models.PHRCDRC> result = new List<PHRCDRC>();
            DataTable dt = new DataTable();
            string sql = $@"SELECT DISTINCT DrugSourceName as DrugSourceName,
                            DrugSourceId as DrugSourceId, 
                            PHRCDRC.PAT_IDNO AS PAT_IDNO
                            FROM PHRCDRC PHRCDRC
							JOIN DRUGSOURCE DRUGSOURCE ON (PHRCDRC.DRUGSOURCE = DRUGSOURCE.DrugSourceId)
                           ; ";

            using (SqlConnection conn = new SqlConnection(this.GetDBConnectionString()))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd);
                sqlAdapter.Fill(dt);
                conn.Close();
            }
            return this.MapPHRCDRCDRUGSOURCE(dt);
        }

        ///<summary>
        ///程式說明：抓 PHRCDRC DRUGSOURCE(DRUGSOURCE TABLE)的值
        ///</summary>
        public List<Models.PHRCDRC> PHRCDRCDRUGSOURCEMultiSelect()
        {
            List<Models.PHRCDRC> result = new List<PHRCDRC>();
            DataTable dt = new DataTable();
            string sql = $@"SELECT DISTINCT DrugSourceName as DrugSourceName,
                            DrugSourceId as DrugSourceId
                            FROM DRUGSOURCE DRUGSOURCE
                           ; ";

            using (SqlConnection conn = new SqlConnection(this.GetDBConnectionString()))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd);
                sqlAdapter.Fill(dt);
                conn.Close();
            }
            return this.MapPHRCDRCDRUGSOURCEMultiSelect(dt);
        }


        ///<summary>
        ///程式說明：抓 PHRCDRC DRUGCOMPCODENM的值
        ///</summary>
        public List<Models.PHRCDRC> PHRCDRCDRUGCOMPCODENMDropDownList()
        {
            List<Models.PHRCDRC> result = new List<PHRCDRC>();
            DataTable dt = new DataTable();
            string sql = $@"SELECT DISTINCT DRUGCOMPCODENM AS DRUGCOMPCODENM,
                            UDNNHICODE AS UDNNHICODE,
                            PAT_IDNO AS PAT_IDNO
                            FROM PHRCDRC
                           ; ";

            using (SqlConnection conn = new SqlConnection(this.GetDBConnectionString()))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd);
                sqlAdapter.Fill(dt);
                conn.Close();
            }
            return this.MapPHRCDRCDRUGCOMPCODENM(dt);
        }

        ///<summary>
        ///程式說明：抓 CMDEXAMREPORT HOSPITAL_ID(HOSPITAL Table)的值
        ///</summary>
        public List<Models.CMDEXAMREPORT> CMDEXAMREPORTHOSPITAL_IDDropDownList()
        {
            List<Models.CMDEXAMREPORT> result = new List<CMDEXAMREPORT>();
            DataTable dt = new DataTable();
            string sql = $@"SELECT DISTINCT HOSPITAL.HospitalName AS HospitalName,
							HOSPITAL.HospitalId AS HospitalId,
                            CMDEXAMREPORT.PAT_IDNO AS PAT_IDNO
	                        FROM CMDEXAMREPORT CMDEXAMREPORT
							JOIN HOSPITAL HOSPITAL ON (CMDEXAMREPORT.HOSPITAL_ID = HOSPITAL.HospitalId)
                           ; ";

            using (SqlConnection conn = new SqlConnection(this.GetDBConnectionString()))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd);
                sqlAdapter.Fill(dt);
                conn.Close();
            }
            return this.MapCMDEXAMREPORTHOSPITAL_ID(dt);
        }


        ///<summary>
        ///程式說明：抓 CMDEXAMREPORT SOURCE(SOURCE Table)的值
        ///</summary>
        public List<Models.CMDEXAMREPORT> CMDEXAMREPORTSOURCEDropDownList()
        {
            List<Models.CMDEXAMREPORT> result = new List<CMDEXAMREPORT>();
            DataTable dt = new DataTable();
            string sql = $@"SELECT DISTINCT SourceName AS SourceName,
                            SourceId AS SourceId,
                            CMDEXAMREPORT.PAT_IDNO AS PAT_IDNO
                            FROM Source Source 
							JOIN CMDEXAMREPORT CMDEXAMREPORT ON (CMDEXAMREPORT.Source = Source.SourceId) 
                           ; ";

            using (SqlConnection conn = new SqlConnection(this.GetDBConnectionString()))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd);
                sqlAdapter.Fill(dt);
                conn.Close();
            }
            return this.MapCMDEXAMREPORTSOURCE(dt);
        }

        ///<summary>
        ///程式說明：抓 CMDEXAMREPORT SOURCE(SOURCE Table) MultiSelect的值
        ///</summary>
        public List<Models.CMDEXAMREPORT> CMDEXAMREPORTSOURCEMultiSelect()
        {
            List<Models.CMDEXAMREPORT> result = new List<CMDEXAMREPORT>();
            DataTable dt = new DataTable();
            string sql = $@"SELECT DISTINCT SourceName AS SourceName,
                            SourceId AS SourceId
                            FROM Source Source 

                           ; ";

            using (SqlConnection conn = new SqlConnection(this.GetDBConnectionString()))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd);
                sqlAdapter.Fill(dt);
                conn.Close();
            }
            return this.MapCMDEXAMREPORTSOURCEMultiSelect(dt);
        }

        ///<summary>
        ///程式說明：抓 CMDEXAMREPORT SECTION_NAMEC的值
        ///</summary>
        public List<Models.CMDEXAMREPORT> CMDEXAMREPORTSECTION_NAMECDropDownList()
        {
            List<Models.CMDEXAMREPORT> result = new List<CMDEXAMREPORT>();
            DataTable dt = new DataTable();
            string sql = $@"SELECT DISTINCT SECTION_NAMEC AS SECTION_NAMEC,
                            SECTION AS SECTION,
                            CMDEXAMREPORT.PAT_IDNO AS PAT_IDNO
                            FROM CMDEXAMREPORT 
                           ; ";

            using (SqlConnection conn = new SqlConnection(this.GetDBConnectionString()))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd);
                sqlAdapter.Fill(dt);
                conn.Close();
            }
            return this.MapCMDEXAMREPORTSECTION_NAMEC(dt);
        }

        ///<summary>
        ///程式說明：抓 CMDEXAMREPORT EXAM_TYPE_NAME的值
        ///</summary>
        public List<Models.CMDEXAMREPORT> CMDEXAMREPORTEXAM_TYPE_NAMEDropDownList()
        {
            List<Models.CMDEXAMREPORT> result = new List<CMDEXAMREPORT>();
            DataTable dt = new DataTable();
            string sql = $@"SELECT DISTINCT EXAM_TYPE_NAME AS EXAM_TYPE_NAME,
                            EXAM_TYPE_CODE AS EXAM_TYPE_CODE,
                            CMDEXAMREPORT.PAT_IDNO AS PAT_IDNO
                            FROM CMDEXAMREPORT 
                           ; ";

            using (SqlConnection conn = new SqlConnection(this.GetDBConnectionString()))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd);
                sqlAdapter.Fill(dt);
                conn.Close();
            }
            return this.MapCMDEXAMREPORTEXAM_TYPE_NAME(dt);
        }

        ///<summary>
        ///程式說明：抓 CMDEXAMREPORT EXECUTE_DATE的值
        ///</summary>
        public List<Models.CMDEXAMREPORT> CMDEXAMREPORTEXECUTE_DATEDropDownList()
        {
            List<Models.CMDEXAMREPORT> result = new List<CMDEXAMREPORT>();
            DataTable dt = new DataTable();
            string sql = $@"SELECT DISTINCT EXECUTE_DATE AS EXECUTE_DATE,
                            CMDEXAMREPORT.PAT_IDNO AS PAT_IDNO
                            FROM CMDEXAMREPORT 
                           ; ";

            using (SqlConnection conn = new SqlConnection(this.GetDBConnectionString()))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd);
                sqlAdapter.Fill(dt);
                conn.Close();
            }
            return this.MapCMDEXAMREPORTEXECUTE_DATE(dt);
        }

        ///<summary>
        ///程式說明：抓 CMDBDRC HOSPITAL_ID的值
        ///</summary>
        public List<Models.CMDBDRC> CMDBDRCHOSPITAL_IDDropDownList()
        {
            List<Models.CMDBDRC> result = new List<CMDBDRC>();
            DataTable dt = new DataTable();
            string sql = $@"SELECT DISTINCT HospitalName AS HospitalName,
                            HospitalId AS HospitalId,
                            CMDBDRC.PAT_IDNO AS PAT_IDNO,
							RECTYPE.RECTypeId AS RECTypeId
                            FROM HOSPITAL HOS 
							JOIN CMDBDRC CMDBDRC ON (CMDBDRC.HOSPITAL_ID = HOS.HospitalId)
                            JOIN RECTYPE RECTYPE ON (RECTYPE.RECTypeId = CMDBDRC.REC_TYPE)
                           ; ";

            using (SqlConnection conn = new SqlConnection(this.GetDBConnectionString()))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd);
                sqlAdapter.Fill(dt);
                conn.Close();
            }
            return this.MapCMDBDRCHOSPITAL_ID(dt);
        }

        ///<summary>
        ///程式說明：抓 CMDBDRC SOURCE的值
        ///</summary>
        public List<Models.CMDBDRC> CMDBDRCSOURCEDropDownList()
        {
            List<Models.CMDBDRC> result = new List<CMDBDRC>();
            DataTable dt = new DataTable();
            string sql = $@"SELECT DISTINCT SOURCE.SOURCEName AS SOURCEName,
                            SOURCE.SOURCEId AS SOURCEId,
                            CMDBDRC.PAT_IDNO AS PAT_IDNO,
							RECTYPE.RECTypeId AS RECTypeId
                            FROM SOURCE
                            JOIN CMDBDRC CMDBDRC ON (CMDBDRC.SOURCE = SOURCE.SOURCEId)
                            JOIN RECTYPE RECTYPE ON (RECTYPE.RECTypeId = CMDBDRC.REC_TYPE)
                           ; ";

            using (SqlConnection conn = new SqlConnection(this.GetDBConnectionString()))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd);
                sqlAdapter.Fill(dt);
                conn.Close();
            }
            return this.MapCMDBDRCSOURCE(dt);
        }

        ///<summary>
        ///程式說明：抓 CMDBDRC SOURCE MultiSelect的值
        ///</summary>
        public List<Models.CMDBDRC> CMDBDRCSOURCEMultiSelect()
        {
            List<Models.CMDBDRC> result = new List<CMDBDRC>();
            DataTable dt = new DataTable();
            string sql = $@"SELECT DISTINCT SOURCE.SOURCEName AS SOURCEName,
                            SOURCE.SOURCEId AS SOURCEId,
							RECTYPE.RECTypeId AS RECTypeId
                            FROM SOURCE
                            JOIN CMDBDRC CMDBDRC ON (CMDBDRC.SOURCE = SOURCE.SOURCEId)
                            JOIN RECTYPE RECTYPE ON (RECTYPE.RECTypeId = CMDBDRC.REC_TYPE)
                           ; ";

            using (SqlConnection conn = new SqlConnection(this.GetDBConnectionString()))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd);
                sqlAdapter.Fill(dt);
                conn.Close();
            }
            return this.MapCMDBDRCSOURCEMultiSelect(dt);
        }

        ///<summary>
        ///程式說明：抓 CMDBDRC SECTION_NAMEC的值
        ///</summary>
        public List<Models.CMDBDRC> CMDBDRCSECTION_NAMECDropDownList()
        {
            List<Models.CMDBDRC> result = new List<CMDBDRC>();
            DataTable dt = new DataTable();
            string sql = $@"SELECT DISTINCT SECTION_NAMEC AS SECTION_NAMEC,
                            SECTION AS SECTION,
                            PAT_IDNO AS PAT_IDNO,
							RECTYPE.RECTypeId AS RECTypeId
                            FROM CMDBDRC                            
                            JOIN RECTYPE RECTYPE ON (RECTYPE.RECTypeId = CMDBDRC.REC_TYPE)
                           ; ";

            using (SqlConnection conn = new SqlConnection(this.GetDBConnectionString()))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd);
                sqlAdapter.Fill(dt);
                conn.Close();
            }
            return this.MapCMDBDRCSECTION_NAMEC(dt);
        }

        ///<summary>
        ///程式說明：抓 CMDBDRC REC_NAME的值
        ///</summary>
        public List<Models.CMDBDRC> CMDBDRCREC_NAMEDropDownList()
        {
            List<Models.CMDBDRC> result = new List<CMDBDRC>();
            DataTable dt = new DataTable();
            string sql = $@"SELECT DISTINCT REC_NAME AS REC_NAME,
                            REC_CODE AS REC_CODE,
                            PAT_IDNO AS PAT_IDNO,
                            RECTYPE.RECTypeId AS RECTypeId
                            FROM CMDBDRC                            
                            JOIN RECTYPE RECTYPE ON (RECTYPE.RECTypeId = CMDBDRC.REC_TYPE)
                           ; ";

            using (SqlConnection conn = new SqlConnection(this.GetDBConnectionString()))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd);
                sqlAdapter.Fill(dt);
                conn.Close();
            }
            return this.MapCMDBDRCREC_NAME(dt);
        }


        ///<summary>
        ///程式說明：抓 CMDBDRC NHI_NAME的值
        ///</summary>
        public List<Models.CMDBDRC> CMDBDRCNHI_NAMEDropDownList()
        {
            List<Models.CMDBDRC> result = new List<CMDBDRC>();
            DataTable dt = new DataTable();
            string sql = $@"SELECT DISTINCT NHI_NAME AS NHI_NAME,
                            NHI_CODE AS NHI_CODE,
                            PAT_IDNO AS PAT_IDNO,
                            RECTYPE.RECTypeId AS RECTypeId
                            FROM CMDBDRC                            
                            JOIN RECTYPE RECTYPE ON (RECTYPE.RECTypeId = CMDBDRC.REC_TYPE)
                           ; ";

            using (SqlConnection conn = new SqlConnection(this.GetDBConnectionString()))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd);
                sqlAdapter.Fill(dt);
                conn.Close();
            }
            return this.MapCMDBDRCNHI_NAME(dt);
        }

        ///<summary>
        ///程式說明：抓 CMDBDRC EXECUTE_DATE的值
        ///</summary>
        public List<Models.CMDBDRC> CMDBDRCEXECUTE_DATEDropDownList()
        {
            List<Models.CMDBDRC> result = new List<CMDBDRC>();
            DataTable dt = new DataTable();
            string sql = $@"SELECT DISTINCT EXECUTE_DATE,
                            PAT_IDNO AS PAT_IDNO,
                            RECTYPE.RECTypeId AS RECTypeId
                            FROM CMDBDRC                            
                            JOIN RECTYPE RECTYPE ON (RECTYPE.RECTypeId = CMDBDRC.REC_TYPE)
                           ; ";

            using (SqlConnection conn = new SqlConnection(this.GetDBConnectionString()))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd);
                sqlAdapter.Fill(dt);
                conn.Close();
            }
            return this.MapCMDBDRCEXECUTE_DATE(dt);
        }

        ///<summary>
        ///程式說明：抓 REHABILITATION REC_CODE的值
        ///</summary>
        public List<Models.CMDBDRC> REHABILITATIONREC_CODEDropDownList()
        {
            List<Models.CMDBDRC> result = new List<CMDBDRC>();
            DataTable dt = new DataTable();
            string sql = $@"SELECT DISTINCT REC_CODE AS REC_CODE,
                            PAT_IDNO AS PAT_IDNO,
                            RECTYPE.RECTypeId AS RECTypeId
                            FROM CMDBDRC                            
                            JOIN RECTYPE RECTYPE ON (RECTYPE.RECTypeId = CMDBDRC.REC_TYPE)
                           ; ";

            using (SqlConnection conn = new SqlConnection(this.GetDBConnectionString()))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd);
                sqlAdapter.Fill(dt);
                conn.Close();
            }
            return this.MapREHABILITATIONREC_CODE(dt);
        }


        ///<summary>
        ///程式說明：抓 CMDALLERGY HOSPITAL_ID的值
        ///</summary>
        public List<Models.CMDALLERGY> CMDALLERGYHOSPITAL_IDDropDownList()
        {
            List<Models.CMDALLERGY> result = new List<CMDALLERGY>();
            DataTable dt = new DataTable();
            string sql = $@"SELECT DISTINCT HOSPITAL.HospitalName AS HospitalName,
                            HOSPITAL.HospitalId AS HospitalId,
                            CMDALLERGY.PAT_IDNO AS PAT_IDNO
                            FROM HOSPITAL HOSPITAL 
							JOIN CMDALLERGY CMDALLERGY ON (CMDALLERGY.HOSPITAL_ID = HOSPITAL.HospitalId)
                           ; ";

            using (SqlConnection conn = new SqlConnection(this.GetDBConnectionString()))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd);
                sqlAdapter.Fill(dt);
                conn.Close();
            }
            return this.MapCMDALLERGYHOSPITAL_ID(dt);
        }

        ///<summary>
        ///程式說明：抓 CMDALLERGY SOURCE的值
        ///</summary>
        public List<Models.CMDALLERGY> CMDALLERGYSOURCEDropDownList()
        {
            List<Models.CMDALLERGY> result = new List<CMDALLERGY>();
            DataTable dt = new DataTable();
            string sql = $@"SELECT DISTINCT SourceName AS SourceName,
                            SourceId AS SourceId,
                            CMDALLERGY.PAT_IDNO AS PAT_IDNO
                            FROM Source Source 
							JOIN CMDALLERGY CMDALLERGY ON (CMDALLERGY.Source = Source.SourceId) 
                           ; ";

            using (SqlConnection conn = new SqlConnection(this.GetDBConnectionString()))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd);
                sqlAdapter.Fill(dt);
                conn.Close();
            }
            return this.MapCMDALLERGYSOURCE(dt);
        }

        ///<summary>
        ///程式說明：抓 CMDALLERGY SOURCE MuitiSelect的值
        ///</summary>
        public List<Models.CMDALLERGY> CMDALLERGYSOURCEMultiSelect()
        {
            List<Models.CMDALLERGY> result = new List<CMDALLERGY>();
            DataTable dt = new DataTable();
            string sql = $@"SELECT DISTINCT SourceName AS SourceName,
                            SourceId AS SourceId
                            FROM Source Source 
							JOIN CMDALLERGY CMDALLERGY ON (CMDALLERGY.Source = Source.SourceId) 
                           ; ";

            using (SqlConnection conn = new SqlConnection(this.GetDBConnectionString()))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd);
                sqlAdapter.Fill(dt);
                conn.Close();
            }
            return this.MapCMDALLERGYSOURCEMuitiSelect(dt);
        }

        ///<summary>
        ///程式說明：抓 CMDALLERGY DRUG的值
        ///</summary>
        public List<Models.CMDALLERGY> CMDALLERGYDRUGDropDownList()
        {
            List<Models.CMDALLERGY> result = new List<CMDALLERGY>();
            DataTable dt = new DataTable();
            string sql = $@"SELECT DISTINCT ALLERGYDRUG.AllergyDrugName AS AllergyDrugName,
                            ALLERGYDRUG.AllergyDrugId AS AllergyDrugId,
                            CMDALLERGY.PAT_IDNO AS PAT_IDNO
                            FROM ALLERGYDRUG ALLERGYDRUG
                            JOIN CMDALLERGY CMDALLERGY ON (CMDALLERGY.DRUG = ALLERGYDRUG.AllergyDrugId) 
                           ; ";

            using (SqlConnection conn = new SqlConnection(this.GetDBConnectionString()))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd);
                sqlAdapter.Fill(dt);
                conn.Close();
            }
            return this.MapCMDALLERGYDRUG(dt);
        }


        /*
         * MapFunction
         */

        /*
        * ChartUse
        */
        ///<summary>
        ///程式說明：MapPHRCDRCBarChart
        ///</summary>
        private List<Models.ChartModel> MapPHRCDRCBarChart(DataTable dt)
        {
            List<Models.ChartModel> result = new List<Models.ChartModel>();
            foreach (DataRow row in dt.Rows)
            {
                result.Add(new ChartModel()
                {
                    DRUGCOMPCODENM = row["DRUGCOMPCODENM"].ToString(),
                    REMAIN = row["REMAIN"].ToString(),
                    PAT_IDNO = row["PAT_IDNO"].ToString()
                });
            }
            return result;
        }

        ///<summary>
        ///程式說明：MapPHRCDRCChart
        ///</summary>
        private List<Models.PHRCDRC> MapPHRCDRCChart(DataTable dt)
        {
            List<Models.PHRCDRC> result = new List<Models.PHRCDRC>();
            foreach (DataRow row in dt.Rows)
            {
                result.Add(new PHRCDRC()
                {
                    ID = row["ID"].ToString(),
                    DRUGCOMPCODENM = row["DRUGCOMPCODENM"].ToString(),
                    BEGIN_DT = row["BEGIN_DT"].ToString(),
                    END_DT = row["END_DT"].ToString(),
                    DAYS =row["DAYS"].ToString(),
                    PAT_IDNO = row["PAT_IDNO"].ToString()
                });
            }
            return result;
        }


        /*
         * GridUse
         */

        ///<summary>
        ///程式說明：MapPHRCDRC
        ///</summary>
        private List<Models.PHRCDRC> MapPHRCDRC(DataTable dt)
        {
            List<Models.PHRCDRC> result = new List<Models.PHRCDRC>();
            foreach (DataRow row in dt.Rows)
            {
                result.Add(new PHRCDRC()
                {
                    HOSPITAL_ID = row["HOSPITAL_ID"].ToString(),
                    PAT_IDNO = row["PAT_IDNO"].ToString(),
                    REC_NO = row["REC_NO"].ToString(),
                    CASE_NO = row["CASE_NO"].ToString(),
                    DRUGSOURCE = row["DRUGSOURCE"].ToString(),
                    UDDATC = row["UDDATC"].ToString(),
                    UDDATCNM = row["UDDATCNM"].ToString(),
                    DRUGCOMPCODE = row["DRUGCOMPCODE"].ToString(),
                    DRUGCOMPCODENM = row["DRUGCOMPCODENM"].ToString(),
                    UDNNHICODE = row["UDNNHICODE"].ToString(),
                    UDDMDPNAME = row["UDDMDPNAME"].ToString(),
                    BEGIN_DT = row["BEGIN_DT"].ToString(),
                    END_DT = row["END_DT"].ToString(),
                    DSPQTY = row["DSPQTY"].ToString(),
                    DAYS = row["DAYS"].ToString(),
                    CANCEL_YN = row["CANCEL_YN"].ToString(),
                    CANCEL_DTTM = row["CANCEL_DTTM"].ToString(),
                    CANCEL_USER_ID = row["CANCEL_USER_ID"].ToString(),
                    CANCEL_NAMEC = row["CANCEL_NAMEC"].ToString(),
                    PROC_DTTM = row["PROC_DTTM"].ToString(),
                    PROC_USER_ID = row["PROC_USER_ID"].ToString(),
                    PROC_NAMEC = row["PROC_NAMEC"].ToString(),
                    CREATE_DTTM = row["CREATE_DTTM"].ToString(),
                    CREATE_USER_ID = row["CREATE_USER_ID"].ToString(),
                    CREATE_NAMEC = row["CREATE_NAMEC"].ToString(),
                    MAIN_DIAGNOSIS = row["MAIN_DIAGNOSIS"].ToString(),
                    ROUTE = row["ROUTE"].ToString(),
                    DOSEUNIT = row["DOSEUNIT"].ToString(),
                    COMPLEX_MARK = row["COMPLEX_MARK"].ToString(),
                    INSULOOKSEQ = row["INSULOOKSEQ"].ToString(),
                    HOSPITAL_ID_ORI = row["HOSPITAL_ID_ORI"].ToString(),
                    HOSPITAL_SNAME_ORI = row["HOSPITAL_SNAME_ORI"].ToString(),
                    ATC3_NAME = row["ATC3_NAME"].ToString(),
                    HOSPITAL_ID_CHRONIC = row["HOSPITAL_ID_CHRONIC"].ToString(),
                    HOSPITAL_SNAME_CHRONIC = row["HOSPITAL_SNAME_CHRONIC"].ToString(),

                    HospitalId = row["HospitalId"].ToString(),
                    DrugSourceId = row["DrugSourceId"].ToString(),

                    Text = row["HOSPITAL_ID"].ToString(),
                    Value = row["HospitalId"].ToString()

                });
            }
            return result;
        }

        ///<summary>
        ///程式說明：MapCMDTOCC
        ///</summary>
        private List<Models.CMDTOCC> MapCMDTOCC(DataTable dt)
        {
            List<Models.CMDTOCC> result = new List<Models.CMDTOCC>();
            foreach (DataRow row in dt.Rows)
            {
                result.Add(new CMDTOCC()
                {
                    HOSPITAL_ID = row["HOSPITAL_ID"].ToString(),
                    PAT_IDNO = row["PAT_IDNO"].ToString(),
                    TOCCMSG = row["TOCCMSG"].ToString(),
                    CANCEL_YN = row["CANCEL_YN"].ToString(),
                    CANCEL_DTTM = row["CANCEL_DTTM"].ToString(),
                    CANCEL_USER_ID = row["CANCEL_USER_ID"].ToString(),
                    CANCEL_NAMEC = row["CANCEL_NAMEC"].ToString(),
                    PROC_DTTM = row["PROC_DTTM"].ToString(),
                    PROC_USER_ID = row["PROC_USER_ID"].ToString(),
                    PROC_NAMEC = row["PROC_NAMEC"].ToString(),
                    CREATE_DTTM = row["CREATE_DTTM"].ToString(),
                    CREATE_USER_ID = row["CREATE_USER_ID"].ToString(),
                    CREATE_NAMEC = row["CREATE_NAMEC"].ToString(),

                    HospitalId = row["HospitalId"].ToString(),

                });
            }
            return result;
        }


        ///<summary>
        ///程式說明：MapCMDALLERGY
        ///</summary>
        private List<Models.CMDALLERGY> MapCMDALLERGY(DataTable dt)
        {
            List<Models.CMDALLERGY> result = new List<Models.CMDALLERGY>();
            foreach (DataRow row in dt.Rows)
            {
                result.Add(new CMDALLERGY()
                {
                    HOSPITAL_ID = row["HOSPITAL_ID"].ToString(),
                    PAT_IDNO = row["PAT_IDNO"].ToString(),
                    REC_NO = row["REC_NO"].ToString(),
                    UPLOAD_DTTM = row["UPLOAD_DTTM"].ToString(),
                    SOURCE = row["SOURCE"].ToString(),
                    SOURCE_IDNO = row["SOURCE_IDNO"].ToString(),
                    UPLOAD_MARK = row["UPLOAD_MARK"].ToString(),
                    DRUG = row["DRUG"].ToString(),
                    CANCEL_YN = row["CANCEL_YN"].ToString(),
                    CANCEL_DTTM = row["CANCEL_DTTM"].ToString(),
                    CANCEL_USER_ID = row["CANCEL_USER_ID"].ToString(),
                    CANCEL_NAMEC = row["CANCEL_NAMEC"].ToString(),
                    PROC_DTTM = row["PROC_DTTM"].ToString(),
                    PROC_USER_ID = row["PROC_USER_ID"].ToString(),
                    PROC_NAMEC = row["PROC_NAMEC"].ToString(),
                    CREATE_DTTM = row["CREATE_DTTM"].ToString(),
                    CREATE_USER_ID = row["CREATE_USER_ID"].ToString(),
                    CREATE_NAMEC = row["CREATE_NAMEC"].ToString(),
                    HOSPITAL_ID_ORI = row["HOSPITAL_ID_ORI"].ToString(),
                    HOSPITAL_SNAME_ORI = row["HOSPITAL_SNAME_ORI"].ToString(),

                    HospitalId = row["HospitalId"].ToString(),
                    SourceId = row["SourceId"].ToString(),
                    AllergyDrugId = row["AllergyDrugId"].ToString(),
                });
            }
            return result;
        }


        ///<summary>
        ///程式說明：MapCMDBDRC
        ///</summary>
        private List<Models.CMDBDRC> MapCMDBDRC(DataTable dt)
        {
            List<Models.CMDBDRC> result = new List<Models.CMDBDRC>();
            foreach (DataRow row in dt.Rows)
            {
                result.Add(new CMDBDRC()
                {
                    HOSPITAL_ID = row["HOSPITAL_ID"].ToString(),
                    PAT_IDNO = row["PAT_IDNO"].ToString(),
                    REC_TYPE = row["REC_TYPE"].ToString(),
                    REC_NO = row["REC_NO"].ToString(),
                    SOURCE = row["SOURCE"].ToString(),
                    NHI_YM = row["NHI_YM"].ToString(),
                    SECTION = row["SECTION"].ToString(),
                    SECTION_NAMEC = row["SECTION_NAMEC"].ToString(),
                    MAIN_DIAGNOSIS = row["MAIN_DIAGNOSIS"].ToString(),
                    MAIN_DIAGNOSIS_NAME = row["MAIN_DIAGNOSIS_NAME"].ToString(),
                    REC_CODE = row["REC_CODE"].ToString(),
                    REC_NAME = row["REC_NAME"].ToString(),
                    NHI_CODE = row["NHI_CODE"].ToString(),
                    NHI_NAME = row["NHI_NAME"].ToString(),
                    REGION = row["REGION"].ToString(),
                    EXECUTE_DATE = row["EXECUTE_DATE"].ToString(),
                    REPORT_DATE = row["REPORT_DATE"].ToString(),
                    QTY = row["QTY"].ToString(),
                    CANCEL_YN = row["CANCEL_YN"].ToString(),
                    CANCEL_DTTM = row["CANCEL_DTTM"].ToString(),
                    CANCEL_USER_ID = row["CANCEL_USER_ID"].ToString(),
                    CANCEL_NAMEC = row["CANCEL_NAMEC"].ToString(),
                    PROC_DTTM = row["PROC_DTTM"].ToString(),
                    PROC_USER_ID = row["PROC_USER_ID"].ToString(),
                    PROC_NAMEC = row["PROC_NAMEC"].ToString(),
                    CREATE_DTTM = row["CREATE_DTTM"].ToString(),
                    CREATE_USER_ID = row["CREATE_USER_ID"].ToString(),
                    CREATE_NAMEC = row["CREATE_NAMEC"].ToString(),
                    ENCNT_DATE_START = row["ENCNT_DATE_START"].ToString(),
                    ENCNT_DATE_END = row["ENCNT_DATE_END"].ToString(),
                    HOSPITAL_ID_ORI = row["HOSPITAL_ID_ORI"].ToString(),
                    HOSPITAL_SNAME_ORI = row["HOSPITAL_SNAME_ORI"].ToString(),
                    OPDDATE = row["OPDDATE"].ToString(),
                    TREATMENT_SITE = row["TREATMENT_SITE"].ToString(),

                    HospitalId = row["HospitalId"].ToString(),
                    RECTypeId = row["RECTypeId"].ToString(),
                    SourceId = row["SourceId"].ToString(),
                });
            }
            return result;
        }





        ///<summary>
        ///程式說明：MapCMDEXAMREPORT
        ///</summary>
        private List<Models.CMDEXAMREPORT> MapCMDEXAMREPORT(DataTable dt)
        {
            List<Models.CMDEXAMREPORT> result = new List<Models.CMDEXAMREPORT>();
            foreach (DataRow row in dt.Rows)
            {
                result.Add(new CMDEXAMREPORT()
                {
                    HOSPITAL_ID = row["HOSPITAL_ID"].ToString(),
                    PAT_IDNO = row["PAT_IDNO"].ToString(),
                    REC_NO = row["REC_NO"].ToString(),
                    EXAM_TYPE = row["EXAM_TYPE"].ToString(),
                    SOURCE = row["SOURCE"].ToString(),
                    NHI_YM = row["NHI_YM"].ToString(),
                    SECTION = row["SECTION"].ToString(),
                    SECTION_NAMEC = row["SECTION_NAMEC"].ToString(),
                    MAIN_DIAGNOSIS = row["MAIN_DIAGNOSIS"].ToString(),
                    MAIN_DIAGNOSIS_NAME = row["MAIN_DIAGNOSIS_NAME"].ToString(),
                    REGION = row["REGION"].ToString(),
                    EXAM_TYPE_CODE = row["EXAM_TYPE_CODE"].ToString(),
                    EXAM_TYPE_NAME = row["EXAM_TYPE_NAME"].ToString(),
                    NHI_CODE = row["NHI_CODE"].ToString(),
                    NHI_NAME = row["NHI_NAME"].ToString(),
                    EXAM_NAME = row["EXAM_NAME"].ToString(),
                    EXAM_PROCEDURE = row["EXAM_PROCEDURE"].ToString(),
                    EXAM_REPORT01 = row["EXAM_REPORT01"].ToString(),
                    UNIT = row["UNIT"].ToString(),
                    REFERENCE = row["REFERENCE"].ToString(),
                    EXAM_REPORT02 = row["EXAM_REPORT02"].ToString(),
                    SPECIMEN = row["SPECIMEN"].ToString(),
                    ORDER_DATE = row["ORDER_DATE"].ToString(),
                    EXECUTE_DATE = row["EXECUTE_DATE"].ToString(),
                    REPORT_DATE = row["REPORT_DATE"].ToString(),
                    CANCEL_YN = row["CANCEL_YN"].ToString(),
                    CANCEL_DTTM = row["CANCEL_DTTM"].ToString(),
                    CANCEL_USER_ID = row["CANCEL_USER_ID"].ToString(),
                    CANCEL_NAMEC = row["CANCEL_NAMEC"].ToString(),
                    PROC_DTTM = row["PROC_DTTM"].ToString(),
                    PROC_USER_ID = row["PROC_USER_ID"].ToString(),
                    PROC_NAMEC = row["PROC_NAMEC"].ToString(),
                    CREATE_DTTM = row["CREATE_DTTM"].ToString(),
                    CREATE_USER_ID = row["CREATE_USER_ID"].ToString(),
                    CREATE_NAMEC = row["CREATE_NAMEC"].ToString(),
                    HOSPITAL_ID_ORI = row["HOSPITAL_ID_ORI"].ToString(),
                    HOSPITAL_SNAME_ORI = row["HOSPITAL_SNAME_ORI"].ToString(),
                    CERTIFICATION = row["CERTIFICATION"].ToString(),
                    VIDEO_MATERIAL = row["VIDEO_MATERIAL"].ToString(),
                    HospitalId = row["HospitalId"].ToString(),
                    SourceId = row["SourceId"].ToString(),
                });
            }
            return result;
        }

        /*
         * DropDownList Use
         */

        /*
         * PHRCDRC Table Use
         */
        ///<summary>
        ///程式說明：Map PHRCDRC HOSPITAL_ID
        ///</summary>
        private List<Models.PHRCDRC> MapPHRCDRCHOSPITAL_ID(DataTable dt)
        {
            List<Models.PHRCDRC> result = new List<Models.PHRCDRC>();
            foreach (DataRow row in dt.Rows)
            {
                result.Add(new PHRCDRC()
                {
                    PAT_IDNO = row["PAT_IDNO"].ToString(),
                    Text = row["HospitalName"].ToString(),
                    Value = row["HospitalId"].ToString()

                });
            }
            return result;
        }

        ///<summary>
        ///程式說明：Map PHRCDRC DRUGSOURCE
        ///</summary>
        private List<Models.PHRCDRC> MapPHRCDRCDRUGSOURCE(DataTable dt)
        {
            List<Models.PHRCDRC> result = new List<Models.PHRCDRC>();
            foreach (DataRow row in dt.Rows)
            {
                result.Add(new PHRCDRC()
                {
                    PAT_IDNO = row["PAT_IDNO"].ToString(),
                    Text = row["DrugSourceName"].ToString(),
                    Value = row["DrugSourceId"].ToString()

                });
            }
            return result;
        }

        ///<summary>
        ///程式說明：Map PHRCDRC DRUGSOURCE MultiSelect
        ///</summary>
        private List<Models.PHRCDRC> MapPHRCDRCDRUGSOURCEMultiSelect(DataTable dt)
        {
            List<Models.PHRCDRC> result = new List<Models.PHRCDRC>();
            foreach (DataRow row in dt.Rows)
            {
                result.Add(new PHRCDRC()
                {
                    Text = row["DrugSourceName"].ToString(),
                    Value = row["DrugSourceId"].ToString()

                });
            }
            return result;
        }

        ///<summary>
        ///程式說明：Map PHRCDRC DRUGCOMPCODENM
        ///</summary>
        private List<Models.PHRCDRC> MapPHRCDRCDRUGCOMPCODENM(DataTable dt)
        {
            List<Models.PHRCDRC> result = new List<Models.PHRCDRC>();
            foreach (DataRow row in dt.Rows)
            {
                result.Add(new PHRCDRC()
                {
                    PAT_IDNO = row["PAT_IDNO"].ToString(),
                    Text = row["DRUGCOMPCODENM"].ToString(),
                    Value = row["UDNNHICODE"].ToString()

                });
            }
            return result;
        }

        /*
         * CMDEXAMREPORT Table Use
         */
        ///<summary>
        ///程式說明：Map CMDEXAMREPORT HOSPITAL_ID
        ///</summary>
        private List<Models.CMDEXAMREPORT> MapCMDEXAMREPORTHOSPITAL_ID(DataTable dt)
        {
            List<Models.CMDEXAMREPORT> result = new List<Models.CMDEXAMREPORT>();
            foreach (DataRow row in dt.Rows)
            {
                result.Add(new CMDEXAMREPORT()
                {
                    PAT_IDNO = row["PAT_IDNO"].ToString(),
                    Text = row["HospitalName"].ToString(),
                    Value = row["HospitalId"].ToString()

                });
            }
            return result;
        }

        ///<summary>
        ///程式說明：Map CMDEXAMREPORT SOURCE
        ///</summary>
        private List<Models.CMDEXAMREPORT> MapCMDEXAMREPORTSOURCE(DataTable dt)
        {
            List<Models.CMDEXAMREPORT> result = new List<Models.CMDEXAMREPORT>();
            foreach (DataRow row in dt.Rows)
            {
                result.Add(new CMDEXAMREPORT()
                {
                    PAT_IDNO = row["PAT_IDNO"].ToString(),
                    Text = row["SourceName"].ToString(),
                    Value = row["SourceId"].ToString()

                });
            }
            return result;
        }

        ///<summary>
        ///程式說明：Map CMDEXAMREPORT SOURCE MultiSelect
        ///</summary>
        private List<Models.CMDEXAMREPORT> MapCMDEXAMREPORTSOURCEMultiSelect(DataTable dt)
        {
            List<Models.CMDEXAMREPORT> result = new List<Models.CMDEXAMREPORT>();
            foreach (DataRow row in dt.Rows)
            {
                result.Add(new CMDEXAMREPORT()
                {
                    Text = row["SourceName"].ToString(),
                    Value = row["SourceId"].ToString()

                });
            }
            return result;
        }


        ///<summary>
        ///程式說明：Map CMDEXAMREPORT SECTION_NAMEC
        ///</summary>
        private List<Models.CMDEXAMREPORT> MapCMDEXAMREPORTSECTION_NAMEC(DataTable dt)
        {
            List<Models.CMDEXAMREPORT> result = new List<Models.CMDEXAMREPORT>();
            foreach (DataRow row in dt.Rows)
            {
                result.Add(new CMDEXAMREPORT()
                {
                    PAT_IDNO = row["PAT_IDNO"].ToString(),
                    Text = row["SECTION_NAMEC"].ToString(),
                    Value = row["SECTION"].ToString()

                });
            }
            return result;
        }

        ///<summary>
        ///程式說明：Map CMDEXAMREPORT EXAM_TYPE_NAME
        ///</summary>
        private List<Models.CMDEXAMREPORT> MapCMDEXAMREPORTEXAM_TYPE_NAME(DataTable dt)
        {
            List<Models.CMDEXAMREPORT> result = new List<Models.CMDEXAMREPORT>();
            foreach (DataRow row in dt.Rows)
            {
                result.Add(new CMDEXAMREPORT()
                {
                    PAT_IDNO = row["PAT_IDNO"].ToString(),
                    Text = row["EXAM_TYPE_NAME"].ToString(),
                    Value = row["EXAM_TYPE_CODE"].ToString()

                });
            }
            return result;
        }

        ///<summary>
        ///程式說明：Map CMDEXAMREPORT EXECUTE_DATE
        ///</summary>
        private List<Models.CMDEXAMREPORT> MapCMDEXAMREPORTEXECUTE_DATE(DataTable dt)
        {
            List<Models.CMDEXAMREPORT> result = new List<Models.CMDEXAMREPORT>();
            foreach (DataRow row in dt.Rows)
            {
                result.Add(new CMDEXAMREPORT()
                {
                    PAT_IDNO = row["PAT_IDNO"].ToString(),
                    Text = row["EXECUTE_DATE"].ToString(),
                    Value = row["EXECUTE_DATE"].ToString()

                });
            }
            return result;
        }

        /*
         * CMDBDRC Table Use
         */
        ///<summary>
        ///程式說明：Map CMDBDRC HOSPITAL_ID
        ///</summary>
        private List<Models.CMDBDRC> MapCMDBDRCHOSPITAL_ID(DataTable dt)
        {
            List<Models.CMDBDRC> result = new List<Models.CMDBDRC>();
            foreach (DataRow row in dt.Rows)
            {
                result.Add(new CMDBDRC()
                {
                    PAT_IDNO = row["PAT_IDNO"].ToString(),
                    RECTypeId =row["RECTypeId"].ToString(),
                    Text = row["HospitalName"].ToString(),
                    Value = row["HospitalId"].ToString()

                });
            }
            return result;
        }

        ///<summary>
        ///程式說明：Map CMDBDRC SOURCE
        ///</summary>
        private List<Models.CMDBDRC> MapCMDBDRCSOURCE(DataTable dt)
        {
            List<Models.CMDBDRC> result = new List<Models.CMDBDRC>();
            foreach (DataRow row in dt.Rows)
            {
                result.Add(new CMDBDRC()
                {
                    PAT_IDNO = row["PAT_IDNO"].ToString(),
                    RECTypeId = row["RECTypeId"].ToString(),
                    Text = row["SOURCEName"].ToString(),
                    Value = row["SOURCEId"].ToString()

                });
            }
            return result;
        }

        ///<summary>
        ///程式說明：Map CMDBDRC SOURCE MultiSelect
        ///</summary>
        private List<Models.CMDBDRC> MapCMDBDRCSOURCEMultiSelect(DataTable dt)
        {
            List<Models.CMDBDRC> result = new List<Models.CMDBDRC>();
            foreach (DataRow row in dt.Rows)
            {
                result.Add(new CMDBDRC()
                {
                    RECTypeId = row["RECTypeId"].ToString(),
                    Text = row["SOURCEName"].ToString(),
                    Value = row["SOURCEId"].ToString()

                });
            }
            return result;
        }

        ///<summary>
        ///程式說明：Map CMDBDRC SECTION_NAMEC
        ///</summary>
        private List<Models.CMDBDRC> MapCMDBDRCSECTION_NAMEC(DataTable dt)
        {
            List<Models.CMDBDRC> result = new List<Models.CMDBDRC>();
            foreach (DataRow row in dt.Rows)
            {
                result.Add(new CMDBDRC()
                {
                    PAT_IDNO = row["PAT_IDNO"].ToString(),
                    RECTypeId = row["RECTypeId"].ToString(),
                    Text = row["SECTION_NAMEC"].ToString(),
                    Value = row["SECTION"].ToString()

                });
            }
            return result;
        }

        ///<summary>
        ///程式說明：Map CMDBDRC REC_NAME
        ///</summary>
        private List<Models.CMDBDRC> MapCMDBDRCREC_NAME(DataTable dt)
        {
            List<Models.CMDBDRC> result = new List<Models.CMDBDRC>();
            foreach (DataRow row in dt.Rows)
            {
                result.Add(new CMDBDRC()
                {
                    PAT_IDNO = row["PAT_IDNO"].ToString(),
                    RECTypeId = row["RECTypeId"].ToString(),
                    Text = row["REC_NAME"].ToString(),
                    Value = row["REC_CODE"].ToString()

                });
            }
            return result;
        }

        ///<summary>
        ///程式說明：Map CMDBDRC NHI_NAME
        ///</summary>
        private List<Models.CMDBDRC> MapCMDBDRCNHI_NAME(DataTable dt)
        {
            List<Models.CMDBDRC> result = new List<Models.CMDBDRC>();
            foreach (DataRow row in dt.Rows)
            {
                result.Add(new CMDBDRC()
                {
                    PAT_IDNO = row["PAT_IDNO"].ToString(),
                    RECTypeId = row["RECTypeId"].ToString(),
                    Text = row["NHI_NAME"].ToString(),
                    Value = row["NHI_CODE"].ToString()

                });
            }
            return result;
        }

        ///<summary>
        ///程式說明：Map CMDBDRC EXECUTE_DATE
        ///</summary>
        private List<Models.CMDBDRC> MapCMDBDRCEXECUTE_DATE(DataTable dt)
        {
            List<Models.CMDBDRC> result = new List<Models.CMDBDRC>();
            foreach (DataRow row in dt.Rows)
            {
                result.Add(new CMDBDRC()
                {
                    PAT_IDNO = row["PAT_IDNO"].ToString(),
                    RECTypeId = row["RECTypeId"].ToString(),
                    Text = row["EXECUTE_DATE"].ToString(),
                    Value = row["EXECUTE_DATE"].ToString()

                });
            }
            return result;
        }

        /*
         * REHABILITATION Table Use
         */
        ///<summary>
        ///程式說明：Map REHABILITATION REC_CODE
        ///</summary>
        private List<Models.CMDBDRC> MapREHABILITATIONREC_CODE(DataTable dt)
        {
            List<Models.CMDBDRC> result = new List<Models.CMDBDRC>();
            foreach (DataRow row in dt.Rows)
            {
                result.Add(new CMDBDRC()
                {
                    PAT_IDNO = row["PAT_IDNO"].ToString(),
                    RECTypeId = row["RECTypeId"].ToString(),
                    Text = row["REC_CODE"].ToString(),
                    Value = row["REC_CODE"].ToString()

                });
            }
            return result;
        }

        /*
         * CMDALLERGY Table Use
         */
        ///<summary>
        ///程式說明：Map ALLERGY HOSPITAL_ID
        ///</summary>
        private List<Models.CMDALLERGY> MapCMDALLERGYHOSPITAL_ID(DataTable dt)
        {
            List<Models.CMDALLERGY> result = new List<Models.CMDALLERGY>();
            foreach (DataRow row in dt.Rows)
            {
                result.Add(new CMDALLERGY()
                {
                    PAT_IDNO = row["PAT_IDNO"].ToString(),
                    Text = row["HospitalName"].ToString(),
                    Value = row["HospitalId"].ToString()

                });
            }
            return result;
        }

        ///<summary>
        ///程式說明：Map ALLERGY SOURCE
        ///</summary>
        private List<Models.CMDALLERGY> MapCMDALLERGYSOURCE(DataTable dt)
        {
            List<Models.CMDALLERGY> result = new List<Models.CMDALLERGY>();
            foreach (DataRow row in dt.Rows)
            {
                result.Add(new CMDALLERGY()
                {
                    PAT_IDNO = row["PAT_IDNO"].ToString(),
                    Text = row["SourceName"].ToString(),
                    Value = row["SourceId"].ToString()

                });
            }
            return result;
        }

        ///<summary>
        ///程式說明：Map ALLERGY SOURCE MultiSelect
        ///</summary>
        private List<Models.CMDALLERGY> MapCMDALLERGYSOURCEMuitiSelect(DataTable dt)
        {
            List<Models.CMDALLERGY> result = new List<Models.CMDALLERGY>();
            foreach (DataRow row in dt.Rows)
            {
                result.Add(new CMDALLERGY()
                {
                    Text = row["SourceName"].ToString(),
                    Value = row["SourceId"].ToString()

                });
            }
            return result;
        }

        ///<summary>
        ///程式說明：Map ALLERGY SOURCE
        ///</summary>
        private List<Models.CMDALLERGY> MapCMDALLERGYDRUG(DataTable dt)
        {
            List<Models.CMDALLERGY> result = new List<Models.CMDALLERGY>();
            foreach (DataRow row in dt.Rows)
            {
                result.Add(new CMDALLERGY()
                {
                    PAT_IDNO = row["PAT_IDNO"].ToString(),
                    Text = row["AllergyDrugName"].ToString(),
                    Value = row["AllergyDrugId"].ToString()

                });
            }
            return result;
        }


    }
}