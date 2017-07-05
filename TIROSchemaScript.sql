USE [master]
GO
/****** Object:  Database [ArbabTravelsERP]    Script Date: 27-Jan-17 1:15:32 AM ******/
CREATE DATABASE [ArbabTravelsERP] ON  PRIMARY 
( NAME = N'ArbabTravelsERP', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\ArbabTravelsERP.mdf' , SIZE = 6144KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'ArbabTravelsERP_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\ArbabTravelsERP_log.ldf' , SIZE = 1280KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [ArbabTravelsERP] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ArbabTravelsERP].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ArbabTravelsERP] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ArbabTravelsERP] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ArbabTravelsERP] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ArbabTravelsERP] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ArbabTravelsERP] SET ARITHABORT OFF 
GO
ALTER DATABASE [ArbabTravelsERP] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ArbabTravelsERP] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [ArbabTravelsERP] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ArbabTravelsERP] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ArbabTravelsERP] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ArbabTravelsERP] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ArbabTravelsERP] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ArbabTravelsERP] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ArbabTravelsERP] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ArbabTravelsERP] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ArbabTravelsERP] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ArbabTravelsERP] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ArbabTravelsERP] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ArbabTravelsERP] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ArbabTravelsERP] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ArbabTravelsERP] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ArbabTravelsERP] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ArbabTravelsERP] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ArbabTravelsERP] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [ArbabTravelsERP] SET  MULTI_USER 
GO
ALTER DATABASE [ArbabTravelsERP] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ArbabTravelsERP] SET DB_CHAINING OFF 
GO
USE [ArbabTravelsERP]
GO
/****** Object:  UserDefinedTableType [dbo].[UDT_TICKET_DETAILS]    Script Date: 27-Jan-17 1:15:32 AM ******/
CREATE TYPE [dbo].[UDT_TICKET_DETAILS] AS TABLE(
	[PassportId] [int] NOT NULL,
	[AirlinesID] [int] NOT NULL,
	[OtherAirlines] [varchar](100) NULL,
	[IsDirect] [bit] NULL,
	[PnrNumber] [varchar](20) NULL,
	[TicketNumber] [varchar](20) NULL,
	[FlightNumber] [varchar](20) NULL,
	[IsBooked] [bit] NULL,
	[IsCancelled] [bit] NULL,
	[DepartureCityCode] [varchar](20) NULL,
	[DepartureDate] [date] NULL,
	[DepartureTime] [varchar](20) NULL,
	[DestinationCityCode] [varchar](20) NULL,
	[ArivalDate] [date] NULL,
	[ArrivalTime] [varchar](20) NULL,
	[ReportPath] [varchar](100) NULL,
	[Remark] [varchar](250) NULL,
	[createdBy] [varchar](20) NULL,
	[CreatedDate] [datetime] NULL,
	[Conn_PnrNumber] [varchar](20) NULL,
	[Conn_TicketNumber] [varchar](20) NULL,
	[Conn_FlightNumber] [varchar](20) NULL,
	[Conn_IsBooked] [bit] NULL,
	[Conn_IsCancelled] [bit] NULL,
	[Conn_DepartureCityCode] [varchar](20) NULL,
	[Conn_DepartureDate] [date] NULL,
	[Conn_DepartureTime] [varchar](20) NULL,
	[Conn_DestinationCityCode] [varchar](20) NULL,
	[Conn_ArivalDate] [date] NULL,
	[Conn_ArrivalTime] [varchar](20) NULL,
	[Conn_createdBy] [varchar](20) NULL,
	[Conn_CreatedDate] [datetime] NULL
)
GO
/****** Object:  UserDefinedTableType [dbo].[UDT_USER_ADDRESS]    Script Date: 27-Jan-17 1:15:33 AM ******/
CREATE TYPE [dbo].[UDT_USER_ADDRESS] AS TABLE(
	[ADDRESS_TYPE_ID] [int] NULL,
	[ADDRESS] [varchar](80) NULL,
	[CITY_CODE] [varchar](10) NULL,
	[USER_VILLAGE] [varchar](50) NULL,
	[USER_PINCODE] [varchar](20) NULL,
	[CREATED_BY] [varchar](20) NULL
)
GO
/****** Object:  UserDefinedTableType [dbo].[UDT_USER_CERTIFICATION]    Script Date: 27-Jan-17 1:15:33 AM ******/
CREATE TYPE [dbo].[UDT_USER_CERTIFICATION] AS TABLE(
	[CERTIFICATION] [varchar](70) NULL,
	[CERTIFICATION_LEVEL] [int] NULL,
	[INSTITUTE] [varchar](80) NULL,
	[YEAR_OF_PASSING] [int] NULL
)
GO
/****** Object:  UserDefinedTableType [dbo].[UDT_USER_CONTACT]    Script Date: 27-Jan-17 1:15:33 AM ******/
CREATE TYPE [dbo].[UDT_USER_CONTACT] AS TABLE(
	[CONTACT_TYPE_ID] [int] NULL,
	[CONTACT_NO] [varchar](50) NULL,
	[CREATED_BY] [varchar](20) NULL
)
GO
/****** Object:  UserDefinedTableType [dbo].[UDT_USER_DETAILS]    Script Date: 27-Jan-17 1:15:33 AM ******/
CREATE TYPE [dbo].[UDT_USER_DETAILS] AS TABLE(
	[REGISTRATION_NO] [varchar](20) NULL,
	[FIRST_NAME] [varchar](50) NULL,
	[MIDDLE_NAME] [varchar](50) NULL,
	[LAST_NAME] [varchar](50) NULL,
	[GAMCA_NO] [varchar](20) NULL,
	[FILE_NAME] [varchar](50) NULL,
	[FILE_PATH] [varchar](50) NULL,
	[WEBSITE] [varchar](50) NULL,
	[SKYPE] [varchar](50) NULL,
	[REMARK] [varchar](1000) NULL,
	[CONTACT_REMARK] [varchar](1000) NULL,
	[CREATED_BY] [varchar](50) NULL,
	[AVAILING_TYPE_ID] [int] NULL,
	[SOURCE_ID] [int] NULL,
	[OTHER_SOURCE] [varchar](20) NULL,
	[REFERRER_NAME] [varchar](50) NULL,
	[STATUS_ID] [int] NULL,
	[REQUIREMENT_ID] [int] NULL,
	[LOGIN_ACCESS] [bit] NULL,
	[LOGIN_PASSWORD] [varchar](50) NULL,
	[MODIFIED_BY] [varchar](20) NULL,
	[IS_EXPERIENCED] [bit] NULL,
	[EDUCATION_REMARK] [varchar](1000) NULL,
	[WORK_REMARK] [varchar](1000) NULL,
	[BRANCH_CODE] [varchar](20) NULL,
	[LOCATION_CODE] [varchar](20) NULL,
	[COMPANY_NAME] [varchar](70) NULL,
	[TOTAL_WORK_EXPERIENCE] [varchar](50) NULL,
	[TOTAL_GULF_EXPERIENCE] [varchar](50) NULL,
	[SKILLS] [varchar](100) NULL,
	[FATHER_NAME] [varchar](80) NULL,
	[MOTHER_NAME] [varchar](80) NULL,
	[GENDER_CODE] [char](1) NULL,
	[DATE_OF_BIRTH] [datetime] NULL,
	[PLACE_OF_BIRTH] [varchar](50) NULL,
	[MARITAL_STATUS_ID] [int] NULL,
	[NATIONALITY_ID] [int] NULL,
	[CURRENT_LOCATION] [varchar](50) NULL,
	[RELIGION_ID] [int] NULL,
	[DESIGNATION] [varchar](100) NULL,
	[INDUSTRY] [varchar](100) NULL,
	[REFERENCE] [varchar](20) NULL,
	[POST_APPLIED_FOR] [varchar](50) NULL,
	[CIVILIAN_NO] [varchar](20) NULL,
	[CLINIC_NAME] [varchar](100) NULL
)
GO
/****** Object:  UserDefinedTableType [dbo].[UDT_USER_DOCUMENT]    Script Date: 27-Jan-17 1:15:33 AM ******/
CREATE TYPE [dbo].[UDT_USER_DOCUMENT] AS TABLE(
	[DOCUMENT_TYPE_ID] [varchar](50) NULL,
	[DOCUMENT_PATH] [varchar](200) NULL,
	[CREATED_BY] [varchar](20) NULL,
	[MODIFIED_BY] [varchar](20) NULL
)
GO
/****** Object:  UserDefinedTableType [dbo].[UDT_USER_DRIVING]    Script Date: 27-Jan-17 1:15:33 AM ******/
CREATE TYPE [dbo].[UDT_USER_DRIVING] AS TABLE(
	[DRIVING_LICENCE_NUMBER] [varchar](20) NULL,
	[DATE_OF_ISSUE] [datetime] NULL,
	[PLACE_OF_ISSUE] [varchar](20) NULL,
	[EXPIRY_DATE] [datetime] NULL,
	[VEHICLE_TYPE_ID] [int] NULL,
	[CREATED_BY] [varchar](20) NULL,
	[MODIFIED_BY] [varchar](20) NULL,
	[REMARK] [varchar](100) NULL,
	[REGISTRATION_NO] [varchar](20) NULL
)
GO
/****** Object:  UserDefinedTableType [dbo].[UDT_USER_EDUCATION]    Script Date: 27-Jan-17 1:15:33 AM ******/
CREATE TYPE [dbo].[UDT_USER_EDUCATION] AS TABLE(
	[USER_EDUCATION_ID] [int] NULL,
	[REGISTRATION_NO] [varchar](12) NOT NULL,
	[EDUCATION_TYPE_ID] [int] NULL,
	[SPECIALIZATION_TYPE_ID] [int] NULL,
	[UNIVERSITY_ID] [varchar](70) NULL,
	[UNIVERSITY_YEAR_OF_PASSING] [varchar](8) NULL,
	[IS_HIGHEST_QUALIFICATION] [bit] NULL,
	[CREATED_BY] [varchar](20) NULL,
	[MODIFIED_BY] [varchar](20) NULL,
	[IsNEW] [bit] NULL
)
GO
/****** Object:  UserDefinedTableType [dbo].[UDT_USER_EMAIL]    Script Date: 27-Jan-17 1:15:33 AM ******/
CREATE TYPE [dbo].[UDT_USER_EMAIL] AS TABLE(
	[USER_EMAIL] [varchar](70) NULL
)
GO
/****** Object:  UserDefinedTableType [dbo].[UDT_USER_EXPERIENCE]    Script Date: 27-Jan-17 1:15:33 AM ******/
CREATE TYPE [dbo].[UDT_USER_EXPERIENCE] AS TABLE(
	[USER_COMPANY_NAME] [varchar](80) NULL,
	[IS_CURRENT_COMPANY] [bit] NULL,
	[DESIGNATION_ID] [int] NULL,
	[INDUSTRY_ID] [int] NULL,
	[CITY_CODE] [varchar](20) NULL,
	[WORK_PERIOD_FROM] [datetime] NULL,
	[WORK_PERIOD_TO] [datetime] NULL,
	[TOTAL_WORK_EXPERIENCE] [decimal](18, 0) NULL,
	[REMARK] [varchar](100) NULL,
	[CREATED_BY] [varchar](20) NULL,
	[MODIFIED_BY] [varchar](20) NULL
)
GO
/****** Object:  UserDefinedTableType [dbo].[UDT_USER_LANGUAGE]    Script Date: 27-Jan-17 1:15:33 AM ******/
CREATE TYPE [dbo].[UDT_USER_LANGUAGE] AS TABLE(
	[LANGUAGE_ID] [int] NULL,
	[IS_READ] [bit] NULL,
	[IS_WRITE] [bit] NULL,
	[IS_SPEAK] [bit] NULL
)
GO
/****** Object:  UserDefinedTableType [dbo].[UDT_USER_PASSPORT]    Script Date: 27-Jan-17 1:15:33 AM ******/
CREATE TYPE [dbo].[UDT_USER_PASSPORT] AS TABLE(
	[PASSPORT_NUMBER] [varchar](20) NULL,
	[DATE_OF_ISSUE] [datetime] NULL,
	[PLACE_OF_ISSUE] [varchar](50) NULL,
	[DATE_OF_EXPIRY] [datetime] NULL,
	[EMIGRATION_CLEARANCE_REQUIRED] [bit] NULL,
	[CREATED_BY] [varchar](20) NULL,
	[MODIFIED_BY] [varchar](20) NULL,
	[REGISTRATION_NO] [varchar](20) NULL
)
GO
/****** Object:  StoredProcedure [dbo].[GET_COUNTRY_STATE_CITY]    Script Date: 27-Jan-17 1:15:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROC [dbo].[GET_COUNTRY_STATE_CITY]  
   
AS     
BEGIN    
	SELECT TCM.CITY_CODE,TCM.CITY_NAME,TSM.STATE_CODE,TSM.STATE_NAME,TCUM.COUNTRY_CODE,TCUM.COUNTRY_NAME,tcm.IS_ACTIVE                                         
	FROM TBL_CITY_MASTER TCM WITH (NOLOCK)                                        
	LEFT JOIN TBL_STATE_MASTER TSM WITH (NOLOCK) ON TCM.STATE_CODE = TSM.STATE_CODE                                        
	LEFT JOIN TBL_COUNTRY_MASTER TCUM WITH (NOLOCK) ON TSM.COUNTRY_CODE = TCUM.COUNTRY_CODE        
	ORDER BY TCUM.COUNTRY_NAME,TSM.STATE_NAME,TCM.CITY_NAME 
END
GO
/****** Object:  StoredProcedure [dbo].[GET_DESIGNATION_BYINDUSTRY]    Script Date: 27-Jan-17 1:15:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[GET_DESIGNATION_BYINDUSTRY]  
(  
@INDUSTRY_ID VARCHAR(100) = NULL  
)  
AS   
BEGIN  
  
SELECT DESIGNATION_ID,DESIGNATION_NAME, TRT.INDUSTRY_ID,TRT.INDUSTRY_TYPE      
FROM TBL_DESIGNATION_MASTER TDM WITH (NOLOCK)               
JOIN TBL_INDUSTRY_MASTER TRT WITH (NOLOCK) ON TDM.INDUSTRY_ID=TRT.INDUSTRY_ID  
WHERE  TDM.INDUSTRY_ID IN (SELECT * FROM SPLIT(@INDUSTRY_ID,','))  
  
END
GO
/****** Object:  StoredProcedure [dbo].[GET_SPECIALIZATION_BYEDUCATION]    Script Date: 27-Jan-17 1:15:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[GET_SPECIALIZATION_BYEDUCATION]  
(    
@EDUCATION_TYPE_ID VARCHAR(50) = null
)    
AS     
BEGIN    
    
	SELECT TEM.EDUCATION_TYPE_ID,TEM.EDUCATION_TYPE,TSM.SPECIALIZATION_TYPE,TSM.SPECIALIZATION_ID          
	FROM TBL_EDUCATION_TYPE_MASTER TEM WITH (NOLOCK)          
	JOIN TBL_SPECIALIZATION_MASTER TSM WITH (NOLOCK) ON TEM.EDUCATION_TYPE_ID = TSM.EDUCATION_TYPE_ID              
	WHERE TEM.EDUCATION_TYPE_ID IN (SELECT * FROM Split(@EDUCATION_TYPE_ID,','))
	ORDER BY EDUCATION_TYPE,TSM.SPECIALIZATION_TYPE      
END  
  

GO
/****** Object:  StoredProcedure [dbo].[PROC_ADD_DELETE_MENU_FOR_USERTYPE]    Script Date: 27-Jan-17 1:15:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[PROC_ADD_DELETE_MENU_FOR_USERTYPE]
@MENU_ID int,                      
@USER_TYPE_ID VARCHAR(20),                     
@CREATED_BY varchar(50) ,
@CONDITIONAL_OPERATOR varchar(50) 
AS
BEGIN                   
IF @CONDITIONAL_OPERATOR ='ADD_MENU_FOR_USERTYPE'                       
 BEGIN                      
                      
  IF NOT EXISTS (SELECT * from TBL_USER_MENU_MAPPING WITH(NOLOCK) WHERE MENU_ID=@MENU_ID AND REGISTRATION_NUMBER = @USER_TYPE_ID)                      
  BEGIN                      
 
   INSERT INTO TBL_USER_MENU_MAPPING                       
   (                      
   MENU_ID,                      
   REGISTRATION_NUMBER,                      
   CREATED_DATE,                      
   CREATED_BY                     
   )                      
   VALUES                      
   (                      
   @MENU_ID,                      
   @USER_TYPE_ID,                      
   GETDATE(),                      
   @CREATED_BY                     
   )                      
  END                      
 END                      
                       
 ELSE IF @CONDITIONAL_OPERATOR ='DEL_MENU_FOR_USERTYPE'                      
 BEGIN                      
  DELETE FROM TBL_USER_MENU_MAPPING WHERE MENU_ID=@MENU_ID AND REGISTRATION_NUMBER = @USER_TYPE_ID                    
 END                      
 END
GO
/****** Object:  StoredProcedure [dbo].[PROC_ADVERTIZEMENT_MASTER]    Script Date: 27-Jan-17 1:15:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[PROC_ADVERTIZEMENT_MASTER]  
(  
 @CONDITIONAL_OPERATOR VARCHAR(30) = NULL  
 )  
AS   
BEGIN  
 IF @CONDITIONAL_OPERATOR = 'REQUIRMENT'  
 BEGIN  
  
  SELECT REQUIREMENT_ID ,(ISNULL(TCM.COMPANY_NAME,CLIENT.NAME) + ' | ' + ISNULL(TRD.JOB_TITLE,''))REQUIREMENT
	FROM TBL_REQUIREMENT_DETAILS TRD WITH (NOLOCK)
	LEFT JOIN TBL_COMPANY_MASTER TCM WITH(NOLOCK) ON TCM.COMPANY_ID=TRD.COMPANY_ID
	LEFT JOIN 
	(
		SELECT TUD.REGISTRATION_NO,(ISNULL(TUPD.FIRST_NAME,'') +' ' + ISNULL(TUPD.MIDDLE_NAME,'') +' '+ ISNULL(TUPD.LAST_NAME,''))NAME 
		FROM TBL_USER_DETAILS TUD WITH(NOLOCK) 
		JOIN TBL_USER_PERSONAL_DETAILS TUPD WITH(NOLOCK) ON TUD.REGISTRATION_NO=TUPD.REGISTRATION_NO
		WHERE TUD.USER_TYPE_ID = 5
	)CLIENT ON TRD.CONTACT_PERSON = CLIENT.REGISTRATION_NO
	WHERE TRD.IS_ACTIVE=1
  return  
 END   
   
 IF @CONDITIONAL_OPERATOR = 'SELECT'  
  BEGIN  
   --SELECT TAM.ADV_ID,TAM.PAPER_NAME,TAM.AD_AGENCY_NAME,TAM.EXPENSES,FILE_PATH,ADV_DATE,  
   --ISNULL(TCM.COMPANY_NAME,  
   --ISNULL(TUPD.FIRST_NAME,'') + SPACE(1) +   
   --ISNULL(TUPD.MIDDLE_NAME,'') + SPACE(1)   
   --+ ISNULL(TUPD.LAST_NAME,'')   
   --)REQUIREMENTs     
   --FROM TBL_ADVERTISEMENT_MASTER TAM  
   --JOIN TBL_REQUIREMENT_DETAILS TRD on TAM.REQUIREMENTS = TRD.requirement_id  
   --LEFT join TBL_COMPANY_MASTER TCM ON TRD.COMPANY_ID = TCM.COMPANY_ID  
   ----LEFT JOIN TBL_USER_DETAILS TUD ON TRD.CONTACT_PERSON = TUD.REGISTRATION_NO  
   --LEFT JOIN TBL_USER_PERSONAL_DETAILS TUPD ON TRD.CONTACT_PERSON = TUPD.REGISTRATION_NO  
   
   SELECT TAM.ADV_ID,TAM.PAPER_NAME,TAM.AD_AGENCY_NAME,TAM.EXPENSES,FILE_PATH,ADV_DATE,
   REQUIREMENT_ID ,(ISNULL(TCM.COMPANY_NAME,CLIENT.NAME) + ' | ' + ISNULL(TRD.JOB_TITLE,''))REQUIREMENTs
   FROM TBL_ADVERTISEMENT_MASTER TAM  
	JOIN TBL_REQUIREMENT_DETAILS TRD WITH (NOLOCK) ON TAM.REQUIREMENTS = TRD.REQUIREMENT_ID
	LEFT JOIN TBL_COMPANY_MASTER TCM WITH(NOLOCK) ON TCM.COMPANY_ID=TRD.COMPANY_ID
	LEFT JOIN 
	(
		SELECT TUD.REGISTRATION_NO,(ISNULL(TUPD.FIRST_NAME,'') +' ' + ISNULL(TUPD.MIDDLE_NAME,'') +' '+ ISNULL(TUPD.LAST_NAME,''))NAME 
		FROM TBL_USER_DETAILS TUD WITH(NOLOCK) 
		JOIN TBL_USER_PERSONAL_DETAILS TUPD WITH(NOLOCK) ON TUD.REGISTRATION_NO=TUPD.REGISTRATION_NO
		WHERE TUD.USER_TYPE_ID = 5
	)CLIENT ON TRD.CONTACT_PERSON = CLIENT.REGISTRATION_NO
	WHERE TRD.IS_ACTIVE=1
   
  END  
   
END 

GO
/****** Object:  StoredProcedure [dbo].[PROC_ALL_MASTER]    Script Date: 27-Jan-17 1:15:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
                              
                        
CREATE PROC [dbo].[PROC_ALL_MASTER]                                        
(                                        
@CONDITIONAL_OPERATOR VARCHAR(50) =NULL,                                        
@REGISTRATION_NO VARCHAR(12) =NULL                                      
)                                        
AS                                        
BEGIN                                        
                        
 IF @CONDITIONAL_OPERATOR='COUNTRY_STATE_CITY_MASTER'                                        
 BEGIN                                        
  SELECT TCM.CITY_CODE,TCM.CITY_NAME,TSM.STATE_CODE,TSM.STATE_NAME,TCUM.COUNTRY_CODE,TCUM.COUNTRY_NAME,tcm.IS_ACTIVE                                         
  FROM TBL_CITY_MASTER TCM WITH (NOLOCK)                                        
  LEFT JOIN TBL_STATE_MASTER TSM WITH (NOLOCK) ON TCM.STATE_CODE = TSM.STATE_CODE                                        
  LEFT JOIN TBL_COUNTRY_MASTER TCUM WITH (NOLOCK) ON TSM.COUNTRY_CODE = TCUM.COUNTRY_CODE        
  ORDER BY TCUM.COUNTRY_NAME,TSM.STATE_NAME,TCM.CITY_NAME        
 END                                        
                        
 IF @CONDITIONAL_OPERATOR='AvailingType'                                        
 BEGIN                                        
  SELECT AVAILING_TYPE_ID,AVAILING_TYPE,TYPE_ORDER,IS_ACTIVE                                        
  FROM TBL_AVAILING_TYPE_MASTER WITH (NOLOCK)                                        
  ORDER BY AVAILING_TYPE                                        
 END                                        
                        
 IF @CONDITIONAL_OPERATOR='Source'                                        
 BEGIN                                        
  SELECT SOURCE_ID,SOURCE_NAME,SOURCE_ORDER                                        
  FROM TBL_SOURCE_MASTER WITH (NOLOCK)                                        
  ORDER BY SOURCE_NAME                                        
 END                                        
                        
 IF @CONDITIONAL_OPERATOR='Status'                                        
 BEGIN                                        
  SELECT STATUS_ID,STATUS_NAME,DESCRIPTION,STATUS_ORDER                                        
  FROM TBL_STATUS_MASTER WITH (NOLOCK)
  WHERE IS_ACTIVE=1                                        
  ORDER BY STATUS_NAME                                        
 END                                        
                        
 IF @CONDITIONAL_OPERATOR='Requirement'                                        
 BEGIN                                        
 select TRD.REQUIREMENT_ID,TCM.COMPANY_NAME         
 from TBL_REQUIREMENT_DETAILS TRD WITH (NOLOCK)                    
 JOIN TBL_COMPANY_MASTER TCM WITH (NOLOCK) ON TRD.COMPANY_ID=TCM.COMPANY_ID                    
 ORDER BY TCM.COMPANY_NAME        
 END                                        
                        
 IF @CONDITIONAL_OPERATOR='VisaType'                                        
 BEGIN                                        
  SELECT VISA_ID,VISA_NUMBER                                        
  FROM TBL_VISA_MASTER WITH (NOLOCK)                                        
 END                                        
                        
 IF @CONDITIONAL_OPERATOR='MaritalStatus'                                        
 BEGIN                                        
  SELECT MARITAL_STATUS_ID,MARITAL_STATUS,MARITAL_STATUS_ORDER                                        
  FROM TBL_MARITAL_STATUS_MASTER WITH (NOLOCK)                                        
  ORDER BY MARITAL_STATUS                                        
 END                                        
                        
 IF @CONDITIONAL_OPERATOR='Nationality'                                        
 BEGIN                                        
  SELECT NATIONALITY_ID,NATIONALITY                                        
  FROM TBL_NATIONALITY_MASTER WITH (NOLOCK)        
  ORDER BY NATIONALITY               
 END                                        
                        
 IF @CONDITIONAL_OPERATOR='Location'         
 BEGIN                                        
  SELECT CITY_CODE,CITY_NAME        
  FROM TBL_CITY_MASTER WITH (NOLOCK)        
  ORDER BY CITY_NAME        
 END                                        
                        
 IF @CONDITIONAL_OPERATOR='Religion'                                        
 BEGIN                                 
  SELECT RELIGION_ID,RELIGION_NAME        
  FROM TBL_RELIGION_MASTER WITH (NOLOCK)        
  ORDER BY RELIGION_NAME        
 END                                        
                        
 IF @CONDITIONAL_OPERATOR='Languages'                                        
 BEGIN              
  SELECT LANGUAGE_ID,LANGUAGE_NAME        
  FROM TBL_LANGUAGE_MASTER WITH (NOLOCK)        
  ORDER BY LANGUAGE_NAME        
 END                      
                        
 IF @CONDITIONAL_OPERATOR='AddressType'                                        
 BEGIN                                        
 SELECT ADDRESS_TYPE_ID,ADDRESS_TYPE,TYPE_FOR                                        
 FROM TBL_ADDRESS_TYPE_MASTER WITH (NOLOCK)        
 ORDER BY ADDRESS_TYPE        
 END                                        
                        
 IF @CONDITIONAL_OPERATOR='University'                                        
 BEGIN                                        
  SELECT UNIVERSITY_ID,UNIVERSITY_NAME                                        
  FROM TBL_UNIVERSITY_MASTER WITH (NOLOCK)                                        
 END                                        
                        
 IF @CONDITIONAL_OPERATOR='Company'                                        
 BEGIN                                        
  SELECT COMPANY_ID,COMPANY_NAME        
  FROM TBL_COMPANY_MASTER WITH (NOLOCK)        
  ORDER BY COMPANY_NAME        
 END                                        
                        
 IF @CONDITIONAL_OPERATOR='Designation'                                        
 BEGIN                                        
 SELECT DESIGNATION_ID,DESIGNATION_NAME, TRT.INDUSTRY_ID,TRT.INDUSTRY_TYPE            
 FROM TBL_DESIGNATION_MASTER TDM WITH (NOLOCK)                     
 JOIN TBL_INDUSTRY_MASTER TRT WITH (NOLOCK) ON TDM.INDUSTRY_ID=TRT.INDUSTRY_ID                                 
 ORDER BY TRT.INDUSTRY_TYPE,DESIGNATION_NAME        
 END                                        
                        
 IF @CONDITIONAL_OPERATOR='Industry'                                        
 BEGIN                                        
  SELECT INDUSTRY_ID,INDUSTRY_TYPE                                        
  FROM TBL_INDUSTRY_MASTER WITH (NOLOCK)                                        
  ORDER BY INDUSTRY_TYPE        
 END                                      
                        
 IF @CONDITIONAL_OPERATOR='GetAddressDetails'                                        
 BEGIN                                        
--SELECT '1' USER_ADDRESS_ID,'Add'ADDRESS,'C001'CITY_CODE,'Mumbai'USER_VILLAGE,'400099'USER_PINCODE,'India'COUNTRY_NAME,'StateCity'STATECITY                                    
  SELECT USER_ADDRESS_ID,(TATM.ADDRESS_TYPE+'-'+ADDRESS)ADDRESS,TCM.CITY_CODE,USER_VILLAGE,USER_PINCODE,TCTM.COUNTRY_NAME,(TSM.STATE_NAME+' '+TCM.CITY_NAME)STATECITY                                      
   FROM TBL_USER_ADDRESS TUA WITH(NOLOCK)                                      
   JOIN TBL_ADDRESS_TYPE_MASTER TATM WITH(NOLOCK) ON TUA.ADDRESS_TYPE_ID = TATM.ADDRESS_TYPE_ID                                      
   JOIN TBL_CITY_MASTER TCM WITH(NOLOCK) ON TUA.CITY_CODE = TCM.CITY_CODE                                      
   LEFT JOIN TBL_STATE_MASTER TSM WITH(NOLOCK) ON TCM.STATE_CODE =TSM.STATE_CODE                                      
   LEFT JOIN TBL_COUNTRY_MASTER TCTM WITH(NOLOCK) ON TSM.COUNTRY_CODE =TCTM.COUNTRY_CODE                                      
   WHERE REGISTRATION_NUMBER = @REGISTRATION_NO                                      
          
 END                                      
                        
 IF @CONDITIONAL_OPERATOR='Education'                                        
 BEGIN                                        
  SELECT TEM.EDUCATION_TYPE_ID,TEM.EDUCATION_TYPE,TSM.SPECIALIZATION_TYPE,TSM.SPECIALIZATION_ID              
  FROM TBL_EDUCATION_TYPE_MASTER TEM WITH (NOLOCK)              
  JOIN TBL_SPECIALIZATION_MASTER TSM WITH (NOLOCK) ON TEM.EDUCATION_TYPE_ID = TSM.EDUCATION_TYPE_ID                  
  ORDER BY EDUCATION_TYPE,TSM.SPECIALIZATION_TYPE        
 END                                  
                        
                                       
                        
 IF @CONDITIONAL_OPERATOR='Specialization'                                       
 BEGIN                                        
  SELECT SPECIALIZATION_ID,SPECIALIZATION_TYPE                 
  FROM TBL_SPECIALIZATION_MASTER WITH (NOLOCK)                                        
  ORDER BY SPECIALIZATION_TYPE                                      
 END                                        
                        
 IF @CONDITIONAL_OPERATOR='Vehicle_type'               
 BEGIN                                        
  SELECT VEHICLE_TYPE_ID,VEHICLE_TYPE                                  
  FROM TBL_VEHICLE_TYPE WITH (NOLOCK)                                        
  ORDER BY VEHICLE_TYPE                                  
                        
 END                                        
                        
 IF @CONDITIONAL_OPERATOR='Branch'                                       
 BEGIN                                        
  SELECT BRANCH_CODE,BRANCH_NAME        
  FROM TBL_BRANCH_MASTER WITH (NOLOCK)                                        
  ORDER BY BRANCH_NAME        
 END                            
                        
 IF @CONDITIONAL_OPERATOR='UserType'                                       
 BEGIN                                        
  --SELECT USER_TYPE,USER_TYPE_ID                            
  --FROM TBL_USER_TYPE WITH (NOLOCK)                                        
  --WHERE IS_ACTIVE=1                            
  SELECT TUD.REGISTRATION_NO AS USER_TYPE_ID,                  
  ISNULL(FIRST_NAME + SPACE(1),'') +                   
  isnull(MIDDLE_NAME + SPACE(1),'')+ isnull(LAST_NAME,'')USER_TYPE                  
  FROM TBL_USER_PERSONAL_DETAILS  TUP WITH(NOLOCK)                  
  JOIN TBL_USER_DETAILS TUD WITH(NOLOCK) ON TUP.REGISTRATION_NO = TUD.REGISTRATION_NO                   
  WHERE USER_TYPE_ID =2                  
                        
 END                            
         
 IF @CONDITIONAL_OPERATOR='MODE_OF_INTERVIEW'                                       
 BEGIN                                        
  SELECT INTERVIEW_MODE,INTERVIEW_MODE_ID                          
  FROM TBL_INTERVIEW_MODE_MASTER WITH (NOLOCK)                                        
  WHERE IS_ACTIVE=1                            
  ORDER BY INTERVIEW_MODE        
 END                                        
                        
 IF @CONDITIONAL_OPERATOR='CURRENCY'                                       
 BEGIN                                        
  SELECT CURRENCY_ID,CURRENCY_SYMBOL AS CURRENCY_NAME                          
  FROM TBL_CURRENCY_MASTER WITH (NOLOCK)                                        
  WHERE IS_ACTIVE=1                            
 END                        
                         
 IF @CONDITIONAL_OPERATOR='Agent'                                       
 BEGIN                                        
  SELECT TUD.REGISTRATION_NO,(ISNULL(TUPD.FIRST_NAME,'') +' '+ISNULL(TUPD.LAST_NAME,''))COMPANY_NAME                        
  FROM TBL_USER_DETAILS TUD WITH (NOLOCK)                                        
  JOIN TBL_USER_PERSONAL_DETAILS TUPD WITH(NOLOCK) ON TUD.REGISTRATION_NO=TUPD.REGISTRATION_NO                        
  WHERE USER_TYPE_ID=3                           
 END                         
                         
 IF @CONDITIONAL_OPERATOR='CERTIFICATION'                           
                        
 BEGIN                                        
                        
  SELECT CERTIFICATION_ID,CERTIFICATION_NAME        
  FROM TBL_CERTIFICATION_MASTER WITH (NOLOCK)                                        
  WHERE IS_ACTIVE=1        
  ORDER BY CERTIFICATION_NAME        
                        
 END                          
                       
 IF @CONDITIONAL_OPERATOR='GETCLIENT'                                       
 BEGIN                                        
	SELECT TUD.REGISTRATION_NO,(ISNULL(TUPD.FIRST_NAME,'') +' ' + ISNULL(TUPD.MIDDLE_NAME,'') +' '+ ISNULL(TUPD.LAST_NAME,''))NAME
	FROM TBL_USER_DETAILS TUD WITH (NOLOCK)                      
	JOIN TBL_USER_PERSONAL_DETAILS TUPD WITH (NOLOCK) ON TUD.REGISTRATION_NO = TUPD.REGISTRATION_NO                      
	WHERE USER_TYPE_ID = 5 AND IS_ACTIVE =1        
	ORDER BY (ISNULL(TUPD.FIRST_NAME,'') +' ' + ISNULL(TUPD.MIDDLE_NAME,'') +' '+ ISNULL(TUPD.LAST_NAME,''))        
END                      
                       
 IF @CONDITIONAL_OPERATOR='GETCANDIDATE'                   
                        
 BEGIN                                        
                        
SELECT TPD.PASSPORT_ID,(ISNULL(TPD.PASSPORT_NUMBER,'') +' | '+ ISNULL(TUPD.FIRST_NAME,'') +' ' + ISNULL(TUPD.MIDDLE_NAME,'') +' '+ ISNULL(TUPD.LAST_NAME,''))NAME                      
FROM TBL_USER_DETAILS TUD WITH (NOLOCK)                      
JOIN TBL_USER_PERSONAL_DETAILS TUPD WITH (NOLOCK) ON TUD.REGISTRATION_NO = TUPD.REGISTRATION_NO                      
JOIN TBL_PASSPORT_DETAILS TPD WITH(NOLOCK) ON TUD.REGISTRATION_NO = TPD.REGISTATION_NUMBER                      
WHERE USER_TYPE_ID = 1 AND TPD.PASSPORT_NUMBER IS NOT NULL AND STATUS_ID=6                      
ORDER BY (ISNULL(TUPD.FIRST_NAME,'') +' ' + ISNULL(TUPD.MIDDLE_NAME,'') +' '+ ISNULL(TUPD.LAST_NAME,''))        
                        
END                      
                      
IF @CONDITIONAL_OPERATOR='GETDOCTOR'                                       
                        
 BEGIN                                        
                        
SELECT TUD.REGISTRATION_NO,(ISNULL(TUPD.FIRST_NAME,'') +' ' + ISNULL(TUPD.MIDDLE_NAME,'') +' '+ ISNULL(TUPD.LAST_NAME,''))NAME                      
FROM TBL_USER_DETAILS TUD WITH (NOLOCK)                      
JOIN TBL_USER_PERSONAL_DETAILS TUPD WITH (NOLOCK) ON TUD.REGISTRATION_NO = TUPD.REGISTRATION_NO                      
WHERE USER_TYPE_ID = 4        
ORDER BY (ISNULL(TUPD.FIRST_NAME,'') +' ' + ISNULL(TUPD.MIDDLE_NAME,'') +' '+ ISNULL(TUPD.LAST_NAME,''))                      
                        
END                      
                    
IF @CONDITIONAL_OPERATOR='GETCANDIDATEFOR_VISA_ENDORSEMENT'                                       
                        
 BEGIN                                        
                        
SELECT TPD.PASSPORT_ID,(ISNULL(TPD.PASSPORT_NUMBER,'') +' | '+ ISNULL(TUPD.FIRST_NAME,'') +' ' + ISNULL(TUPD.MIDDLE_NAME,'') +' '+ ISNULL(TUPD.LAST_NAME,''))NAME                      
FROM TBL_USER_DETAILS TUD WITH (NOLOCK)                      
JOIN TBL_USER_PERSONAL_DETAILS TUPD WITH (NOLOCK) ON TUD.REGISTRATION_NO = TUPD.REGISTRATION_NO                      
JOIN TBL_PASSPORT_DETAILS TPD WITH(NOLOCK) ON TUD.REGISTRATION_NO = TPD.REGISTATION_NUMBER                    
JOIN TBL_MOFA TMO WITH(NOLOCK) ON TPD.PASSPORT_ID = TMO.PassportID                      
WHERE USER_TYPE_ID = 1 AND TPD.PASSPORT_NUMBER IS NOT NULL AND DDDate IS NOT NULL--AND STATUS_ID=6                      
ORDER BY (ISNULL(TUPD.FIRST_NAME,'') +' ' + ISNULL(TUPD.MIDDLE_NAME,'') +' '+ ISNULL(TUPD.LAST_NAME,''))                        
END                     
                    
IF @CONDITIONAL_OPERATOR='GETAIRLINES'                                       
 BEGIN                                        
SELECT AirlinesId,AirlinesName         
from TBL_AIRLINES_MASTER              
ORDER BY AirlinesName              
END        
        
IF @CONDITIONAL_OPERATOR='PORTAL'                                       
BEGIN                                        
SELECT PORTAL_ID,PORTAL_NAME         
FROM TBL_PORTAL_MASTER WITH(NOLOCK)        
ORDER BY PORTAL_NAME        
END        
      
IF @CONDITIONAL_OPERATOR='FOLDER_NAME'                                       
BEGIN      
SELECT * FROM TBL_SAVE_TO_FOLDER_DETAILS        
END      
                   
END 

GO
/****** Object:  StoredProcedure [dbo].[PROC_CANDIDATE_STATUS_SEARCH]    Script Date: 27-Jan-17 1:15:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[PROC_CANDIDATE_STATUS_SEARCH]    
(    
 @REGISTRATION_NO VARCHAR(20) = NULL
)AS     
BEGIN    
	--Personal Details--
	SELECT top 1 TUD.REGISTRATION_NO,TUD.CREATED_DATE,ltrim(rtrim(isnull(FIRST_NAME + ' ',' '))) +' ' + ltrim(rtrim(isnull(MIDDLE_NAME + ' ','')))+ ' ' +ltrim(rtrim(isnull(LAST_NAME,''))) AS CANDIDATE_NAME,
	TPD.FIRST_NAME,TPD.MIDDLE_NAME,TPD.LAST_NAME,TPD.FATHER_NAME,(select GENDER_NAME from TBL_GENDER_MASTER where GENDER_CODE = TPD.GENDER_CODE) as GENDER_NAME,TPD.GENDER_CODE,
	TPD.DATE_OF_BIRTH,DATEDIFF(YEAR,DATE_OF_BIRTH,GETDATE()) -(CASE WHEN DATEADD(YY,DATEDIFF(YEAR,DATE_OF_BIRTH,GETDATE()),DATE_OF_BIRTH)> GETDATE() THEN 1 ELSE 0 END) AGE,TPAD.PASSPORT_NUMBER as PASSPORT_NUMBER,
	TPD.PLACE_OF_BIRTH,TBL_MARITAL.MARITAL_STATUS,TPD.MARITAL_STATUS_ID,TBL_NATION.NATIONALITY,TPD.NATIONALITY_ID,
	TBL_RELIGION.RELIGION_NAME,TPD.RELIGION_ID,TUD.USER_IMAGE_PATH as FILE_PATH,
	CONTACT.CONTACT_NO,USER_EMAIL.USER_EMAIL USER_EMAIL,
	ISNULL(TSM.SOURCE_NAME,OTHER_SOURCE) AS SOURCE_NAME,AVAILING_TYPE,
	TCM.CITY_NAME AS CURRENT_LOCATION,
	TPAD.EMIGRATION_CLEARANCE_REQUIRED as EMIGRATION_CLEARANCE_REQUIRED

	FROM TBL_USER_DETAILS TUD WITH(NOLOCK)
	JOIN TBL_USER_PERSONAL_DETAILS TPD WITH(NOLOCK) ON TUD.REGISTRATION_NO = TPD.REGISTRATION_NO
	LEFT Join TBL_MARITAL_STATUS_MASTER TBL_MARITAL With(NOLOCK) ON TPD.MARITAL_STATUS_ID = TBL_MARITAL.MARITAL_STATUS_ID
	LEFT Join TBL_NATIONALITY_MASTER TBL_NATION With(NOLOCK) ON TPD.NATIONALITY_ID = TPD.NATIONALITY_ID
	LEFT Join TBL_RELIGION_MASTER TBL_RELIGION With(NOLOCK) ON TPD.RELIGION_ID = TBL_RELIGION.RELIGION_ID
	LEFT JOIN TBL_PASSPORT_DETAILS TPAD WITH (NOLOCK)ON TUD.REGISTRATION_NO = TPAD.REGISTATION_NUMBER
	LEFT JOIN TBL_SOURCE_MASTER TSM WITH (NOLOCK) ON TUD.SOURCE_ID = TSM.SOURCE_ID
	LEFT JOIN TBL_AVAILING_TYPE_MASTER TAM WITH (NOLOCK) ON TUD.AVAILING_TYPE_ID = TAM.AVAILING_TYPE_ID
	LEFT JOIN TBL_CITY_MASTER TCM WITH (NOLOCK) ON TUD.LOCATION_CODE = TCM.CITY_CODE
	LEFT JOIN             
	(            
	 SELECT DISTINCT p.REGISTRATION_NUMBER,                  
	 (
		 SELECT SUBSTRING((SELECT ',' + TUC.CONTACT_NO 
		 FROM TBL_USER_CONTACTS TUC    
		 WHERE P.REGISTRATION_NUMBER = TUC.REGISTRATION_NUMBER    
		 ORDER BY TUC.USER_CONTACT_ID    
		 FOR XML PATH('')),2,200000)
	 ) AS CONTACT_NO                    
	 FROM TBL_USER_CONTACTS p WITH (NOLOCK)             
	)CONTACT ON TUD.REGISTRATION_NO = CONTACT.REGISTRATION_NUMBER    
	LEFT JOIN             
	 (            
		SELECT DISTINCT p.REGISTRATION_NUMBER,                  
		(
		SELECT SUBSTRING((SELECT ',' + TEUA.USER_EMAIL
		FROM TBL_USER_EMAIL_ADDRESS TEUA    
		WHERE P.REGISTRATION_NUMBER = TEUA.REGISTRATION_NUMBER    
		ORDER BY TEUA.USER_EMAIL    
		FOR XML PATH('')),2,200000)
		)AS USER_EMAIL
	  FROM TBL_USER_EMAIL_ADDRESS p    WITH(NOLOCK)            
	)USER_EMAIL ON TUD.REGISTRATION_NO = user_email.REGISTRATION_NUMBER     
	WHERE TUD.REGISTRATION_NO = @REGISTRATION_NO

	 -- SECTION 2 EDUCATION DETAILS    
	SELECT EDUCATION_TYPE,SPECIALIZATION_TYPE,TUED.UNIVERSITY_ID AS UNIVERSITY_NAME,REGISTRATION_NO,    
	UNIVERSITY_YEAR_OF_PASSING FROM TBL_USER_EDUCATION_DETAILS TUED WITH (NOLOCK)    
	JOIN TBL_EDUCATION_TYPE_MASTER TETM WITH (NOLOCK)ON TUED.EDUCATION_TYPE_ID = TETM.EDUCATION_TYPE_ID    
	JOIN TBL_SPECIALIZATION_MASTER TSM WITH (NOLOCK)ON TUED.SPECIALIZATION_TYPE_ID = TSM.SPECIALIZATION_ID 
	WHERE REGISTRATION_NO = @REGISTRATION_NO

	 --Certification DETAILS    
	SELECT REGISTRATION_NUMBER,CERTIFICATION_NAME as CERTIFICATION,CERTIFICATION_LEVEL,    
	INSTITUTE, YEAR_OF_PASSING FROM TBL_USER_CERTIFICATION TUC WITH (NOLOCK)    
	JOIN TBL_CERTIFICATION_MASTER TCM WITH (NOLOCK)ON TUC.USER_CERTIFICATION_ID = TCM.CERTIFICATION_ID    
	WHERE REGISTRATION_NUMBER = @REGISTRATION_NO

	----Industry Details
	--SELECT TUE.REGISTRATION_NO,TIM.INDUSTRY_TYPE,TDM.DESIGNATION_NAME,TUD.TOTAL_WORK_EXPERIENCE,TUD.TOTAL_GULF_EXPERIENCE
	--FROM TBL_USER_EXPERIENCE TUE WITH(NOLOCK)    
	--JOIN TBL_INDUSTRY_MASTER TIM WITH(NOLOCK) ON TUE.INDUSTRY_ID=TIM.INDUSTRY_ID    
	--JOIN TBL_DESIGNATION_MASTER TDM WITH (NOLOCK) ON TUE.DESIGNATION_ID=TDM.DESIGNATION_ID  
	--JOIN TBL_USER_DETAILS TUD WITH(NOLOCK) ON TUD.REGISTRATION_NO = TUE.REGISTRATION_NO  
	--WHERE TUE.REGISTRATION_NO = @REGISTRATION_NO

	----Mofa Details
	--select top 1 tbl_mofa.MofaNumber,tbl_mofa.MofaDate,tbl_mofa.ApplicationNumber,tbl_mofa.ApplicationDate,
	--tbl_mofa.HealthNumber,tbl_mofa.HealthDate,tbl_mofa.DDDate,tbl_mofa.DDNumber
	--from TBL_MOFA tbl_mofa
	--join TBL_PASSPORT_DETAILS tbl_passport
	--on tbl_mofa.PassportID = tbl_passport.PASSPORT_ID
	--where tbl_passport.REGISTATION_NUMBER = @REGISTRATION_NO
	--ORDER BY CREATED_DATE DESC

	----Medical Details
	--select top 1 tbl_status.STATUS_NAME,tbl_medical.CheckupDate,
	--(select FIRST_NAME + ' ' + LAST_NAME  from TBL_USER_PERSONAL_DETAILS tbl_personal where tbl_personal.REGISTRATION_NO = tbl_medical.DoctorID) as Doctor
	--from TBL_MEDICAL tbl_medical
	--Join TBL_STATUS_MASTER tbl_status
	--on tbl_status.STATUS_ID = tbl_medical.MedicalStatus
	--Join TBL_PASSPORT_DETAILS tbl_passport
	--on tbl_passport.PASSPORT_ID = tbl_medical.PassportID
	--where tbl_passport.REGISTATION_NUMBER = @REGISTRATION_NO
	--ORDER BY tbl_medical.CreatedDate DESC
	

	----Visa Endorsement
	--select top 1 tbl_status.STATUS_NAME, tbl_visa_endorsement.SubmissionDate
	--from TBL_VISA_ENDORSEMENT tbl_visa_endorsement
	--join TBL_STATUS_MASTER tbl_status
	--on tbl_status.STATUS_ID = tbl_visa_endorsement.SubmissionStatusID
	--join TBL_USER_DETAILS tbl_user_details
	--on tbl_user_details.REGISTRATION_NO = @REGISTRATION_NO
	--ORDER BY tbl_visa_endorsement.CreatedDate DESC

	----Policy Details
	--select top 1 tbl_policy.POLICYID, tbl_policy.PolicyDate,tbl_policy.Policy
	--from TBL_POLICY tbl_policy
	--join TBL_PASSPORT_DETAILS tbl_passport
	--on tbl_passport.PASSPORT_ID = tbl_policy.PassportID
	--where tbl_passport.REGISTATION_NUMBER = @REGISTRATION_NO
	--ORDER BY CreatedDate DESC
	
	----Travel Details
	--select top 1 CASE WHEN tbl_ticket.IsBooked=1 THEN 'BOOKED' ELSE 'CANCELLED' end TRAVEL_STATUS,
	--tbl_ticket.PnrNumber,tbl_ticket.DepartureDate,
	--tbl_airlines.AirlinesName,tbl_city.CITY_NAME as DepartureCity,
	--tbl_destination_city.CITY_NAME as DestinationCity,
	--tbl_ticket.DepartureTime , 
	--tbl_ticket.ArrivalTime
	--from TBL_TICKET tbl_ticket
	--join TBL_AIRLINES_MASTER tbl_airlines
	--on tbl_airlines.AirlinesId = tbl_ticket.AirlinesID
	--join TBL_CITY_MASTER tbl_city 
	--on tbl_city.CITY_CODE = tbl_ticket.DepartureCityCode
	--join TBL_CITY_MASTER tbl_destination_city
	--on tbl_destination_city.CITY_CODE = tbl_ticket.DestinationCityCode
	--join TBL_PASSPORT_DETAILS tbl_passport
	--on tbl_passport.PASSPORT_ID = tbl_ticket.PassportId
	--where tbl_passport.REGISTATION_NUMBER = @REGISTRATION_NO
	--ORDER BY tbl_ticket.CreatedDate DESC

	--USER REQUIREMENT DETAILS
	SELECT REGISTRATION_NO,REQUIREMENT_ID,CANDIDATE_STATUS,CURRENT_STATUS,CREATED_BY
	FROM TBL_USER_REQUIREMENT
	WHERE REGISTRATION_NO=@REGISTRATION_NO
	ORDER BY CREATED_DATE DESC
END
GO
/****** Object:  StoredProcedure [dbo].[PROC_CANDIDATE_STATUS_SEARCH_1]    Script Date: 27-Jan-17 1:15:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[PROC_CANDIDATE_STATUS_SEARCH_1]    

(    

 @REGISTRATION_NO VARCHAR(20) ='C1020160004'    

    

)AS     

--- section 1     

BEGIN    

SELECT TUD.REGISTRATION_NO, CONVERT(VARCHAR(12),TUD.CREATED_DATE,103) REGISTRATION_DATE ,    

ltrim(rtrim(isnull(FIRST_NAME + ' ',' '))) +' ' + ltrim(rtrim(isnull(MIDDLE_NAME + ' ','')))+ ' ' +    

ltrim(rtrim(isnull(LAST_NAME,''))) AS CANDIDATE_NAME, CONVERT(VARCHAR(12),DATE_OF_BIRTH,103)DATE_OF_BIRTH,    

DATEDIFF(YEAR,DATE_OF_BIRTH,GETDATE()) -(CASE WHEN DATEADD(YY,DATEDIFF(YEAR,DATE_OF_BIRTH,GETDATE()),DATE_OF_BIRTH)> GETDATE() THEN 1 ELSE 0 END) AGE,    

PASSPORT_NUMBER,CONTACT.CONTACT_NO,user_email.user_email USER_EMAIL--,DESIGNATION_NAME,ROLE_TYPE     

,ISNULL(TSM.SOURCE_NAME,OTHER_SOURCE) AS SOURCE_NAME,AVAILING_TYPE,    

CASE WHEN ISNULL(EMIGRATION_CLEARANCE_REQUIRED,0) = 0 THEN 'NO' ELSE 'YES' END AS EMIGRATION_CLEARANCE_REQUIRED,    

CONVERT(VARCHAR,TOTAL_WORK_EXPERIENCE)TOTAL_WORK_EXPERIENCE,CONVERT(VARCHAR,TOTAL_GULF_EXPERIENCE)TOTAL_GULF_EXPERIENCE,   

CITY_NAME AS LOCATION,     

MOFANUMBER,CONVERT(VARCHAR(12),MOFADATE,103)MOFA_DATE, TM.ApplicationNumber APPLICATION_NO,CONVERT(VARCHAR(12),TM.ApplicationDate,103) APPLICATION_DATE,    

HEALTHNUMBER, CONVERT(VARCHAR(12),HEALTHDATE,103) HEALTHDATE, DDNUMBER, CONVERT(VARCHAR(12),DDDATE,103)DDDATE,    

TSMMED.STATUS_NAME AS MEDICALSTATUS, DOC.DOCTOR_NAME,    

CONVERT(VARCHAR(12),MED.CREATEDDATE,103) AS MEDICAL_DATE, CONVERT(VARCHAR(12),TVE.SUBMISSIONDATE,103) VISA_SUBMISSION_DATE ,    

TVSS.STATUS_NAME VISA_SUBMISSION_STATUS,TP.Policy POLICY_NO,CONVERT(VARCHAR(12),TP.PolicyDate,103) POLICY_DATE    

FROM TBL_USER_DETAILS TUD WITH (NOLOCK)    

JOIN TBL_USER_PERSONAL_DETAILS TPD WITH(NOLOCK) ON TUD.REGISTRATION_NO = TPD.REGISTRATION_NO    

LEFT JOIN TBL_PASSPORT_DETAILS TPAD WITH (NOLOCK)ON TUD.REGISTRATION_NO = TPAD.REGISTATION_NUMBER    

--LEFT JOIN TBL_INDUSTRY_MASTER TIM WITH (NOLOCK)ON  TUD.INDUSTRY_ID = TIM.INDUSTRY_ID    

--LEFT JOIN TBL_DESIGNATION_MASTER TDM WITH (NOLOCK)ON TUD.DESIGNATION_ID = TDM.DESIGNATION_ID    

--LEFT JOIN TBL_ROLE_MASTER TRM WITH (NOLOCK)ON TDM.ROLE_ID = TRM.ROLE_ID    

LEFT JOIN TBL_SOURCE_MASTER TSM WITH (NOLOCK) ON TUD.SOURCE_ID = TSM.SOURCE_ID    

LEFT JOIN TBL_CITY_MASTER TCM WITH (NOLOCK) ON TUD.LOCATION_CODE = TCM.CITY_CODE    

LEFT JOIN TBL_AVAILING_TYPE_MASTER TAM WITH (NOLOCK) ON TUD.AVAILING_TYPE_ID = TAM.AVAILING_TYPE_ID    

LEFT JOIN TBL_MOFA TM WITH (NOLOCK) ON TPAD.PASSPORT_ID = TM.PASSPORTID    

LEFT JOIN TBL_MEDICAL MED ON TPAD.PASSPORT_ID = MED.PassportID    

LEFT JOIN TBL_STATUS_MASTER TSMMED ON MED.MedicalStatus=TSMMED.STATUS_ID    

LEFT JOIN TBL_POLICY TP on  tpAd.PASSPORT_ID =TP.PassportID    

    

LEFT JOIN     

(    

SELECT (ISNULL(TUPD.FIRST_NAME,'') +' '+ISNULL(TUPD.LAST_NAME,'')) AS DOCTOR_NAME, TUD.REGISTRATION_NO     

FROM TBL_USER_DETAILS TUD WITH(NOLOCK)     

JOIN TBL_USER_PERSONAL_DETAILS TUPD WITH (NOLOCK) ON TUD.REGISTRATION_NO = TUPD.REGISTRATION_NO    

WHERE USER_TYPE_ID =4    

)DOC ON MED.DoctorID = DOC.REGISTRATION_NO    

LEFT JOIN TBL_VISA_MASTER TVM ON TUD.REGISTRATION_NO = TVM.REGISTRATION_NUMBER    

LEFT JOIN TBL_VISA_ENDORSEMENT TVE ON TPAD.PASSPORT_ID = TVE.PassportId    

LEFT JOIN TBL_STATUS_MASTER TVSS ON TVE.SubmissionStatusID = TVSS.STATUS_ID    

LEFT JOIN             

(            

 SELECT DISTINCT p.REGISTRATION_NUMBER,                  

 (SELECT SUBSTRING(    

 (SELECT ',' + TUC.CONTACT_NO    

 FROM TBL_USER_CONTACTS TUC    

 WHERE P.REGISTRATION_NUMBER = TUC.REGISTRATION_NUMBER    

 ORDER BY TUC.USER_CONTACT_ID    

 FOR XML PATH('')),2,200000)) AS CONTACT_NO                    

 FROM TBL_USER_CONTACTS p WITH (NOLOCK)             

)CONTACT ON TUD.REGISTRATION_NO = CONTACT.REGISTRATION_NUMBER    

LEFT JOIN             

   (            

    SELECT DISTINCT p.REGISTRATION_NUMBER,                  

  (SELECT SUBSTRING(    

  (SELECT ',' + TEUA.USER_EMAIL    

  FROM TBL_USER_EMAIL_ADDRESS TEUA    

  WHERE P.REGISTRATION_NUMBER = TEUA.REGISTRATION_NUMBER    

  ORDER BY TEUA.USER_EMAIL    

  FOR XML PATH('')),2,200000)) AS  user_email                    

     FROM TBL_USER_EMAIL_ADDRESS p    WITH(NOLOCK)            

   )user_email ON TUD.REGISTRATION_NO = user_email.REGISTRATION_NUMBER     

   WHERE TUD.REGISTRATION_NO = @REGISTRATION_NO    

       

       

       

   -- SECTION 2 EDUCATION DETAILS     

   SELECT EDUCATION_TYPE,SPECIALIZATION_TYPE,TUED.UNIVERSITY_ID AS UNIVERSITY_NAME,REGISTRATION_NO,    

	UNIVERSITY_YEAR_OF_PASSING FROM TBL_USER_EDUCATION_DETAILS TUED WITH (NOLOCK)    

	JOIN TBL_EDUCATION_TYPE_MASTER TETM WITH (NOLOCK)ON TUED.EDUCATION_TYPE_ID = TETM.EDUCATION_TYPE_ID    

	JOIN TBL_SPECIALIZATION_MASTER TSM WITH (NOLOCK)ON TUED.SPECIALIZATION_TYPE_ID = TSM.SPECIALIZATION_ID 

   WHERE REGISTRATION_NO = @REGISTRATION_NO    

   -- SECTION 3 CERTIFICATION DETAILS     

       

   SELECT REGISTRATION_NUMBER,CERTIFICATION_NAME,CERTIFICATION_LEVEL,    

   INSTITUTE, YEAR_OF_PASSING FROM TBL_USER_CERTIFICATION TUC WITH (NOLOCK)    

   JOIN TBL_CERTIFICATION_MASTER TCM WITH (NOLOCK)ON TUC.USER_CERTIFICATION_ID = TCM.CERTIFICATION_ID    

   WHERE REGISTRATION_NUMBER = @REGISTRATION_NO    

       

   --SECTION 4 TICKET DETAILS     

   SELECT TICKET_DETAILS.*, TCM_DEPT.CITY_NAME DEPARTURE_PLACE, TCM_DEST.CITY_NAME DESTINATION_PLACE FROM     

   (    

   SELECT REGISTATION_NUMBER,CASE WHEN ISNULL(TAM.AirlinesName,'')='OTHER' THEN OtherAirlines ELSE TAM.AirlinesName end AIRLINES,    

   ISNULL(TICKET.PnrNumber,TCTD.PNRNUMBER) AS PNR     

   ,ISNULL(TICKET.TicketNumber,TCTD.TICKETNUMBER) TICKETNUMBER,    

   ISNULL(TICKET.FlightNumber, TCTD.FLIGHTNUMBER) FLIGHTNUMBER,     

   ISNULL(TICKET.DepartureCityCode,TCTD.DepartureCityCode)DEP_CITYCODE,    

   CONVERT(VARCHAR(12),ISNULL(TICKET.DepartureDate,TCTD.DepartureDate),103)TRAVEL_DATE,    

   ISNULL(TICKET.DepartureTime,TCTD.DepartureTime) DEPARTURE_TIME,    

   ISNULL(TICKET.DestinationCityCode,TCTD.DestinationCityCode)DEST_CITYCODE,    

   CONVERT(VARCHAR(12),ISNULL(TICKET.ArivalDate,TCTD.ArrivalDate),103)ARR_DATE,ISNULL(TICKET.ArrivalTime,TCTD.ArrivalTime)DESTINATION_TIME,    

   CASE WHEN TICKET.IsBooked=1 THEN 'BOOKED' ELSE 'CANCELLED' end TRAVEL_STATUS    

   FROM TBL_PASSPORT_DETAILS TPAD WITH (NOLOCK)    

   JOIN  TBL_TICKET TICKET  WITH(NOLOCK) ON TPAD.PASSPORT_ID = TICKET.PASSPORTID    

   LEFT JOIN TBL_CONNECTED_TICKETDETAILS TCTD ON TICKET.TICKETID = TCTD.TICKETID    

   JOIN TBL_AIRLINES_MASTER TAM ON TICKET.AIRLINESID = TAM.AirlinesId    

    WHERE REGISTATION_NUMBER = @REGISTRATION_NO    

   ) TICKET_DETAILS     

   JOIN TBL_CITY_MASTER TCM_DEPT ON TICKET_DETAILS.DEP_CITYCODE = TCM_DEPT.CITY_CODE    

   JOIN TBL_CITY_MASTER TCM_DEST ON TICKET_DETAILS.DEST_CITYCODE = TCM_DEST.CITY_CODE    

       

   --SECTION 5 INDUSTRY DETAILS    

 SELECT TUE.REGISTRATION_NO,TIM.INDUSTRY_TYPE,TDM.DESIGNATION_NAME    

 FROM TBL_USER_EXPERIENCE TUE WITH(NOLOCK)    

 JOIN TBL_INDUSTRY_MASTER TIM WITH(NOLOCK) ON TUE.INDUSTRY_ID=TIM.INDUSTRY_ID    

 JOIN TBL_DESIGNATION_MASTER TDM WITH (NOLOCK) ON TUE.DESIGNATION_ID=TDM.DESIGNATION_ID    

 WHERE TUE.REGISTRATION_NO = @REGISTRATION_NO    

   

   

   --SECTION 6 INTERVIEW DETAILS

   SELECT CASE WHEN TUD.STATUS_ID = 6 OR TUD.STATUS_ID > 7 THEN 'SELECTED' ELSE STATUS_NAME END INTERVIEWSTATUS,

 Convert(varchar(12),INTERVIEWDATE,103)INTERVIEWDATE,REQUIREMENT, INTERVIEWID ,TIMM.INTERVIEW_MODE

 FROM TBL_USER_DETAILS  TUD

 JOIN TBL_STATUS_MASTER TSM ON TUD.STATUS_ID = TSM.STATUS_ID

 JOIN 

 (

	SELECT REQUIREMENT_ID ,(ISNULL(TCM.COMPANY_NAME,CLIENT.NAME) + ' | ' + ISNULL(TRD.JOB_TITLE,''))REQUIREMENT

	FROM TBL_REQUIREMENT_DETAILS TRD WITH (NOLOCK)

	LEFT JOIN TBL_COMPANY_MASTER TCM WITH(NOLOCK) ON TCM.COMPANY_ID=TRD.COMPANY_ID

	LEFT JOIN 

	(

		SELECT TUD.REGISTRATION_NO,(ISNULL(TUPD.FIRST_NAME,'') +' ' + ISNULL(TUPD.MIDDLE_NAME,'') +' '+ ISNULL(TUPD.LAST_NAME,''))NAME 

		FROM TBL_USER_DETAILS TUD WITH(NOLOCK) 

		JOIN TBL_USER_PERSONAL_DETAILS TUPD WITH(NOLOCK) ON TUD.REGISTRATION_NO=TUPD.REGISTRATION_NO

		WHERE TUD.USER_TYPE_ID = 5

	)CLIENT ON TRD.CONTACT_PERSON = CLIENT.REGISTRATION_NO

	WHERE TRD.IS_ACTIVE=1

 ) TRD ON TUD.REQUIREMENT_ID= TRD.REQUIREMENT_ID

 JOIN TBL_INTERVIEW TI ON TRD.REQUIREMENT_ID = TI.REQUIREMENTID

 JOIN TBL_INTERVIEW_MODE_MASTER TIMM ON TI.InterviewModeId = TIMM.INTERVIEW_MODE_ID

 WHERE TUD.REGISTRATION_NO = @REGISTRATION_NO   

    

END

GO
/****** Object:  StoredProcedure [dbo].[PROC_CERTIFICATION_MASTER]    Script Date: 27-Jan-17 1:15:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
  
CREATE PROC [dbo].[PROC_CERTIFICATION_MASTER]  
(  
@CONDITIONAL_OPERATOR VARCHAR(100) = 'SaveCERTIFICATIONMaster',  
@CERTIFICATION VARCHAR(70) = 'DADDY',  
@CREATED_BY varchar (20) =NULL  
)  
AS   
BEGIN  
  
 IF @CONDITIONAL_OPERATOR='SaveCERTIFICATIONMaster'                 
 BEGIN    
 Insert into TBL_CERTIFICATION_MASTER(CERTIFICATION_NAME,IS_ACTIVE,CREATED_BY,CREATED_DATE)  
 VALUES(@CERTIFICATION,1,@CREATED_BY,GETDATE())  
  
 SELECT @@IDENTITY  
 END  
   
END

  

GO
/****** Object:  StoredProcedure [dbo].[PROC_COMPANY_MASTER]    Script Date: 27-Jan-17 1:15:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[PROC_COMPANY_MASTER]
(
@COMPANY_ID INT = NULL,
@CONDITIONAL_OPERATOR VARCHAR(100) = 'SaveCompanyMaster',
@COMPANY_NAME VARCHAR(70) = 'DADDY',
@CONTACT_PERSON varchar	(70) =NULL,
@CREATED_BY varchar	(20) =NULL
)
AS 
BEGIN

 IF @CONDITIONAL_OPERATOR='SaveCompanyMaster'               
 BEGIN  
	Insert into tbl_company_master(COMPANY_NAME,CONTACT_PERSON,CREATED_BY,CREATED_DATE)
	VALUES(@COMPANY_NAME,@CONTACT_PERSON,@CREATED_BY,GETDATE())

	SELECT @@IDENTITY
 END

 IF @CONDITIONAL_OPERATOR='DELETE_COMPANY'               
 BEGIN  
	UPDATE TBL_COMPANY_MASTER SET IS_ACTIVE=0 WHERE COMPANY_ID=@COMPANY_ID
 END
END



GO
/****** Object:  StoredProcedure [dbo].[PROC_FETCH_ALL_MASTERS]    Script Date: 27-Jan-17 1:15:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
  
CREATE PROC [dbo].[PROC_FETCH_ALL_MASTERS]  
AS   
  
BEGIN  
 ---COUNTRY_STATE_CITY_MASTER  
 SELECT TCM.CITY_CODE,TCM.CITY_NAME,TSM.STATE_CODE,TSM.STATE_NAME,TCUM.COUNTRY_CODE,TCUM.COUNTRY_NAME                                         
 FROM TBL_CITY_MASTER TCM WITH (NOLOCK)                                        
 LEFT JOIN TBL_STATE_MASTER TSM WITH (NOLOCK) ON TCM.STATE_CODE = TSM.STATE_CODE                                        
 LEFT JOIN TBL_COUNTRY_MASTER TCUM WITH (NOLOCK)   
 ON TSM.COUNTRY_CODE = TCUM.COUNTRY_CODE        
 WHERE TCM.IS_ACTIVE =1 AND TSM.IS_ACTIVE =1 AND TCUM.IS_ACTIVE =1  
 ORDER BY TCUM.COUNTRY_NAME,TSM.STATE_NAME,TCM.CITY_NAME    
  
 -- AVAILINGTYPE  
 SELECT AVAILING_TYPE_ID,AVAILING_TYPE,TYPE_ORDER,IS_ACTIVE                                        
 FROM TBL_AVAILING_TYPE_MASTER WITH (NOLOCK)     
 WHERE IS_ACTIVE =1                                       
 ORDER BY AVAILING_TYPE     
  
 -- SOURCE  
 SELECT SOURCE_ID,SOURCE_NAME,SOURCE_ORDER                                        
 FROM TBL_SOURCE_MASTER WITH (NOLOCK)     
 WHERE IS_ACTIVE =1                                 
 ORDER BY SOURCE_NAME   
  
 --STATUS  
 SELECT STATUS_ID,STATUS_NAME,DESCRIPTION,STATUS_ORDER                                        
 FROM TBL_STATUS_MASTER WITH (NOLOCK) WHERE IS_ACTIVE =1                                       
 ORDER BY STATUS_NAME     
  
 --REQUIREMENT  
 SELECT TRD.REQUIREMENT_ID,TCM.COMPANY_NAME         
 FROM TBL_REQUIREMENT_DETAILS TRD WITH (NOLOCK)                    
 JOIN TBL_COMPANY_MASTER TCM WITH (NOLOCK) ON TRD.COMPANY_ID=TCM.COMPANY_ID    
 WHERE TCM.IS_ACTIVE =1                    
 ORDER BY TCM.COMPANY_NAME  
  
 ---VISATYPE  
 SELECT VISA_ID,VISA_NUMBER                                        
 FROM TBL_VISA_MASTER WITH (NOLOCK)  
  
 --MARITALSTATUS  
 SELECT MARITAL_STATUS_ID,MARITAL_STATUS,MARITAL_STATUS_ORDER                                        
 FROM TBL_MARITAL_STATUS_MASTER WITH (NOLOCK)    
 WHERE IS_ACTIVE =1 ORDER BY MARITAL_STATUS     
  
 -- NATIONALITY  
 SELECT NATIONALITY_ID,NATIONALITY                                        
 FROM TBL_NATIONALITY_MASTER WITH (NOLOCK)        
 ORDER BY NATIONALITY   
  
 -- LOCATION  
  SELECT CITY_CODE,CITY_NAME FROM TBL_CITY_MASTER WITH (NOLOCK)    
  WHERE IS_ACTIVE =1 ORDER BY CITY_NAME    
    
 -- RELIGION  
 SELECT RELIGION_ID,RELIGION_NAME        
 FROM TBL_RELIGION_MASTER WITH (NOLOCK)      
 WHERE IS_ACTIVE =1 ORDER BY RELIGION_NAME   
  
 --- LANGUAGE  
  SELECT LANGUAGE_ID,LANGUAGE_NAME FROM TBL_LANGUAGE_MASTER WITH (NOLOCK)     
 WHERE  IS_ACTIVE =1 ORDER BY LANGUAGE_NAME    
  
 -- ADDRERSSTYPE  
  SELECT ADDRESS_TYPE_ID,ADDRESS_TYPE,TYPE_FOR                                        
  FROM TBL_ADDRESS_TYPE_MASTER WITH (NOLOCK)    
  WHERE IS_ACTIVE =1 ORDER BY ADDRESS_TYPE   
    
 -- UNIVERSITY  
 SELECT UNIVERSITY_ID,UNIVERSITY_NAME                                        
 FROM TBL_UNIVERSITY_MASTER WITH (NOLOCK)      
 WHERE IS_ACTIVE =1   
  
 -- COMPANY  
SELECT COMPANY_NAME,COMPANY_ID FROM (
SELECT COMPANY_NAME,COMPANY_ID, ROW_NUMBER() OVER (PARTITION BY COMPANY_NAME order by COMPANY_NAME)ROW_1        
FROM TBL_COMPANY_MASTER WITH (NOLOCK)    
WHERE IS_ACTIVE =1 
)Z WHERE ROW_1 =1 ORDER BY COMPANY_NAME   

  
 --DESIGNATION  
 SELECT DESIGNATION_ID,DESIGNATION_NAME, TRT.INDUSTRY_ID,TRT.INDUSTRY_TYPE            
 FROM TBL_DESIGNATION_MASTER TDM WITH (NOLOCK)                     
 JOIN TBL_INDUSTRY_MASTER TRT WITH (NOLOCK) ON TDM.INDUSTRY_ID=TRT.INDUSTRY_ID     
 WHERE TDM.IS_ACTIVE =1                                
 ORDER BY TRT.INDUSTRY_TYPE,DESIGNATION_NAME    
  
 -- INDUSTRY  
 SELECT INDUSTRY_ID,INDUSTRY_TYPE                                        
 FROM TBL_INDUSTRY_MASTER WITH (NOLOCK)    
 WHERE IS_ACTIVE =1                                        
 ORDER BY INDUSTRY_TYPE  
  
 -- EDUCATION  
 SELECT TEM.EDUCATION_TYPE_ID,TEM.EDUCATION_TYPE,TSM.SPECIALIZATION_TYPE,TSM.SPECIALIZATION_ID              
 FROM TBL_EDUCATION_TYPE_MASTER TEM WITH (NOLOCK)              
 JOIN TBL_SPECIALIZATION_MASTER TSM WITH (NOLOCK) ON TEM.EDUCATION_TYPE_ID = TSM.EDUCATION_TYPE_ID                  
 WHERE TEM.IS_ACTIVE =1 ORDER BY EDUCATION_TYPE,TSM.SPECIALIZATION_TYPE   
  
 --SPECIALIZATION  
 SELECT SPECIALIZATION_ID,SPECIALIZATION_TYPE                 
 FROM TBL_SPECIALIZATION_MASTER WITH (NOLOCK)      
 WHERE IS_ACTIVE =1 ORDER BY SPECIALIZATION_TYPE  
  
 -- VEHICLE_TYPE  
 SELECT VEHICLE_TYPE_ID,VEHICLE_TYPE                                  
 FROM TBL_VEHICLE_TYPE WITH (NOLOCK)   
 WHERE IS_ACTIVE =1 ORDER BY VEHICLE_TYPE   
  
 --- CERTIFICATION              
 SELECT CERTIFICATION_ID,CERTIFICATION_NAME        
 FROM TBL_CERTIFICATION_MASTER WITH (NOLOCK)                                        
 WHERE IS_ACTIVE=1 ORDER BY CERTIFICATION_NAME   
  
END

GO
/****** Object:  StoredProcedure [dbo].[PROC_GET_ADVERTISEMENT_DATA]    Script Date: 27-Jan-17 1:15:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,Rohan>
-- Create date: <Create Date,30/12/2016>
-- Description:	<Description,to get advertisement data>
-- =============================================
CREATE PROCEDURE [dbo].[PROC_GET_ADVERTISEMENT_DATA] 
@ADVERTISEMENT_ID int =19
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT advertisement.ADV_ID,advertisement.PAPER_NAME,
		   advertisement.AD_AGENCY_NAME,advertisement.EXPENSES,
		   advertisement.REQUIREMENT_ID,advertisement.ADV_DATE,
		   advertisement.FILE_PATH,
		   requirement.REQUIREMENT
	from TBL_ADVERTISEMENT_MASTER advertisement
	Join 
	(
	SELECT REQUIREMENT_ID ,(ISNULL(TCM.COMPANY_NAME,CLIENT.NAME) + ' | ' + ISNULL(TRD.JOB_TITLE,''))REQUIREMENT
	FROM TBL_REQUIREMENT_DETAILS TRD WITH (NOLOCK)
	LEFT JOIN TBL_COMPANY_MASTER TCM WITH(NOLOCK) ON TCM.COMPANY_ID=TRD.COMPANY_ID
	LEFT JOIN 
	(
		SELECT TUD.REGISTRATION_NO,(ISNULL(TUPD.FIRST_NAME,'') +' ' + ISNULL(TUPD.MIDDLE_NAME,'') +' '+ ISNULL(TUPD.LAST_NAME,''))NAME 
		FROM TBL_USER_DETAILS TUD WITH(NOLOCK) 
		JOIN TBL_USER_PERSONAL_DETAILS TUPD WITH(NOLOCK) ON TUD.REGISTRATION_NO=TUPD.REGISTRATION_NO
		WHERE TUD.USER_TYPE_ID = 5
	)CLIENT ON TRD.CONTACT_PERSON = CLIENT.REGISTRATION_NO
	WHERE TRD.IS_ACTIVE=1

	) requirement on advertisement.REQUIREMENT_ID = requirement.REQUIREMENT_ID
	where advertisement.IS_ACTIVE = 1 AND (advertisement.ADV_ID = @ADVERTISEMENT_ID or ISNULL(@ADVERTISEMENT_ID,'') ='')
END

GO
/****** Object:  StoredProcedure [dbo].[PROC_GET_CANDIDATE_NAME_BASED_ON_PASPPORT_NO]    Script Date: 27-Jan-17 1:15:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PROC_GET_CANDIDATE_NAME_BASED_ON_PASPPORT_NO]
	-- Add the parameters for the stored procedure here
	@USER_REQUIREMENT_ID INT = 64
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT (personalDetails.FIRST_NAME + ' ' + personalDetails.LAST_NAME) CandidateName 
	from TBL_USER_PERSONAL_DETAILS personalDetails
	join TBL_USER_REQUIREMENT REQ on personalDetails.REGISTRATION_NO = REQ.REGISTRATION_NO
	where REQ.USER_REQUIREMENT_ID = @USER_REQUIREMENT_ID 

END
GO
/****** Object:  StoredProcedure [dbo].[PROC_GET_CERTIFICATION_DETAILS]    Script Date: 27-Jan-17 1:15:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,Rohan>
-- Create date: <Create Date,17/01/2017>
-- Description:	<Description,to fetch certification details>
-- =============================================
create PROCEDURE [dbo].[PROC_GET_CERTIFICATION_DETAILS] 
	-- Add the parameters for the stored procedure here
	@REGISTRATION_NO varchar(20) = null
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	SELECT TUC.REGISTRATION_NUMBER,TCM.CERTIFICATION_NAME as CERTIFICATION,TUC.CERTIFICATION_LEVEL,   
	TUC.INSTITUTE, TUC.YEAR_OF_PASSING,
	TUC.USER_CERTIFICATION_ID,
	TUC.CERTIFICATION as CERTIFICATION_ID
	FROM TBL_USER_CERTIFICATION TUC WITH (NOLOCK)    
	JOIN TBL_CERTIFICATION_MASTER TCM WITH (NOLOCK)ON TUC.CERTIFICATION = TCM.CERTIFICATION_ID    
	WHERE REGISTRATION_NUMBER = @REGISTRATION_NO
END

GO
/****** Object:  StoredProcedure [dbo].[PROC_GET_EDIT_DETAILS_BY_REQUIREMENT_ID]    Script Date: 27-Jan-17 1:15:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[PROC_GET_EDIT_DETAILS_BY_REQUIREMENT_ID] 
(
@REQUIREMENT_ID int=0
)
AS
BEGIN

;WITH REQUIREMENT_CTE AS
(SELECT TRD.REQUIREMENT_ID,TEL.LANGUAGE_ID,ISNULL(TEL.CAN_READ,0) CAN_READ,ISNULL(TEL.CAN_WRITE,0) CAN_WRITE,ISNULL(TEL.CAN_SPEAK,0) CAN_SPEAK,TRE.EDUCATION_TYPE_ID,TRG.GENDER,ALLOW.FOOD,ALLOW.HOUSE,ALLOW.MEDICAL,ALLOW.TRAVEL,
TRR.RELIGION_ID,TRDES.DESIGNATION_ID,TRI.INDUSTRY_ID,TRS.SPECIALIZATION_ID,TRC.CERTIFICATION_ID,
TRD.AGE_FROM,TRD.AGE_TO,TRD.BASIC_SALARY_RANGE_FROM,TRD.BASIC_SALARY_RANGE_TO,TRD.COMPANY_ID,TRD.CONTACT_PERSON,
TRD.CONTACT_PERIOD,TRD.CURRENCY_TYPE_ID,TRD.EXPERIENCE_FROM,TRD.EXPERIENCE_TO,TRD.INTERVIEW_MODE_ID,TRD.IS_ACTIVE,
TRD.JOB_DESCRIPTION,TRD.JOB_TITLE,TRD.LEAVES_PER_YEAR,TRD.NO_OF_OPENINGS,TRD.OVERTIME,TRD.WORKING_HOURS,
TRD.POSTING_PLACE,TRD.REMARK,TRD.TRIP_PER_YEAR,
TRALL.ALLOWANCE_ID,TRALL.ALLOWANCE_TYPE_ID FROM TBL_REQUIREMENT_DETAILS TRD
LEFT JOIN
TBL_REQUIREMENT_LANGUAGE TEL on TRD.REQUIREMENT_ID=TEL.REQUIRMENT_ID
LEFT JOIN
TBL_REQUIRMENT_EDUCATION_TYPE TRE on TRD.REQUIREMENT_ID=TRE.REQUIREMENT_ID
LEFT JOIN
TBL_REQUIREMENT_GENDER TRG on TRD.REQUIREMENT_ID=TRG.REQUIREMENT_ID
LEFT JOIN 
(
SELECT REQUIRMENT_ID,[HOUSE],[FOOD],[MEDICAL],[TRAVEL] FROM   
(  
SELECT ALLOWANCE_AMOUNT,ALLOWANCE_TYPE,REQUIRMENT_ID  FROM TBL_REQUIREMENT_ALLOWANCE TRA   
JOIN TBL_ALLOWANCE_TYPE_MASTER TATM ON TRA.ALLOWANCE_TYPE_ID = TATM.ALLOWANCE_TYPE_ID  
) PIV PIVOT  
(  
SUM(ALLOWANCE_AMOUNT) FOR ALLOWANCE_TYPE IN ([HOUSE],[FOOD],[MEDICAL],[TRAVEL])  
)ALLOWANCE  
)ALLOW on TRD.REQUIREMENT_ID= ALLOW.REQUIRMENT_ID
LEFT JOIN
TBL_REQUIREMENT_RELIGION TRR on TRD.REQUIREMENT_ID=TRR.REQUIREMENT_ID
LEFT JOIN
TBL_REQUIRMENT_DESIGNATION TRDES on TRD.REQUIREMENT_ID=TRDES.REQUIREMENT_ID
LEFT JOIN
TBL_REQUIRMENT_INDUSTRY TRI on TRD.REQUIREMENT_ID=TRI.REQUIREMENT_ID
LEFT JOIN
TBL_REQUIRMENT_SPECIALIZATION TRS on TRD.REQUIREMENT_ID=TRS.REQUIREMENT_ID
LEFT JOIN
TBL_REQUIRMENT_CERTIFICATION TRC on TRD.REQUIREMENT_ID=TRC.REQUIREMENT_ID
LEFT JOIN 
TBL_REQUIREMENT_ALLOWANCE TRALL on TRD.REQUIREMENT_ID=TRALL.REQUIRMENT_ID
) 

SELECT DISTINCT t1.REQUIREMENT_ID,
		 STUFF((SELECT DISTINCT '|'+CAST(t2.LANGUAGE_ID AS VARCHAR)+','+CAST(t2.CAN_READ AS VARCHAR)+','+CAST(t2.CAN_WRITE AS VARCHAR)+','+CAST(t2.CAN_SPEAK AS VARCHAR)  LANGUAGE_ID
					FROM REQUIREMENT_CTE t2
					WHERE t1.REQUIREMENT_ID= t2.REQUIREMENT_ID
				FOR XML PATH(''), TYPE)
				.value('.', 'NVARCHAR(MAX)'
			  ) ,1,1,'') 
		LANGUAGE_ID,
		STUFF((SELECT DISTINCT '|'+CAST(t2.EDUCATION_TYPE_ID AS VARCHAR) EDUCATION_TYPE_ID
					FROM REQUIREMENT_CTE t2
					WHERE t1.REQUIREMENT_ID= t2.REQUIREMENT_ID
				FOR XML PATH(''), TYPE)
				.value('.', 'NVARCHAR(MAX)'
			  ) ,1,1,'') 
		EDUCATION_TYPE_ID,
		STUFF((SELECT DISTINCT '|'+CAST(t2.GENDER AS VARCHAR) GENDER_CODES
					FROM REQUIREMENT_CTE t2
					WHERE t1.REQUIREMENT_ID= t2.REQUIREMENT_ID
				FOR XML PATH(''), TYPE)
				.value('.', 'NVARCHAR(MAX)'
			  ) ,1,1,'') 
		GENDER_CODES,
			STUFF((SELECT DISTINCT '|'+CAST(t2.RELIGION_ID AS VARCHAR) RELIGION_ID
					FROM REQUIREMENT_CTE t2
					WHERE t1.REQUIREMENT_ID= t2.REQUIREMENT_ID
				FOR XML PATH(''), TYPE)
				.value('.', 'NVARCHAR(MAX)'
			  ) ,1,1,'') 
		RELIGION_ID,
		STUFF((SELECT DISTINCT '|'+CAST(t2.DESIGNATION_ID AS VARCHAR) DESIGNATION_ID
					FROM REQUIREMENT_CTE t2
					WHERE t1.REQUIREMENT_ID= t2.REQUIREMENT_ID
				FOR XML PATH(''), TYPE)
				.value('.', 'NVARCHAR(MAX)'
			  ) ,1,1,'') 
		DESIGNATION_ID,
		STUFF((SELECT DISTINCT '|'+CAST(t2.INDUSTRY_ID AS VARCHAR) INDUSTRY_ID
					FROM REQUIREMENT_CTE t2
					WHERE t1.REQUIREMENT_ID= t2.REQUIREMENT_ID
				FOR XML PATH(''), TYPE)
				.value('.', 'NVARCHAR(MAX)'
			  ) ,1,1,'') 
		INDUSTRY_ID,
		STUFF((SELECT DISTINCT '|'+CAST(t2.SPECIALIZATION_ID AS VARCHAR) SPECIALIZATION_ID
					FROM REQUIREMENT_CTE t2
					WHERE t1.REQUIREMENT_ID= t2.REQUIREMENT_ID
				FOR XML PATH(''), TYPE)
				.value('.', 'NVARCHAR(MAX)'
			  ) ,1,1,'') 
		SPECIALIZATION_ID,	
		STUFF((SELECT DISTINCT '|'+CAST(t2.CERTIFICATION_ID AS VARCHAR) CERTIFICATION_ID
					FROM REQUIREMENT_CTE t2
					WHERE t1.REQUIREMENT_ID= t2.REQUIREMENT_ID
				FOR XML PATH(''), TYPE)
				.value('.', 'NVARCHAR(MAX)'
			  ) ,1,1,'') 
		CERTIFICATION_ID,t1.AGE_FROM,t1.AGE_TO,t1.BASIC_SALARY_RANGE_FROM,t1.BASIC_SALARY_RANGE_TO,t1.COMPANY_ID,t1.CONTACT_PERSON,
t1.CONTACT_PERIOD,t1.CURRENCY_TYPE_ID,t1.EXPERIENCE_FROM,t1.EXPERIENCE_TO,t1.INTERVIEW_MODE_ID,t1.IS_ACTIVE,
t1.JOB_DESCRIPTION,t1.JOB_TITLE,t1.LEAVES_PER_YEAR,t1.NO_OF_OPENINGS,t1.OVERTIME,t1.POSTING_PLACE,	
t1.WORKING_HOURS,t1.REMARK,t1.TRIP_PER_YEAR,			
		STUFF((SELECT DISTINCT '|'+CAST(t2.ALLOWANCE_ID AS VARCHAR)+','+CAST(t2.ALLOWANCE_TYPE_ID AS VARCHAR) ALLOWANCE_ID
					FROM REQUIREMENT_CTE t2
					WHERE t1.REQUIREMENT_ID= t2.REQUIREMENT_ID
				FOR XML PATH(''), TYPE)
				.value('.', 'NVARCHAR(MAX)'
			  ) ,1,1,'') 
		ALLOWANCE_ID,
		t1.FOOD,t1.HOUSE,t1.MEDICAL,t1.TRAVEL
		
	FROM REQUIREMENT_CTE t1 
	WHERE t1.REQUIREMENT_ID=@REQUIREMENT_ID
	
	END
GO
/****** Object:  StoredProcedure [dbo].[PROC_GET_EDUCATION_DETAILS]    Script Date: 27-Jan-17 1:15:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,Rohan>
-- Create date: <Create Date,17/01/2017>
-- Description:	<Description,Get education details>
-- =============================================
create PROCEDURE [dbo].[PROC_GET_EDUCATION_DETAILS] 
	-- Add the parameters for the stored procedure here
	@REGISTRATION_NO varchar(20) = null
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT EDUCATION_TYPE,SPECIALIZATION_TYPE,TUED.UNIVERSITY_ID AS UNIVERSITY_NAME,REGISTRATION_NO,    
	UNIVERSITY_YEAR_OF_PASSING,TUED.EDUCATION_TYPE_ID,TUED.USER_EDUCATION_ID,TUED.SPECIALIZATION_TYPE_ID,TUED.IS_HIGHEST_QUALIFICATION
	FROM TBL_USER_EDUCATION_DETAILS TUED WITH (NOLOCK) 
	JOIN TBL_EDUCATION_TYPE_MASTER TETM WITH (NOLOCK)ON TUED.EDUCATION_TYPE_ID = TETM.EDUCATION_TYPE_ID    
	JOIN TBL_SPECIALIZATION_MASTER TSM WITH (NOLOCK)ON TUED.SPECIALIZATION_TYPE_ID = TSM.SPECIALIZATION_ID 
	WHERE REGISTRATION_NO = @REGISTRATION_NO

END

GO
/****** Object:  StoredProcedure [dbo].[PROC_GET_LAYOUT_MENU]    Script Date: 27-Jan-17 1:15:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[PROC_GET_LAYOUT_MENU]
@USER_TYPE_ID varchar(20) = NULL
AS
BEGIN                      
SELECT DISTINCT TLM.LMS_MENU_ID MENU_ID, TLM.PARENT_MENU_ID, TLM.MENU_NAME, TLM.MENU_TITLE,   
TLM.MENU_URL,10 CHANNEL_USER_TYPE_ID, TLM.PAGE_NAME, TLM.CONTROLLER_NAME, TLM.REMARK, '' CHANNEL_CODE,TLM.MENU_ICON AS MENU_ICON,
 TLM.CONTROLLER_NAME +'/'+TLM.PAGE_NAME AS PAGE_URL, ''   AS 'PARENT_MENU_NAME',TLM.IS_PARENT       
FROM  TBL_LMS_MENU TLM  
JOIN TBL_USER_MENU_MAPPING TUMM ON TLM.LMS_MENU_ID = TUMM.MENU_ID  
WHERE REGISTRATION_NUMBER =@USER_TYPE_ID
UNION   
SELECT DISTINCT TLM.LMS_MENU_ID MENU_ID, TLM.PARENT_MENU_ID, TLM.MENU_NAME, TLM.MENU_TITLE,   
TLM.MENU_URL,10 CHANNEL_USER_TYPE_ID, TLM.PAGE_NAME, TLM.CONTROLLER_NAME, TLM.REMARK, '' CHANNEL_CODE,TLM.MENU_ICON AS MENU_ICON,
TLM.CONTROLLER_NAME +'/'+TLM.PAGE_NAME AS PAGE_URL,   '' AS 'PARENT_MENU_NAME' ,TLM.IS_PARENT          
FROM  TBL_LMS_MENU TLUM  
JOIN TBL_LMS_MENU TLM ON TLUM.PARENT_MENU_ID = TLM.LMS_MENU_ID  
JOIN TBL_USER_MENU_MAPPING TUMM ON TLUM.LMS_MENU_ID = TUMM.MENU_ID  
WHERE REGISTRATION_NUMBER =@USER_TYPE_ID      
  
END

GO
/****** Object:  StoredProcedure [dbo].[PROC_GET_MENU_BY_SELECTED_USER]    Script Date: 27-Jan-17 1:15:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[PROC_GET_MENU_BY_SELECTED_USER]
@USER_TYPE_ID varchar(20) = NULL
AS
BEGIN                              
                                
   SELECT * FROM                               
   (                              
   SELECT DISTINCT(TLM.LMS_MENU_ID) as 'MENU_ID',TLM.MENU_NAME,TLM.MENU_TITLE,TLM.MENU_URL, TLM.CONTROLLER_NAME +'/'+TLM.PAGE_NAME AS PAGE_URL, TLM.IS_PARENT,TLM.REMARK,                              
   CASE WHEN TLM.IS_PARENT = 1 THEN TLM.MENU_NAME                              
   ELSE TL_1.MENU_NAME END  PARENT_MENU, TL_1.MENU_TITLE PARENT_MENU_TITLE,                              
   ISNULL(USER_TYPE_MENU.MENU_ID, 0) AS USER_TYPE_MENU_ID                    
   FROM TBL_LMS_MENU TLM WITH(NOLOCK)              
   LEFT JOIN TBL_LMS_MENU TL_1 WITH(NOLOCK) ON TLM.PARENT_MENU_ID = TL_1.LMS_MENU_ID                              
   LEFT JOIN                               
   (                              
  SELECT MENU_ID FROM TBL_USER_MENU_MAPPING WITH(NOLOCK) WHERE REGISTRATION_NUMBER = @USER_TYPE_ID -- 1                  
   )USER_TYPE_MENU ON TLM.LMS_MENU_ID = USER_TYPE_MENU.MENU_ID                    
   )A ORDER BY PARENT_MENU                          
  END
GO
/****** Object:  StoredProcedure [dbo].[PROC_GET_PASSPORT_DETAILS]    Script Date: 27-Jan-17 1:15:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[PROC_GET_PASSPORT_DETAILS] 
	-- Add the parameters for the stored procedure here
	@Status varchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT TUR.USER_REQUIREMENT_ID,(ISNULL(TPD.PASSPORT_NUMBER,'') +' | '+ ISNULL(TUPD.FIRST_NAME,'') +' ' + ISNULL(TUPD.MIDDLE_NAME,'') +' '+ ISNULL(TUPD.LAST_NAME,''))PASSPORT_NUMBER
	FROM TBL_USER_REQUIREMENT TUR WITH (NOLOCK)
	JOIN TBL_USER_DETAILS TUD WITH (NOLOCK) ON TUR.REGISTRATION_NO = TUD.REGISTRATION_NO
	JOIN TBL_USER_PERSONAL_DETAILS TUPD WITH (NOLOCK) ON TUD.REGISTRATION_NO = TUPD.REGISTRATION_NO                      
	JOIN TBL_PASSPORT_DETAILS TPD WITH(NOLOCK) ON TUD.REGISTRATION_NO = TPD.REGISTATION_NUMBER                      
	WHERE USER_TYPE_ID = 1 AND TPD.PASSPORT_NUMBER IS NOT NULL AND STATUS_ID in (select CAST(Item as INT) from Split(@Status,','))
END

GO
/****** Object:  StoredProcedure [dbo].[PROC_GET_PROCESS_DETAILS]    Script Date: 27-Jan-17 1:15:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[PROC_GET_PROCESS_DETAILS]    
(    
 @USER_REQUIREMENT_ID INT = null
)AS     
BEGIN 

	--Mofa Details
	select top 1 MOFA.MofaNumber,MOFA.MofaDate,MOFA.ApplicationNumber,MOFA.ApplicationDate,	MOFA.HealthNumber,MOFA.HealthDate,MOFA.DDDate,MOFA.DDNumber
	from TBL_MOFA MOFA
	where USER_REQUIREMENT_ID = @USER_REQUIREMENT_ID
	ORDER BY CreatedDate DESC

	--Medical Details
	select top 1 tbl_status.STATUS_NAME,tbl_medical.CheckupDate,(FIRST_NAME + ' ' + LAST_NAME)Doctor
	from TBL_MEDICAL tbl_medical
	Join TBL_STATUS_MASTER tbl_status on tbl_status.STATUS_ID = tbl_medical.MedicalStatus
	JOIN TBL_USER_PERSONAL_DETAILS TUPD ON tbl_medical.DoctorID =TUPD.REGISTRATION_NO
	where USER_REQUIREMENT_ID = @USER_REQUIREMENT_ID AND TUPD.IS_ACTIVE =1
	ORDER BY tbl_medical.CreatedDate DESC
	

	--Visa Endorsement
	select top 1 tbl_status.STATUS_NAME, tbl_visa_endorsement.SubmissionDate
	from TBL_VISA_ENDORSEMENT tbl_visa_endorsement
	join TBL_STATUS_MASTER tbl_status on tbl_status.STATUS_ID = tbl_visa_endorsement.SubmissionStatusID
	where USER_REQUIREMENT_ID = @USER_REQUIREMENT_ID
	ORDER BY tbl_visa_endorsement.CreatedDate DESC

	--Policy Details
	select top 1 tbl_policy.POLICYID, tbl_policy.PolicyDate,tbl_policy.Policy
	from TBL_POLICY tbl_policy
	where USER_REQUIREMENT_ID = @USER_REQUIREMENT_ID
	ORDER BY CreatedDate DESC
	
	--Travel Details
	select top 1 CASE WHEN tbl_ticket.IsBooked=1 THEN 'BOOKED' ELSE 'CANCELLED' end TRAVEL_STATUS,
	tbl_ticket.PnrNumber,tbl_ticket.DepartureDate,
	tbl_airlines.AirlinesName,tbl_city.CITY_NAME as DepartureCity,
	tbl_destination_city.CITY_NAME as DestinationCity,
	tbl_ticket.DepartureTime , 
	tbl_ticket.ArrivalTime
	from TBL_TICKET tbl_ticket
	join TBL_AIRLINES_MASTER tbl_airlines on tbl_airlines.AirlinesId = tbl_ticket.AirlinesID
	join TBL_CITY_MASTER tbl_city on tbl_city.CITY_CODE = tbl_ticket.DepartureCityCode
	join TBL_CITY_MASTER tbl_destination_city on tbl_destination_city.CITY_CODE = tbl_ticket.DestinationCityCode
	where USER_REQUIREMENT_ID = @USER_REQUIREMENT_ID
	ORDER BY tbl_ticket.CreatedDate DESC
END

GO
/****** Object:  StoredProcedure [dbo].[PROC_GET_REQUIREMENT]    Script Date: 27-Jan-17 1:15:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[PROC_GET_REQUIREMENT]
(
@RequirementId int =null
)
AS 
BEGIN
	SELECT REQUIREMENT_ID ,(ISNULL(TCM.COMPANY_NAME,CLIENT.NAME) + ' | ' + ISNULL(TRD.JOB_TITLE,''))REQUIREMENT
	FROM TBL_REQUIREMENT_DETAILS TRD WITH (NOLOCK)
	LEFT JOIN TBL_COMPANY_MASTER TCM WITH(NOLOCK) ON TCM.COMPANY_ID=TRD.COMPANY_ID
	LEFT JOIN 
	(
		SELECT TUD.REGISTRATION_NO,(ISNULL(TUPD.FIRST_NAME,'') +' ' + ISNULL(TUPD.MIDDLE_NAME,'') +' '+ ISNULL(TUPD.LAST_NAME,''))NAME 
		FROM TBL_USER_DETAILS TUD WITH(NOLOCK) 
		JOIN TBL_USER_PERSONAL_DETAILS TUPD WITH(NOLOCK) ON TUD.REGISTRATION_NO=TUPD.REGISTRATION_NO
		WHERE TUD.USER_TYPE_ID = 5
	)CLIENT ON TRD.CONTACT_PERSON = CLIENT.REGISTRATION_NO
	WHERE TRD.IS_ACTIVE=1  AND (TRD.REQUIREMENT_ID = @RequirementId or ISNULL(@RequirementId,'') ='')
END

GO
/****** Object:  StoredProcedure [dbo].[PROC_GETUSER_BYUSERTYPE]    Script Date: 27-Jan-17 1:15:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[PROC_GETUSER_BYUSERTYPE]
(
@USER_TYPE_ID INT =NULL
)
AS
BEGIN

	SELECT TUD.REGISTRATION_NO,(ISNULL(TUPD.FIRST_NAME,'') +' '+ISNULL(TUPD.LAST_NAME,''))NAME
	FROM TBL_USER_DETAILS TUD WITH (NOLOCK)                                        
	JOIN TBL_USER_PERSONAL_DETAILS TUPD WITH(NOLOCK) ON TUD.REGISTRATION_NO=TUPD.REGISTRATION_NO                       	WHERE TUPD.IS_ACTIVE=1 AND USER_TYPE_ID=@USER_TYPE_ID 

END
GO
/****** Object:  StoredProcedure [dbo].[PROC_INSERT_TICKET_DETAILS]    Script Date: 27-Jan-17 1:15:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,Rohan>
-- Create date: <Create Date,04/01/2017>
-- Description:	<Description,to insert record into ticket and connected ticket table>
-- =============================================
CREATE PROCEDURE [dbo].[PROC_INSERT_TICKET_DETAILS]
	-- Add the parameters for the stored procedure here
	@TicketDetails dbo.UDT_TICKET_DETAILS READONLY
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Declare @IsConnected bit
	Declare @TicketId int

	select @IsConnected = IsDirect from @TicketDetails

	Insert INTO TBL_TICKET
	(PassportId,AirlinesID,OtherAirlines,IsDirect,PnrNumber,TicketNumber,FlightNumber,IsBooked,IsCancelled,
	 DepartureCityCode,DepartureDate,DepartureTime,DestinationCityCode,ArivalDate,ArrivalTime,ReportPath,Remark,createdBy,CreatedDate)
	 Select PassportId,
			AirlinesID,
			OtherAirlines,
			IsDirect,
			PnrNumber,
			TicketNumber,
			FlightNumber,
			IsBooked,
			IsCancelled,
			DepartureCityCode,
			DepartureDate,
			DepartureTime,
			DestinationCityCode,
			ArivalDate,
			ArrivalTime,
			ReportPath,
			Remark,
			createdBy,
			GetDate()
	 from @TicketDetails

	 select @TicketId = SCOPE_IDENTITY()
	 if(@IsConnected = 0)
	 BEGIN
	 Insert INTO TBL_CONNECTED_TICKETDETAILS
	 (TicketID,PnrNumber,TicketNumber,FlightNumber,IsBooked,IsCancelled,DepartureCityCode,DepartureDate,DepartureTime,DestinationCityCode,ArrivalDate,ArrivalTime,CreatedBy,CreatedDate)
	 Select @TicketId,
			Conn_PnrNumber,
			Conn_TicketNumber,
			Conn_FlightNumber,
			Conn_IsBooked,
			Conn_IsCancelled,
			Conn_DepartureCityCode,
			Conn_DepartureDate,
			Conn_DepartureTime,
			Conn_DestinationCityCode,
			Conn_ArivalDate,
			Conn_ArrivalTime,
			Conn_createdBy,
			GETDATE()
	 from @TicketDetails

	 END
END


GO
/****** Object:  StoredProcedure [dbo].[PROC_INTERVIEW_STATUS]    Script Date: 27-Jan-17 1:15:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[PROC_INTERVIEW_STATUS] 
(
@REGISTRATION_NO VARCHAR(20)

)
as 
BEGIN

SELECT CASE WHEN TUD.STATUS_ID = 6 OR TUD.STATUS_ID > 7 THEN 'SELECTED' ELSE STATUS_NAME END INTERVIEWSTATUS,
 INTERVIEWDATE,CLIENT_NAME, InterviewID 
 FROM TBL_USER_DETAILS  TUD
 JOIN TBL_STATUS_MASTER TSM ON TUD.STATUS_ID = TSM.STATUS_ID
 JOIN (SELECT TRD.REQUIREMENT_ID, ISNULL(TCM.COMPANY_NAME,    
  ISNULL(TUPD.FIRST_NAME,'') + SPACE(1) + ISNULL(TUPD.MIDDLE_NAME,'') + SPACE(1)     
  + ISNULL(TUPD.LAST_NAME,''))CLIENT_NAME 
  FROM TBL_REQUIREMENT_DETAILS TRD    
  LEFT JOIN TBL_COMPANY_MASTER TCM ON TRD.COMPANY_ID = TCM.COMPANY_ID   
  LEFT JOIN TBL_USER_PERSONAL_DETAILS TUPD ON TRD.CONTACT_PERSON = TUPD.REGISTRATION_NO
  WHERE TRD.IS_ACTIVE =1 AND  STATUS_ID ='ACTIVE') TRD 
  ON TUD.REQUIREMENT_ID= TRD.REQUIREMENT_ID
 JOIN TBL_INTERVIEW TI ON TRD.REQUIREMENT_ID = TI.REQUIREMENTID
 WHERE TUD.REGISTRATION_NO = @REGISTRATION_NO
END



GO
/****** Object:  StoredProcedure [dbo].[PROC_MANAGE_USERS]    Script Date: 27-Jan-17 1:15:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
  
CREATE PROC [dbo].[PROC_MANAGE_USERS]  
(  
@CONDITIONAL_OPERATOR VARCHAR(30)= 'GETEMPLOYEES' ,
@REGISTRATION_NUMBER	VARCHAR(20) =NULL,
@IS_ACTIVE INT = NULL
)  
AS   
BEGIN   
 IF @CONDITIONAL_OPERATOR ='GETEMPLOYEES'  
  BEGIN  
  SELECT TUPD.REGISTRATION_NO,UPPER(  
  ISNULL(FIRST_NAME + SPACE(1),'') + ISNULL(MIDDLE_NAME + SPACE(1),'') +  
  ISNULL(LAST_NAME,'')) EMPLOYEE_NAME,IS_ACTIVE FROM TBL_USER_PERSONAL_DETAILS TUPD  
  JOIN TBL_USER_DETAILS TUD ON TUPD.REGISTRATION_NO = TUD.REGISTRATION_NO  
  WHERE  USER_TYPE_ID = 2  
  RETURN
 END   
 
 IF @CONDITIONAL_OPERATOR ='ACTIVE_INACTIVE'
	BEGIN
		UPDATE 	TBL_USER_PERSONAL_DETAILS SET IS_ACTIVE = @IS_ACTIVE
		WHERE REGISTRATION_NO = @REGISTRATION_NUMBER
		RETURN
	END
	
 IF @CONDITIONAL_OPERATOR ='SELECT_EMPLOYEE'
	BEGIN
		SELECT TUPD.REGISTRATION_NO,UPPER(  
		ISNULL(FIRST_NAME + SPACE(1),'') + ISNULL(MIDDLE_NAME + SPACE(1),'') +  
		ISNULL(LAST_NAME,'')) EMPLOYEE_NAME,IS_ACTIVE FROM TBL_USER_PERSONAL_DETAILS TUPD  
		JOIN TBL_USER_DETAILS TUD ON TUPD.REGISTRATION_NO = TUD.REGISTRATION_NO  
		WHERE  USER_TYPE_ID = 2 AND TUPD.REGISTRATION_NO = @REGISTRATION_NUMBER
		RETURN
	END

END 

GO
/****** Object:  StoredProcedure [dbo].[PROC_MENU]    Script Date: 27-Jan-17 1:15:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PROC_MENU]                            
 @LMS_MENU_ID INT = NULL,                            
 @MENU_NAME VARCHAR(30) = NULL,                            
 @MENU_TITLE VARCHAR(50) = NULL,                            
 @MENU_URL VARCHAR(100) = NULL,                            
 @PARENT_MENU_ID INT = NULL,                            
 @IS_PARENT BIT = NULL,                            
 @CREATED_BY VARCHAR(10) = NULL,                            
 @CREATED_DATE DATETIME = NULL,                            
 @REMARK VARCHAR(100) = NULL,                            
 @CONDITIONAL_OPERATOR VARCHAR(50) = 'Layout_Menu',                        
 @CHANNEL_CODE VARCHAR(20) = NULL,                
 @CHANNEL_USER_TYPE_ID INT = NULL,                    
 @MENU_ID INT = NULL,                  
 @USER_TYPE_ID varchar(20) = NULL,                
 @PAGE_NAME VARCHAR(50) = NULL,                
 @CONTROLLER_NAME VARCHAR(50) = NULL                
AS                            
BEGIN                            
 -- SET NOCOUNT ON added to prevent extra result sets from                            
 -- interfering with SELECT statements.                            
 SET NOCOUNT ON;                            
                            
 IF (@CONDITIONAL_OPERATOR = 'Get_MENU')                            
    BEGIN                            
    SELECT LM.LMS_MENU_ID AS MENU_ID, LM.MENU_NAME, LM.MENU_TITLE, LM.MENU_URL, LM.PAGE_NAME, LM.CONTROLLER_NAME, LM.CONTROLLER_NAME +'/'+LM.PAGE_NAME AS PAGE_URL, LM.IS_PARENT, LM.PARENT_MENU_ID, LM1.MENU_NAME AS 'PARENT_MENU_NAME', LM.REMARK            
  
    
      
        
          
            
              
               
    FROM TBL_LMS_MENU LM WITH(NOLOCK)              
    LEFT JOIN TBL_LMS_MENU LM1 WITH(NOLOCK) ON LM.PARENT_MENU_ID = LM1.LMS_MENU_ID                          
    WHERE (LM.IS_PARENT = @IS_PARENT OR @IS_PARENT ='')                          
    AND (LM.PARENT_MENU_ID = @PARENT_MENU_ID OR @PARENT_MENU_ID = '')                            
    AND (LM.LMS_MENU_ID = @LMS_MENU_ID OR @LMS_MENU_ID = '')                            
 END                            
                           
 IF (@CONDITIONAL_OPERATOR = 'Get_PARENT_MENU')                            
    BEGIN                            
    SELECT LM.LMS_MENU_ID AS MENU_ID, LM.MENU_NAME, LM.MENU_TITLE, LM.MENU_URL, LM.PAGE_NAME, LM.CONTROLLER_NAME, LM.CONTROLLER_NAME +'/'+LM.PAGE_NAME AS PAGE_URL,LM.IS_PARENT, LM.PARENT_MENU_ID, LM1.MENU_NAME AS 'PARENT_MENU_NAME', LM.REMARK             
  
    
      
        
          
            
              
    FROM TBL_LMS_MENU LM WITH(NOLOCK)              
    LEFT JOIN TBL_LMS_MENU LM1 WITH(NOLOCK) ON LM.PARENT_MENU_ID = LM1.LMS_MENU_ID                          
    WHERE (LM.IS_PARENT = @IS_PARENT OR @IS_PARENT ='')                          
    AND (LM.PARENT_MENU_ID IS NULL)                          
 END                            
                           
                             
 IF (@CONDITIONAL_OPERATOR = 'ADD_MENU')                            
    BEGIN                            
  SET NOCOUNT OFF;                            
                
  INSERT INTO TBL_LMS_MENU                            
  (MENU_NAME, MENU_TITLE, MENU_URL, PAGE_NAME, CONTROLLER_NAME, PARENT_MENU_ID,                             
  IS_PARENT, CREATED_BY, CREATED_DATE, REMARK)                            
  VALUES                            
  (@MENU_NAME, @MENU_TITLE, @MENU_URL, @PAGE_NAME, @CONTROLLER_NAME, @PARENT_MENU_ID,                             
  @IS_PARENT, @CREATED_BY, @CREATED_DATE, @REMARK)                            
                     
                     
  --This Condition if for Admin User (If Menu is added then it will directly assign to admin user)                
  IF EXISTS(SELECT MAX(LMS_MENU_ID) FROM TBL_LMS_MENU WHERE PARENT_MENU_ID IS NOT NULL)                
  BEGIN                
                
   SELECT @USER_TYPE_ID = 'ADMIN'              
       
   SELECT @MENU_ID = MAX(LMS_MENU_ID) FROM TBL_LMS_MENU WITH(NOLOCK)              
                   
   INSERT INTO TBL_USER_MENU_MAPPING (REGISTRATION_NUMBER, MENU_ID, CREATED_BY, CREATED_DATE)                
  VALUES (@USER_TYPE_ID, @MENU_ID, @CREATED_BY, @CREATED_DATE)                
                     
  END                    
                 
 END                
                             
 IF (@CONDITIONAL_OPERATOR = 'EDIT_MENU')           
    BEGIN                            
   SET NOCOUNT OFF;                            
   UPDATE TBL_LMS_MENU SET                          
MENU_NAME = @MENU_NAME,                        
   MENU_TITLE = @MENU_TITLE,                          
   --MENU_URL = @MENU_URL,                          
   REMARK = @REMARK,                
   PAGE_NAME = @PAGE_NAME,                
   CONTROLLER_NAME = @CONTROLLER_NAME                
   WHERE LMS_MENU_ID = @LMS_MENU_ID                          
  END                            
                           
IF (@CONDITIONAL_OPERATOR = 'Delete_MENU')                          
    BEGIN                            
    SET NOCOUNT OFF;              
                 
    DECLARE @CHILDCNT INT               
 SELECT @CHILDCNT = COUNT(*) FROM TBL_LMS_MENU WHERE PARENT_MENU_ID=@LMS_MENU_ID              
 IF @CHILDCNT > 0              
 BEGIN                
  RETURN              
 END              
                  
    DECLARE @CNT INT SET @CNT = 1              
 IF (@CNT = (SELECT count(*) FROM TBL_USER_MENU_MAPPING WHERE MENU_ID = @LMS_MENU_ID))                   
 BEGIN              
     DELETE FROM TBL_USER_MENU_MAPPING WHERE MENU_ID = @LMS_MENU_ID              
     DELETE FROM TBL_LMS_MENU WHERE LMS_MENU_ID = @LMS_MENU_ID              
 END              
 ELSE              
  RETURN              
 END                          
                        
IF @CONDITIONAL_OPERATOR ='GET_USER_MENU'                        
  BEGIN                              
                                
   SELECT * FROM                               
   (                              
   SELECT DISTINCT(TLM.LMS_MENU_ID) as 'MENU_ID',TLM.MENU_NAME,TLM.MENU_TITLE,TLM.MENU_URL, TLM.CONTROLLER_NAME +'/'+TLM.PAGE_NAME AS PAGE_URL, TLM.IS_PARENT,TLM.REMARK,                              
   CASE WHEN TLM.IS_PARENT = 1 THEN TLM.MENU_NAME                              
   ELSE TL_1.MENU_NAME END  PARENT_MENU, TL_1.MENU_TITLE PARENT_MENU_TITLE,                              
   ISNULL(USER_TYPE_MENU.MENU_ID, 0) AS USER_TYPE_MENU_ID                    
   FROM TBL_LMS_MENU TLM WITH(NOLOCK)              
   LEFT JOIN TBL_LMS_MENU TL_1 WITH(NOLOCK) ON TLM.PARENT_MENU_ID = TL_1.LMS_MENU_ID                              
   LEFT JOIN                               
   (                              
  SELECT MENU_ID FROM TBL_USER_MENU_MAPPING WITH(NOLOCK) WHERE REGISTRATION_NUMBER = @USER_TYPE_ID -- 1                  
   )USER_TYPE_MENU ON TLM.LMS_MENU_ID = USER_TYPE_MENU.MENU_ID                    
   )A ORDER BY PARENT_MENU                          
  END                    
                    
                    
IF @CONDITIONAL_OPERATOR ='ADD_MENU_FOR_USERTYPE'                       
 BEGIN                      
  SET NOCOUNT OFF;                      
  IF NOT EXISTS (SELECT * from TBL_USER_MENU_MAPPING WITH(NOLOCK) WHERE MENU_ID=@MENU_ID AND REGISTRATION_NUMBER = @USER_TYPE_ID)                      
  BEGIN                      
   INSERT INTO TBL_USER_MENU_MAPPING                       
   (                      
   MENU_ID,                      
   REGISTRATION_NUMBER,                      
   CREATED_DATE,                      
   CREATED_BY                     
   )                      
   VALUES                      
   (                      
   @MENU_ID,                      
   @USER_TYPE_ID,                      
   GETDATE(),                      
   @CREATED_BY                     
   )                      
  END                      
 END                      
                       
 IF @CONDITIONAL_OPERATOR ='DEL_MENU_FOR_USERTYPE'                      
 BEGIN                      
 SET NOCOUNT OFF;                      
  DELETE FROM TBL_USER_MENU_MAPPING WHERE MENU_ID=@MENU_ID AND REGISTRATION_NUMBER = @USER_TYPE_ID                    
 END                      
                   
                   
                   
 -- To display menu in Layout Page                  
 IF @CONDITIONAL_OPERATOR = 'Layout_Menu'                  
 BEGIN                  
                   
                 
                   
 IF (@CHANNEL_USER_TYPE_ID is null)            
BEGIN            
SELECT DISTINCT TLM.LMS_MENU_ID MENU_ID, TLM.PARENT_MENU_ID, TLM.MENU_NAME, TLM.MENU_TITLE,   
TLM.MENU_URL,10 CHANNEL_USER_TYPE_ID, TLM.PAGE_NAME, TLM.CONTROLLER_NAME, TLM.REMARK, '' CHANNEL_CODE,TLM.MENU_ICON          
FROM  TBL_LMS_MENU TLM  
JOIN TBL_USER_MENU_MAPPING TUMM ON TLM.LMS_MENU_ID = TUMM.MENU_ID  
WHERE REGISTRATION_NUMBER =@USER_TYPE_ID  
UNION   
SELECT DISTINCT TLM.LMS_MENU_ID MENU_ID, TLM.PARENT_MENU_ID, TLM.MENU_NAME, TLM.MENU_TITLE,   
TLM.MENU_URL,10 CHANNEL_USER_TYPE_ID, TLM.PAGE_NAME, TLM.CONTROLLER_NAME, TLM.REMARK, '' CHANNEL_CODE,TLM.MENU_ICON          
FROM  TBL_LMS_MENU TLUM  
JOIN TBL_LMS_MENU TLM ON TLUM.PARENT_MENU_ID = TLM.LMS_MENU_ID  
JOIN TBL_USER_MENU_MAPPING TUMM ON TLUM.LMS_MENU_ID = TUMM.MENU_ID  
WHERE REGISTRATION_NUMBER =@USER_TYPE_ID        
  
END             
            
ELSE            
            
BEGIN                  
 ;WITH Menu AS                   
 (                  
 SELECT UMM.MENU_ID, LM.PARENT_MENU_ID, LM.MENU_NAME, LM.MENU_TITLE, LM.MENU_URL, LM.PAGE_NAME , LM.CONTROLLER_NAME, UMM.USER_TYPE_ID,         
 LM.REMARK,LM.MENU_ICON        
 FROM TBL_USER_MENU_MAPPING UMM              
 JOIN TBL_LMS_MENU LM ON UMM.MENU_ID = LM.LMS_MENU_ID                  
                  
 UNION ALL                  
                  
 SELECT tmp.LMS_MENU_ID, tmp.PARENT_MENU_ID, tmp.MENU_NAME, tmp.MENU_TITLE, tmp.MENU_URL, tmp.PAGE_NAME, tmp.CONTROLLER_NAME, Menu.USER_TYPE_ID, tmp.REMARK,TMP.MENU_ICON        
 FROM TBL_LMS_MENU tmp                  
   INNER JOIN Menu ON tmp.LMS_MENU_ID = Menu.PARENT_MENU_ID                  
 WHERE   Menu.MENU_ID<>Menu.PARENT_MENU_ID                  
 )                  
                   
 SELECT DISTINCT MENU_ID, PARENT_MENU_ID, MENU_NAME, MENU_TITLE, MENU_URL,USER_TYPE_ID, PAGE_NAME, CONTROLLER_NAME, REMARK ,MENU_ICON       
 FROM   Menu        
 WHERE USER_TYPE_ID = @USER_TYPE_ID              
END            
            
            
            
 END                  
                        
END 

GO
/****** Object:  StoredProcedure [dbo].[PROC_PEOPLE_MASTER]    Script Date: 27-Jan-17 1:15:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
                        
CREATE PROC [dbo].[PROC_PEOPLE_MASTER]
AS                                        
BEGIN

	SELECT TCM.CITY_CODE,TCM.CITY_NAME,TSM.STATE_CODE,TSM.STATE_NAME,TCUM.COUNTRY_CODE,TCUM.COUNTRY_NAME,tcm.IS_ACTIVE                                         
	FROM TBL_CITY_MASTER TCM WITH (NOLOCK)                                        
	LEFT JOIN TBL_STATE_MASTER TSM WITH (NOLOCK) ON TCM.STATE_CODE = TSM.STATE_CODE                                        
	LEFT JOIN TBL_COUNTRY_MASTER TCUM WITH (NOLOCK) ON TSM.COUNTRY_CODE = TCUM.COUNTRY_CODE        
	ORDER BY TCUM.COUNTRY_NAME,TSM.STATE_NAME,TCM.CITY_NAME

	SELECT ADDRESS_TYPE_ID CONTACT_TYPE_ID ,ADDRESS_TYPE CONTACT_TYPE,TYPE_FOR
	FROM TBL_ADDRESS_TYPE_MASTER WITH(NOLOCK)
	ORDER BY ADDRESS_TYPE

	SELECT DESIGNATION_ID,DESIGNATION_NAME, TRT.INDUSTRY_ID,TRT.INDUSTRY_TYPE      
	FROM TBL_DESIGNATION_MASTER TDM WITH (NOLOCK)               
	JOIN TBL_INDUSTRY_MASTER TRT WITH (NOLOCK) ON TDM.INDUSTRY_ID=TRT.INDUSTRY_ID
	ORDER BY TRT.INDUSTRY_TYPE,DESIGNATION_NAME
	
END
GO
/****** Object:  StoredProcedure [dbo].[PROC_PORTAL_SEARCH]    Script Date: 27-Jan-17 1:15:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
              
              
CREATE PROC [dbo].[PROC_PORTAL_SEARCH]              
(              
 @ANY VARCHAR(100)=NULL,              
 @ALL VARCHAR(100) =NULL,              
 @EXCLUDING VARCHAR(100) =NULL,              
 @EDUCATION_DEGREE VARCHAR(70) =NULL, -- COMMA SEPERATED DEGREE ID              
 @SPECIALIZATION VARCHAR(70) =NULL , -- COMMA SEPERATED SPECIALIZATION ID              
 @MIN_PASSING_YEAR INT =NULL,              
 @MAX_PASSING_YEAR INT = NULL,              
 @CERTIFICATION VARCHAR(70) = NULL , -- COMMA SEPERATED CERTIFICATION ID              
 @MIN_EXPERIENCE DECIMAL(5,2) =NULL,              
 @MAX_EXPERIENCE DECIMAL(5,2)=NULL,              
 @STATE_CODE VARCHAR(20) =NULL,              
 @CITY_CODE VARCHAR(20) =NULL,              
 @COMPANY_SPECIALIZATION VARCHAR(70) =NULL, --COMMA SEPERATED SPECIALIZATION ID              
 @MIN_AGE INT =0,              
 @MAX_AGE INT =null,              
 @RESUME_NOT_VIEWED INT =0,            
 @CONDITIONAL_OPERATOR VARCHAR(50) ='PORTAL_SEARCH',      
 @REGISTRATION_NUMBER VARCHAR(20)='C1020150002',  
 @WHERE_CONDITION 
 VARCHAR(MAX) =NULL         
)              
              
AS               
              
BEGIN              
IF(@CONDITIONAL_OPERATOR ='PORTAL_SEARCH')      
BEGIN    
  

SELECT TUD.REGISTRATION_NO , tud.USER_IMAGE_PATH,
ltrim(rtrim(isnull(FIRST_NAME + ' ',''))) + ' '  + ltrim(rtrim(isnull(MIDDLE_NAME + ' ','')))+ ' ' + ltrim(rtrim(isnull(LAST_NAME,''))) AS CANDIDATE_NAME,
ISNULL(TUD.TOTAL_WORK_EXPERIENCE,0) TOTAL_WORK_EXPERIENCE, TGM.GENDER_NAME,TSM.SOURCE_NAME,TUPD.CURRENT_LOCATION,
CONVERT(VARCHAR(2),DATEDIFF(YY,TUPD.DATE_OF_BIRTH,GETDATE()))AS AGE,INDUSTRY_TYPE,
CASE WHEN ISNULL(LTRIM(RTRIM(LAST_VIEW.REGISTRATION_NO)),'')='' THEN 0 ELSE 1 END AS VIEWED,VIEWED_BY,DESIGNATION,
USER_EMAIL, CONTACT_NO,HIGHEST_EDUCATION
FROM TBL_USER_DETAILS TUD WITH(NOLOCK)
JOIN
(
		SELECT  TUD.REGISTRATION_NO FROM TBL_USER_DETAILS TUD WITH(NOLOCK)
		JOIN TBL_USER_PERSONAL_DETAILS TUPD WITH(NOLOCK) ON TUD.REGISTRATION_NO = TUPD.REGISTRATION_NO
		LEFT JOIN TBL_USER_EXPERIENCE TUE WITH(NOLOCK) ON TUD.REGISTRATION_NO = TUE.REGISTRATION_NO
		LEFT JOIN TBL_USER_EDUCATION_DETAILS TUED WITH(NOLOCK) ON TUD.REGISTRATION_NO = TUED.REGISTRATION_NO
		LEFT JOIN TBL_CITY_MASTER TCM ON TUPD.CURRENT_LOCATION = TCM.CITY_CODE 
		WHERE TUD.USER_TYPE_ID = 1
		AND (ISNULL(TUD.TOTAL_WORK_EXPERIENCE,0) <= @MAX_EXPERIENCE OR ISNULL(@MAX_EXPERIENCE,0.0)=0.0 )   
		AND (ISNULL(TUD.TOTAL_WORK_EXPERIENCE,0) >=@MIN_EXPERIENCE OR ISNULL(@MIN_EXPERIENCE,0.0)=0.0 ) 
		AND (EDUCATION_TYPE_ID IN (SELECT ITEM FROM SPLIT(@EDUCATION_DEGREE ,',')) OR ISNULL(@EDUCATION_DEGREE,'')='')  
		AND (SPECIALIZATION_TYPE_ID IN (SELECT ITEM FROM SPLIT(@SPECIALIZATION,',')) OR ISNULL(@SPECIALIZATION,'')='')  
		AND (CONVERT(INT,ISNULL(UNIVERSITY_YEAR_OF_PASSING,0)) >= @MIN_PASSING_YEAR  OR ISNULL(@MIN_PASSING_YEAR,0) =0)  
		AND (CONVERT(INT,ISNULL(UNIVERSITY_YEAR_OF_PASSING,0)) <= @MAX_PASSING_YEAR  OR ISNULL(@MAX_PASSING_YEAR,0) =0) 
		AND (TUPD.CURRENT_LOCATION IN (SELECT ITEM FROM SPLIT(@CITY_CODE ,',')) OR ISNULL(@CITY_CODE,'')='')
		AND (TCM.STATE_CODE  IN (SELECT ITEM FROM SPLIT(@STATE_CODE ,',')) OR ISNULL(@STATE_CODE,'')='')
		AND (ISNULL(CONVERT(VARCHAR(2),DATEDIFF(YY,TUPD.DATE_OF_BIRTH,GETDATE())),0) <= @MAX_AGE OR ISNULL(@MAX_AGE,0.0)=0.0 )   
		AND (ISNULL(CONVERT(VARCHAR(2),DATEDIFF(YY,TUPD.DATE_OF_BIRTH,GETDATE())),0) >=@MIN_AGE OR ISNULL(@MIN_AGE,0.0)=0.0 )
		GROUP BY  TUD.REGISTRATION_NO
)USERS ON TUD.REGISTRATION_NO = USERS.REGISTRATION_NO
JOIN TBL_USER_PERSONAL_DETAILS TUPD WITH(NOLOCK) ON TUD.REGISTRATION_NO = TUPD.REGISTRATION_NO
LEFT JOIN TBL_GENDER_MASTER TGM WITH(NOLOCK) ON TUPD.GENDER_CODE = TGM.GENDER_CODE 
left JOIN TBL_SOURCE_MASTER TSM WITH(NOLOCK) ON TUD.SOURCE_ID = TSM.SOURCE_ID
LEFT JOIN               
(              
SELECT REGISTRATION_NO,INDUSTRY_TYPE               
FROM              
(              
SELECT DISTINCT P.REGISTRATION_NO,              
STUFF((SELECT DISTINCT ',' + TIM.INDUSTRY_TYPE              
	FROM TBL_USER_EXPERIENCE P1 WITH(NOLOCK)              
	JOIN TBL_INDUSTRY_MASTER TIM WITH(NOLOCK) ON P1.INDUSTRY_ID = TIM.INDUSTRY_ID                       
	WHERE P.REGISTRATION_NO = P1.REGISTRATION_NO              
	FOR XML PATH(''), TYPE              
	).value('.', 'NVARCHAR(MAX)')              
,1,1,'') INDUSTRY_TYPE              
FROM TBL_USER_EXPERIENCE P              
)USER_EXPERIENCE              
GROUP BY REGISTRATION_NO,INDUSTRY_TYPE               
)USER_EXPERIENCE ON TUD.REGISTRATION_NO = USER_EXPERIENCE.REGISTRATION_NO   
LEFT JOIN               
(              
	SELECT TRW.REGISTRATION_NO, ISNULL(TUPD.FIRST_NAME,'') + ISNULL(TUPD.MIDDLE_NAME,'')              
	+ ISNULL(TUPD.LAST_NAME,'')VIEWED_BY  FROM TBL_RESUME_VIEW TRW              
	JOIN TBL_USER_PERSONAL_DETAILS TUPD WITH(NOLOCK) ON TRW.VIEWED_BY = TUPD.REGISTRATION_NO              
	JOIN              
	(              
		SELECT MAX(RESUME_VIEW_ID)RESUME_VIEW_ID , REGISTRATION_NO               
		FROM TBL_RESUME_VIEW              
		GROUP BY REGISTRATION_NO              
	) LAST_VIEW ON TRW.RESUME_VIEW_ID =LAST_VIEW.RESUME_VIEW_ID              
)LAST_VIEW ON TUD.REGISTRATION_NO = LAST_VIEW.REGISTRATION_NO   
LEFT JOIN         
(
	SELECT REGISTRATION_NO,DESIGNATION_NAME AS DESIGNATION   
	FROM TBL_USER_EXPERIENCE TUE  WITH(NOLOCK)          
	JOIN TBL_DESIGNATION_MASTER TDM WITH(NOLOCK) ON TUE.DESIGNATION_ID = TDM.DESIGNATION_ID        
	WHERE IS_CURRENT_COMPANY = 1        
)USER_DESIGNATION ON TUD.REGISTRATION_NO = USER_DESIGNATION.REGISTRATION_NO
LEFT JOIN         
(        
	SELECT DISTINCT p.REGISTRATION_NUMBER,              
	STUFF((SELECT distinct ',' + p.CONTACT_NO                
	FROM TBL_USER_CONTACTS p1 WITH(NOLOCK)   
	WHERE p.REGISTRATION_NUMBER = p1.REGISTRATION_NUMBER                
	FOR XML PATH(''), TYPE                
	).value('.', 'NVARCHAR(MAX)')                
	,1,1,'') CONTACT_NO                
	FROM TBL_USER_CONTACTS p          
)CONTACT ON TUD.REGISTRATION_NO = CONTACT.REGISTRATION_NUMBER
 LEFT JOIN         
   (        
	   SELECT DISTINCT p.REGISTRATION_NUMBER,              
		STUFF((SELECT distinct ',' + p.user_email                
		 FROM tbl_user_email_address p1 WITH(NOLOCK)  
		 WHERE p.REGISTRATION_NUMBER = p1.REGISTRATION_NUMBER                
		 FOR XML PATH(''), TYPE                
	   ).value('.', 'NVARCHAR(MAX)')                
		,1,1,'') user_email                
	  FROM tbl_user_email_address p    WITH(NOLOCK)        
   )user_email ON TUD.REGISTRATION_NO = user_email.REGISTRATION_NUMBER    
    LEFT JOIN         
  (        
		SELECT DISTINCT   P.REGISTRATION_NO,        
		STUFF((SELECT distinct ',' + tet.EDUCATION_TYPE              
		 FROM TBL_USER_EDUCATION_DETAILS p1 WITH(NOLOCK)         
		 JOIN TBL_EDUCATION_TYPE_MASTER TET ON p1.EDUCATION_TYPE_ID = TET.EDUCATION_TYPE_ID          
		 WHERE p.REGISTRATION_NO = p1.REGISTRATION_NO              
		 FOR XML PATH(''), TYPE              
		 ).value('.', 'NVARCHAR(MAX)')              
		,1,1,'') HIGHEST_EDUCATION              
	  FROM TBL_USER_EDUCATION_DETAILS p WITH(NOLOCK)         
	  where  IS_HIGHEST_QUALIFICATION =1   	 
  )HIGHEST_EDUCATION ON TUD.REGISTRATION_NO = HIGHEST_EDUCATION.REGISTRATION_NO    
     
END      
      
IF(@CONDITIONAL_OPERATOR ='VIEW_PROFILE')      
BEGIN      

IF NOT EXISTS(SELECT 1 FROM TBL_RESUME_VIEW WHERE REGISTRATION_NO=@REGISTRATION_NUMBER AND VIEWED_BY='AMBI' AND MONTH(CREATED_DATE) >= 1)
BEGIN
INSERT INTO TBL_RESUME_VIEW(REGISTRATION_NO,VIEWED_BY,CREATED_DATE)
SELECT @REGISTRATION_NUMBER,'AMBI',GETDATE()
END
      
SELECT TUD.REGISTRATION_NO , tud.USER_IMAGE_PATH,
ltrim(rtrim(isnull(FIRST_NAME + ' ',''))) + ltrim(rtrim(isnull(MIDDLE_NAME + ' ',''))) + ltrim(rtrim(isnull(LAST_NAME,''))) AS CANDIDATE_NAME,
ISNULL(TUD.TOTAL_WORK_EXPERIENCE,0) TOTAL_WORK_EXPERIENCE, TGM.GENDER_NAME,TSM.SOURCE_NAME,TUPD.CURRENT_LOCATION,
CONVERT(VARCHAR(2),DATEDIFF(YY,TUPD.DATE_OF_BIRTH,GETDATE()))AS AGE,INDUSTRY_TYPE,
CASE WHEN ISNULL(LTRIM(RTRIM(LAST_VIEW.REGISTRATION_NO)),'')='' THEN 0 ELSE 1 END AS VIEWED,VIEWED_BY,DESIGNATION,
USER_EMAIL, CONTACT_NO,HIGHEST_EDUCATION
FROM TBL_USER_DETAILS TUD WITH(NOLOCK)
JOIN
(
		SELECT  TUD.REGISTRATION_NO FROM TBL_USER_DETAILS TUD WITH(NOLOCK)
		JOIN TBL_USER_PERSONAL_DETAILS TUPD WITH(NOLOCK) ON TUD.REGISTRATION_NO = TUPD.REGISTRATION_NO
		LEFT JOIN TBL_USER_EXPERIENCE TUE WITH(NOLOCK) ON TUD.REGISTRATION_NO = TUE.REGISTRATION_NO
		LEFT JOIN TBL_USER_EDUCATION_DETAILS TUED WITH(NOLOCK) ON TUD.REGISTRATION_NO = TUED.REGISTRATION_NO
		LEFT JOIN TBL_CITY_MASTER TCM ON TUPD.CURRENT_LOCATION = TCM.CITY_CODE 
		WHERE TUD.USER_TYPE_ID = 1
		AND (ISNULL(TUD.TOTAL_WORK_EXPERIENCE,0) <= @MAX_EXPERIENCE OR ISNULL(@MAX_EXPERIENCE,0.0)=0.0 )   
		AND (ISNULL(TUD.TOTAL_WORK_EXPERIENCE,0) >=@MIN_EXPERIENCE OR ISNULL(@MIN_EXPERIENCE,0.0)=0.0 ) 
		AND (EDUCATION_TYPE_ID IN (SELECT ITEM FROM SPLIT(@EDUCATION_DEGREE ,',')) OR ISNULL(@EDUCATION_DEGREE,'')='')  
		AND (SPECIALIZATION_TYPE_ID IN (SELECT ITEM FROM SPLIT(@SPECIALIZATION,',')) OR ISNULL(@SPECIALIZATION,'')='')  
		AND (CONVERT(INT,ISNULL(UNIVERSITY_YEAR_OF_PASSING,0)) >= @MIN_PASSING_YEAR  OR ISNULL(@MIN_PASSING_YEAR,0) =0)  
		AND (CONVERT(INT,ISNULL(UNIVERSITY_YEAR_OF_PASSING,0)) <= @MAX_PASSING_YEAR  OR ISNULL(@MAX_PASSING_YEAR,0) =0) 
		AND (TUPD.CURRENT_LOCATION IN (SELECT ITEM FROM SPLIT(@CITY_CODE ,',')) OR ISNULL(@CITY_CODE,'')='')
		AND (TCM.STATE_CODE  IN (SELECT ITEM FROM SPLIT(@STATE_CODE ,',')) OR ISNULL(@STATE_CODE,'')='')
		AND (ISNULL(CONVERT(VARCHAR(2),DATEDIFF(YY,TUPD.DATE_OF_BIRTH,GETDATE())),0) <= @MAX_AGE OR ISNULL(@MAX_AGE,0.0)=0.0 )   
		AND (ISNULL(CONVERT(VARCHAR(2),DATEDIFF(YY,TUPD.DATE_OF_BIRTH,GETDATE())),0) >=@MIN_AGE OR ISNULL(@MIN_AGE,0.0)=0.0 )
		GROUP BY  TUD.REGISTRATION_NO
)USERS ON TUD.REGISTRATION_NO = USERS.REGISTRATION_NO
JOIN TBL_USER_PERSONAL_DETAILS TUPD WITH(NOLOCK) ON TUD.REGISTRATION_NO = TUPD.REGISTRATION_NO
LEFT JOIN TBL_GENDER_MASTER TGM WITH(NOLOCK) ON TUPD.GENDER_CODE = TGM.GENDER_CODE 
left JOIN TBL_SOURCE_MASTER TSM WITH(NOLOCK) ON TUD.SOURCE_ID = TSM.SOURCE_ID
LEFT JOIN               
(              
SELECT REGISTRATION_NO,INDUSTRY_TYPE               
FROM              
(              
SELECT DISTINCT P.REGISTRATION_NO,              
STUFF((SELECT DISTINCT ',' + TIM.INDUSTRY_TYPE              
	FROM TBL_USER_EXPERIENCE P1 WITH(NOLOCK)              
	JOIN TBL_INDUSTRY_MASTER TIM WITH(NOLOCK) ON P1.INDUSTRY_ID = TIM.INDUSTRY_ID                       
	WHERE P.REGISTRATION_NO = P1.REGISTRATION_NO              
	FOR XML PATH(''), TYPE              
	).value('.', 'NVARCHAR(MAX)')              
,1,1,'') INDUSTRY_TYPE              
FROM TBL_USER_EXPERIENCE P              
)USER_EXPERIENCE              
GROUP BY REGISTRATION_NO,INDUSTRY_TYPE               
)USER_EXPERIENCE ON TUD.REGISTRATION_NO = USER_EXPERIENCE.REGISTRATION_NO   
LEFT JOIN               
(              
	SELECT TRW.REGISTRATION_NO, ISNULL(TUPD.FIRST_NAME,'') + ISNULL(TUPD.MIDDLE_NAME,'')              
	+ ISNULL(TUPD.LAST_NAME,'')VIEWED_BY  FROM TBL_RESUME_VIEW TRW              
	JOIN TBL_USER_PERSONAL_DETAILS TUPD WITH(NOLOCK) ON TRW.VIEWED_BY = TUPD.REGISTRATION_NO              
	JOIN              
	(              
		SELECT MAX(RESUME_VIEW_ID)RESUME_VIEW_ID , REGISTRATION_NO               
		FROM TBL_RESUME_VIEW              
		GROUP BY REGISTRATION_NO              
	) LAST_VIEW ON TRW.RESUME_VIEW_ID =LAST_VIEW.RESUME_VIEW_ID              
)LAST_VIEW ON TUD.REGISTRATION_NO = LAST_VIEW.REGISTRATION_NO   
LEFT JOIN         
(
	SELECT REGISTRATION_NO,DESIGNATION_NAME AS DESIGNATION   
	FROM TBL_USER_EXPERIENCE TUE  WITH(NOLOCK)          
	JOIN TBL_DESIGNATION_MASTER TDM WITH(NOLOCK) ON TUE.DESIGNATION_ID = TDM.DESIGNATION_ID        
	WHERE IS_CURRENT_COMPANY = 1        
)USER_DESIGNATION ON TUD.REGISTRATION_NO = USER_DESIGNATION.REGISTRATION_NO
LEFT JOIN         
(        
	SELECT DISTINCT p.REGISTRATION_NUMBER,              
	STUFF((SELECT distinct ',' + p.CONTACT_NO                
	FROM TBL_USER_CONTACTS p1 WITH(NOLOCK)   
	WHERE p.REGISTRATION_NUMBER = p1.REGISTRATION_NUMBER                
	FOR XML PATH(''), TYPE                
	).value('.', 'NVARCHAR(MAX)')                
	,1,1,'') CONTACT_NO                
	FROM TBL_USER_CONTACTS p          
)CONTACT ON TUD.REGISTRATION_NO = CONTACT.REGISTRATION_NUMBER
 LEFT JOIN         
   (        
	   SELECT DISTINCT p.REGISTRATION_NUMBER,              
		STUFF((SELECT distinct ',' + p.user_email                
		 FROM tbl_user_email_address p1 WITH(NOLOCK)  
		 WHERE p.REGISTRATION_NUMBER = p1.REGISTRATION_NUMBER                
		 FOR XML PATH(''), TYPE                
	   ).value('.', 'NVARCHAR(MAX)')                
		,1,1,'') user_email                
	  FROM tbl_user_email_address p    WITH(NOLOCK)        
   )user_email ON TUD.REGISTRATION_NO = user_email.REGISTRATION_NUMBER    
    LEFT JOIN         
  (        
		SELECT DISTINCT   P.REGISTRATION_NO,        
		STUFF((SELECT distinct ',' + tet.EDUCATION_TYPE              
		 FROM TBL_USER_EDUCATION_DETAILS p1 WITH(NOLOCK)         
		 JOIN TBL_EDUCATION_TYPE_MASTER TET ON p1.EDUCATION_TYPE_ID = TET.EDUCATION_TYPE_ID          
		 WHERE p.REGISTRATION_NO = p1.REGISTRATION_NO              
		 FOR XML PATH(''), TYPE              
		 ).value('.', 'NVARCHAR(MAX)')              
		,1,1,'') HIGHEST_EDUCATION              
	  FROM TBL_USER_EDUCATION_DETAILS p WITH(NOLOCK)         
	  where  IS_HIGHEST_QUALIFICATION =1   	 
  )HIGHEST_EDUCATION ON TUD.REGISTRATION_NO = HIGHEST_EDUCATION.REGISTRATION_NO    
  WHERE TUD.USER_TYPE_ID =1 AND  TUD.REGISTRATION_NO=@REGISTRATION_NUMBER            

  SELECT TUD.IS_READ AS [READ],TUD.IS_SPEAK SPEAK,TUD.IS_WRITE WRITE,TLM.LANGUAGE_NAME  AS LANGUAGE,TUD.REGISTRATION_NO 
  FROM TBL_USER_LANGUAGE TUD WITH(NOLOCK)
  JOIN TBL_LANGUAGE_MASTER TLM WITH(NOLOCK) ON TUD.LANGUAGE_ID = TLM.LANGUAGE_ID
  WHERE TUD.REGISTRATION_NO=@REGISTRATION_NUMBER 

  SELECT TUD.REGISTRATION_NUMBER,
  ISNULL(TUD.ADDRESS,'')+' '+ISNULL(TUD.USER_VILLAGE,'')+' '+ISNULL(CAST(TUD.USER_PINCODE AS VARCHAR(10)),'')+' '+
  ISNULL(TCTM.COUNTRY_NAME,'')+' '+ISNULL(TSM.STATE_NAME,'')+' '+ISNULL(TCM.CITY_NAME,'') ADDRESS
  FROM TBL_USER_ADDRESS TUD WITH(NOLOCK)
  JOIN TBL_ADDRESS_TYPE_MASTER TATM WITH(NOLOCK) ON TUD.ADDRESS_TYPE_ID = TATM.ADDRESS_TYPE_ID
  JOIN TBL_CITY_MASTER TCM WITH(NOLOCK) ON TUD.CITY_CODE = TCM.CITY_CODE
  JOIN TBL_STATE_MASTER TSM WITH(NOLOCK)ON TCM.STATE_CODE =TSM.STATE_CODE
  JOIN TBL_COUNTRY_MASTER TCTM WITH(NOLOCK)ON TSM.COUNTRY_CODE = TCTM.COUNTRY_CODE
  WHERE TUD.REGISTRATION_NUMBER=@REGISTRATION_NUMBER

  SELECT TUED.REGISTRATION_NO,TUED.UNIVERSITY_YEAR_OF_PASSING,TETM.EDUCATION_TYPE,TSM.SPECIALIZATION_TYPE,TUM.UNIVERSITY_NAME
  FROM TBL_USER_EDUCATION_DETAILS TUED WITH(NOLOCK)
  JOIN TBL_EDUCATION_TYPE_MASTER TETM WITH(NOLOCK) ON TUED.EDUCATION_TYPE_ID = TETM.EDUCATION_TYPE_ID
  JOIN TBL_SPECIALIZATION_MASTER TSM WITH(NOLOCK) ON TUED.SPECIALIZATION_TYPE_ID = TSM.SPECIALIZATION_ID
  JOIN TBL_UNIVERSITY_MASTER TUM WITH(NOLOCK) ON TUED.UNIVERSITY_ID  = TUM.UNIVERSITY_ID
  WHERE TUED.REGISTRATION_NO=@REGISTRATION_NUMBER

  SELECT TUC.CERTIFICATION_LEVEL,TUC.INSTITUTE,TUC.REGISTRATION_NUMBER,TUC.YEAR_OF_PASSING,TCM.CERTIFICATION_NAME
  FROM TBL_USER_CERTIFICATION TUC WITH(NOLOCK)
  JOIN TBL_CERTIFICATION_MASTER TCM WITH(NOLOCK) ON TUC.CERTIFICATION = TCM.CERTIFICATION_ID
  WHERE TUC.REGISTRATION_NUMBER=@REGISTRATION_NUMBER

  SELECT TUE.REGISTRATION_NO,TUE.WORK_PERIOD_FROM,TUE.WORK_PERIOD_TO,TCMP.COMPANY_NAME,TDM.DESIGNATION_NAME,TIM.INDUSTRY_TYPE
  ,ISNULL(TCTM.COUNTRY_NAME,'')+' '+ISNULL(TSM.STATE_NAME,'')+' '+ISNULL(TCM.CITY_NAME,'') ADDRESS
  FROM TBL_USER_EXPERIENCE TUE WITH(NOLOCK)
  JOIN TBL_COMPANY_MASTER TCMP WITH(NOLOCK) ON TUE.USER_COMPANY_NAME = TCMP.COMPANY_ID
  JOIN TBL_DESIGNATION_MASTER TDM WITH(NOLOCK) ON TUE.DESIGNATION_ID  = TDM.DESIGNATION_ID
  JOIN TBL_INDUSTRY_MASTER TIM WITH(NOLOCK) ON TUE.INDUSTRY_ID = TIM.INDUSTRY_ID
  JOIN TBL_CITY_MASTER TCM WITH(NOLOCK) ON TUE.CITY_CODE = TCM.CITY_CODE
  JOIN TBL_STATE_MASTER TSM WITH(NOLOCK)ON TCM.STATE_CODE =TSM.STATE_CODE
  JOIN TBL_COUNTRY_MASTER TCTM WITH(NOLOCK)ON TSM.COUNTRY_CODE = TCTM.COUNTRY_CODE
  WHERE TUE.REGISTRATION_NO=@REGISTRATION_NUMBER

  
  SELECT TUD.REGISTRATION_NO,TUD.DOCUMENT_ID,TUD.DOCUMENT_PATH
  FROM TBL_USER_DOCUMENTS TUD WITH(NOLOCK)
  WHERE TUD.REGISTRATION_NO=@REGISTRATION_NUMBER

  SELECT (ISNULL(TCTM.CONTACT_TYPE,'') +'-'+ISNULL(TUD.CONTACT_NO,''))CONTACT
  FROM TBL_USER_CONTACTS TUD WITH(NOLOCK)
  JOIN TBL_CONTACT_TYPE_MASTER TCTM WITH(NOLOCK) ON TUD.CONTACT_TYPE_ID = TCTM.CONTACT_TYPE_ID
  WHERE TUD.REGISTRATION_NUMBER=@REGISTRATION_NUMBER

  SELECT TUD.USER_EMAIL
  FROM TBL_USER_EMAIL_ADDRESS TUD WITH(NOLOCK)
  WHERE TUD.REGISTRATION_NUMBER=@REGISTRATION_NUMBER
END      
              
END 


GO
/****** Object:  StoredProcedure [dbo].[PROC_POWER_SEARCH]    Script Date: 27-Jan-17 1:15:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE PROC [dbo].[PROC_POWER_SEARCH]
(
 @ANY VARCHAR(100)=NULL,
@ALL VARCHAR(100) =NULL,
@EXCLUDING VARCHAR(100) =NULL,
@EDUCATION_DEGREE VARCHAR(70) =NULL, -- COMMA SEPERATED DEGREE ID
@SPECIALIZATION VARCHAR(70) =NULL , -- COMMA SEPERATED SPECIALIZATION ID
@MIN_PASSING_YEAR INT =NULL,
@MAX_PASSING_YEAR INT = NULL,
@CERTIFICATION VARCHAR(70) = NULL , -- COMMA SEPERATED CERTIFICATION ID
@MIN_EXPERIENCE DECIMAL(5,2) =NULL,
@MAX_EXPERIENCE DECIMAL(5,2)=NULL,
@STATE_CODE VARCHAR(20) =NULL,
@CITY_CODE VARCHAR(20) =NULL,
@COMPANY_SPECIALIZATION VARCHAR(70) =NULL, --COMMA SEPERATED SPECIALIZATION ID
@MIN_AGE INT =NULL,
@MAX_AGE INT =NULL,
@RESUME_NOT_VIEWED INT =0
)

AS 

BEGIN

		SELECT TUD.REGISTRATION_NO,TUD.USER_IMAGE_PATH, 
		ISNULL(TUPD.FIRST_NAME,'') + ISNULL(TUPD.MIDDLE_NAME,'')+ ISNULL(TUPD.LAST_NAME,'') AS CANDIDATE_NAME,
		TGM.GENDER_NAME,tud.TOTAL_WORK_EXPERIENCE,SOURCE_NAME,CURRENT_LOCATION,
		CONVERT(VARCHAR(2),DATEDIFF(YY,TUPD.DATE_OF_BIRTH,GETDATE())) + 'YRS' AS AGE,
		tud.TOTAL_WORK_EXPERIENCE,INDUSTRY_TYPE, 
		CASE WHEN LAST_VIEW.REGISTRATION_NO IS NULL THEN 0 ELSE 1 END AS VIEWED,VIEWED_BY
		FROM TBL_USER_DETAILS TUD
		JOIN TBL_USER_PERSONAL_DETAILS TUPD ON TUD.REGISTRATION_NO = TUPD.REGISTRATION_NO
		LEFT JOIN TBL_GENDER_MASTER TGM ON TUPD.GENDER_CODE = TGM.GENDER_CODE
		LEFT JOIN TBL_SOURCE_MASTER TSM ON TUD.SOURCE_ID = TSM.SOURCE_ID
		LEFT JOIN 
		(
		SELECT SUM(TOTAL_WORK_EXPERIENCE)TOTAL_WORK_EXPERIENCE,REGISTRATION_NO,INDUSTRY_TYPE 
		FROM
		(
		SELECT DISTINCT p.REGISTRATION_NO,TOTAL_WORK_EXPERIENCE,
		  STUFF((SELECT distinct ',' + TIM.INDUSTRY_TYPE
				 FROM TBL_USER_EXPERIENCE p1 WITH(NOLOCK)
				 JOIN TBL_INDUSTRY_MASTER TIM WITH(NOLOCK) ON P1.INDUSTRY_ID = TIM.INDUSTRY_ID         
				 WHERE p.REGISTRATION_NO = p1.REGISTRATION_NO
					FOR XML PATH(''), TYPE
					).value('.', 'NVARCHAR(MAX)')
				,1,1,'') INDUSTRY_TYPE
		FROM TBL_USER_EXPERIENCE p
		)USER_EXPERIENCE
		GROUP BY REGISTRATION_NO,INDUSTRY_TYPE 
		)USER_EXPERIENCE ON TUD.REGISTRATION_NO = USER_EXPERIENCE.REGISTRATION_NO
		LEFT JOIN 
		(
		SELECT TRW.REGISTRATION_NO, ISNULL(TUPD.FIRST_NAME,'') + ISNULL(TUPD.MIDDLE_NAME,'')
		+ ISNULL(TUPD.LAST_NAME,'')VIEWED_BY  FROM TBL_RESUME_VIEW TRW
		JOIN TBL_USER_PERSONAL_DETAILS TUPD WITH(NOLOCK) ON TRW.VIEWED_BY = TUPD.REGISTRATION_NO
		JOIN
		(
		SELECT MAX(RESUME_VIEW_ID)RESUME_VIEW_ID , REGISTRATION_NO 
		FROM TBL_RESUME_VIEW
		GROUP BY REGISTRATION_NO
		) LAST_VIEW ON TRW.RESUME_VIEW_ID =LAST_VIEW.RESUME_VIEW_ID
		)LAST_VIEW ON TUD.REGISTRATION_NO = LAST_VIEW.REGISTRATION_NO
		WHERE TUD.USER_TYPE_ID =1

END 



GO
/****** Object:  StoredProcedure [dbo].[PROC_REQUIREMENT_DETAILS]    Script Date: 27-Jan-17 1:15:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
        
        
CREATE PROC [dbo].[PROC_REQUIREMENT_DETAILS]         
(        
@COMPANY_ID int =NULL,        
@RECIEVED_DATE datetime =NULL,        
@NO_OF_OPENINGS int =NULL,        
@EXPERIENCE_FROM decimal(18,2) =NULL,        
@EXPERIENCE_TO decimal(18,2) =NULL,        
@JOB_DESCRIPTION varchar(200) =NULL,        
--@GENDER char(1) =NULL,        
@AGE_FROM int =NULL,        
@AGE_TO int =NULL,        
--@RELIGION_ID int =NULL,        
@INTERVIEW_MODE_ID int =NULL,        
@SPECIALIZATION_ID int=NULL,        
@POSTING_PLACE varchar =NULL,        
@CURRENCY_TYPE_ID int =NULL,        
@BASIC_SALARY_RANGE_TO int =NULL,        
@BASIC_SALARY_RANGE_FROM int =NULL,        
@OVERTIME decimal =NULL,        
@TRIP_PER_YEAR int =NULL,        
@CONTACT_PERIOD decimal =NULL,        
@WORKING_HOURS decimal =NULL,        
@LEAVES_PER_YEAR int =NULL,        
@REMARK varchar =NULL,        
@IS_ACTIVE bit =NULL,        
@CONDITIONAL_OPERATOR VARCHAR(30) =NULL,        
@USER_CODE VARCHAR(20) =NULL,        
@STATUS_ID varchar(20)=null,        
@CONTACT_PERSON VARCHAR(20)=NULL,    
@JOB_TITLE VARCHAR(50)=NULL        
)        
AS         
 BEGIN        
 IF @CONDITIONAL_OPERATOR = 'INSERT_REQUIREMENT'        
  BEGIN        
   INSERT INTO TBL_REQUIREMENT_DETAILS (COMPANY_ID,CONTACT_PERSON,STATUS_ID,NO_OF_OPENINGS,EXPERIENCE_FROM,        
   EXPERIENCE_TO,AGE_FROM,AGE_TO,INTERVIEW_MODE_ID,        
   POSTING_PLACE,CURRENCY_TYPE_ID,BASIC_SALARY_RANGE_TO,BASIC_SALARY_RANGE_FROM,OVERTIME,TRIP_PER_YEAR,        
   CONTACT_PERIOD,WORKING_HOURS,LEAVES_PER_YEAR,REMARK,IS_ACTIVE,CREATED_BY,CREATED_DATE,JOB_DESCRIPTION,JOB_TITLE)        
   VALUES         
   (        
   @COMPANY_ID,@CONTACT_PERSON,@STATUS_ID,@NO_OF_OPENINGS,@EXPERIENCE_FROM,@EXPERIENCE_TO,        
   @AGE_FROM,@AGE_TO,@INTERVIEW_MODE_ID,@POSTING_PLACE,@CURRENCY_TYPE_ID,        
   @BASIC_SALARY_RANGE_TO,@BASIC_SALARY_RANGE_FROM,@OVERTIME,@TRIP_PER_YEAR,@CONTACT_PERIOD,@WORKING_HOURS,        
   @LEAVES_PER_YEAR,@REMARK,1,@USER_CODE,GETDATE(),@JOB_DESCRIPTION ,@JOB_TITLE       
   )          
              
   SELECT IDENT_CURRENT('TBL_REQUIREMENT_DETAILS')REQUIREMENT_ID        
  END         
          
 END 

GO
/****** Object:  StoredProcedure [dbo].[PROC_REQUIREMENT_DETAILS_INSERT]    Script Date: 27-Jan-17 1:15:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[PROC_REQUIREMENT_DETAILS_INSERT]         
(        
@COMPANY_ID int =NULL,               
@NO_OF_OPENINGS int =NULL,        
@EXPERIENCE_FROM decimal(18,2) =NULL,        
@EXPERIENCE_TO decimal(18,2) =NULL,        
@JOB_DESCRIPTION varchar(200) =NULL,        
@GENDER_CODES char(10) =NULL,        
@AGE_FROM int =NULL,        
@AGE_TO int =NULL,        
@RELIGION_IDS  VARCHAR(max)=NULL,        
@INTERVIEW_MODE_ID int =NULL,        
@SPECIALIZATION_IDS VARCHAR(max)=NULL,        
@POSTING_PLACE varchar =NULL,        
@CURRENCY_TYPE_ID int =NULL,        
@BASIC_SALARY_RANGE_TO int =NULL,        
@BASIC_SALARY_RANGE_FROM int =NULL,        
@OVERTIME decimal =NULL,        
@TRIP_PER_YEAR int =NULL,        
@CONTACT_PERIOD decimal =NULL,        
@WORKING_HOURS decimal =NULL,        
@LEAVES_PER_YEAR int =NULL,        
@REMARK varchar(max) =NULL,        
@IS_ACTIVE bit =1,             
@USER_CODE VARCHAR(20) =NULL,        
@STATUS_ID varchar(20)=null,        
@CONTACT_PERSON VARCHAR(20)=NULL,    
@JOB_TITLE VARCHAR(50)=NULL,
@ALLOWANCE_IDS VARCHAR(max)=NULL,  
@LANGUAGES_IDS VARCHAR(max)=NULL ,
@EDUCATION_IDS VARCHAR(max)=NULL,
@INDUSTRY_IDS VARCHAR(max)=NULL,
@DESIGNATION_IDS VARCHAR(max)=NULL,
@CIRTIFICATION_IDS VARCHAR(MAX)=NULL,
@RequirementID int output

)        
AS              
   BEGIN   
   --DECLARE @RequirementID int ; 
   DECLARE @PrimaryDelimiter VARCHAR(1)
   DECLARE @SecondryDelimiter VARCHAR(1)
	SET @PrimaryDelimiter='|';
	SET @SecondryDelimiter=',';
   --REQUIREMENT_DETAILS INSERTATION
   INSERT INTO TBL_REQUIREMENT_DETAILS (COMPANY_ID,CONTACT_PERSON,STATUS_ID,NO_OF_OPENINGS,EXPERIENCE_FROM,        
   EXPERIENCE_TO,AGE_FROM,AGE_TO,INTERVIEW_MODE_ID,        
   POSTING_PLACE,CURRENCY_TYPE_ID,BASIC_SALARY_RANGE_TO,BASIC_SALARY_RANGE_FROM,OVERTIME,TRIP_PER_YEAR,        
   CONTACT_PERIOD,WORKING_HOURS,LEAVES_PER_YEAR,REMARK,IS_ACTIVE,CREATED_BY,CREATED_DATE,JOB_DESCRIPTION,JOB_TITLE)        

   VALUES         
   (        
   @COMPANY_ID,@CONTACT_PERSON,@STATUS_ID,@NO_OF_OPENINGS,@EXPERIENCE_FROM,@EXPERIENCE_TO,        
   @AGE_FROM,@AGE_TO,@INTERVIEW_MODE_ID,@POSTING_PLACE,@CURRENCY_TYPE_ID,        
   @BASIC_SALARY_RANGE_TO,@BASIC_SALARY_RANGE_FROM,@OVERTIME,@TRIP_PER_YEAR,@CONTACT_PERIOD,@WORKING_HOURS,        
   @LEAVES_PER_YEAR,@REMARK,@IS_ACTIVE,@USER_CODE,GETDATE(),@JOB_DESCRIPTION ,@JOB_TITLE       
   )          
              
   SET @RequirementID= @@IDENTITY;
   --ALLOWANCE INSERTATION
   
    IF ((@ALLOWANCE_IDS IS NOT NULL) AND (LEN(@ALLOWANCE_IDS) > 0))
	BEGIN
		;WITH CTE AS
		( 
		SELECT 
				CAST('<M>' + REPLACE(Splitdata, @SecondryDelimiter, '</M><M>') + '</M>' AS XML) 
				AS [SplitXML]
			FROM   dbo.fnSplitString(@ALLOWANCE_IDS,@PrimaryDelimiter)
		)
		 INSERT INTO TBL_REQUIREMENT_ALLOWANCE (	
			ALLOWANCE_ID,REQUIRMENT_ID,IS_INCLUDED,IS_ALLOWANCE,ALLOWANCE_AMOUNT,IS_NOT_APPLICABLE,	CREATED_BY,	CREATED_DATE,ALLOWANCE_TYPE_ID) 
		SELECT 
			 SplitXML.value('/M[1]', 'varchar(10)') AS ALLOWANCE_ID,@RequirementID,NULL,NULL,
			 SplitXML.value('/M[3]', 'varchar(10)') AS ALLOWANCE_AMOUNT,
			 NULL,@USER_CODE,GETDATE(),SplitXML.value('/M[2]', 'varchar(10)') AS ALLOWANCE_TYPE_ID 	
		FROM CTE
	END

	--GENDER INSERTATION
	IF ((@GENDER_CODES IS NOT NULL) AND (LEN(@GENDER_CODES) > 0))
	BEGIN
		;WITH CTE_ALLOWANCE AS
		( 
		SELECT 
				CAST('<M>' + REPLACE(Splitdata, '', '</M><M>') + '</M>' AS XML) 
				AS [SplitXML]
			FROM   dbo.fnSplitString(@GENDER_CODES,@PrimaryDelimiter)
		)
		INSERT INTO TBL_REQUIREMENT_GENDER (REQUIREMENT_ID,GENDER,CREATED_BY,CREATED_DATE,IS_ACTIVE)	 
		SELECT @RequirementID,SplitXML.value('/M[1]', 'varchar(10)') As GENDER,@USER_CODE,GETDATE(),1	

		FROM CTE_ALLOWANCE		
    END
	--LANGUAGE INSERTATION	
	IF ((@LANGUAGES_IDS IS NOT NULL) AND (LEN(@LANGUAGES_IDS) > 0))
	BEGIN
		;WITH CTE_LANGUAGE AS
		( 
		SELECT 
				CAST('<M>' + REPLACE(Splitdata, @SecondryDelimiter, '</M><M>') + '</M>' AS XML) 
				AS [SplitXML]

			FROM   dbo.fnSplitString(@LANGUAGES_IDS,@PrimaryDelimiter)
		)
		INSERT INTO TBL_REQUIREMENT_LANGUAGE (REQUIRMENT_ID,LANGUAGE_ID,CAN_READ,CAN_WRITE,CAN_SPEAK,IS_ACTIVE,CREATED_BY,CREATED_DATE)
		SELECT @RequirementID,
			  SplitXML.value('/M[1]', 'varchar(10)') As LANGUAGE_ID,
			  SplitXML.value('/M[2]', 'varchar(10)') As CAN_READ,
			  SplitXML.value('/M[3]', 'varchar(10)') As CAN_WRITE,
			  SplitXML.value('/M[4]', 'varchar(10)') As CAN_SPEAK,1,@USER_CODE,GETDATE() 	
		FROM CTE_LANGUAGE
	END
	
	--RELIGION INSERTATION
	IF ((@RELIGION_IDS IS NOT NULL) AND (LEN(@RELIGION_IDS) > 0))
	BEGIN
		;WITH CTE_RELIGION AS
		( 
		SELECT 
				CAST('<M>' + REPLACE(Splitdata, '', '</M><M>') + '</M>' AS XML) 
				AS [SplitXML]
			FROM   dbo.fnSplitString(@RELIGION_IDS,@PrimaryDelimiter)
		)	
		INSERT INTO TBL_REQUIREMENT_RELIGION (REQUIREMENT_ID,RELIGION_ID,CREATED_BY,CREATED_DATE,IS_ACTIVE)
		SELECT @RequirementID,
			  SplitXML.value('/M[1]', 'varchar(10)')AS RELIGION_ID, @USER_CODE,GETDATE(),1
		FROM CTE_RELIGION
	END
	--INDUSTRY INSERTATION

	IF ((@INDUSTRY_IDS IS NOT NULL) AND (LEN(@INDUSTRY_IDS) > 0))
	BEGIN
	;WITH CTE_INDUSTRY AS
	( 
	SELECT 
			CAST('<M>' + REPLACE(Splitdata, '', '</M><M>') + '</M>' AS XML) 
			AS [SplitXML]
		FROM   dbo.fnSplitString(@INDUSTRY_IDS,@PrimaryDelimiter)
	)	
	INSERT INTO TBL_REQUIRMENT_INDUSTRY (REQUIREMENT_ID,INDUSTRY_ID,CREATED_BY,CREATED_DATE,IS_ACTIVE)
	SELECT @RequirementID,
		  SplitXML.value('/M[1]', 'varchar(10)') AS INDUSTRY_ID, @USER_CODE,GETDATE(),1
	FROM CTE_INDUSTRY
	END
	--DESIGNATION INSERTION
	
	IF ((@DESIGNATION_IDS IS NOT NULL) AND (LEN(@DESIGNATION_IDS) > 0))
	BEGIN
		;WITH CTE_DESIGNATION AS
		( 
		SELECT 
				CAST('<M>' + REPLACE(Splitdata, '', '</M><M>') + '</M>' AS XML) 
				AS [SplitXML]
			FROM   dbo.fnSplitString(@DESIGNATION_IDS,@PrimaryDelimiter)
		)	
		INSERT INTO TBL_REQUIRMENT_DESIGNATION (REQUIREMENT_ID,DESIGNATION_ID,CREATED_BY,CREATED_DATE,IS_ACTIVE)
		SELECT @RequirementID,
			  SplitXML.value('/M[1]', 'varchar(10)') As DESIGNATION_ID,@USER_CODE,GETDATE(),1
		FROM CTE_DESIGNATION
	END
	--EDUCATION INSERTATION

	IF ((@EDUCATION_IDS IS NOT NULL) AND (LEN(@DESIGNATION_IDS) > 0))
	BEGIN
		;WITH CTE_EDUCATION AS
		( 
		SELECT 
				CAST('<M>' + REPLACE(Splitdata, '', '</M><M>') + '</M>' AS XML) 
				AS [SplitXML]
			FROM   dbo.fnSplitString(@EDUCATION_IDS,@PrimaryDelimiter)
		)	
		INSERT INTO TBL_REQUIRMENT_EDUCATION_TYPE (REQUIREMENT_ID,EDUCATION_TYPE_ID,CREATED_BY,CREATED_DATE,IS_ACTIVE)
		SELECT @RequirementID,
			  SplitXML.value('/M[1]', 'varchar(10)') As EDUCATION_TYPE_ID, @USER_CODE,GETDATE(),1
		FROM CTE_EDUCATION
	END
	--SPECIALIZATION INSERTION
	
	IF ((@SPECIALIZATION_IDS IS NOT NULL) AND (LEN(@SPECIALIZATION_IDS) > 0))
	BEGIN
	;WITH CTE_SPECIALIZATION AS
	( 
	SELECT 
			CAST('<M>' + REPLACE(Splitdata, '', '</M><M>') + '</M>' AS XML) 
			AS [SplitXML]
		FROM   dbo.fnSplitString(@SPECIALIZATION_IDS,@PrimaryDelimiter)
	)	
	INSERT INTO TBL_REQUIRMENT_SPECIALIZATION (REQUIREMENT_ID,SPECIALIZATION_ID,CREATED_BY,CREATED_DATE,IS_ACTIVE)
	SELECT @RequirementID,
		  SplitXML.value('/M[1]', 'varchar(10)') As SPECIALIZATION_ID,@USER_CODE,GETDATE(),1
	FROM CTE_SPECIALIZATION
	END

-- CERTIFICATION INSERTION
	
	IF ((@CIRTIFICATION_IDS IS NOT NULL) AND (LEN(@CIRTIFICATION_IDS) > 0))
	BEGIN
	;WITH CTE_CERTIFICATION AS
	( 
	SELECT 
			CAST('<M>' + REPLACE(Splitdata, '', '</M><M>') + '</M>' AS XML) 
			AS [SplitXML]
		FROM   dbo.fnSplitString(@CIRTIFICATION_IDS,@PrimaryDelimiter)
	)	
	INSERT INTO TBL_REQUIRMENT_CERTIFICATION (REQUIREMENT_ID,CERTIFICATION_ID,CREATED_BY,CREATED_DATE,IS_ACTIVE)
	SELECT @RequirementID,
		  SplitXML.value('/M[1]', 'varchar(10)') As CIRTIFICATION_ID,@USER_CODE,GETDATE(),1
	FROM CTE_CERTIFICATION
	END
		RETURN @RequirementID;

 END
GO
/****** Object:  StoredProcedure [dbo].[PROC_REQUIREMENT_DETAILS_UPDATE]    Script Date: 27-Jan-17 1:15:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[PROC_REQUIREMENT_DETAILS_UPDATE]         
( 
@REQUIREMENT_ID int,       
@COMPANY_ID int =NULL,               
@NO_OF_OPENINGS int =NULL,        
@EXPERIENCE_FROM decimal(18,2) =NULL,        
@EXPERIENCE_TO decimal(18,2) =NULL,        
@JOB_DESCRIPTION varchar(200) =NULL,        
@GENDER_CODES char(10) =NULL,        
@AGE_FROM int =NULL,        
@AGE_TO int =NULL,        
@RELIGION_IDS  VARCHAR(max)=NULL,        
@INTERVIEW_MODE_ID int =NULL,        
@SPECIALIZATION_IDS VARCHAR(max)=NULL,        
@POSTING_PLACE varchar =NULL,        
@CURRENCY_TYPE_ID int =NULL,        
@BASIC_SALARY_RANGE_TO int =NULL,        
@BASIC_SALARY_RANGE_FROM int =NULL,        
@OVERTIME decimal =NULL,        
@TRIP_PER_YEAR int =NULL,        
@CONTACT_PERIOD decimal =NULL,        
@WORKING_HOURS decimal =NULL,        
@LEAVES_PER_YEAR int =NULL,        
@REMARK varchar =NULL,        
@IS_ACTIVE bit =1,             
@USER_CODE VARCHAR(20) =NULL,        
@STATUS_ID bit=1,        
@CONTACT_PERSON VARCHAR(20)=NULL,    
@JOB_TITLE VARCHAR(50)=NULL,
@ALLOWANCE_IDS VARCHAR(max)=NULL,  
@LANGUAGES_IDS VARCHAR(max)=NULL ,
@EDUCATION_IDS VARCHAR(max)=NULL,
@INDUSTRY_IDS VARCHAR(max)=NULL,
@DESIGNATION_IDS VARCHAR(max)=NULL,
@CIRTIFICATION_IDS VARCHAR(MAX)=NULL
)        
AS              
   BEGIN   
   --DECLARE @RequirementID int ; 
   DECLARE @PrimaryDelimiter VARCHAR(1)
   DECLARE @SecondryDelimiter VARCHAR(1)
	SET @PrimaryDelimiter='|';
	SET @SecondryDelimiter=',';

   --REQUIREMENT_DETAILS UPDATE
  UPDATE TBL_REQUIREMENT_DETAILS SET COMPANY_ID=@COMPANY_ID,CONTACT_PERSON=@CONTACT_PERSON,
  STATUS_ID=@STATUS_ID,NO_OF_OPENINGS=@NO_OF_OPENINGS,EXPERIENCE_FROM=@EXPERIENCE_FROM,        
   EXPERIENCE_TO=@EXPERIENCE_TO,AGE_FROM=@AGE_FROM,AGE_TO=@AGE_TO,INTERVIEW_MODE_ID=@INTERVIEW_MODE_ID,        
   POSTING_PLACE=@POSTING_PLACE,CURRENCY_TYPE_ID=@CURRENCY_TYPE_ID,BASIC_SALARY_RANGE_TO=@BASIC_SALARY_RANGE_TO,
   BASIC_SALARY_RANGE_FROM=@BASIC_SALARY_RANGE_FROM,OVERTIME=@OVERTIME,TRIP_PER_YEAR=@TRIP_PER_YEAR,        
   CONTACT_PERIOD=@CONTACT_PERIOD,WORKING_HOURS=@WORKING_HOURS,
   LEAVES_PER_YEAR=@LEAVES_PER_YEAR,REMARK=@REMARK,IS_ACTIVE=@IS_ACTIVE,CREATED_BY=@USER_CODE,
   JOB_DESCRIPTION=@JOB_DESCRIPTION,JOB_TITLE=@JOB_TITLE  
   WHERE REQUIREMENT_ID=  @REQUIREMENT_ID      

--ALLOWANCE INSERTATION
   DELETE FROM TBL_REQUIREMENT_ALLOWANCE WHERE REQUIRMENT_ID=@REQUIREMENT_ID;
    IF ((@ALLOWANCE_IDS IS NOT NULL) AND (LEN(@ALLOWANCE_IDS) > 0))
	BEGIN
		;WITH CTE AS
		( 
		SELECT 
				CAST('<M>' + REPLACE(Item, @SecondryDelimiter, '</M><M>') + '</M>' AS XML) 
				AS [SplitXML]
			FROM   dbo.Split(@ALLOWANCE_IDS,@PrimaryDelimiter)
		)
		 INSERT INTO TBL_REQUIREMENT_ALLOWANCE (	
			ALLOWANCE_ID,REQUIRMENT_ID,IS_INCLUDED,IS_ALLOWANCE,ALLOWANCE_AMOUNT,IS_NOT_APPLICABLE,CREATED_BY,	CREATED_DATE,ALLOWANCE_TYPE_ID) 
		SELECT 
			 SplitXML.value('/M[1]', 'varchar(10)') AS ALLOWANCE_ID,@REQUIREMENT_ID,NULL,NULL,
			 SplitXML.value('/M[3]', 'varchar(10)') AS ALLOWANCE_AMOUNT,
			 NULL,@USER_CODE,GETDATE(),SplitXML.value('/M[2]', 'varchar(10)') AS ALLOWANCE_TYPE_ID 	
		FROM CTE
	END

	--GENDER INSERTATION
	DELETE FROM TBL_REQUIREMENT_GENDER WHERE REQUIREMENT_ID=@REQUIREMENT_ID;	
	IF ((@GENDER_CODES IS NOT NULL) AND (LEN(@GENDER_CODES) > 0))
	BEGIN
		;WITH CTE_GENDER AS
		( 
		SELECT 
				CAST('<M>' + REPLACE(Item, '', '</M><M>') + '</M>' AS XML) 
				AS [SplitXML]
			FROM   dbo.Split(@GENDER_CODES,@PrimaryDelimiter)
		)
		INSERT INTO TBL_REQUIREMENT_GENDER (REQUIREMENT_ID,GENDER,CREATED_BY,CREATED_DATE,IS_ACTIVE)	 
		SELECT @REQUIREMENT_ID,SplitXML.value('/M[1]', 'varchar(10)') As GENDER,@USER_CODE,GETDATE(),1	

		FROM CTE_GENDER	
    END
	--LANGUAGE INSERTATION
	DELETE FROM TBL_REQUIREMENT_LANGUAGE WHERE REQUIRMENT_ID=@REQUIREMENT_ID;	
	IF ((@LANGUAGES_IDS IS NOT NULL) AND (LEN(@LANGUAGES_IDS) > 0))
	BEGIN
		;WITH CTE_LANGUAGE AS
		( 
		SELECT 
				CAST('<M>' + REPLACE(Item, @SecondryDelimiter, '</M><M>') + '</M>' AS XML) 
				AS [SplitXML]

			FROM   dbo.Split(@LANGUAGES_IDS,@PrimaryDelimiter)
		)
		INSERT INTO TBL_REQUIREMENT_LANGUAGE (REQUIRMENT_ID,LANGUAGE_ID,CAN_READ,CAN_WRITE,CAN_SPEAK,IS_ACTIVE,CREATED_BY,CREATED_DATE)
		SELECT @REQUIREMENT_ID,
			  SplitXML.value('/M[1]', 'varchar(10)') As LANGUAGE_ID,
			  SplitXML.value('/M[2]', 'varchar(10)') As CAN_READ,
			  SplitXML.value('/M[3]', 'varchar(10)') As CAN_WRITE,
			  SplitXML.value('/M[4]', 'varchar(10)') As CAN_SPEAK,1,@USER_CODE,GETDATE() 	
		FROM CTE_LANGUAGE
	END
	
	--RELIGION INSERTATION
	DELETE FROM TBL_REQUIREMENT_RELIGION WHERE REQUIREMENT_ID=@REQUIREMENT_ID;
	IF ((@RELIGION_IDS IS NOT NULL) AND (LEN(@RELIGION_IDS) > 0))
	BEGIN
		;WITH CTE_RELIGION AS
		( 
		SELECT 
				CAST('<M>' + REPLACE(Item, '', '</M><M>') + '</M>' AS XML) 
				AS [SplitXML]
			FROM   dbo.Split(@RELIGION_IDS,@PrimaryDelimiter)
		)	
		INSERT INTO TBL_REQUIREMENT_RELIGION (REQUIREMENT_ID,RELIGION_ID,CREATED_BY,CREATED_DATE,IS_ACTIVE)
		SELECT @REQUIREMENT_ID,
			  SplitXML.value('/M[1]', 'varchar(10)')AS RELIGION_ID, @USER_CODE,GETDATE(),1
		FROM CTE_RELIGION
	END
	--INDUSTRY INSERTATION
	DELETE FROM TBL_REQUIRMENT_INDUSTRY WHERE REQUIREMENT_ID=@REQUIREMENT_ID;
	IF ((@INDUSTRY_IDS IS NOT NULL) AND (LEN(@INDUSTRY_IDS) > 0))
	BEGIN
	;WITH CTE_INDUSTRY AS
	( 
	SELECT 
			CAST('<M>' + REPLACE(Item, '', '</M><M>') + '</M>' AS XML) 
			AS [SplitXML]
		FROM   dbo.Split(@INDUSTRY_IDS,@PrimaryDelimiter)
	)	
	INSERT INTO TBL_REQUIRMENT_INDUSTRY (REQUIREMENT_ID,INDUSTRY_ID,CREATED_BY,CREATED_DATE,IS_ACTIVE)
	SELECT @REQUIREMENT_ID,
		  SplitXML.value('/M[1]', 'varchar(10)') AS INDUSTRY_ID, @USER_CODE,GETDATE(),1
	FROM CTE_INDUSTRY
	END
	--DESIGNATION INSERTION
	DELETE FROM TBL_REQUIRMENT_DESIGNATION WHERE REQUIREMENT_ID=@REQUIREMENT_ID;
	IF ((@DESIGNATION_IDS IS NOT NULL) AND (LEN(@DESIGNATION_IDS) > 0))
	BEGIN
		;WITH CTE_DESIGNATION AS
		( 
		SELECT 
				CAST('<M>' + REPLACE(Item, '', '</M><M>') + '</M>' AS XML) 
				AS [SplitXML]
			FROM   dbo.Split(@DESIGNATION_IDS,@PrimaryDelimiter)
		)	
		INSERT INTO TBL_REQUIRMENT_DESIGNATION (REQUIREMENT_ID,DESIGNATION_ID,CREATED_BY,CREATED_DATE,IS_ACTIVE)
		SELECT @REQUIREMENT_ID,
			  SplitXML.value('/M[1]', 'varchar(10)') As DESIGNATION_ID,@USER_CODE,GETDATE(),1
		FROM CTE_DESIGNATION
	END
	--EDUCATION INSERTATION
	DELETE FROM TBL_REQUIRMENT_EDUCATION_TYPE WHERE REQUIREMENT_ID=@REQUIREMENT_ID;
	IF ((@EDUCATION_IDS IS NOT NULL) AND (LEN(@DESIGNATION_IDS) > 0))
	BEGIN
		;WITH CTE_EDUCATION AS
		( 
		SELECT 
				CAST('<M>' + REPLACE(Item, '', '</M><M>') + '</M>' AS XML) 
				AS [SplitXML]
			FROM   dbo.Split(@EDUCATION_IDS,@PrimaryDelimiter)
		)	
		INSERT INTO TBL_REQUIRMENT_EDUCATION_TYPE (REQUIREMENT_ID,EDUCATION_TYPE_ID,CREATED_BY,CREATED_DATE,IS_ACTIVE)
		SELECT @REQUIREMENT_ID,
			  SplitXML.value('/M[1]', 'varchar(10)') As EDUCATION_TYPE_ID, @USER_CODE,GETDATE(),1
		FROM CTE_EDUCATION
	END
	--SPECIALIZATION INSERTION
	DELETE FROM TBL_REQUIRMENT_SPECIALIZATION WHERE REQUIREMENT_ID=@REQUIREMENT_ID;
	IF ((@SPECIALIZATION_IDS IS NOT NULL) AND (LEN(@SPECIALIZATION_IDS) > 0))
	BEGIN
	;WITH CTE_SPECIALIZATION AS
	( 
	SELECT 
			CAST('<M>' + REPLACE(Item, '', '</M><M>') + '</M>' AS XML) 
			AS [SplitXML]
		FROM   dbo.Split(@SPECIALIZATION_IDS,@PrimaryDelimiter)
	)	
	INSERT INTO TBL_REQUIRMENT_SPECIALIZATION (REQUIREMENT_ID,SPECIALIZATION_ID,CREATED_BY,CREATED_DATE,IS_ACTIVE)
	SELECT @REQUIREMENT_ID,
		  SplitXML.value('/M[1]', 'varchar(10)') As SPECIALIZATION_ID,@USER_CODE,GETDATE(),1
	FROM CTE_SPECIALIZATION
	END

-- CERTIFICATION INSERTION
	DELETE FROM TBL_REQUIRMENT_CERTIFICATION WHERE REQUIREMENT_ID=@REQUIREMENT_ID;
	IF ((@CIRTIFICATION_IDS IS NOT NULL) AND (LEN(@CIRTIFICATION_IDS) > 0))
	BEGIN
	;WITH CTE_CERTIFICATION AS
	( 
	SELECT 
			CAST('<M>' + REPLACE(Item, '', '</M><M>') + '</M>' AS XML) 
			AS [SplitXML]
		FROM   dbo.Split(@CIRTIFICATION_IDS,@PrimaryDelimiter)
	)	
	INSERT INTO TBL_REQUIRMENT_CERTIFICATION (REQUIREMENT_ID,CERTIFICATION_ID,CREATED_BY,CREATED_DATE,IS_ACTIVE)
	SELECT @REQUIREMENT_ID,
		  SplitXML.value('/M[1]', 'varchar(10)') As CIRTIFICATION_ID,@USER_CODE,GETDATE(),1
	FROM CTE_CERTIFICATION
	END
		
 END
GO
/****** Object:  StoredProcedure [dbo].[PROC_REQUIREMENT_MASTER]    Script Date: 27-Jan-17 1:15:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[PROC_REQUIREMENT_MASTER]
AS
BEGIN
SELECT ALLOWANCE_ID,ALLOWANCE_NAME,IS_ACTIVE,CREATED_DATE,CREATED_BY FROM TBL_ALLOWANCE_MASTER WHERE IS_ACTIVE=1
SELECT COMPANY_ID,COMPANY_NAME,CONTACT_PERSON,CREATED_BY,CREATED_DATE,MODIFIED_BY,MODIFIED_DATE,IS_ACTIVE FROM TBL_COMPANY_MASTER WHERE IS_ACTIVE=1
SELECT TUD.REGISTRATION_NO,(ISNULL(TUPD.FIRST_NAME,'') +' ' + ISNULL(TUPD.MIDDLE_NAME,'') +' '+ ISNULL(TUPD.LAST_NAME,''))NAME
 FROM TBL_USER_DETAILS TUD WITH (NOLOCK)                      
 JOIN TBL_USER_PERSONAL_DETAILS TUPD WITH (NOLOCK) ON TUD.REGISTRATION_NO = TUPD.REGISTRATION_NO                      
 WHERE USER_TYPE_ID = 5 AND IS_ACTIVE =1        
 ORDER BY (ISNULL(TUPD.FIRST_NAME,'') +' ' + ISNULL(TUPD.MIDDLE_NAME,'') +' '+ ISNULL(TUPD.LAST_NAME,''))
 SELECT CURRENCY_ID,CURRENCY_NAME,CURRENCY_SYMBOL,DISPLAY_ORDER,IS_ACTIVE,CREATED_BY,CREATED_DATE,
MODIFIED_BY,MODIFIED_DATE FROM TBL_CURRENCY_MASTER WHERE IS_ACTIVE =1 ORDER BY DISPLAY_ORDER

SELECT EDUCATION_TYPE_ID,EDUCATION_TYPE,IS_ACTIVE,CREATED_BY,CREATED_DATE,MODIFIED_BY,
MODIFIED_DATE FROM TBL_EDUCATION_TYPE_MASTER WHERE IS_ACTIVE =1 ORDER BY EDUCATION_TYPE_ID

SELECT GENDER_CODE,GENDER_NAME,GENDER_ORDER,IS_ACTIVE,CREATED_BY,CREATED_DATE,MODIFIED_BY,MODIFIED_DATE
FROM 
TBL_GENDER_MASTER WHERE IS_ACTIVE =1 ORDER BY GENDER_ORDER

SELECT INTERVIEW_MODE_ID,INTERVIEW_MODE,DISPLAY_ORDER,IS_ACTIVE,CREATED_BY,CREATED_DATE,MODIFIED_BY,MODIFIED_DATE
FROM 
TBL_INTERVIEW_MODE_MASTER WHERE IS_ACTIVE =1 ORDER BY DISPLAY_ORDER

SELECT LANGUAGE_ID,LANGUAGE_NAME,IS_ACTIVE,CREATED_DATE,CREATED_BY
FROM 
TBL_LANGUAGE_MASTER WHERE IS_ACTIVE =1 

SELECT RELIGION_ID,RELIGION_NAME,RELIGION_ORDER,IS_ACTIVE,CREATED_BY,CREATED_DATE,MODIFIED_BY,MODIFIED_DATE
FROM
TBL_RELIGION_MASTER WHERE IS_ACTIVE=1 ORDER BY RELIGION_ORDER

SELECT [STATUS_VAL],[STATUS_NAME]
FROM
TBL_REQUIREMENT_STATUS_MASTER ORDER BY STATUS_ORDER
--SELECT SPECIALIZATION_ID,EDUCATION_TYPE_ID,SPECIALIZATION_TYPE,IS_ACTIVE,CREATED_BY,CREATED_DATE,MODIFIED_BY,MODIFIED_DATE

--FROM

--TBL_SPECIALIZATION_MASTER WHERE IS_ACTIVE=1 

SELECT INDUSTRY_ID,INDUSTRY_TYPE,IS_ACTIVE,CREATED_DATE,CREATED_BY,MODIFIED_BY,MODIFIED_DATE
FROM  TBL_INDUSTRY_MASTER WHERE IS_ACTIVE=1

SELECT CERTIFICATION_ID,CERTIFICATION_NAME,CREATED_BY,CREATED_DATE,IS_ACTIVE
FROM  TBL_CERTIFICATION_MASTER WHERE IS_ACTIVE=1

SELECT ALLOWANCE_TYPE_ID,ALLOWANCE_TYPE FROM TBL_ALLOWANCE_TYPE_MASTER WHERE IS_ACTIVE=1


END

GO
/****** Object:  StoredProcedure [dbo].[PROC_REQUIREMENT_SEARCH]    Script Date: 27-Jan-17 1:15:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE  PROC [dbo].[PROC_REQUIREMENT_SEARCH] 
(
 @REQUIREMENT_ID INT =1
)
AS 

BEGIN
-- SECTION 1 (UNABLE TO CALCULATE ROLE)
SELECT TRD.REQUIREMENT_ID, CONVERT(VARCHAR(12),RECIEVED_DATE,103)OPENING_DATE,
COMPANY_NAME,ISNULL(TCM.CONTACT_PERSON,TRD.CONTACT_PERSON)AS CONTACT_PERSON,
CONVERT(VARCHAR,NO_OF_OPENINGS)NO_OF_OPENINGS,INTERVIEW_MODE, INDUSTRY_TYPE,'' REQ_ROLE, '' VISA ,
ISNULL(CONVERT(VARCHAR(12),EXPERIENCE_FROM),'') + ' - '  + ISNULL(CONVERT(VARCHAR(12),EXPERIENCE_TO),'') EXPERIENCE,
SPECIALIZATION,EDUCATION_TYPE,CERTIFICATION_TYPE,LANGUAGES,GENDERS,
ISNULL(CONVERT(VARCHAR(10),AGE_FROM),'') + ' - ' +  ISNULL(CONVERT(VARCHAR(10),AGE_TO),'') AGE,
ISNULL(RELIGION_NAME,'')RELIGION,UPPER(POSTING_PLACE)POSTING_PLACE,
CONVERT(VARCHAR,BASIC_SALARY_RANGE_TO) + ' - ' + CONVERT(VARCHAR(10),BASIC_SALARY_RANGE_FROM)
 + ISNULL(' ' + CURRENCY_SYMBOL,'') BASIC_SALARY,
CONVERT(VARCHAR,OVERTIME)OVERTIME,CONVERT(VARCHAR,CONTACT_PERIOD)CONTACT_PERIOD,
CONVERT(VARCHAR,WORKING_HOURS)WORKING_HOURS,CONVERT(VARCHAR,LEAVES_PER_YEAR)LEAVES_PER_YEAR,
 CONVERT(VARCHAR(10),TRIP_PER_YEAR) TRIP_PER_YEAR,
 ISNULL([HOUSE],0) HOUSE, ISNULL([FOOD],0)FOOD, ISNULL([MEDICAL],0) MEDICAL, ISNULL([TRAVEL],0)TRAVEL,
 JOB_DESCRIPTION
FROM TBL_REQUIREMENT_DETAILS TRD WITH(NOLOCK)  
LEFT JOIN(  
SELECT [HOUSE],[FOOD],[MEDICAL],[TRAVEL],REQUIRMENT_ID FROM   
(  
SELECT ALLOWANCE_AMOUNT,ALLOWANCE_TYPE,REQUIRMENT_ID  FROM TBL_REQUIREMENT_ALLOWANCE TRA   
JOIN TBL_ALLOWANCE_TYPE_MASTER TATM ON TRA.ALLOWANCE_TYPE_ID = TATM.ALLOWANCE_TYPE_ID  
) PIV PIVOT  
(  
SUM(ALLOWANCE_AMOUNT) FOR ALLOWANCE_TYPE IN ([HOUSE],[FOOD],[MEDICAL],[TRAVEL])  
)ALLOWANCE  
)ALLOWANCE ON TRD.REQUIREMENT_ID = ALLOWANCE.REQUIRMENT_ID  
LEFT JOIN TBL_GENDER_MASTER TGM WITH(NOLOCK)ON TRD.GENDER = TGM.GENDER_CODE  
LEFT JOIN TBL_RELIGION_MASTER TRM ON TRD.RELIGION_ID = TRM.RELIGION_ID  
LEFT JOIN TBL_CURRENCY_MASTER TCUM ON TRD.CURRENCY_TYPE_ID = TCUM.CURRENCY_ID  
LEFT JOIN TBL_COMPANY_MASTER TCM WITH(NOLOCK) ON TRD.COMPANY_ID = TCM.COMPANY_ID  
LEFT JOIN TBL_INTERVIEW_MODE_MASTER TIMM WITH(NOLOCK)ON TRD.INTERVIEW_MODE_ID = TIMM.INTERVIEW_MODE_ID  
  
LEFT JOIN             
(            
 SELECT DISTINCT p.REGISTRATION_NUMBER,(ISNULL(tupd.FIRST_NAME,'') +' '+ ISNULL(tupd.LAST_NAME,''))NAME,                 
 (SELECT SUBSTRING(    
 (SELECT ',' + TUC.CONTACT_NO    
 FROM TBL_USER_CONTACTS TUC    
 WHERE P.REGISTRATION_NUMBER = TUC.REGISTRATION_NUMBER    
 ORDER BY TUC.USER_CONTACT_ID    
 FOR XML PATH('')),2,200000)) AS CONTACT_NO                    
 FROM TBL_USER_CONTACTS p WITH (NOLOCK)             
 JOIN TBL_USER_DETAILS TUD ON P.REGISTRATION_NUMBER = TUD.REGISTRATION_NO  
 join TBL_USER_PERSONAL_DETAILS tupd on tud.REGISTRATION_NO = tupd.REGISTRATION_NO  
 WHERE USER_TYPE_ID = 5  
)CONTACT ON TRD.CONTACT_PERSON= CONTACT.REGISTRATION_NUMBER  
LEFT JOIN             
   (            
    SELECT DISTINCT p.REGISTRATION_NUMBER,                  
  (SELECT SUBSTRING(    
  (SELECT ',' + TEUA.USER_EMAIL    
  FROM TBL_USER_EMAIL_ADDRESS TEUA    
  WHERE P.REGISTRATION_NUMBER = TEUA.REGISTRATION_NUMBER    
  ORDER BY TEUA.USER_EMAIL    
  FOR XML PATH('')),2,200000)) AS  user_email                    
     FROM TBL_USER_EMAIL_ADDRESS p    WITH(NOLOCK)            
     JOIN TBL_USER_DETAILS TUD ON P.REGISTRATION_NUMBER = TUD.REGISTRATION_NO  
   )user_email ON TRD.CONTACT_PERSON= CONTACT.REGISTRATION_NUMBER  
  
CROSS APPLY FUNC_REQUIREMENT_INDUSTRY_TYPE (TRD.REQUIREMENT_ID)  
CROSS APPLY FUNC_REQUIREMENT_EDUCATION_SPECIALIZATION(TRD.REQUIREMENT_ID)  
WHERE TRD.REQUIREMENT_ID = @REQUIREMENT_ID  
  
--SECTION 2   
  
SELECT COUNT(TUD.REQUIREMENT_ID)AS CV_SOURCED,COUNT(TM.PASSPORTID)SHORTLISTED,COUNT(TM.PASSPORTID)SELECTED, COUNT(TM.PASSPORTID) INPROCESS,  
COUNT(TM.PASSPORTID)AS MOBILIZED, COUNT(TVM.REGISTRATION_NUMBER) AS VISA_COUNT  
FROM TBL_USER_DETAILS TUD   
JOIN TBL_REQUIREMENT_DETAILS TRD ON TUD.REQUIREMENT_ID = TRD.REQUIREMENT_ID  
LEFT JOIN TBL_PASSPORT_DETAILS TPD ON TUD.REGISTRATION_NO = TPD.REGISTATION_NUMBER  
LEFT JOIN TBL_MOFA TM ON TPD.PASSPORT_ID = TM.PASSPORTID  
LEFT JOIN TBL_TICKET TT ON TPD.PASSPORT_ID = TT.PASSPORTID  
LEFT JOIN TBL_VISA_MASTER TVM ON TUD.REGISTRATION_NO = TVM.REGISTRATION_NUMBER  
WHERE TRD.REQUIREMENT_ID = @REQUIREMENT_ID  
  
SELECT top 1 TVM.VISA_NUMBER,CONVERT(VARCHAR,TVM.ISSUE_DATE,103)ISSUE_DATE,CONVERT(VARCHAR,TVM.EXPIRY_DATE,103)EXPIRY_DATE  
FROM TBL_USER_DETAILS TUD  
JOIN TBL_REQUIREMENT_DETAILS TRD ON TUD.REQUIREMENT_ID = TRD.REQUIREMENT_ID  
LEFT JOIN TBL_USER_VISA_DETAILS TUVD ON TUD.REGISTRATION_NO= TUVD.REGISTRATION_NUMBER  
JOIN TBL_VISA_MASTER TVM ON TUVD.VISA_ID = TVM.VISA_ID  
WHERE TRD.REQUIREMENT_ID = @REQUIREMENT_ID  

END 



GO
/****** Object:  StoredProcedure [dbo].[PROC_REQUIREMENT_SEARCH_RESULT]    Script Date: 27-Jan-17 1:15:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create PROC [dbo].[PROC_REQUIREMENT_SEARCH_RESULT]
(
@COMPANY_ID INT = 0,         
@IS_ACTIVE bit =null ,     
@CLIENT_NAME VARCHAR(70) =null,    
@JOB_TITLE varchar(100)=null
)
AS
BEGIN

DECLARE @ConditionBit bit=0
IF(@IS_ACTIVE is not null)
SET @ConditionBit=CASE WHEN @IS_ACTIVE=1 THEN 0 
						WHEN @IS_ACTIVE=0 THEN 1 END
SELECT TRD.REQUIREMENT_ID, COMPANY_NAME,    
    ISNULL( COMPANY_NAME,ISNULL(CONTACT_PERSON.NAME,TCM.CONTACT_PERSON))AS CLIENT_NAME,  TRD.IS_ACTIVE,   
    CASE WHEN (TRD.IS_ACTIVE=1) THEN 'ACTIVE' ELSE 'INACTIVE' END AS 'STATUS'
    FROM TBL_REQUIREMENT_DETAILS TRD WITH(NOLOCK)    
    LEFT JOIN TBL_COMPANY_MASTER TCM WITH(NOLOCK) ON TRD.COMPANY_ID = TCM.COMPANY_ID  	
    LEFT JOIN    
    (    
    SELECT TUD.REGISTRATION_NO,(ISNULL(tupd.FIRST_NAME,'') +' '+ ISNULL(tupd.LAST_NAME,''))NAME,TUD.REQUIREMENT_ID    
    FROM TBL_USER_DETAILS TUD     
    join TBL_USER_PERSONAL_DETAILS tupd on tud.REGISTRATION_NO = tupd.REGISTRATION_NO    
    WHERE USER_TYPE_ID = 5    
    )CONTACT_PERSON ON TRD.CONTACT_PERSON = CONTACT_PERSON.REGISTRATION_NO    
	Where
    ((TRD.IS_ACTIVE = @IS_ACTIVE AND @IS_ACTIVE is not null) OR ISNULL(@IS_ACTIVE,0)=@ConditionBit)

	AND ( TRD.COMPANY_ID = @COMPANY_ID OR ISNULL(@COMPANY_ID,0)=0 )        
	AND (TRD.JOB_TITLE=@JOB_TITLE OR ISNULL(@JOB_TITLE,'')='')
    AND ((ISNULL( TCM.COMPANY_NAME,ISNULL(CONTACT_PERSON.NAME,TCM.CONTACT_PERSON)) LIKE '%'+@CLIENT_NAME+'%') 
    OR ISNULL(@CLIENT_NAME,'')='')
	
	END  
    

GO
/****** Object:  StoredProcedure [dbo].[PROC_SELECT_MASTER]    Script Date: 27-Jan-17 1:15:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[PROC_SELECT_MASTER]
(
 @CONDITIONAL_OPERATOR VARCHAR(30) =NULL
)
AS
BEGIN
	IF @CONDITIONAL_OPERATOR='AVAILING_TYPE'
		BEGIN
			SELECT AvAILING_TYPE_ID, AvAILING_TYPE FROM TBL_AVAILING_TYPE_MASTER
			WHERE IS_ACTIVE =1 ORDER BY TYPE_ORDER
			RETURN
		END
		
	ELSE IF @CONDITIONAL_OPERATOR ='SOURCE'
		BEGIN
			SELECT SOURCE_ID,SOURCE_NAME FROM TBL_SOURCE_MASTER
			WHERE IS_ACTIVE =1 ORDER BY SOURCE_ORDER
			RETURN
		END
		
	ELSE IF @CONDITIONAL_OPERATOR='STATUS'
		BEGIN
			SELECT STATUS_ID,STATUS_NAME FROM TBL_STATUS_MASTER
			WHERE IS_ACTIVE = 1 ORDER BY STATUS_ORDER
			RETURN
		END
		
	ELSE IF @CONDITIONAL_OPERATOR='AD_MEDIUM'
		BEGIN
			SELECT AD_MEDIUM_ID,AD_MEDIUM_TYPE FROM TBL_AD_MEDIUM_MASTER
			WHERE IS_ACTIVE =1 ORDER BY DISPLAY_ORDER
			RETURN
		END
		
	ELSE IF @CONDITIONAL_OPERATOR ='ADDRESS_TYPE'
		BEGIN
			SELECT ADDRESS_TYPE_ID,ADDRESS_TYPE FROM TBL_ADDRESS_TYPE_MASTER
			WHERE IS_ACTIVE =1 ORDER BY DISPLAY_ORDER
			RETURN
		END
		
	ELSE IF @CONDITIONAL_OPERATOR='CAREER_STATUS'
		BEGIN
			SELECT CAREER_STATUS_ID,CAREER_STATUS_TYPE FROM TBL_CAREER_STATUS_MASTER
			WHERE IS_ACTIVE =1 ORDER BY STATUS_ORDER
			RETURN 
		END
		
	ELSE IF @CONDITIONAL_OPERATOR ='CITY'
		BEGIN
			SELECT CITY_CODE,STATE_CODE,CITY_NAME FROM TBL_CITY_MASTER
			WHERE IS_ACTIVE =1 ORDER BY CITY_NAME
			RETURN
		END

	ELSE IF @CONDITIONAL_OPERATOR ='CONTACT_TYPE'
		BEGIN
			SELECT CONTACT_TYPE_ID,CONTACT_TYPE FROM TBL_CONTACT_TYPE_MASTER
			WHERE IS_ACTIVE =1 ORDER BY DISPLAY_ORDER
			RETURN
		END

	ELSE IF @CONDITIONAL_OPERATOR ='CONTACT_TYPE'
		BEGIN
			SELECT CONTACT_TYPE_ID,CONTACT_TYPE FROM TBL_CONTACT_TYPE_MASTER
			WHERE IS_ACTIVE =1 ORDER BY DISPLAY_ORDER
			RETURN
		END
	ELSE IF @CONDITIONAL_OPERATOR ='COUNTRY'
		BEGIN
			SELECT COUNTRY_CODE,COUNTRY_NAME FROM TBL_COUNTRY_MASTER
			WHERE IS_ACTIVE =1 ORDER BY COUNTRY_NAME
			RETURN
		END
		
	ELSE IF @CONDITIONAL_OPERATOR ='CURRENCY'
		BEGIN
			SELECT CURRENCY_ID,CURRENCY_NAME,CURRENCY_SYMBOL FROM TBL_CURRENCY_MASTER
			WHERE IS_ACTIVE =1 ORDER BY DISPLAY_ORDER
			RETURN
		END

	ELSE IF @CONDITIONAL_OPERATOR ='DESIGNATION'
		BEGIN
			SELECT DESIGNATION_ID,DESIGNATION_NAME FROM TBL_DESIGNATION_MASTER
			WHERE IS_ACTIVE =1 ORDER BY DESIGNaTION_NAME
			RETURN
		END
		
	ELSE IF @CONDITIONAL_OPERATOR ='EDUCATION_TYPE'
		BEGIN
			SELECT EDUCATION_TYPE_ID,EDUCATION_TYPE FROM TBL_EDUCATION_TYPE_MASTER
			WHERE IS_ACTIVE =1 ORDER BY EDUCATION_TYPE
			RETURN
		END
		
	ELSE IF @CONDITIONAL_OPERATOR ='EDUCATION_TYPE'
		BEGIN
			SELECT EMAIL_TYPE_ID,EMAIL_TYPE FROM TBL_EMAIL_TYPE_MASTER
			WHERE IS_ACTIVE =1 ORDER BY DISPLAY_ORDER
			RETURN
		END

	ELSE IF @CONDITIONAL_OPERATOR ='GENDER'
		BEGIN
			SELECT GENDER_CODE,GENDER_NAME,GENDER_ORDER,IS_ACTIVE FROM TBL_GENDER_MASTER
			WHERE IS_ACTIVE =1 ORDER BY GENDER_ORDER
			RETURN
		END

	ELSE IF @CONDITIONAL_OPERATOR ='INDUSTRY_TYPE'
		BEGIN
			SELECT INDUSTRY_ID,INDUSTRY_TYPE FROM TBL_INDUSTRY_MASTER
			WHERE IS_ACTIVE =1 ORDER BY INDUSTRY_TYPE
			RETURN
		END

	ELSE IF @CONDITIONAL_OPERATOR ='INTERVIEW_MODE'
		BEGIN
			SELECT INTERVIEW_MODE_ID,INTERVIEW_MODE,DISPLAY_ORDER FROM TBL_INTERVIEW_MODE_MASTER
			WHERE IS_ACTIVE =1 ORDER BY DISPLAY_ORDER
			RETURN
		END

	ELSE IF @CONDITIONAL_OPERATOR ='MARITAL_STATUS'
		BEGIN
			SELECT MARITAL_STATUS_ID,MARITAL_STATUS FROM TBL_MARITAL_STATUS_MASTER
			WHERE IS_ACTIVE =1 ORDER BY MARITAL_STATUS_ORDER
			RETURN
		END

	ELSE IF @CONDITIONAL_OPERATOR ='PREFIX'
		BEGIN
			SELECT PREFIX_ID,PREFIX FROM TBL_PREFIX_MASTER
			WHERE IS_ACTIVE =1 ORDER BY PREFIX_ORDER
			RETURN
		END


	ELSE IF @CONDITIONAL_OPERATOR ='RELIGION'
		BEGIN
			SELECT RELIGION_ID,RELIGION_NAME,RELIGION_ORDER FROM TBL_RELIGION_MASTER
			WHERE IS_ACTIVE =1 ORDER BY RELIGION_ORDER
			RETURN
		END
		
	ELSE IF @CONDITIONAL_OPERATOR ='SPECIALIZATION_TYPE'
		BEGIN
			SELECT SPECIALIZATION_ID,SPECIALIZATION_TYPE,IS_ACTIVE FROM TBL_SPECIALIZATION_MASTER
			WHERE IS_ACTIVE =1 ORDER BY SPECIALIZATION_TYPE
			RETURN
		END	
	
	ELSE IF @CONDITIONAL_OPERATOR ='UNIVERSITY'
		BEGIN
			SELECT UNIVERSITY_ID,UNIVERSITY_NAME FROM TBL_UNIVERSITY_MASTER
			WHERE IS_ACTIVE =1 ORDER BY UNIVERSITY_NAME
			RETURN
		END	
		
	ELSE IF @CONDITIONAL_OPERATOR ='DOCUMENT_TYPE'
		BEGIN
			SELECT DOCUMENT_TYPE_ID,DOCUMENT_TYPE FROM TBL_USER_DOCUMENT_MASTER
			WHERE IS_ACTIVE =1 ORDER BY DOCUMENT_TYPE
			RETURN
		END	







END




GO
/****** Object:  StoredProcedure [dbo].[PROC_STATUS_SEARCH]    Script Date: 27-Jan-17 1:15:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[PROC_STATUS_SEARCH]    
(    
@REGISTRATION_NUMBER VARCHAR(20) ='',     
@PASSPORT_NUMBER VARCHAR(20) ='',    
@CANDIDATE_NAME VARCHAR(70) ='',     
@DATE_OF_BIRTH DATE = NULL,     
@CONTACT_NUMBER VARCHAR(11) ='',     
@REQUIREMENT_ID INT = 0,    
@COMPANY_ID INT = 0,     
@CONDITIONAL_OPERATOR VARCHAR(30) ='REQUIREMENT',     
@ALL_PENDING int = 0,     
@CLIENT_NAME VARCHAR(70) =''    
)    
AS     
BEGIN     
    
 IF @CONDITIONAL_OPERATOR = 'CANDIDATE'    
  BEGIN    
   SELECT * FROM     
   (    
   SELECT TUD.REGISTRATION_NO, CONVERT(VARCHAR(12),TUD.CREATED_DATE,103) REGISTRATION_DATE ,    
   ltrim(rtrim(isnull(FIRST_NAME + ' ',' '))) +' ' + ltrim(rtrim(isnull(MIDDLE_NAME + ' ','')))+ ' ' +    
   ltrim(rtrim(isnull(LAST_NAME,''))) AS CANDIDATE_NAME, CONVERT(VARCHAR(12),DATE_OF_BIRTH,103)DATE_OF_BIRTH,    
   PASSPORT_NUMBER,CONTACT_NO     
   FROM TBL_USER_DETAILS TUD WITH (NOLOCK)    
   JOIN TBL_USER_PERSONAL_DETAILS TPD WITH(NOLOCK) ON TUD.REGISTRATION_NO = TPD.REGISTRATION_NO    
   LEFT JOIN TBL_PASSPORT_DETAILS TPAD WITH (NOLOCK)ON TUD.REGISTRATION_NO = TPAD.REGISTATION_NUMBER    
   LEFT JOIN             
   (            
   SELECT DISTINCT p.REGISTRATION_NUMBER,                  
   (SELECT SUBSTRING(    
   (SELECT ',' + TUC.CONTACT_NO    
   FROM TBL_USER_CONTACTS TUC    
   WHERE P.REGISTRATION_NUMBER = TUC.REGISTRATION_NUMBER    
   ORDER BY TUC.USER_CONTACT_ID    
   FOR XML PATH('')),2,200000)) AS CONTACT_NO                    
   FROM TBL_USER_CONTACTS p WITH (NOLOCK)            
   )CONTACT ON TUD.REGISTRATION_NO = CONTACT.REGISTRATION_NUMBER    
   WHERE TUD.USER_TYPE_ID=1 AND (TUD.REGISTRATION_NO = @REGISTRATION_NUMBER OR ISNULL(@REGISTRATION_NUMBER,'') ='')    
   AND (ISNULL(@PASSPORT_NUMBER,'')='' OR PASSPORT_NUMBER= @PASSPORT_NUMBER)    
   AND (ISNULL(@DATE_OF_BIRTH,'') ='' OR CONVERT(DATE,DATE_OF_BIRTH) = @DATE_OF_BIRTH)    
   AND (ISNULL(@CONTACT_NUMBER,'')='' OR CONTACT_NO LIKE '%' + @CONTACT_NUMBER +'%')    
   )CAND    
   WHERE (ISNULL(@CANDIDATE_NAME,'')='' OR CANDIDATE_NAME LIKE '%' + @CANDIDATE_NAME + '%')    
    
  END     
      
  ELSE IF @CONDITIONAL_OPERATOR = 'REQUIREMENT'    
   BEGIN     
    SELECT TRD.REQUIREMENT_ID, TRD.COMPANY_ID, COMPANY_NAME,    
    ISNULL( COMPANY_NAME,ISNULL(CONTACT_PERSON.NAME,TCM.CONTACT_PERSON))AS CLIENT_NAME,     
    CASE WHEN TRD.IS_ACTIVE = 1 THEN 'YES' ELSE 'NO' END AS ALL_PENDING    
    FROM TBL_REQUIREMENT_DETAILS TRD WITH(NOLOCK)    
    LEFT JOIN TBL_COMPANY_MASTER TCM WITH(NOLOCK) ON TRD.COMPANY_ID = TCM.COMPANY_ID    
    LEFT JOIN    
    (    
    SELECT TUD.REGISTRATION_NO,(ISNULL(tupd.FIRST_NAME,'') +' '+ ISNULL(tupd.LAST_NAME,''))NAME,TUD.REQUIREMENT_ID    
    FROM TBL_USER_DETAILS TUD     
    join TBL_USER_PERSONAL_DETAILS tupd on tud.REGISTRATION_NO = tupd.REGISTRATION_NO    
    WHERE USER_TYPE_ID = 5    
    )CONTACT_PERSON ON TRD.CONTACT_PERSON = CONTACT_PERSON.REGISTRATION_NO    
        
    WHERE (TRD.REQUIREMENT_ID = @REQUIREMENT_ID OR ISNULL(@REQUIREMENT_ID,0) = 0)    
    AND ( TRD.COMPANY_ID = @COMPANY_ID OR ISNULL(@COMPANY_ID,0)=0 )    
    AND (TRD.IS_ACTIVE = @ALL_PENDING OR ISNULL(@ALL_PENDING,0)=0)    
    AND ((TRD.COMPANY_ID = @COMPANY_ID OR ISNULL(@COMPANY_ID,0)=0) OR (CONTACT_PERSON.NAME LIKE '%'+@CLIENT_NAME+'%'     
    OR ISNULL(CONTACT_PERSON.NAME,'')=''))    
        
   END     
    
END 
GO
/****** Object:  StoredProcedure [dbo].[PROC_STATUS_SEARCH_CANDIDATE]    Script Date: 27-Jan-17 1:15:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[PROC_STATUS_SEARCH_CANDIDATE]    
(   
@REGISTRATION_NUMBER VARCHAR(20) =NULL,     
@PASSPORT_NUMBER VARCHAR(20) =NULL,    
@CANDIDATE_NAME VARCHAR(100) =NULL,     
@DATE_OF_BIRTH DATE = NULL,     
@CONTACT_NUMBER VARCHAR(50) =NULL,
@USER_TYPE_ID INT= NULL
)
AS 
BEGIN
	SELECT * FROM     
	(    
	SELECT TUD.REGISTRATION_NO, CONVERT(VARCHAR(12),TUD.CREATED_DATE,103) REGISTRATION_DATE ,    
	ltrim(rtrim(isnull(FIRST_NAME + ' ',' '))) +' ' + ltrim(rtrim(isnull(MIDDLE_NAME + ' ','')))+ ' ' +    
	ltrim(rtrim(isnull(LAST_NAME,''))) AS CANDIDATE_NAME, DATE_OF_BIRTH,    
	PASSPORT_NUMBER,CONTACT_NO     
	FROM TBL_USER_DETAILS TUD WITH (NOLOCK)    
	JOIN TBL_USER_PERSONAL_DETAILS TPD WITH(NOLOCK) ON TUD.REGISTRATION_NO = TPD.REGISTRATION_NO    
	LEFT JOIN TBL_PASSPORT_DETAILS TPAD WITH (NOLOCK)ON TUD.REGISTRATION_NO = TPAD.REGISTATION_NUMBER    
	LEFT JOIN             
	(            
		SELECT DISTINCT p.REGISTRATION_NUMBER,                  
		(SELECT SUBSTRING(    
		(SELECT ',' + TUC.CONTACT_NO    
		FROM TBL_USER_CONTACTS TUC    
		WHERE P.REGISTRATION_NUMBER = TUC.REGISTRATION_NUMBER    
		ORDER BY TUC.USER_CONTACT_ID    
		FOR XML PATH('')),2,200000)) AS CONTACT_NO                    
		FROM TBL_USER_CONTACTS p WITH (NOLOCK)            
	)CONTACT ON TUD.REGISTRATION_NO = CONTACT.REGISTRATION_NUMBER    
	WHERE TUD.USER_TYPE_ID=@USER_TYPE_ID 
	AND (TUD.REGISTRATION_NO = @REGISTRATION_NUMBER  OR ISNULL(@REGISTRATION_NUMBER,'') ='')    
	AND (ISNULL(@PASSPORT_NUMBER,'')='' OR PASSPORT_NUMBER LIKE '%' +@PASSPORT_NUMBER + '%')    
	AND (ISNULL(@DATE_OF_BIRTH,'') ='' OR CONVERT(DATE,DATE_OF_BIRTH) = @DATE_OF_BIRTH)    
	AND (ISNULL(@CONTACT_NUMBER,'')='' OR CONTACT_NO LIKE '%' + @CONTACT_NUMBER +'%')    
	)CAND    
	WHERE (ISNULL(@CANDIDATE_NAME,'')='' OR CANDIDATE_NAME LIKE '%' + @CANDIDATE_NAME + '%')    
END
GO
/****** Object:  StoredProcedure [dbo].[PROC_TASK_MASTER]    Script Date: 27-Jan-17 1:15:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
      
-- Exec  PROC_TASK_MASTER 'SELECT_ALLTASK'      
CREATE PROC [dbo].[PROC_TASK_MASTER]      
(        
 @CONDITIONAL_OPERATOR VARCHAR(30) =NULL  ,    
 @REGISTRATION_NO varchar(20) =null,     
 @TASK_ID INT =null    
)      
 AS       
 BEGIN      
     
SELECT TUPD.REGISTRATION_NO,UPPER(          
ISNULL(FIRST_NAME + SPACE(1),'') + ISNULL(MIDDLE_NAME + SPACE(1),'') +          
ISNULL(LAST_NAME,'')) EMPLOYEE_NAME,IS_ACTIVE into #TEMP FROM TBL_USER_PERSONAL_DETAILS TUPD          
JOIN TBL_USER_DETAILS TUD ON TUPD.REGISTRATION_NO = TUD.REGISTRATION_NO          
WHERE  USER_TYPE_ID = 2      
    
     
 IF @CONDITIONAL_OPERATOR = 'SELECT_ALLTASK'      
  BEGIN      
      
    SELECT TTM.TASK_ID,TTM.TASK_NAME,TTM.PERC_COMPLETED,TTM.TASK_COMMENT,      
    --CREATED_BY.EMPLOYEE_NAME + SPACE(1) + '/' +      
    CONVERT(VARCHAR(12),TTM.CREATED_DATE,13)      
 ASSIGNEDBY,ASSIGNED_TO.EMPLOYEE_NAME ASSIGNEDTO,      
    MODIFIED_BY.EMPLOYEE_NAME + SPACE(1) + '/' + CONVERT(VARCHAR(12),TTM.MODIFIED_DATE,13) UPDATEDBY      
    FROM TBL_TASK_MASTER TTM       
    JOIN     
    (SELECT TASK_ID FROM TBL_TASK_FOLLOWUP GROUP BY TASK_ID )    
    TTF ON TTM.TASK_ID = TTF.TASK_ID      
    JOIN #TEMP ASSIGNED_TO ON TTM.TASK_ASSIGNED_TO = ASSIGNED_TO.REGISTRATION_NO      
    JOIN #TEMP CREATED_BY ON TTM.CREATED_BY = CREATED_BY.REGISTRATION_NO      
    JOIN #TEMP MODIFIED_BY ON TTM.MODIFIED_BY = MODIFIED_BY.REGISTRATION_NO      
    WHERE TTM.CREATED_BY = @REGISTRATION_NO OR TTM.TASK_ASSIGNED_TO = @REGISTRATION_NO     
    ORDER BY TTM.TASK_ID DESC  
  END      
        
 ELSE IF @CONDITIONAL_OPERATOR = 'FOLLOWUP'      
  BEGIN      
	  SELECT TASK_FOLLOWUP_ID,TASK_ID,TASK_COMMENT,PERC_COMPLETED,CREATED_DATE,tm.EMPLOYEE_NAME CREATED_BY     
	  FROM TBL_TASK_FOLLOWUP TTF with (nolock)    
	  JOIn #temp tm on ttf.CREATED_BY = tm.REGISTRATION_NO    
	  WHERE task_id = @TASK_ID 
  END  
  
 ELSE IF @CONDITIONAL_OPERATOR ='OPENTASK'
	BEGIN
		SELECT COUNT (1) OPEN_TASK FROM TBL_TASK_MASTER WITH(NOLOCK) WHERE 
		(CREATED_BY = @REGISTRATION_NO
		 OR TASK_ASSIGNED_TO =  @REGISTRATION_NO) AND PERC_COMPLETED <100
	
	END     
        
  END    

GO
/****** Object:  StoredProcedure [dbo].[PROC_UPDATE_CANDIDATE]    Script Date: 27-Jan-17 1:15:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,Rohan>
-- Create date: <Create Date,14-01-2017>
-- Description:	<Description,to update user details>
-- =============================================
CREATE PROCEDURE [dbo].[PROC_UPDATE_CANDIDATE]
	-- Add the parameters for the stored procedure here
	@USER_DETAIL as [dbo].UDT_USER_DETAILS READONLY,
	@CONDITIONAL_OPERATOR varchar(100) = null,
	@USER_PASSPORT as [dbo].UDT_USER_PASSPORT READONLY,
	@USER_DRIVING as [dbo].UDT_USER_DRIVING READONLY,
	@USER_EDUCATION as [dbo].UDT_USER_EDUCATION READONLY
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	if(@CONDITIONAL_OPERATOR = 'UPDATE PERSONAL DETAILS')
	BEGIN
	Update USER_DETAILS
	set User_DETAILS.FIRST_NAME = UDT_DETAILS.FIRST_NAME,
		User_DETAILS.LAST_NAME = UDT_DETAILS.LAST_NAME,
		User_DETAILS.MIDDLE_NAME = UDT_DETAILS.MIDDLE_NAME,
		User_Details.DATE_OF_BIRTH = UDT_DETAILS.DATE_OF_BIRTH,
		USER_DETAILS.PLACE_OF_BIRTH = UDT_DETAILS.PLACE_OF_BIRTH,
		USER_DETAILS.GENDER_CODE = UDT_DETAILS.GENDER_CODE,

		USER_DETAILS.MARITAL_STATUS_ID = UDT_DETAILS.MARITAL_STATUS_ID,
		USER_DETAILS.NATIONALITY_ID = UDT_DETAILS.NATIONALITY_ID,
		USER_DETAILS.CURRENT_LOCATION = UDT_DETAILS.CURRENT_LOCATION,
		USER_DETAILS.RELIGION_ID = UDT_DETAILS.RELIGION_ID

	from @USER_DETAIL UDT_DETAILS
	Join TBL_USER_PERSONAL_DETAILS USER_DETAILS
	on UDT_DETAILS.REGISTRATION_NO = USER_DETAILS.REGISTRATION_NO

	--PASSPORT DETAILS
	--Update PASSPORT_DETAILS
	--set PASSPORT_DETAILS.PASSPORT_NUMBER = UDT_DETAILS.PASSPORT_NUMBER,
	--	PASSPORT_DETAILS.DATE_OF_ISSUE = UDT_DETAILS.DATE_OF_ISSUE,
	--	PASSPORT_DETAILS.PLACE_OF_ISSUE = UDT_DETAILS.PLACE_OF_ISSUE,
	--	PASSPORT_DETAILS.DATE_OF_EXPIRY = UDT_DETAILS.DATE_OF_EXPIRY,
	--	PASSPORT_DETAILS.EMIGRATION_CLEARANCE_REQUIRED = UDT_DETAILS.EMIGRATION_CLEARANCE_REQUIRED

	--from @USER_DETAIL UDT_DETAILS
	--join TBL_PASSPORT_DETAILS  PASSPORT_DETAILS
	--on PASSPORT_DETAILS.REGISTATION_NUMBER = UDT_DETAILS.REGISTRATION_NO

	----DRIVING LICENSE
	--Update DRIVING_LICENSE
	--set DRIVING_LICENSE.DRIVING_LICENCE_NUMBER = UDT_DETAILS.DRIVING_LICENCE_NUMBER,
	--	DRIVING_LICENSE.PLACE_OF_ISSUE = UDT_DETAILS.DRIVING_PLACE_OF_ISSUE,
	--	DRIVING_LICENSE.DATE_OF_ISSUE = UDT_DETAILS.DRIVING_DATE_OF_ISSUE,
	--	DRIVING_LICENSE.EXPIRY_DATE = UDT_DETAILS.DRIVING_EXPIRY_DATE,
	--	DRIVING_LICENSE.VEHICLE_TYPE_ID = UDT_DETAILS.VEHICLE_TYPE_ID,
	--	DRIVING_LICENSE.REMARK = UDT_DETAILS.DRIVING_REMARK
		
	--from @USER_DETAIL UDT_DETAILS
	--join TBL_USER_DRIVING_LICENCE_DETAILS DRIVING_LICENSE
	--on DRIVING_LICENSE.REGISTRATION_NO = UDT_DETAILS.REGISTRATION_NO
	
	--Update USER IMAGE PATH
	Update USER_DETAILS
	set USER_DETAILS.USER_IMAGE_PATH = UDT_DETAILS.FILE_PATH
	from @USER_DETAIL UDT_DETAILS
	join TBL_USER_DETAILS USER_DETAILS
	on USER_DETAILS.REGISTRATION_NO = UDT_DETAILS.REGISTRATION_NO

	SELECT REGISTRATION_NO from @USER_DETAIL
	END

	if(@CONDITIONAL_OPERATOR = 'UPDATE EDUCATION DETAILS')
	BEGIN

	INSERT INTO TBL_USER_EDUCATION_DETAILS
	(
	EDUCATION_TYPE_ID,
	REGISTRATION_NO,
	SPECIALIZATION_TYPE_ID,
	IS_HIGHEST_QUALIFICATION,
	UNIVERSITY_ID,
	UNIVERSITY_YEAR_OF_PASSING,
	CREATED_BY,
	MODIFIED_BY,
	CREATED_DATE,
	MODIFIED_DATE
	)

	Select
	USER_EDU.EDUCATION_TYPE_ID,
	USER_EDU.REGISTRATION_NO,
	USER_EDU.SPECIALIZATION_TYPE_ID,
	USER_EDU.IS_HIGHEST_QUALIFICATION,
	USER_EDU.UNIVERSITY_ID,
	USER_EDU.UNIVERSITY_YEAR_OF_PASSING,
	USER_EDU.CREATED_BY,
	USER_EDU.CREATED_BY,
	GETDATE(),
	GETDATE()

	from @USER_EDUCATION USER_EDU
	where USER_EDU.USER_EDUCATION_ID = 0 and USER_EDU.ISNEW = 1
	
	
	Delete tbl_user_education
	from TBL_USER_EDUCATION_DETAILS TBL_USER_EDUCATION
	JOIN @USER_EDUCATION USER_EDU
	on USER_EDU.USER_EDUCATION_ID = TBL_USER_EDUCATION.USER_EDUCATION_ID
	where USER_EDU.IsNEW = 0

	SELECT REGISTRATION_NO from @USER_EDUCATION
	END
END

GO
/****** Object:  StoredProcedure [dbo].[PROC_UPDATE_USER_STATUS]    Script Date: 27-Jan-17 1:15:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,Rohan>
-- Create date: <Create Date,06/01/2017>
-- Description:	<Description,to update user status after every process>
-- =============================================
CREATE PROCEDURE [dbo].[PROC_UPDATE_USER_STATUS]
	-- Add the parameters for the stored procedure here
	@USER_REQUIREMENT_ID int = null,
	@Status int = null
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Update TBL_USER_DETAILS
	set STATUS_ID = @Status
	where REGISTRATION_NO = (select REGISTRATION_NO from TBL_USER_REQUIREMENT req where USER_REQUIREMENT_ID=@USER_REQUIREMENT_ID)

END


GO
/****** Object:  StoredProcedure [dbo].[PROC_USER_ADDRESS_DETAILS]    Script Date: 27-Jan-17 1:15:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
    
    
-- =============================================                  
-- Author:  <YOGENDRA DUBEY>                  
-- Create date: <26-AUG-2015>                  
-- Description: <STORED PROCEDURE TO INSERT USER DETAILS>                  
-- =============================================                  
CREATE PROCEDURE [dbo].[PROC_USER_ADDRESS_DETAILS]                  
 (                  
 @REGISTRATION_NO varchar(20) =NULL,                  
 @ADDRESS_TYPE_ID int =NULL,                  
 @ADDRESS VARCHAR(80)=NULL,                  
 @CITY_CODE VARCHAR(10)=NULL,                  
 @VILLAGE varchar(50)=NULL,          
 @CONTACT_TYPE_ID INT =NULL,          
 @CONTACT_NO VARCHAR(20)=NULL,                 
 @EMAIL_ID VARCHAR(20)=NULL,                 
 @PIN_CODE VARCHAR(20)=NULL,                  
 @CREATED_BY   varchar(10) =NULL,                   
 @CONDITIONAL_OPERATOR VARCHAR(30) = NULL                  
 )                  
                   
AS                  
BEGIN                  
 -- SET NOCOUNT ON added to prevent extra result sets from                  
 -- interfering with SELECT statements.                  
 SET NOCOUNT ON;                  
 IF @CONDITIONAL_OPERATOR ='SAVE_ADDRESS'                  
  BEGIN                  
   INSERT INTO TBL_USER_ADDRESS(REGISTRATION_NUMBER,ADDRESS_TYPE_ID,ADDRESS,CITY_CODE,USER_VILLAGE,USER_PINCODE,CREATED_BY,CREATED_DATE)                  
   VALUES                   
   (@REGISTRATION_NO,@ADDRESS_TYPE_ID,@ADDRESS,@CITY_CODE,@VILLAGE,@PIN_CODE,@CREATED_BY,GETDATE())              
  END                  
          
 IF @CONDITIONAL_OPERATOR ='SAVE_PHONE'                  
  BEGIN                  
   INSERT INTO TBL_USER_CONTACTS(REGISTRATION_NUMBER,CONTACT_TYPE_ID,CONTACT_NO,CREATED_BY,CREATED_DATE)                  
   VALUES                   
   (@REGISTRATION_NO,@CONTACT_TYPE_ID,@CONTACT_NO,@CREATED_BY,GETDATE())              
  END                            
           
 IF @CONDITIONAL_OPERATOR ='SAVE_EMAIL'                  
  BEGIN                  
   INSERT INTO TBL_USER_EMAIL_ADDRESS(REGISTRATION_NUMBER,USER_EMAIL)                  
   VALUES                   
   (@REGISTRATION_NO,@EMAIL_ID)              
  END                            
                 
END     

GO
/****** Object:  StoredProcedure [dbo].[PROC_USER_CERTIFICATION_LICENCE_VISA_DETAILS]    Script Date: 27-Jan-17 1:15:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================                
-- Author:  <AMBI GUPTA>                
-- Create date: <05-SEP-2015>                
-- Description: <STORED PROCEDURE TO INSERT USER PERSONAL DETAILS>                
-- =============================================                
CREATE PROCEDURE [dbo].[PROC_USER_CERTIFICATION_LICENCE_VISA_DETAILS]                
 (                
 @REGISTRATION_NO varchar(20) =NULL,                
 @CERTIFICATION  varchar(70) =NULL,                
 @CERTIFICATION_LEVEL varchar(20)=NULL,                
 @INSTITUTE varchar(80) =NULL,                
 @YEAR_OF_PASSING INT=NULL,                
 @DRIVING_LICENCE_NUMBER varchar(20)=NULL,                
 @PLACE_OF_ISSUE VARCHAR(20) =NULL,                
 @DATE_OF_ISSUE DATE =NULL,                
 @EXPIRY_DATE  DATE =NULL,                
 @VEHICLE_TYPE_ID INT=NULL,                
 @REMARK VARCHAR(100)=NULL,                
 @CREATED_BY varchar(50) =NULL,                 
 @VISA_ID INT=NULL,                
 @CONDITIONAL_OPERATOR VARCHAR(30) = NULL,                
 @PASSPORT_NUMBER VARCHAR(20) = NULL,      
 @PASSPORT_DATE_OF_ISSUE DATE = NULL,      
 @PASSPORT_PLACE_OF_ISSUE VARCHAR(50) = NULL,      
 @PASSPORT_DATE_OF_EXPIRY DATE = NULL,      
 @EMIGRATION_CLEARANCE_REQUIRED BIT=NULL      
 )                
                 
AS                
BEGIN                
 -- SET NOCOUNT ON added to prevent extra result sets from                
 -- interfering with SELECT statements.                
 SET NOCOUNT ON;                
 IF @CONDITIONAL_OPERATOR ='SAVE_CERTIFICATION'                
  BEGIN                
   INSERT INTO TBL_USER_CERTIFICATION(REGISTRATION_NUMBER,CERTIFICATION,CERTIFICATION_LEVEL,INSTITUTE,YEAR_OF_PASSING)            
   VALUES (@REGISTRATION_NO,@CERTIFICATION,@CERTIFICATION_LEVEL,@INSTITUTE,@YEAR_OF_PASSING)                
  END        
          
  IF @CONDITIONAL_OPERATOR ='SAVE_LICENCE'                
  BEGIN             
   INSERT INTO TBL_USER_DRIVING_LICENCE_DETAILS(REGISTRATION_NO,DRIVING_LICENCE_NUMBER,PLACE_OF_ISSUE,DATE_OF_ISSUE,            
   EXPIRY_DATE,VEHICLE_TYPE_ID,REMARK,CREATED_BY,CREATED_DATE,MODIFIED_BY,MODIFIED_DATE)            
   VALUES (@REGISTRATION_NO,@DRIVING_LICENCE_NUMBER,@PLACE_OF_ISSUE,@DATE_OF_ISSUE,            
   @EXPIRY_DATE,@VEHICLE_TYPE_ID,@REMARK,@CREATED_BY,GETDATE(),@CREATED_BY,GETDATE())            
  END        
  IF @CONDITIONAL_OPERATOR ='SAVE_VISA'                
  BEGIN             
   INSERT INTO TBL_USER_VISA_DETAILS(REGISTRATION_NUMBER,VISA_ID,CREATED_BY,CREATED_DATE,MODIFIED_BY,MODIFIED_DATE)            
   VALUES (@REGISTRATION_NO,@VISA_ID,@CREATED_BY,GETDATE(),@CREATED_BY,GETDATE())                
  END                
  IF @CONDITIONAL_OPERATOR ='SAVE_PASSPORT'                
  BEGIN             
   INSERT INTO TBL_PASSPORT_DETAILS(REGISTATION_NUMBER,PASSPORT_NUMBER,DATE_OF_ISSUE,PLACE_OF_ISSUE,DATE_OF_EXPIRY,EMIGRATION_CLEARANCE_REQUIRED,CREATED_BY,CREATED_DATE,MODIFIED_BY,MODIFIED_DATE)            
   VALUES (@REGISTRATION_NO,@PASSPORT_NUMBER,@PASSPORT_DATE_OF_ISSUE,@PASSPORT_PLACE_OF_ISSUE,@PASSPORT_DATE_OF_EXPIRY,@EMIGRATION_CLEARANCE_REQUIRED,@CREATED_BY,GETDATE(),@CREATED_BY,GETDATE())                
  END                
             
END 




GO
/****** Object:  StoredProcedure [dbo].[PROC_USER_DETAILS]    Script Date: 27-Jan-17 1:15:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



-- =============================================        
    
-- Author:  <YOGENDRA DUBEY>        
    
-- Create date: <26-AUG-2015>        
    
-- Description: <STORED PROCEDURE TO INSERT USER DETAILS>        
    
-- =============================================        
    
CREATE PROCEDURE [dbo].[PROC_USER_DETAILS]                  
 (                  
 @REGISTRATION_NO varchar(20) =NULL,                  
 @USER_TYPE_ID  int =NULL,                  
 @AVAILING_TYPE_ID int =NULL,                  
 @SOURCE_ID   int =NULL,                  
 @STATUS_ID   int =NULL,                  
 @VISIT_NUMBER  int =NULL,                  
 @REQUIREMENT_ID  int =NULL,    
 @LOGIN_PASSWORD varchar(50) = null,                  
 @LOGIN_ACCESS  bit =NULL,                            
 @USER_IMAGE_PATH varchar(100)=NULL,                  
 @REMARK    varchar(150)=NULL,                  
 @CREATED_BY   varchar(10) =NULL,                   
 @IS_EXPERIENCED  bit =NULL,                  
 @CONDITIONAL_OPERATOR VARCHAR(30) = NULL,          
 @WEBSITE VARCHAR(50) = NULL,          
 @SKYPE VARCHAR(50) = NULL,          
 @CONTACT_REMARK VARCHAR(1000) = NULL,          
 @EDUCATION_REMARK VARCHAR(1000) = NULL,          
 @WORK_REMARK VARCHAR(1000) = NULL,          
 @BRANCH_CODE VARCHAR(20)=NULL,                  
 @CIVILIAN_NO VARCHAR(20)=NULL,      
 @NAME VARCHAR(20)=NULL,      
 @CLIENT_DESIGNATION INT=NULL,      
 @CLIENT_INDUSTRY_ID INT=NULL,      
 @REFERENCE VARCHAR(20)=NULL,      
 @GAMCA_NO VARCHAR(20)=NULL,      
 @LOCATION_CODE VARCHAR(20)=NULL ,    
 @MONTH INT = NULL,    
 @YEAR INT = NULL ,    
 @CURRENT_COUNTER INT =NULL,    
 @OTHER_SOURCE VARCHAR(20)=NULL,    
 @REFERRER_NAME VARCHAR(50)=NULL,    
 @FIRST_NAME  varchar(50) ='AMBI',                
 @MIDDLE_NAME varchar(50) =NULL,                
 @LAST_NAME   varchar(50) =NULL,    
 @DATE_OF_BIRTH DATETIME =NULL,                
 @PLACE_OF_BIRTH  varchar(50) =NULL,  
 @TOTAL_WORK_EXPERIENCE VARCHAR(50)=NULL,                
 @TOTAL_GULF_EXPERIENCE varchar(50) =NULL,      
 @SKILL varchar(50) =NULL   
    
)        
    
         
    
AS        
    
BEGIN        
    
 -- SET NOCOUNT ON added to prevent extra result sets from        
    
 -- interfering with SELECT statements.        
    
 SET NOCOUNT ON;        
    
 IF @CONDITIONAL_OPERATOR ='INSERT'        
    
  BEGIN        
   
  IF(@USER_TYPE_ID IN (1,2))
  BEGIN
	  IF EXISTS(SELECT 1 FROM TBL_USER_PERSONAL_DETAILS TUPD WITH(NOLOCK) 
	  JOIN TBL_USER_DETAILS TUD WITH(NOLOCK) ON TUPD.REGISTRATION_NO = TUD.REGISTRATION_NO
	  WHERE FIRST_NAME= @FIRST_NAME AND LAST_NAME=@LAST_NAME 
	  AND PLACE_OF_BIRTH=@PLACE_OF_BIRTH AND CONVERT(DATE,DATE_OF_BIRTH) = CONVERT(DATE,@DATE_OF_BIRTH) AND USER_TYPE_ID = @USER_TYPE_ID)    
	  BEGIN    
	  SELECT 'DUPLIACTE NAME,DOB AND PLACE OF BIRTH.RECORD ALREADY EXISTS' AS Error    
	  RETURN;    
	  END    
  END
  ELSE IF(@USER_TYPE_ID IN (3,4,5))
  BEGIN
	  IF EXISTS(SELECT 1 FROM TBL_USER_PERSONAL_DETAILS TUPD WITH(NOLOCK) 
	  JOIN TBL_USER_DETAILS TUD WITH(NOLOCK) ON TUPD.REGISTRATION_NO = TUD.REGISTRATION_NO
	  WHERE FIRST_NAME= @FIRST_NAME AND LAST_NAME=@LAST_NAME AND USER_TYPE_ID = @USER_TYPE_ID) 
	  BEGIN    
	  SELECT 'DUPLIACTE NAME.RECORD ALREADY EXISTS' AS Error    
	  RETURN;    
	  END    
  END
    
	SET @MONTH = MONTH(GETDATE())    
	SET @YEAR = YEAR(GETDATE())    
    
    
    
 IF EXISTS (SELECT 1 FROM TBL_USER_REGISTRATION with(nolock) WHERE USER_TYPE_ID = @USER_TYPE_ID AND REG_MONTH = @MONTH AND REG_YEAR = @YEAR)    
    
  BEGIN    
    
   SELECT @CURRENT_COUNTER = CURRENT_COUNTER FROM TBL_USER_REGISTRATION with(nolock)     
   WHERE USER_TYPE_ID = @USER_TYPE_ID AND REG_MONTH = @MONTH AND REG_YEAR = @YEAR    
       
    
   SELECT @REGISTRATION_NO = LEFT(USER_TYPE,1) + CONVERT(VARCHAR, @MONTH) + CONVERT(VARCHAR, @YEAR) +      
    
   REPLICATE ('0',4- LEN(@CURRENT_COUNTER + 1)) + CONVERT(VARCHAR,@CURRENT_COUNTER +1)     
    
   FROM TBL_USER_TYPE with(nolock) WHERE  USER_TYPE_ID = @USER_TYPE_ID    
    
    
    
   UPDATE TBL_USER_REGISTRATION SET CURRENT_COUNTER = CURRENT_COUNTER +1     
    
   WHERE USER_TYPE_ID = @USER_TYPE_ID AND REG_MONTH = @MONTH AND REG_YEAR = @YEAR    
    
  END     
    
    
    
    
    
 ELSE     
    
  BEGIN    
    
    
    
   SET @CURRENT_COUNTER = 0    
    
    
   SELECT @REGISTRATION_NO = LEFT(USER_TYPE,1) + CONVERT(VARCHAR, @MONTH) + CONVERT(VARCHAR, @YEAR) +      
    
   REPLICATE ('0',4- LEN(@CURRENT_COUNTER + 1)) + CONVERT(VARCHAR,@CURRENT_COUNTER +1)      
    
   FROM TBL_USER_TYPE with(nolock) WHERE  USER_TYPE_ID = @USER_TYPE_ID    
    
       
   INSERT INTO TBL_USER_REGISTRATION (REG_MONTH,REG_YEAR,USER_TYPE_ID,CURRENT_COUNTER)    
    
   VALUES (@MONTH, @YEAR, @USER_TYPE_ID,1)    
    
  END     
    
      
    
      
    
    INSERT INTO TBL_USER_DETAILS(REGISTRATION_NO,USER_TYPE_ID,AVAILING_TYPE_ID,SOURCE_ID,                  
    
    STATUS_ID,VISIT_NUMBER,REQUIREMENT_ID,LOGIN_ACCESS,USER_IMAGE_PATH,REMARK,CREATED_BY,CREATED_DATE,                  
    
    MODIFIED_BY,MODIFIED_DATE,IS_EXPERIENCED,WEBSITE,SKYPE,CONTACT_REMARK,EDUCATION_REMARK,WORK_REMARK,BRANCH_CODE,      
    
    CIVILIAN_NO,COMPANY_NAME,DESIGNATION_ID,INDUSTRY_ID ,REFERENCE ,GAMCA_NO,LOCATION_CODE ,REFERRER_NAME,OTHER_SOURCE,  
    TOTAL_GULF_EXPERIENCE,TOTAL_WORK_EXPERIENCE,SKILLS)        
    
    VALUES         
    
    (               
  @REGISTRATION_NO,@USER_TYPE_ID,@AVAILING_TYPE_ID,@SOURCE_ID,@STATUS_ID,@VISIT_NUMBER,                  
    
  @REQUIREMENT_ID,@LOGIN_ACCESS,@USER_IMAGE_PATH,@REMARK,@CREATED_BY,GETDATE(),                  
    
  @CREATED_BY,GETDATE(),@IS_EXPERIENCED  ,@WEBSITE,@SKYPE,@CONTACT_REMARK,@EDUCATION_REMARK,@WORK_REMARK,@BRANCH_CODE,      
    
  @CIVILIAN_NO,@NAME,@CLIENT_DESIGNATION,@CLIENT_INDUSTRY_ID ,@REFERENCE ,@GAMCA_NO,@LOCATION_CODE,@REFERRER_NAME,@OTHER_SOURCE,    
  @TOTAL_GULF_EXPERIENCE,@TOTAL_WORK_EXPERIENCE,@SKILL)     
    
  SELECT 'Successfull' AS Error ,@REGISTRATION_NO as TOTAL    
    
  END        
    
          
    
 ELSE IF @CONDITIONAL_OPERATOR='UPDATE'        
    
  BEGIN        
    
    UPDATE TBL_USER_DETAILS         
    
    SET AVAILING_TYPE_ID = @AVAILING_TYPE_ID,SOURCE_ID=@SOURCE_ID,        
    
    STATUS_ID = @STATUS_ID, VISIT_NUMBER=@VISIT_NUMBER,        
    
    REQUIREMENT_ID = @REQUIREMENT_ID,LOGIN_ACCESS= @LOGIN_ACCESS,        
    
    USER_IMAGE_PATH=@USER_IMAGE_PATH,        
    
    REMARK =@REMARK, MODIFIED_BY = @CREATED_BY, MODIFIED_DATE = GETDATE()        
    
    WHERE REGISTRATION_NO = @REGISTRATION_NO          
    
  END        
    
END  

GO
/****** Object:  StoredProcedure [dbo].[PROC_USER_EDUCATION_WORK_DETAILS]    Script Date: 27-Jan-17 1:15:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================                    
-- Author:  <AMBI GUPTA>                    
-- Create date: <05-SEP-2015>                    
-- Description: <STORED PROCEDURE TO INSERT USER PERSONAL DETAILS>                    
-- =============================================                    
CREATE PROCEDURE [dbo].[PROC_USER_EDUCATION_WORK_DETAILS]            
 (                    
 @REGISTRATION_NO varchar(20) =NULL,                    
 @EDUCATION_TYPE_ID INT =NULL,                    
 @SPECIALIZATION_TYPE_ID INT =NULL,                    
 @UNIVERSITY_ID varchar(70) =NULL,                    
 @UNIVERSITY_YEAR_OF_PASSING VARCHAR(8)=NULL,                    
 @COMPANY_ID INT=NULL,                    
 @IS_CURRENT_COMPANY BIT =NULL,                    
 @IS_EXPERIENCED BIT=NULL,                    
 @DESIGNATION_ID INT=NULL,                    
 @INDUSTRY_ID INT=NULL,                    
 @CITY_CODE VARCHAR(20)=NULL,                    
 @TOTAL_WORK_EXPERIENCE DECIMAL=NULL,            
 @CREATED_BY varchar(50) =NULL,                     
 @CONDITIONAL_OPERATOR VARCHAR(30) = NULL,          
 @LANGUAGE_ID INT =NULL,          
 @IS_READ BIT =NULL,          
 @IS_WRITE BIT = NULL,          
 @IS_SPEAK BIT=NULL,        
 @DOCUMENT_TYPE_ID varchar(20) =null,        
 @DOCUMENT_PATH  varchar(200)=null,        
 @IS_HIGHEST_QUALIFICATION BIT=NULL,    
 @WORK_PERIOD_FROM DATETIME=NULL,    
 @WORK_PERIOD_TO DATETIME=NULL  
 )                    
    
                     
    
AS                    
    
BEGIN                    
    
 -- SET NOCOUNT ON added to prevent extra result sets from                    
    
 -- interfering with SELECT statements.                    
    
 SET NOCOUNT ON;                    
    
 IF @CONDITIONAL_OPERATOR ='SAVE_EDUCATION'                    
    
  BEGIN                    
    
   INSERT INTO TBL_USER_EDUCATION_DETAILS(REGISTRATION_NO,EDUCATION_TYPE_ID,SPECIALIZATION_TYPE_ID,UNIVERSITY_ID,UNIVERSITY_YEAR_OF_PASSING,CREATED_BY,CREATED_DATE,MODIFIED_DATE,IS_HIGHEST_QUALIFICATION)                
    
   VALUES (@REGISTRATION_NO,@EDUCATION_TYPE_ID,@SPECIALIZATION_TYPE_ID,@UNIVERSITY_ID,@UNIVERSITY_YEAR_OF_PASSING,@CREATED_BY,GETDATE(),GETDATE(),@IS_HIGHEST_QUALIFICATION)                    
    
  END            
    
              
    
  IF @CONDITIONAL_OPERATOR ='SAVE_WORK'                    
  BEGIN                 
    
   INSERT INTO TBL_USER_EXPERIENCE(REGISTRATION_NO,USER_COMPANY_NAME,IS_CURRENT_COMPANY,DESIGNATION_ID,INDUSTRY_ID,CITY_CODE,TOTAL_WORK_EXPERIENCE,CREATED_BY,CREATED_DATE,MODIFIED_BY,MODIFIED_DATE,WORK_PERIOD_FROM,WORK_PERIOD_TO)                
    
   VALUES (@REGISTRATION_NO,@COMPANY_ID,@IS_CURRENT_COMPANY,@DESIGNATION_ID,@INDUSTRY_ID,@CITY_CODE,@TOTAL_WORK_EXPERIENCE,@CREATED_BY,GETDATE(),@CREATED_BY,GETDATE(),@WORK_PERIOD_FROM,@WORK_PERIOD_TO)                
    
  END          
    
          
    
  IF @CONDITIONAL_OPERATOR ='SAVE_DOC'                    
    
  BEGIN                 
    
   INSERT INTO TBL_USER_DOCUMENTS(REGISTRATION_NO,DOCUMENT_TYPE_ID,DOCUMENT_PATH,CREATED_BY,CREATED_DATE,MODIFIED_BY,MODIFIED_DATE)                
    
   VALUES (@REGISTRATION_NO,@DOCUMENT_TYPE_ID,@DOCUMENT_PATH,@CREATED_BY,GETDATE(),@CREATED_BY,GETDATE())                
    
  END        
    
            
    
  IF @CONDITIONAL_OPERATOR ='SAVE_LANGUAGE'                    
    
  BEGIN                 
    
   INSERT INTO TBL_USER_LANGUAGE(REGISTRATION_NO,LANGUAGE_ID,IS_READ,IS_WRITE,IS_SPEAK)                
    
   VALUES (@REGISTRATION_NO,@LANGUAGE_ID,@IS_READ,@IS_WRITE,@IS_SPEAK)                
    
  END          
    
            
    
                 
    
END 

GO
/****** Object:  StoredProcedure [dbo].[PROC_USER_GETMASTER]    Script Date: 27-Jan-17 1:15:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create PROCEDURE [dbo].[PROC_USER_GETMASTER]
AS
BEGIN

	SELECT TCM.CITY_CODE,TCM.CITY_NAME,TSM.STATE_CODE,TSM.STATE_NAME,TCUM.COUNTRY_CODE,TCUM.COUNTRY_NAME,tcm.IS_ACTIVE                                         
	FROM TBL_CITY_MASTER TCM WITH (NOLOCK)                                        
	LEFT JOIN TBL_STATE_MASTER TSM WITH (NOLOCK) ON TCM.STATE_CODE = TSM.STATE_CODE                                        
	LEFT JOIN TBL_COUNTRY_MASTER TCUM WITH (NOLOCK) ON TSM.COUNTRY_CODE = TCUM.COUNTRY_CODE        
	ORDER BY TCUM.COUNTRY_NAME,TSM.STATE_NAME,TCM.CITY_NAME

	SELECT ADDRESS_TYPE_ID CONTACT_TYPE_ID ,ADDRESS_TYPE CONTACT_TYPE,TYPE_FOR
	FROM TBL_ADDRESS_TYPE_MASTER WITH(NOLOCK)
	ORDER BY ADDRESS_TYPE

	SELECT AVAILING_TYPE_ID,AVAILING_TYPE                                       
	FROM TBL_AVAILING_TYPE_MASTER WITH (NOLOCK)                                        
	ORDER BY AVAILING_TYPE

	SELECT SOURCE_ID,SOURCE_NAME                                        
	FROM TBL_SOURCE_MASTER WITH (NOLOCK)                                        
	ORDER BY SOURCE_NAME

	SELECT STATUS_ID,STATUS_NAME,DESCRIPTION                                        
	FROM TBL_STATUS_MASTER WITH (NOLOCK)
	WHERE IS_ACTIVE=1                                        
	ORDER BY STATUS_NAME

	SELECT MARITAL_STATUS_ID,MARITAL_STATUS                                        
	FROM TBL_MARITAL_STATUS_MASTER WITH (NOLOCK)                                        
	ORDER BY MARITAL_STATUS

	SELECT NATIONALITY_ID,NATIONALITY                                        
	FROM TBL_NATIONALITY_MASTER WITH (NOLOCK)        
	ORDER BY NATIONALITY

	SELECT LANGUAGE_ID,LANGUAGE_NAME        
	FROM TBL_LANGUAGE_MASTER WITH (NOLOCK)        
	ORDER BY LANGUAGE_NAME

	SELECT UNIVERSITY_ID,UNIVERSITY_NAME                                        
	FROM TBL_UNIVERSITY_MASTER WITH (NOLOCK) 

	SELECT COMPANY_ID,COMPANY_NAME        
	FROM TBL_COMPANY_MASTER WITH (NOLOCK)        
	ORDER BY COMPANY_NAME

	SELECT DESIGNATION_ID,DESIGNATION_NAME, TRT.INDUSTRY_ID,TRT.INDUSTRY_TYPE            
	FROM TBL_DESIGNATION_MASTER TDM WITH (NOLOCK)                     
	JOIN TBL_INDUSTRY_MASTER TRT WITH (NOLOCK) ON TDM.INDUSTRY_ID=TRT.INDUSTRY_ID                                 
	ORDER BY TRT.INDUSTRY_TYPE,DESIGNATION_NAME 

	SELECT TEM.EDUCATION_TYPE_ID,TEM.EDUCATION_TYPE,TSM.SPECIALIZATION_TYPE,TSM.SPECIALIZATION_ID              
	FROM TBL_EDUCATION_TYPE_MASTER TEM WITH (NOLOCK)              
	JOIN TBL_SPECIALIZATION_MASTER TSM WITH (NOLOCK) ON TEM.EDUCATION_TYPE_ID = TSM.EDUCATION_TYPE_ID                  
	ORDER BY EDUCATION_TYPE,TSM.SPECIALIZATION_TYPE

	SELECT VEHICLE_TYPE_ID,VEHICLE_TYPE                                  
	FROM TBL_VEHICLE_TYPE WITH (NOLOCK)                                        
	ORDER BY VEHICLE_TYPE

	SELECT BRANCH_CODE,BRANCH_NAME        
	FROM TBL_BRANCH_MASTER WITH (NOLOCK)                                        
	ORDER BY BRANCH_NAME

	SELECT CERTIFICATION_ID,CERTIFICATION_NAME        
	FROM TBL_CERTIFICATION_MASTER WITH (NOLOCK)                                        
	WHERE IS_ACTIVE=1        
	ORDER BY CERTIFICATION_NAME

	SELECT VISA_ID,VISA_NUMBER                                        
	FROM TBL_VISA_MASTER WITH (NOLOCK)
  
	SELECT REQUIREMENT_ID ,(ISNULL(TCM.COMPANY_NAME,CLIENT.NAME) + ' | ' + ISNULL(TRD.JOB_TITLE,''))REQUIREMENT
	FROM TBL_REQUIREMENT_DETAILS TRD WITH (NOLOCK)
	LEFT JOIN TBL_COMPANY_MASTER TCM WITH(NOLOCK) ON TCM.COMPANY_ID=TRD.COMPANY_ID
	LEFT JOIN 
	(
		SELECT TUD.REGISTRATION_NO,(ISNULL(TUPD.FIRST_NAME,'') +' ' + ISNULL(TUPD.MIDDLE_NAME,'') +' '+ ISNULL(TUPD.LAST_NAME,''))NAME 
		FROM TBL_USER_DETAILS TUD WITH(NOLOCK) 
		JOIN TBL_USER_PERSONAL_DETAILS TUPD WITH(NOLOCK) ON TUD.REGISTRATION_NO=TUPD.REGISTRATION_NO
		WHERE TUD.USER_TYPE_ID = 5
	)CLIENT ON TRD.CONTACT_PERSON = CLIENT.REGISTRATION_NO
	WHERE TRD.IS_ACTIVE=1

	SELECT GENDER_CODE,GENDER_NAME
	FROM TBL_GENDER_MASTER WITH(NOLOCK)
	
	SELECT RELIGION_ID,RELIGION_NAME        
	FROM TBL_RELIGION_MASTER WITH (NOLOCK)        
	ORDER BY RELIGION_NAME 
END
GO
/****** Object:  StoredProcedure [dbo].[PROC_USER_INSERT]    Script Date: 27-Jan-17 1:15:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PROC_USER_INSERT]
(
 @USER_TYPE_ID INT = NULL,
 @USER_DETAIL as [dbo].UDT_USER_DETAILS READONLY,
 @USER_EMAIL as [dbo].UDT_USER_EMAIL READONLY,
 @USER_CONTACT as [dbo].UDT_USER_CONTACT READONLY,
 @USER_ADDRESS as [dbo].UDT_USER_ADDRESS READONLY,
 @USER_EDUCATION as [dbo].UDT_USER_EDUCATION READONLY,
 @USER_CERTIFICATION as [dbo].UDT_USER_CERTIFICATION READONLY,
 @USER_EXPERIENCE as [dbo].UDT_USER_EXPERIENCE READONLY,
 @USER_DOCUMENT as [dbo].UDT_USER_DOCUMENT READONLY,
 @USER_PASSPORT AS [dbo].[UDT_USER_PASSPORT] READONLY,
 @USER_DRIVING AS [dbo].[UDT_USER_DRIVING] READONLY,
 @USER_LANGUAGE AS [dbo].[UDT_USER_LANGUAGE] READONLY
)
AS
BEGIN
	
	DECLARE 
	@CURRENT_COUNTER INT =NULL,
	@REGISTRATION_NO VARCHAR(20)=NULL

	IF EXISTS (SELECT 1 FROM TBL_USER_REGISTRATION with(nolock) WHERE USER_TYPE_ID = @USER_TYPE_ID AND REG_MONTH = MONTH(GETDATE()) AND REG_YEAR = YEAR(GETDATE()))
	BEGIN

		SELECT @CURRENT_COUNTER = CURRENT_COUNTER FROM TBL_USER_REGISTRATION with(nolock)     
		WHERE USER_TYPE_ID = @USER_TYPE_ID AND REG_MONTH = MONTH(GETDATE()) AND REG_YEAR = YEAR(GETDATE())

		SELECT @REGISTRATION_NO = LEFT(USER_TYPE,1) + CONVERT(VARCHAR, MONTH(GETDATE())) + CONVERT(VARCHAR, YEAR(GETDATE())) +
		REPLICATE ('0',4- LEN(@CURRENT_COUNTER + 1)) + CONVERT(VARCHAR,@CURRENT_COUNTER +1)
		FROM TBL_USER_TYPE with(nolock) WHERE  USER_TYPE_ID = @USER_TYPE_ID
    
		UPDATE TBL_USER_REGISTRATION SET CURRENT_COUNTER = CURRENT_COUNTER +1
		WHERE USER_TYPE_ID = @USER_TYPE_ID AND REG_MONTH = MONTH(GETDATE()) AND REG_YEAR = YEAR(GETDATE())
	END     
	ELSE     
	BEGIN    
		SET @CURRENT_COUNTER = 0    
		SELECT @REGISTRATION_NO = LEFT(USER_TYPE,1) + CONVERT(VARCHAR, MONTH(GETDATE())) + CONVERT(VARCHAR, YEAR(GETDATE())) + 
		REPLICATE ('0',4- LEN(@CURRENT_COUNTER + 1)) + CONVERT(VARCHAR,@CURRENT_COUNTER +1)
		FROM TBL_USER_TYPE with(nolock) WHERE  USER_TYPE_ID = @USER_TYPE_ID
       
		INSERT INTO TBL_USER_REGISTRATION (REG_MONTH,REG_YEAR,USER_TYPE_ID,CURRENT_COUNTER)
		VALUES (MONTH(GETDATE()), YEAR(GETDATE()), @USER_TYPE_ID,1)
	END

	INSERT INTO TBL_USER_DETAILS(REGISTRATION_NO,USER_TYPE_ID,USER_IMAGE_PATH,LOGIN_ACCESS,GAMCA_NO,WEBSITE,SKYPE,REMARK,CONTACT_REMARK,CREATED_BY,CREATED_DATE,
	AVAILING_TYPE_ID,SOURCE_ID,OTHER_SOURCE,REFERRER_NAME,STATUS_ID,REQUIREMENT_ID,LOGIN_PASSWORD,IS_EXPERIENCED,EDUCATION_REMARK,WORK_REMARK,BRANCH_CODE,
	LOCATION_CODE,COMPANY_NAME,TOTAL_WORK_EXPERIENCE,TOTAL_GULF_EXPERIENCE,SKILLS
	,INDUSTRY_ID,DESIGNATION_ID,REFERENCE,CIVILIAN_NO,CLINIC_NAME)
	SELECT @REGISTRATION_NO,@USER_TYPE_ID,FILE_PATH,0,GAMCA_NO,WEBSITE,SKYPE,REMARK,CONTACT_REMARK,CREATED_BY,GETDATE(), 
	AVAILING_TYPE_ID,SOURCE_ID,OTHER_SOURCE,REFERRER_NAME,STATUS_ID,REQUIREMENT_ID,LOGIN_PASSWORD,IS_EXPERIENCED,EDUCATION_REMARK,WORK_REMARK,BRANCH_CODE,
	LOCATION_CODE,COMPANY_NAME,TOTAL_WORK_EXPERIENCE,TOTAL_GULF_EXPERIENCE,SKILLS
	,INDUSTRY,DESIGNATION,REFERENCE,CIVILIAN_NO,CLINIC_NAME
	FROM @USER_DETAIL

	INSERT INTO TBL_USER_PERSONAL_DETAILS(REGISTRATION_NO,FIRST_NAME,MIDDLE_NAME,LAST_NAME,IS_ACTIVE
	,FATHER_NAME,MOTHER_NAME,GENDER_CODE,DATE_OF_BIRTH,PLACE_OF_BIRTH,MARITAL_STATUS_ID,NATIONALITY_ID,CURRENT_LOCATION,RELIGION_ID)
	SELECT @REGISTRATION_NO,FIRST_NAME,MIDDLE_NAME,LAST_NAME,1 
	,FATHER_NAME,MOTHER_NAME,GENDER_CODE,DATE_OF_BIRTH,PLACE_OF_BIRTH,MARITAL_STATUS_ID,NATIONALITY_ID,CURRENT_LOCATION,RELIGION_ID
	FROM @USER_DETAIL

	INSERT INTO TBL_USER_ADDRESS(REGISTRATION_NUMBER,ADDRESS_TYPE_ID,ADDRESS,CITY_CODE,USER_VILLAGE,USER_PINCODE,CREATED_BY,CREATED_DATE)
	SELECT @REGISTRATION_NO,ADDRESS_TYPE_ID,ADDRESS,CITY_CODE,USER_VILLAGE,USER_PINCODE, CREATED_BY,GETDATE()
	FROM @USER_ADDRESS

	INSERT INTO TBL_USER_CONTACTS(REGISTRATION_NUMBER,CONTACT_NO,CONTACT_TYPE_ID,CREATED_BY,CREATED_DATE)
	SELECT @REGISTRATION_NO,CONTACT_NO,CONTACT_TYPE_ID,CREATED_BY,GETDATE() 
	FROM @USER_CONTACT

	INSERT INTO TBL_USER_EMAIL_ADDRESS(REGISTRATION_NUMBER,USER_EMAIL)
	SELECT @REGISTRATION_NO,USER_EMAIL FROM @USER_EMAIL
	
	INSERT INTO TBL_USER_EDUCATION_DETAILS(REGISTRATION_NO,EDUCATION_TYPE_ID,SPECIALIZATION_TYPE_ID,UNIVERSITY_ID,UNIVERSITY_YEAR_OF_PASSING,IS_HIGHEST_QUALIFICATION,
	CREATED_BY,CREATED_DATE)
	SELECT @REGISTRATION_NO,EDUCATION_TYPE_ID,SPECIALIZATION_TYPE_ID,UNIVERSITY_ID,UNIVERSITY_YEAR_OF_PASSING,IS_HIGHEST_QUALIFICATION,
	CREATED_BY,GETDATE()
	FROM @USER_EDUCATION

	INSERT INTO TBL_USER_CERTIFICATION(REGISTRATION_NUMBER,CERTIFICATION,CERTIFICATION_LEVEL,INSTITUTE,YEAR_OF_PASSING)
	SELECT @REGISTRATION_NO,CERTIFICATION,CERTIFICATION_LEVEL,INSTITUTE,YEAR_OF_PASSING
	FROM @USER_CERTIFICATION

	INSERT INTO TBL_USER_EXPERIENCE(REGISTRATION_NO,USER_COMPANY_NAME,IS_CURRENT_COMPANY,DESIGNATION_ID,INDUSTRY_ID,CITY_CODE,TOTAL_WORK_EXPERIENCE,REMARK,
	CREATED_BY,CREATED_DATE,WORK_PERIOD_FROM,WORK_PERIOD_TO)
	SELECT @REGISTRATION_NO,USER_COMPANY_NAME,IS_CURRENT_COMPANY,DESIGNATION_ID,INDUSTRY_ID,CITY_CODE,TOTAL_WORK_EXPERIENCE,REMARK,
	CREATED_BY,GETDATE(),WORK_PERIOD_FROM,WORK_PERIOD_TO
	FROM @USER_EXPERIENCE

	INSERT INTO TBL_USER_DOCUMENTS(REGISTRATION_NO,DOCUMENT_TYPE_ID,DOCUMENT_PATH,CREATED_BY,CREATED_DATE)
	SELECT @REGISTRATION_NO,DOCUMENT_TYPE_ID,DOCUMENT_PATH,CREATED_BY,GETDATE()
	FROM @USER_DOCUMENT

	INSERT INTO TBL_USER_DRIVING_LICENCE_DETAILS(REGISTRATION_NO,DRIVING_LICENCE_NUMBER,PLACE_OF_ISSUE,	DATE_OF_ISSUE,EXPIRY_DATE,VEHICLE_TYPE_ID,REMARK,CREATED_BY,CREATED_DATE)
	SELECT @REGISTRATION_NO,DRIVING_LICENCE_NUMBER,PLACE_OF_ISSUE,DATE_OF_ISSUE,EXPIRY_DATE,VEHICLE_TYPE_ID,REMARK,CREATED_BY,GETDATE()
	FROM @USER_DRIVING

	INSERT INTO TBL_PASSPORT_DETAILS(REGISTATION_NUMBER,PASSPORT_NUMBER,DATE_OF_ISSUE,PLACE_OF_ISSUE,DATE_OF_EXPIRY,EMIGRATION_CLEARANCE_REQUIRED,CREATED_BY,CREATED_DATE)
	SELECT @REGISTRATION_NO,PASSPORT_NUMBER,DATE_OF_ISSUE,PLACE_OF_ISSUE,DATE_OF_EXPIRY,EMIGRATION_CLEARANCE_REQUIRED,CREATED_BY,GETDATE()
	FROM @USER_PASSPORT
	
	INSERT INTO TBL_USER_LANGUAGE(REGISTRATION_NO,LANGUAGE_ID,IS_READ,IS_WRITE,IS_SPEAK)
	SELECT @REGISTRATION_NO,LANGUAGE_ID,IS_READ,IS_WRITE,IS_SPEAK
	FROM @USER_LANGUAGE

	INSERT INTO TBL_USER_REQUIREMENT(REGISTRATION_NO,REQUIREMENT_ID,CANDIDATE_STATUS,CURRENT_STATUS,CREATED_BY,CREATED_DATE)
	SELECT @REGISTRATION_NO,REQUIREMENT_ID,STATUS_ID,1,CREATED_BY,GETDATE()
	FROM @USER_DETAIL
	WHERE REQUIREMENT_ID IS NOT NULL AND REQUIREMENT_ID <> 0

	SELECT @REGISTRATION_NO REGISTRATION_NO
	
END
GO
/****** Object:  StoredProcedure [dbo].[PROC_USER_LOGIN_DETAILS]    Script Date: 27-Jan-17 1:15:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[PROC_USER_LOGIN_DETAILS]    
(    
@USER_NAME VARCHAR(20) =NULL,    
@USER_PASSWORD VARCHAR(20) =NULL  
)    
AS     
BEGIN    
 SELECT TUD.REGISTRATION_NO,USER_TYPE_ID,USER_IMAGE_PATH,(ISNULL(TUPD.FIRST_NAME,'') +' '+ISNULL(TUPD.LAST_NAME,''))NAME    
 FROM TBL_USER_DETAILS TUD WITH (NOLOCK)  
 JOIN TBL_USER_PERSONAL_DETAILS TUPD WITH(NOLOCK) ON TUD.REGISTRATION_NO=TUPD.REGISTRATION_NO  
 WHERE TUD.REGISTRATION_NO=@USER_NAME AND LOGIN_PASSWORD=@USER_PASSWORD    
     
 END    

GO
/****** Object:  StoredProcedure [dbo].[PROC_USER_PERSONAL_DETAILS]    Script Date: 27-Jan-17 1:15:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================            
-- Author:  <AMBI GUPTA>            
-- Create date: <05-SEP-2015>            
-- Description: <STORED PROCEDURE TO INSERT USER PERSONAL DETAILS>            
-- =============================================            
CREATE PROCEDURE [dbo].[PROC_USER_PERSONAL_DETAILS]            
 (            
 @REGISTRATION_NO varchar(20) =NULL,            
 @FIRST_NAME  varchar(50) =NULL,            
 @MIDDLE_NAME varchar(50) =NULL,            
 @LAST_NAME   varchar(50) =NULL,            
 @FATHER_NAME varchar(80)=NULL,            
 @MOTHER_NAME  varchar(80)=NULL,            
 @GENDER_CODE CHAR(1) =NULL,            
 @DATE_OF_BIRTH DATETIME =NULL,            
 @PLACE_OF_BIRTH  varchar(50) =NULL,            
 @MARITAL_STATUS_ID INT=NULL,            
 @NATIONALITY_ID INT=NULL,            
 @CURRENT_LOCATION varchar(50) =NULL,             
 @RELIGION_ID INT=NULL,            
 @CONDITIONAL_OPERATOR VARCHAR(30) = NULL            
 )            
             
AS            
BEGIN            
 -- SET NOCOUNT ON added to prevent extra result sets from            
 -- interfering with SELECT statements.            
 SET NOCOUNT ON;            
 IF @CONDITIONAL_OPERATOR ='INSERT'            
  BEGIN            
   INSERT INTO TBL_USER_PERSONAL_DETAILS(REGISTRATION_NO,FIRST_NAME,MIDDLE_NAME,LAST_NAME,FATHER_NAME,MOTHER_NAME,        
   GENDER_CODE,DATE_OF_BIRTH,PLACE_OF_BIRTH,MARITAL_STATUS_ID,NATIONALITY_ID,CURRENT_LOCATION,RELIGION_ID)        
   VALUES             
   (            
    @REGISTRATION_NO,@FIRST_NAME,@MIDDLE_NAME,@LAST_NAME,@FATHER_NAME,@MOTHER_NAME,        
   @GENDER_CODE,@DATE_OF_BIRTH,@PLACE_OF_BIRTH,@MARITAL_STATUS_ID,@NATIONALITY_ID,@CURRENT_LOCATION,@RELIGION_ID            
   )      
         
  END            
              
 ELSE IF @CONDITIONAL_OPERATOR='UPDATE'            
  BEGIN            
   UPDATE TBL_USER_PERSONAL_DETAILS             
   SET FIRST_NAME = @FIRST_NAME,MIDDLE_NAME=@MIDDLE_NAME,            
   LAST_NAME = @LAST_NAME, FATHER_NAME=@FATHER_NAME,            
   MOTHER_NAME = @MOTHER_NAME,GENDER_CODE= @GENDER_CODE,            
   DATE_OF_BIRTH = @DATE_OF_BIRTH,PLACE_OF_BIRTH=@PLACE_OF_BIRTH,            
   MARITAL_STATUS_ID =@MARITAL_STATUS_ID, NATIONALITY_ID = @NATIONALITY_ID, CURRENT_LOCATION = @CURRENT_LOCATION,RELIGION_ID=@RELIGION_ID          
   WHERE REGISTRATION_NO = @REGISTRATION_NO              
  END            
END 




GO
/****** Object:  StoredProcedure [dbo].[PROC_USER_VISA_DETAILS]    Script Date: 27-Jan-17 1:15:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<YOGENDRA DUBEY>
-- Create date: <26 AUG 2015>
-- Description:	<STORED PROCEDURE TO INSERT OR UPDATE USER VISA >
-- =============================================
CREATE PROCEDURE [dbo].[PROC_USER_VISA_DETAILS]
(
@REGISTRATION_NUMBER VARCHAR(12) = NULL,
@VISA_ID	INT = NULL,
@CREATED_BY	VARCHAR(12) =NULL, 
@CONDITIONAL_OPERATOR VARCHAR(30) = NULL
)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
		
	 IF @CONDITIONAL_OPERATOR = 'INSERT'
		BEGIN
			INSERT INTO TBL_USER_VISA_DETAILS (	REGISTRATION_NUMBER,VISA_ID,CREATED_BY,MODIFIED_BY)
			VALUES ( @REGISTRATION_NUMBER, @VISA_ID,@CREATED_BY,@CREATED_BY)		
		END
		
	 IF @CONDITIONAL_OPERATOR ='DELETE'
		BEGIN
			DELETE FROM TBL_USER_VISA_DETAILS WHERE REGISTRATION_NUMBER = @REGISTRATION_NUMBER
		END	
END




GO
/****** Object:  StoredProcedure [dbo].[PROC_VISA_GETALLVISA]    Script Date: 27-Jan-17 1:15:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROC [dbo].[PROC_VISA_GETALLVISA]
(
@CREATED_BY NVARCHAR(50) =NULL,
@VISA_ID INT = null
)
AS   
BEGIN  

	SELECT VISA.VISA_ID,USERS.CIVILIAN_NO,VISA.CREATED_BY,VISA.CREATED_DATE,VISA.EXPIRY_DATE,VISA.FILE_NAME,VISA.FILE_PATH,
	VISA.ISSUE_DATE,VISA.PLACE_OF_ENDORSEMENT,VISA.PURPOSE,VISA.RECIEVED_DATE,VISA.REGISTRATION_NUMBER,VISA.REMARK,VISA.VISA_NUMBER,
	(PER.FIRST_NAME +' '+PER.LAST_NAME) AS CLIENT_NAME
	FROM TBL_VISA_MASTER VISA WITH(NOLOCK)
	JOIN TBL_USER_PERSONAL_DETAILS PER WITH(NOLOCK) ON VISA.REGISTRATION_NUMBER = PER.REGISTRATION_NO
	JOIN TBL_USER_DETAILS USERS ON PER.REGISTRATION_NO = USERS.REGISTRATION_NO
	WHERE VISA.IS_ACTIVE = 1 AND (VISA.CREATED_BY=@CREATED_BY OR ISNULL(@CREATED_BY,'')='') 
	AND (VISA.VISA_ID = @VISA_ID OR ISNULL(@VISA_ID,'') ='')
END  

  







GO
/****** Object:  StoredProcedure [dbo].[PROC_VISA_MASTER]    Script Date: 27-Jan-17 1:15:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROC [dbo].[PROC_VISA_MASTER]  

(  

@REGISTRATION_NUMBER varchar(12)=NULL,  

@VISA_NUMBER varchar(30)=NULL,  

@PLACE_OF_ENDORSEMENT varchar(12)=NULL,  

@ISSUE_DATE datetime=NULL,  

@EXPIRY_DATE datetime=NULL,  

@RECIEVED_DATE datetime=NULL,  

@FILE_NAME varchar(50)=NULL,  

@FILE_PATH varchar(100)=NULL,  

@REMARK varchar(100)=NULL,  

@CREATED_BY varchar(20)=NULL,  

@PURPOSE varchar(20)=NULL,  

@CONDITIONAL_OPERATOR VARCHAR(100)=NULL  

)  

AS   

BEGIN  

 IF(@CONDITIONAL_OPERATOR ='INSERT')  

 BEGIN  

  INSERT INTO TBL_VISA_MASTER (REGISTRATION_NUMBER,VISA_NUMBER,PLACE_OF_ENDORSEMENT,ISSUE_DATE,EXPIRY_DATE,RECIEVED_DATE,  
  FILE_NAME,FILE_PATH,REMARK,CREATED_BY,PURPOSE,CREATED_DATE,IS_ACTIVE)  
  VALUES(@REGISTRATION_NUMBER,@VISA_NUMBER,@PLACE_OF_ENDORSEMENT,@ISSUE_DATE,@EXPIRY_DATE,@RECIEVED_DATE,  
  @FILE_NAME,@FILE_PATH,@REMARK,@CREATED_BY,@PURPOSE,GETDATE(),1)  
  SELECT 'Successfull' AS Error  

 END  
END  

  







GO
/****** Object:  UserDefinedFunction [dbo].[FUNC_REQUIREMENT_EDUCATION_SPECIALIZATION]    Script Date: 27-Jan-17 1:15:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE FUNCTION [dbo].[FUNC_REQUIREMENT_EDUCATION_SPECIALIZATION] 
(
@REQUIREMENT_ID INT = 0
)
RETURNS 
@INDUSTRY_TYPE TABLE 
(
	SPECIALIZATION VARCHAR(MAX), 
	EDUCATION_TYPE VARCHAR(MAX),
	CERTIFICATION_TYPE VARCHAR(MAX),
	LANGUAGES VARCHAR(MAX),
	GENDERS VARCHAR(MAX)
)
AS
BEGIN
	-- Fill the table variable with the rows for your result set
	DECLARE @SPECIALIZATION VARCHAR(MAX) = '' , @EDUCATION_TYPE VARCHAR(MAX) = '',
	@CERTIFICATION VARCHAR(MAX) ='', @LANGUAGE VARCHAR(MAX) ='',@GENDER VARCHAR(MAX) =''

	SELECT @SPECIALIZATION = @SPECIALIZATION + ', ' + ISNULL(SPECIALIZATION_TYPE,'') FROM TBL_REQUIRMENT_SPECIALIZATION TRS
	JOIN TBL_SPECIALIZATION_MASTER TS ON TRS.SPECIALIZATION_ID = TS.SPECIALIZATION_ID
	WHERE REQUIREMENT_ID = @REQUIREMENT_ID
	

	SELECT @EDUCATION_TYPE =  @EDUCATION_TYPE + ', ' + EDUCATION_TYPE FROM TBL_REQUIRMENT_EDUCATION_TYPE TRET
	JOIN TBL_EDUCATION_TYPE_MASTER TEM ON TRET.EDUCATION_TYPE_ID = TEM.EDUCATION_TYPE_ID
	WHERE REQUIREMENT_ID = @REQUIREMENT_ID
	
	SELECT @CERTIFICATION =@CERTIFICATION + ', ' + ISNULL(CERTIFICATION_NAME,'') FROM TBL_REQUIRMENT_CERTIFICATION TRC
	JOIN TBL_CERTIFICATION_MASTER TCM on TCM.CERTIFICATION_ID=TRC.CERTIFICATION_ID 
	WHERE REQUIREMENT_ID = @REQUIREMENT_ID
	
	SELECT @SPECIALIZATION =  @SPECIALIZATION + ', ' + ISNULL(SPECIALIZATION_TYPE,'') FROM TBL_REQUIRMENT_SPECIALIZATION TRS
	JOIN TBL_SPECIALIZATION_MASTER TS ON TRS.SPECIALIZATION_ID = TS.SPECIALIZATION_ID
	WHERE REQUIREMENT_ID = @REQUIREMENT_ID


	SELECT @LANGUAGE = @LANGUAGE  + ', ' + (UPPER(LANGUAGE_NAME) + ' (' +ltrim(rtrim( CASE WHEN ISNULL(CAN_READ,0)=0 THEN '' ELSE 'Read' END  + ' '
	+ CASE WHEN ISNULL(CAN_WRITE,0)=0 THEN '' ELSE ' Write' END + 
	CASE WHEN ISNULL(CAN_SPEAK,0)=0 THEN '' ELSE ' Speak' END + ')')))
	FROM TBL_REQUIREMENT_LANGUAGE TRC 
	JOIN TBL_LANGUAGE_MASTER TLM ON TRC.LANGUAGE_ID = TLM.LANGUAGE_ID
	WHERE REQUIRMENT_ID = @REQUIREMENT_ID

	SELECT @GENDER= @GENDER+', '+UPPER(GENDER_NAME) FROM TBL_REQUIREMENT_GENDER RG JOIN TBL_GENDER_MASTER GM 
	ON RG.GENDER=GM.GENDER_CODE WHERE RG.REQUIREMENT_ID = @REQUIREMENT_ID

	INSERT INTO @INDUSTRY_TYPE 	
	SELECT ISNULL(STUFF(@SPECIALIZATION,1,1,''),''),
		   ISNULL(STUFF(@EDUCATION_TYPE,1,1,''),''),
	       ISNULL(STUFF(@CERTIFICATION,1,1,''),''),
		   ISNULL(STUFF(@LANGUAGE,1,1,''),''),
		   ISNULL(STUFF(@GENDER,1,1,''),'')
	
	RETURN 
END
GO
/****** Object:  UserDefinedFunction [dbo].[FUNC_REQUIREMENT_INDUSTRY_TYPE]    Script Date: 27-Jan-17 1:15:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE FUNCTION [dbo].[FUNC_REQUIREMENT_INDUSTRY_TYPE] 
(
@REQUIREMENT_ID INT = 0
)
RETURNS 
@INDUSTRY_TYPE TABLE 
(
	INDUSTRY_TYPE VARCHAR(MAX)
)
AS
BEGIN
	-- Fill the table variable with the rows for your result set
	DECLARE @STR VARCHAR(MAX) = ''


	SELECT @STR = @STR + ', ' + INDUSTRY_TYPE FROM
	TBL_REQUIRMENT_INDUSTRY TRI 
	LEFT JOIN TBL_INDUSTRY_MASTER TRM WITH(NOLOCK) ON TRI.INDUSTRY_ID = TRM.INDUSTRY_ID
	WHERE REQUIREMENT_ID = @REQUIREMENT_ID
	INSERT INTO @INDUSTRY_TYPE SELECT ISNULL(STUFF(@STR,1,1,''),'')
	
	RETURN 
END

 

GO
/****** Object:  UserDefinedFunction [dbo].[Split]    Script Date: 27-Jan-17 1:15:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create FUNCTION [dbo].[Split] (
      @InputString                  VARCHAR(8000),
      @Delimiter                    VARCHAR(50)
)

RETURNS @Items TABLE (
      Item                          VARCHAR(8000)
)

AS
BEGIN
      IF @Delimiter = ' '
      BEGIN
            SET @Delimiter = ','
            SET @InputString = REPLACE(@InputString, ' ', @Delimiter)
      END

      IF (@Delimiter IS NULL OR @Delimiter = '')
            SET @Delimiter = ','



      DECLARE @Item                 VARCHAR(8000)
      DECLARE @ItemList       VARCHAR(8000)
      DECLARE @DelimIndex     INT

      SET @ItemList = @InputString
      SET @DelimIndex = CHARINDEX(@Delimiter, @ItemList, 0)
      WHILE (@DelimIndex != 0)
      BEGIN
            SET @Item = SUBSTRING(@ItemList, 0, @DelimIndex)
            INSERT INTO @Items VALUES (@Item)

            -- Set @ItemList = @ItemList minus one less item
            SET @ItemList = SUBSTRING(@ItemList, @DelimIndex+1, LEN(@ItemList)-@DelimIndex)
            SET @DelimIndex = CHARINDEX(@Delimiter, @ItemList, 0)
      END -- End WHILE

      IF @Item IS NOT NULL -- At least one delimiter was encountered in @InputString
      BEGIN
            SET @Item = @ItemList
            INSERT INTO @Items VALUES (@Item)
      END

      -- No delimiters were encountered in @InputString, so just return @InputString
      ELSE INSERT INTO @Items VALUES (@InputString)

      RETURN

END -- End Function



GO
/****** Object:  Table [dbo].[TBL_AD_MEDIUM_MASTER]    Script Date: 27-Jan-17 1:15:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TBL_AD_MEDIUM_MASTER](
	[AD_MEDIUM_ID] [int] IDENTITY(1,1) NOT NULL,
	[AD_MEDIUM_TYPE] [varchar](20) NOT NULL,
	[DISPLAY_ORDER] [int] NOT NULL,
	[IS_ACTIVE] [bit] NOT NULL,
	[CREATED_BY] [varchar](20) NULL,
	[CREATED_DATE] [datetime] NOT NULL,
	[MODIFIED_BY] [varchar](20) NULL,
	[MODIFIED_DATE] [datetime] NOT NULL,
 CONSTRAINT [PK_TBL_AD_MEDIUM_MASTER] PRIMARY KEY CLUSTERED 
(
	[AD_MEDIUM_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TBL_ADDRESS_TYPE_MASTER]    Script Date: 27-Jan-17 1:15:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TBL_ADDRESS_TYPE_MASTER](
	[ADDRESS_TYPE_ID] [int] IDENTITY(1,1) NOT NULL,
	[ADDRESS_TYPE] [varchar](50) NOT NULL,
	[DISPLAY_ORDER] [int] NOT NULL,
	[IS_ACTIVE] [bit] NOT NULL,
	[CREATED_BY] [varchar](20) NULL,
	[CREATED_DATE] [datetime] NOT NULL,
	[MODIFIED_BY] [varchar](20) NULL,
	[MODIFIED_DATE] [datetime] NOT NULL,
	[TYPE_FOR] [varchar](50) NULL,
 CONSTRAINT [PK_TBL_ADDRESS_TYPE_MASTER] PRIMARY KEY CLUSTERED 
(
	[ADDRESS_TYPE_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TBL_ADVERTISEMENT_MASTER]    Script Date: 27-Jan-17 1:15:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TBL_ADVERTISEMENT_MASTER](
	[ADV_ID] [int] IDENTITY(1,1) NOT NULL,
	[PAPER_NAME] [varchar](100) NOT NULL,
	[AD_AGENCY_NAME] [varchar](100) NOT NULL,
	[EXPENSES] [decimal](12, 2) NULL,
	[REQUIREMENT_ID] [int] NOT NULL,
	[FILE_PATH] [varchar](200) NULL,
	[ADV_DATE] [datetime] NOT NULL,
	[IS_ACTIVE] [bit] NULL,
	[CREATED_BY] [varchar](20) NULL,
	[CREATED_DATE] [datetime] NOT NULL,
	[MODIFIED_BY] [varchar](20) NULL,
	[MODIFIED_DATE] [datetime] NULL,
 CONSTRAINT [PK_TBL_ADVERTISEMENT_MASTER] PRIMARY KEY CLUSTERED 
(
	[ADV_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TBL_AIRLINES_MASTER]    Script Date: 27-Jan-17 1:15:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TBL_AIRLINES_MASTER](
	[AirlinesId] [int] IDENTITY(1,1) NOT NULL,
	[AirlinesName] [varchar](100) NULL,
	[CreatedBy] [varchar](20) NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedBy] [varchar](20) NULL,
	[ModifiedDate] [datetime] NULL,
	[IsActive] [bit] NULL,
 CONSTRAINT [PK_TBL_AIRLINES_MASTER] PRIMARY KEY CLUSTERED 
(
	[AirlinesId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TBL_ALLOWANCE_MASTER]    Script Date: 27-Jan-17 1:15:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TBL_ALLOWANCE_MASTER](
	[ALLOWANCE_ID] [int] IDENTITY(1,1) NOT NULL,
	[ALLOWANCE_NAME] [varchar](50) NULL,
	[IS_ACTIVE] [bit] NULL,
	[CREATED_DATE] [datetime] NULL,
	[CREATED_BY] [varchar](20) NULL,
 CONSTRAINT [PK_TBL_ALLOWANCE_MASTER] PRIMARY KEY CLUSTERED 
(
	[ALLOWANCE_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TBL_ALLOWANCE_TYPE_MASTER]    Script Date: 27-Jan-17 1:15:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TBL_ALLOWANCE_TYPE_MASTER](
	[ALLOWANCE_TYPE_ID] [int] IDENTITY(1,1) NOT NULL,
	[ALLOWANCE_TYPE] [varchar](50) NOT NULL,
	[CREATED_BY] [varchar](50) NULL,
	[CREATED_DATE] [datetime] NULL,
	[IS_ACTIVE] [bit] NULL,
 CONSTRAINT [PK_TBL_ALLOWANCE_TYPE_MASTER] PRIMARY KEY CLUSTERED 
(
	[ALLOWANCE_TYPE_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TBL_AVAILING_TYPE_MASTER]    Script Date: 27-Jan-17 1:15:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TBL_AVAILING_TYPE_MASTER](
	[AVAILING_TYPE_ID] [int] IDENTITY(1,1) NOT NULL,
	[AVAILING_TYPE] [varchar](50) NOT NULL,
	[TYPE_ORDER] [int] NOT NULL,
	[IS_ACTIVE] [bit] NOT NULL,
	[CREATED_BY] [varchar](20) NULL,
	[CREATED_DATE] [datetime] NOT NULL,
	[MODIFIED_BY] [varchar](20) NULL,
	[MODIFIED_DATE] [datetime] NOT NULL,
 CONSTRAINT [PK_TBL_AVAILING_TYPE_MASTER] PRIMARY KEY CLUSTERED 
(
	[AVAILING_TYPE_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TBL_BRANCH_MASTER]    Script Date: 27-Jan-17 1:15:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TBL_BRANCH_MASTER](
	[BRANCH_CODE] [varchar](20) NOT NULL,
	[BRANCH_NAME] [varchar](80) NOT NULL,
	[IS_ACTIVE] [bit] NULL,
	[CREATED_BY] [varchar](20) NULL,
	[CREATED_DATE] [datetime] NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TBL_CAREER_STATUS_MASTER]    Script Date: 27-Jan-17 1:15:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TBL_CAREER_STATUS_MASTER](
	[CAREER_STATUS_ID] [int] IDENTITY(1,1) NOT NULL,
	[CAREER_STATUS_TYPE] [varchar](50) NOT NULL,
	[STATUS_ORDER] [int] NOT NULL,
	[IS_ACTIVE] [bit] NOT NULL,
	[CREATED_BY] [varchar](20) NULL,
	[CREATED_DATE] [datetime] NOT NULL,
	[MODIFIED_BY] [varchar](20) NULL,
	[MODIFIED_DATE] [datetime] NOT NULL,
 CONSTRAINT [PK_TBL_CAREER_STATUS_MASTER] PRIMARY KEY CLUSTERED 
(
	[CAREER_STATUS_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TBL_CERTIFICATION_MASTER]    Script Date: 27-Jan-17 1:15:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TBL_CERTIFICATION_MASTER](
	[CERTIFICATION_ID] [int] IDENTITY(1,1) NOT NULL,
	[CERTIFICATION_NAME] [varchar](70) NOT NULL,
	[CREATED_BY] [varchar](50) NULL,
	[CREATED_DATE] [datetime] NULL,
	[IS_ACTIVE] [bit] NULL,
 CONSTRAINT [PK_TBL_CERTIFICATION_MASTER] PRIMARY KEY CLUSTERED 
(
	[CERTIFICATION_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TBL_CITY_MASTER]    Script Date: 27-Jan-17 1:15:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TBL_CITY_MASTER](
	[CITY_CODE] [varchar](20) NOT NULL,
	[STATE_CODE] [varchar](12) NOT NULL,
	[CITY_NAME] [varchar](80) NOT NULL,
	[IS_ACTIVE] [bit] NOT NULL,
	[CREATED_BY] [varchar](20) NULL,
	[CREATED_DATE] [datetime] NOT NULL,
	[MODIFIED_BY] [varchar](20) NULL,
	[MODIFIED_DATE] [datetime] NOT NULL,
 CONSTRAINT [PK_TBL_CITY_MASTER] PRIMARY KEY CLUSTERED 
(
	[CITY_CODE] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TBL_COMPANY_MASTER]    Script Date: 27-Jan-17 1:15:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TBL_COMPANY_MASTER](
	[COMPANY_ID] [int] IDENTITY(1,1) NOT NULL,
	[COMPANY_NAME] [varchar](70) NOT NULL,
	[CONTACT_PERSON] [varchar](70) NULL,
	[CREATED_BY] [varchar](20) NULL,
	[CREATED_DATE] [datetime] NULL,
	[MODIFIED_BY] [varchar](20) NULL,
	[MODIFIED_DATE] [datetime] NULL,
	[IS_ACTIVE] [bit] NOT NULL,
 CONSTRAINT [PK_TBL_COMPANY_MASTER] PRIMARY KEY CLUSTERED 
(
	[COMPANY_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TBL_CONNECTED_TICKETDETAILS]    Script Date: 27-Jan-17 1:15:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TBL_CONNECTED_TICKETDETAILS](
	[ConnectTicketID] [int] IDENTITY(1,1) NOT NULL,
	[TicketID] [int] NULL,
	[PnrNumber] [varchar](20) NULL,
	[TicketNumber] [varchar](20) NULL,
	[FlightNumber] [varchar](20) NULL,
	[IsBooked] [bit] NULL,
	[IsCancelled] [bit] NULL,
	[DepartureCityCode] [varchar](20) NULL,
	[DepartureDate] [date] NULL,
	[DepartureTime] [varchar](20) NULL,
	[ArrivalDate] [date] NULL,
	[ArrivalTime] [varchar](20) NULL,
	[CreatedDate] [datetime] NULL,
	[CreatedBy] [varchar](20) NULL,
	[DestinationCityCode] [varchar](20) NULL,
 CONSTRAINT [PK_TBL_CONNECTED_TICKETDETAILS] PRIMARY KEY CLUSTERED 
(
	[ConnectTicketID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TBL_CONTACT_TYPE_MASTER]    Script Date: 27-Jan-17 1:15:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TBL_CONTACT_TYPE_MASTER](
	[CONTACT_TYPE_ID] [int] IDENTITY(1,1) NOT NULL,
	[CONTACT_TYPE] [varchar](10) NOT NULL,
	[DISPLAY_ORDER] [int] NOT NULL,
	[IS_ACTIVE] [bit] NOT NULL,
	[CREATED_BY] [varchar](20) NULL,
	[CREATED_DATE] [datetime] NOT NULL,
	[MODIFIED_BY] [varchar](20) NULL,
	[MODIFIED_DATE] [datetime] NOT NULL,
 CONSTRAINT [PK_TBL_CONTACT_TYPE_MASTER] PRIMARY KEY CLUSTERED 
(
	[CONTACT_TYPE_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TBL_COUNTRY_MASTER]    Script Date: 27-Jan-17 1:15:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TBL_COUNTRY_MASTER](
	[COUNTRY_CODE] [varchar](8) NOT NULL,
	[COUNTRY_NAME] [varchar](80) NOT NULL,
	[IS_ACTIVE] [bit] NOT NULL,
	[CREATED_BY] [varchar](20) NULL,
	[CREATED_DATE] [datetime] NOT NULL,
	[MODIFIED_BY] [varchar](20) NULL,
	[MODIFIED_DATE] [datetime] NULL,
	[ID] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_TBL_COUNTRY_MASTER_1] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TBL_CURRENCY_MASTER]    Script Date: 27-Jan-17 1:15:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TBL_CURRENCY_MASTER](
	[CURRENCY_ID] [int] IDENTITY(1,1) NOT NULL,
	[CURRENCY_NAME] [varchar](50) NOT NULL,
	[CURRENCY_SYMBOL] [varchar](10) NOT NULL,
	[DISPLAY_ORDER] [int] NOT NULL,
	[IS_ACTIVE] [bit] NOT NULL,
	[CREATED_BY] [varchar](20) NULL,
	[CREATED_DATE] [datetime] NOT NULL,
	[MODIFIED_BY] [varchar](20) NULL,
	[MODIFIED_DATE] [datetime] NOT NULL,
 CONSTRAINT [PK_TBL_CURRENCY_MASTER] PRIMARY KEY CLUSTERED 
(
	[CURRENCY_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TBL_DESIGNATION_MASTER]    Script Date: 27-Jan-17 1:15:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TBL_DESIGNATION_MASTER](
	[DESIGNATION_ID] [int] IDENTITY(1,1) NOT NULL,
	[INDUSTRY_ID] [int] NOT NULL,
	[DESIGNATION_NAME] [varchar](100) NOT NULL,
	[IS_ACTIVE] [bit] NOT NULL,
	[CREATED_BY] [varchar](20) NULL,
	[CREATED_DATE] [datetime] NULL,
	[MODIFIED_BY] [varchar](20) NULL,
	[MODIFIED_DATE] [datetime] NULL,
 CONSTRAINT [PK_TBL_DESIGNATION_MASTER] PRIMARY KEY CLUSTERED 
(
	[DESIGNATION_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TBL_EDUCATION_TYPE_MASTER]    Script Date: 27-Jan-17 1:15:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TBL_EDUCATION_TYPE_MASTER](
	[EDUCATION_TYPE_ID] [int] IDENTITY(1,1) NOT NULL,
	[EDUCATION_TYPE] [varchar](20) NULL,
	[IS_ACTIVE] [bit] NOT NULL,
	[CREATED_BY] [varchar](20) NULL,
	[CREATED_DATE] [datetime] NOT NULL,
	[MODIFIED_BY] [varchar](20) NULL,
	[MODIFIED_DATE] [datetime] NOT NULL,
 CONSTRAINT [PK_TBL_EDUCATION_TYPE_MASTER] PRIMARY KEY CLUSTERED 
(
	[EDUCATION_TYPE_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TBL_EMAIL_TYPE_MASTER]    Script Date: 27-Jan-17 1:15:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TBL_EMAIL_TYPE_MASTER](
	[EMAIL_TYPE_ID] [int] IDENTITY(1,1) NOT NULL,
	[EMAIL_TYPE] [varchar](50) NOT NULL,
	[DISPLAY_ORDER] [int] NOT NULL,
	[IS_ACTIVE] [bit] NOT NULL,
	[CREATED_BY] [varchar](20) NULL,
	[CREATED_DATE] [datetime] NOT NULL,
	[MODIFIED_BY] [varchar](20) NULL,
	[MODIFIED_DATE] [date] NOT NULL,
 CONSTRAINT [PK_TBL_EMAIL_TYPE_MASTER] PRIMARY KEY CLUSTERED 
(
	[EMAIL_TYPE_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TBL_ERROR_LOG]    Script Date: 27-Jan-17 1:15:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TBL_ERROR_LOG](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[PAGE_NAME] [varchar](100) NULL,
	[PAGE_URL] [varchar](100) NULL,
	[METHOD_NAME] [varchar](100) NULL,
	[ERROR_MESSAGE] [varchar](500) NULL,
	[INNER_EXCEPTION_MESSAGE] [varchar](1000) NULL,
	[USER_IP] [varchar](50) NULL,
	[USER_CODE] [varchar](500) NULL,
	[CREATED_DATE] [datetime] NULL,
 CONSTRAINT [PK_TBL_ERROR_LOG] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TBL_GENDER_MASTER]    Script Date: 27-Jan-17 1:15:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TBL_GENDER_MASTER](
	[GENDER_CODE] [char](1) NOT NULL,
	[GENDER_NAME] [varchar](10) NOT NULL,
	[GENDER_ORDER] [int] NOT NULL,
	[IS_ACTIVE] [bit] NOT NULL,
	[CREATED_BY] [varchar](20) NULL,
	[CREATED_DATE] [datetime] NOT NULL,
	[MODIFIED_BY] [varchar](20) NULL,
	[MODIFIED_DATE] [datetime] NOT NULL,
 CONSTRAINT [PK_TBL_GENDER_MASTER] PRIMARY KEY CLUSTERED 
(
	[GENDER_CODE] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TBL_INDUSTRY_MASTER]    Script Date: 27-Jan-17 1:15:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TBL_INDUSTRY_MASTER](
	[INDUSTRY_ID] [int] IDENTITY(1,1) NOT NULL,
	[INDUSTRY_TYPE] [varchar](80) NOT NULL,
	[IS_ACTIVE] [bit] NOT NULL,
	[CREATED_DATE] [datetime] NULL,
	[CREATED_BY] [varchar](20) NULL,
	[MODIFIED_BY] [varchar](20) NULL,
	[MODIFIED_DATE] [datetime] NULL,
 CONSTRAINT [PK_TBL_INDUSTRY_MASTER] PRIMARY KEY CLUSTERED 
(
	[INDUSTRY_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TBL_INTERVIEW]    Script Date: 27-Jan-17 1:15:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TBL_INTERVIEW](
	[InterviewID] [int] IDENTITY(1,1) NOT NULL,
	[Company_ID] [int] NULL,
	[Agent_ID] [varchar](20) NULL,
	[RequirementID] [int] NULL,
	[InterviewModeId] [int] NOT NULL,
	[InterviewDate] [datetime] NOT NULL,
	[InterviewVenue] [varchar](150) NULL,
	[InterviewExpenses] [decimal](8, 2) NULL,
	[InterviewRemark] [varchar](250) NULL,
	[IsSelected] [bit] NOT NULL,
	[CreatedBy] [varchar](20) NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
 CONSTRAINT [PK_TBL_INTERVIEW] PRIMARY KEY CLUSTERED 
(
	[InterviewID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TBL_INTERVIEW_MODE_MASTER]    Script Date: 27-Jan-17 1:15:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TBL_INTERVIEW_MODE_MASTER](
	[INTERVIEW_MODE_ID] [int] IDENTITY(1,1) NOT NULL,
	[INTERVIEW_MODE] [varchar](50) NOT NULL,
	[DISPLAY_ORDER] [int] NOT NULL,
	[IS_ACTIVE] [bit] NOT NULL,
	[CREATED_BY] [varchar](20) NULL,
	[CREATED_DATE] [datetime] NOT NULL,
	[MODIFIED_BY] [varchar](20) NULL,
	[MODIFIED_DATE] [datetime] NOT NULL,
 CONSTRAINT [PK_TBL_INTERVIEW_MODE_MASTER] PRIMARY KEY CLUSTERED 
(
	[INTERVIEW_MODE_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TBL_LANGUAGE_MASTER]    Script Date: 27-Jan-17 1:15:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TBL_LANGUAGE_MASTER](
	[LANGUAGE_ID] [int] IDENTITY(1,1) NOT NULL,
	[LANGUAGE_NAME] [varchar](50) NULL,
	[IS_ACTIVE] [bit] NULL,
	[CREATED_DATE] [datetime] NULL,
	[CREATED_BY] [varchar](20) NULL,
 CONSTRAINT [PK_TBL_LANGUAGE_MASTER] PRIMARY KEY CLUSTERED 
(
	[LANGUAGE_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TBL_LMS_MENU]    Script Date: 27-Jan-17 1:15:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TBL_LMS_MENU](
	[LMS_MENU_ID] [int] IDENTITY(1,1) NOT NULL,
	[MENU_NAME] [varchar](30) NULL,
	[MENU_TITLE] [varchar](50) NULL,
	[MENU_URL] [varchar](100) NULL,
	[PARENT_MENU_ID] [int] NULL,
	[IS_PARENT] [bit] NULL,
	[CREATED_BY] [varchar](10) NULL,
	[CREATED_DATE] [datetime] NULL,
	[REMARK] [varchar](100) NULL,
	[PAGE_NAME] [varchar](50) NULL,
	[CONTROLLER_NAME] [varchar](50) NULL,
	[MENU_ICON] [varchar](50) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TBL_MARITAL_STATUS_MASTER]    Script Date: 27-Jan-17 1:15:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TBL_MARITAL_STATUS_MASTER](
	[MARITAL_STATUS_ID] [int] IDENTITY(1,1) NOT NULL,
	[MARITAL_STATUS] [varchar](10) NOT NULL,
	[MARITAL_STATUS_ORDER] [int] NOT NULL,
	[IS_ACTIVE] [bit] NOT NULL,
	[CREATED_BY] [varchar](20) NULL,
	[CREATED_DATE] [datetime] NOT NULL,
	[MODIFIED_BY] [varchar](20) NULL,
	[MODIFIED_DATE] [datetime] NOT NULL,
 CONSTRAINT [PK_TBL_MARITAL_STATUS_MASTER] PRIMARY KEY CLUSTERED 
(
	[MARITAL_STATUS_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TBL_MEDICAL]    Script Date: 27-Jan-17 1:15:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TBL_MEDICAL](
	[MedicalId] [int] IDENTITY(1,1) NOT NULL,
	[USER_REQUIREMENT_ID] [int] NOT NULL,
	[DoctorID] [varchar](20) NOT NULL,
	[CheckupDate] [date] NULL,
	[TokenNumber] [varchar](30) NULL,
	[ReportDate] [date] NULL,
	[MedicalStatus] [int] NULL,
	[ReportPath] [varchar](150) NULL,
	[Remark] [varchar](250) NULL,
	[CreatedBy] [varchar](20) NULL,
	[CreatedDate] [datetime] NULL,
 CONSTRAINT [PK_TBL_MEDICAL] PRIMARY KEY CLUSTERED 
(
	[MedicalId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TBL_MEDICAL_STATUS]    Script Date: 27-Jan-17 1:15:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TBL_MEDICAL_STATUS](
	[MedicalStatusID] [int] IDENTITY(1,1) NOT NULL,
	[MedicalStatus] [varchar](20) NULL,
	[CreatedBy] [varchar](20) NULL,
	[CreatedDate] [datetime] NULL,
 CONSTRAINT [PK_TBL_MEDICAL_STATUS] PRIMARY KEY CLUSTERED 
(
	[MedicalStatusID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TBL_MOFA]    Script Date: 27-Jan-17 1:15:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TBL_MOFA](
	[MofaID] [int] IDENTITY(1,1) NOT NULL,
	[USER_REQUIREMENT_ID] [int] NULL,
	[MofaNumber] [varchar](30) NULL,
	[MofaDate] [date] NULL,
	[ApplicationNumber] [varchar](30) NULL,
	[ApplicationDate] [date] NULL,
	[HealthNumber] [varchar](30) NULL,
	[HealthDate] [date] NULL,
	[DDNumber] [varchar](30) NULL,
	[DDDate] [date] NULL,
	[MofaFilePath] [varchar](150) NULL,
	[MofaRemark] [varchar](250) NULL,
	[CreatedDate] [datetime] NULL,
	[CreatedBy] [varchar](20) NULL,
 CONSTRAINT [PK_TBL_MOFA] PRIMARY KEY CLUSTERED 
(
	[MofaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TBL_NATIONALITY_MASTER]    Script Date: 27-Jan-17 1:15:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TBL_NATIONALITY_MASTER](
	[NATIONALITY_ID] [int] IDENTITY(1,1) NOT NULL,
	[NATIONALITY] [varchar](80) NULL,
	[CREATED_BY] [varchar](20) NULL,
	[CREATED_DATE] [datetime] NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TBL_PASSPORT_DETAILS]    Script Date: 27-Jan-17 1:15:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TBL_PASSPORT_DETAILS](
	[PASSPORT_ID] [int] IDENTITY(1,1) NOT NULL,
	[REGISTATION_NUMBER] [varchar](20) NOT NULL,
	[PASSPORT_NUMBER] [varchar](20) NULL,
	[DATE_OF_ISSUE] [date] NULL,
	[PLACE_OF_ISSUE] [varchar](50) NULL,
	[DATE_OF_EXPIRY] [date] NULL,
	[EMIGRATION_CLEARANCE_REQUIRED] [bit] NULL,
	[CREATED_BY] [varchar](20) NULL,
	[CREATED_DATE] [datetime] NULL,
	[MODIFIED_BY] [varchar](20) NULL,
	[MODIFIED_DATE] [datetime] NULL,
 CONSTRAINT [PK_TBL_PASSPORT_DETAILS] PRIMARY KEY CLUSTERED 
(
	[PASSPORT_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TBL_POLICY]    Script Date: 27-Jan-17 1:15:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TBL_POLICY](
	[POLICYID] [int] IDENTITY(1,1) NOT NULL,
	[USER_REQUIREMENT_ID] [int] NOT NULL,
	[Policy] [varchar](100) NULL,
	[PolicyDate] [date] NULL,
	[PolicyFees] [decimal](10, 2) NULL,
	[PolicyRemark] [varchar](250) NULL,
	[CreatedBy] [varchar](20) NULL,
	[CreatedDate] [datetime] NULL,
 CONSTRAINT [PK_TBL_POLICY] PRIMARY KEY CLUSTERED 
(
	[POLICYID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TBL_PORTAL_MASTER]    Script Date: 27-Jan-17 1:15:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TBL_PORTAL_MASTER](
	[PORTAL_ID] [int] IDENTITY(1,1) NOT NULL,
	[PORTAL_NAME] [varchar](100) NULL,
	[CREATED_BY] [varchar](50) NULL,
	[CREATED_DATE] [datetime] NULL,
	[IS_ACTIVE] [bit] NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TBL_PREFIX_MASTER]    Script Date: 27-Jan-17 1:15:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TBL_PREFIX_MASTER](
	[PREFIX_ID] [int] IDENTITY(1,1) NOT NULL,
	[PREFIX] [varchar](10) NOT NULL,
	[PREFIX_ORDER] [int] NOT NULL,
	[IS_ACTIVE] [int] NOT NULL,
	[CREATED_BY] [varchar](10) NULL,
	[CREATED_DATE] [datetime] NOT NULL,
	[MODIFIED_BY] [varchar](10) NULL,
	[MODIFIED_DATE] [datetime] NOT NULL,
 CONSTRAINT [PK_TBL_PREFIX_MASTER] PRIMARY KEY CLUSTERED 
(
	[PREFIX_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TBL_REGISTRATION_COUNTER]    Script Date: 27-Jan-17 1:15:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TBL_REGISTRATION_COUNTER](
	[COUNTER_ID] [int] NOT NULL,
	[COUNTER_FOR] [varchar](12) NOT NULL,
	[COUNTER_PREFIX] [char](1) NOT NULL,
	[CURRENT_VALUE] [int] NOT NULL,
 CONSTRAINT [PK_TBL_REGISTRATION_COUNTER] PRIMARY KEY CLUSTERED 
(
	[COUNTER_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TBL_RELIGION_MASTER]    Script Date: 27-Jan-17 1:15:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TBL_RELIGION_MASTER](
	[RELIGION_ID] [int] IDENTITY(1,1) NOT NULL,
	[RELIGION_NAME] [varchar](20) NOT NULL,
	[RELIGION_ORDER] [int] NOT NULL,
	[IS_ACTIVE] [bit] NOT NULL,
	[CREATED_BY] [varchar](20) NULL,
	[CREATED_DATE] [datetime] NOT NULL,
	[MODIFIED_BY] [varchar](20) NULL,
	[MODIFIED_DATE] [datetime] NOT NULL,
 CONSTRAINT [PK_TBL_RELIGION_MASTER] PRIMARY KEY CLUSTERED 
(
	[RELIGION_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TBL_REQUIREMENT_ALLOWANCE]    Script Date: 27-Jan-17 1:15:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TBL_REQUIREMENT_ALLOWANCE](
	[REQUIREMENT_ALLOWANCE_ID] [int] IDENTITY(1,1) NOT NULL,
	[ALLOWANCE_ID] [int] NULL,
	[REQUIRMENT_ID] [int] NULL,
	[IS_INCLUDED] [bit] NULL,
	[IS_ALLOWANCE] [bit] NULL,
	[ALLOWANCE_AMOUNT] [decimal](12, 2) NULL,
	[IS_NOT_APPLICABLE] [bit] NULL,
	[CREATED_BY] [varchar](20) NULL,
	[CREATED_DATE] [datetime] NULL,
	[ALLOWANCE_TYPE_ID] [int] NULL,
 CONSTRAINT [PK_TBL_REQUIREMENT_ALLOWANCE] PRIMARY KEY CLUSTERED 
(
	[REQUIREMENT_ALLOWANCE_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TBL_REQUIREMENT_DETAILS]    Script Date: 27-Jan-17 1:15:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TBL_REQUIREMENT_DETAILS](
	[REQUIREMENT_ID] [int] IDENTITY(1,1) NOT NULL,
	[COMPANY_ID] [int] NULL,
	[RECIEVED_DATE] [datetime] NULL,
	[NO_OF_OPENINGS] [int] NULL,
	[EXPERIENCE] [decimal](4, 2) NULL,
	[JOB_DESCRIPTION] [varchar](200) NULL,
	[GENDER] [char](1) NULL,
	[AGE] [int] NULL,
	[RELIGION_ID] [int] NULL,
	[INTERVIEW_MODE_ID] [int] NULL,
	[SPECIALIZATION_ID] [int] NULL,
	[POSTING_PLACE] [varchar](70) NULL,
	[CURRENCY_TYPE_ID] [int] NULL,
	[BASIC_RANGE] [int] NULL,
	[OVERTIME] [decimal](18, 2) NULL,
	[TRIP_PER_YEAR] [int] NULL,
	[CONTACT_PERIOD] [decimal](12, 2) NULL,
	[WORKING_HOURS] [decimal](4, 2) NULL,
	[LEAVES_PER_YEAR] [int] NULL,
	[REMARK] [varchar](200) NULL,
	[IS_ACTIVE] [bit] NOT NULL,
	[CREATED_BY] [varchar](20) NULL,
	[CREATED_DATE] [datetime] NULL,
	[EXPERIENCE_FROM] [decimal](18, 2) NULL,
	[EXPERIENCE_TO] [decimal](18, 2) NULL,
	[AGE_FROM] [int] NULL,
	[AGE_TO] [int] NULL,
	[BASIC_SALARY_RANGE_TO] [int] NULL,
	[BASIC_SALARY_RANGE_FROM] [int] NULL,
	[CONTACT_PERSON] [varchar](20) NULL,
	[STATUS_ID] [varchar](20) NULL,
	[JOB_TITLE] [varchar](70) NULL,
 CONSTRAINT [PK_TBL_REQUIREMENT_DETAILS] PRIMARY KEY CLUSTERED 
(
	[REQUIREMENT_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TBL_REQUIREMENT_GENDER]    Script Date: 27-Jan-17 1:15:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TBL_REQUIREMENT_GENDER](
	[REQUIREMENT_GENDER_ID] [int] IDENTITY(1,1) NOT NULL,
	[REQUIREMENT_ID] [int] NULL,
	[GENDER] [varchar](10) NULL,
	[CREATED_BY] [varchar](20) NULL,
	[CREATED_DATE] [datetime] NULL,
	[IS_ACTIVE] [bit] NULL,
 CONSTRAINT [PK_TBL_REQUIREMENT_GENDER] PRIMARY KEY CLUSTERED 
(
	[REQUIREMENT_GENDER_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TBL_REQUIREMENT_LANGUAGE]    Script Date: 27-Jan-17 1:15:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TBL_REQUIREMENT_LANGUAGE](
	[REQUIREMENT_LANGUAGE_ID] [int] IDENTITY(1,1) NOT NULL,
	[REQUIRMENT_ID] [int] NULL,
	[LANGUAGE_ID] [int] NULL,
	[CAN_READ] [bit] NULL,
	[CAN_WRITE] [bit] NULL,
	[CAN_SPEAK] [bit] NULL,
	[IS_ACTIVE] [bit] NULL,
	[CREATED_BY] [varchar](20) NULL,
	[CREATED_DATE] [datetime] NULL,
 CONSTRAINT [PK_TBL_REQUIREMENT_LANGUAGE] PRIMARY KEY CLUSTERED 
(
	[REQUIREMENT_LANGUAGE_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TBL_REQUIREMENT_RELIGION]    Script Date: 27-Jan-17 1:15:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TBL_REQUIREMENT_RELIGION](
	[REQUIREMENT_RELIIGION_ID] [int] IDENTITY(1,1) NOT NULL,
	[REQUIREMENT_ID] [int] NULL,
	[RELIGION_ID] [varchar](10) NULL,
	[CREATED_BY] [varchar](20) NULL,
	[CREATED_DATE] [datetime] NULL,
	[IS_ACTIVE] [bit] NULL,
 CONSTRAINT [PK_TBL_REQUIREMENT_RELIGION] PRIMARY KEY CLUSTERED 
(
	[REQUIREMENT_RELIIGION_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TBL_REQUIREMENT_STATUS_MASTER]    Script Date: 27-Jan-17 1:15:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TBL_REQUIREMENT_STATUS_MASTER](
	[STATUS_ID] [int] IDENTITY(1,1) NOT NULL,
	[STATUS_NAME] [varchar](50) NOT NULL,
	[STATUS_VAL] [bit] NULL,
	[STATUS_ORDER] [int] NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TBL_REQUIREMENT_TYPE_MASTER]    Script Date: 27-Jan-17 1:15:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TBL_REQUIREMENT_TYPE_MASTER](
	[REQUIREMENT_TYPE_ID] [int] IDENTITY(1,1) NOT NULL,
	[REQUIREMENT_TYPE] [varchar](30) NOT NULL,
	[IS_ACTIVE] [bit] NOT NULL,
	[CREATED_BY] [varchar](20) NULL,
	[CREATED_DATE] [datetime] NOT NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TBL_REQUIRMENT_CERTIFICATION]    Script Date: 27-Jan-17 1:15:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TBL_REQUIRMENT_CERTIFICATION](
	[REQIREMENT_CERTIFICATION_ID] [int] IDENTITY(1,1) NOT NULL,
	[REQUIREMENT_ID] [int] NULL,
	[CERTIFICATION_ID] [int] NULL,
	[CREATED_BY] [varchar](20) NULL,
	[CREATED_DATE] [datetime] NULL,
	[IS_ACTIVE] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[REQIREMENT_CERTIFICATION_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TBL_REQUIRMENT_DESIGNATION]    Script Date: 27-Jan-17 1:15:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TBL_REQUIRMENT_DESIGNATION](
	[REQIREMENT_DESGNATION_ID] [int] IDENTITY(1,1) NOT NULL,
	[REQUIREMENT_ID] [int] NULL,
	[DESIGNATION_ID] [varchar](70) NULL,
	[CREATED_BY] [varchar](20) NULL,
	[CREATED_DATE] [datetime] NULL,
	[IS_ACTIVE] [bit] NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TBL_REQUIRMENT_EDUCATION_TYPE]    Script Date: 27-Jan-17 1:15:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TBL_REQUIRMENT_EDUCATION_TYPE](
	[REQIREMENT_EDUCATION_TYPE_ID] [int] IDENTITY(1,1) NOT NULL,
	[REQUIREMENT_ID] [int] NULL,
	[EDUCATION_TYPE_ID] [varchar](70) NULL,
	[CREATED_BY] [varchar](20) NULL,
	[CREATED_DATE] [datetime] NULL,
	[IS_ACTIVE] [bit] NULL,
 CONSTRAINT [PK_TBL_REQUIRMENT_EDUCATION_TYPE] PRIMARY KEY CLUSTERED 
(
	[REQIREMENT_EDUCATION_TYPE_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TBL_REQUIRMENT_INDUSTRY]    Script Date: 27-Jan-17 1:15:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TBL_REQUIRMENT_INDUSTRY](
	[REQIREMENT_INDUSTRY_ID] [int] IDENTITY(1,1) NOT NULL,
	[REQUIREMENT_ID] [int] NULL,
	[INDUSTRY_ID] [varchar](70) NULL,
	[CREATED_BY] [varchar](20) NULL,
	[CREATED_DATE] [datetime] NULL,
	[IS_ACTIVE] [bit] NULL,
 CONSTRAINT [PK_TBL_REQUIRMENT_INDUSTRY] PRIMARY KEY CLUSTERED 
(
	[REQIREMENT_INDUSTRY_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TBL_REQUIRMENT_SPECIALIZATION]    Script Date: 27-Jan-17 1:15:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TBL_REQUIRMENT_SPECIALIZATION](
	[REQIREMENT_SPECIALIZATION_ID] [int] IDENTITY(1,1) NOT NULL,
	[REQUIREMENT_ID] [int] NULL,
	[SPECIALIZATION_ID] [varchar](70) NULL,
	[CREATED_BY] [varchar](20) NULL,
	[CREATED_DATE] [datetime] NULL,
	[IS_ACTIVE] [bit] NULL,
 CONSTRAINT [PK_TBL_REQUIRMENT_SPECIALIZATION] PRIMARY KEY CLUSTERED 
(
	[REQIREMENT_SPECIALIZATION_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TBL_RESUME_VIEW]    Script Date: 27-Jan-17 1:15:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TBL_RESUME_VIEW](
	[RESUME_VIEW_ID] [int] IDENTITY(1,1) NOT NULL,
	[REGISTRATION_NO] [varchar](20) NULL,
	[VIEWED_BY] [varchar](20) NULL,
	[CREATED_DATE] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[RESUME_VIEW_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TBL_ROLE_MASTER]    Script Date: 27-Jan-17 1:15:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TBL_ROLE_MASTER](
	[ROLE_ID] [int] IDENTITY(1,1) NOT NULL,
	[ROLE_TYPE] [varchar](50) NULL,
	[IS_ACTIVE] [bit] NOT NULL,
	[CREATED_DATE] [datetime] NULL,
	[CREATED_BY] [varchar](20) NULL,
 CONSTRAINT [PK_TBL_ROLE_MASTER] PRIMARY KEY CLUSTERED 
(
	[ROLE_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TBL_SAVE_TO_FOLDER_DETAILS]    Script Date: 27-Jan-17 1:15:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TBL_SAVE_TO_FOLDER_DETAILS](
	[FOLDER_ID] [int] IDENTITY(1,1) NOT NULL,
	[REGISTRATION_NO] [varchar](20) NOT NULL,
	[FOLDER_NAME] [varchar](50) NOT NULL,
	[CREATED_BY] [varchar](50) NULL,
	[CREATED_DATE] [datetime] NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TBL_SOURCE_MASTER]    Script Date: 27-Jan-17 1:15:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TBL_SOURCE_MASTER](
	[SOURCE_ID] [int] IDENTITY(1,1) NOT NULL,
	[SOURCE_NAME] [varchar](50) NOT NULL,
	[SOURCE_ORDER] [int] NOT NULL,
	[IS_ACTIVE] [bit] NOT NULL,
	[CREATED_BY] [varchar](20) NULL,
	[CREATED_DATE] [datetime] NOT NULL,
	[MODIFIED_BY] [varchar](20) NULL,
	[MODIFIED_DATE] [datetime] NOT NULL,
 CONSTRAINT [PK_TBL_SOURCE_MASTER] PRIMARY KEY CLUSTERED 
(
	[SOURCE_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TBL_SPECIALIZATION_MASTER]    Script Date: 27-Jan-17 1:15:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TBL_SPECIALIZATION_MASTER](
	[SPECIALIZATION_ID] [int] IDENTITY(1,1) NOT NULL,
	[EDUCATION_TYPE_ID] [int] NOT NULL,
	[SPECIALIZATION_TYPE] [varchar](50) NOT NULL,
	[IS_ACTIVE] [bit] NOT NULL,
	[CREATED_BY] [varchar](20) NULL,
	[CREATED_DATE] [datetime] NOT NULL,
	[MODIFIED_BY] [varchar](20) NULL,
	[MODIFIED_DATE] [datetime] NOT NULL,
 CONSTRAINT [PK_TBL_SPECIALIZATION_MASTER] PRIMARY KEY CLUSTERED 
(
	[SPECIALIZATION_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TBL_STATE_MASTER]    Script Date: 27-Jan-17 1:15:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TBL_STATE_MASTER](
	[STATE_CODE] [varchar](12) NOT NULL,
	[COUNTRY_CODE] [varchar](8) NOT NULL,
	[STATE_NAME] [varchar](50) NOT NULL,
	[IS_ACTIVE] [bit] NOT NULL,
	[CREATED_BY] [varchar](20) NULL,
	[CREATED_DATE] [datetime] NOT NULL,
	[MODIFIED_BY] [varchar](20) NULL,
	[MODIFIED_DATE] [datetime] NOT NULL,
 CONSTRAINT [PK_TBL_STATE_MASTER] PRIMARY KEY CLUSTERED 
(
	[STATE_CODE] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TBL_STATUS_MASTER]    Script Date: 27-Jan-17 1:15:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TBL_STATUS_MASTER](
	[STATUS_ID] [int] IDENTITY(1,1) NOT NULL,
	[STATUS_NAME] [varchar](50) NOT NULL,
	[DESCRIPTION] [varchar](50) NULL,
	[STATUS_ORDER] [int] NULL,
	[IS_ACTIVE] [bit] NOT NULL,
	[CREATED_BY] [varchar](20) NULL,
	[CREATED_DATE] [datetime] NULL,
	[MODIFIED_BY] [varchar](20) NULL,
	[MODIFIED_DATE] [datetime] NULL,
 CONSTRAINT [PK_TBL_STATUS_MASTER] PRIMARY KEY CLUSTERED 
(
	[STATUS_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TBL_TASK_FOLLOWUP]    Script Date: 27-Jan-17 1:15:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TBL_TASK_FOLLOWUP](
	[TASK_FOLLOWUP_ID] [int] IDENTITY(1,1) NOT NULL,
	[TASK_ID] [int] NULL,
	[TASK_COMMENT] [varchar](200) NULL,
	[PERC_COMPLETED] [decimal](5, 2) NULL,
	[CREATED_DATE] [datetime] NULL,
	[CREATED_BY] [varchar](20) NULL,
 CONSTRAINT [PK_TBL_TASK_FOLLOWUP] PRIMARY KEY CLUSTERED 
(
	[TASK_FOLLOWUP_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TBL_TASK_MASTER]    Script Date: 27-Jan-17 1:15:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TBL_TASK_MASTER](
	[TASK_ID] [int] IDENTITY(1,1) NOT NULL,
	[TASK_NAME] [varchar](100) NULL,
	[TASK_ASSIGNED_TO] [varchar](20) NULL,
	[PERC_COMPLETED] [decimal](5, 2) NULL,
	[TASK_COMMENT] [varchar](200) NULL,
	[CREATED_DATE] [datetime] NULL,
	[CREATED_BY] [varchar](20) NULL,
	[MODIFIED_DATE] [datetime] NULL,
	[MODIFIED_BY] [varchar](20) NULL,
 CONSTRAINT [PK_TBL_TASK_MASTER] PRIMARY KEY CLUSTERED 
(
	[TASK_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TBL_TICKET]    Script Date: 27-Jan-17 1:15:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TBL_TICKET](
	[TicketID] [int] IDENTITY(1,1) NOT NULL,
	[USER_REQUIREMENT_ID] [int] NOT NULL,
	[AirlinesID] [int] NULL,
	[OtherAirlines] [varchar](100) NULL,
	[IsDirect] [bit] NULL,
	[PnrNumber] [varchar](20) NULL,
	[TicketNumber] [varchar](20) NULL,
	[FlightNumber] [varchar](20) NULL,
	[IsBooked] [bit] NULL,
	[IsCancelled] [bit] NULL,
	[DepartureCityCode] [varchar](20) NULL,
	[DepartureDate] [date] NULL,
	[DepartureTime] [varchar](20) NULL,
	[DestinationCityCode] [varchar](20) NULL,
	[ArivalDate] [date] NULL,
	[ArrivalTime] [varchar](20) NULL,
	[ReportPath] [varchar](100) NULL,
	[Remark] [varchar](250) NULL,
	[createdBy] [varchar](20) NULL,
	[CreatedDate] [datetime] NULL,
 CONSTRAINT [PK_TBL_TICKET] PRIMARY KEY CLUSTERED 
(
	[TicketID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TBL_UNIVERSITY_MASTER]    Script Date: 27-Jan-17 1:15:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TBL_UNIVERSITY_MASTER](
	[UNIVERSITY_ID] [int] IDENTITY(1,1) NOT NULL,
	[UNIVERSITY_NAME] [varchar](80) NOT NULL,
	[IS_ACTIVE] [bit] NOT NULL,
	[CREATED_BY] [varchar](20) NULL,
	[CREATED_DATE] [datetime] NOT NULL,
	[MODIFIED_BY] [varchar](20) NULL,
	[MODIFIED_DATE] [datetime] NOT NULL,
 CONSTRAINT [PK_TBL] PRIMARY KEY CLUSTERED 
(
	[UNIVERSITY_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TBL_USER_ADDRESS]    Script Date: 27-Jan-17 1:15:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TBL_USER_ADDRESS](
	[USER_ADDRESS_ID] [int] IDENTITY(1,1) NOT NULL,
	[REGISTRATION_NUMBER] [varchar](20) NOT NULL,
	[ADDRESS_TYPE_ID] [int] NOT NULL,
	[ADDRESS] [varchar](80) NULL,
	[CITY_CODE] [varchar](10) NULL,
	[USER_VILLAGE] [varchar](50) NULL,
	[USER_PINCODE] [varchar](20) NULL,
	[CREATED_BY] [varchar](20) NULL,
	[CREATED_DATE] [datetime] NULL,
 CONSTRAINT [PK_TBL_USER_ADDRESS] PRIMARY KEY CLUSTERED 
(
	[USER_ADDRESS_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TBL_USER_CERTIFICATION]    Script Date: 27-Jan-17 1:15:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TBL_USER_CERTIFICATION](
	[USER_CERTIFICATION_ID] [int] IDENTITY(1,1) NOT NULL,
	[REGISTRATION_NUMBER] [varchar](20) NULL,
	[CERTIFICATION] [varchar](70) NULL,
	[CERTIFICATION_LEVEL] [int] NULL,
	[INSTITUTE] [varchar](80) NULL,
	[YEAR_OF_PASSING] [int] NULL,
 CONSTRAINT [PK_TBL_USER_CERTIFICATION] PRIMARY KEY CLUSTERED 
(
	[USER_CERTIFICATION_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TBL_USER_CONTACTS]    Script Date: 27-Jan-17 1:15:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TBL_USER_CONTACTS](
	[USER_CONTACT_ID] [int] IDENTITY(1,1) NOT NULL,
	[REGISTRATION_NUMBER] [varchar](20) NULL,
	[CONTACT_TYPE_ID] [int] NULL,
	[CREATED_BY] [varchar](20) NULL,
	[CREATED_DATE] [datetime] NULL,
	[CONTACT_NO] [varchar](50) NULL,
 CONSTRAINT [PK_TBL_USER_CONTACTS] PRIMARY KEY CLUSTERED 
(
	[USER_CONTACT_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TBL_USER_DETAILS]    Script Date: 27-Jan-17 1:15:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TBL_USER_DETAILS](
	[REGISTRATION_NO] [varchar](20) NOT NULL,
	[USER_TYPE_ID] [int] NOT NULL,
	[AVAILING_TYPE_ID] [int] NULL,
	[SOURCE_ID] [int] NULL,
	[STATUS_ID] [int] NULL,
	[VISIT_NUMBER] [int] NULL,
	[REQUIREMENT_ID] [varchar](20) NULL,
	[LOGIN_ACCESS] [bit] NOT NULL,
	[LOGIN_PASSWORD] [varchar](50) NULL,
	[USER_IMAGE_PATH] [varchar](100) NULL,
	[REMARK] [varchar](150) NULL,
	[CREATED_BY] [varchar](20) NULL,
	[CREATED_DATE] [datetime] NOT NULL,
	[MODIFIED_BY] [varchar](20) NULL,
	[MODIFIED_DATE] [datetime] NULL,
	[IS_EXPERIENCED] [bit] NULL,
	[WEBSITE] [varchar](50) NULL,
	[SKYPE] [varchar](50) NULL,
	[CONTACT_REMARK] [varchar](1000) NULL,
	[EDUCATION_REMARK] [varchar](1000) NULL,
	[WORK_REMARK] [varchar](1000) NULL,
	[BRANCH_CODE] [varchar](20) NULL,
	[CIVILIAN_NO] [varchar](20) NULL,
	[NAME] [varchar](20) NULL,
	[CLIENT_DESIGNATION] [int] NULL,
	[CLIENT_INDUSTRY_ID] [int] NULL,
	[REFERENCE] [varchar](20) NULL,
	[GAMCA_NO] [varchar](20) NULL,
	[LOCATION_CODE] [varchar](20) NULL,
	[OTHER_SOURCE] [varchar](20) NULL,
	[REFERRER_NAME] [varchar](50) NULL,
	[COMPANY_NAME] [varchar](70) NULL,
	[DESIGNATION_ID] [varchar](50) NULL,
	[INDUSTRY_ID] [varchar](50) NULL,
	[TOTAL_WORK_EXPERIENCE] [varchar](50) NULL,
	[TOTAL_GULF_EXPERIENCE] [varchar](50) NULL,
	[SKILLS] [varchar](100) NULL,
	[CLINIC_NAME] [varchar](100) NULL,
 CONSTRAINT [PK_TBL_USER_DETAILS] PRIMARY KEY CLUSTERED 
(
	[REGISTRATION_NO] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TBL_USER_DOCUMENT_MASTER]    Script Date: 27-Jan-17 1:15:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TBL_USER_DOCUMENT_MASTER](
	[DOCUMENT_TYPE_ID] [int] IDENTITY(1,1) NOT NULL,
	[DOCUMENT_TYPE] [varchar](30) NOT NULL,
	[DOCUMENT_PATH] [varchar](150) NULL,
	[IS_ACTIVE] [bit] NOT NULL,
	[CREATED_BY] [varchar](20) NULL,
	[CREATED_DATE] [datetime] NOT NULL,
	[MODIFIED_BY] [varchar](20) NULL,
	[MODIFIED_DATE] [datetime] NOT NULL,
 CONSTRAINT [PK_TBL_USER_DOCUMENT_MASTER] PRIMARY KEY CLUSTERED 
(
	[DOCUMENT_TYPE_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TBL_USER_DOCUMENTS]    Script Date: 27-Jan-17 1:15:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TBL_USER_DOCUMENTS](
	[DOCUMENT_ID] [int] IDENTITY(1,1) NOT NULL,
	[REGISTRATION_NO] [varchar](20) NOT NULL,
	[DOCUMENT_TYPE_ID] [varchar](50) NOT NULL,
	[DOCUMENT_PATH] [varchar](200) NOT NULL,
	[IS_ACTIVE] [bit] NOT NULL,
	[CREATED_BY] [varchar](20) NULL,
	[CREATED_DATE] [datetime] NOT NULL,
	[MODIFIED_BY] [varchar](20) NULL,
	[MODIFIED_DATE] [datetime] NOT NULL,
 CONSTRAINT [PK_TBL_USER_DOCUMENTS] PRIMARY KEY CLUSTERED 
(
	[DOCUMENT_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TBL_USER_DRIVING_LICENCE_DETAILS]    Script Date: 27-Jan-17 1:15:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TBL_USER_DRIVING_LICENCE_DETAILS](
	[DRIVING_LICENCE_ID] [int] IDENTITY(1,1) NOT NULL,
	[REGISTRATION_NO] [varchar](20) NOT NULL,
	[DRIVING_LICENCE_NUMBER] [varchar](20) NULL,
	[PLACE_OF_ISSUE] [varchar](20) NULL,
	[DATE_OF_ISSUE] [date] NULL,
	[EXPIRY_DATE] [date] NULL,
	[VEHICLE_TYPE_ID] [int] NULL,
	[REMARK] [varchar](100) NULL,
	[CREATED_BY] [varchar](20) NULL,
	[CREATED_DATE] [datetime] NOT NULL,
	[MODIFIED_BY] [varchar](20) NULL,
	[MODIFIED_DATE] [datetime] NULL,
 CONSTRAINT [PK_TBL_USER_DRIVING_LICENCE_DETAILS] PRIMARY KEY CLUSTERED 
(
	[DRIVING_LICENCE_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TBL_USER_EDUCATION_DETAILS]    Script Date: 27-Jan-17 1:15:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TBL_USER_EDUCATION_DETAILS](
	[USER_EDUCATION_ID] [int] IDENTITY(1,1) NOT NULL,
	[REGISTRATION_NO] [varchar](12) NOT NULL,
	[EDUCATION_TYPE_ID] [int] NULL,
	[SPECIALIZATION_TYPE_ID] [int] NULL,
	[UNIVERSITY_ID] [varchar](70) NULL,
	[UNIVERSITY_YEAR_OF_PASSING] [varchar](8) NULL,
	[IS_HIGHEST_QUALIFICATION] [bit] NULL,
	[CREATED_BY] [varchar](20) NULL,
	[CREATED_DATE] [datetime] NOT NULL,
	[MODIFIED_BY] [varchar](20) NULL,
	[MODIFIED_DATE] [datetime] NULL,
 CONSTRAINT [PK_TBL_USER_EDUCATION_DETAILS] PRIMARY KEY CLUSTERED 
(
	[USER_EDUCATION_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TBL_USER_EMAIL_ADDRESS]    Script Date: 27-Jan-17 1:15:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TBL_USER_EMAIL_ADDRESS](
	[USER_EMAIL_ID] [int] IDENTITY(1,1) NOT NULL,
	[REGISTRATION_NUMBER] [varchar](20) NULL,
	[USER_EMAIL] [varchar](70) NULL,
 CONSTRAINT [PK_TBL_USER_EMAIL_ADDRESS] PRIMARY KEY CLUSTERED 
(
	[USER_EMAIL_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TBL_USER_EXPERIENCE]    Script Date: 27-Jan-17 1:15:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TBL_USER_EXPERIENCE](
	[EXPERIENCE_ID] [int] IDENTITY(1,1) NOT NULL,
	[REGISTRATION_NO] [varchar](20) NOT NULL,
	[USER_COMPANY_NAME] [varchar](80) NOT NULL,
	[IS_CURRENT_COMPANY] [bit] NULL,
	[DESIGNATION_ID] [int] NULL,
	[INDUSTRY_ID] [int] NULL,
	[CITY_CODE] [varchar](20) NULL,
	[TOTAL_WORK_EXPERIENCE] [decimal](4, 2) NULL,
	[REMARK] [varchar](100) NULL,
	[CREATED_BY] [varchar](20) NULL,
	[CREATED_DATE] [datetime] NOT NULL,
	[MODIFIED_BY] [varchar](20) NULL,
	[MODIFIED_DATE] [datetime] NULL,
	[WORK_PERIOD_FROM] [datetime] NULL,
	[WORK_PERIOD_TO] [datetime] NULL,
 CONSTRAINT [PK_TBL_USER_EXPERIENCE] PRIMARY KEY CLUSTERED 
(
	[EXPERIENCE_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TBL_USER_LANGUAGE]    Script Date: 27-Jan-17 1:15:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TBL_USER_LANGUAGE](
	[USER_LANGUAGE_ID] [int] IDENTITY(1,1) NOT NULL,
	[LANGUAGE_ID] [int] NOT NULL,
	[REGISTRATION_NO] [varchar](20) NOT NULL,
	[IS_READ] [bit] NOT NULL,
	[IS_WRITE] [bit] NOT NULL,
	[IS_SPEAK] [bit] NOT NULL,
 CONSTRAINT [PK_TBL_USER_LANGUAGE] PRIMARY KEY CLUSTERED 
(
	[USER_LANGUAGE_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TBL_USER_MENU_MAPPING]    Script Date: 27-Jan-17 1:15:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TBL_USER_MENU_MAPPING](
	[USER_MENU_ID] [int] IDENTITY(1,1) NOT NULL,
	[REGISTRATION_NUMBER] [varchar](20) NULL,
	[MENU_ID] [int] NULL,
	[CREATED_BY] [varchar](10) NULL,
	[CREATED_DATE] [datetime] NULL,
	[USER_TYPE_ID] [int] NULL,
 CONSTRAINT [PK_TBL_USER_MENU_MAPPING] PRIMARY KEY CLUSTERED 
(
	[USER_MENU_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TBL_USER_PERSONAL_DETAILS]    Script Date: 27-Jan-17 1:15:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TBL_USER_PERSONAL_DETAILS](
	[REGISTRATION_NO] [varchar](20) NOT NULL,
	[FIRST_NAME] [varchar](50) NOT NULL,
	[MIDDLE_NAME] [varchar](50) NULL,
	[LAST_NAME] [varchar](50) NOT NULL,
	[FATHER_NAME] [varchar](80) NULL,
	[MOTHER_NAME] [varchar](80) NULL,
	[GENDER_CODE] [char](1) NULL,
	[DATE_OF_BIRTH] [datetime] NULL,
	[PLACE_OF_BIRTH] [varchar](50) NULL,
	[MARITAL_STATUS_ID] [int] NULL,
	[NATIONALITY_ID] [int] NULL,
	[CURRENT_LOCATION] [varchar](50) NULL,
	[RELIGION_ID] [int] NULL,
	[IS_ACTIVE] [bit] NOT NULL,
 CONSTRAINT [PK_TBL_USER_PERSONAL_DETAILS] PRIMARY KEY CLUSTERED 
(
	[REGISTRATION_NO] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TBL_USER_REGISTRATION]    Script Date: 27-Jan-17 1:15:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TBL_USER_REGISTRATION](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[REG_MONTH] [int] NULL,
	[REG_YEAR] [int] NULL,
	[USER_TYPE_ID] [int] NULL,
	[CURRENT_COUNTER] [int] NULL,
 CONSTRAINT [PK_TBL_USER_REGISTRATION] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TBL_USER_REQUIREMENT]    Script Date: 27-Jan-17 1:15:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TBL_USER_REQUIREMENT](
	[USER_REQUIREMENT_ID] [int] IDENTITY(1,1) NOT NULL,
	[REGISTRATION_NO] [varchar](20) NOT NULL,
	[REQUIREMENT_ID] [int] NOT NULL,
	[CANDIDATE_STATUS] [int] NOT NULL,
	[CURRENT_STATUS] [bit] NOT NULL,
	[CREATED_BY] [varchar](20) NULL,
	[CREATED_DATE] [datetime] NOT NULL,
	[MODIFIED_BY] [varchar](20) NULL,
	[MODIFIED_DATE] [datetime] NULL,
 CONSTRAINT [PK_TBL_USER_REQUIREMENT] PRIMARY KEY CLUSTERED 
(
	[USER_REQUIREMENT_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TBL_USER_TYPE]    Script Date: 27-Jan-17 1:15:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TBL_USER_TYPE](
	[USER_TYPE_ID] [int] IDENTITY(1,1) NOT NULL,
	[USER_TYPE] [varchar](50) NOT NULL,
	[IS_ACTIVE] [bit] NOT NULL,
 CONSTRAINT [PK_TBL_USER_TYPE] PRIMARY KEY CLUSTERED 
(
	[USER_TYPE_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TBL_USER_VISA_DETAILS]    Script Date: 27-Jan-17 1:15:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TBL_USER_VISA_DETAILS](
	[USER_VISA_ID] [int] IDENTITY(1,1) NOT NULL,
	[REGISTRATION_NUMBER] [varchar](20) NOT NULL,
	[VISA_ID] [int] NULL,
	[CREATED_DATE] [datetime] NOT NULL,
	[MODIFIED_DATE] [datetime] NOT NULL,
	[CREATED_BY] [varchar](20) NULL,
	[MODIFIED_BY] [varchar](20) NULL,
 CONSTRAINT [PK_TBL_USER_VISA_DETAILS] PRIMARY KEY CLUSTERED 
(
	[USER_VISA_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TBL_VEHICLE_TYPE]    Script Date: 27-Jan-17 1:15:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TBL_VEHICLE_TYPE](
	[VEHICLE_TYPE_ID] [int] IDENTITY(1,1) NOT NULL,
	[VEHICLE_TYPE] [varchar](20) NOT NULL,
	[VEHICLE_ORDER] [int] NOT NULL,
	[IS_ACTIVE] [bit] NOT NULL,
	[CREATED_BY] [varchar](20) NULL,
	[CREATED_DATE] [datetime] NOT NULL,
	[MODIFIED_BY] [varchar](20) NULL,
	[MODIFIED_DATE] [datetime] NOT NULL,
 CONSTRAINT [PK_TBL_VEHICLE_TYPE] PRIMARY KEY CLUSTERED 
(
	[VEHICLE_TYPE_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TBL_VISA_ENDORSEMENT]    Script Date: 27-Jan-17 1:15:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TBL_VISA_ENDORSEMENT](
	[VisaEndorsementId] [int] IDENTITY(1,1) NOT NULL,
	[USER_REQUIREMENT_ID] [int] NOT NULL,
	[SubmissionDate] [date] NULL,
	[SubmissionStatusID] [int] NULL,
	[CreatedBy] [varchar](20) NULL,
	[CreatedDate] [datetime] NULL,
 CONSTRAINT [PK_TBL_VISA_ENDORSEMENT] PRIMARY KEY CLUSTERED 
(
	[VisaEndorsementId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TBL_VISA_MASTER]    Script Date: 27-Jan-17 1:15:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TBL_VISA_MASTER](
	[VISA_ID] [int] IDENTITY(1,1) NOT NULL,
	[REGISTRATION_NUMBER] [varchar](12) NOT NULL,
	[CIVILIAN_NUMBER] [varchar](50) NULL,
	[VISA_NUMBER] [varchar](30) NOT NULL,
	[PLACE_OF_ENDORSEMENT] [varchar](12) NOT NULL,
	[ISSUE_DATE] [datetime] NOT NULL,
	[EXPIRY_DATE] [datetime] NOT NULL,
	[RECIEVED_DATE] [datetime] NOT NULL,
	[FILE_NAME] [varchar](50) NULL,
	[FILE_PATH] [varchar](100) NULL,
	[REMARK] [varchar](100) NULL,
	[CREATED_BY] [varchar](50) NULL,
	[CREATED_DATE] [datetime] NULL,
	[PURPOSE] [varchar](50) NULL,
	[IS_ACTIVE] [bit] NULL,
 CONSTRAINT [PK_TBL_VISA_MASTER] PRIMARY KEY CLUSTERED 
(
	[VISA_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TBL_VISA_SUBMISSION_STATUS]    Script Date: 27-Jan-17 1:15:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TBL_VISA_SUBMISSION_STATUS](
	[VisaSubmissionStatusID] [int] IDENTITY(1,1) NOT NULL,
	[SubmissionStatus] [varchar](30) NULL,
	[CreatedBy] [nchar](10) NULL,
	[CreatedDate] [datetime] NULL,
 CONSTRAINT [PK_TBL_VISA_SUBMISSION_STATUS] PRIMARY KEY CLUSTERED 
(
	[VisaSubmissionStatusID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TempEducation]    Script Date: 27-Jan-17 1:15:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TempEducation](
	[Any graduate] [nvarchar](255) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TempIndustries]    Script Date: 27-Jan-17 1:15:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TempIndustries](
	[F1] [float] NULL,
	[Industries] [nvarchar](255) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TempRoles]    Script Date: 27-Jan-17 1:15:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TempRoles](
	[Admin/Secretarial] [nvarchar](255) NULL,
	[Fresher] [nvarchar](255) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TempSpecialization]    Script Date: 27-Jan-17 1:15:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TempSpecialization](
	[Aviation] [nvarchar](255) NULL,
	[Any] [nvarchar](255) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Tmp_TBL_TASK_MASTER]    Script Date: 27-Jan-17 1:15:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Tmp_TBL_TASK_MASTER](
	[TASK_ID] [int] IDENTITY(1,1) NOT NULL,
	[TASK_NAME] [varchar](100) NULL,
	[TASK_ASSIGNED_TO] [varchar](20) NULL,
	[PERC_COMPLETED] [decimal](5, 2) NULL,
	[CREATED_DATE] [datetime] NULL,
	[CREATED_BY] [varchar](20) NULL,
	[MODIFIED_DATE] [datetime] NULL,
	[MODIFIED_BY] [varchar](20) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  UserDefinedFunction [dbo].[FUNC_USER_contact]    Script Date: 27-Jan-17 1:15:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		YOGENDRA DUBEY
-- Create date:  01ST -OCT -2015
-- Description:	 FUNCTION TO GET USER EMAIL ADDRESS
-- =============================================
CREATE FUNCTION [dbo].[FUNC_USER_contact] 
(	
	-- Add the parameters for the function here
	@REGISTRATION_NUMBER varchar(20)
)
RETURNS TABLE 
AS
RETURN 
(

 SELECT DISTINCT p.REGISTRATION_NUMBER,    
    STUFF((SELECT distinct ',' + p.CONTACT_NO      
     FROM TBL_USER_CONTACTS p1 WITH(NOLOCK)      
                
     WHERE p.REGISTRATION_NUMBER = p1.REGISTRATION_NUMBER      
     FOR XML PATH(''), TYPE      
     ).value('.', 'NVARCHAR(MAX)')      
    ,1,1,'') CONTACT_NO      
  FROM TBL_USER_CONTACTS p  
  where P.REGISTRATION_NUMBER = @REGISTRATION_NUMBER
 )




GO
/****** Object:  UserDefinedFunction [dbo].[FUNC_USER_CONTACTS]    Script Date: 27-Jan-17 1:15:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		YOGENDRA DUBEY
-- Create date:  01ST -OCT -2015
-- Description:	 FUNCTION TO GET USER EMAIL ADDRESS
-- =============================================
CREATE FUNCTION [dbo].[FUNC_USER_CONTACTS] 
(	
	-- Add the parameters for the function here
	@REGISTRATION_NUMBER varchar(20)
)
RETURNS TABLE 
AS
RETURN 
(

 SELECT DISTINCT p.REGISTRATION_NUMBER,    
    STUFF((SELECT distinct ',' + p.CONTACT_NO      
     FROM TBL_USER_CONTACTS p1 WITH(NOLOCK)      
                
     WHERE p.REGISTRATION_NUMBER = p1.REGISTRATION_NUMBER      
     FOR XML PATH(''), TYPE      
     ).value('.', 'NVARCHAR(MAX)')      
    ,1,1,'') CONTACT_NO      
  FROM TBL_USER_CONTACTS p  
  where P.REGISTRATION_NUMBER = @REGISTRATION_NUMBER
 )




GO
/****** Object:  UserDefinedFunction [dbo].[FUNC_USER_EMAIL_ADDRESS]    Script Date: 27-Jan-17 1:15:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		YOGENDRA DUBEY
-- Create date:  01ST -OCT -2015
-- Description:	 FUNCTION TO GET USER EMAIL ADDRESS
-- =============================================
CREATE FUNCTION [dbo].[FUNC_USER_EMAIL_ADDRESS] 
(	
	-- Add the parameters for the function here
	@REGISTRATION_NUMBER varchar(20)
)
RETURNS TABLE 
AS
RETURN 
(

 SELECT DISTINCT p.REGISTRATION_NUMBER,    
    STUFF((SELECT distinct ',' + p.user_email      
     FROM tbl_user_email_address p1 WITH(NOLOCK)      
                
     WHERE p.REGISTRATION_NUMBER = p1.REGISTRATION_NUMBER      
     FOR XML PATH(''), TYPE      
     ).value('.', 'NVARCHAR(MAX)')      
    ,1,1,'') user_email      
  FROM tbl_user_email_address p  
  where P.REGISTRATION_NUMBER = @REGISTRATION_NUMBER
 )




GO
/****** Object:  UserDefinedFunction [dbo].[FUNC_USER_HIGHEST_EDUCATION]    Script Date: 27-Jan-17 1:15:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		YOGENDRA DUBEY
-- Create date:  01ST -OCT -2015
-- Description:	 FUNCTION TO GET USER EMAIL ADDRESS
-- =============================================
create FUNCTION [dbo].[FUNC_USER_HIGHEST_EDUCATION]
(	
	-- Add the parameters for the function here
	@REGISTRATION_NUMBER varchar(20)
)
RETURNS TABLE 
AS
RETURN 
(

SELECT DISTINCT   
    STUFF((SELECT distinct ',' + tet.EDUCATION_TYPE      
     FROM TBL_USER_EDUCATION_DETAILS p1 WITH(NOLOCK) 
     JOIN TBL_EDUCATION_TYPE_MASTER TET ON p1.EDUCATION_TYPE_ID = TET.EDUCATION_TYPE_ID  
     WHERE p.REGISTRATION_NO = p1.REGISTRATION_NO      
     FOR XML PATH(''), TYPE      
     ).value('.', 'NVARCHAR(MAX)')      
    ,1,1,'') HIGHEST_EDUCATION      
  FROM TBL_USER_EDUCATION_DETAILS p WITH(NOLOCK) 
 where P.REGISTRATION_NO = @REGISTRATION_NUMBER AND IS_HIGHEST_QUALIFICATION =1
 )



GO
ALTER TABLE [dbo].[TBL_ADVERTISEMENT_MASTER] ADD  CONSTRAINT [DF__TBL_ADVER__IS_AC__681373AD]  DEFAULT ((1)) FOR [IS_ACTIVE]
GO
ALTER TABLE [dbo].[TBL_ADVERTISEMENT_MASTER] ADD  CONSTRAINT [DF__TBL_ADVER__CREAT__671F4F74]  DEFAULT (getdate()) FOR [CREATED_DATE]
GO
ALTER TABLE [dbo].[TBL_ADVERTISEMENT_MASTER] ADD  CONSTRAINT [DF_TBL_ADVERTISEMENT_MASTER_MODIFIED_DATE]  DEFAULT (getdate()) FOR [MODIFIED_DATE]
GO
ALTER TABLE [dbo].[TBL_COMPANY_MASTER] ADD  CONSTRAINT [DF_TBL_COMPANY_MASTER_CREATED_DATE]  DEFAULT (getdate()) FOR [CREATED_DATE]
GO
ALTER TABLE [dbo].[TBL_COMPANY_MASTER] ADD  CONSTRAINT [DF_TBL_COMPANY_MASTER_MODIFIED_DATE]  DEFAULT (getdate()) FOR [MODIFIED_DATE]
GO
ALTER TABLE [dbo].[TBL_COMPANY_MASTER] ADD  CONSTRAINT [DF_TBL_COMPANY_MASTER_IS_ACTIVE]  DEFAULT ((1)) FOR [IS_ACTIVE]
GO
ALTER TABLE [dbo].[TBL_DESIGNATION_MASTER] ADD  CONSTRAINT [DF_TBL_DESIGNATION_MASTER_IS_ACTIVE]  DEFAULT ((1)) FOR [IS_ACTIVE]
GO
ALTER TABLE [dbo].[TBL_DESIGNATION_MASTER] ADD  CONSTRAINT [DF_TBL_DESIGNATION_MASTER_CREATED_DATE]  DEFAULT (getdate()) FOR [CREATED_DATE]
GO
ALTER TABLE [dbo].[TBL_DESIGNATION_MASTER] ADD  CONSTRAINT [DF_TBL_DESIGNATION_MASTER_MODIFIED_DATE]  DEFAULT (getdate()) FOR [MODIFIED_DATE]
GO
ALTER TABLE [dbo].[TBL_ERROR_LOG] ADD  DEFAULT (getdate()) FOR [CREATED_DATE]
GO
ALTER TABLE [dbo].[TBL_INDUSTRY_MASTER] ADD  CONSTRAINT [DF_TBL_INDUSTRY_MASTER_IS_ACTIVE]  DEFAULT ((1)) FOR [IS_ACTIVE]
GO
ALTER TABLE [dbo].[TBL_INDUSTRY_MASTER] ADD  CONSTRAINT [DF_TBL_INDUSTRY_MASTER_CREATED_DATE]  DEFAULT (getdate()) FOR [CREATED_DATE]
GO
ALTER TABLE [dbo].[TBL_INDUSTRY_MASTER] ADD  CONSTRAINT [DF_TBL_INDUSTRY_MASTER_MODIFIED_DATE]  DEFAULT (getdate()) FOR [MODIFIED_DATE]
GO
ALTER TABLE [dbo].[TBL_INTERVIEW] ADD  CONSTRAINT [DF_TBL_INTERVIEW_IsSelected]  DEFAULT ((0)) FOR [IsSelected]
GO
ALTER TABLE [dbo].[TBL_INTERVIEW] ADD  CONSTRAINT [DF_TBL_INTERVIEW_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[TBL_INTERVIEW_MODE_MASTER] ADD  CONSTRAINT [DF_TBL_INTERVIEW_MODE_MASTER_CREATED_DATE]  DEFAULT (getdate()) FOR [CREATED_DATE]
GO
ALTER TABLE [dbo].[TBL_INTERVIEW_MODE_MASTER] ADD  CONSTRAINT [DF_TBL_INTERVIEW_MODE_MASTER_MODIFIED_DATE]  DEFAULT (getdate()) FOR [MODIFIED_DATE]
GO
ALTER TABLE [dbo].[TBL_REQUIREMENT_ALLOWANCE] ADD  CONSTRAINT [DF_TBL_REQUIREMENT_ALLOWANCE_CREATED_DATE]  DEFAULT (getdate()) FOR [CREATED_DATE]
GO
ALTER TABLE [dbo].[TBL_REQUIREMENT_DETAILS] ADD  CONSTRAINT [DF_TBL_REQUIREMENT_DETAILS_IS_ACTIVE]  DEFAULT ((0)) FOR [IS_ACTIVE]
GO
ALTER TABLE [dbo].[TBL_REQUIREMENT_GENDER] ADD  CONSTRAINT [DF_TBL_REQUIREMENT_GENDER_CREATED_DATE]  DEFAULT (getdate()) FOR [CREATED_DATE]
GO
ALTER TABLE [dbo].[TBL_REQUIREMENT_GENDER] ADD  CONSTRAINT [DF_TBL_REQUIREMENT_GENDER_IS_ACTIVE]  DEFAULT ((1)) FOR [IS_ACTIVE]
GO
ALTER TABLE [dbo].[TBL_REQUIREMENT_LANGUAGE] ADD  CONSTRAINT [DF_TBL_REQUIREMENT_LANGUAGE_CAN_READ]  DEFAULT ((0)) FOR [CAN_READ]
GO
ALTER TABLE [dbo].[TBL_REQUIREMENT_LANGUAGE] ADD  CONSTRAINT [DF_TBL_REQUIREMENT_LANGUAGE_CAN_WRITE]  DEFAULT ((0)) FOR [CAN_WRITE]
GO
ALTER TABLE [dbo].[TBL_REQUIREMENT_LANGUAGE] ADD  CONSTRAINT [DF_TBL_REQUIREMENT_LANGUAGE_CAN_SPEAK]  DEFAULT ((0)) FOR [CAN_SPEAK]
GO
ALTER TABLE [dbo].[TBL_REQUIREMENT_LANGUAGE] ADD  CONSTRAINT [DF_TBL_REQUIREMENT_LANGUAGE_IS_ACTIVE]  DEFAULT ((0)) FOR [IS_ACTIVE]
GO
ALTER TABLE [dbo].[TBL_REQUIREMENT_LANGUAGE] ADD  CONSTRAINT [DF_TBL_REQUIREMENT_LANGUAGE_CREATED_DATE]  DEFAULT (getdate()) FOR [CREATED_DATE]
GO
ALTER TABLE [dbo].[TBL_REQUIREMENT_RELIGION] ADD  CONSTRAINT [DF_TBL_REQUIREMENT_RELIGION_CREATED_DATE]  DEFAULT (getdate()) FOR [CREATED_DATE]
GO
ALTER TABLE [dbo].[TBL_REQUIREMENT_RELIGION] ADD  CONSTRAINT [DF_TBL_REQUIREMENT_RELIGION_IS_ACTIVE]  DEFAULT ((1)) FOR [IS_ACTIVE]
GO
ALTER TABLE [dbo].[TBL_TASK_MASTER] ADD  CONSTRAINT [DF_TBL_TASK_MASTER_CREATED_DATE]  DEFAULT (getdate()) FOR [CREATED_DATE]
GO
ALTER TABLE [dbo].[TBL_USER_DETAILS] ADD  CONSTRAINT [DF_LOGIN_PASSWORD]  DEFAULT ('pass@123') FOR [LOGIN_PASSWORD]
GO
ALTER TABLE [dbo].[TBL_USER_DOCUMENTS] ADD  CONSTRAINT [DF_TBL_USER_DOCUMENTS_IS_ACTIVE]  DEFAULT ((1)) FOR [IS_ACTIVE]
GO
ALTER TABLE [dbo].[TBL_USER_DOCUMENTS] ADD  CONSTRAINT [DF_TBL_USER_DOCUMENTS_CREATED_DATE]  DEFAULT (getdate()) FOR [CREATED_DATE]
GO
ALTER TABLE [dbo].[TBL_USER_DOCUMENTS] ADD  CONSTRAINT [DF_TBL_USER_DOCUMENTS_MODIFIED_DATE]  DEFAULT (getdate()) FOR [MODIFIED_DATE]
GO
ALTER TABLE [dbo].[TBL_USER_PERSONAL_DETAILS] ADD  CONSTRAINT [DF_TBL_USER_PERSONAL_DETAILS_IS_ACTIVE]  DEFAULT ((1)) FOR [IS_ACTIVE]
GO
ALTER TABLE [dbo].[TBL_ADVERTISEMENT_MASTER]  WITH CHECK ADD  CONSTRAINT [FK_TBL_ADVERTISEMENT_MASTER_TBL_REQUIREMENT_DETAILS] FOREIGN KEY([REQUIREMENT_ID])
REFERENCES [dbo].[TBL_REQUIREMENT_DETAILS] ([REQUIREMENT_ID])
GO
ALTER TABLE [dbo].[TBL_ADVERTISEMENT_MASTER] CHECK CONSTRAINT [FK_TBL_ADVERTISEMENT_MASTER_TBL_REQUIREMENT_DETAILS]
GO
ALTER TABLE [dbo].[TBL_DESIGNATION_MASTER]  WITH CHECK ADD  CONSTRAINT [FK_TBL_DESIGNATION_MASTER_TBL_INDUSTRY_MASTER] FOREIGN KEY([INDUSTRY_ID])
REFERENCES [dbo].[TBL_INDUSTRY_MASTER] ([INDUSTRY_ID])
GO
ALTER TABLE [dbo].[TBL_DESIGNATION_MASTER] CHECK CONSTRAINT [FK_TBL_DESIGNATION_MASTER_TBL_INDUSTRY_MASTER]
GO
ALTER TABLE [dbo].[TBL_INTERVIEW]  WITH CHECK ADD  CONSTRAINT [FK_TBL_INTERVIEW_TBL_INTERVIEW_MODE_MASTER] FOREIGN KEY([InterviewModeId])
REFERENCES [dbo].[TBL_INTERVIEW_MODE_MASTER] ([INTERVIEW_MODE_ID])
GO
ALTER TABLE [dbo].[TBL_INTERVIEW] CHECK CONSTRAINT [FK_TBL_INTERVIEW_TBL_INTERVIEW_MODE_MASTER]
GO
ALTER TABLE [dbo].[TBL_INTERVIEW]  WITH CHECK ADD  CONSTRAINT [FK_TBL_INTERVIEW_TBL_REQUIREMENT_DETAILS] FOREIGN KEY([RequirementID])
REFERENCES [dbo].[TBL_REQUIREMENT_DETAILS] ([REQUIREMENT_ID])
GO
ALTER TABLE [dbo].[TBL_INTERVIEW] CHECK CONSTRAINT [FK_TBL_INTERVIEW_TBL_REQUIREMENT_DETAILS]
GO
ALTER TABLE [dbo].[TBL_INTERVIEW]  WITH CHECK ADD  CONSTRAINT [FK_TBL_INTERVIEW_TBL_USER_DETAILS] FOREIGN KEY([Agent_ID])
REFERENCES [dbo].[TBL_USER_DETAILS] ([REGISTRATION_NO])
GO
ALTER TABLE [dbo].[TBL_INTERVIEW] CHECK CONSTRAINT [FK_TBL_INTERVIEW_TBL_USER_DETAILS]
GO
ALTER TABLE [dbo].[TBL_MEDICAL]  WITH CHECK ADD  CONSTRAINT [FK_TBL_MEDICAL_TBL_USER_REQUIREMENT] FOREIGN KEY([USER_REQUIREMENT_ID])
REFERENCES [dbo].[TBL_USER_REQUIREMENT] ([USER_REQUIREMENT_ID])
GO
ALTER TABLE [dbo].[TBL_MEDICAL] CHECK CONSTRAINT [FK_TBL_MEDICAL_TBL_USER_REQUIREMENT]
GO
ALTER TABLE [dbo].[TBL_MOFA]  WITH CHECK ADD  CONSTRAINT [FK_TBL_MOFA_TBL_USER_REQUIREMENT] FOREIGN KEY([USER_REQUIREMENT_ID])
REFERENCES [dbo].[TBL_USER_REQUIREMENT] ([USER_REQUIREMENT_ID])
GO
ALTER TABLE [dbo].[TBL_MOFA] CHECK CONSTRAINT [FK_TBL_MOFA_TBL_USER_REQUIREMENT]
GO
ALTER TABLE [dbo].[TBL_POLICY]  WITH CHECK ADD  CONSTRAINT [FK_TBL_POLICY_TBL_USER_REQUIREMENT] FOREIGN KEY([USER_REQUIREMENT_ID])
REFERENCES [dbo].[TBL_USER_REQUIREMENT] ([USER_REQUIREMENT_ID])
GO
ALTER TABLE [dbo].[TBL_POLICY] CHECK CONSTRAINT [FK_TBL_POLICY_TBL_USER_REQUIREMENT]
GO
ALTER TABLE [dbo].[TBL_REQUIREMENT_ALLOWANCE]  WITH CHECK ADD  CONSTRAINT [FK_TBL_REQUIREMENT_ALLOWANCE_TBL_ALLOWANCE_MASTER] FOREIGN KEY([ALLOWANCE_ID])
REFERENCES [dbo].[TBL_ALLOWANCE_MASTER] ([ALLOWANCE_ID])
GO
ALTER TABLE [dbo].[TBL_REQUIREMENT_ALLOWANCE] CHECK CONSTRAINT [FK_TBL_REQUIREMENT_ALLOWANCE_TBL_ALLOWANCE_MASTER]
GO
ALTER TABLE [dbo].[TBL_REQUIREMENT_ALLOWANCE]  WITH CHECK ADD  CONSTRAINT [FK_TBL_REQUIREMENT_ALLOWANCE_TBL_ALLOWANCE_TYPE_MASTER] FOREIGN KEY([ALLOWANCE_TYPE_ID])
REFERENCES [dbo].[TBL_ALLOWANCE_TYPE_MASTER] ([ALLOWANCE_TYPE_ID])
GO
ALTER TABLE [dbo].[TBL_REQUIREMENT_ALLOWANCE] CHECK CONSTRAINT [FK_TBL_REQUIREMENT_ALLOWANCE_TBL_ALLOWANCE_TYPE_MASTER]
GO
ALTER TABLE [dbo].[TBL_REQUIREMENT_ALLOWANCE]  WITH CHECK ADD  CONSTRAINT [FK_TBL_REQUIREMENT_ALLOWANCE_TBL_REQUIREMENT_DETAILS] FOREIGN KEY([REQUIRMENT_ID])
REFERENCES [dbo].[TBL_REQUIREMENT_DETAILS] ([REQUIREMENT_ID])
GO
ALTER TABLE [dbo].[TBL_REQUIREMENT_ALLOWANCE] CHECK CONSTRAINT [FK_TBL_REQUIREMENT_ALLOWANCE_TBL_REQUIREMENT_DETAILS]
GO
ALTER TABLE [dbo].[TBL_REQUIREMENT_GENDER]  WITH CHECK ADD  CONSTRAINT [FK_TBL_REQUIREMENT_GENDER_TBL_REQUIREMENT_GENDER] FOREIGN KEY([REQUIREMENT_ID])
REFERENCES [dbo].[TBL_REQUIREMENT_DETAILS] ([REQUIREMENT_ID])
GO
ALTER TABLE [dbo].[TBL_REQUIREMENT_GENDER] CHECK CONSTRAINT [FK_TBL_REQUIREMENT_GENDER_TBL_REQUIREMENT_GENDER]
GO
ALTER TABLE [dbo].[TBL_REQUIREMENT_LANGUAGE]  WITH CHECK ADD  CONSTRAINT [FK_TBL_REQUIREMENT_LANGUAGE_TBL_REQUIREMENT_DETAILS] FOREIGN KEY([REQUIRMENT_ID])
REFERENCES [dbo].[TBL_REQUIREMENT_DETAILS] ([REQUIREMENT_ID])
GO
ALTER TABLE [dbo].[TBL_REQUIREMENT_LANGUAGE] CHECK CONSTRAINT [FK_TBL_REQUIREMENT_LANGUAGE_TBL_REQUIREMENT_DETAILS]
GO
ALTER TABLE [dbo].[TBL_REQUIREMENT_RELIGION]  WITH CHECK ADD  CONSTRAINT [FK_TBL_REQUIREMENT_RELIGION_TBL_REQUIREMENT_DETAILS] FOREIGN KEY([REQUIREMENT_ID])
REFERENCES [dbo].[TBL_REQUIREMENT_DETAILS] ([REQUIREMENT_ID])
GO
ALTER TABLE [dbo].[TBL_REQUIREMENT_RELIGION] CHECK CONSTRAINT [FK_TBL_REQUIREMENT_RELIGION_TBL_REQUIREMENT_DETAILS]
GO
ALTER TABLE [dbo].[TBL_TICKET]  WITH CHECK ADD  CONSTRAINT [FK_TBL_TICKET_TBL_USER_REQUIREMENT] FOREIGN KEY([USER_REQUIREMENT_ID])
REFERENCES [dbo].[TBL_USER_REQUIREMENT] ([USER_REQUIREMENT_ID])
GO
ALTER TABLE [dbo].[TBL_TICKET] CHECK CONSTRAINT [FK_TBL_TICKET_TBL_USER_REQUIREMENT]
GO
ALTER TABLE [dbo].[TBL_USER_DOCUMENTS]  WITH CHECK ADD  CONSTRAINT [FK_TBL_USER_DOCUMENTS_TBL_USER_DETAILS] FOREIGN KEY([REGISTRATION_NO])
REFERENCES [dbo].[TBL_USER_DETAILS] ([REGISTRATION_NO])
GO
ALTER TABLE [dbo].[TBL_USER_DOCUMENTS] CHECK CONSTRAINT [FK_TBL_USER_DOCUMENTS_TBL_USER_DETAILS]
GO
ALTER TABLE [dbo].[TBL_USER_REQUIREMENT]  WITH CHECK ADD  CONSTRAINT [FK_TBL_USER_REQUIREMENT_TBL_REQUIREMENT_DETAILS] FOREIGN KEY([REQUIREMENT_ID])
REFERENCES [dbo].[TBL_REQUIREMENT_DETAILS] ([REQUIREMENT_ID])
GO
ALTER TABLE [dbo].[TBL_USER_REQUIREMENT] CHECK CONSTRAINT [FK_TBL_USER_REQUIREMENT_TBL_REQUIREMENT_DETAILS]
GO
ALTER TABLE [dbo].[TBL_USER_REQUIREMENT]  WITH CHECK ADD  CONSTRAINT [FK_TBL_USER_REQUIREMENT_TBL_USER_DETAILS] FOREIGN KEY([REGISTRATION_NO])
REFERENCES [dbo].[TBL_USER_DETAILS] ([REGISTRATION_NO])
GO
ALTER TABLE [dbo].[TBL_USER_REQUIREMENT] CHECK CONSTRAINT [FK_TBL_USER_REQUIREMENT_TBL_USER_DETAILS]
GO
ALTER TABLE [dbo].[TBL_VISA_ENDORSEMENT]  WITH CHECK ADD  CONSTRAINT [FK_TBL_VISA_ENDORSEMENT_TBL_USER_REQUIREMENT] FOREIGN KEY([USER_REQUIREMENT_ID])
REFERENCES [dbo].[TBL_USER_REQUIREMENT] ([USER_REQUIREMENT_ID])
GO
ALTER TABLE [dbo].[TBL_VISA_ENDORSEMENT] CHECK CONSTRAINT [FK_TBL_VISA_ENDORSEMENT_TBL_USER_REQUIREMENT]
GO
USE [master]
GO
ALTER DATABASE [ArbabTravelsERP] SET  READ_WRITE 
GO
