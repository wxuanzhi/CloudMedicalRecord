using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KendoUIApp_Test.Models;

namespace KendoUIApp_Test.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Welcome to ASP.NET MVC!";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        /*
         * 連接Model
         */
        readonly Models.CodeService codeService = new Models.CodeService();

        /*
         * Chart
         */

        ///<summary>
        ///程式說明：取得PHRCDRCDAYS，用在餘藥天數Chart
        ///</summary>
        [HttpPost]
        public JsonResult GetPHRCDRCChart(Models.ChartModel data, string PatientId)
        {
            List<Models.ChartModel> PHRCDRCBarChart = new List<ChartModel>();
            PHRCDRCBarChart = this.codeService.GetPHRCDRCBarChart().Where(s =>
            s.PAT_IDNO == PatientId).ToList();
            return Json(PHRCDRCBarChart);
        }

        ///<summary>
        ///程式說明：取得PHRCDRCDAYS，用在用藥區間Chart
        ///</summary>
        [HttpPost]
        public JsonResult GetRangeBarChart(Models.PHRCDRC data ,string PatientId)
        {
            List<Models.PHRCDRC> PHRCDRCChart = new List<PHRCDRC>();
            PHRCDRCChart = this.codeService.GetPHRCDRCChart().Where(s =>
            s.PAT_IDNO == PatientId).ToList();
            return Json(PHRCDRCChart);
        }



        /*
         * Grid
         */

        ///<summary>
        ///程式說明：PHRCDRC PatientId Change
        ///</summary>
        [HttpPost]
        public JsonResult PHRCDRCPatientIdChange(Models.PHRCDRC data, string PatientId)
        {
            List<Models.PHRCDRC> PHRCDRCPatientId = new List<PHRCDRC>();
            PHRCDRCPatientId = this.codeService.GetPHRCDRC().Where(s =>
            s.PAT_IDNO == PatientId).ToList();
            return Json(PHRCDRCPatientId);
        }

        ///<summary>
        ///程式說明：CMDTOCC PatientId Change
        ///</summary>
        [HttpPost]
        public JsonResult CMDTOCCPatientIdChange(Models.CMDTOCC data, string PatientId)
        {
            List<Models.CMDTOCC> CMDTOCCPatientId = new List<CMDTOCC>();
            CMDTOCCPatientId = this.codeService.GetCMDTOCC().Where(s =>
            s.PAT_IDNO == PatientId).ToList();
            return Json(CMDTOCCPatientId);
        }

        ///<summary>
        ///程式說明：CMDALLERGY PatientId Change
        ///</summary>
        [HttpPost]
        public JsonResult CMDALLERGYPatientIdChange(Models.CMDALLERGY data, string PatientId)
        {
            List<Models.CMDALLERGY> CMDALLERGYPatientId = new List<CMDALLERGY>();
            CMDALLERGYPatientId = this.codeService.GetCMDALLERGY().Where(s =>
            s.PAT_IDNO == PatientId).ToList();
            return Json(CMDALLERGYPatientId);
        }

        ///<summary>
        ///程式說明：CMDBDRC PatientId Change
        ///</summary>
        [HttpPost]
        public JsonResult CMDBDRCPatientIdChange(Models.CMDBDRC data, string PatientId)
        {
            List<Models.CMDBDRC> CMDBDRCPatientId = new List<CMDBDRC>();
            CMDBDRCPatientId = this.codeService.GetCMDBDRC().Where(s =>
            s.PAT_IDNO == PatientId && s.RECTypeId == "02").ToList();
            return Json(CMDBDRCPatientId);
        }

        ///<summary>
        ///程式說明：OPERATION PatientId Change
        ///</summary>
        [HttpPost]
        public JsonResult OPERATIONPatientIdChange(Models.CMDBDRC data, string PatientId)
        {
            List<Models.CMDBDRC> OPERATIONPatientId = new List<CMDBDRC>();
            OPERATIONPatientId = this.codeService.GetCMDBDRC().Where(s =>
            s.PAT_IDNO == PatientId && s.RECTypeId == "03").ToList();
            return Json(OPERATIONPatientId);
        }

        ///<summary>
        ///程式說明：DENTISTRY PatientId Change
        ///</summary>
        [HttpPost]
        public JsonResult DENTISTRYPatientIdChange(Models.CMDBDRC data, string PatientId)
        {
            List<Models.CMDBDRC> DENTISTRYPatientId = new List<CMDBDRC>();
            DENTISTRYPatientId = this.codeService.GetCMDBDRC().Where(s =>
            s.PAT_IDNO == PatientId && s.RECTypeId == "04").ToList();
            return Json(DENTISTRYPatientId);
        }

        ///<summary>
        ///程式說明：REHABILITATION PatientId Change
        ///</summary>
        [HttpPost]
        public JsonResult REHABILITATIONPatientIdChange(Models.CMDBDRC data, string PatientId)
        {
            List<Models.CMDBDRC> REHABILITATIONPatientId = new List<CMDBDRC>();
            REHABILITATIONPatientId = this.codeService.GetCMDBDRC().Where(s =>
            s.PAT_IDNO == PatientId && s.RECTypeId == "08").ToList();
            return Json(REHABILITATIONPatientId);
        }

        ///<summary>
        ///程式說明：CMDEXAMREPORT PatientId Change
        ///</summary>
        [HttpPost]
        public JsonResult CMDEXAMREPORTPatientIdChange(Models.CMDEXAMREPORT data, string PatientId)
        {
            List<Models.CMDEXAMREPORT> CMDEXAMREPORTPatientId = new List<CMDEXAMREPORT>();
            CMDEXAMREPORTPatientId = this.codeService.GetCMDEXAMREPORT().Where(s =>
            s.PAT_IDNO == PatientId).ToList();
            return Json(CMDEXAMREPORTPatientId);
        }

        /*
         * DropDownList
         */

        ///<summary>
        ///程式說明：PHRCDRC HOSPITAL_ID DropDownList
        ///</summary>
        [HttpPost]
        public JsonResult GetPHRCDRCHOSPITAL_IDDropDownList(Models.PHRCDRC data, string PatientId)
        {
            List<Models.PHRCDRC> GetPHRCDRCHOSPITAL_IDDropDownList = new List<PHRCDRC>();
            GetPHRCDRCHOSPITAL_IDDropDownList = this.codeService.PHRCDRCHOSPITAL_IDDropDownList().Where(s =>
            s.PAT_IDNO == PatientId).ToList();
            return Json(GetPHRCDRCHOSPITAL_IDDropDownList);
        }

        ///<summary>
        ///程式說明：PHRCDRC DRUGSOURCE DropDownList
        ///</summary>
        [HttpPost]
        public JsonResult GetPHRCDRCDRUGSOURCEDropDownList(Models.PHRCDRC data, string PatientId)
        {
            List<Models.PHRCDRC> GetPHRCDRCDRUGSOURCEDropDownList = new List<PHRCDRC>();
            GetPHRCDRCDRUGSOURCEDropDownList = this.codeService.PHRCDRCDRUGSOURCEDropDownList().Where(s =>
            s.PAT_IDNO == PatientId).ToList();
            return Json(GetPHRCDRCDRUGSOURCEDropDownList);
        }

        ///<summary>
        ///程式說明：PHRCDRC DRUGSOURCE MultiSelect
        ///</summary>
        [HttpPost]
        public JsonResult GetPHRCDRCDRUGSOURCEMultiSelect(Models.PHRCDRC data)
        {
            List<Models.PHRCDRC> GetPHRCDRCDRUGSOURCEMultiSelect = new List<PHRCDRC>();
            GetPHRCDRCDRUGSOURCEMultiSelect = this.codeService.PHRCDRCDRUGSOURCEMultiSelect().ToList();
            return Json(GetPHRCDRCDRUGSOURCEMultiSelect);
        }


        ///<summary>
        ///程式說明：PHRCDRC DRUGCOMPCODENM DropDownList
        ///</summary>
        [HttpPost]
        public JsonResult GetPHRCDRCDRUGCOMPCODENMDropDownList(Models.PHRCDRC data, string PatientId)
        {
            List<Models.PHRCDRC> GetPHRCDRCDRUGCOMPCODENMDropDownList = new List<PHRCDRC>();
            GetPHRCDRCDRUGCOMPCODENMDropDownList = this.codeService.PHRCDRCDRUGCOMPCODENMDropDownList().Where(s =>
            s.PAT_IDNO == PatientId).ToList();
            return Json(GetPHRCDRCDRUGCOMPCODENMDropDownList);
        }

        ///<summary>
        ///程式說明：CMDEXAMREPORT HOSPITAL_ID DropDownList
        ///</summary>
        [HttpPost]
        public JsonResult GetCMDEXAMREPORTHOSPITAL_IDDropDownList(Models.CMDEXAMREPORT data, string PatientId)
        {
            List<Models.CMDEXAMREPORT> GetCMDEXAMREPORTHOSPITAL_IDDropDownList = new List<CMDEXAMREPORT>();
            GetCMDEXAMREPORTHOSPITAL_IDDropDownList = this.codeService.CMDEXAMREPORTHOSPITAL_IDDropDownList().Where(s =>
            s.PAT_IDNO == PatientId).ToList();
            return Json(GetCMDEXAMREPORTHOSPITAL_IDDropDownList);
        }

        ///<summary>
        ///程式說明：CMDEXAMREPORT SOURCE DropDownList
        ///</summary>
        [HttpPost]
        public JsonResult GetCMDEXAMREPORTSOURCEDropDownList(Models.CMDEXAMREPORT data, string PatientId)
        {
            List<Models.CMDEXAMREPORT> GetCMDEXAMREPORTSOURCEDropDownList = new List<CMDEXAMREPORT>();
            GetCMDEXAMREPORTSOURCEDropDownList = this.codeService.CMDEXAMREPORTSOURCEDropDownList().Where(s =>
            s.PAT_IDNO == PatientId).ToList();
            return Json(GetCMDEXAMREPORTSOURCEDropDownList);
        }

        ///<summary>
        ///程式說明：CMDEXAMREPORT SOURCE MultiSelect
        ///</summary>
        [HttpPost]
        public JsonResult GetCMDEXAMREPORTSOURCEMultiSelect(Models.CMDEXAMREPORT data)
        {
            List<Models.CMDEXAMREPORT> GetCMDEXAMREPORTSOURCEMultiSelect = new List<CMDEXAMREPORT>();
            GetCMDEXAMREPORTSOURCEMultiSelect = this.codeService.CMDEXAMREPORTSOURCEMultiSelect().ToList();
            return Json(GetCMDEXAMREPORTSOURCEMultiSelect);
        }

        ///<summary>
        ///程式說明：CMDEXAMREPORT SECTION_NAMEC DropDownList
        ///</summary>
        [HttpPost]
        public JsonResult GetCMDEXAMREPORTSECTION_NAMECDropDownList(Models.CMDEXAMREPORT data, string PatientId)
        {
            List<Models.CMDEXAMREPORT> GetCMDEXAMREPORTSECTION_NAMECDropDownList = new List<CMDEXAMREPORT>();
            GetCMDEXAMREPORTSECTION_NAMECDropDownList = this.codeService.CMDEXAMREPORTSECTION_NAMECDropDownList().Where(s =>
            s.PAT_IDNO == PatientId).ToList();
            return Json(GetCMDEXAMREPORTSECTION_NAMECDropDownList);
        }

        ///<summary>
        ///程式說明：CMDEXAMREPORT EXAM_TYPE_NAME DropDownList
        ///</summary>
        [HttpPost]
        public JsonResult GetCMDEXAMREPORTEXAM_TYPE_NAMEDropDownList(Models.CMDEXAMREPORT data, string PatientId)
        {
            List<Models.CMDEXAMREPORT> GetCMDEXAMREPORTEXAM_TYPE_NAMEDropDownList = new List<CMDEXAMREPORT>();
            GetCMDEXAMREPORTEXAM_TYPE_NAMEDropDownList = this.codeService.CMDEXAMREPORTEXAM_TYPE_NAMEDropDownList().Where(s =>
            s.PAT_IDNO == PatientId).ToList();
            return Json(GetCMDEXAMREPORTEXAM_TYPE_NAMEDropDownList);
        }

        ///<summary>
        ///程式說明：CMDEXAMREPORT EXECUTE_DATE DropDownList
        ///</summary>
        [HttpPost]
        public JsonResult GetCMDEXAMREPORTEXECUTE_DATEDropDownList(Models.CMDEXAMREPORT data, string PatientId)
        {
            List<Models.CMDEXAMREPORT> GetCMDEXAMREPORTEXECUTE_DATEDropDownList = new List<CMDEXAMREPORT>();
            GetCMDEXAMREPORTEXECUTE_DATEDropDownList = this.codeService.CMDEXAMREPORTEXECUTE_DATEDropDownList().Where(s =>
            s.PAT_IDNO == PatientId).ToList();
            return Json(GetCMDEXAMREPORTEXECUTE_DATEDropDownList);
        }


        ///<summary>
        ///程式說明：CMDBDRC HOSPITAL_ID DropDownList
        ///</summary>
        [HttpPost]
        public JsonResult GetCMDBDRCHOSPITAL_IDDropDownList(Models.CMDBDRC data, string PatientId)
        {
            List<Models.CMDBDRC> GetCMDBDRCHOSPITAL_IDDropDownList = new List<CMDBDRC>();
            GetCMDBDRCHOSPITAL_IDDropDownList = this.codeService.CMDBDRCHOSPITAL_IDDropDownList().Where(s =>
            s.PAT_IDNO == PatientId && s.RECTypeId == "02").ToList();
            return Json(GetCMDBDRCHOSPITAL_IDDropDownList);
        }

        ///<summary>
        ///程式說明：CMDBDRC SOURCE DropDownList
        ///</summary>
        [HttpPost]
        public JsonResult GetCMDBDRCSOURCEDropDownList(Models.CMDBDRC data, string PatientId)
        {
            List<Models.CMDBDRC> GetCMDBDRCSOURCEDropDownList = new List<CMDBDRC>();
            GetCMDBDRCSOURCEDropDownList = this.codeService.CMDBDRCSOURCEDropDownList().Where(s =>
            s.PAT_IDNO == PatientId && s.RECTypeId == "02").ToList();
            return Json(GetCMDBDRCSOURCEDropDownList);
        }

        ///<summary>
        ///程式說明：CMDBDRC SOURCE MultiSelect
        ///</summary>
        [HttpPost]
        public JsonResult GetCMDBDRCSOURCEMultiSelect(Models.CMDBDRC data)
        {
            List<Models.CMDBDRC> GetCMDBDRCSOURCEMultiSelect = new List<CMDBDRC>();
            GetCMDBDRCSOURCEMultiSelect = this.codeService.CMDBDRCSOURCEMultiSelect().Where(s =>
            s.RECTypeId == "02").ToList();
            return Json(GetCMDBDRCSOURCEMultiSelect);
        }

        ///<summary>
        ///程式說明：CMDBDRC SECTION_NAMEC DropDownList
        ///</summary>
        [HttpPost]
        public JsonResult GetCMDBDRCSECTION_NAMECDropDownList(Models.CMDBDRC data, string PatientId)
        {
            List<Models.CMDBDRC> GetCMDBDRCSECTION_NAMECDropDownList = new List<CMDBDRC>();
            GetCMDBDRCSECTION_NAMECDropDownList = this.codeService.CMDBDRCSECTION_NAMECDropDownList().Where(s =>
            s.PAT_IDNO == PatientId && s.RECTypeId == "02").ToList();
            return Json(GetCMDBDRCSECTION_NAMECDropDownList);
        }
        ///<summary>
        ///程式說明：CMDBDRC REC_NAME DropDownList
        ///</summary>
        [HttpPost]
        public JsonResult GetCMDBDRCREC_NAMEDropDownList(Models.CMDBDRC data, string PatientId)
        {
            List<Models.CMDBDRC> GetCMDBDRCREC_NAMEDropDownList = new List<CMDBDRC>();
            GetCMDBDRCREC_NAMEDropDownList = this.codeService.CMDBDRCREC_NAMEDropDownList().Where(s =>
            s.PAT_IDNO == PatientId && s.RECTypeId == "02").ToList();
            return Json(GetCMDBDRCREC_NAMEDropDownList);
        }

        ///<summary>
        ///程式說明：CMDBDRC NHI_NAME DropDownList
        ///</summary>
        [HttpPost]
        public JsonResult GetCMDBDRCNHI_NAMEDropDownList(Models.CMDBDRC data, string PatientId)
        {
            List<Models.CMDBDRC> GetCMDBDRCNHI_NAMEDropDownList = new List<CMDBDRC>();
            GetCMDBDRCNHI_NAMEDropDownList = this.codeService.CMDBDRCNHI_NAMEDropDownList().Where(s =>
            s.PAT_IDNO == PatientId && s.RECTypeId == "02").ToList();
            return Json(GetCMDBDRCNHI_NAMEDropDownList);
        }

        ///<summary>
        ///程式說明：CMDBDRC EXECUTE_DATE DropDownList
        ///</summary>
        [HttpPost]
        public JsonResult GetCMDBDRCEXECUTE_DATEDropDownList(Models.CMDBDRC data, string PatientId)
        {
            List<Models.CMDBDRC> GetCMDBDRCEXECUTE_DATEDropDownList = new List<CMDBDRC>();
            GetCMDBDRCEXECUTE_DATEDropDownList = this.codeService.CMDBDRCEXECUTE_DATEDropDownList().Where(s =>
            s.PAT_IDNO == PatientId && s.RECTypeId == "02").ToList();
            return Json(GetCMDBDRCEXECUTE_DATEDropDownList);
        }

        ///<summary>
        ///程式說明：OPERATION HOSPITAL_ID DropDownList
        ///</summary>
        [HttpPost]
        public JsonResult GetOPERATIONHOSPITAL_IDDropDownList(Models.CMDBDRC data, string PatientId)
        {
            List<Models.CMDBDRC> GetOPERATIONHOSPITAL_IDDropDownList = new List<CMDBDRC>();
            GetOPERATIONHOSPITAL_IDDropDownList = this.codeService.CMDBDRCHOSPITAL_IDDropDownList().Where(s =>
            s.PAT_IDNO == PatientId && s.RECTypeId == "03").ToList();
            return Json(GetOPERATIONHOSPITAL_IDDropDownList);
        }


        ///<summary>
        ///程式說明：OPERATION SOURCE DropDownList
        ///</summary>
        [HttpPost]
        public JsonResult GetOPERATIONSOURCEDropDownList(Models.CMDBDRC data, string PatientId)
        {
            List<Models.CMDBDRC> GetOPERATIONSOURCEDropDownList = new List<CMDBDRC>();
            GetOPERATIONSOURCEDropDownList = this.codeService.CMDBDRCSOURCEDropDownList().Where(s =>
            s.PAT_IDNO == PatientId && s.RECTypeId == "03").ToList();
            return Json(GetOPERATIONSOURCEDropDownList);
        }


        ///<summary>
        ///程式說明：OPERATION SOURCE MultiSelect
        ///</summary>
        [HttpPost]
        public JsonResult GetOPERATIONSOURCEMultiSelect(Models.CMDBDRC data)
        {
            List<Models.CMDBDRC> GetOPERATIONSOURCEMultiSelect = new List<CMDBDRC>();
            GetOPERATIONSOURCEMultiSelect = this.codeService.CMDBDRCSOURCEMultiSelect().Where(s =>
            s.RECTypeId == "03").ToList();
            return Json(GetOPERATIONSOURCEMultiSelect);
        }

        ///<summary>
        ///程式說明：OPERATION SECTION_NAMEC DropDownList
        ///</summary>
        [HttpPost]
        public JsonResult GetOPERATIONSECTION_NAMECDropDownList(Models.CMDBDRC data, string PatientId)
        {
            List<Models.CMDBDRC> GetOPERATIONSECTION_NAMECDropDownList = new List<CMDBDRC>();
            GetOPERATIONSECTION_NAMECDropDownList = this.codeService.CMDBDRCSECTION_NAMECDropDownList().Where(s =>
            s.PAT_IDNO == PatientId && s.RECTypeId == "03").ToList();
            return Json(GetOPERATIONSECTION_NAMECDropDownList);
        }
        ///<summary>
        ///程式說明：OPERATION REC_NAME DropDownList
        ///</summary>
        [HttpPost]
        public JsonResult GetOPERATIONREC_NAMEDropDownList(Models.CMDBDRC data, string PatientId)
        {
            List<Models.CMDBDRC> GetOPERATIONREC_NAMEDropDownList = new List<CMDBDRC>();
            GetOPERATIONREC_NAMEDropDownList = this.codeService.CMDBDRCREC_NAMEDropDownList().Where(s =>
            s.PAT_IDNO == PatientId && s.RECTypeId == "03").ToList();
            return Json(GetOPERATIONREC_NAMEDropDownList);
        }

        ///<summary>
        ///程式說明：OPERATION NHI_NAME DropDownList
        ///</summary>
        [HttpPost]
        public JsonResult GetOPERATIONNHI_NAMEDropDownList(Models.CMDBDRC data, string PatientId)
        {
            List<Models.CMDBDRC> GetOPERATIONNHI_NAMEDropDownList = new List<CMDBDRC>();
            GetOPERATIONNHI_NAMEDropDownList = this.codeService.CMDBDRCNHI_NAMEDropDownList().Where(s =>
            s.PAT_IDNO == PatientId && s.RECTypeId == "03").ToList();
            return Json(GetOPERATIONNHI_NAMEDropDownList);
        }

        ///<summary>
        ///程式說明：OPERATION EXECUTE_DATE DropDownList
        ///</summary>
        [HttpPost]
        public JsonResult GetOPERATIONEXECUTE_DATEDropDownList(Models.CMDBDRC data, string PatientId)
        {
            List<Models.CMDBDRC> GetOPERATIONEXECUTE_DATEDropDownList = new List<CMDBDRC>();
            GetOPERATIONEXECUTE_DATEDropDownList = this.codeService.CMDBDRCEXECUTE_DATEDropDownList().Where(s =>
            s.PAT_IDNO == PatientId && s.RECTypeId == "03").ToList();
            return Json(GetOPERATIONEXECUTE_DATEDropDownList);
        }

        ///<summary>
        ///程式說明：DENTISTRY HOSPITAL_ID DropDownList
        ///</summary>
        [HttpPost]
        public JsonResult GetDENTISTRYHOSPITAL_IDDropDownList(Models.CMDBDRC data, string PatientId)
        {
            List<Models.CMDBDRC> GetDENTISTRYHOSPITAL_IDDropDownList = new List<CMDBDRC>();
            GetDENTISTRYHOSPITAL_IDDropDownList = this.codeService.CMDBDRCHOSPITAL_IDDropDownList().Where(s =>
            s.PAT_IDNO == PatientId && s.RECTypeId == "04").ToList();
            return Json(GetDENTISTRYHOSPITAL_IDDropDownList);
        }

        ///<summary>
        ///程式說明：DENTISTRY SOURCE DropDownList
        ///</summary>
        [HttpPost]
        public JsonResult GetDENTISTRYSOURCEDropDownList(Models.CMDBDRC data, string PatientId)
        {
            List<Models.CMDBDRC> GetDENTISTRYSOURCEDropDownList = new List<CMDBDRC>();
            GetDENTISTRYSOURCEDropDownList = this.codeService.CMDBDRCSOURCEDropDownList().Where(s =>
            s.PAT_IDNO == PatientId && s.RECTypeId == "04").ToList();
            return Json(GetDENTISTRYSOURCEDropDownList);
        }

        ///<summary>
        ///程式說明：DENTISTRY SOURCE MultiSelect
        ///</summary>
        [HttpPost]
        public JsonResult GetDENTISTRYSOURCEMultiSelect(Models.CMDBDRC data)
        {
            List<Models.CMDBDRC> GetDENTISTRYSOURCEMultiSelect = new List<CMDBDRC>();
            GetDENTISTRYSOURCEMultiSelect = this.codeService.CMDBDRCSOURCEMultiSelect().Where(s =>
            s.RECTypeId == "04").ToList();
            return Json(GetDENTISTRYSOURCEMultiSelect);
        }

        ///<summary>
        ///程式說明：DENTISTRY REC_NAME DropDownList
        ///</summary>
        [HttpPost]
        public JsonResult GetDENTISTRYREC_NAMEDropDownList(Models.CMDBDRC data, string PatientId)
        {
            List<Models.CMDBDRC> GetDENTISTRYREC_NAMEDropDownList = new List<CMDBDRC>();
            GetDENTISTRYREC_NAMEDropDownList = this.codeService.CMDBDRCREC_NAMEDropDownList().Where(s =>
            s.PAT_IDNO == PatientId && s.RECTypeId == "04").ToList();
            return Json(GetDENTISTRYREC_NAMEDropDownList);
        }

        ///<summary>
        ///程式說明：DENTISTRY NHI_NAME DropDownList
        ///</summary>
        [HttpPost]
        public JsonResult GetDENTISTRYNHI_NAMEDropDownList(Models.CMDBDRC data, string PatientId)
        {
            List<Models.CMDBDRC> GetDENTISTRYNHI_NAMEDropDownList = new List<CMDBDRC>();
            GetDENTISTRYNHI_NAMEDropDownList = this.codeService.CMDBDRCNHI_NAMEDropDownList().Where(s =>
            s.PAT_IDNO == PatientId && s.RECTypeId == "04").ToList();
            return Json(GetDENTISTRYNHI_NAMEDropDownList);
        }

        ///<summary>
        ///程式說明：DENTISTRY EXECUTE_DATE DropDownList
        ///</summary>
        [HttpPost]
        public JsonResult GetDENTISTRYEXECUTE_DATEDropDownList(Models.CMDBDRC data, string PatientId)
        {
            List<Models.CMDBDRC> GetDENTISTRYEXECUTE_DATEDropDownList = new List<CMDBDRC>();
            GetDENTISTRYEXECUTE_DATEDropDownList = this.codeService.CMDBDRCEXECUTE_DATEDropDownList().Where(s =>
            s.PAT_IDNO == PatientId && s.RECTypeId == "04").ToList();
            return Json(GetDENTISTRYEXECUTE_DATEDropDownList);
        }

        ///<summary>
        ///程式說明：REHABILITATION HOSPITAL_ID DropDownList
        ///</summary>
        [HttpPost]
        public JsonResult GetREHABILITATIONHOSPITAL_IDDropDownList(Models.CMDBDRC data, string PatientId)
        {
            List<Models.CMDBDRC> GetREHABILITATIONHOSPITAL_IDDropDownList = new List<CMDBDRC>();
            GetREHABILITATIONHOSPITAL_IDDropDownList = this.codeService.CMDBDRCHOSPITAL_IDDropDownList().Where(s =>
            s.PAT_IDNO == PatientId && s.RECTypeId == "08").ToList();
            return Json(GetREHABILITATIONHOSPITAL_IDDropDownList);
        }

        ///<summary>
        ///程式說明：REHABILITATION SOURCE DropDownList
        ///</summary>
        [HttpPost]
        public JsonResult GetREHABILITATIONSOURCEDropDownList(Models.CMDBDRC data, string PatientId)
        {
            List<Models.CMDBDRC> GetREHABILITATIONSOURCEDropDownList = new List<CMDBDRC>();
            GetREHABILITATIONSOURCEDropDownList = this.codeService.CMDBDRCSOURCEDropDownList().Where(s =>
            s.PAT_IDNO == PatientId && s.RECTypeId == "08").ToList();
            return Json(GetREHABILITATIONSOURCEDropDownList);
        }

        ///<summary>
        ///程式說明：REHABILITATION SOURCE MultiSelect
        ///</summary>
        [HttpPost]
        public JsonResult GetREHABILITATIONSOURCEMultiSelect(Models.CMDBDRC data, string PatientId)
        {
            List<Models.CMDBDRC> GetREHABILITATIONSOURCEMultiSelect = new List<CMDBDRC>();
            GetREHABILITATIONSOURCEMultiSelect = this.codeService.CMDBDRCSOURCEMultiSelect().Where(s =>
            s.RECTypeId == "08").ToList();
            return Json(GetREHABILITATIONSOURCEMultiSelect);
        }

        ///<summary>
        ///程式說明：REHABILITATION REC_CODE DropDownList
        ///</summary>
        [HttpPost]
        public JsonResult GetREHABILITATIONREC_CODEDropDownList(Models.CMDBDRC data, string PatientId)
        {
            List<Models.CMDBDRC> GetREHABILITATIONREC_CODEDropDownList = new List<CMDBDRC>();
            GetREHABILITATIONREC_CODEDropDownList = this.codeService.REHABILITATIONREC_CODEDropDownList().Where(s =>
            s.PAT_IDNO == PatientId && s.RECTypeId == "08").ToList();
            return Json(GetREHABILITATIONREC_CODEDropDownList);
        }

        ///<summary>
        ///程式說明：REHABILITATION NHI_NAME DropDownList
        ///</summary>
        [HttpPost]
        public JsonResult GetREHABILITATIONNHI_NAMEDropDownList(Models.CMDBDRC data, string PatientId)
        {
            List<Models.CMDBDRC> GetREHABILITATIONNHI_NAMEDropDownList = new List<CMDBDRC>();
            GetREHABILITATIONNHI_NAMEDropDownList = this.codeService.CMDBDRCNHI_NAMEDropDownList().Where(s =>
            s.PAT_IDNO == PatientId && s.RECTypeId == "08").ToList();
            return Json(GetREHABILITATIONNHI_NAMEDropDownList);
        }

        ///<summary>
        ///程式說明：REHABILITATION EXECUTE_DATE DropDownList
        ///</summary>
        [HttpPost]
        public JsonResult GetREHABILITATIONEXECUTE_DATEDropDownList(Models.CMDBDRC data, string PatientId)
        {
            List<Models.CMDBDRC> GetREHABILITATIONEXECUTE_DATEDropDownList = new List<CMDBDRC>();
            GetREHABILITATIONEXECUTE_DATEDropDownList = this.codeService.CMDBDRCEXECUTE_DATEDropDownList().Where(s =>
            s.PAT_IDNO == PatientId && s.RECTypeId == "08").ToList();
            return Json(GetREHABILITATIONEXECUTE_DATEDropDownList);
        }

        ///<summary>
        ///程式說明：CMDALLERGY HOSPITAL_ID DropDownList
        ///</summary>
        [HttpPost]
        public JsonResult GetCMDALLERGYHOSPITAL_IDDropDownList(Models.CMDALLERGY data, string PatientId)
        {
            List<Models.CMDALLERGY> GetCMDALLERGYHOSPITAL_IDDropDownList = new List<CMDALLERGY>();
            GetCMDALLERGYHOSPITAL_IDDropDownList = this.codeService.CMDALLERGYHOSPITAL_IDDropDownList().Where(s =>
            s.PAT_IDNO == PatientId).ToList();
            return Json(GetCMDALLERGYHOSPITAL_IDDropDownList);
        }

        ///<summary>
        ///程式說明：CMDALLERGY SOURCE DropDownList
        ///</summary>
        [HttpPost]
        public JsonResult GetCMDALLERGYSOURCEDropDownList(Models.CMDALLERGY data, string PatientId)
        {
            List<Models.CMDALLERGY> GetCMDALLERGYSOURCEDropDownList = new List<CMDALLERGY>();
            GetCMDALLERGYSOURCEDropDownList = this.codeService.CMDALLERGYSOURCEDropDownList().Where(s =>
            s.PAT_IDNO == PatientId).ToList();
            return Json(GetCMDALLERGYSOURCEDropDownList);
        }

        ///<summary>
        ///程式說明：CMDALLERGY SOURCE MultiSelect
        ///</summary>
        [HttpPost]
        public JsonResult GetCMDALLERGYSOURCEMultiSelect(Models.CMDALLERGY data)
        {
            List<Models.CMDALLERGY> GetCMDALLERGYSOURCEMultiSelect = new List<CMDALLERGY>();
            GetCMDALLERGYSOURCEMultiSelect = this.codeService.CMDALLERGYSOURCEMultiSelect().ToList();
            return Json(GetCMDALLERGYSOURCEMultiSelect);
        }

        ///<summary>
        ///程式說明：CMDALLERGY DRUG DropDownList
        ///</summary>
        [HttpPost]
        public JsonResult GetCMDALLERGYDRUGDropDownList(Models.CMDALLERGY data, string PatientId)
        {
            List<Models.CMDALLERGY> GetCMDALLERGYDRUGDropDownList = new List<CMDALLERGY>();
            GetCMDALLERGYDRUGDropDownList = this.codeService.CMDALLERGYDRUGDropDownList().Where(s =>
            s.PAT_IDNO == PatientId).ToList();
            return Json(GetCMDALLERGYDRUGDropDownList);
        }






        /*
         * DropDownList Change
         */


        ///<summary>
        ///程式說明：PHRCDRC HOSPITAL_ID DropDownList Change
        ///</summary>
        [HttpPost]
        public JsonResult PHRCDRCHOSPITAL_IDChange(Models.PHRCDRC data,string PatientId)
        {
            List<Models.PHRCDRC> PHRCDRCHOSPITAL_ID = new List<PHRCDRC>();
            PHRCDRCHOSPITAL_ID = this.codeService.GetPHRCDRC().Where(s =>
            s.HospitalId == data.HOSPITAL_ID).Where(o =>
            o.PAT_IDNO == PatientId).ToList();
            return Json(PHRCDRCHOSPITAL_ID);

        }

        ///<summary>
        ///程式說明：PHRCDRC DRUGSOURCE MultiSelect Change
        ///</summary>
        [HttpPost]
        public JsonResult PHRCDRCDRUGSOURCEMultiSelectChange(Models.PHRCDRC data, string PatientId, string DrugSource)
        {
            string[] sources = DrugSource.Split(',');
            List<Models.PHRCDRC> PHRCDRCDRUGSOURCE = new List<PHRCDRC>();
            PHRCDRCDRUGSOURCE = this.codeService.GetPHRCDRC().Where(o => sources.Contains(o.DrugSourceId) && o.PAT_IDNO == PatientId).ToList();
            return Json(PHRCDRCDRUGSOURCE);
        }

        ///<summary>
        ///程式說明：PHRCDRC DRUGCOMPCODENM DropDownList Change
        ///</summary>
        [HttpPost]
        public JsonResult PHRCDRCDRUGCOMPCODENMChange(Models.PHRCDRC data, string PatientId)
        {
            List<Models.PHRCDRC> PHRCDRCDRUGCOMPCODENM = new List<PHRCDRC>();
            PHRCDRCDRUGCOMPCODENM = this.codeService.GetPHRCDRC().Where(s =>
            s.UDNNHICODE == data.DRUGCOMPCODENM).Where(o =>
            o.PAT_IDNO == PatientId).ToList();
            return Json(PHRCDRCDRUGCOMPCODENM);
        }

        ///<summary>
        ///程式說明：CMDEXAMREPORT HOSPITAL_ID DropDownList Change
        ///</summary>
        [HttpPost]
        public JsonResult CMDEXAMREPORTHOSPITAL_IDChange(Models.CMDEXAMREPORT data, string PatientId)
        {
            List<Models.CMDEXAMREPORT> CMDEXAMREPORTHOSPITAL_ID = new List<CMDEXAMREPORT>();
            CMDEXAMREPORTHOSPITAL_ID = this.codeService.GetCMDEXAMREPORT().Where(s =>
            s.HospitalId == data.HOSPITAL_ID).Where(o =>
            o.PAT_IDNO == PatientId).ToList();
            return Json(CMDEXAMREPORTHOSPITAL_ID);
        }

        ///<summary>
        ///程式說明：CMDEXAMREPORT SOURCE MultiSelect Change
        ///</summary>
        [HttpPost]
        public JsonResult CMDEXAMREPORTSOURCEMultiSelectChange(Models.CMDEXAMREPORT data, string PatientId, string SOURCE)
        {
            string[] sources = SOURCE.Split(',');
            List<Models.CMDEXAMREPORT> CMDEXAMREPORTSOURCE = new List<CMDEXAMREPORT>();
            CMDEXAMREPORTSOURCE = this.codeService.GetCMDEXAMREPORT().Where(o => sources.Contains(o.SourceId) && o.PAT_IDNO == PatientId).ToList();
            return Json(CMDEXAMREPORTSOURCE);
        }

        ///<summary>
        ///程式說明：CMDEXAMREPORT SECTION_NAMEC DropDownList Change
        ///</summary>
        [HttpPost]
        public JsonResult CMDEXAMREPORTSECTION_NAMECChange(Models.CMDEXAMREPORT data, string PatientId)
        {
            List<Models.CMDEXAMREPORT> CMDEXAMREPORTSECTION_NAMEC = new List<CMDEXAMREPORT>();
            CMDEXAMREPORTSECTION_NAMEC = this.codeService.GetCMDEXAMREPORT().Where(s =>
            s.SECTION == data.SECTION_NAMEC).Where(o =>
            o.PAT_IDNO == PatientId).ToList();
            return Json(CMDEXAMREPORTSECTION_NAMEC);
        }

        ///<summary>
        ///程式說明：CMDEXAMREPORT EXAM_TYPE_NAME DropDownList Change
        ///</summary>
        [HttpPost]
        public JsonResult CMDEXAMREPORTEXAM_TYPE_NAMEChange(Models.CMDEXAMREPORT data, string PatientId)
        {
            List<Models.CMDEXAMREPORT> CMDEXAMREPORTEXAM_TYPE_NAME = new List<CMDEXAMREPORT>();
            CMDEXAMREPORTEXAM_TYPE_NAME = this.codeService.GetCMDEXAMREPORT().Where(s =>
            s.EXAM_TYPE_CODE == data.EXAM_TYPE_NAME).Where(o =>
            o.PAT_IDNO == PatientId).ToList();
            return Json(CMDEXAMREPORTEXAM_TYPE_NAME);
        }

        ///<summary>
        ///程式說明：CMDEXAMREPORT EXECUTE_DATE DropDownList Change
        ///</summary>
        [HttpPost]
        public JsonResult CMDEXAMREPORTEXECUTE_DATEChange(Models.CMDEXAMREPORT data, string PatientId)
        {
            List<Models.CMDEXAMREPORT> CMDEXAMREPORTEXECUTE_DATE = new List<CMDEXAMREPORT>();
            CMDEXAMREPORTEXECUTE_DATE = this.codeService.GetCMDEXAMREPORT().Where(s =>
            s.EXECUTE_DATE == data.EXECUTE_DATE).Where(o =>
            o.PAT_IDNO == PatientId).ToList();
            return Json(CMDEXAMREPORTEXECUTE_DATE);
        }


        ///<summary>
        ///程式說明：CMDBDRC HOSPITAL_ID DropDownList Change
        ///</summary>
        [HttpPost]
        public JsonResult CMDBDRCHOSPITAL_IDChange(Models.CMDBDRC data, string PatientId)
        {
            List<Models.CMDBDRC> CMDBDRCHOSPITAL_ID = new List<CMDBDRC>();
            CMDBDRCHOSPITAL_ID = this.codeService.GetCMDBDRC().Where(s =>
            s.HospitalId == data.HOSPITAL_ID && s.RECTypeId == "02").Where(o =>
            o.PAT_IDNO == PatientId).ToList();
            return Json(CMDBDRCHOSPITAL_ID);
        }

        ///<summary>
        ///程式說明：CMDBDRC SOURCE MultiSelect Change
        ///</summary>
        [HttpPost]
        public JsonResult CMDBDRCSOURCEMultiSelectChange(Models.CMDBDRC data, string PatientId ,string SOURCE)
        {
            string[] sources = SOURCE.Split(',');
            List<Models.CMDBDRC> CMDBDRCSOURCE = new List<CMDBDRC>();
            CMDBDRCSOURCE = this.codeService.GetCMDBDRC().Where(o =>
            sources.Contains(o.SourceId) && o.PAT_IDNO == PatientId && o.RECTypeId == "02").ToList();
            return Json(CMDBDRCSOURCE);
        }

        ///<summary>
        ///程式說明：CMDBDRC SECTION_NAMEC DropDownList Change
        ///</summary>
        [HttpPost]
        public JsonResult CMDBDRCSECTION_NAMECChange(Models.CMDBDRC data, string PatientId)
        {
            List<Models.CMDBDRC> CMDBDRCSECTION_NAMEC = new List<CMDBDRC>();
            CMDBDRCSECTION_NAMEC = this.codeService.GetCMDBDRC().Where(s =>
            s.SECTION == data.SECTION_NAMEC && s.RECTypeId == "02").Where(o =>
            o.PAT_IDNO == PatientId).ToList();
            return Json(CMDBDRCSECTION_NAMEC);
        }

        ///<summary>
        ///程式說明：CMDBDRC REC_NAME DropDownList Change
        ///</summary>
        [HttpPost]
        public JsonResult CMDBDRCREC_NAMEChange(Models.CMDBDRC data, string PatientId)
        {
            List<Models.CMDBDRC> CMDBDRCREC_NAME = new List<CMDBDRC>();
            CMDBDRCREC_NAME = this.codeService.GetCMDBDRC().Where(s =>
            s.REC_CODE == data.REC_NAME && s.RECTypeId == "02").Where(o =>
            o.PAT_IDNO == PatientId).ToList();
            return Json(CMDBDRCREC_NAME);
        }

        ///<summary>
        ///程式說明：CMDBDRC NHI_NAME DropDownList Change
        ///</summary>
        [HttpPost]
        public JsonResult CMDBDRCNHI_NAMEChange(Models.CMDBDRC data, string PatientId)
        {
            List<Models.CMDBDRC> CMDBDRCNHI_NAME = new List<CMDBDRC>();
            CMDBDRCNHI_NAME = this.codeService.GetCMDBDRC().Where(s =>
            s.NHI_CODE == data.NHI_NAME && s.RECTypeId == "02").Where(o =>
            o.PAT_IDNO == PatientId).ToList();
            return Json(CMDBDRCNHI_NAME);
        }

        ///<summary>
        ///程式說明：CMDBDRC EXECUTE_DATE DropDownList Change
        ///</summary>
        [HttpPost]
        public JsonResult CMDBDRCEXECUTE_DATEChange(Models.CMDBDRC data, string PatientId)
        {
            List<Models.CMDBDRC> CMDBDRCEXECUTE_DATE = new List<CMDBDRC>();
            CMDBDRCEXECUTE_DATE = this.codeService.GetCMDBDRC().Where(s =>
            s.EXECUTE_DATE == data.EXECUTE_DATE && s.RECTypeId == "02").Where(o =>
            o.PAT_IDNO == PatientId).ToList();
            return Json(CMDBDRCEXECUTE_DATE);
        }

        ///<summary>
        ///程式說明：OPERATION HOSPITAL_ID DropDownList Change
        ///</summary>
        [HttpPost]
        public JsonResult OPERATIONHOSPITAL_IDChange(Models.CMDBDRC data, string PatientId)
        {
            List<Models.CMDBDRC> OPERATIONHOSPITAL_ID = new List<CMDBDRC>();
            OPERATIONHOSPITAL_ID = this.codeService.GetCMDBDRC().Where(s =>
            s.HospitalId == data.HOSPITAL_ID && s.RECTypeId == "03").Where(o =>
            o.PAT_IDNO == PatientId).ToList();
            return Json(OPERATIONHOSPITAL_ID);
        }

        ///<summary>
        ///程式說明：OPERATION SOURCE MultiSelect Change
        ///</summary>
        [HttpPost]
        public JsonResult OPERATIONSOURCEMultiSelectChange(Models.CMDBDRC data, string PatientId, string SOURCE)
        {
            string[] sources = SOURCE.Split(',');
            List<Models.CMDBDRC> OPERATIONSOURCE = new List<CMDBDRC>();
            OPERATIONSOURCE = this.codeService.GetCMDBDRC().Where(o => sources.Contains(o.SourceId) && o.PAT_IDNO == PatientId && o.RECTypeId == "03").ToList();
            return Json(OPERATIONSOURCE);
        }

        ///<summary>
        ///程式說明：OPERATION SECTION_NAMEC DropDownList Change
        ///</summary>
        [HttpPost]
        public JsonResult OPERATIONSECTION_NAMECChange(Models.CMDBDRC data, string PatientId)
        {
            List<Models.CMDBDRC> OPERATIONSECTION_NAMEC = new List<CMDBDRC>();
            OPERATIONSECTION_NAMEC = this.codeService.GetCMDBDRC().Where(s =>
            s.SECTION == data.SECTION_NAMEC && s.RECTypeId == "03").Where(o =>
            o.PAT_IDNO == PatientId).ToList();
            return Json(OPERATIONSECTION_NAMEC);
        }

        ///<summary>
        ///程式說明：OPERATION REC_NAME DropDownList Change
        ///</summary>
        [HttpPost]
        public JsonResult OPERATIONREC_NAMEChange(Models.CMDBDRC data, string PatientId)
        {
            List<Models.CMDBDRC> OPERATIONREC_NAME = new List<CMDBDRC>();
            OPERATIONREC_NAME = this.codeService.GetCMDBDRC().Where(s =>
            s.REC_CODE == data.REC_NAME && s.RECTypeId == "03").Where(o =>
            o.PAT_IDNO == PatientId).ToList();
            return Json(OPERATIONREC_NAME);
        }

        ///<summary>
        ///程式說明：OPERATION NHI_NAME DropDownList Change
        ///</summary>
        [HttpPost]
        public JsonResult OPERATIONNHI_NAMEChange(Models.CMDBDRC data, string PatientId)
        {
            List<Models.CMDBDRC> OPERATIONNHI_NAME = new List<CMDBDRC>();
            OPERATIONNHI_NAME = this.codeService.GetCMDBDRC().Where(s =>
            s.NHI_CODE == data.NHI_NAME && s.RECTypeId == "03").Where(o =>
            o.PAT_IDNO == PatientId).ToList();
            return Json(OPERATIONNHI_NAME);
        }

        ///<summary>
        ///程式說明：OPERATION EXECUTE_DATE DropDownList Change
        ///</summary>
        [HttpPost]
        public JsonResult OPERATIONEXECUTE_DATEChange(Models.CMDBDRC data, string PatientId)
        {
            List<Models.CMDBDRC> OPERATIONEXECUTE_DATE = new List<CMDBDRC>();
            OPERATIONEXECUTE_DATE = this.codeService.GetCMDBDRC().Where(s =>
            s.EXECUTE_DATE == data.EXECUTE_DATE && s.RECTypeId == "03").Where(o =>
            o.PAT_IDNO == PatientId).ToList();
            return Json(OPERATIONEXECUTE_DATE);
        }


        ///<summary>
        ///程式說明：DENTISTRY HOSPITAL_ID DropDownList Change
        ///</summary>
        [HttpPost]
        public JsonResult DENTISTRYHOSPITAL_IDChange(Models.CMDBDRC data, string PatientId)
        {
            List<Models.CMDBDRC> DENTISTRYHOSPITAL_ID = new List<CMDBDRC>();
            DENTISTRYHOSPITAL_ID = this.codeService.GetCMDBDRC().Where(s =>
            s.HospitalId == data.HOSPITAL_ID && s.RECTypeId == "04").Where(o =>
            o.PAT_IDNO == PatientId).ToList();
            return Json(DENTISTRYHOSPITAL_ID);
        }

        ///<summary>
        ///程式說明：DENTISTRY SOURCE MultiSelect Change
        ///</summary>
        [HttpPost]
        public JsonResult DENTISTRYSOURCEMultiSelectChange(Models.CMDBDRC data, string PatientId, string SOURCE)
        {
            string[] sources = SOURCE.Split(',');
            List<Models.CMDBDRC> DENTISTRYSOURCE = new List<CMDBDRC>();
            DENTISTRYSOURCE = this.codeService.GetCMDBDRC().Where(o => sources.Contains(o.SourceId) && o.PAT_IDNO == PatientId && o.RECTypeId == "04").ToList();
            return Json(DENTISTRYSOURCE);
        }

        ///<summary>
        ///程式說明：DENTISTRY SECTION_NAMEC DropDownList Change
        ///</summary>
        [HttpPost]
        public JsonResult DENTISTRYSECTION_NAMECChange(Models.CMDBDRC data, string PatientId)
        {
            List<Models.CMDBDRC> DENTISTRYSECTION_NAMEC = new List<CMDBDRC>();
            DENTISTRYSECTION_NAMEC = this.codeService.GetCMDBDRC().Where(s =>
            s.SECTION == data.SECTION_NAMEC && s.RECTypeId == "04").Where(o =>
            o.PAT_IDNO == PatientId).ToList();
            return Json(DENTISTRYSECTION_NAMEC);
        }

        ///<summary>
        ///程式說明：DENTISTRY REC_NAME DropDownList Change
        ///</summary>
        [HttpPost]
        public JsonResult DENTISTRYREC_NAMEChange(Models.CMDBDRC data, string PatientId)
        {
            List<Models.CMDBDRC> DENTISTRYREC_NAME = new List<CMDBDRC>();
            DENTISTRYREC_NAME = this.codeService.GetCMDBDRC().Where(s =>
            s.REC_CODE == data.REC_NAME && s.RECTypeId == "04").Where(o =>
            o.PAT_IDNO == PatientId).ToList();
            return Json(DENTISTRYREC_NAME);
        }

        ///<summary>
        ///程式說明：DENTISTRY NHI_NAME DropDownList Change
        ///</summary>
        [HttpPost]
        public JsonResult DENTISTRYNHI_NAMEChange(Models.CMDBDRC data, string PatientId)
        {
            List<Models.CMDBDRC> DENTISTRYNHI_NAME = new List<CMDBDRC>();
            DENTISTRYNHI_NAME = this.codeService.GetCMDBDRC().Where(s =>
            s.NHI_CODE == data.NHI_NAME && s.RECTypeId == "04").Where(o =>
            o.PAT_IDNO == PatientId).ToList();
            return Json(DENTISTRYNHI_NAME);
        }

        ///<summary>
        ///程式說明：DENTISTRY EXECUTE_DATE DropDownList Change
        ///</summary>
        [HttpPost]
        public JsonResult DENTISTRYEXECUTE_DATEChange(Models.CMDBDRC data, string PatientId)
        {
            List<Models.CMDBDRC> DENTISTRYEXECUTE_DATE = new List<CMDBDRC>();
            DENTISTRYEXECUTE_DATE = this.codeService.GetCMDBDRC().Where(s =>
            s.EXECUTE_DATE == data.EXECUTE_DATE && s.RECTypeId == "04").Where(o =>
            o.PAT_IDNO == PatientId).ToList();
            return Json(DENTISTRYEXECUTE_DATE);
        }


        ///<summary>
        ///程式說明：REHABILITATION HOSPITAL_ID DropDownList Change
        ///</summary>
        [HttpPost]
        public JsonResult REHABILITATIONHOSPITAL_IDChange(Models.CMDBDRC data, string PatientId)
        {
            List<Models.CMDBDRC> REHABILITATIONHOSPITAL_ID = new List<CMDBDRC>();
            REHABILITATIONHOSPITAL_ID = this.codeService.GetCMDBDRC().Where(s =>
            s.HospitalId == data.HOSPITAL_ID && s.RECTypeId == "08").Where(o =>
            o.PAT_IDNO == PatientId).ToList();
            return Json(REHABILITATIONHOSPITAL_ID);
        }

        ///<summary>
        ///程式說明：REHABILITATION SOURCE MultiSelect Change
        ///</summary>
        [HttpPost]
        public JsonResult REHABILITATIONSOURCEMultiSelectChange(Models.CMDBDRC data, string PatientId, string SOURCE)
        {
            string[] sources = SOURCE.Split(',');
            List<Models.CMDBDRC> REHABILITATIONSOURCE = new List<CMDBDRC>();
            REHABILITATIONSOURCE = this.codeService.GetCMDBDRC().Where(o => sources.Contains(o.SourceId) && o.PAT_IDNO == PatientId && o.RECTypeId == "08").ToList();
            return Json(REHABILITATIONSOURCE);
        }

        ///<summary>
        ///程式說明：REHABILITATION SECTION_NAMEC DropDownList Change
        ///</summary>
        [HttpPost]
        public JsonResult REHABILITATIONSECTION_NAMECChange(Models.CMDBDRC data, string PatientId)
        {
            List<Models.CMDBDRC> REHABILITATIONSECTION_NAMEC = new List<CMDBDRC>();
            REHABILITATIONSECTION_NAMEC = this.codeService.GetCMDBDRC().Where(s =>
            s.SECTION == data.SECTION_NAMEC && s.RECTypeId == "08").Where(o =>
            o.PAT_IDNO == PatientId).ToList();
            return Json(REHABILITATIONSECTION_NAMEC);
        }

        ///<summary>
        ///程式說明：REHABILITATION REC_CODE DropDownList Change
        ///</summary>
        [HttpPost]
        public JsonResult REHABILITATIONREC_CODEChange(Models.CMDBDRC data, string PatientId)
        {
            List<Models.CMDBDRC> REHABILITATIONREC_CODE = new List<CMDBDRC>();
            REHABILITATIONREC_CODE = this.codeService.GetCMDBDRC().Where(s =>
            s.REC_CODE == data.REC_CODE && s.RECTypeId == "08").Where(o =>
            o.PAT_IDNO == PatientId).ToList();
            return Json(REHABILITATIONREC_CODE);
        }

        ///<summary>
        ///程式說明：REHABILITATION NHI_NAME DropDownList Change
        ///</summary>
        [HttpPost]
        public JsonResult REHABILITATIONNHI_NAMEChange(Models.CMDBDRC data, string PatientId)
        {
            List<Models.CMDBDRC> REHABILITATIONNHI_NAME = new List<CMDBDRC>();
            REHABILITATIONNHI_NAME = this.codeService.GetCMDBDRC().Where(s =>
            s.NHI_CODE == data.NHI_NAME && s.RECTypeId == "08").Where(o =>
            o.PAT_IDNO == PatientId).ToList();
            return Json(REHABILITATIONNHI_NAME);
        }

        ///<summary>
        ///程式說明：REHABILITATION EXECUTE_DATE DropDownList Change
        ///</summary>
        [HttpPost]
        public JsonResult REHABILITATIONEXECUTE_DATEChange(Models.CMDBDRC data, string PatientId)
        {
            List<Models.CMDBDRC> REHABILITATIONEXECUTE_DATE = new List<CMDBDRC>();
            REHABILITATIONEXECUTE_DATE = this.codeService.GetCMDBDRC().Where(s =>
            s.EXECUTE_DATE == data.EXECUTE_DATE && s.RECTypeId == "08").Where(o =>
            o.PAT_IDNO == PatientId).ToList();
            return Json(REHABILITATIONEXECUTE_DATE);
        }


        ///<summary>
        ///程式說明：CMDALLERGY HOSPITAL_ID DropDownList Change
        ///</summary>
        [HttpPost]
        public JsonResult CMDALLERGYHOSPITAL_IDChange(Models.CMDALLERGY data, string PatientId)
        {
            List<Models.CMDALLERGY> CMDALLERGYHOSPITAL_ID = new List<CMDALLERGY>();
            CMDALLERGYHOSPITAL_ID = this.codeService.GetCMDALLERGY().Where(s =>
            s.HospitalId == data.HOSPITAL_ID).Where(o =>
            o.PAT_IDNO == PatientId).ToList();
            return Json(CMDALLERGYHOSPITAL_ID);
        }

        ///<summary>
        ///程式說明：CMDALLERGY SOURCE MultiSelect Change
        ///</summary>
        [HttpPost]
        public JsonResult CMDALLERGYSOURCEMultiSelectChange(Models.CMDALLERGY data, string PatientId, string SOURCE)
        {
            string[] sources = SOURCE.Split(',');
            List<Models.CMDALLERGY> CMDALLERGYSOURCE = new List<CMDALLERGY>();
            CMDALLERGYSOURCE = this.codeService.GetCMDALLERGY().Where(o => sources.Contains(o.SourceId) && o.PAT_IDNO == PatientId).ToList();
            return Json(CMDALLERGYSOURCE);
        }

        ///<summary>
        ///程式說明：CMDALLERGY DRUG DropDownList Change
        ///</summary>
        [HttpPost]
        public JsonResult CMDALLERGYDRUGChange(Models.CMDALLERGY data, string PatientId)
        {
            List<Models.CMDALLERGY> CMDALLERGYDRUG = new List<CMDALLERGY>();
            CMDALLERGYDRUG = this.codeService.GetCMDALLERGY().Where(s =>
            s.AllergyDrugId == data.DRUG).Where(o =>
            o.PAT_IDNO == PatientId).ToList();
            return Json(CMDALLERGYDRUG);
        }

    }
}
