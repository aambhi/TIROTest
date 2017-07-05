using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TIROERP.Core.Model;
using TIROERP.Core.RepositoryInterface;
namespace TIROERP.Infrastructure.Repository
{
    public class AdvertisementRepository : IAdvertisement
    {
        ArbabTravelsERPEntities _entities;

        public void Create(Advertisement advertisement)
        {
            _entities = new ArbabTravelsERPEntities();
            TBL_ADVERTISEMENT_MASTER tbl_advert_master = new TBL_ADVERTISEMENT_MASTER();
            try
            {
                tbl_advert_master.AD_AGENCY_NAME = advertisement.AD_AGENCY_NAME;
                tbl_advert_master.ADV_DATE = Convert.ToDateTime(advertisement.ADV_DATE);
                tbl_advert_master.CREATED_BY = Convert.ToString(((UserLoginResult)HttpContext.Current.Session["UserDetails"]).REGISTRATION_NO);
                tbl_advert_master.CREATED_DATE = DateTime.Now;
                tbl_advert_master.IS_ACTIVE = true;
                tbl_advert_master.EXPENSES = advertisement.EXPENSES;
                tbl_advert_master.FILE_PATH = advertisement.FILE_PATH;
                tbl_advert_master.PAPER_NAME = advertisement.PAPER_NAME;
                tbl_advert_master.REQUIREMENT_ID = Convert.ToInt32(advertisement.REQUIREMENT_ID);
                _entities.TBL_ADVERTISEMENT_MASTER.Add(tbl_advert_master);
                _entities.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Advertisement> GetAllAdvertisements(int adv_Id)
        {
            _entities = new ArbabTravelsERPEntities();

            var advert_list = _entities.PROC_GET_ADVERTISEMENT_DATA(adv_Id).Select(x => new Advertisement
            {
                PAPER_NAME = x.PAPER_NAME,
                AD_AGENCY_NAME = x.AD_AGENCY_NAME,
                EXPENSES = Convert.ToDecimal(x.EXPENSES),
                REQUIREMENT_ID = x.REQUIREMENT_ID,
                ADV_DATE = x.ADV_DATE,
                FILE_PATH = x.FILE_PATH,
                ADV_ID = x.ADV_ID,
                REQUIREMENT_NAME = x.REQUIREMENT,
                CREATED_BY = x.CREATED_BY,
                CREATED_DATE = x.CREATED_DATE
            }).OrderByDescending(x => x.CREATED_DATE).ToList();

            return advert_list;
        }



        public void Edit(Advertisement advertisement)
        {
            _entities = new ArbabTravelsERPEntities();
            TBL_ADVERTISEMENT_MASTER advert_detail = new TBL_ADVERTISEMENT_MASTER();
            try
            {
                advert_detail.ADV_ID = advertisement.ADV_ID;
                advert_detail.PAPER_NAME = advertisement.PAPER_NAME;
                advert_detail.AD_AGENCY_NAME = advertisement.AD_AGENCY_NAME;
                advert_detail.EXPENSES = advertisement.EXPENSES;
                advert_detail.REQUIREMENT_ID = Convert.ToInt32(advertisement.REQUIREMENT_ID);
                advert_detail.ADV_DATE = Convert.ToDateTime(advertisement.ADV_DATE);
                advert_detail.FILE_PATH = advertisement.FILE_PATH;
                advert_detail.CREATED_BY = advertisement.CREATED_BY;
                advert_detail.CREATED_DATE = Convert.ToDateTime(advertisement.CREATED_DATE);
                advert_detail.MODIFIED_BY = Convert.ToString(((UserLoginResult)HttpContext.Current.Session["UserDetails"]).REGISTRATION_NO);
                advert_detail.MODIFIED_DATE = DateTime.Now;
                advert_detail.IS_ACTIVE = true;
                _entities.Entry(advert_detail).State = System.Data.Entity.EntityState.Modified;
                _entities.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Delete(Advertisement advertisementDetail)
        {
            _entities = new ArbabTravelsERPEntities();
            try
            {
                var advertisement = _entities.TBL_ADVERTISEMENT_MASTER.Where(x => x.ADV_ID == advertisementDetail.ADV_ID).SingleOrDefault();
                advertisement.IS_ACTIVE = false;
                advertisement.MODIFIED_BY = Convert.ToString(((UserLoginResult)HttpContext.Current.Session["UserDetails"]).REGISTRATION_NO);
                advertisement.MODIFIED_DATE = DateTime.Now;
                _entities.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Advertisement_Requirements> GetAllRequirements()
        {
            List<Advertisement_Requirements> advert_requirement = new List<Advertisement_Requirements>();

            _entities = new ArbabTravelsERPEntities();

            advert_requirement = _entities.PROC_GET_REQUIREMENT(null).Select(x => new Advertisement_Requirements
            {
                RequirementName = x.REQUIREMENT,
                REQUIREMENT_ID = x.REQUIREMENT_ID
            }).ToList();

            return advert_requirement;

        }

    }
}