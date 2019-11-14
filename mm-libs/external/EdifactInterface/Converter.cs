using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EdifactInterface
{
    public class Converter
    {

        public Converter(int iCounter, Int64 iBillingID, Int64 iMaxProcessNumberOfLastBilling, DateTime dtStartDate, DateTime dtEndDate, List<BillingInfo> lsBillingInfo, bool bIsTestData = true)
        {
            // data validation
            if (iCounter > 99999 || iCounter < 1)
            {
                Console.Error.WriteLine("iCounter value not between 1 and 99999, value was:" + iCounter);
                iCounter = 1;
            }
            if (iBillingID > 999999999999 || iBillingID < 0)
            {
                Console.Error.WriteLine("iBillingID value not between 1 and 999999999999, value was:" + iBillingID);
                iBillingID = 1;
            }

            this.iCounter = iCounter;
            this.iBillingID = iBillingID;
            this.iProcessNumber = iMaxProcessNumberOfLastBilling+1;

            bIsTest = bIsTestData;
            if(bIsTest)
                strFileName = "TDRC0" + iCounter.ToString("D3"); // what happens for iCounter>999?
            else
                strFileName = "EDRC0" + iCounter.ToString("D3");

            string strFileName2 = "";
            if (bIsTest)
                strFileName2 = "TDRC0" + iCounter.ToString("D2") + DateTime.Now.ToString("yyMM"); // what happens for iCounter>99?
            else
                strFileName2 = "EDRC0" + iCounter.ToString("D2") + DateTime.Now.ToString("yyMM");

            strExcelFileName = "Report " + DateTime.Now.ToString("dd-MM-yyyy") + ", Abrechnung " + this.iBillingID + ", " + strFileName + ".xls";

            lsExcelOutput = new List<ExcelOutput>();

            // build edifact output
            strOutput = "UNA:+,? '\n";
            strOutput += "UNB+UNOC:3+"+STR_IK_SENDER+"+"+STR_IK_RECEIVER+"+20130807:1602+" + iCounter.ToString("D5") + "+" + strFileName2; 
            if(bIsTest)
                strOutput += "+1'\n";
            else
                strOutput += "'\n";


            // build UNH segments
            int iCounterUNHSegments = 1;

            if (lsBillingInfo == null || lsBillingInfo.Count <= 0)
            {
                strOutput += "UNZ+" + 0 + "+" + iCounter.ToString("D5") + "'";
                lsExcelOutput.Add(new EdifactInterface.ExcelOutput("0", this.iBillingID, this.iProcessNumber, "0", "", "Error, no valid patient with treatment was passed by calling module! BillingInfo argument was malformed.", "", "", "", "", ' ', ' ', 0, new ArticleInfo("0", " ", " ", 0), false, false, "", "", "", "", "", "", ""));
                return;
            }

            foreach (BillingInfo bi in lsBillingInfo) 
            {
                 strOutput += buildUNH(this.iProcessNumber, dtStartDate, dtEndDate, iCounterUNHSegments, bi);
                 this.iProcessNumber++;
                 iCounterUNHSegments++;
                 if (treatmentWithBeva(bi.lsArticles))
                 {
                     strOutput += buildBevaUNH(this.iProcessNumber, dtStartDate, dtEndDate, iCounterUNHSegments, bi);
                     iCounterUNHSegments++;
                     this.iProcessNumber++;
                 }
                 strOutput += buildAdditionalUNH(this.iProcessNumber, dtStartDate, dtEndDate, iCounterUNHSegments, bi);
                 iCounterUNHSegments++;
                 this.iProcessNumber++;
            }
            strOutput += "UNZ+" + (iCounterUNHSegments-1) + "+" + iCounter.ToString("D5") + "'";
        }

        public string getEdifact()
        {
            return strOutput;
        }

        public string getAuf(long lEdifactFileSizeInBytes) // TODO
        {
            //return STR_IK_SENDER + "+" + STR_IK_RECEIVER;
            long lEncryptedEdifactFileSizeInBytes = lEdifactFileSizeInBytes;
            string strFileID = "EDRC0" + iCounter.ToString("D3");
            if (bIsTest)
                strFileID = "TDRC0" + iCounter.ToString("D3");

            string strFileID2 = "EDRC0" + iCounter.ToString("D2") + DateTime.Now.ToString("yyyyMMdd");
            if (bIsTest)
                strFileID2 = "TDRC0" + iCounter.ToString("D2") + DateTime.Now.ToString("yyyyMMdd");

            return "500000" + "01" + "00000348" + "000" + strFileID + "RG140" + STR_IK_SENDER + "      " + STR_IK_SENDER + "      " + STR_IK_RECEIVER + "      " + STR_IK_RECEIVER + "      "
                 + "000000000000" + strFileName + "   " + DateTime.Now.ToString("yyyyMMdd") + "000001" + "0000000000000000000000000000" + "00000000000000" + "000000" + "0" + lEdifactFileSizeInBytes.ToString("D12") + lEncryptedEdifactFileSizeInBytes.ToString("D12") + "I8" + "00" + "00" + "00" + "   " + "0000000000000" + " 00" + "00000000000000000"
                 + "                                                                                                      ";
        }

        public List<ExcelOutput> getExcel()
        {
            return lsExcelOutput;
        } 

        public string getEdifactFilename()
        {
            return strFileName;
        }

        public string getAufFilename()
        {
            return strFileName + ".auf";
        }

        public string getExcelFilename()
        {
            return strExcelFileName;
        }

        public bool getIsTest()
        {
            return bIsTest;
        }

        private string buildUNHHelperBefore(Int64 iProcessNumber, DateTime dtStartDate, DateTime dtEndDate, int iCounterUNHSegments, BillingInfo bi, DiagnosisInfo diMain)
        {
            string strReturn = "";

            strReturn += "UNH+99" + iCounterUNHSegments.ToString("D8") + "+DIR73C:3:0:DR'\n"; // DIR73C = single billing, RGS140 = multiple billing
            strReturn += "IVK+10+01+" + STR_IK_SENDER + "+" + STR_IK_RECEIVER + "+" + iProcessNumber.ToString("D12") + "'\n";
            strReturn += "IBH+"+bi.strDoctorLANR+"+"+bi.strPracticeBSNR+"'\n";
            strReturn += "INF+17172100035++0:7'\n";
            strReturn += "INV+" + bi.strPatientInsuranceState.Substring(0,5) + "+" + bi.strPatientInsuranceNumber + ":" + STR_IK_RECEIVER + "+" + bi.strPatientLastName + ":" + bi.strPatientFirstName + ":" + bi.dtPatientBirthDate.ToString("yyyyMMdd") + "+" + bi.iPatientSex + "'\n";
            strReturn += "DIA+" + diMain.strDiagnosisICD10 + ":" + diMain.cDiagnosisState + ":" + bi.cTreatmentLocalization + "'\n";

            return strReturn;
        }

        private string buildUNHHelperAfter(Int64 iProcessNumber, DateTime dtStartDate, DateTime dtEndDate, int iCounterUNHSegments, BillingInfo bi, DiagnosisInfo diMain)
        {
            string strReturn = "";

            strReturn += "RGI+" + dtStartDate.ToString("yyyyMMdd") + ":" + dtEndDate.ToString("yyyyMMdd") + "+1+" + STR_IK_SENDER + "+" + iProcessNumber.ToString("D12") + "+" + DateTime.Now.ToString("yyyyMMdd") + "++000'\n";
            strReturn += "UNT+10+99" + iCounterUNHSegments.ToString("D8") + "'\n";

            return strReturn;
        }

        private string buildUNH(Int64 iProcessNumber, DateTime dtStartDate, DateTime dtEndDate, int iCounterUNHSegments, BillingInfo bi)
        {            
            string strReturn = "";

            // data validation
            if (bi.strPatientInsuranceState.Length > 5 || bi.strPatientInsuranceState.Length < 1)
            {
                Console.Error.WriteLine("strPatientInsuranceState value not 5 chars long, value was:" + bi.strPatientInsuranceState);
                bi.strPatientInsuranceState = "00000";
            }
            /*if (bi.strPatientInsuranceNumber > 999999999999 || bi.strPatientInsuranceNumber < 0)
            {
                Console.Error.WriteLine("strPatientInsuranceNumber value not between 000000000000 and 999999999999, value was:" + bi.strPatientInsuranceNumber);
                bi.strPatientInsuranceNumber = 1;
            }*/
            if (bi.iPatientSex > 3 || bi.iPatientSex < 1)
            {
                Console.Error.WriteLine("iPatientSex value not between 1 and 3, value was:" + bi.iPatientSex);
                bi.iPatientSex = 3;
            }
            if (bi.cTreatmentLocalization != 'R' && bi.cTreatmentLocalization != 'L')
            {
                Console.Error.WriteLine("cTreatmentLocalization value is neither R nor L, value was:" + bi.cTreatmentLocalization);
                bi.cTreatmentLocalization = 'L';
            }

            DiagnosisInfo diMain = new DiagnosisInfo("H36.0", 'V');
            if (bi.lsDiagnosisInfo != null && bi.lsDiagnosisInfo.Count > 0)
                diMain = bi.lsDiagnosisInfo[0];
            else
            {
                Console.Error.WriteLine("No diagnosis was found. Diagnosis H36.0, V is used.");
                diMain = new DiagnosisInfo("H36.0", 'V');
            }

            strReturn += buildUNHHelperBefore(iProcessNumber, dtStartDate, dtEndDate, iCounterUNHSegments, bi, diMain);

            string strGpos = treatmentToGpos(bi.bTreatmentIsFollowup, bi.iTreatmentNumber, bi.lsArticles, diMain.strDiagnosisICD10);
            string strValue = gposToValue(strGpos);
            string strGrossValue = gposToGrossValue(strGpos);
            strReturn += "ABR++" + strGpos + "+++1+" + strValue + "+++++" + bi.dtTreatment.ToString("yyyyMMdd") + "'\n";
            strReturn += "FKI+" + strGrossValue + "++++++" + strValue + "'\n";

            strReturn += buildUNHHelperAfter(iProcessNumber, dtStartDate, dtEndDate, iCounterUNHSegments, bi, diMain);

            lsExcelOutput.Add(new EdifactInterface.ExcelOutput(bi.strTreatmentID, iBillingID, iProcessNumber, bi.strPatientInsuranceState, bi.strPatientInsuranceNumber, bi.strPatientFirstName, bi.strPatientLastName, bi.strDoctorLANR, bi.strPracticeBSNR, diMain.strDiagnosisICD10, diMain.cDiagnosisState, bi.cTreatmentLocalization, bi.iTreatmentNumber + 1, treatmentMainArticle(bi.lsArticles), treatmentWithOzurdex(bi.lsArticles), treatmentWithBeva(bi.lsArticles), strGpos, strValue, bi.dtTreatment.ToString("MM.dd.yyyy"), bi.strFollowupPractice, bi.strFollowupDoctor, bi.strFollowupStatus, bi.dtFollowup.ToString("MM.dd.yyyy")));
                                                   
            return strReturn;
        }

        private string buildBevaUNH(Int64 iProcessNumber, DateTime dtStartDate, DateTime dtEndDate, int iCounterUNHSegments, BillingInfo bi)
        {
            string strReturn = "";

            DiagnosisInfo diMain = new DiagnosisInfo("H36.0", 'V');
            if (bi.lsDiagnosisInfo != null && bi.lsDiagnosisInfo.Count > 0)
                diMain = bi.lsDiagnosisInfo[0];
            else
                diMain = new DiagnosisInfo("H36.0", 'V');

            strReturn += buildUNHHelperBefore(iProcessNumber, dtStartDate, dtEndDate, iCounterUNHSegments, bi, diMain);

            string strGpos = STR_GPOS_BEVA;
            string strValue = gposToValue(strGpos);
            string strGrossValue = gposToGrossValue(strGpos);
            strReturn += "ABR++" + strGpos + "+++1+" + strValue + "+++++" + bi.dtTreatment.ToString("yyyyMMdd") + "'\n";
            strReturn += "FKI+" + strGrossValue + "++++++" + strValue + "'\n";

            strReturn += buildUNHHelperAfter(iProcessNumber, dtStartDate, dtEndDate, iCounterUNHSegments, bi, diMain);

            lsExcelOutput.Add(new EdifactInterface.ExcelOutput(bi.strTreatmentID, iBillingID, iProcessNumber, bi.strPatientInsuranceState, bi.strPatientInsuranceNumber, bi.strPatientFirstName, bi.strPatientLastName, bi.strDoctorLANR, bi.strPracticeBSNR, "Zusatzposition Bevacizumab", diMain.cDiagnosisState, bi.cTreatmentLocalization, bi.iTreatmentNumber + 1, treatmentMainArticle(bi.lsArticles), false, false, strGpos, strValue, bi.dtTreatment.ToString("MM.dd.yyyy"), bi.strFollowupPractice, bi.strFollowupDoctor, bi.strFollowupStatus, bi.dtFollowup.ToString("MM.dd.yyyy")));

            return strReturn;
        }

        private string buildAdditionalUNH(Int64 iProcessNumber, DateTime dtStartDate, DateTime dtEndDate, int iCounterUNHSegments, BillingInfo bi)
        {
            /*// data validation
            if (bi.strPatientInsuranceState > 99999 || bi.strPatientInsuranceState < 0)
            {
                Console.Error.WriteLine("strPatientInsuranceState value not between 00000 and 99999, value was:" + bi.strPatientInsuranceState);
                bi.strPatientInsuranceState = 1;
            }
            if (bi.strPatientInsuranceNumber > 999999999999 || bi.strPatientInsuranceNumber < 0)
            {
                Console.Error.WriteLine("strPatientInsuranceNumber value not between 000000000000 and 999999999999, value was:" + bi.strPatientInsuranceNumber);
                bi.strPatientInsuranceNumber = 1;
            }
            if (bi.iPatientSex > 3 || bi.iPatientSex < 1)
            {
                Console.Error.WriteLine("iPatientSex value not between 1 and 3, value was:" + bi.iPatientSex);
                bi.iPatientSex = 3;
            }
            DiagnosisInfo diMain = null;
            if (bi.lsDiagnosisInfo.Count > 0)
                diMain = bi.lsDiagnosisInfo[0];
            else
                Console.Error.WriteLine("No diagnosis was found.");
            

            string strReturn = "";
            strReturn += "UNH+99" + iCounterUNHSegments.ToString("D8") + "+DIR73C:3:0:DR'\n"; // DIR73C = single billing, RGS140 = multiple billing
            strReturn += "IVK+10+01+" + STR_IK_SENDER + "+" + STR_IK_RECEIVER + "+" + iBillingID.ToString("D12") + "'\n";
            strReturn += "IBH+" + bi.strDoctorLANR + "+" + bi.strPracticeBSNR + "'\n";
            strReturn += "INF+17172100035++0:7'\n";
            strReturn += "INV+" + bi.strPatientInsuranceState.ToString("D5") + "+" + bi.strPatientInsuranceNumber + ":" + STR_IK_RECEIVER + "+" + bi.strPatientLastName + ":" + bi.strPatientFirstName + ":" + STR_IK_RECEIVER + "+" + bi.iPatientSex + "'\n";
            strReturn += "DIA+" + diMain.strDiagnosisICD10 + ":" + diMain.cDiagnosisState + "+" + bi.cTreatmentLocalization + "'\n";
            string strGpos = treatmentToGpos(bi.bTreatmentIsFollowup, bi.iTreatmentNumber, bi.lsArticles, diMain.strDiagnosisICD10);
            strReturn += "ABR++" + strGpos + "+++1++++++" + bi.dtTreatment.ToString("yyyyMMdd") + "'\n";
            string strValue = gposToValue(strGpos);
            strReturn += "FKI+++++++" + strValue + "'\n";
            strReturn += "RGI+" + dtStartDate.ToString("yyyyMMdd") + ":" + dtEndDate.ToString("yyyyMMdd") + "+1+" + STR_IK_SENDER + "+" + iBillingID.ToString("D12") + "+" + DateTime.Now.ToString("yyyyMMdd") + "++000'\n";
            strReturn += "UNT+10+99" + iCounterUNHSegments.ToString("D8") + "'\n";
        
            // lsExcelOutput.Add(new EdifactInterface.ExcelOutput(10001, 124124124, 2, "Max", "Mustermann", "123456", "654321", "H36.0", 'G', 'R', true, true, "869382", 3, DateTime.Now));

            return strReturn; */

            string strReturn = "";

            DiagnosisInfo diMain = new DiagnosisInfo("H36.0", 'V');
            if (bi.lsDiagnosisInfo != null && bi.lsDiagnosisInfo.Count > 0)
                diMain = bi.lsDiagnosisInfo[0];
            else
                diMain = new DiagnosisInfo("H36.0", 'V');

            strReturn += buildUNHHelperBefore(iProcessNumber, dtStartDate, dtEndDate, iCounterUNHSegments, bi, diMain);

            string strGpos = STR_GPOS_VERGUTUNG;
            string strValue = gposToValue(strGpos);
            string strGrossValue = gposToGrossValue(strGpos);
            strReturn += "ABR++" + strGpos + "+++1+" + strValue + "+++++" + bi.dtTreatment.ToString("yyyyMMdd") + "'\n";
            strReturn += "FKI+" + strGrossValue + "++++++" + strValue + "'\n";

            strReturn += buildUNHHelperAfter(iProcessNumber, dtStartDate, dtEndDate, iCounterUNHSegments, bi, diMain);

            lsExcelOutput.Add(new EdifactInterface.ExcelOutput(bi.strTreatmentID, iBillingID, iProcessNumber, bi.strPatientInsuranceState, bi.strPatientInsuranceNumber, bi.strPatientFirstName, bi.strPatientLastName, bi.strDoctorLANR, bi.strPracticeBSNR, "Zusatzposition Vergütung", diMain.cDiagnosisState, bi.cTreatmentLocalization, bi.iTreatmentNumber + 1, treatmentMainArticle(bi.lsArticles), false, false, strGpos, strValue, bi.dtTreatment.ToString("MM.dd.yyyy"), bi.strFollowupPractice, bi.strFollowupDoctor, bi.strFollowupStatus, bi.dtFollowup.ToString("MM.dd.yyyy")));

            return strReturn;
        }

        private string treatmentToGpos(bool bTreatmentIsFollowup, int iTreatmentNumber, List<ArticleInfo> lsArticles, string strDiagnosisICD10)
        {
            // bTreatmentIsFollowup can be ignored due to how iTreatmentNumber is handled at the moment,
            // first treatment ever is 0, second treatment is iTreatmentNumber=1, etc.

            string strReturn = "36620050"; // first time treatment vs AMD

            if (strDiagnosisICD10.Equals("H36.0") || strDiagnosisICD10.Equals("H35.3")) // treatment for "AMD or Diabetisches Makulaödem"
            {
                strReturn = "36620050"; // first time treatment

                if (iTreatmentNumber >= 3) // treatment 4,5,6
                    strReturn = "36620051";

                if (iTreatmentNumber >= 6) // treatment 7, 8, etc. etc.
                    strReturn = "36620052";

            }
            else if (strDiagnosisICD10.Equals("H34.8")) // treatment for "Mak. nach venösem Netzhautgefäßverschluss"
            {
                strReturn = "36620053"; // first time treatment

                if (iTreatmentNumber >= 3) // treatment 4,5,6
                    strReturn = "36620054";

                if (treatmentWithOzurdex(lsArticles)) // = Ozurdex
                {
                    strReturn = "36620055";
                    if (iTreatmentNumber >= 1) // treatment 2,3,4, etc. etc.
                        strReturn = "36620056";
                }

            }

            return strReturn;
        }

        private bool treatmentWithOzurdex(List<ArticleInfo> lsArticles)
        {
            if (lsArticles == null)
                return false;
            for (int i = 0; i < lsArticles.Count; i++) 
            {
                if (lsArticles[i].strName.ToLower().Contains("ozurdex"))
                    return true;
            }
            return false;
        }

        private bool treatmentWithBeva(List<ArticleInfo> lsArticles)
        {
            if (lsArticles == null)
                return false;
            for (int i = 0; i < lsArticles.Count; i++)
            {
                if (lsArticles[i].strName.ToLower().Contains("bevacizumab"))
                    return true;
            }
            return false;
        }

        private ArticleInfo treatmentMainArticle(List<ArticleInfo> lsArticles)
        {
            ArticleInfo aiReturn = new ArticleInfo("0","Kein Artikel gefunden!","0",0);

            if (lsArticles != null && lsArticles.Count > 0)
                aiReturn = lsArticles[0];
            else
                Console.Error.WriteLine("No article was found.");

            if (treatmentWithOzurdex(lsArticles) && treatmentWithBeva(lsArticles))
                aiReturn.strName = "Ozurdex und Bevacizumab";

            return aiReturn;                         
        }

        private string treatmentMainArticleStr(List<ArticleInfo> lsArticles)
        {
            string strReturn = "Kein Artikel gefunden!";

            if (lsArticles != null && lsArticles.Count > 0)
                strReturn = lsArticles[0].strName;
            else
                Console.Error.WriteLine("No article was found.");

            if (treatmentWithOzurdex(lsArticles) && treatmentWithBeva(lsArticles))
                strReturn = "Ozurdex und Bevacizumab";

            return strReturn;
        }

        private string gposToValue(string strGpos)
        {
            string strReturn = "290,00"; // all non-Ozurdex 

            if (strGpos.Equals("36620055") || strGpos.Equals("36620056"))
                strReturn = "380,00";

            if (strGpos.Equals(STR_GPOS_BEVA))
                strReturn = "75,00";

            if (strGpos.Equals(STR_GPOS_VERGUTUNG))
                strReturn = "25,00";

            //iValue *= iNumberOfInjections;

            return strReturn;
        }

        private string gposToGrossValue(string strGpos)
        {
            string strReturn = "290,00"; // all non-Ozurdex 

            if (strGpos.Equals("36620055") || strGpos.Equals("36620056"))
                strReturn = "380,00";

            if (strGpos.Equals(STR_GPOS_BEVA))
                strReturn = "75,00";

            if (strGpos.Equals(STR_GPOS_VERGUTUNG))
                strReturn = "25,00";

            //iValue *= iNumberOfInjections;

            return strReturn;
        }

        private string strOutput;
        private string strFileName;
        private string strExcelFileName;
        private int iCounter;
        private Int64 iBillingID;
        private Int64 iProcessNumber;
        private bool bIsTest;
        private const string STR_IK_SENDER = "591104483";
        private const string STR_IK_RECEIVER = "109519005"; // Brandenburg 100696012 // Berlin 109519005

        private const string STR_GPOS_BEVA = "06010050";
        private const string STR_GPOS_VERGUTUNG = "36620057";
        private List<ExcelOutput> lsExcelOutput;
    }

    // just a wrapper class
    public class BillingInfo
    {
        public BillingInfo(string _strTreatmentID, string _strPatientInsuranceState, string _strPatientInsuranceNumber, int _iPatientSex, string _strPatientFirstName, string _strPatientLastName, DateTime _dtPatientBirthDate,
                           string _strDoctorLANR, string _strPracticeBSNR, List<DiagnosisInfo> _lsDiagnosisInfo, char _cTreatmentLocalization, bool _bTreatmentIsFollowup, int _iTreatmentNumber,
                           List<ArticleInfo> _lsArticles, DateTime _dtTreatment, string _strFollowupPractice, string _strFollowupDoctor, string _strFollowupStatus, DateTime _dtFollowup) 
        {
            strTreatmentID = _strTreatmentID;
            strPatientInsuranceState = _strPatientInsuranceState;
            strPatientInsuranceNumber = _strPatientInsuranceNumber;
            iPatientSex = _iPatientSex;
            strPatientFirstName = _strPatientFirstName;
            strPatientLastName = _strPatientLastName;
            dtPatientBirthDate = _dtPatientBirthDate;
            strDoctorLANR = _strDoctorLANR;
            strPracticeBSNR = _strPracticeBSNR;
            lsDiagnosisInfo = _lsDiagnosisInfo;
            cTreatmentLocalization = _cTreatmentLocalization;
            bTreatmentIsFollowup = _bTreatmentIsFollowup;
            iTreatmentNumber = _iTreatmentNumber;
            lsArticles = _lsArticles;
            dtTreatment = _dtTreatment;
            strFollowupPractice = _strFollowupPractice;
            strFollowupDoctor = _strFollowupDoctor;
            strFollowupStatus = _strFollowupStatus;
            dtFollowup = _dtFollowup;
        }

        public BillingInfo(string[] arrInit)
        {
           if (arrInit.Length < 14)
            {
                List<EdifactInterface.DiagnosisInfo> lsDiagnosis = new List<EdifactInterface.DiagnosisInfo>();
                List<EdifactInterface.ArticleInfo> lsArticle = new List<EdifactInterface.ArticleInfo>();
                lsDiagnosis.Add(new EdifactInterface.DiagnosisInfo("H35.3", 'G'));
                lsArticle.Add(new EdifactInterface.ArticleInfo("0", "Kein Artikel gefunden", "0000000", 1));

                strTreatmentID = "1234567890";
                strPatientInsuranceState = "00000";
                strPatientInsuranceNumber = "000000000";
                iPatientSex = 3;
                strPatientFirstName = "No";
                strPatientLastName = "Name";
                dtPatientBirthDate = DateTime.Now.AddYears(-70);
                strDoctorLANR = "000000";
                strPracticeBSNR = "000000";
                lsDiagnosisInfo = lsDiagnosis;
                cTreatmentLocalization = 'R';
                bTreatmentIsFollowup = false;
                iTreatmentNumber = 0;
                lsArticles = lsArticle;
                dtTreatment = DateTime.Now;
                strFollowupPractice = "Unknown";
                strFollowupDoctor = "No Name";
                strFollowupStatus = "Unknown";
                dtFollowup = dtTreatment;
            }
            else
            {
                List<EdifactInterface.DiagnosisInfo> lsDiagnosis = new List<EdifactInterface.DiagnosisInfo>();
                List<EdifactInterface.ArticleInfo> lsArticle = new List<EdifactInterface.ArticleInfo>();
                lsDiagnosis.Add(new EdifactInterface.DiagnosisInfo(arrInit[4], arrInit[11][0]));
                lsArticle.Add(new EdifactInterface.ArticleInfo("0", arrInit[3], "0000000", 1));

                strTreatmentID = "1234567890";
                strPatientInsuranceState = arrInit[7];
                strPatientInsuranceNumber = arrInit[8];
                iPatientSex = 3;
                strPatientFirstName = arrInit[1];
                strPatientLastName = arrInit[2];
                dtPatientBirthDate = randomizedBirthDate();
                strDoctorLANR = arrInit[9];
                strPracticeBSNR = arrInit[10];
                lsDiagnosisInfo = lsDiagnosis;
                cTreatmentLocalization = arrInit[12][0];
                bTreatmentIsFollowup = false;
                iTreatmentNumber = Convert.ToInt32(arrInit[13]);
                lsArticles = lsArticle;
                string[] strDateValues = arrInit[0].Split('.');
                dtTreatment = new DateTime(Convert.ToInt32(strDateValues[2]), Convert.ToInt32(strDateValues[0]), Convert.ToInt32(strDateValues[1]));
                strFollowupPractice = "Praxisname";
                strFollowupDoctor = "Dr. Max Mustermann";
                strFollowupStatus = "durchgeführt";
                dtFollowup = dtTreatment;
            }
        }

        public DateTime randomizedBirthDate()
        {
            DateTime dtReturn = DateTime.Now; // DateTime.Now.AddYears(-70);
            
            dtReturn = dtReturn.AddDays(rnd.Next(-30, 31));
            dtReturn = dtReturn.AddMonths(rnd.Next(-12, 13));
            dtReturn = dtReturn.AddYears(-75 + rnd.Next(-10, 16));

            //Console.WriteLine("Generiertes Geburtsdatum: " + dtReturn.ToShortDateString());

            return dtReturn;
        }

        private static Random rnd = new Random();

        public string strTreatmentID;
        public string strPatientInsuranceState;
        public string strPatientInsuranceNumber;
        public int iPatientSex;
        public string strPatientFirstName;
        public string strPatientLastName;
        public DateTime dtPatientBirthDate;
        public List<DiagnosisInfo> lsDiagnosisInfo;
        public char cTreatmentLocalization;
        public string strDoctorLANR;
        public string strPracticeBSNR;
        public bool bTreatmentIsFollowup;
        public int iTreatmentNumber;
        public List<ArticleInfo> lsArticles; 
        public DateTime dtTreatment;
        public string strFollowupPractice;
        public string strFollowupDoctor;
        public string strFollowupStatus;
        public DateTime dtFollowup;
    }

    // just another wrapper class
    public class DiagnosisInfo 
    {
        public DiagnosisInfo(string _strDiagnosisICD10, char _cDiagnosisState)
        {
            strDiagnosisICD10 = _strDiagnosisICD10;
            cDiagnosisState = _cDiagnosisState;
        }

        public string strDiagnosisICD10;
        public char cDiagnosisState;
    }

    // just another wrapper class
    public class ArticleInfo
    {
        public ArticleInfo(string _strArticleID, string _strName, string _strPZN, int _iQuantity)
        {
            strArticleID = _strArticleID;
            strName = _strName;
            strPZN = _strPZN;
            iQuantity = _iQuantity;
        }

        public string strArticleID;
        public string strName;
        public string strPZN;
        public int iQuantity;
    }

    public class ExcelOutput
    {
        public ExcelOutput(string _strTreatmentID, Int64 _iBillingID, Int64 _iProcessNumber, string _strPatientInsuranceState, string _strPatientInsuranceNumber, string _strPatientFirstName, string _strPatientLastName,
                           string _strDoctorLANR, string _strPracticeBSNR, string _strMainDiagnosis, char _cDiagnosisState, char _cTreatmentLocalization, int _iTreatmentNumber,
                           ArticleInfo _aiRelevantArticle, bool _bTreatmentWithOzurdex, bool _bTreatmentWithBeva, string _strGpos, string _strChargedValue, string _strDateOfTreatment,
                           string _strFollowupPractice, string _strFollowupDoctor, string _strFollowupStatus, string _strDateOfFollowup)
        {
            strTreatmentID = _strTreatmentID;
            iBillingID = _iBillingID; 
            iProcessNumber = _iProcessNumber;
            strPatientInsuranceState = _strPatientInsuranceState;
            strPatientInsuranceNumber = _strPatientInsuranceNumber;
            strPatientFirstName = _strPatientFirstName;
            strPatientLastName = _strPatientLastName;
            strDoctorLANR = _strDoctorLANR;
            strPracticeBSNR = _strPracticeBSNR;
            strMainDiagnosis = _strMainDiagnosis;
            cDiagnosisState = _cDiagnosisState;
            cTreatmentLocalization = _cTreatmentLocalization;
            iTreatmentNumber = _iTreatmentNumber;
            aiRelevantArticle = _aiRelevantArticle;
            strGpos = _strGpos;
            bTreatmentWithOzurdex = _bTreatmentWithOzurdex;
            bTreatmentWithBeva = _bTreatmentWithBeva;
            strChargedValue = _strChargedValue;
            strDateOfTreatment = _strDateOfTreatment;
            strFollowupPractice = _strFollowupPractice;
            strFollowupDoctor = _strFollowupDoctor;
            strFollowupStatus = _strFollowupStatus;
            strDateOfFollowup = _strDateOfFollowup;
        }

        public override string ToString()
        {
            return strDateOfTreatment + ",\t" + iProcessNumber.ToString() + ",\t" + strPatientFirstName + " " + strPatientLastName + ",\t\t\t" + aiRelevantArticle.strName + ",\t" + strMainDiagnosis + ",\t\t\t" + strGpos + ",\t" + strChargedValue + ",\t" + strPatientInsuranceState + ",\t" + strPatientInsuranceNumber + ",\t" + strDoctorLANR + ",\t" + strPracticeBSNR + ",\t" + cDiagnosisState.ToString() + ",\t" + cTreatmentLocalization.ToString() + ",\t" + strFollowupPractice + ",\t\t\t" + strFollowupDoctor + ",\t\t" + strDateOfFollowup + ",\t" + strFollowupStatus + ",\t" + iTreatmentNumber.ToString() + ",\t" + bTreatmentWithOzurdex.ToString() + ",\t" + bTreatmentWithBeva.ToString();
        }

        public static List<string> ToStringList(List<ExcelOutput> ls)
        {

            List<string> lsReturn = new List<string>();
            lsReturn.Add("DateOfTreatment,\tProcessNumber,\tPatientFirstName PatientLastName\t\t\tArticleName,\tMainDiagnosis,\t\t\tGpos,\tChargedValue,\tPatientInsuranceState,\tPatientInsuranceNumber,\tDoctorLANR,\tPracticeBSNR,\tDiagnosisState,\tTreatmentLocalization,\tFollowupPractice,\t\t\tFollowupDoctor,\t\tDateOfFollowup,\tFollowupStatus,\tTreatmentNumber,\tTreatmentWithOzurdex,\tTreatmentWithBeva");
            for (int i = 0; i < ls.Count; i++)
                lsReturn.Add(ls[i].ToString());
            return lsReturn;
        }

        public string strTreatmentID;
        public Int64 iBillingID;
        public Int64 iProcessNumber;
        public string strFollowupPractice;
        public string strFollowupDoctor;
        public string strFollowupStatus;
        public string strDateOfFollowup;
        public string strPatientInsuranceState;
        public string strPatientInsuranceNumber;
        public string strPatientFirstName;
        public string strPatientLastName;
        public string strMainDiagnosis;
        public string strDoctorLANR;
        public string strPracticeBSNR;
        public char cDiagnosisState;
        public char cTreatmentLocalization;
        public int iTreatmentNumber;
        public ArticleInfo aiRelevantArticle;
        public bool bTreatmentWithOzurdex;
        public bool bTreatmentWithBeva;
        public string strGpos;
        public string strChargedValue;
        public string strDateOfTreatment;
    }

}
