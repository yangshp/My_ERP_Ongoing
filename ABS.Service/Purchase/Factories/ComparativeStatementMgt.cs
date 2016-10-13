﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ABS.Data.BaseFactories;
using ABS.Data.BaseInterfaces;
using ABS.Models;

using ABS.Models.ViewModel.Inventory;
using ABS.Service.AllServiceClasses;
using ABS.Service.Inventory.Interfaces;
using System.Transactions;
using System.Data;
using System.Data.SqlClient;
using ABS.Models.ViewModel.SystemCommon;
using System.Collections;
using System.Data.Common;
using ABS.Models.ViewModel.Sales;
using ABS.Models.ViewModel.Purchase;
using ABS.Utility.Attributes;
using ABS.Utility;


namespace ABS.Service.Inventory.Factories
{

    public class ComparativeStatementMgt : iComparativeStatementMgt
    {
        private ERP_Entities _ctxCmn = null;
        private iGenericFactory<vmComparativeStatement> GFactory_GF_Comparative = null;
        private iGenericFactory<InvRequisitionMaster> GFactory_GF_Requisition = null;
        private iGenericFactory<vmQuotation> GFactory_GF_Quotation = null;
        private iGenericFactory_EF<CmnCombo> GenericFactory_EF_CmnCombo;
        private iGenericFactory<vmChallan> GenericFactory_GF_vmChallan;
        private iGenericFactory_EF<CmnDocument> GenericFactory_CmnDocument = null;
        private iGenericFactory_EF<CmnDocumentPath> GenericFactory_CmnDocumentPath = null;



        public IEnumerable<vmComparativeStatement> GetCSList()
        {
            IEnumerable<vmComparativeStatement> lstcsMaster = null;
            try
            {
                using (_ctxCmn = new ERP_Entities())
                {
                    lstcsMaster = _ctxCmn.PurchaseCSMasters.Where(m => m.IsDeleted == false).Select(m => new vmComparativeStatement { CSID = m.CSID, CSNo = m.CSNo, CompanyID = m.CompanyID }).ToList();
                }

            }
            catch (Exception e)
            {
                e.ToString();
            }
            return lstcsMaster;
        }


        public IEnumerable<vmComparativeStatement> GetCSMaster(vmCmnParameters objcmnParam, out int recordsTotal)
        {         
            IEnumerable<vmComparativeStatement> lstCSPaging = null;
            recordsTotal = 0;

            try
            {
                using (_ctxCmn = new ERP_Entities())
                {
                    lstCSPaging = (from CS in _ctxCmn.PurchaseCSMasters.Where(s => s.IsDeleted == false && s.CompanyID == objcmnParam.loggedCompany)                                                                           
                                          select new vmComparativeStatement
                                          {                                      
                                              CSID  = CS.CSID,
                                              CSNo = CS.CSNo,
                                              CSDate = CS.CSDate,
                                              Description = CS.Description

                                          }).ToList();
                    lstCSPaging = lstCSPaging.OrderByDescending(x => x.QuotationID).Skip(objcmnParam.pageNumber).Take(objcmnParam.pageSize).ToList();
                    recordsTotal = lstCSPaging.Count();
                }

            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return lstCSPaging;
        }

        public string SaveUpdateCSMasterNdetails(PurchaseCSMaster CSMaster, List<PurchaseCSDetail> CSDetails, int menuID)
        {         
            _ctxCmn = new ERP_Entities();
            GenericFactory_EF_CmnCombo = new CmnCombo_EF();
            string result = "";
            if (CSMaster.CSID > 0)
            {
                //using (TransactionScope transaction = new TransactionScope())
                //{
                //    try
                //    {
                //        Int64 poID = chMaster.POID;
                //        IEnumerable<PurchasePOMaster> lstPurchasePOMaster = (from qcm in _ctxCmn.PurchasePOMasters.Where(m => m.POID == poID && m.CompanyID == chMaster.CompanyID) select qcm).ToList();
                //        PurchasePOMaster objPurchasePOMaster = new PurchasePOMaster();
                //        foreach (PurchasePOMaster qcms in lstPurchasePOMaster)
                //        {
                //            qcms.UpdateBy = chMaster.CreateBy;
                //            qcms.UpdateOn = DateTime.Now;
                //            qcms.UpdatePc =  HostService.GetIP();
                //            qcms.POID = chMaster.POID;
                //            qcms.CurrencyID = chMaster.CurrencyID;
                //            qcms.Amount = chMaster.Amount;
                //            qcms.PODate = chMaster.PODate;
                //            qcms.BankAccountNo = chMaster.BankAccountNo;
                //            qcms.DepartmentID = chMaster.DepartmentID;
                //            qcms.TransactionTypeID = chMaster.TransactionTypeID;
                //            qcms.BankBranchID = chMaster.BankBranchID;
                //            qcms.IsDeleted = false;
                //            qcms.BankID = chMaster.BankID;
                //            qcms.PartyID = chMaster.PartyID;
                //            //qcms.PIID = chMaster.PIID; 
                //            qcms.CompanyID = chMaster.CompanyID;
                //            qcms.ExpireDate = chMaster.ExpireDate;
                //            //qcms.FRID= chMaster.FRID;
                //            qcms.LCorVoucherorLcafDate = chMaster.LCorVoucherorLcafDate;
                //            qcms.LCorVoucherorLcafNo = chMaster.LCorVoucherorLcafNo;
                //            qcms.MoneyTransactionTypeID = chMaster.MoneyTransactionTypeID;
                //            qcms.OrderTypeID = chMaster.OrderTypeID;
                //            qcms.RequisitionID = qcms.RequisitionID;
                //            qcms.ShipmentDate = qcms.ShipmentDate; 
                //            objPurchasePOMaster = qcms;
                //        }
                //        List<PurchasePODetail> lstPurchasePODetail = new List<PurchasePODetail>();
                //        foreach (PurchasePODetail qcdt in chDetails)
                //        {
                //            PurchasePODetail objPurchasePODetail = (from qcdetl in _ctxCmn.PurchasePODetails.Where(m => m.PODetailID == qcdt.PODetailID) select qcdetl).FirstOrDefault();

                //            objPurchasePODetail.Amount = qcdt.Amount;
                //            objPurchasePODetail.FOBValue = qcdt.FOBValue;
                //            objPurchasePODetail.FreightCharge = qcdt.FreightCharge;
                //            objPurchasePODetail.HSCode = qcdt.HSCode;
                //            objPurchasePODetail.ItemID = qcdt.ItemID;
                //            objPurchasePODetail.NetWeight = qcdt.NetWeight;
                //            objPurchasePODetail.IsDeleted = false;
                //            objPurchasePODetail.GrossWeight = qcdt.GrossWeight;
                //            objPurchasePODetail.OriginCountryID = qcdt.OriginCountryID; 
                //            objPurchasePODetail.NetWeight = qcdt.NetWeight;
                //            objPurchasePODetail.PackingQty = qcdt.PackingQty;
                //            objPurchasePODetail.PackingUnitID = qcdt.PackingUnitID;
                //            objPurchasePODetail.Qty = qcdt.Qty; 
                //            objPurchasePODetail.UnitID = qcdt.UnitID;
                //            objPurchasePODetail.UnitPrice = qcdt.UnitPrice;
                //            objPurchasePODetail.WeightUnitID = qcdt.WeightUnitID;
                //            objPurchasePODetail.UpdateBy = chMaster.CreateBy;
                //            objPurchasePODetail.UpdateOn = DateTime.Now;
                //            objPurchasePODetail.UpdatePc =  HostService.GetIP();
                //            lstPurchasePODetail.Add(objPurchasePODetail);

                //        }
                //        _ctxCmn.SaveChanges();

                //        //**********----------------------Start File Upload----------------------**********
                //        GenericFactory_CmnDocument = new CmnDocument_EF();
                //        int DocumentID = Convert.ToInt16(GenericFactory_CmnDocument.getMaxID("CmnDocument"));
                //        List<CmnDocument> lstCmnDocument = new List<CmnDocument>();

                //        for (int i = 1; i <= fileNames.Count; i++)
                //        {
                //            CmnDocument objCmnDocument = new CmnDocument();
                //            objCmnDocument.DocumentID = DocumentID;
                //            objCmnDocument.DocumentPahtID = 2;
                //            //objCmnDocument.DocumentName = fileNames[i].ToString();
                //            string extension = System.IO.Path.GetExtension(fileNames[i - 1].ToString());
                //            objCmnDocument.DocumentName = chMaster.PONo + "_Doc_" + i + extension;
                //            objCmnDocument.TransactionID = chMaster.POID;
                //            objCmnDocument.TransactionTypeID = 22;
                //            objCmnDocument.CompanyID = chMaster.CompanyID;
                //            objCmnDocument.CreateBy = Convert.ToInt16(chMaster.CreateBy);
                //            objCmnDocument.CreateOn = DateTime.Now;
                //            objCmnDocument.CreatePc =  HostService.GetIP();
                //            objCmnDocument.IsDeleted = false;

                //            objCmnDocument.IsDeleted = false;
                //            lstCmnDocument.Add(objCmnDocument);

                //            DocumentID++;
                //        }

                //        GenericFactory_CmnDocument.InsertList(lstCmnDocument);
                //        GenericFactory_CmnDocument.Save();
                //        GenericFactory_CmnDocument.updateMaxID("CmnDocument", Convert.ToInt64(DocumentID - 1));

                //        //**********----------------------File upload completed----------------------**********

                //        transaction.Complete();
                //        result = chMaster.PONo.ToString();
                //    }
                //    catch (Exception e)
                //    {
                //        e.ToString();
                //        result = "";
                //    }
                //}
            }
            else
            {
                using (TransactionScope transaction = new TransactionScope())
                {
                    try
                    {
                        //...........START  new maxId...............//
                        long NextId = Convert.ToInt16(GenericFactory_EF_CmnCombo.getMaxID("PurchaseCSMaster"));
                        long FirstDigit = 0;
                        long OtherDigits = 0;
                        long nextChDetailId = Convert.ToInt16(GenericFactory_EF_CmnCombo.getMaxID("PurchaseCSDetail"));
                        FirstDigit = Convert.ToInt64(nextChDetailId.ToString().Substring(0, 1));
                        OtherDigits = Convert.ToInt64(nextChDetailId.ToString().Substring(1, nextChDetailId.ToString().Length - 1));
                        //..........END new maxId....................//


                        //......... START for custom code........... //

                        string customCode = "";
                        string CustomNo = GenericFactory_EF_CmnCombo.getCustomCode(menuID, Convert.ToDateTime(CSMaster.CSDate), CSMaster.CompanyID ?? 1, 1, 1);

                        if (CustomNo != null)
                        {
                            customCode = CustomNo;
                        }
                        else
                        {
                            customCode = NextId.ToString();
                        }

                        //.........END for custom code............ //

                        string newChNo = customCode;
                        CSMaster.CSID = NextId;
                        CSMaster.CreateOn = DateTime.Now;
                        CSMaster.CreatePc = HostService.GetIP();
                        CSMaster.CSNo = customCode;
                        CSMaster.IsDeleted = false;

                        List<PurchaseCSDetail> lstCSDetail = new List<PurchaseCSDetail>();
                        foreach (PurchaseCSDetail sdtl in CSDetails)
                        {
                            PurchaseCSDetail objchDetail = new PurchaseCSDetail();
                            objchDetail.CSDetailID = Convert.ToInt64(FirstDigit + "" + OtherDigits);//nextQCDetailId;
                            objchDetail.CSID = NextId;
                            objchDetail.FOBValue = sdtl.FOBValue;
                            objchDetail.FreightCharge = sdtl.FreightCharge;
                            objchDetail.PartyID = sdtl.PartyID;
                            objchDetail.CurrencyID = sdtl.CurrencyID;
                            objchDetail.ItemID = sdtl.ItemID;
                            objchDetail.UnitID = sdtl.UnitID;
                            objchDetail.Qty = sdtl.Qty;
                            objchDetail.UnitPrice = sdtl.UnitPrice;
                            objchDetail.Amount = sdtl.Amount;
                            objchDetail.IsDeleted = false;
                            objchDetail.CreateBy = CSMaster.CreateBy;
                            objchDetail.CreateOn = DateTime.Now;
                            objchDetail.CreatePc = HostService.GetIP();
                            lstCSDetail.Add(objchDetail);
                            OtherDigits++;
                        }

                        _ctxCmn.PurchaseCSMasters.Add(CSMaster);

                        //............Update MaxID.................//
                        GenericFactory_EF_CmnCombo.updateMaxID("PurchaseCSMaster", Convert.ToInt64(NextId));
                        //............Update CustomCode.............//
                        GenericFactory_EF_CmnCombo.updateCustomCode(menuID, Convert.ToDateTime(CSMaster.CSDate), CSMaster.CompanyID ?? 1, 1, 1);
                        _ctxCmn.PurchaseCSDetails.AddRange(lstCSDetail);

                        //............Update MaxID.................//
                        GenericFactory_EF_CmnCombo.updateMaxID("PurchaseCSDetail", Convert.ToInt64(FirstDigit + "" + (OtherDigits - 1)));
                        _ctxCmn.SaveChanges();

                        transaction.Complete();
                        result = customCode;
                    }
                    catch (Exception e)
                    {
                        result = "";
                    }
                }

            }
            return result;
        }

        public IEnumerable<vmQuotation> GetQuotationInfoDetail(int QuotationID,int CompanyID)
        {

            GFactory_GF_Quotation = new vmQuotation_GF();
            IEnumerable<vmQuotation> lstQuotation = null;
            string spQuery = string.Empty;
            try
            {
                Hashtable ht = new Hashtable();
                ht.Add("QuotationID", QuotationID);
                ht.Add("CompanyId", CompanyID);
                spQuery = "[dbo].[Get_PurchaseQuotationDetail]";
                lstQuotation = GFactory_GF_Quotation.ExecuteQuery(spQuery, ht);

            }
            catch (Exception e)
            {
                e.ToString();
            }
            return lstQuotation;
        }
        public IEnumerable<vmComparativeStatement> GetQuotationRequisitionID(vmCmnParameters objcmnParam)
        {
            GFactory_GF_Comparative = new vmComparativeStatement_GF();
            IEnumerable<vmComparativeStatement> lstQuotation = null;
            string spQuery = string.Empty;
            try
            {
                Hashtable ht = new Hashtable();                                     
                ht.Add("pageNumber", objcmnParam.pageNumber);
                ht.Add("pageSize", objcmnParam.pageSize);
                ht.Add("IsPaging", objcmnParam.IsPaging);
                ht.Add("RequisitionId", Convert.ToInt16(objcmnParam.id));
                ht.Add("CompanyId", objcmnParam.loggedCompany);
                spQuery = "[dbo].[Get_PurchaseQuotationInfo]";
                lstQuotation = GFactory_GF_Comparative.ExecuteQuery(spQuery, ht);

            }
            catch (Exception e)
            {
                e.ToString();
            }
            return lstQuotation;
        }

        public IEnumerable<InvRequisitionMaster> GetSPR(vmCmnParameters objcmnParam)
        {
            GFactory_GF_Requisition = new InvRequisitionMaster_GF();
            IEnumerable<InvRequisitionMaster> lstSPR = null;
            string spQuery = string.Empty;
            try
            {
                Hashtable ht = new Hashtable();
                ht.Add("pageNumber", objcmnParam.pageNumber);
                ht.Add("pageSize", objcmnParam.pageSize);
                ht.Add("IsPaging", objcmnParam.IsPaging);
                ht.Add("CompanyID", objcmnParam.loggedCompany);
                spQuery = "[dbo].[Get_InvSPRNo]";
                lstSPR = GFactory_GF_Requisition.ExecuteQuery(spQuery, ht);

            }
            catch (Exception e)
            {
                e.ToString();
            }
            return lstSPR;
        }
        public IEnumerable<CmnAddressCountry> GetLocation(vmCmnParameters objcmnParam, out int recordsTotal)
        {
            IEnumerable<CmnAddressCountry> objCountry = null;
            IEnumerable<CmnAddressCountry> objCountryWithoutPaging = null;

            recordsTotal = 0;
            using (_ctxCmn = new ERP_Entities())
            {
                try
                {
                    objCountryWithoutPaging = (from spr in _ctxCmn.CmnAddressCountries.Where(m => m.IsDeleted == false) select spr).ToList().Select(m => new CmnAddressCountry { CountryID = m.CountryID, CountryName = m.CountryName }).ToList();
                    objCountry = objCountryWithoutPaging.OrderBy(x => x.CountryID).Skip(objcmnParam.pageNumber).Take(objcmnParam.pageSize).ToList();
                    recordsTotal = objCountryWithoutPaging.Count();
                }
                catch (Exception e)
                {
                    e.ToString();
                }
            }
            return objCountry;
        }

        public IEnumerable<CmnUOM> GetPackingUnit(vmCmnParameters objcmnParam, out int recordsTotal)
        {
            IEnumerable<CmnUOM> lstPackingUnit = null;
            IEnumerable<CmnUOM> lstPackingUnitWithoutPaging = null;

            recordsTotal = 0;
            using (_ctxCmn = new ERP_Entities())
            {
                try
                {
                    lstPackingUnitWithoutPaging = (from pu in _ctxCmn.CmnUOMs.Where(m => m.IsDeleted == false && m.UOMGroupID == 5) select pu).ToList().Select(m => new CmnUOM { UOMID = m.UOMID, UOMName = m.UOMName }).ToList();
                    lstPackingUnit = lstPackingUnitWithoutPaging.OrderBy(x => x.UOMID).Skip(objcmnParam.pageNumber).Take(objcmnParam.pageSize).ToList();
                    recordsTotal = lstPackingUnitWithoutPaging.Count();
                }
                catch (Exception e)
                {
                    e.ToString();
                }
            }
            return lstPackingUnit;
        }

        public IEnumerable<CmnUOM> GetWeightUnit(vmCmnParameters objcmnParam, out int recordsTotal)
        {
            IEnumerable<CmnUOM> lstWeightUnit = null;
            IEnumerable<CmnUOM> lstWeightUnitWithoutPaging = null;

            recordsTotal = 0;
            using (_ctxCmn = new ERP_Entities())
            {
                try
                {
                    lstWeightUnitWithoutPaging = (from wu in _ctxCmn.CmnUOMs.Where(m => m.IsDeleted == false && m.UOMGroupID == 4) select wu).ToList().Select(m => new CmnUOM { UOMID = m.UOMID, UOMName = m.UOMName }).ToList();
                    lstWeightUnit = lstWeightUnitWithoutPaging.OrderBy(x => x.UOMID).Skip(objcmnParam.pageNumber).Take(objcmnParam.pageSize).ToList();
                    recordsTotal = lstWeightUnitWithoutPaging.Count();
                }
                catch (Exception e)
                {
                    e.ToString();
                }
            }
            return lstWeightUnit;
        }


        public IEnumerable<InvRequisitionMaster> GetSPRNo(vmCmnParameters objcmnParam, out int recordsTotal)
        {
            IEnumerable<InvRequisitionMaster> objSPRNo = null;
            IEnumerable<InvRequisitionMaster> objSPRNoWithoutPaging = null;

            recordsTotal = 0;
            using (_ctxCmn = new ERP_Entities())
            {
                try
                {

                    objSPRNoWithoutPaging = (from spr in _ctxCmn.InvRequisitionMasters.Where(m => m.IsDeleted == false) select spr).ToList().Select(m => new InvRequisitionMaster { RequisitionID = m.RequisitionID, RequisitionNo = m.RequisitionNo }).ToList();
                    objSPRNo = objSPRNoWithoutPaging.OrderBy(x => x.RequisitionID).Skip(objcmnParam.pageNumber).Take(objcmnParam.pageSize).ToList();
                    recordsTotal = objSPRNoWithoutPaging.Count();

                }
                catch (Exception e)
                {
                    e.ToString();
                }
            }
            return objSPRNo;
        }

        public IEnumerable<PurchaseQuotationMaster> GetStatementNo(vmCmnParameters objcmnParam, out int recordsTotal)
        {
            IEnumerable<PurchaseQuotationMaster> objPurchaseCSMaster = null;
            IEnumerable<PurchaseQuotationMaster> objPurchaseCSMasterWithoutPaging = null; 

            recordsTotal = 0;
            using (_ctxCmn = new ERP_Entities())
            {
                try
                {

                    objPurchaseCSMasterWithoutPaging = (from stmnt in _ctxCmn.PurchaseQuotationMasters.Where(m => m.IsDeleted == false && m.CompanyID == objcmnParam.loggedCompany && m.IsConfirm==true) select stmnt).ToList().Select(m => new PurchaseQuotationMaster { QuotationID = m.QuotationID, QuotationNo = m.QuotationNo }).ToList();
                    objPurchaseCSMaster = objPurchaseCSMasterWithoutPaging.OrderBy(x => x.QuotationID).Skip(objcmnParam.pageNumber).Take(objcmnParam.pageSize).ToList();
                    recordsTotal = objPurchaseCSMasterWithoutPaging.Count();

                }
                catch (Exception e)
                {
                    e.ToString();
                }
            }
            return objPurchaseCSMaster;
        }


        public IEnumerable<vmChallan> GetItemDetailByStatementNo(vmCmnParameters objcmnParam, Int64 StatementID)
        {
            GenericFactory_GF_vmChallan = new vmChallan_GF();
            string spQuery = "";
            IEnumerable<vmChallan> lstItemDetailByStatementID = null;
            // recordsTotal = 0; 
            try
            {
                Hashtable ht = new Hashtable();
                ht.Add("CompanyID", objcmnParam.loggedCompany);
                ht.Add("LoggedUser", objcmnParam.loggeduser);

                ht.Add("PageNo", objcmnParam.pageNumber);
                ht.Add("RowCountPerPage", objcmnParam.pageSize);
                ht.Add("IsPaging", objcmnParam.IsPaging);
                ht.Add("QuotationID", StatementID);

                spQuery = "[Get_PurPOItemByQuotationID]";

                lstItemDetailByStatementID = GenericFactory_GF_vmChallan.ExecuteQuery(spQuery, ht);

                // recordsTotal = lstMasterInfoByGrrNo.Count();
            }
            catch (Exception e)
            {
                e.ToString();
            }
            return lstItemDetailByStatementID;
        }


        public IEnumerable<vmChallan> GetItmDetailByItmCode(vmCmnParameters objcmnParam, string ItemCode)
        {
            GenericFactory_GF_vmChallan = new vmChallan_GF();
            string spQuery = "";
            IEnumerable<vmChallan> lstItemDetailByItmCode = null;
            // recordsTotal = 0;
            try
            {
                Hashtable ht = new Hashtable();
                ht.Add("CompanyID", objcmnParam.loggedCompany);
                ht.Add("LoggedUser", objcmnParam.loggeduser);

                ht.Add("PageNo", objcmnParam.pageNumber);
                ht.Add("RowCountPerPage", objcmnParam.pageSize);
                ht.Add("IsPaging", objcmnParam.IsPaging);
                ht.Add("ArticleNo", ItemCode);

                spQuery = "[Get_InvChallanItemByItemCode]";

                lstItemDetailByItmCode = GenericFactory_GF_vmChallan.ExecuteQuery(spQuery, ht);

                // recordsTotal = lstMasterInfoByGrrNo.Count();
            }
            catch (Exception e)
            {
                e.ToString();
            }
            return lstItemDetailByItmCode;
        }


        public IEnumerable<vmChallan> GetPODetailByPOID(vmCmnParameters objcmnParam, Int64 poID, out int recordsTotal)  
        {
            GenericFactory_GF_vmChallan = new vmChallan_GF();
            string spQuery = "";
            IEnumerable<vmChallan> lstItemDetailByPOID = null; 
            recordsTotal = 0;
            try
            {
                Hashtable ht = new Hashtable();
                ht.Add("CompanyID", objcmnParam.loggedCompany);
                ht.Add("LoggedUser", objcmnParam.loggeduser);

                ht.Add("PageNo", objcmnParam.pageNumber);
                ht.Add("RowCountPerPage", objcmnParam.pageSize);
                ht.Add("IsPaging", objcmnParam.IsPaging);
                ht.Add("POID", poID);

                spQuery = "[Get_PurPOListByPOID]";

                lstItemDetailByPOID = GenericFactory_GF_vmChallan.ExecuteQuery(spQuery, ht);

                recordsTotal = lstItemDetailByPOID.Count();
            }
            catch (Exception e)
            {
                e.ToString();
            }
            return lstItemDetailByPOID; 
        }


        public IEnumerable<vmChallan> GetPOMasterList(vmCmnParameters objcmnParam, out int recordsTotal)
        {
            GenericFactory_GF_vmChallan = new vmChallan_GF();
            string spQuery = "";
            IEnumerable<vmChallan> lstPOMaster = null;
            recordsTotal = 0;
            try
            {
                Hashtable ht = new Hashtable();
                ht.Add("CompanyID", objcmnParam.loggedCompany);
                ht.Add("LoggedUser", objcmnParam.loggeduser);
                ht.Add("PageNo", objcmnParam.pageNumber);
                ht.Add("RowCountPerPage", objcmnParam.pageSize);
                ht.Add("IsPaging", objcmnParam.IsPaging);

                spQuery = "[Get_PurPOList]";

                lstPOMaster = GenericFactory_GF_vmChallan.ExecuteQuery(spQuery, ht);

                recordsTotal = lstPOMaster.Count();
            }
            catch (Exception e)
            {
                e.ToString();
            }
            return lstPOMaster;
        }

        public IEnumerable<vmChallan> GetGrrList()
        { 
            IEnumerable<vmChallan> lstGrrMaster = null; 
            try
            {
                using (_ctxCmn = new ERP_Entities())
                {
                    lstGrrMaster = _ctxCmn.InvGrrMasters.Where(m => m.IsDeleted == false).Select(m=> new vmChallan {GrrID=m.GrrID, GrrNo=m.GrrNo, ManualGRRNoRpt = m.ManualGrrNo+"||"+m.GrrNo,  CompanyID=m.CompanyID, CreateBy=m.CreateBy }).ToList();
                }
              
            }
            catch (Exception e)
            {
                e.ToString();
            }
            return lstGrrMaster;
        }
        public IEnumerable<CmnCombo> GetOrderType(vmCmnParameters objcmnParam, string ComboType) 
        {
            IEnumerable<CmnCombo> lstOrderType = null;
            try
            {
                using (_ctxCmn = new ERP_Entities())
                {
                    lstOrderType = _ctxCmn.CmnComboes.Where(m => m.IsDeleted == false && m.ComboType == ComboType).ToList().Select(m => new CmnCombo { ComboID = m.ComboID, ComboName = m.ComboName }).ToList();
                }

            }
            catch (Exception e)
            {
                e.ToString();
            }
            return lstOrderType;
        }

        public IEnumerable<CmnCombo> GetMoneyTrnsType(vmCmnParameters objcmnParam, string ComboType)
        {
            IEnumerable<CmnCombo> lstMoneyTrnsType = null;
            try
            {
                using (_ctxCmn = new ERP_Entities())
                {
                    lstMoneyTrnsType = _ctxCmn.CmnComboes.Where(m => m.IsDeleted == false && m.ComboType == ComboType).ToList().Select(m => new CmnCombo { ComboID = m.ComboID, ComboName = m.ComboName }).ToList();
                }

            }
            catch (Exception e)
            {
                e.ToString();
            }
            return lstMoneyTrnsType;
        }


        public IEnumerable<vmItemGroup> GetItemSampleNo(int? pageNumber, int? pageSize, int? IsPaging)
        {
            IEnumerable<vmItemGroup> objSampleNo = null;
            IEnumerable<CmnItemMaster> cmnItemGroupID = null;
            using (_ctxCmn = new ERP_Entities())
            {
                try
                {
                    cmnItemGroupID = (from grp in _ctxCmn.CmnItemMasters.Where(x => x.ItemTypeID == 1 && x.IsDeleted == false) select grp).ToList().GroupBy(x => x.ItemGroupID).Select(o => new CmnItemMaster { ItemGroupID = o.Key }).ToList();

                    objSampleNo = (from groupItm in _ctxCmn.CmnItemGroups.ToList()
                                   join groupId in cmnItemGroupID on groupItm.ItemGroupID equals groupId.ItemGroupID
                                   select new
                                   {
                                       ItemGroupID = groupId.ItemGroupID,
                                       ItemGroupName = groupItm.ItemGroupName
                                   }).Select(m => new vmItemGroup { ItemGroupID = m.ItemGroupID ?? 0, ItemGroupName = m.ItemGroupName }).ToList();

                }
                catch (Exception e)
                {
                    e.ToString();
                }
            }
            return objSampleNo;
        }


        public IEnumerable<CmnCombo> GetChallanTrnsTypes(int? pageNumber, int? pageSize, int? IsPaging)
        {
            IEnumerable<CmnCombo> lstChallanTrnsTypes = null;
            using (_ctxCmn = new ERP_Entities())
            {
                try
                {
                    lstChallanTrnsTypes = (from grp in _ctxCmn.CmnComboes.Where(x => x.ComboType == "ChallanTransType" && x.IsDeleted == false) select grp).ToList();

                }
                catch (Exception e)
                {
                    e.ToString();
                }
            }
            return lstChallanTrnsTypes;

        }


        public IEnumerable<AccCurrencyInfo> GetCurrency(int? pageNumber, int? pageSize, int? IsPaging)
        {
            IEnumerable<AccCurrencyInfo> lstCurrency = null;
            using (_ctxCmn = new ERP_Entities())
            {
                try
                {
                    lstCurrency = (from grp in _ctxCmn.AccCurrencyInfoes select grp).ToList().Select(m => new AccCurrencyInfo { Id = m.Id, CurrencyName = m.CurrencyName, ConversionRate = m.ConversionRate }).ToList();
                }
                catch (Exception e)
                {
                    e.ToString();
                }
            }
            return lstCurrency;
        }

        public IEnumerable<vmCmnUser> GetParty(int pageNumber, int pageSize, int IsPaging)
        {
            List<vmCmnUser> lstParty = null;
            try
            {
                //**************************Paging Implemented******************************
                using (_ctxCmn = new ERP_Entities())
                {
                    lstParty = (from x in _ctxCmn.CmnUsers
                                select new
                                {
                                    UserID = x.UserID,
                                    UserFullName = x.UserFullName,
                                    UserTypeID = x.UserTypeID,
                                    IsDeleted = x.IsDeleted

                                }).ToList().Select(m => new vmCmnUser
                                {
                                    UserID = m.UserID,
                                    UserFullName = m.UserFullName,
                                    UserTypeID = m.UserTypeID,
                                    IsDeleted = m.IsDeleted
                                })
                               .Where(m => m.UserTypeID == 3 && m.IsDeleted == false && m.UserFullName != null)

                               .OrderBy(p => p.UserID)
                               .Skip(pageNumber)
                               .Take(pageSize).ToList();
                }
            }
            catch (Exception e)
            {
                e.ToString();
            }

            return lstParty;
        }


        public IEnumerable<vmChallan> GetItemMasterById(vmCmnParameters objcmnParam, out int recordsTotal)
        {
            GenericFactory_GF_vmChallan = new vmChallan_GF();
            //  int itemGroupId = Convert.ToInt32(groupId);

            string spQuery = "";
            IEnumerable<vmChallan> objItemMaster = null;
            recordsTotal = 0;
            try
            {
                Hashtable ht = new Hashtable();
                ht.Add("CompanyID", objcmnParam.loggedCompany);
                ht.Add("LoggedUser", objcmnParam.loggeduser);
                ht.Add("PageNo", objcmnParam.pageNumber);
                ht.Add("RowCountPerPage", objcmnParam.pageSize);
                ht.Add("IsPaging", objcmnParam.IsPaging);
                // ht.Add("ItemGroupID", itemGroupId);

                spQuery = "[Get_Item]";

                objItemMaster = GenericFactory_GF_vmChallan.ExecuteQuery(spQuery, ht);

                recordsTotal = objItemMaster.Count();
            }
            catch (Exception e)
            {
                e.ToString();
            }
            return objItemMaster;

        }



        public CmnDocumentPath GetUploadPath()
        {
            GenericFactory_CmnDocumentPath = new CmnDocumentPath_EF();
            CmnDocumentPath objUploadPath = null;
            try
            {
                objUploadPath = GenericFactory_CmnDocumentPath.GetAll().Select(m => new
                CmnDocumentPath
                {
                    TransactionTypeID = m.TransactionTypeID,
                    PhysicalPath = m.PhysicalPath
                })
                    .Where(m => m.TransactionTypeID == 22).FirstOrDefault();
            }
            catch (Exception e)
            {
                e.ToString();
            }
            return objUploadPath;
        }
        public IEnumerable<vmCmnDocument> GetFileDetailsById(int poID) 
        {
            GenericFactory_CmnDocument = new CmnDocument_EF();
            IEnumerable<vmCmnDocument> objFileInfo = null;
            string fullFilePath = string.Empty;
            try
            {
                using (_ctxCmn = new ERP_Entities())
                {
                    //  var transactionName;
                    var virtualPath = _ctxCmn.CmnDocumentPaths.Where(m => m.TransactionTypeID == 22 && m.IsDeleted == false).ToList().
                                     Select(m => new CmnDocumentPath
                                     {
                                         VirtualPath = m.VirtualPath
                                     }).FirstOrDefault();

                    var transactionName = _ctxCmn.CmnTransactionTypes.Where(m => m.TransactionTypeID == 22 && m.IsDeleted == false).ToList().
                                     Select(m => new CmnTransactionType
                                     {
                                         TransactionTypeName = m.TransactionTypeName
                                     }).FirstOrDefault();


                    objFileInfo = _ctxCmn.CmnDocuments.Where(m => m.TransactionID == poID).ToList().
                                Select(m => new vmCmnDocument
                                {
                                    DocumentID = m.DocumentID,
                                    DocumentName = m.DocumentName,
                                    TransactionID = m.TransactionID,
                                    FullDocumentPath = virtualPath.VirtualPath + transactionName.TransactionTypeName + "/" + m.DocumentName
                                }).ToList();


                    //objFileInfo = GenericFactory_CmnDocument.GetAll().Select(m => new CmnDocument
                    //{
                    //    DocumentID = m.DocumentID,
                    //    DocumentName = m.DocumentName,
                    //    TransactionID = m.TransactionID
                    //}).
                    //    Where(m => m.TransactionID == lcID).ToList();
                }
            }
            catch (Exception e)
            {
                e.ToString();
            }


            return objFileInfo;
        }
    }
}










