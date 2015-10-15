﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using DigoFramework;
using NetZ.Web.Html;

namespace NetZ.Web.Server
{
    /// <summary>
    /// Classe que será utilizada para responder uma solicitação enviada por um cliente por uma
    /// conexão HTTP. Esta classe contém métodos e propriedades relevantes para construção da resposta.
    /// </summary>
    public class Resposta : SistemaBase.Objeto
    {
        #region Constantes

        public enum EnmContentType
        {
            _123_APPLICATION_VNDLOTUS_1_2_3,
            _3DML_TEXT_VNDIN3D3DML,
            _3G2_VIDEO_3GPP2,
            _3GP_VIDEO_3GPP,
            _7Z_APPLICATION_X_7Z_COMPRESSED,
            AAB_APPLICATION_X_AUTHORWARE_BIN,
            AAC_AUDIO_X_AAC,
            AAM_APPLICATION_X_AUTHORWARE_MAP,
            AAS_APPLICATION_X_AUTHORWARE_SEG,
            ABW_APPLICATION_X_ABIWORD,
            AC_APPLICATION_PKIX_ATTR_CERT,
            ACC_APPLICATION_VNDAMERICANDYNAMICSACC,
            ACE_APPLICATION_X_ACE_COMPRESSED,
            ACU_APPLICATION_VNDACUCOBOL,
            ADP_AUDIO_ADPCM,
            AEP_APPLICATION_VNDAUDIOGRAPH,
            AFP_APPLICATION_VNDIBMMODCAP,
            AHEAD_APPLICATION_VNDAHEADSPACE,
            AI_APPLICATION_POSTSCRIPT,
            AIF_AUDIO_X_AIFF,
            AIR_APPLICATION_VNDADOBEAIR_APPLICATION_INSTALLER_PACKAGE_ZIP,
            AIT_APPLICATION_VNDDVBAIT,
            AMI_APPLICATION_VNDAMIGAAMI,
            APK_APPLICATION_VNDANDROIDPACKAGE_ARCHIVE,
            APPLICATION_APPLICATION_X_MS_APPLICATION,
            APPLICATION_PGP_ENCRYPTED,
            APR_APPLICATION_VNDLOTUS_APPROACH,
            ASF_VIDEO_X_MS_ASF,
            ASO_APPLICATION_VNDACCPACSIMPLYASO,
            ATC_APPLICATION_VNDACUCORP,
            ATOM_XML_APPLICATION_ATOM_XML,
            ATOMCAT_APPLICATION_ATOMCAT_XML,
            ATOMSVC_APPLICATION_ATOMSVC_XML,
            ATX_APPLICATION_VNDANTIXGAME_COMPONENT,
            AU_AUDIO_BASIC,
            AVI_VIDEO_X_MSVIDEO,
            AW_APPLICATION_APPLIXWARE,
            AZF_APPLICATION_VNDAIRZIPFILESECUREAZF,
            AZS_APPLICATION_VNDAIRZIPFILESECUREAZS,
            AZW_APPLICATION_VNDAMAZONEBOOK,
            BCPIO_APPLICATION_X_BCPIO,
            BDF_APPLICATION_X_FONT_BDF,
            BDM_APPLICATION_VNDSYNCMLDM_WBXML,
            BED_APPLICATION_VNDREALVNCBED,
            BH2_APPLICATION_VNDFUJITSUOASYSPRS,
            BIN_APPLICATION_OCTET_STREAM,
            BMI_APPLICATION_VNDBMI,
            BMP_IMAGE_BMP,
            BOX_APPLICATION_VNDPREVIEWSYSTEMSBOX,
            BTIF_IMAGE_PRSBTIF,
            BZ_APPLICATION_X_BZIP,
            BZ2_APPLICATION_X_BZIP2,
            C_TEXT_X_C,
            C11AMC_APPLICATION_VNDCLUETRUSTCARTOMOBILE_CONFIG,
            C11AMZ_APPLICATION_VNDCLUETRUSTCARTOMOBILE_CONFIG_PKG,
            C4G_APPLICATION_VNDCLONKC4GROUP,
            CAB_APPLICATION_VNDMS_CAB_COMPRESSED,
            CAR_APPLICATION_VNDCURLCAR,
            CAT_APPLICATION_VNDMS_PKISECCAT,
            CCXML_APPLICATION_CCXML_XML,
            CDBCMSG_APPLICATION_VNDCONTACTCMSG,
            CDKEY_APPLICATION_VNDMEDIASTATIONCDKEY,
            CDMIA_APPLICATION_CDMI_CAPABILITY,
            CDMIC_APPLICATION_CDMI_CONTAINER,
            CDMID_APPLICATION_CDMI_DOMAIN,
            CDMIO_APPLICATION_CDMI_OBJECT,
            CDMIQ_APPLICATION_CDMI_QUEUE,
            CDX_CHEMICAL_X_CDX,
            CDXML_APPLICATION_VNDCHEMDRAW_XML,
            CDY_APPLICATION_VNDCINDERELLA,
            CER_APPLICATION_PKIX_CERT,
            CGM_IMAGE_CGM,
            CHAT_APPLICATION_X_CHAT,
            CHM_APPLICATION_VNDMS_HTMLHELP,
            CHRT_APPLICATION_VNDKDEKCHART,
            CIF_CHEMICAL_X_CIF,
            CII_APPLICATION_VNDANSER_WEB_CERTIFICATE_ISSUE_INITIATION,
            CIL_APPLICATION_VNDMS_ARTGALRY,
            CLA_APPLICATION_VNDCLAYMORE,
            CLASS_APPLICATION_JAVA_VM,
            CLKK_APPLICATION_VNDCRICKCLICKERKEYBOARD,
            CLKP_APPLICATION_VNDCRICKCLICKERPALETTE,
            CLKT_APPLICATION_VNDCRICKCLICKERTEMPLATE,
            CLKW_APPLICATION_VNDCRICKCLICKERWORDBANK,
            CLKX_APPLICATION_VNDCRICKCLICKER,
            CLP_APPLICATION_X_MSCLIP,
            CMC_APPLICATION_VNDCOSMOCALLER,
            CMDF_CHEMICAL_X_CMDF,
            CML_CHEMICAL_X_CML,
            CMP_APPLICATION_VNDYELLOWRIVER_CUSTOM_MENU,
            CMX_IMAGE_X_CMX,
            COD_APPLICATION_VNDRIMCOD,
            CPIO_APPLICATION_X_CPIO,
            CPT_APPLICATION_MAC_COMPACTPRO,
            CRD_APPLICATION_X_MSCARDFILE,
            CRL_APPLICATION_PKIX_CRL,
            CRYPTONOTE_APPLICATION_VNDRIGCRYPTONOTE,
            CSH_APPLICATION_X_CSH,
            CSML_CHEMICAL_X_CSML,
            CSP_APPLICATION_VNDCOMMONSPACE,
            CSS_TEXT_CSS,
            CSV_TEXT_CSV,
            CU_APPLICATION_CU_SEEME,
            CURL_TEXT_VNDCURL,
            CWW_APPLICATION_PRSCWW,
            DAE_MODEL_VNDCOLLADA_XML,
            DAF_APPLICATION_VNDMOBIUSDAF,
            DAVMOUNT_APPLICATION_DAVMOUNT_XML,
            DCURL_TEXT_VNDCURLDCURL,
            DD2_APPLICATION_VNDOMADD2_XML,
            DDD_APPLICATION_VNDFUJIXEROXDDD,
            DEB_APPLICATION_X_DEBIAN_PACKAGE,
            DER_APPLICATION_X_X509_CA_CERT,
            DFAC_APPLICATION_VNDDREAMFACTORY,
            DIR_APPLICATION_X_DIRECTOR,
            DIS_APPLICATION_VNDMOBIUSDIS,
            DJVU_IMAGE_VNDDJVU,
            DNA_APPLICATION_VNDDNA,
            DOC_APPLICATION_MSWORD,
            DOCM_APPLICATION_VNDMS_WORDDOCUMENTMACROENABLED12,
            DOCX_APPLICATION_VNDOPENXMLFORMATS_OFFICEDOCUMENTWORDPROCESSINGMLDOCUMENT,
            DOTM_APPLICATION_VNDMS_WORDTEMPLATEMACROENABLED12,
            DOTX_APPLICATION_VNDOPENXMLFORMATS_OFFICEDOCUMENTWORDPROCESSINGMLTEMPLATE,
            DP_APPLICATION_VNDOSGIDP,
            DPG_APPLICATION_VNDDPGRAPH,
            DRA_AUDIO_VNDDRA,
            DSC_TEXT_PRSLINESTAG,
            DSSC_APPLICATION_DSSC_DER,
            DTB_APPLICATION_X_DTBOOK_XML,
            DTD_APPLICATION_XML_DTD,
            DTS_AUDIO_VNDDTS,
            DTSHD_AUDIO_VNDDTSHD,
            DVI_APPLICATION_X_DVI,
            DWF_MODEL_VNDDWF,
            DWG_IMAGE_VNDDWG,
            DXF_IMAGE_VNDDXF,
            DXP_APPLICATION_VNDSPOTFIREDXP,
            ECELP4800_AUDIO_VNDNUERAECELP4800,
            ECELP7470_AUDIO_VNDNUERAECELP7470,
            ECELP9600_AUDIO_VNDNUERAECELP9600,
            EDM_APPLICATION_VNDNOVADIGMEDM,
            EDX_APPLICATION_VNDNOVADIGMEDX,
            EFIF_APPLICATION_VNDPICSEL,
            EI6_APPLICATION_VNDPGOSASLI,
            EML_MESSAGE_RFC822,
            EMMA_APPLICATION_EMMA_XML,
            EOL_AUDIO_VNDDIGITAL_WINDS,
            EOT_APPLICATION_VNDMS_FONTOBJECT,
            EPUB_APPLICATION_EPUB_ZIP,
            ES_APPLICATION_ECMASCRIPT,
            ES3_APPLICATION_VNDESZIGNO3_XML,
            ESF_APPLICATION_VNDEPSONESF,
            ETX_TEXT_X_SETEXT,
            EXE_APPLICATION_X_MSDOWNLOAD,
            EXI_APPLICATION_EXI,
            EXT_APPLICATION_VNDNOVADIGMEXT,
            EZ2_APPLICATION_VNDEZPIX_ALBUM,
            EZ3_APPLICATION_VNDEZPIX_PACKAGE,
            F_TEXT_X_FORTRAN,
            F4V_VIDEO_X_F4V,
            FBS_IMAGE_VNDFASTBIDSHEET,
            FCS_APPLICATION_VNDISACFCS,
            FDF_APPLICATION_VNDFDF,
            FE_LAUNCH_APPLICATION_VNDDENOVOFCSELAYOUT_LINK,
            FG5_APPLICATION_VNDFUJITSUOASYSGP,
            FH_IMAGE_X_FREEHAND,
            FIG_APPLICATION_X_XFIG,
            FLI_VIDEO_X_FLI,
            FLO_APPLICATION_VNDMICROGRAFXFLO,
            FLV_VIDEO_X_FLV,
            FLW_APPLICATION_VNDKDEKIVIO,
            FLX_TEXT_VNDFMIFLEXSTOR,
            FLY_TEXT_VNDFLY,
            FM_APPLICATION_VNDFRAMEMAKER,
            FNC_APPLICATION_VNDFROGANSFNC,
            FPX_IMAGE_VNDFPX,
            FSC_APPLICATION_VNDFSCWEBLAUNCH,
            FST_IMAGE_VNDFST,
            FTC_APPLICATION_VNDFLUXTIMECLIP,
            FTI_APPLICATION_VNDANSER_WEB_FUNDS_TRANSFER_INITIATION,
            FVT_VIDEO_VNDFVT,
            FXP_APPLICATION_VNDADOBEFXP,
            FZS_APPLICATION_VNDFUZZYSHEET,
            G2W_APPLICATION_VNDGEOPLAN,
            G3_IMAGE_G3FAX,
            G3W_APPLICATION_VNDGEOSPACE,
            GAC_APPLICATION_VNDGROOVE_ACCOUNT,
            GDL_MODEL_VNDGDL,
            GEO_APPLICATION_VNDDYNAGEO,
            GEX_APPLICATION_VNDGEOMETRY_EXPLORER,
            GGB_APPLICATION_VNDGEOGEBRAFILE,
            GGT_APPLICATION_VNDGEOGEBRATOOL,
            GHF_APPLICATION_VNDGROOVE_HELP,
            GIF_IMAGE_GIF,
            GIM_APPLICATION_VNDGROOVE_IDENTITY_MESSAGE,
            GMX_APPLICATION_VNDGMX,
            GNUMERIC_APPLICATION_X_GNUMERIC,
            GPH_APPLICATION_VNDFLOGRAPHIT,
            GQF_APPLICATION_VNDGRAFEQ,
            GRAM_APPLICATION_SRGS,
            GRV_APPLICATION_VNDGROOVE_INJECTOR,
            GRXML_APPLICATION_SRGS_XML,
            GSF_APPLICATION_X_FONT_GHOSTSCRIPT,
            GTAR_APPLICATION_X_GTAR,
            GTM_APPLICATION_VNDGROOVE_TOOL_MESSAGE,
            GTW_MODEL_VNDGTW,
            GV_TEXT_VNDGRAPHVIZ,
            GXT_APPLICATION_VNDGEONEXT,
            H261_VIDEO_H261,
            H263_VIDEO_H263,
            H264_VIDEO_H264,
            HAL_APPLICATION_VNDHAL_XML,
            HBCI_APPLICATION_VNDHBCI,
            HDF_APPLICATION_X_HDF,
            HLP_APPLICATION_WINHLP,
            HPGL_APPLICATION_VNDHP_HPGL,
            HPID_APPLICATION_VNDHP_HPID,
            HPS_APPLICATION_VNDHP_HPS,
            HQX_APPLICATION_MAC_BINHEX40,
            HTKE_APPLICATION_VNDKENAMEAAPP,
            HTML_TEXT_HTML,
            HVD_APPLICATION_VNDYAMAHAHV_DIC,
            HVP_APPLICATION_VNDYAMAHAHV_VOICE,
            HVS_APPLICATION_VNDYAMAHAHV_SCRIPT,
            I2G_APPLICATION_VNDINTERGEO,
            ICC_APPLICATION_VNDICCPROFILE,
            ICE_X_CONFERENCE_X_COOLTALK,
            ICO_IMAGE_X_ICON,
            ICS_TEXT_CALENDAR,
            IEF_IMAGE_IEF,
            IFM_APPLICATION_VNDSHANAINFORMEDFORMDATA,
            IGL_APPLICATION_VNDIGLOADER,
            IGM_APPLICATION_VNDINSORSIGM,
            IGS_MODEL_IGES,
            IGX_APPLICATION_VNDMICROGRAFXIGX,
            IIF_APPLICATION_VNDSHANAINFORMEDINTERCHANGE,
            IMP_APPLICATION_VNDACCPACSIMPLYIMP,
            IMS_APPLICATION_VNDMS_IMS,
            IPFIX_APPLICATION_IPFIX,
            IPK_APPLICATION_VNDSHANAINFORMEDPACKAGE,
            IRM_APPLICATION_VNDIBMRIGHTS_MANAGEMENT,
            IRP_APPLICATION_VNDIREPOSITORYPACKAGE_XML,
            ITP_APPLICATION_VNDSHANAINFORMEDFORMTEMPLATE,
            IVP_APPLICATION_VNDIMMERVISION_IVP,
            IVU_APPLICATION_VNDIMMERVISION_IVU,
            JAD_TEXT_VNDSUNJ2MEAPP_DESCRIPTOR,
            JAM_APPLICATION_VNDJAM,
            JAR_APPLICATION_JAVA_ARCHIVE,
            JAVA_TEXT_X_JAVA_SOURCE_JAVA,
            JISP_APPLICATION_VNDJISP,
            JLT_APPLICATION_VNDHP_JLYT,
            JNLP_APPLICATION_X_JAVA_JNLP_FILE,
            JODA_APPLICATION_VNDJOOSTJODA_ARCHIVE,
            JPEG_JPG_IMAGE_JPEG,
            JPGV_VIDEO_JPEG,
            JPM_VIDEO_JPM,
            JS_APPLICATION_JAVASCRIPT,
            JSON_APPLICATION_JSON,
            KARBON_APPLICATION_VNDKDEKARBON,
            KFO_APPLICATION_VNDKDEKFORMULA,
            KIA_APPLICATION_VNDKIDSPIRATION,
            KML_APPLICATION_VNDGOOGLE_EARTHKML_XML,
            KMZ_APPLICATION_VNDGOOGLE_EARTHKMZ,
            KNE_APPLICATION_VNDKINAR,
            KON_APPLICATION_VNDKDEKONTOUR,
            KPR_APPLICATION_VNDKDEKPRESENTER,
            KSP_APPLICATION_VNDKDEKSPREAD,
            KTX_IMAGE_KTX,
            KTZ_APPLICATION_VNDKAHOOTZ,
            KWD_APPLICATION_VNDKDEKWORD,
            LASXML_APPLICATION_VNDLASLAS_XML,
            LATEX_APPLICATION_X_LATEX,
            LBD_APPLICATION_VNDLLAMAGRAPHICSLIFE_BALANCEDESKTOP,
            LBE_APPLICATION_VNDLLAMAGRAPHICSLIFE_BALANCEEXCHANGE_XML,
            LES_APPLICATION_VNDHHELESSON_PLAYER,
            LINK66_APPLICATION_VNDROUTE66LINK66_XML,
            LRM_APPLICATION_VNDMS_LRM,
            LTF_APPLICATION_VNDFROGANSLTF,
            LVP_AUDIO_VNDLUCENTVOICE,
            LWP_APPLICATION_VNDLOTUS_WORDPRO,
            M21_APPLICATION_MP21,
            M3U_AUDIO_X_MPEGURL,
            M3U8_APPLICATION_VNDAPPLEMPEGURL,
            M4V_VIDEO_X_M4V,
            MA_APPLICATION_MATHEMATICA,
            MADS_APPLICATION_MADS_XML,
            MAG_APPLICATION_VNDECOWINCHART,
            MATHML_APPLICATION_MATHML_XML,
            MBK_APPLICATION_VNDMOBIUSMBK,
            MBOX_APPLICATION_MBOX,
            MC1_APPLICATION_VNDMEDCALCDATA,
            MCD_APPLICATION_VNDMCD,
            MCURL_TEXT_VNDCURLMCURL,
            MDB_APPLICATION_X_MSACCESS,
            MDI_IMAGE_VNDMS_MODI,
            META4_APPLICATION_METALINK4_XML,
            METS_APPLICATION_METS_XML,
            MFM_APPLICATION_VNDMFMP,
            MGP_APPLICATION_VNDOSGEOMAPGUIDEPACKAGE,
            MGZ_APPLICATION_VNDPROTEUSMAGAZINE,
            MID_AUDIO_MIDI,
            MIF_APPLICATION_VNDMIF,
            MJ2_VIDEO_MJ2,
            MLP_APPLICATION_VNDDOLBYMLP,
            MMD_APPLICATION_VNDCHIPNUTSKARAOKE_MMD,
            MMF_APPLICATION_VNDSMAF,
            MMR_IMAGE_VNDFUJIXEROXEDMICS_MMR,
            MNY_APPLICATION_X_MSMONEY,
            MODS_APPLICATION_MODS_XML,
            MOVIE_VIDEO_X_SGI_MOVIE,
            MP4_APPLICATION_MP4,
            MP4_VIDEO_MP4,
            MP4A_AUDIO_MP4,
            MPC_APPLICATION_VNDMOPHUNCERTIFICATE,
            MPEG_VIDEO_MPEG,
            MPGA_AUDIO_MPEG,
            MPKG_APPLICATION_VNDAPPLEINSTALLER_XML,
            MPM_APPLICATION_VNDBLUEICEMULTIPASS,
            MPN_APPLICATION_VNDMOPHUNAPPLICATION,
            MPP_APPLICATION_VNDMS_PROJECT,
            MPY_APPLICATION_VNDIBMMINIPAY,
            MQY_APPLICATION_VNDMOBIUSMQY,
            MRC_APPLICATION_MARC,
            MRCX_APPLICATION_MARCXML_XML,
            MSCML_APPLICATION_MEDIASERVERCONTROL_XML,
            MSEQ_APPLICATION_VNDMSEQ,
            MSF_APPLICATION_VNDEPSONMSF,
            MSH_MODEL_MESH,
            MSL_APPLICATION_VNDMOBIUSMSL,
            MSTY_APPLICATION_VNDMUVEESTYLE,
            MTS_MODEL_VNDMTS,
            MUS_APPLICATION_VNDMUSICIAN,
            MUSICXML_APPLICATION_VNDRECORDAREMUSICXML_XML,
            MVB_APPLICATION_X_MSMEDIAVIEW,
            MWF_APPLICATION_VNDMFER,
            MXF_APPLICATION_MXF,
            MXL_APPLICATION_VNDRECORDAREMUSICXML,
            MXML_APPLICATION_XV_XML,
            MXS_APPLICATION_VNDTRISCAPEMXS,
            MXU_VIDEO_VNDMPEGURL,
            N_A_APPLICATION_ANDREW_INSET,
            N_GAGE_APPLICATION_VNDNOKIAN_GAGESYMBIANINSTALL,
            N3_TEXT_N3,
            NBP_APPLICATION_VNDWOLFRAMPLAYER,
            NC_APPLICATION_X_NETCDF,
            NCX_APPLICATION_X_DTBNCX_XML,
            NGDAT_APPLICATION_VNDNOKIAN_GAGEDATA,
            NLU_APPLICATION_VNDNEUROLANGUAGENLU,
            NML_APPLICATION_VNDENLIVEN,
            NND_APPLICATION_VNDNOBLENET_DIRECTORY,
            NNS_APPLICATION_VNDNOBLENET_SEALER,
            NNW_APPLICATION_VNDNOBLENET_WEB,
            NPX_IMAGE_VNDNET_FPX,
            NSF_APPLICATION_VNDLOTUS_NOTES,
            OA2_APPLICATION_VNDFUJITSUOASYS2,
            OA3_APPLICATION_VNDFUJITSUOASYS3,
            OAS_APPLICATION_VNDFUJITSUOASYS,
            OBD_APPLICATION_X_MSBINDER,
            ODA_APPLICATION_ODA,
            ODB_APPLICATION_VNDOASISOPENDOCUMENTDATABASE,
            ODC_APPLICATION_VNDOASISOPENDOCUMENTCHART,
            ODF_APPLICATION_VNDOASISOPENDOCUMENTFORMULA,
            ODFT_APPLICATION_VNDOASISOPENDOCUMENTFORMULA_TEMPLATE,
            ODG_APPLICATION_VNDOASISOPENDOCUMENTGRAPHICS,
            ODI_APPLICATION_VNDOASISOPENDOCUMENTIMAGE,
            ODM_APPLICATION_VNDOASISOPENDOCUMENTTEXT_MASTER,
            ODP_APPLICATION_VNDOASISOPENDOCUMENTPRESENTATION,
            ODS_APPLICATION_VNDOASISOPENDOCUMENTSPREADSHEET,
            ODT_APPLICATION_VNDOASISOPENDOCUMENTTEXT,
            OGA_AUDIO_OGG,
            OGV_VIDEO_OGG,
            OGX_APPLICATION_OGG,
            ONETOC_APPLICATION_ONENOTE,
            OPF_APPLICATION_OEBPS_PACKAGE_XML,
            ORG_APPLICATION_VNDLOTUS_ORGANIZER,
            OSF_APPLICATION_VNDYAMAHAOPENSCOREFORMAT,
            OSFPVG_APPLICATION_VNDYAMAHAOPENSCOREFORMATOSFPVG_XML,
            OTC_APPLICATION_VNDOASISOPENDOCUMENTCHART_TEMPLATE,
            OTF_APPLICATION_X_FONT_OTF,
            OTG_APPLICATION_VNDOASISOPENDOCUMENTGRAPHICS_TEMPLATE,
            OTH_APPLICATION_VNDOASISOPENDOCUMENTTEXT_WEB,
            OTI_APPLICATION_VNDOASISOPENDOCUMENTIMAGE_TEMPLATE,
            OTP_APPLICATION_VNDOASISOPENDOCUMENTPRESENTATION_TEMPLATE,
            OTS_APPLICATION_VNDOASISOPENDOCUMENTSPREADSHEET_TEMPLATE,
            OTT_APPLICATION_VNDOASISOPENDOCUMENTTEXT_TEMPLATE,
            OXT_APPLICATION_VNDOPENOFFICEORGEXTENSION,
            P_TEXT_X_PASCAL,
            P10_APPLICATION_PKCS10,
            P12_APPLICATION_X_PKCS12,
            P7B_APPLICATION_X_PKCS7_CERTIFICATES,
            P7M_APPLICATION_PKCS7_MIME,
            P7R_APPLICATION_X_PKCS7_CERTREQRESP,
            P7S_APPLICATION_PKCS7_SIGNATURE,
            P8_APPLICATION_PKCS8,
            PAR_TEXT_PLAIN_BAS,
            PAW_APPLICATION_VNDPAWAAFILE,
            PBD_APPLICATION_VNDPOWERBUILDER6,
            PBM_IMAGE_X_PORTABLE_BITMAP,
            PCF_APPLICATION_X_FONT_PCF,
            PCL_APPLICATION_VNDHP_PCL,
            PCLXL_APPLICATION_VNDHP_PCLXL,
            PCURL_APPLICATION_VNDCURLPCURL,
            PCX_IMAGE_X_PCX,
            PDB_APPLICATION_VNDPALM,
            PDF_APPLICATION_PDF,
            PFA_APPLICATION_X_FONT_TYPE1,
            PFR_APPLICATION_FONT_TDPFR,
            PGM_IMAGE_X_PORTABLE_GRAYMAP,
            PGN_APPLICATION_X_CHESS_PGN,
            PGP_APPLICATION_PGP_SIGNATURE,
            PIC_IMAGE_X_PICT,
            PKI_APPLICATION_PKIXCMP,
            PKIPATH_APPLICATION_PKIX_PKIPATH,
            PLB_APPLICATION_VND3GPPPIC_BW_LARGE,
            PLC_APPLICATION_VNDMOBIUSPLC,
            PLF_APPLICATION_VNDPOCKETLEARN,
            PLS_APPLICATION_PLS_XML,
            PML_APPLICATION_VNDCTC_POSML,
            PNG_IMAGE_PNG,
            PNM_IMAGE_X_PORTABLE_ANYMAP,
            PORTPKG_APPLICATION_VNDMACPORTSPORTPKG,
            POTM_APPLICATION_VNDMS_POWERPOINTTEMPLATEMACROENABLED12,
            POTX_APPLICATION_VNDOPENXMLFORMATS_OFFICEDOCUMENTPRESENTATIONMLTEMPLATE,
            PPAM_APPLICATION_VNDMS_POWERPOINTADDINMACROENABLED12,
            PPD_APPLICATION_VNDCUPS_PPD,
            PPM_IMAGE_X_PORTABLE_PIXMAP,
            PPSM_APPLICATION_VNDMS_POWERPOINTSLIDESHOWMACROENABLED12,
            PPSX_APPLICATION_VNDOPENXMLFORMATS_OFFICEDOCUMENTPRESENTATIONMLSLIDESHOW,
            PPT_APPLICATION_VNDMS_POWERPOINT,
            PPTM_APPLICATION_VNDMS_POWERPOINTPRESENTATIONMACROENABLED12,
            PPTX_APPLICATION_VNDOPENXMLFORMATS_OFFICEDOCUMENTPRESENTATIONMLPRESENTATION,
            PRC_APPLICATION_X_MOBIPOCKET_EBOOK,
            PRE_APPLICATION_VNDLOTUS_FREELANCE,
            PRF_APPLICATION_PICS_RULES,
            PSB_APPLICATION_VND3GPPPIC_BW_SMALL,
            PSD_IMAGE_VNDADOBEPHOTOSHOP,
            PSF_APPLICATION_X_FONT_LINUX_PSF,
            PSKCXML_APPLICATION_PSKC_XML,
            PTID_APPLICATION_VNDPVIPTID1,
            PUB_APPLICATION_X_MSPUBLISHER,
            PVB_APPLICATION_VND3GPPPIC_BW_VAR,
            PWN_APPLICATION_VND3MPOST_IT_NOTES,
            PYA_AUDIO_VNDMS_PLAYREADYMEDIAPYA,
            PYV_VIDEO_VNDMS_PLAYREADYMEDIAPYV,
            QAM_APPLICATION_VNDEPSONQUICKANIME,
            QBO_APPLICATION_VNDINTUQBO,
            QFX_APPLICATION_VNDINTUQFX,
            QPS_APPLICATION_VNDPUBLISHARE_DELTA_TREE,
            QT_VIDEO_QUICKTIME,
            QXD_APPLICATION_VNDQUARKQUARKXPRESS,
            RAM_AUDIO_X_PN_REALAUDIO,
            RAR_APPLICATION_X_RAR_COMPRESSED,
            RAS_IMAGE_X_CMU_RASTER,
            RCPROFILE_APPLICATION_VNDIPUNPLUGGEDRCPROFILE,
            RDF_APPLICATION_RDF_XML,
            RDZ_APPLICATION_VNDDATA_VISIONRDZ,
            REP_APPLICATION_VNDBUSINESSOBJECTS,
            RES_APPLICATION_X_DTBRESOURCE_XML,
            RGB_IMAGE_X_RGB,
            RIF_APPLICATION_REGINFO_XML,
            RIP_AUDIO_VNDRIP,
            RL_APPLICATION_RESOURCE_LISTS_XML,
            RLC_IMAGE_VNDFUJIXEROXEDMICS_RLC,
            RLD_APPLICATION_RESOURCE_LISTS_DIFF_XML,
            RM_APPLICATION_VNDRN_REALMEDIA,
            RMP_AUDIO_X_PN_REALAUDIO_PLUGIN,
            RMS_APPLICATION_VNDJCPJAVAMEMIDLET_RMS,
            RNC_APPLICATION_RELAX_NG_COMPACT_SYNTAX,
            RP9_APPLICATION_VNDCLOANTORP9,
            RPSS_APPLICATION_VNDNOKIARADIO_PRESETS,
            RPST_APPLICATION_VNDNOKIARADIO_PRESET,
            RQ_APPLICATION_SPARQL_QUERY,
            RS_APPLICATION_RLS_SERVICES_XML,
            RSD_APPLICATION_RSD_XML,
            RSS_XML_APPLICATION_RSS_XML,
            RTF_APPLICATION_RTF,
            RTX_TEXT_RICHTEXT,
            S_TEXT_X_ASM,
            SAF_APPLICATION_VNDYAMAHASMAF_AUDIO,
            SBML_APPLICATION_SBML_XML,
            SC_APPLICATION_VNDIBMSECURE_CONTAINER,
            SCD_APPLICATION_X_MSSCHEDULE,
            SCM_APPLICATION_VNDLOTUS_SCREENCAM,
            SCQ_APPLICATION_SCVP_CV_REQUEST,
            SCS_APPLICATION_SCVP_CV_RESPONSE,
            SCURL_TEXT_VNDCURLSCURL,
            SDA_APPLICATION_VNDSTARDIVISIONDRAW,
            SDC_APPLICATION_VNDSTARDIVISIONCALC,
            SDD_APPLICATION_VNDSTARDIVISIONIMPRESS,
            SDKM_APPLICATION_VNDSOLENTSDKM_XML,
            SDP_APPLICATION_SDP,
            SDW_APPLICATION_VNDSTARDIVISIONWRITER,
            SEE_APPLICATION_VNDSEEMAIL,
            SEED_APPLICATION_VNDFDSNSEED,
            SEMA_APPLICATION_VNDSEMA,
            SEMD_APPLICATION_VNDSEMD,
            SEMF_APPLICATION_VNDSEMF,
            SER_APPLICATION_JAVA_SERIALIZED_OBJECT,
            SETPAY_APPLICATION_SET_PAYMENT_INITIATION,
            SETREG_APPLICATION_SET_REGISTRATION_INITIATION,
            SFD_HDSTX_APPLICATION_VNDHYDROSTATIXSOF_DATA,
            SFS_APPLICATION_VNDSPOTFIRESFS,
            SGL_APPLICATION_VNDSTARDIVISIONWRITER_GLOBAL,
            SGML_TEXT_SGML,
            SH_APPLICATION_X_SH,
            SHAR_APPLICATION_X_SHAR,
            SHF_APPLICATION_SHF_XML,
            SIS_APPLICATION_VNDSYMBIANINSTALL,
            SIT_APPLICATION_X_STUFFIT,
            SITX_APPLICATION_X_STUFFITX,
            SKP_APPLICATION_VNDKOAN,
            SLDM_APPLICATION_VNDMS_POWERPOINTSLIDEMACROENABLED12,
            SLDX_APPLICATION_VNDOPENXMLFORMATS_OFFICEDOCUMENTPRESENTATIONMLSLIDE,
            SLT_APPLICATION_VNDEPSONSALT,
            SM_APPLICATION_VNDSTEPMANIASTEPCHART,
            SMF_APPLICATION_VNDSTARDIVISIONMATH,
            SMI_APPLICATION_SMIL_XML,
            SNF_APPLICATION_X_FONT_SNF,
            SPF_APPLICATION_VNDYAMAHASMAF_PHRASE,
            SPL_APPLICATION_X_FUTURESPLASH,
            SPOT_TEXT_VNDIN3DSPOT,
            SPP_APPLICATION_SCVP_VP_RESPONSE,
            SPQ_APPLICATION_SCVP_VP_REQUEST,
            SRC_APPLICATION_X_WAIS_SOURCE,
            SRU_APPLICATION_SRU_XML,
            SRX_APPLICATION_SPARQL_RESULTS_XML,
            SSE_APPLICATION_VNDKODAK_DESCRIPTOR,
            SSF_APPLICATION_VNDEPSONSSF,
            SSML_APPLICATION_SSML_XML,
            ST_APPLICATION_VNDSAILINGTRACKERTRACK,
            STC_APPLICATION_VNDSUNXMLCALCTEMPLATE,
            STD_APPLICATION_VNDSUNXMLDRAWTEMPLATE,
            STF_APPLICATION_VNDWTSTF,
            STI_APPLICATION_VNDSUNXMLIMPRESSTEMPLATE,
            STK_APPLICATION_HYPERSTUDIO,
            STL_APPLICATION_VNDMS_PKISTL,
            STR_APPLICATION_VNDPGFORMAT,
            STW_APPLICATION_VNDSUNXMLWRITERTEMPLATE,
            SUB_IMAGE_VNDDVBSUBTITLE,
            SUS_APPLICATION_VNDSUS_CALENDAR,
            SV4CPIO_APPLICATION_X_SV4CPIO,
            SV4CRC_APPLICATION_X_SV4CRC,
            SVC_APPLICATION_VNDDVBSERVICE,
            SVD_APPLICATION_VNDSVD,
            SVG_IMAGE_SVG_XML,
            SWF_APPLICATION_X_SHOCKWAVE_FLASH,
            SWI_APPLICATION_VNDARISTANETWORKSSWI,
            SXC_APPLICATION_VNDSUNXMLCALC,
            SXD_APPLICATION_VNDSUNXMLDRAW,
            SXG_APPLICATION_VNDSUNXMLWRITERGLOBAL,
            SXI_APPLICATION_VNDSUNXMLIMPRESS,
            SXM_APPLICATION_VNDSUNXMLMATH,
            SXW_APPLICATION_VNDSUNXMLWRITER,
            T_TEXT_TROFF,
            TAO_APPLICATION_VNDTAOINTENT_MODULE_ARCHIVE,
            TAR_APPLICATION_X_TAR,
            TCAP_APPLICATION_VND3GPP2TCAP,
            TCL_APPLICATION_X_TCL,
            TEACHER_APPLICATION_VNDSMARTTEACHER,
            TEI_APPLICATION_TEI_XML,
            TEX_APPLICATION_X_TEX,
            TEXINFO_APPLICATION_X_TEXINFO,
            TFI_APPLICATION_THRAUD_XML,
            TFM_APPLICATION_X_TEX_TFM,
            THMX_APPLICATION_VNDMS_OFFICETHEME,
            TIFF_IMAGE_TIFF,
            TMO_APPLICATION_VNDTMOBILE_LIVETV,
            TORRENT_APPLICATION_X_BITTORRENT,
            TPL_APPLICATION_VNDGROOVE_TOOL_TEMPLATE,
            TPT_APPLICATION_VNDTRIDTPT,
            TRA_APPLICATION_VNDTRUEAPP,
            TRM_APPLICATION_X_MSTERMINAL,
            TSD_APPLICATION_TIMESTAMPED_DATA,
            TSV_TEXT_TAB_SEPARATED_VALUES,
            TTF_APPLICATION_X_FONT_TTF,
            TTL_TEXT_TURTLE,
            TWD_APPLICATION_VNDSIMTECH_MINDMAPPER,
            TXD_APPLICATION_VNDGENOMATIXTUXEDO,
            TXF_APPLICATION_VNDMOBIUSTXF,
            TXT_TEXT_PLAIN,
            UFD_APPLICATION_VNDUFDL,
            UMJ_APPLICATION_VNDUMAJIN,
            UNITYWEB_APPLICATION_VNDUNITY,
            UOML_APPLICATION_VNDUOML_XML,
            URI_TEXT_URI_LIST,
            USTAR_APPLICATION_X_USTAR,
            UTZ_APPLICATION_VNDUIQTHEME,
            UU_TEXT_X_UUENCODE,
            UVA_AUDIO_VNDDECEAUDIO,
            UVH_VIDEO_VNDDECEHD,
            UVI_IMAGE_VNDDECEGRAPHIC,
            UVM_VIDEO_VNDDECEMOBILE,
            UVP_VIDEO_VNDDECEPD,
            UVS_VIDEO_VNDDECESD,
            UVU_VIDEO_VNDUVVUMP4,
            UVV_VIDEO_VNDDECEVIDEO,
            VCD_APPLICATION_X_CDLINK,
            VCF_TEXT_X_VCARD,
            VCG_APPLICATION_VNDGROOVE_VCARD,
            VCS_TEXT_X_VCALENDAR,
            VCX_APPLICATION_VNDVCX,
            VIS_APPLICATION_VNDVISIONARY,
            VIV_VIDEO_VNDVIVO,
            VSD_APPLICATION_VNDVISIO,
            VSF_APPLICATION_VNDVSF,
            VTU_MODEL_VNDVTU,
            VXML_APPLICATION_VOICEXML_XML,
            WAD_APPLICATION_X_DOOM,
            WAV_AUDIO_X_WAV,
            WAX_AUDIO_X_MS_WAX,
            WBMP_IMAGE_VNDWAPWBMP,
            WBS_APPLICATION_VNDCRITICALTOOLSWBS_XML,
            WBXML_APPLICATION_VNDWAPWBXML,
            WEBA_AUDIO_WEBM,
            WEBM_VIDEO_WEBM,
            WEBP_IMAGE_WEBP,
            WG_APPLICATION_VNDPMIWIDGET,
            WGT_APPLICATION_WIDGET,
            WM_VIDEO_X_MS_WM,
            WMA_AUDIO_X_MS_WMA,
            WMD_APPLICATION_X_MS_WMD,
            WMF_APPLICATION_X_MSMETAFILE,
            WML_TEXT_VNDWAPWML,
            WMLC_APPLICATION_VNDWAPWMLC,
            WMLS_TEXT_VNDWAPWMLSCRIPT,
            WMLSC_APPLICATION_VNDWAPWMLSCRIPTC,
            WMV_VIDEO_X_MS_WMV,
            WMX_VIDEO_X_MS_WMX,
            WMZ_APPLICATION_X_MS_WMZ,
            WOFF_APPLICATION_X_FONT_WOFF,
            WPD_APPLICATION_VNDWORDPERFECT,
            WPL_APPLICATION_VNDMS_WPL,
            WPS_APPLICATION_VNDMS_WORKS,
            WQD_APPLICATION_VNDWQD,
            WRI_APPLICATION_X_MSWRITE,
            WRL_MODEL_VRML,
            WSDL_APPLICATION_WSDL_XML,
            WSPOLICY_APPLICATION_WSPOLICY_XML,
            WTB_APPLICATION_VNDWEBTURBO,
            WVX_VIDEO_X_MS_WVX,
            X3D_APPLICATION_VNDHZN_3D_CROSSWORD,
            XAP_APPLICATION_X_SILVERLIGHT_APP,
            XAR_APPLICATION_VNDXARA,
            XBAP_APPLICATION_X_MS_XBAP,
            XBD_APPLICATION_VNDFUJIXEROXDOCUWORKSBINDER,
            XBM_IMAGE_X_XBITMAP,
            XDF_APPLICATION_XCAP_DIFF_XML,
            XDM_APPLICATION_VNDSYNCMLDM_XML,
            XDP_APPLICATION_VNDADOBEXDP_XML,
            XDSSC_APPLICATION_DSSC_XML,
            XDW_APPLICATION_VNDFUJIXEROXDOCUWORKS,
            XENC_APPLICATION_XENC_XML,
            XER_APPLICATION_PATCH_OPS_ERROR_XML,
            XFDF_APPLICATION_VNDADOBEXFDF,
            XFDL_APPLICATION_VNDXFDL,
            XHTML_APPLICATION_XHTML_XML,
            XIF_IMAGE_VNDXIFF,
            XLAM_APPLICATION_VNDMS_EXCELADDINMACROENABLED12,
            XLS_APPLICATION_VNDMS_EXCEL,
            XLSB_APPLICATION_VNDMS_EXCELSHEETBINARYMACROENABLED12,
            XLSM_APPLICATION_VNDMS_EXCELSHEETMACROENABLED12,
            XLSX_APPLICATION_VNDOPENXMLFORMATS_OFFICEDOCUMENTSPREADSHEETMLSHEET,
            XLTM_APPLICATION_VNDMS_EXCELTEMPLATEMACROENABLED12,
            XLTX_APPLICATION_VNDOPENXMLFORMATS_OFFICEDOCUMENTSPREADSHEETMLTEMPLATE,
            XML_APPLICATION_XML,
            XO_APPLICATION_VNDOLPC_SUGAR,
            XOP_APPLICATION_XOP_XML,
            XPI_APPLICATION_X_XPINSTALL,
            XPM_IMAGE_X_XPIXMAP,
            XPR_APPLICATION_VNDIS_XPR,
            XPS_APPLICATION_VNDMS_XPSDOCUMENT,
            XPW_APPLICATION_VNDINTERCONFORMNET,
            XSLT_APPLICATION_XSLT_XML,
            XSM_APPLICATION_VNDSYNCML_XML,
            XSPF_APPLICATION_XSPF_XML,
            XUL_APPLICATION_VNDMOZILLAXUL_XML,
            XWD_IMAGE_X_XWINDOWDUMP,
            XYZ_CHEMICAL_X_XYZ,
            YAML_TEXT_YAML,
            YANG_APPLICATION_YANG,
            YIN_APPLICATION_YIN_XML,
            ZAZ_APPLICATION_VNDZZAZZDECK_XML,
            ZIP_APPLICATION_ZIP,
            ZIR_APPLICATION_VNDZUL,
            ZMM_APPLICATION_VNDHANDHELD_ENTERTAINMENT_XML,
        }

        public enum EnmEncoding
        {
            _8859,
            ANSI,
            ASCII,
            NUMB,
            UTF_16,
            UTF_8,
        }

        #endregion Constantes

        #region Atributos

        private byte[] _arrBteResposta;
        private DateTime _dttUltimaModificacao = DateTime.Now;
        private EnmContentType _enmContentType = EnmContentType.TXT_TEXT_PLAIN;
        private EnmEncoding _enmEncoding = EnmEncoding.UTF_8;
        private int _intStatus;
        private List<Cookie> _lstObjCookie;
        private MemoryStream _mmsConteudo;
        private Solicitacao _objSolicitacao;

        /// <summary>
        /// Data em que o conteúdo desta mensagem foi modificada pela última vez.
        /// <para>
        /// A indicação desta propriedade é importante pois ela será comparada com a data da versão
        /// deste conteúdo no navegador, sendo que se este recurso não tiver sido alterado ele não
        /// será enviado ao cliente, fazendo com que o mesmo utilize a versão que ele tem em cache,
        /// agilizando assim o processo e não consumindo recursos de rede e processamento.
        /// </para>
        /// </summary>
        public DateTime dttUltimaModificacao
        {
            get
            {
                return _dttUltimaModificacao;
            }

            set
            {
                _dttUltimaModificacao = value;
            }
        }

        public EnmContentType enmContentType
        {
            get
            {
                return _enmContentType;
            }

            set
            {
                _enmContentType = value;
            }
        }

        public EnmEncoding enmEncoding
        {
            get
            {
                return _enmEncoding;
            }

            set
            {
                _enmEncoding = value;
            }
        }

        internal byte[] arrBteResposta
        {
            get
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    if (_arrBteResposta != null)
                    {
                        return _arrBteResposta;
                    }

                    _arrBteResposta = this.getArrBteResposta();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion Ações

                return _arrBteResposta;
            }
        }

        internal int intStatus
        {
            get
            {
                return _intStatus;
            }

            set
            {
                _intStatus = value;
            }
        }

        private List<Cookie> lstObjCookie
        {
            get
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    if (_lstObjCookie != null)
                    {
                        return _lstObjCookie;
                    }

                    _lstObjCookie = new List<Cookie>();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion Ações

                return _lstObjCookie;
            }
        }

        private MemoryStream mmsConteudo
        {
            get
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    if (_mmsConteudo != null)
                    {
                        return _mmsConteudo;
                    }

                    _mmsConteudo = new MemoryStream();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion Ações

                return _mmsConteudo;
            }
        }

        private Solicitacao objSolicitacao
        {
            get
            {
                return _objSolicitacao;
            }

            set
            {
                _objSolicitacao = value;
            }
        }

        #endregion Atributos

        #region Construtores

        public Resposta(Solicitacao objSolicitacao)
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                this.objSolicitacao = objSolicitacao;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }

            #endregion Ações
        }

        #endregion Construtores

        #region Métodos

        /// <summary>
        /// Adiciona um cookie para ser armazenado no browser do cliente.
        /// </summary>
        public void addCookie(Cookie objCookie)
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                if (objCookie == null)
                {
                    return;
                }

                if (string.IsNullOrEmpty(objCookie.strNome))
                {
                    return;
                }

                if (string.IsNullOrEmpty(objCookie.strValor))
                {
                    return;
                }

                if (objCookie.dttValidade < DateTime.Now)
                {
                    return;
                }

                this.lstObjCookie.Add(objCookie);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }

            #endregion Ações
        }

        /// <summary>
        /// Adiciona código HTML para a resposta que será encaminhada para o cliente quando o
        /// processamento da solicitação for finalizada.
        /// </summary>
        /// <param name="strHtml">Código HTML que deve ser enviada para o cliente.</param>
        public void addHtml(string strHtml)
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                if (string.IsNullOrEmpty(strHtml))
                {
                    return;
                }

                this.enmContentType = EnmContentType.HTML_TEXT_HTML;
                this.enmEncoding = EnmEncoding.UTF_8;
                this.mmsConteudo.Write(Encoding.UTF8.GetBytes(strHtml), 0, Encoding.UTF8.GetByteCount(strHtml));
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }

            #endregion Ações
        }

        /// <summary>
        /// Adiciona o conteúdo em html da <see cref="PaginaHtml"/> para a resposta.
        /// </summary>
        /// <param name="pagHtml">Página que se deseja responder para o usuário.</param>
        public void addHtml(PaginaHtml pagHtml)
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                if (pagHtml == null)
                {
                    return;
                }

                this.addHtml(pagHtml.toHtml());
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }

            #endregion Ações
        }

        internal void addArquivo(ArquivoEstatico arq)
        {
            #region Variáveis

            byte[] arrBte;

            #endregion Variáveis

            #region Ações

            try
            {
                if (arq == null)
                {
                    return;
                }

                if (!File.Exists(arq.dirCompleto))
                {
                    return;
                }

                this.dttUltimaModificacao = arq.dttUltimaModificacao;
                this.atualizarEnmContentType(arq);

                if (this.objSolicitacao.dttUltimaModificacao.ToString().Equals(this.dttUltimaModificacao.ToString()))
                {
                    return;
                }

                arrBte = File.ReadAllBytes(arq.dirCompleto);

                this.mmsConteudo.Write(arrBte, 0, arrBte.Length);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }

            #endregion Ações
        }

        private void addCookieSessaoId()
        {
            #region Variáveis

            Cookie objCookieSessaoId;
            string strSessaoId;

            #endregion Variáveis

            #region Ações

            try
            {
                if (this.objSolicitacao == null)
                {
                    return;
                }

                foreach (Cookie objCookie in this.objSolicitacao.lstObjCookie)
                {
                    if (objCookie == null)
                    {
                        continue;
                    }

                    if (string.IsNullOrEmpty(objCookie.strNome))
                    {
                        continue;
                    }

                    if (objCookie.strNome.Equals(Server.STR_COOKIE_SESSAO_ID_NOME))
                    {
                        return;
                    }
                }

                strSessaoId = "_dtt_agora+_solicitacao_id";

                strSessaoId = strSessaoId.Replace("_dtt_agora", DateTime.Now.ToString());
                strSessaoId = strSessaoId.Replace("_solicitacao_id", this.objSolicitacao.intObjetoId.ToString());

                strSessaoId = Utils.getStrMd5(strSessaoId);

                objCookieSessaoId = new Cookie(Server.STR_COOKIE_SESSAO_ID_NOME, strSessaoId);
                objCookieSessaoId.dttValidade = DateTime.Now.AddHours(8);

                this.addCookie(objCookieSessaoId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }

            #endregion Ações
        }

        private void atualizarEnmContentType(ArquivoEstatico arq)
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                if (arq == null)
                {
                    this.enmContentType = EnmContentType.TXT_TEXT_PLAIN;
                    return;
                }

                if (string.IsNullOrEmpty(arq.dirCompleto))
                {
                    this.enmContentType = EnmContentType.TXT_TEXT_PLAIN;
                    return;
                }

                if (string.IsNullOrEmpty(Path.GetExtension(arq.dirCompleto)))
                {
                    this.enmContentType = EnmContentType.TXT_TEXT_PLAIN;
                    return;
                }

                switch (Path.GetExtension(arq.dirCompleto).ToLower())
                {
                    case ".js":
                        this.enmContentType = EnmContentType.JS_APPLICATION_JAVASCRIPT;
                        return;

                    case ".css":
                        this.enmContentType = EnmContentType.CSS_TEXT_CSS;
                        return;

                    case ".htm":
                    case ".html":
                        this.enmContentType = EnmContentType.HTML_TEXT_HTML;
                        return;

                    case ".exe":
                        this.enmContentType = EnmContentType.EXE_APPLICATION_X_MSDOWNLOAD;
                        return;

                    case ".dll":
                        this.enmContentType = EnmContentType.EXE_APPLICATION_X_MSDOWNLOAD;
                        return;

                    case ".pdf":
                        this.enmContentType = EnmContentType.PDF_APPLICATION_PDF;
                        return;

                    case ".png":
                        this.enmContentType = EnmContentType.PNG_IMAGE_PNG;
                        return;

                    case ".bmp":
                        this.enmContentType = EnmContentType.BMP_IMAGE_BMP;
                        return;

                    case ".tif":
                        this.enmContentType = EnmContentType.TIFF_IMAGE_TIFF;
                        return;

                    case ".jpg":
                        this.enmContentType = EnmContentType.JPEG_JPG_IMAGE_JPEG;
                        return;

                    case ".mp4":
                        this.enmContentType = EnmContentType.MP4_VIDEO_MP4;
                        return;

                    default:
                        this.enmContentType = EnmContentType.TXT_TEXT_PLAIN;
                        return;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }

            #endregion Ações
        }

        private byte[] getArrBteResposta()
        {
            #region Variáveis

            MemoryStream mmsResposta;
            string strHeader;

            #endregion Variáveis

            #region Ações

            try
            {
                strHeader = this.getStrHeader();

                mmsResposta = new MemoryStream();

                mmsResposta.Write(Encoding.UTF8.GetBytes(strHeader), 0, Encoding.UTF8.GetByteCount(strHeader));

                if (!200.Equals(this.intStatus))
                {
                    return mmsResposta.ToArray();
                }

                mmsResposta.Write(Encoding.UTF8.GetBytes(Environment.NewLine), 0, Encoding.UTF8.GetByteCount(Environment.NewLine));
                mmsResposta.Write(Encoding.UTF8.GetBytes(Environment.NewLine), 0, Encoding.UTF8.GetByteCount(Environment.NewLine));
                mmsResposta.Write(this.mmsConteudo.ToArray(), 0, (int)this.mmsConteudo.Length);

                return mmsResposta.ToArray();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }

            #endregion Ações
        }

        private string getStrEnmContentType()
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                switch (this.enmContentType)
                {
                    case EnmContentType._123_APPLICATION_VNDLOTUS_1_2_3:
                        return "application/vnd.lotus-1-2-3";

                    case EnmContentType._3DML_TEXT_VNDIN3D3DML:
                        return "text/vnd.in3d.3dml";

                    case EnmContentType._3G2_VIDEO_3GPP2:
                        return "video/3gpp2";

                    case EnmContentType._3GP_VIDEO_3GPP:
                        return "video/3gpp";

                    case EnmContentType._7Z_APPLICATION_X_7Z_COMPRESSED:
                        return "application/x-7z-compressed";

                    case EnmContentType.AAB_APPLICATION_X_AUTHORWARE_BIN:
                        return "application/x-authorware-bin";

                    case EnmContentType.AAC_AUDIO_X_AAC:
                        return "audio/x-aac";

                    case EnmContentType.AAM_APPLICATION_X_AUTHORWARE_MAP:
                        return "application/x-authorware-map";

                    case EnmContentType.AAS_APPLICATION_X_AUTHORWARE_SEG:
                        return "application/x-authorware-seg";

                    case EnmContentType.ABW_APPLICATION_X_ABIWORD:
                        return "application/x-abiword";

                    case EnmContentType.AC_APPLICATION_PKIX_ATTR_CERT:
                        return "application/pkix-attr-cert";

                    case EnmContentType.ACC_APPLICATION_VNDAMERICANDYNAMICSACC:
                        return "application/vnd.americandynamics.acc";

                    case EnmContentType.ACE_APPLICATION_X_ACE_COMPRESSED:
                        return "application/x-ace-compressed";

                    case EnmContentType.ACU_APPLICATION_VNDACUCOBOL:
                        return "application/vnd.acucobol";

                    case EnmContentType.ADP_AUDIO_ADPCM:
                        return "audio/adpcm";

                    case EnmContentType.AEP_APPLICATION_VNDAUDIOGRAPH:
                        return "application/vnd.audiograph";

                    case EnmContentType.AFP_APPLICATION_VNDIBMMODCAP:
                        return "application/vnd.ibm.modcap";

                    case EnmContentType.AHEAD_APPLICATION_VNDAHEADSPACE:
                        return "application/vnd.ahead.space";

                    case EnmContentType.AI_APPLICATION_POSTSCRIPT:
                        return "application/postscript";

                    case EnmContentType.AIF_AUDIO_X_AIFF:
                        return "audio/x-aiff";

                    case EnmContentType.AIR_APPLICATION_VNDADOBEAIR_APPLICATION_INSTALLER_PACKAGE_ZIP:
                        return "application/vnd.adobe.air-application-installer-package+zip";

                    case EnmContentType.AIT_APPLICATION_VNDDVBAIT:
                        return "application/vnd.dvb.ait";

                    case EnmContentType.AMI_APPLICATION_VNDAMIGAAMI:
                        return "application/vnd.amiga.ami";

                    case EnmContentType.APK_APPLICATION_VNDANDROIDPACKAGE_ARCHIVE:
                        return "application/vnd.android.package-archive";

                    case EnmContentType.APPLICATION_APPLICATION_X_MS_APPLICATION:
                        return "application/x-ms-application";

                    case EnmContentType.APR_APPLICATION_VNDLOTUS_APPROACH:
                        return "application/vnd.lotus-approach";

                    case EnmContentType.ASF_VIDEO_X_MS_ASF:
                        return "video/x-ms-asf";

                    case EnmContentType.ASO_APPLICATION_VNDACCPACSIMPLYASO:
                        return "application/vnd.accpac.simply.aso";

                    case EnmContentType.ATC_APPLICATION_VNDACUCORP:
                        return "application/vnd.acucorp";

                    case EnmContentType.ATOM_XML_APPLICATION_ATOM_XML:
                        return "application/atom+xml";

                    case EnmContentType.ATOMCAT_APPLICATION_ATOMCAT_XML:
                        return "application/atomcat+xml";

                    case EnmContentType.ATOMSVC_APPLICATION_ATOMSVC_XML:
                        return "application/atomsvc+xml";

                    case EnmContentType.ATX_APPLICATION_VNDANTIXGAME_COMPONENT:
                        return "application/vnd.antix.game-component";

                    case EnmContentType.AU_AUDIO_BASIC:
                        return "audio/basic";

                    case EnmContentType.AVI_VIDEO_X_MSVIDEO:
                        return "video/x-msvideo";

                    case EnmContentType.AW_APPLICATION_APPLIXWARE:
                        return "application/applixware";

                    case EnmContentType.AZF_APPLICATION_VNDAIRZIPFILESECUREAZF:
                        return "application/vnd.airzip.filesecure.azf";

                    case EnmContentType.AZS_APPLICATION_VNDAIRZIPFILESECUREAZS:
                        return "application/vnd.airzip.filesecure.azs";

                    case EnmContentType.AZW_APPLICATION_VNDAMAZONEBOOK:
                        return "application/vnd.amazon.ebook";

                    case EnmContentType.BCPIO_APPLICATION_X_BCPIO:
                        return "application/x-bcpio";

                    case EnmContentType.BDF_APPLICATION_X_FONT_BDF:
                        return "application/x-font-bdf";

                    case EnmContentType.BDM_APPLICATION_VNDSYNCMLDM_WBXML:
                        return "application/vnd.syncml.dm+wbxml";

                    case EnmContentType.BED_APPLICATION_VNDREALVNCBED:
                        return "application/vnd.realvnc.bed";

                    case EnmContentType.BH2_APPLICATION_VNDFUJITSUOASYSPRS:
                        return "application/vnd.fujitsu.oasysprs";

                    case EnmContentType.BIN_APPLICATION_OCTET_STREAM:
                        return "application/octet-stream";

                    case EnmContentType.BMI_APPLICATION_VNDBMI:
                        return "application/vnd.bmi";

                    case EnmContentType.BMP_IMAGE_BMP:
                        return "image/bmp";

                    case EnmContentType.BOX_APPLICATION_VNDPREVIEWSYSTEMSBOX:
                        return "application/vnd.previewsystems.box";

                    case EnmContentType.BTIF_IMAGE_PRSBTIF:
                        return "image/prs.btif";

                    case EnmContentType.BZ_APPLICATION_X_BZIP:
                        return "application/x-bzip";

                    case EnmContentType.BZ2_APPLICATION_X_BZIP2:
                        return "application/x-bzip2";

                    case EnmContentType.C_TEXT_X_C:
                        return "text/x-c";

                    case EnmContentType.C11AMC_APPLICATION_VNDCLUETRUSTCARTOMOBILE_CONFIG:
                        return "application/vnd.cluetrust.cartomobile-config";

                    case EnmContentType.C11AMZ_APPLICATION_VNDCLUETRUSTCARTOMOBILE_CONFIG_PKG:
                        return "application/vnd.cluetrust.cartomobile-config-pkg";

                    case EnmContentType.C4G_APPLICATION_VNDCLONKC4GROUP:
                        return "application/vnd.clonk.c4group";

                    case EnmContentType.CAB_APPLICATION_VNDMS_CAB_COMPRESSED:
                        return "application/vnd.ms-cab-compressed";

                    case EnmContentType.CAR_APPLICATION_VNDCURLCAR:
                        return "application/vnd.curl.car";

                    case EnmContentType.CAT_APPLICATION_VNDMS_PKISECCAT:
                        return "application/vnd.ms-pki.seccat";

                    case EnmContentType.CCXML_APPLICATION_CCXML_XML:
                        return "application/ccxml+xml,";

                    case EnmContentType.CDBCMSG_APPLICATION_VNDCONTACTCMSG:
                        return "application/vnd.contact.cmsg";

                    case EnmContentType.CDKEY_APPLICATION_VNDMEDIASTATIONCDKEY:
                        return "application/vnd.mediastation.cdkey";

                    case EnmContentType.CDMIA_APPLICATION_CDMI_CAPABILITY:
                        return "application/cdmi-capability";

                    case EnmContentType.CDMIC_APPLICATION_CDMI_CONTAINER:
                        return "application/cdmi-container";

                    case EnmContentType.CDMID_APPLICATION_CDMI_DOMAIN:
                        return "application/cdmi-domain";

                    case EnmContentType.CDMIO_APPLICATION_CDMI_OBJECT:
                        return "application/cdmi-object";

                    case EnmContentType.CDMIQ_APPLICATION_CDMI_QUEUE:
                        return "application/cdmi-queue";

                    case EnmContentType.CDX_CHEMICAL_X_CDX:
                        return "chemical/x-cdx";

                    case EnmContentType.CDXML_APPLICATION_VNDCHEMDRAW_XML:
                        return "application/vnd.chemdraw+xml";

                    case EnmContentType.CDY_APPLICATION_VNDCINDERELLA:
                        return "application/vnd.cinderella";

                    case EnmContentType.CER_APPLICATION_PKIX_CERT:
                        return "application/pkix-cert";

                    case EnmContentType.CGM_IMAGE_CGM:
                        return "image/cgm";

                    case EnmContentType.CHAT_APPLICATION_X_CHAT:
                        return "application/x-chat";

                    case EnmContentType.CHM_APPLICATION_VNDMS_HTMLHELP:
                        return "application/vnd.ms-htmlhelp";

                    case EnmContentType.CHRT_APPLICATION_VNDKDEKCHART:
                        return "application/vnd.kde.kchart";

                    case EnmContentType.CIF_CHEMICAL_X_CIF:
                        return "chemical/x-cif";

                    case EnmContentType.CII_APPLICATION_VNDANSER_WEB_CERTIFICATE_ISSUE_INITIATION:
                        return "application/vnd.anser-web-certificate-issue-initiation";

                    case EnmContentType.CIL_APPLICATION_VNDMS_ARTGALRY:
                        return "application/vnd.ms-artgalry";

                    case EnmContentType.CLA_APPLICATION_VNDCLAYMORE:
                        return "application/vnd.claymore";

                    case EnmContentType.CLASS_APPLICATION_JAVA_VM:
                        return "application/java-vm";

                    case EnmContentType.CLKK_APPLICATION_VNDCRICKCLICKERKEYBOARD:
                        return "application/vnd.crick.clicker.keyboard";

                    case EnmContentType.CLKP_APPLICATION_VNDCRICKCLICKERPALETTE:
                        return "application/vnd.crick.clicker.palette";

                    case EnmContentType.CLKT_APPLICATION_VNDCRICKCLICKERTEMPLATE:
                        return "application/vnd.crick.clicker.template";

                    case EnmContentType.CLKW_APPLICATION_VNDCRICKCLICKERWORDBANK:
                        return "application/vnd.crick.clicker.wordbank";

                    case EnmContentType.CLKX_APPLICATION_VNDCRICKCLICKER:
                        return "application/vnd.crick.clicker";

                    case EnmContentType.CLP_APPLICATION_X_MSCLIP:
                        return "application/x-msclip";

                    case EnmContentType.CMC_APPLICATION_VNDCOSMOCALLER:
                        return "application/vnd.cosmocaller";

                    case EnmContentType.CMDF_CHEMICAL_X_CMDF:
                        return "chemical/x-cmdf";

                    case EnmContentType.CML_CHEMICAL_X_CML:
                        return "chemical/x-cml";

                    case EnmContentType.CMP_APPLICATION_VNDYELLOWRIVER_CUSTOM_MENU:
                        return "application/vnd.yellowriver-custom-menu";

                    case EnmContentType.CMX_IMAGE_X_CMX:
                        return "image/x-cmx";

                    case EnmContentType.COD_APPLICATION_VNDRIMCOD:
                        return "application/vnd.rim.cod";

                    case EnmContentType.CPIO_APPLICATION_X_CPIO:
                        return "application/x-cpio";

                    case EnmContentType.CPT_APPLICATION_MAC_COMPACTPRO:
                        return "application/mac-compactpro";

                    case EnmContentType.CRD_APPLICATION_X_MSCARDFILE:
                        return "application/x-mscardfile";

                    case EnmContentType.CRL_APPLICATION_PKIX_CRL:
                        return "application/pkix-crl";

                    case EnmContentType.CRYPTONOTE_APPLICATION_VNDRIGCRYPTONOTE:
                        return "application/vnd.rig.cryptonote";

                    case EnmContentType.CSH_APPLICATION_X_CSH:
                        return "application/x-csh";

                    case EnmContentType.CSML_CHEMICAL_X_CSML:
                        return "chemical/x-csml";

                    case EnmContentType.CSP_APPLICATION_VNDCOMMONSPACE:
                        return "application/vnd.commonspace";

                    case EnmContentType.CSS_TEXT_CSS:
                        return "text/css";

                    case EnmContentType.CSV_TEXT_CSV:
                        return "text/csv";

                    case EnmContentType.CU_APPLICATION_CU_SEEME:
                        return "application/cu-seeme";

                    case EnmContentType.CURL_TEXT_VNDCURL:
                        return "text/vnd.curl";

                    case EnmContentType.CWW_APPLICATION_PRSCWW:
                        return "application/prs.cww";

                    case EnmContentType.DAE_MODEL_VNDCOLLADA_XML:
                        return "model/vnd.collada+xml";

                    case EnmContentType.DAF_APPLICATION_VNDMOBIUSDAF:
                        return "application/vnd.mobius.daf";

                    case EnmContentType.DAVMOUNT_APPLICATION_DAVMOUNT_XML:
                        return "application/davmount+xml";

                    case EnmContentType.DCURL_TEXT_VNDCURLDCURL:
                        return "text/vnd.curl.dcurl";

                    case EnmContentType.DD2_APPLICATION_VNDOMADD2_XML:
                        return "application/vnd.oma.dd2+xml";

                    case EnmContentType.DDD_APPLICATION_VNDFUJIXEROXDDD:
                        return "application/vnd.fujixerox.ddd";

                    case EnmContentType.DEB_APPLICATION_X_DEBIAN_PACKAGE:
                        return "application/x-debian-package";

                    case EnmContentType.DER_APPLICATION_X_X509_CA_CERT:
                        return "application/x-x509-ca-cert";

                    case EnmContentType.DFAC_APPLICATION_VNDDREAMFACTORY:
                        return "application/vnd.dreamfactory";

                    case EnmContentType.DIR_APPLICATION_X_DIRECTOR:
                        return "application/x-director";

                    case EnmContentType.DIS_APPLICATION_VNDMOBIUSDIS:
                        return "application/vnd.mobius.dis";

                    case EnmContentType.DJVU_IMAGE_VNDDJVU:
                        return "image/vnd.djvu";

                    case EnmContentType.DNA_APPLICATION_VNDDNA:
                        return "application/vnd.dna";

                    case EnmContentType.DOC_APPLICATION_MSWORD:
                        return "application/msword";

                    case EnmContentType.DOCM_APPLICATION_VNDMS_WORDDOCUMENTMACROENABLED12:
                        return "application/vnd.ms-word.document.macroenabled.12";

                    case EnmContentType.DOCX_APPLICATION_VNDOPENXMLFORMATS_OFFICEDOCUMENTWORDPROCESSINGMLDOCUMENT:
                        return "application/vnd.openxmlformats-officedocument.wordprocessingml.document";

                    case EnmContentType.DOTM_APPLICATION_VNDMS_WORDTEMPLATEMACROENABLED12:
                        return "application/vnd.ms-word.template.macroenabled.12";

                    case EnmContentType.DOTX_APPLICATION_VNDOPENXMLFORMATS_OFFICEDOCUMENTWORDPROCESSINGMLTEMPLATE:
                        return "application/vnd.openxmlformats-officedocument.wordprocessingml.template";

                    case EnmContentType.DP_APPLICATION_VNDOSGIDP:
                        return "application/vnd.osgi.dp";

                    case EnmContentType.DPG_APPLICATION_VNDDPGRAPH:
                        return "application/vnd.dpgraph";

                    case EnmContentType.DRA_AUDIO_VNDDRA:
                        return "audio/vnd.dra";

                    case EnmContentType.DSC_TEXT_PRSLINESTAG:
                        return "text/prs.lines.tag";

                    case EnmContentType.DSSC_APPLICATION_DSSC_DER:
                        return "application/dssc+der";

                    case EnmContentType.DTB_APPLICATION_X_DTBOOK_XML:
                        return "application/x-dtbook+xml";

                    case EnmContentType.DTD_APPLICATION_XML_DTD:
                        return "application/xml-dtd";

                    case EnmContentType.DTS_AUDIO_VNDDTS:
                        return "audio/vnd.dts";

                    case EnmContentType.DTSHD_AUDIO_VNDDTSHD:
                        return "audio/vnd.dts.hd";

                    case EnmContentType.DVI_APPLICATION_X_DVI:
                        return "application/x-dvi";

                    case EnmContentType.DWF_MODEL_VNDDWF:
                        return "model/vnd.dwf";

                    case EnmContentType.DWG_IMAGE_VNDDWG:
                        return "image/vnd.dwg";

                    case EnmContentType.DXF_IMAGE_VNDDXF:
                        return "image/vnd.dxf";

                    case EnmContentType.DXP_APPLICATION_VNDSPOTFIREDXP:
                        return "application/vnd.spotfire.dxp";

                    case EnmContentType.ECELP4800_AUDIO_VNDNUERAECELP4800:
                        return "audio/vnd.nuera.ecelp4800";

                    case EnmContentType.ECELP7470_AUDIO_VNDNUERAECELP7470:
                        return "audio/vnd.nuera.ecelp7470";

                    case EnmContentType.ECELP9600_AUDIO_VNDNUERAECELP9600:
                        return "audio/vnd.nuera.ecelp9600";

                    case EnmContentType.EDM_APPLICATION_VNDNOVADIGMEDM:
                        return "application/vnd.novadigm.edm";

                    case EnmContentType.EDX_APPLICATION_VNDNOVADIGMEDX:
                        return "application/vnd.novadigm.edx";

                    case EnmContentType.EFIF_APPLICATION_VNDPICSEL:
                        return "application/vnd.picsel";

                    case EnmContentType.EI6_APPLICATION_VNDPGOSASLI:
                        return "application/vnd.pg.osasli";

                    case EnmContentType.EML_MESSAGE_RFC822:
                        return "message/rfc822";

                    case EnmContentType.EMMA_APPLICATION_EMMA_XML:
                        return "application/emma+xml";

                    case EnmContentType.EOL_AUDIO_VNDDIGITAL_WINDS:
                        return "audio/vnd.digital-winds";

                    case EnmContentType.EOT_APPLICATION_VNDMS_FONTOBJECT:
                        return "application/vnd.ms-fontobject";

                    case EnmContentType.EPUB_APPLICATION_EPUB_ZIP:
                        return "application/epub+zip";

                    case EnmContentType.ES_APPLICATION_ECMASCRIPT:
                        return "application/ecmascript";

                    case EnmContentType.ES3_APPLICATION_VNDESZIGNO3_XML:
                        return "application/vnd.eszigno3+xml";

                    case EnmContentType.ESF_APPLICATION_VNDEPSONESF:
                        return "application/vnd.epson.esf";

                    case EnmContentType.ETX_TEXT_X_SETEXT:
                        return "text/x-setext";

                    case EnmContentType.EXE_APPLICATION_X_MSDOWNLOAD:
                        return "application/x-msdownload";

                    case EnmContentType.EXI_APPLICATION_EXI:
                        return "application/exi";

                    case EnmContentType.EXT_APPLICATION_VNDNOVADIGMEXT:
                        return "application/vnd.novadigm.ext";

                    case EnmContentType.EZ2_APPLICATION_VNDEZPIX_ALBUM:
                        return "application/vnd.ezpix-album";

                    case EnmContentType.EZ3_APPLICATION_VNDEZPIX_PACKAGE:
                        return "application/vnd.ezpix-package";

                    case EnmContentType.F_TEXT_X_FORTRAN:
                        return "text/x-fortran";

                    case EnmContentType.F4V_VIDEO_X_F4V:
                        return "video/x-f4v";

                    case EnmContentType.FBS_IMAGE_VNDFASTBIDSHEET:
                        return "image/vnd.fastbidsheet";

                    case EnmContentType.FCS_APPLICATION_VNDISACFCS:
                        return "application/vnd.isac.fcs";

                    case EnmContentType.FDF_APPLICATION_VNDFDF:
                        return "application/vnd.fdf";

                    case EnmContentType.FE_LAUNCH_APPLICATION_VNDDENOVOFCSELAYOUT_LINK:
                        return "application/vnd.denovo.fcselayout-link";

                    case EnmContentType.FG5_APPLICATION_VNDFUJITSUOASYSGP:
                        return "application/vnd.fujitsu.oasysgp";

                    case EnmContentType.FH_IMAGE_X_FREEHAND:
                        return "image/x-freehand";

                    case EnmContentType.FIG_APPLICATION_X_XFIG:
                        return "application/x-xfig";

                    case EnmContentType.FLI_VIDEO_X_FLI:
                        return "video/x-fli";

                    case EnmContentType.FLO_APPLICATION_VNDMICROGRAFXFLO:
                        return "application/vnd.micrografx.flo";

                    case EnmContentType.FLV_VIDEO_X_FLV:
                        return "video/x-flv";

                    case EnmContentType.FLW_APPLICATION_VNDKDEKIVIO:
                        return "application/vnd.kde.kivio";

                    case EnmContentType.FLX_TEXT_VNDFMIFLEXSTOR:
                        return "text/vnd.fmi.flexstor";

                    case EnmContentType.FLY_TEXT_VNDFLY:
                        return "text/vnd.fly";

                    case EnmContentType.FM_APPLICATION_VNDFRAMEMAKER:
                        return "application/vnd.framemaker";

                    case EnmContentType.FNC_APPLICATION_VNDFROGANSFNC:
                        return "application/vnd.frogans.fnc";

                    case EnmContentType.FPX_IMAGE_VNDFPX:
                        return "image/vnd.fpx";

                    case EnmContentType.FSC_APPLICATION_VNDFSCWEBLAUNCH:
                        return "application/vnd.fsc.weblaunch";

                    case EnmContentType.FST_IMAGE_VNDFST:
                        return "image/vnd.fst";

                    case EnmContentType.FTC_APPLICATION_VNDFLUXTIMECLIP:
                        return "application/vnd.fluxtime.clip";

                    case EnmContentType.FTI_APPLICATION_VNDANSER_WEB_FUNDS_TRANSFER_INITIATION:
                        return "application/vnd.anser-web-funds-transfer-initiation";

                    case EnmContentType.FVT_VIDEO_VNDFVT:
                        return "video/vnd.fvt";

                    case EnmContentType.FXP_APPLICATION_VNDADOBEFXP:
                        return "application/vnd.adobe.fxp";

                    case EnmContentType.FZS_APPLICATION_VNDFUZZYSHEET:
                        return "application/vnd.fuzzysheet";

                    case EnmContentType.G2W_APPLICATION_VNDGEOPLAN:
                        return "application/vnd.geoplan";

                    case EnmContentType.G3_IMAGE_G3FAX:
                        return "image/g3fax";

                    case EnmContentType.G3W_APPLICATION_VNDGEOSPACE:
                        return "application/vnd.geospace";

                    case EnmContentType.GAC_APPLICATION_VNDGROOVE_ACCOUNT:
                        return "application/vnd.groove-account";

                    case EnmContentType.GDL_MODEL_VNDGDL:
                        return "model/vnd.gdl";

                    case EnmContentType.GEO_APPLICATION_VNDDYNAGEO:
                        return "application/vnd.dynageo";

                    case EnmContentType.GEX_APPLICATION_VNDGEOMETRY_EXPLORER:
                        return "application/vnd.geometry-explorer";

                    case EnmContentType.GGB_APPLICATION_VNDGEOGEBRAFILE:
                        return "application/vnd.geogebra.file";

                    case EnmContentType.GGT_APPLICATION_VNDGEOGEBRATOOL:
                        return "application/vnd.geogebra.tool";

                    case EnmContentType.GHF_APPLICATION_VNDGROOVE_HELP:
                        return "application/vnd.groove-help";

                    case EnmContentType.GIF_IMAGE_GIF:
                        return "image/gif";

                    case EnmContentType.GIM_APPLICATION_VNDGROOVE_IDENTITY_MESSAGE:
                        return "application/vnd.groove-identity-message";

                    case EnmContentType.GMX_APPLICATION_VNDGMX:
                        return "application/vnd.gmx";

                    case EnmContentType.GNUMERIC_APPLICATION_X_GNUMERIC:
                        return "application/x-gnumeric";

                    case EnmContentType.GPH_APPLICATION_VNDFLOGRAPHIT:
                        return "application/vnd.flographit";

                    case EnmContentType.GQF_APPLICATION_VNDGRAFEQ:
                        return "application/vnd.grafeq";

                    case EnmContentType.GRAM_APPLICATION_SRGS:
                        return "application/srgs";

                    case EnmContentType.GRV_APPLICATION_VNDGROOVE_INJECTOR:
                        return "application/vnd.groove-injector";

                    case EnmContentType.GRXML_APPLICATION_SRGS_XML:
                        return "application/srgs+xml";

                    case EnmContentType.GSF_APPLICATION_X_FONT_GHOSTSCRIPT:
                        return "application/x-font-ghostscript";

                    case EnmContentType.GTAR_APPLICATION_X_GTAR:
                        return "application/x-gtar";

                    case EnmContentType.GTM_APPLICATION_VNDGROOVE_TOOL_MESSAGE:
                        return "application/vnd.groove-tool-message";

                    case EnmContentType.GTW_MODEL_VNDGTW:
                        return "model/vnd.gtw";

                    case EnmContentType.GV_TEXT_VNDGRAPHVIZ:
                        return "text/vnd.graphviz";

                    case EnmContentType.GXT_APPLICATION_VNDGEONEXT:
                        return "application/vnd.geonext";

                    case EnmContentType.H261_VIDEO_H261:
                        return "video/h261";

                    case EnmContentType.H263_VIDEO_H263:
                        return "video/h263";

                    case EnmContentType.H264_VIDEO_H264:
                        return "video/h264";

                    case EnmContentType.HAL_APPLICATION_VNDHAL_XML:
                        return "application/vnd.hal+xml";

                    case EnmContentType.HBCI_APPLICATION_VNDHBCI:
                        return "application/vnd.hbci";

                    case EnmContentType.HDF_APPLICATION_X_HDF:
                        return "application/x-hdf";

                    case EnmContentType.HLP_APPLICATION_WINHLP:
                        return "application/winhlp";

                    case EnmContentType.HPGL_APPLICATION_VNDHP_HPGL:
                        return "application/vnd.hp-hpgl";

                    case EnmContentType.HPID_APPLICATION_VNDHP_HPID:
                        return "application/vnd.hp-hpid";

                    case EnmContentType.HPS_APPLICATION_VNDHP_HPS:
                        return "application/vnd.hp-hps";

                    case EnmContentType.HQX_APPLICATION_MAC_BINHEX40:
                        return "application/mac-binhex40";

                    case EnmContentType.HTKE_APPLICATION_VNDKENAMEAAPP:
                        return "application/vnd.kenameaapp";

                    case EnmContentType.HTML_TEXT_HTML:
                        return "text/html";

                    case EnmContentType.HVD_APPLICATION_VNDYAMAHAHV_DIC:
                        return "application/vnd.yamaha.hv-dic";

                    case EnmContentType.HVP_APPLICATION_VNDYAMAHAHV_VOICE:
                        return "application/vnd.yamaha.hv-voice";

                    case EnmContentType.HVS_APPLICATION_VNDYAMAHAHV_SCRIPT:
                        return "application/vnd.yamaha.hv-script";

                    case EnmContentType.I2G_APPLICATION_VNDINTERGEO:
                        return "application/vnd.intergeo";

                    case EnmContentType.ICC_APPLICATION_VNDICCPROFILE:
                        return "application/vnd.iccprofile";

                    case EnmContentType.ICE_X_CONFERENCE_X_COOLTALK:
                        return "x-conference/x-cooltalk";

                    case EnmContentType.ICO_IMAGE_X_ICON:
                        return "image/x-icon";

                    case EnmContentType.ICS_TEXT_CALENDAR:
                        return "text/calendar";

                    case EnmContentType.IEF_IMAGE_IEF:
                        return "image/ief";

                    case EnmContentType.IFM_APPLICATION_VNDSHANAINFORMEDFORMDATA:
                        return "application/vnd.shana.informed.formdata";

                    case EnmContentType.IGL_APPLICATION_VNDIGLOADER:
                        return "application/vnd.igloader";

                    case EnmContentType.IGM_APPLICATION_VNDINSORSIGM:
                        return "application/vnd.insors.igm";

                    case EnmContentType.IGS_MODEL_IGES:
                        return "model/iges";

                    case EnmContentType.IGX_APPLICATION_VNDMICROGRAFXIGX:
                        return "application/vnd.micrografx.igx";

                    case EnmContentType.IIF_APPLICATION_VNDSHANAINFORMEDINTERCHANGE:
                        return "application/vnd.shana.informed.interchange";

                    case EnmContentType.IMP_APPLICATION_VNDACCPACSIMPLYIMP:
                        return "application/vnd.accpac.simply.imp";

                    case EnmContentType.IMS_APPLICATION_VNDMS_IMS:
                        return "application/vnd.ms-ims";

                    case EnmContentType.IPFIX_APPLICATION_IPFIX:
                        return "application/ipfix";

                    case EnmContentType.IPK_APPLICATION_VNDSHANAINFORMEDPACKAGE:
                        return "application/vnd.shana.informed.package";

                    case EnmContentType.IRM_APPLICATION_VNDIBMRIGHTS_MANAGEMENT:
                        return "application/vnd.ibm.rights-management";

                    case EnmContentType.IRP_APPLICATION_VNDIREPOSITORYPACKAGE_XML:
                        return "application/vnd.irepository.package+xml";

                    case EnmContentType.ITP_APPLICATION_VNDSHANAINFORMEDFORMTEMPLATE:
                        return "application/vnd.shana.informed.formtemplate";

                    case EnmContentType.IVP_APPLICATION_VNDIMMERVISION_IVP:
                        return "application/vnd.immervision-ivp";

                    case EnmContentType.IVU_APPLICATION_VNDIMMERVISION_IVU:
                        return "application/vnd.immervision-ivu";

                    case EnmContentType.JAD_TEXT_VNDSUNJ2MEAPP_DESCRIPTOR:
                        return "text/vnd.sun.j2me.app-descriptor";

                    case EnmContentType.JAM_APPLICATION_VNDJAM:
                        return "application/vnd.jam";

                    case EnmContentType.JAR_APPLICATION_JAVA_ARCHIVE:
                        return "application/java-archive";

                    case EnmContentType.JAVA_TEXT_X_JAVA_SOURCE_JAVA:
                        return "text/x-java-source,java";

                    case EnmContentType.JISP_APPLICATION_VNDJISP:
                        return "application/vnd.jisp";

                    case EnmContentType.JLT_APPLICATION_VNDHP_JLYT:
                        return "application/vnd.hp-jlyt";

                    case EnmContentType.JNLP_APPLICATION_X_JAVA_JNLP_FILE:
                        return "application/x-java-jnlp-file";

                    case EnmContentType.JODA_APPLICATION_VNDJOOSTJODA_ARCHIVE:
                        return "application/vnd.joost.joda-archive";

                    case EnmContentType.JPEG_JPG_IMAGE_JPEG:
                        return "image/jpeg";

                    case EnmContentType.JPGV_VIDEO_JPEG:
                        return "video/jpeg";

                    case EnmContentType.JPM_VIDEO_JPM:
                        return "video/jpm";

                    case EnmContentType.JS_APPLICATION_JAVASCRIPT:
                        return "application/javascript";

                    case EnmContentType.JSON_APPLICATION_JSON:
                        return "application/json";

                    case EnmContentType.KARBON_APPLICATION_VNDKDEKARBON:
                        return "application/vnd.kde.karbon";

                    case EnmContentType.KFO_APPLICATION_VNDKDEKFORMULA:
                        return "application/vnd.kde.kformula";

                    case EnmContentType.KIA_APPLICATION_VNDKIDSPIRATION:
                        return "application/vnd.kidspiration";

                    case EnmContentType.KML_APPLICATION_VNDGOOGLE_EARTHKML_XML:
                        return "application/vnd.google-earth.kml+xml";

                    case EnmContentType.KMZ_APPLICATION_VNDGOOGLE_EARTHKMZ:
                        return "application/vnd.google-earth.kmz";

                    case EnmContentType.KNE_APPLICATION_VNDKINAR:
                        return "application/vnd.kinar";

                    case EnmContentType.KON_APPLICATION_VNDKDEKONTOUR:
                        return "application/vnd.kde.kontour";

                    case EnmContentType.KPR_APPLICATION_VNDKDEKPRESENTER:
                        return "application/vnd.kde.kpresenter";

                    case EnmContentType.KSP_APPLICATION_VNDKDEKSPREAD:
                        return "application/vnd.kde.kspread";

                    case EnmContentType.KTX_IMAGE_KTX:
                        return "image/ktx";

                    case EnmContentType.KTZ_APPLICATION_VNDKAHOOTZ:
                        return "application/vnd.kahootz";

                    case EnmContentType.KWD_APPLICATION_VNDKDEKWORD:
                        return "application/vnd.kde.kword";

                    case EnmContentType.LASXML_APPLICATION_VNDLASLAS_XML:
                        return "application/vnd.las.las+xml";

                    case EnmContentType.LATEX_APPLICATION_X_LATEX:
                        return "application/x-latex";

                    case EnmContentType.LBD_APPLICATION_VNDLLAMAGRAPHICSLIFE_BALANCEDESKTOP:
                        return "application/vnd.llamagraphics.life-balance.desktop";

                    case EnmContentType.LBE_APPLICATION_VNDLLAMAGRAPHICSLIFE_BALANCEEXCHANGE_XML:
                        return "application/vnd.llamagraphics.life-balance.exchange+xml";

                    case EnmContentType.LES_APPLICATION_VNDHHELESSON_PLAYER:
                        return "application/vnd.hhe.lesson-player";

                    case EnmContentType.LINK66_APPLICATION_VNDROUTE66LINK66_XML:
                        return "application/vnd.route66.link66+xml";

                    case EnmContentType.LRM_APPLICATION_VNDMS_LRM:
                        return "application/vnd.ms-lrm";

                    case EnmContentType.LTF_APPLICATION_VNDFROGANSLTF:
                        return "application/vnd.frogans.ltf";

                    case EnmContentType.LVP_AUDIO_VNDLUCENTVOICE:
                        return "audio/vnd.lucent.voice";

                    case EnmContentType.LWP_APPLICATION_VNDLOTUS_WORDPRO:
                        return "application/vnd.lotus-wordpro";

                    case EnmContentType.M21_APPLICATION_MP21:
                        return "application/mp21";

                    case EnmContentType.M3U_AUDIO_X_MPEGURL:
                        return "audio/x-mpegurl";

                    case EnmContentType.M3U8_APPLICATION_VNDAPPLEMPEGURL:
                        return "application/vnd.apple.mpegurl";

                    case EnmContentType.M4V_VIDEO_X_M4V:
                        return "video/x-m4v";

                    case EnmContentType.MA_APPLICATION_MATHEMATICA:
                        return "application/mathematica";

                    case EnmContentType.MADS_APPLICATION_MADS_XML:
                        return "application/mads+xml";

                    case EnmContentType.MAG_APPLICATION_VNDECOWINCHART:
                        return "application/vnd.ecowin.chart";

                    case EnmContentType.MATHML_APPLICATION_MATHML_XML:
                        return "application/mathml+xml";

                    case EnmContentType.MBK_APPLICATION_VNDMOBIUSMBK:
                        return "application/vnd.mobius.mbk";

                    case EnmContentType.MBOX_APPLICATION_MBOX:
                        return "application/mbox";

                    case EnmContentType.MC1_APPLICATION_VNDMEDCALCDATA:
                        return "application/vnd.medcalcdata";

                    case EnmContentType.MCD_APPLICATION_VNDMCD:
                        return "application/vnd.mcd";

                    case EnmContentType.MCURL_TEXT_VNDCURLMCURL:
                        return "text/vnd.curl.mcurl";

                    case EnmContentType.MDB_APPLICATION_X_MSACCESS:
                        return "application/x-msaccess";

                    case EnmContentType.MDI_IMAGE_VNDMS_MODI:
                        return "image/vnd.ms-modi";

                    case EnmContentType.META4_APPLICATION_METALINK4_XML:
                        return "application/metalink4+xml";

                    case EnmContentType.METS_APPLICATION_METS_XML:
                        return "application/mets+xml";

                    case EnmContentType.MFM_APPLICATION_VNDMFMP:
                        return "application/vnd.mfmp";

                    case EnmContentType.MGP_APPLICATION_VNDOSGEOMAPGUIDEPACKAGE:
                        return "application/vnd.osgeo.mapguide.package";

                    case EnmContentType.MGZ_APPLICATION_VNDPROTEUSMAGAZINE:
                        return "application/vnd.proteus.magazine";

                    case EnmContentType.MID_AUDIO_MIDI:
                        return "audio/midi";

                    case EnmContentType.MIF_APPLICATION_VNDMIF:
                        return "application/vnd.mif";

                    case EnmContentType.MJ2_VIDEO_MJ2:
                        return "video/mj2";

                    case EnmContentType.MLP_APPLICATION_VNDDOLBYMLP:
                        return "application/vnd.dolby.mlp";

                    case EnmContentType.MMD_APPLICATION_VNDCHIPNUTSKARAOKE_MMD:
                        return "application/vnd.chipnuts.karaoke-mmd";

                    case EnmContentType.MMF_APPLICATION_VNDSMAF:
                        return "application/vnd.smaf";

                    case EnmContentType.MMR_IMAGE_VNDFUJIXEROXEDMICS_MMR:
                        return "image/vnd.fujixerox.edmics-mmr";

                    case EnmContentType.MNY_APPLICATION_X_MSMONEY:
                        return "application/x-msmoney";

                    case EnmContentType.MODS_APPLICATION_MODS_XML:
                        return "application/mods+xml";

                    case EnmContentType.MOVIE_VIDEO_X_SGI_MOVIE:
                        return "video/x-sgi-movie";

                    case EnmContentType.MP4_VIDEO_MP4:
                        return "video/mp4";

                    case EnmContentType.MP4_APPLICATION_MP4:
                        return "application/mp4";

                    case EnmContentType.MP4A_AUDIO_MP4:
                        return "audio/mp4";

                    case EnmContentType.MPC_APPLICATION_VNDMOPHUNCERTIFICATE:
                        return "application/vnd.mophun.certificate";

                    case EnmContentType.MPEG_VIDEO_MPEG:
                        return "video/mpeg";

                    case EnmContentType.MPGA_AUDIO_MPEG:
                        return "audio/mpeg";

                    case EnmContentType.MPKG_APPLICATION_VNDAPPLEINSTALLER_XML:
                        return "application/vnd.apple.installer+xml";

                    case EnmContentType.MPM_APPLICATION_VNDBLUEICEMULTIPASS:
                        return "application/vnd.blueice.multipass";

                    case EnmContentType.MPN_APPLICATION_VNDMOPHUNAPPLICATION:
                        return "application/vnd.mophun.application";

                    case EnmContentType.MPP_APPLICATION_VNDMS_PROJECT:
                        return "application/vnd.ms-project";

                    case EnmContentType.MPY_APPLICATION_VNDIBMMINIPAY:
                        return "application/vnd.ibm.minipay";

                    case EnmContentType.MQY_APPLICATION_VNDMOBIUSMQY:
                        return "application/vnd.mobius.mqy";

                    case EnmContentType.MRC_APPLICATION_MARC:
                        return "application/marc";

                    case EnmContentType.MRCX_APPLICATION_MARCXML_XML:
                        return "application/marcxml+xml";

                    case EnmContentType.MSCML_APPLICATION_MEDIASERVERCONTROL_XML:
                        return "application/mediaservercontrol+xml";

                    case EnmContentType.MSEQ_APPLICATION_VNDMSEQ:
                        return "application/vnd.mseq";

                    case EnmContentType.MSF_APPLICATION_VNDEPSONMSF:
                        return "application/vnd.epson.msf";

                    case EnmContentType.MSH_MODEL_MESH:
                        return "model/mesh";

                    case EnmContentType.MSL_APPLICATION_VNDMOBIUSMSL:
                        return "application/vnd.mobius.msl";

                    case EnmContentType.MSTY_APPLICATION_VNDMUVEESTYLE:
                        return "application/vnd.muvee.style";

                    case EnmContentType.MTS_MODEL_VNDMTS:
                        return "model/vnd.mts";

                    case EnmContentType.MUS_APPLICATION_VNDMUSICIAN:
                        return "application/vnd.musician";

                    case EnmContentType.MUSICXML_APPLICATION_VNDRECORDAREMUSICXML_XML:
                        return "application/vnd.recordare.musicxml+xml";

                    case EnmContentType.MVB_APPLICATION_X_MSMEDIAVIEW:
                        return "application/x-msmediaview";

                    case EnmContentType.MWF_APPLICATION_VNDMFER:
                        return "application/vnd.mfer";

                    case EnmContentType.MXF_APPLICATION_MXF:
                        return "application/mxf";

                    case EnmContentType.MXL_APPLICATION_VNDRECORDAREMUSICXML:
                        return "application/vnd.recordare.musicxml";

                    case EnmContentType.MXML_APPLICATION_XV_XML:
                        return "application/xv+xml";

                    case EnmContentType.MXS_APPLICATION_VNDTRISCAPEMXS:
                        return "application/vnd.triscape.mxs";

                    case EnmContentType.MXU_VIDEO_VNDMPEGURL:
                        return "video/vnd.mpegurl";

                    case EnmContentType.N3_TEXT_N3:
                        return "text/n3";

                    case EnmContentType.NBP_APPLICATION_VNDWOLFRAMPLAYER:
                        return "application/vnd.wolfram.player";

                    case EnmContentType.NC_APPLICATION_X_NETCDF:
                        return "application/x-netcdf";

                    case EnmContentType.NCX_APPLICATION_X_DTBNCX_XML:
                        return "application/x-dtbncx+xml";

                    case EnmContentType.N_GAGE_APPLICATION_VNDNOKIAN_GAGESYMBIANINSTALL:
                        return "application/vnd.nokia.n-gage.symbian.install";

                    case EnmContentType.NGDAT_APPLICATION_VNDNOKIAN_GAGEDATA:
                        return "application/vnd.nokia.n-gage.data";

                    case EnmContentType.NLU_APPLICATION_VNDNEUROLANGUAGENLU:
                        return "application/vnd.neurolanguage.nlu";

                    case EnmContentType.NML_APPLICATION_VNDENLIVEN:
                        return "application/vnd.enliven";

                    case EnmContentType.NND_APPLICATION_VNDNOBLENET_DIRECTORY:
                        return "application/vnd.noblenet-directory";

                    case EnmContentType.NNS_APPLICATION_VNDNOBLENET_SEALER:
                        return "application/vnd.noblenet-sealer";

                    case EnmContentType.NNW_APPLICATION_VNDNOBLENET_WEB:
                        return "application/vnd.noblenet-web";

                    case EnmContentType.NPX_IMAGE_VNDNET_FPX:
                        return "image/vnd.net-fpx";

                    case EnmContentType.NSF_APPLICATION_VNDLOTUS_NOTES:
                        return "application/vnd.lotus-notes";

                    case EnmContentType.OA2_APPLICATION_VNDFUJITSUOASYS2:
                        return "application/vnd.fujitsu.oasys2";

                    case EnmContentType.OA3_APPLICATION_VNDFUJITSUOASYS3:
                        return "application/vnd.fujitsu.oasys3";

                    case EnmContentType.OAS_APPLICATION_VNDFUJITSUOASYS:
                        return "application/vnd.fujitsu.oasys";

                    case EnmContentType.OBD_APPLICATION_X_MSBINDER:
                        return "application/x-msbinder";

                    case EnmContentType.ODA_APPLICATION_ODA:
                        return "application/oda";

                    case EnmContentType.ODB_APPLICATION_VNDOASISOPENDOCUMENTDATABASE:
                        return "application/vnd.oasis.opendocument.database";

                    case EnmContentType.ODC_APPLICATION_VNDOASISOPENDOCUMENTCHART:
                        return "application/vnd.oasis.opendocument.chart";

                    case EnmContentType.ODF_APPLICATION_VNDOASISOPENDOCUMENTFORMULA:
                        return "application/vnd.oasis.opendocument.formula";

                    case EnmContentType.ODFT_APPLICATION_VNDOASISOPENDOCUMENTFORMULA_TEMPLATE:
                        return "application/vnd.oasis.opendocument.formula-template";

                    case EnmContentType.ODG_APPLICATION_VNDOASISOPENDOCUMENTGRAPHICS:
                        return "application/vnd.oasis.opendocument.graphics";

                    case EnmContentType.ODI_APPLICATION_VNDOASISOPENDOCUMENTIMAGE:
                        return "application/vnd.oasis.opendocument.image";

                    case EnmContentType.ODM_APPLICATION_VNDOASISOPENDOCUMENTTEXT_MASTER:
                        return "application/vnd.oasis.opendocument.text-master";

                    case EnmContentType.ODP_APPLICATION_VNDOASISOPENDOCUMENTPRESENTATION:
                        return "application/vnd.oasis.opendocument.presentation";

                    case EnmContentType.ODS_APPLICATION_VNDOASISOPENDOCUMENTSPREADSHEET:
                        return "application/vnd.oasis.opendocument.spreadsheet";

                    case EnmContentType.ODT_APPLICATION_VNDOASISOPENDOCUMENTTEXT:
                        return "application/vnd.oasis.opendocument.text";

                    case EnmContentType.OGA_AUDIO_OGG:
                        return "audio/ogg";

                    case EnmContentType.OGV_VIDEO_OGG:
                        return "video/ogg";

                    case EnmContentType.OGX_APPLICATION_OGG:
                        return "application/ogg";

                    case EnmContentType.ONETOC_APPLICATION_ONENOTE:
                        return "application/onenote";

                    case EnmContentType.OPF_APPLICATION_OEBPS_PACKAGE_XML:
                        return "application/oebps-package+xml";

                    case EnmContentType.ORG_APPLICATION_VNDLOTUS_ORGANIZER:
                        return "application/vnd.lotus-organizer";

                    case EnmContentType.OSF_APPLICATION_VNDYAMAHAOPENSCOREFORMAT:
                        return "application/vnd.yamaha.openscoreformat";

                    case EnmContentType.OSFPVG_APPLICATION_VNDYAMAHAOPENSCOREFORMATOSFPVG_XML:
                        return "application/vnd.yamaha.openscoreformat.osfpvg+xml";

                    case EnmContentType.OTC_APPLICATION_VNDOASISOPENDOCUMENTCHART_TEMPLATE:
                        return "application/vnd.oasis.opendocument.chart-template";

                    case EnmContentType.OTF_APPLICATION_X_FONT_OTF:
                        return "application/x-font-otf";

                    case EnmContentType.OTG_APPLICATION_VNDOASISOPENDOCUMENTGRAPHICS_TEMPLATE:
                        return "application/vnd.oasis.opendocument.graphics-template";

                    case EnmContentType.OTH_APPLICATION_VNDOASISOPENDOCUMENTTEXT_WEB:
                        return "application/vnd.oasis.opendocument.text-web";

                    case EnmContentType.OTI_APPLICATION_VNDOASISOPENDOCUMENTIMAGE_TEMPLATE:
                        return "application/vnd.oasis.opendocument.image-template";

                    case EnmContentType.OTP_APPLICATION_VNDOASISOPENDOCUMENTPRESENTATION_TEMPLATE:
                        return "application/vnd.oasis.opendocument.presentation-template";

                    case EnmContentType.OTS_APPLICATION_VNDOASISOPENDOCUMENTSPREADSHEET_TEMPLATE:
                        return "application/vnd.oasis.opendocument.spreadsheet-template";

                    case EnmContentType.OTT_APPLICATION_VNDOASISOPENDOCUMENTTEXT_TEMPLATE:
                        return "application/vnd.oasis.opendocument.text-template";

                    case EnmContentType.OXT_APPLICATION_VNDOPENOFFICEORGEXTENSION:
                        return "application/vnd.openofficeorg.extension";

                    case EnmContentType.P_TEXT_X_PASCAL:
                        return "text/x-pascal";

                    case EnmContentType.P10_APPLICATION_PKCS10:
                        return "application/pkcs10";

                    case EnmContentType.P12_APPLICATION_X_PKCS12:
                        return "application/x-pkcs12";

                    case EnmContentType.P7B_APPLICATION_X_PKCS7_CERTIFICATES:
                        return "application/x-pkcs7-certificates";

                    case EnmContentType.P7M_APPLICATION_PKCS7_MIME:
                        return "application/pkcs7-mime";

                    case EnmContentType.P7R_APPLICATION_X_PKCS7_CERTREQRESP:
                        return "application/x-pkcs7-certreqresp";

                    case EnmContentType.P7S_APPLICATION_PKCS7_SIGNATURE:
                        return "application/pkcs7-signature";

                    case EnmContentType.P8_APPLICATION_PKCS8:
                        return "application/pkcs8";

                    case EnmContentType.PAR_TEXT_PLAIN_BAS:
                        return "text/plain-bas";

                    case EnmContentType.PAW_APPLICATION_VNDPAWAAFILE:
                        return "application/vnd.pawaafile";

                    case EnmContentType.PBD_APPLICATION_VNDPOWERBUILDER6:
                        return "application/vnd.powerbuilder6";

                    case EnmContentType.PBM_IMAGE_X_PORTABLE_BITMAP:
                        return "image/x-portable-bitmap";

                    case EnmContentType.PCF_APPLICATION_X_FONT_PCF:
                        return "application/x-font-pcf";

                    case EnmContentType.PCL_APPLICATION_VNDHP_PCL:
                        return "application/vnd.hp-pcl";

                    case EnmContentType.PCLXL_APPLICATION_VNDHP_PCLXL:
                        return "application/vnd.hp-pclxl";

                    case EnmContentType.PCURL_APPLICATION_VNDCURLPCURL:
                        return "application/vnd.curl.pcurl";

                    case EnmContentType.PCX_IMAGE_X_PCX:
                        return "image/x-pcx";

                    case EnmContentType.PDB_APPLICATION_VNDPALM:
                        return "application/vnd.palm";

                    case EnmContentType.PDF_APPLICATION_PDF:
                        return "application/pdf";

                    case EnmContentType.PFA_APPLICATION_X_FONT_TYPE1:
                        return "application/x-font-type1";

                    case EnmContentType.PFR_APPLICATION_FONT_TDPFR:
                        return "application/font-tdpfr";

                    case EnmContentType.PGM_IMAGE_X_PORTABLE_GRAYMAP:
                        return "image/x-portable-graymap";

                    case EnmContentType.PGN_APPLICATION_X_CHESS_PGN:
                        return "application/x-chess-pgn";

                    case EnmContentType.PGP_APPLICATION_PGP_SIGNATURE:
                        return "application/pgp-signature";

                    case EnmContentType.PIC_IMAGE_X_PICT:
                        return "image/x-pict";

                    case EnmContentType.PKI_APPLICATION_PKIXCMP:
                        return "application/pkixcmp";

                    case EnmContentType.PKIPATH_APPLICATION_PKIX_PKIPATH:
                        return "application/pkix-pkipath";

                    case EnmContentType.PLB_APPLICATION_VND3GPPPIC_BW_LARGE:
                        return "application/vnd.3gpp.pic-bw-large";

                    case EnmContentType.PLC_APPLICATION_VNDMOBIUSPLC:
                        return "application/vnd.mobius.plc";

                    case EnmContentType.PLF_APPLICATION_VNDPOCKETLEARN:
                        return "application/vnd.pocketlearn";

                    case EnmContentType.PLS_APPLICATION_PLS_XML:
                        return "application/pls+xml";

                    case EnmContentType.PML_APPLICATION_VNDCTC_POSML:
                        return "application/vnd.ctc-posml";

                    case EnmContentType.PNG_IMAGE_PNG:
                        return "image/png";

                    case EnmContentType.PNM_IMAGE_X_PORTABLE_ANYMAP:
                        return "image/x-portable-anymap";

                    case EnmContentType.PORTPKG_APPLICATION_VNDMACPORTSPORTPKG:
                        return "application/vnd.macports.portpkg";

                    case EnmContentType.POTM_APPLICATION_VNDMS_POWERPOINTTEMPLATEMACROENABLED12:
                        return "application/vnd.ms-powerpoint.template.macroenabled.12";

                    case EnmContentType.POTX_APPLICATION_VNDOPENXMLFORMATS_OFFICEDOCUMENTPRESENTATIONMLTEMPLATE:
                        return "application/vnd.openxmlformats-officedocument.presentationml.template";

                    case EnmContentType.PPAM_APPLICATION_VNDMS_POWERPOINTADDINMACROENABLED12:
                        return "application/vnd.ms-powerpoint.addin.macroenabled.12";

                    case EnmContentType.PPD_APPLICATION_VNDCUPS_PPD:
                        return "application/vnd.cups-ppd";

                    case EnmContentType.PPM_IMAGE_X_PORTABLE_PIXMAP:
                        return "image/x-portable-pixmap";

                    case EnmContentType.PPSM_APPLICATION_VNDMS_POWERPOINTSLIDESHOWMACROENABLED12:
                        return "application/vnd.ms-powerpoint.slideshow.macroenabled.12";

                    case EnmContentType.PPSX_APPLICATION_VNDOPENXMLFORMATS_OFFICEDOCUMENTPRESENTATIONMLSLIDESHOW:
                        return "application/vnd.openxmlformats-officedocument.presentationml.slideshow";

                    case EnmContentType.PPT_APPLICATION_VNDMS_POWERPOINT:
                        return "application/vnd.ms-powerpoint";

                    case EnmContentType.PPTM_APPLICATION_VNDMS_POWERPOINTPRESENTATIONMACROENABLED12:
                        return "application/vnd.ms-powerpoint.presentation.macroenabled.12";

                    case EnmContentType.PPTX_APPLICATION_VNDOPENXMLFORMATS_OFFICEDOCUMENTPRESENTATIONMLPRESENTATION:
                        return "application/vnd.openxmlformats-officedocument.presentationml.presentation";

                    case EnmContentType.PRC_APPLICATION_X_MOBIPOCKET_EBOOK:
                        return "application/x-mobipocket-ebook";

                    case EnmContentType.PRE_APPLICATION_VNDLOTUS_FREELANCE:
                        return "application/vnd.lotus-freelance";

                    case EnmContentType.PRF_APPLICATION_PICS_RULES:
                        return "application/pics-rules";

                    case EnmContentType.PSB_APPLICATION_VND3GPPPIC_BW_SMALL:
                        return "application/vnd.3gpp.pic-bw-small";

                    case EnmContentType.PSD_IMAGE_VNDADOBEPHOTOSHOP:
                        return "image/vnd.adobe.photoshop";

                    case EnmContentType.PSF_APPLICATION_X_FONT_LINUX_PSF:
                        return "application/x-font-linux-psf";

                    case EnmContentType.PSKCXML_APPLICATION_PSKC_XML:
                        return "application/pskc+xml";

                    case EnmContentType.PTID_APPLICATION_VNDPVIPTID1:
                        return "application/vnd.pvi.ptid1";

                    case EnmContentType.PUB_APPLICATION_X_MSPUBLISHER:
                        return "application/x-mspublisher";

                    case EnmContentType.PVB_APPLICATION_VND3GPPPIC_BW_VAR:
                        return "application/vnd.3gpp.pic-bw-var";

                    case EnmContentType.PWN_APPLICATION_VND3MPOST_IT_NOTES:
                        return "application/vnd.3m.post-it-notes";

                    case EnmContentType.PYA_AUDIO_VNDMS_PLAYREADYMEDIAPYA:
                        return "audio/vnd.ms-playready.media.pya";

                    case EnmContentType.PYV_VIDEO_VNDMS_PLAYREADYMEDIAPYV:
                        return "video/vnd.ms-playready.media.pyv";

                    case EnmContentType.QAM_APPLICATION_VNDEPSONQUICKANIME:
                        return "application/vnd.epson.quickanime";

                    case EnmContentType.QBO_APPLICATION_VNDINTUQBO:
                        return "application/vnd.intu.qbo";

                    case EnmContentType.QFX_APPLICATION_VNDINTUQFX:
                        return "application/vnd.intu.qfx";

                    case EnmContentType.QPS_APPLICATION_VNDPUBLISHARE_DELTA_TREE:
                        return "application/vnd.publishare-delta-tree";

                    case EnmContentType.QT_VIDEO_QUICKTIME:
                        return "video/quicktime";

                    case EnmContentType.QXD_APPLICATION_VNDQUARKQUARKXPRESS:
                        return "application/vnd.quark.quarkxpress";

                    case EnmContentType.RAM_AUDIO_X_PN_REALAUDIO:
                        return "audio/x-pn-realaudio";

                    case EnmContentType.RAR_APPLICATION_X_RAR_COMPRESSED:
                        return "application/x-rar-compressed";

                    case EnmContentType.RAS_IMAGE_X_CMU_RASTER:
                        return "image/x-cmu-raster";

                    case EnmContentType.RCPROFILE_APPLICATION_VNDIPUNPLUGGEDRCPROFILE:
                        return "application/vnd.ipunplugged.rcprofile";

                    case EnmContentType.RDF_APPLICATION_RDF_XML:
                        return "application/rdf+xml";

                    case EnmContentType.RDZ_APPLICATION_VNDDATA_VISIONRDZ:
                        return "application/vnd.data-vision.rdz";

                    case EnmContentType.REP_APPLICATION_VNDBUSINESSOBJECTS:
                        return "application/vnd.businessobjects";

                    case EnmContentType.RES_APPLICATION_X_DTBRESOURCE_XML:
                        return "application/x-dtbresource+xml";

                    case EnmContentType.RGB_IMAGE_X_RGB:
                        return "image/x-rgb";

                    case EnmContentType.RIF_APPLICATION_REGINFO_XML:
                        return "application/reginfo+xml";

                    case EnmContentType.RIP_AUDIO_VNDRIP:
                        return "audio/vnd.rip";

                    case EnmContentType.RL_APPLICATION_RESOURCE_LISTS_XML:
                        return "application/resource-lists+xml";

                    case EnmContentType.RLC_IMAGE_VNDFUJIXEROXEDMICS_RLC:
                        return "image/vnd.fujixerox.edmics-rlc";

                    case EnmContentType.RLD_APPLICATION_RESOURCE_LISTS_DIFF_XML:
                        return "application/resource-lists-diff+xml";

                    case EnmContentType.RM_APPLICATION_VNDRN_REALMEDIA:
                        return "application/vnd.rn-realmedia";

                    case EnmContentType.RMP_AUDIO_X_PN_REALAUDIO_PLUGIN:
                        return "audio/x-pn-realaudio-plugin";

                    case EnmContentType.RMS_APPLICATION_VNDJCPJAVAMEMIDLET_RMS:
                        return "application/vnd.jcp.javame.midlet-rms";

                    case EnmContentType.RNC_APPLICATION_RELAX_NG_COMPACT_SYNTAX:
                        return "application/relax-ng-compact-syntax";

                    case EnmContentType.RP9_APPLICATION_VNDCLOANTORP9:
                        return "application/vnd.cloanto.rp9";

                    case EnmContentType.RPSS_APPLICATION_VNDNOKIARADIO_PRESETS:
                        return "application/vnd.nokia.radio-presets";

                    case EnmContentType.RPST_APPLICATION_VNDNOKIARADIO_PRESET:
                        return "application/vnd.nokia.radio-preset";

                    case EnmContentType.RQ_APPLICATION_SPARQL_QUERY:
                        return "application/sparql-query";

                    case EnmContentType.RS_APPLICATION_RLS_SERVICES_XML:
                        return "application/rls-services+xml";

                    case EnmContentType.RSD_APPLICATION_RSD_XML:
                        return "application/rsd+xml";

                    case EnmContentType.RSS_XML_APPLICATION_RSS_XML:
                        return "application/rss+xml";

                    case EnmContentType.RTF_APPLICATION_RTF:
                        return "application/rtf";

                    case EnmContentType.RTX_TEXT_RICHTEXT:
                        return "text/richtext";

                    case EnmContentType.S_TEXT_X_ASM:
                        return "text/x-asm";

                    case EnmContentType.SAF_APPLICATION_VNDYAMAHASMAF_AUDIO:
                        return "application/vnd.yamaha.smaf-audio";

                    case EnmContentType.SBML_APPLICATION_SBML_XML:
                        return "application/sbml+xml";

                    case EnmContentType.SC_APPLICATION_VNDIBMSECURE_CONTAINER:
                        return "application/vnd.ibm.secure-container";

                    case EnmContentType.SCD_APPLICATION_X_MSSCHEDULE:
                        return "application/x-msschedule";

                    case EnmContentType.SCM_APPLICATION_VNDLOTUS_SCREENCAM:
                        return "application/vnd.lotus-screencam";

                    case EnmContentType.SCQ_APPLICATION_SCVP_CV_REQUEST:
                        return "application/scvp-cv-request";

                    case EnmContentType.SCS_APPLICATION_SCVP_CV_RESPONSE:
                        return "application/scvp-cv-response";

                    case EnmContentType.SCURL_TEXT_VNDCURLSCURL:
                        return "text/vnd.curl.scurl";

                    case EnmContentType.SDA_APPLICATION_VNDSTARDIVISIONDRAW:
                        return "application/vnd.stardivision.draw";

                    case EnmContentType.SDC_APPLICATION_VNDSTARDIVISIONCALC:
                        return "application/vnd.stardivision.calc";

                    case EnmContentType.SDD_APPLICATION_VNDSTARDIVISIONIMPRESS:
                        return "application/vnd.stardivision.impress";

                    case EnmContentType.SDKM_APPLICATION_VNDSOLENTSDKM_XML:
                        return "application/vnd.solent.sdkm+xml";

                    case EnmContentType.SDP_APPLICATION_SDP:
                        return "application/sdp";

                    case EnmContentType.SDW_APPLICATION_VNDSTARDIVISIONWRITER:
                        return "application/vnd.stardivision.writer";

                    case EnmContentType.SEE_APPLICATION_VNDSEEMAIL:
                        return "application/vnd.seemail";

                    case EnmContentType.SEED_APPLICATION_VNDFDSNSEED:
                        return "application/vnd.fdsn.seed";

                    case EnmContentType.SEMA_APPLICATION_VNDSEMA:
                        return "application/vnd.sema";

                    case EnmContentType.SEMD_APPLICATION_VNDSEMD:
                        return "application/vnd.semd";

                    case EnmContentType.SEMF_APPLICATION_VNDSEMF:
                        return "application/vnd.semf";

                    case EnmContentType.SER_APPLICATION_JAVA_SERIALIZED_OBJECT:
                        return "application/java-serialized-object";

                    case EnmContentType.SETPAY_APPLICATION_SET_PAYMENT_INITIATION:
                        return "application/set-payment-initiation";

                    case EnmContentType.SETREG_APPLICATION_SET_REGISTRATION_INITIATION:
                        return "application/set-registration-initiation";

                    case EnmContentType.SFD_HDSTX_APPLICATION_VNDHYDROSTATIXSOF_DATA:
                        return "application/vnd.hydrostatix.sof-data";

                    case EnmContentType.SFS_APPLICATION_VNDSPOTFIRESFS:
                        return "application/vnd.spotfire.sfs";

                    case EnmContentType.SGL_APPLICATION_VNDSTARDIVISIONWRITER_GLOBAL:
                        return "application/vnd.stardivision.writer-global";

                    case EnmContentType.SGML_TEXT_SGML:
                        return "text/sgml";

                    case EnmContentType.SH_APPLICATION_X_SH:
                        return "application/x-sh";

                    case EnmContentType.SHAR_APPLICATION_X_SHAR:
                        return "application/x-shar";

                    case EnmContentType.SHF_APPLICATION_SHF_XML:
                        return "application/shf+xml";

                    case EnmContentType.SIS_APPLICATION_VNDSYMBIANINSTALL:
                        return "application/vnd.symbian.install";

                    case EnmContentType.SIT_APPLICATION_X_STUFFIT:
                        return "application/x-stuffit";

                    case EnmContentType.SITX_APPLICATION_X_STUFFITX:
                        return "application/x-stuffitx";

                    case EnmContentType.SKP_APPLICATION_VNDKOAN:
                        return "application/vnd.koan";

                    case EnmContentType.SLDM_APPLICATION_VNDMS_POWERPOINTSLIDEMACROENABLED12:
                        return "application/vnd.ms-powerpoint.slide.macroenabled.12";

                    case EnmContentType.SLDX_APPLICATION_VNDOPENXMLFORMATS_OFFICEDOCUMENTPRESENTATIONMLSLIDE:
                        return "application/vnd.openxmlformats-officedocument.presentationml.slide";

                    case EnmContentType.SLT_APPLICATION_VNDEPSONSALT:
                        return "application/vnd.epson.salt";

                    case EnmContentType.SM_APPLICATION_VNDSTEPMANIASTEPCHART:
                        return "application/vnd.stepmania.stepchart";

                    case EnmContentType.SMF_APPLICATION_VNDSTARDIVISIONMATH:
                        return "application/vnd.stardivision.math";

                    case EnmContentType.SMI_APPLICATION_SMIL_XML:
                        return "application/smil+xml";

                    case EnmContentType.SNF_APPLICATION_X_FONT_SNF:
                        return "application/x-font-snf";

                    case EnmContentType.SPF_APPLICATION_VNDYAMAHASMAF_PHRASE:
                        return "application/vnd.yamaha.smaf-phrase";

                    case EnmContentType.SPL_APPLICATION_X_FUTURESPLASH:
                        return "application/x-futuresplash";

                    case EnmContentType.SPOT_TEXT_VNDIN3DSPOT:
                        return "text/vnd.in3d.spot";

                    case EnmContentType.SPP_APPLICATION_SCVP_VP_RESPONSE:
                        return "application/scvp-vp-response";

                    case EnmContentType.SPQ_APPLICATION_SCVP_VP_REQUEST:
                        return "application/scvp-vp-request";

                    case EnmContentType.SRC_APPLICATION_X_WAIS_SOURCE:
                        return "application/x-wais-source";

                    case EnmContentType.SRU_APPLICATION_SRU_XML:
                        return "application/sru+xml";

                    case EnmContentType.SRX_APPLICATION_SPARQL_RESULTS_XML:
                        return "application/sparql-results+xml";

                    case EnmContentType.SSE_APPLICATION_VNDKODAK_DESCRIPTOR:
                        return "application/vnd.kodak-descriptor";

                    case EnmContentType.SSF_APPLICATION_VNDEPSONSSF:
                        return "application/vnd.epson.ssf";

                    case EnmContentType.SSML_APPLICATION_SSML_XML:
                        return "application/ssml+xml";

                    case EnmContentType.ST_APPLICATION_VNDSAILINGTRACKERTRACK:
                        return "application/vnd.sailingtracker.track";

                    case EnmContentType.STC_APPLICATION_VNDSUNXMLCALCTEMPLATE:
                        return "application/vnd.sun.xml.calc.template";

                    case EnmContentType.STD_APPLICATION_VNDSUNXMLDRAWTEMPLATE:
                        return "application/vnd.sun.xml.draw.template";

                    case EnmContentType.STF_APPLICATION_VNDWTSTF:
                        return "application/vnd.wt.stf";

                    case EnmContentType.STI_APPLICATION_VNDSUNXMLIMPRESSTEMPLATE:
                        return "application/vnd.sun.xml.impress.template";

                    case EnmContentType.STK_APPLICATION_HYPERSTUDIO:
                        return "application/hyperstudio";

                    case EnmContentType.STL_APPLICATION_VNDMS_PKISTL:
                        return "application/vnd.ms-pki.stl";

                    case EnmContentType.STR_APPLICATION_VNDPGFORMAT:
                        return "application/vnd.pg.format";

                    case EnmContentType.STW_APPLICATION_VNDSUNXMLWRITERTEMPLATE:
                        return "application/vnd.sun.xml.writer.template";

                    case EnmContentType.SUB_IMAGE_VNDDVBSUBTITLE:
                        return "image/vnd.dvb.subtitle";

                    case EnmContentType.SUS_APPLICATION_VNDSUS_CALENDAR:
                        return "application/vnd.sus-calendar";

                    case EnmContentType.SV4CPIO_APPLICATION_X_SV4CPIO:
                        return "application/x-sv4cpio";

                    case EnmContentType.SV4CRC_APPLICATION_X_SV4CRC:
                        return "application/x-sv4crc";

                    case EnmContentType.SVC_APPLICATION_VNDDVBSERVICE:
                        return "application/vnd.dvb.service";

                    case EnmContentType.SVD_APPLICATION_VNDSVD:
                        return "application/vnd.svd";

                    case EnmContentType.SVG_IMAGE_SVG_XML:
                        return "image/svg+xml";

                    case EnmContentType.SWF_APPLICATION_X_SHOCKWAVE_FLASH:
                        return "application/x-shockwave-flash";

                    case EnmContentType.SWI_APPLICATION_VNDARISTANETWORKSSWI:
                        return "application/vnd.aristanetworks.swi";

                    case EnmContentType.SXC_APPLICATION_VNDSUNXMLCALC:
                        return "application/vnd.sun.xml.calc";

                    case EnmContentType.SXD_APPLICATION_VNDSUNXMLDRAW:
                        return "application/vnd.sun.xml.draw";

                    case EnmContentType.SXG_APPLICATION_VNDSUNXMLWRITERGLOBAL:
                        return "application/vnd.sun.xml.writer.global";

                    case EnmContentType.SXI_APPLICATION_VNDSUNXMLIMPRESS:
                        return "application/vnd.sun.xml.impress";

                    case EnmContentType.SXM_APPLICATION_VNDSUNXMLMATH:
                        return "application/vnd.sun.xml.math";

                    case EnmContentType.SXW_APPLICATION_VNDSUNXMLWRITER:
                        return "application/vnd.sun.xml.writer";

                    case EnmContentType.T_TEXT_TROFF:
                        return "text/troff";

                    case EnmContentType.TAO_APPLICATION_VNDTAOINTENT_MODULE_ARCHIVE:
                        return "application/vnd.tao.intent-module-archive";

                    case EnmContentType.TAR_APPLICATION_X_TAR:
                        return "application/x-tar";

                    case EnmContentType.TCAP_APPLICATION_VND3GPP2TCAP:
                        return "application/vnd.3gpp2.tcap";

                    case EnmContentType.TCL_APPLICATION_X_TCL:
                        return "application/x-tcl";

                    case EnmContentType.TEACHER_APPLICATION_VNDSMARTTEACHER:
                        return "application/vnd.smart.teacher";

                    case EnmContentType.TEI_APPLICATION_TEI_XML:
                        return "application/tei+xml";

                    case EnmContentType.TEX_APPLICATION_X_TEX:
                        return "application/x-tex";

                    case EnmContentType.TEXINFO_APPLICATION_X_TEXINFO:
                        return "application/x-texinfo";

                    case EnmContentType.TFI_APPLICATION_THRAUD_XML:
                        return "application/thraud+xml";

                    case EnmContentType.TFM_APPLICATION_X_TEX_TFM:
                        return "application/x-tex-tfm";

                    case EnmContentType.THMX_APPLICATION_VNDMS_OFFICETHEME:
                        return "application/vnd.ms-officetheme";

                    case EnmContentType.TIFF_IMAGE_TIFF:
                        return "image/tiff";

                    case EnmContentType.TMO_APPLICATION_VNDTMOBILE_LIVETV:
                        return "application/vnd.tmobile-livetv";

                    case EnmContentType.TORRENT_APPLICATION_X_BITTORRENT:
                        return "application/x-bittorrent";

                    case EnmContentType.TPL_APPLICATION_VNDGROOVE_TOOL_TEMPLATE:
                        return "application/vnd.groove-tool-template";

                    case EnmContentType.TPT_APPLICATION_VNDTRIDTPT:
                        return "application/vnd.trid.tpt";

                    case EnmContentType.TRA_APPLICATION_VNDTRUEAPP:
                        return "application/vnd.trueapp";

                    case EnmContentType.TRM_APPLICATION_X_MSTERMINAL:
                        return "application/x-msterminal";

                    case EnmContentType.TSD_APPLICATION_TIMESTAMPED_DATA:
                        return "application/timestamped-data";

                    case EnmContentType.TSV_TEXT_TAB_SEPARATED_VALUES:
                        return "text/tab-separated-values";

                    case EnmContentType.TTF_APPLICATION_X_FONT_TTF:
                        return "application/x-font-ttf";

                    case EnmContentType.TTL_TEXT_TURTLE:
                        return "text/turtle";

                    case EnmContentType.TWD_APPLICATION_VNDSIMTECH_MINDMAPPER:
                        return "application/vnd.simtech-mindmapper";

                    case EnmContentType.TXD_APPLICATION_VNDGENOMATIXTUXEDO:
                        return "application/vnd.genomatix.tuxedo";

                    case EnmContentType.TXF_APPLICATION_VNDMOBIUSTXF:
                        return "application/vnd.mobius.txf";

                    case EnmContentType.UFD_APPLICATION_VNDUFDL:
                        return "application/vnd.ufdl";

                    case EnmContentType.UMJ_APPLICATION_VNDUMAJIN:
                        return "application/vnd.umajin";

                    case EnmContentType.UNITYWEB_APPLICATION_VNDUNITY:
                        return "application/vnd.unity";

                    case EnmContentType.UOML_APPLICATION_VNDUOML_XML:
                        return "application/vnd.uoml+xml";

                    case EnmContentType.URI_TEXT_URI_LIST:
                        return "text/uri-list";

                    case EnmContentType.USTAR_APPLICATION_X_USTAR:
                        return "application/x-ustar";

                    case EnmContentType.UTZ_APPLICATION_VNDUIQTHEME:
                        return "application/vnd.uiq.theme";

                    case EnmContentType.UU_TEXT_X_UUENCODE:
                        return "text/x-uuencode";

                    case EnmContentType.UVA_AUDIO_VNDDECEAUDIO:
                        return "audio/vnd.dece.audio";

                    case EnmContentType.UVH_VIDEO_VNDDECEHD:
                        return "video/vnd.dece.hd";

                    case EnmContentType.UVI_IMAGE_VNDDECEGRAPHIC:
                        return "image/vnd.dece.graphic";

                    case EnmContentType.UVM_VIDEO_VNDDECEMOBILE:
                        return "video/vnd.dece.mobile";

                    case EnmContentType.UVP_VIDEO_VNDDECEPD:
                        return "video/vnd.dece.pd";

                    case EnmContentType.UVS_VIDEO_VNDDECESD:
                        return "video/vnd.dece.sd";

                    case EnmContentType.UVU_VIDEO_VNDUVVUMP4:
                        return "video/vnd.uvvu.mp4";

                    case EnmContentType.UVV_VIDEO_VNDDECEVIDEO:
                        return "video/vnd.dece.video";

                    case EnmContentType.VCD_APPLICATION_X_CDLINK:
                        return "application/x-cdlink";

                    case EnmContentType.VCF_TEXT_X_VCARD:
                        return "text/x-vcard";

                    case EnmContentType.VCG_APPLICATION_VNDGROOVE_VCARD:
                        return "application/vnd.groove-vcard";

                    case EnmContentType.VCS_TEXT_X_VCALENDAR:
                        return "text/x-vcalendar";

                    case EnmContentType.VCX_APPLICATION_VNDVCX:
                        return "application/vnd.vcx";

                    case EnmContentType.VIS_APPLICATION_VNDVISIONARY:
                        return "application/vnd.visionary";

                    case EnmContentType.VIV_VIDEO_VNDVIVO:
                        return "video/vnd.vivo";

                    case EnmContentType.VSD_APPLICATION_VNDVISIO:
                        return "application/vnd.visio";

                    case EnmContentType.VSF_APPLICATION_VNDVSF:
                        return "application/vnd.vsf";

                    case EnmContentType.VTU_MODEL_VNDVTU:
                        return "model/vnd.vtu";

                    case EnmContentType.VXML_APPLICATION_VOICEXML_XML:
                        return "application/voicexml+xml";

                    case EnmContentType.WAD_APPLICATION_X_DOOM:
                        return "application/x-doom";

                    case EnmContentType.WAV_AUDIO_X_WAV:
                        return "audio/x-wav";

                    case EnmContentType.WAX_AUDIO_X_MS_WAX:
                        return "audio/x-ms-wax";

                    case EnmContentType.WBMP_IMAGE_VNDWAPWBMP:
                        return "image/vnd.wap.wbmp";

                    case EnmContentType.WBS_APPLICATION_VNDCRITICALTOOLSWBS_XML:
                        return "application/vnd.criticaltools.wbs+xml";

                    case EnmContentType.WBXML_APPLICATION_VNDWAPWBXML:
                        return "application/vnd.wap.wbxml";

                    case EnmContentType.WEBA_AUDIO_WEBM:
                        return "audio/webm";

                    case EnmContentType.WEBM_VIDEO_WEBM:
                        return "video/webm";

                    case EnmContentType.WEBP_IMAGE_WEBP:
                        return "image/webp";

                    case EnmContentType.WG_APPLICATION_VNDPMIWIDGET:
                        return "application/vnd.pmi.widget";

                    case EnmContentType.WGT_APPLICATION_WIDGET:
                        return "application/widget";

                    case EnmContentType.WM_VIDEO_X_MS_WM:
                        return "video/x-ms-wm";

                    case EnmContentType.WMA_AUDIO_X_MS_WMA:
                        return "audio/x-ms-wma";

                    case EnmContentType.WMD_APPLICATION_X_MS_WMD:
                        return "application/x-ms-wmd";

                    case EnmContentType.WMF_APPLICATION_X_MSMETAFILE:
                        return "application/x-msmetafile";

                    case EnmContentType.WML_TEXT_VNDWAPWML:
                        return "text/vnd.wap.wml";

                    case EnmContentType.WMLC_APPLICATION_VNDWAPWMLC:
                        return "application/vnd.wap.wmlc";

                    case EnmContentType.WMLS_TEXT_VNDWAPWMLSCRIPT:
                        return "text/vnd.wap.wmlscript";

                    case EnmContentType.WMLSC_APPLICATION_VNDWAPWMLSCRIPTC:
                        return "application/vnd.wap.wmlscriptc";

                    case EnmContentType.WMV_VIDEO_X_MS_WMV:
                        return "video/x-ms-wmv";

                    case EnmContentType.WMX_VIDEO_X_MS_WMX:
                        return "video/x-ms-wmx";

                    case EnmContentType.WMZ_APPLICATION_X_MS_WMZ:
                        return "application/x-ms-wmz";

                    case EnmContentType.WOFF_APPLICATION_X_FONT_WOFF:
                        return "application/x-font-woff";

                    case EnmContentType.WPD_APPLICATION_VNDWORDPERFECT:
                        return "application/vnd.wordperfect";

                    case EnmContentType.WPL_APPLICATION_VNDMS_WPL:
                        return "application/vnd.ms-wpl";

                    case EnmContentType.WPS_APPLICATION_VNDMS_WORKS:
                        return "application/vnd.ms-works";

                    case EnmContentType.WQD_APPLICATION_VNDWQD:
                        return "application/vnd.wqd";

                    case EnmContentType.WRI_APPLICATION_X_MSWRITE:
                        return "application/x-mswrite";

                    case EnmContentType.WRL_MODEL_VRML:
                        return "model/vrml";

                    case EnmContentType.WSDL_APPLICATION_WSDL_XML:
                        return "application/wsdl+xml";

                    case EnmContentType.WSPOLICY_APPLICATION_WSPOLICY_XML:
                        return "application/wspolicy+xml";

                    case EnmContentType.WTB_APPLICATION_VNDWEBTURBO:
                        return "application/vnd.webturbo";

                    case EnmContentType.WVX_VIDEO_X_MS_WVX:
                        return "video/x-ms-wvx";

                    case EnmContentType.X3D_APPLICATION_VNDHZN_3D_CROSSWORD:
                        return "application/vnd.hzn-3d-crossword";

                    case EnmContentType.XAP_APPLICATION_X_SILVERLIGHT_APP:
                        return "application/x-silverlight-app";

                    case EnmContentType.XAR_APPLICATION_VNDXARA:
                        return "application/vnd.xara";

                    case EnmContentType.XBAP_APPLICATION_X_MS_XBAP:
                        return "application/x-ms-xbap";

                    case EnmContentType.XBD_APPLICATION_VNDFUJIXEROXDOCUWORKSBINDER:
                        return "application/vnd.fujixerox.docuworks.binder";

                    case EnmContentType.XBM_IMAGE_X_XBITMAP:
                        return "image/x-xbitmap";

                    case EnmContentType.XDF_APPLICATION_XCAP_DIFF_XML:
                        return "application/xcap-diff+xml";

                    case EnmContentType.XDM_APPLICATION_VNDSYNCMLDM_XML:
                        return "application/vnd.syncml.dm+xml";

                    case EnmContentType.XDP_APPLICATION_VNDADOBEXDP_XML:
                        return "application/vnd.adobe.xdp+xml";

                    case EnmContentType.XDSSC_APPLICATION_DSSC_XML:
                        return "application/dssc+xml";

                    case EnmContentType.XDW_APPLICATION_VNDFUJIXEROXDOCUWORKS:
                        return "application/vnd.fujixerox.docuworks";

                    case EnmContentType.XENC_APPLICATION_XENC_XML:
                        return "application/xenc+xml";

                    case EnmContentType.XER_APPLICATION_PATCH_OPS_ERROR_XML:
                        return "application/patch-ops-error+xml";

                    case EnmContentType.XFDF_APPLICATION_VNDADOBEXFDF:
                        return "application/vnd.adobe.xfdf";

                    case EnmContentType.XFDL_APPLICATION_VNDXFDL:
                        return "application/vnd.xfdl";

                    case EnmContentType.XHTML_APPLICATION_XHTML_XML:
                        return "application/xhtml+xml";

                    case EnmContentType.XIF_IMAGE_VNDXIFF:
                        return "image/vnd.xiff";

                    case EnmContentType.XLAM_APPLICATION_VNDMS_EXCELADDINMACROENABLED12:
                        return "application/vnd.ms-excel.addin.macroenabled.12";

                    case EnmContentType.XLS_APPLICATION_VNDMS_EXCEL:
                        return "application/vnd.ms-excel";

                    case EnmContentType.XLSB_APPLICATION_VNDMS_EXCELSHEETBINARYMACROENABLED12:
                        return "application/vnd.ms-excel.sheet.binary.macroenabled.12";

                    case EnmContentType.XLSM_APPLICATION_VNDMS_EXCELSHEETMACROENABLED12:
                        return "application/vnd.ms-excel.sheet.macroenabled.12";

                    case EnmContentType.XLSX_APPLICATION_VNDOPENXMLFORMATS_OFFICEDOCUMENTSPREADSHEETMLSHEET:
                        return "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";

                    case EnmContentType.XLTM_APPLICATION_VNDMS_EXCELTEMPLATEMACROENABLED12:
                        return "application/vnd.ms-excel.template.macroenabled.12";

                    case EnmContentType.XLTX_APPLICATION_VNDOPENXMLFORMATS_OFFICEDOCUMENTSPREADSHEETMLTEMPLATE:
                        return "application/vnd.openxmlformats-officedocument.spreadsheetml.template";

                    case EnmContentType.XML_APPLICATION_XML:
                        return "application/xml";

                    case EnmContentType.XO_APPLICATION_VNDOLPC_SUGAR:
                        return "application/vnd.olpc-sugar";

                    case EnmContentType.XOP_APPLICATION_XOP_XML:
                        return "application/xop+xml";

                    case EnmContentType.XPI_APPLICATION_X_XPINSTALL:
                        return "application/x-xpinstall";

                    case EnmContentType.XPM_IMAGE_X_XPIXMAP:
                        return "image/x-xpixmap";

                    case EnmContentType.XPR_APPLICATION_VNDIS_XPR:
                        return "application/vnd.is-xpr";

                    case EnmContentType.XPS_APPLICATION_VNDMS_XPSDOCUMENT:
                        return "application/vnd.ms-xpsdocument";

                    case EnmContentType.XPW_APPLICATION_VNDINTERCONFORMNET:
                        return "application/vnd.intercon.formnet";

                    case EnmContentType.XSLT_APPLICATION_XSLT_XML:
                        return "application/xslt+xml";

                    case EnmContentType.XSM_APPLICATION_VNDSYNCML_XML:
                        return "application/vnd.syncml+xml";

                    case EnmContentType.XSPF_APPLICATION_XSPF_XML:
                        return "application/xspf+xml";

                    case EnmContentType.XUL_APPLICATION_VNDMOZILLAXUL_XML:
                        return "application/vnd.mozilla.xul+xml";

                    case EnmContentType.XWD_IMAGE_X_XWINDOWDUMP:
                        return "image/x-xwindowdump";

                    case EnmContentType.XYZ_CHEMICAL_X_XYZ:
                        return "chemical/x-xyz";

                    case EnmContentType.YAML_TEXT_YAML:
                        return "text/yaml";

                    case EnmContentType.YANG_APPLICATION_YANG:
                        return "application/yang";

                    case EnmContentType.YIN_APPLICATION_YIN_XML:
                        return "application/yin+xml";

                    case EnmContentType.ZAZ_APPLICATION_VNDZZAZZDECK_XML:
                        return "application/vnd.zzazz.deck+xml";

                    case EnmContentType.ZIP_APPLICATION_ZIP:
                        return "application/zip";

                    case EnmContentType.ZIR_APPLICATION_VNDZUL:
                        return "application/vnd.zul";

                    case EnmContentType.ZMM_APPLICATION_VNDHANDHELD_ENTERTAINMENT_XML:
                        return "application/vnd.handheld-entertainment+xml";

                    case EnmContentType.N_A_APPLICATION_ANDREW_INSET:
                        return "application/andrew-inset";

                    case EnmContentType.APPLICATION_PGP_ENCRYPTED:
                        return "application/pgp-encrypted";

                    default:
                        return "text/plain";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }

            #endregion Ações
        }

        private string getStrEnmEncoding()
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                switch (this.enmEncoding)
                {
                    case EnmEncoding._8859:
                        return "8859";

                    case EnmEncoding.ANSI:
                        return "ANSI";

                    case EnmEncoding.ASCII:
                        return "ASCII";

                    case EnmEncoding.NUMB:
                        return "Numb";

                    case EnmEncoding.UTF_16:
                        return "UTF-16";

                    default:
                        return "UTF-8";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }

            #endregion Ações
        }

        private string getStrHeader()
        {
            #region Variáveis

            string strHeader;

            #endregion Variáveis

            #region Ações

            try
            {
                this.addCookieSessaoId();

                strHeader = string.Empty;

                strHeader += this.getStrHeaderStatus();
                strHeader += Environment.NewLine;
                strHeader += this.getStrHeaderData("Date", DateTime.Now);
                strHeader += Environment.NewLine;
                strHeader += this.getStrServer();
                strHeader += Environment.NewLine;
                strHeader += this.getStrSetCookie();
                strHeader += this.getStrHeaderData("Last-Modified", this.dttUltimaModificacao);
                strHeader += Environment.NewLine;
                strHeader += "Connection: keep-alive";
                strHeader += Environment.NewLine;
                strHeader += this.getStrHeaderContentType();
                strHeader += Environment.NewLine;
                strHeader += this.getStrHeaderContentLength();

                return strHeader;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }

            #endregion Ações
        }

        private string getStrHeaderContentLength()
        {
            #region Variáveis

            string strResultado;

            #endregion Variáveis

            #region Ações

            try
            {
                if (this.mmsConteudo.Length < 1)
                {
                    return null;
                }

                strResultado = "Content-Length: _content_length";
                strResultado = strResultado.Replace("_content_length", this.mmsConteudo.Length.ToString());

                return strResultado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }

            #endregion Ações
        }

        private string getStrHeaderContentType()
        {
            #region Variáveis

            string strResultado;

            #endregion Variáveis

            #region Ações

            try
            {
                strResultado = "Content-Type: _content_type; charset=_char_set";

                strResultado = strResultado.Replace("_content_type", this.getStrEnmContentType());
                strResultado = strResultado.Replace("_char_set", this.getStrEnmEncoding());

                return strResultado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }

            #endregion Ações
        }

        private string getStrHeaderData(string strFieldNome, DateTime dtt)
        {
            #region Variáveis

            string strResultado;

            #endregion Variáveis

            #region Ações

            try
            {
                if (string.IsNullOrEmpty(strFieldNome))
                {
                    return null;
                }

                strResultado = "_str_date_nome: _date_valor";

                strResultado = strResultado.Replace("_str_date_nome", strFieldNome);
                strResultado = strResultado.Replace("_date_valor", dtt.ToUniversalTime().ToString("r"));

                return strResultado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }

            #endregion Ações
        }

        private string getStrHeaderStatus()
        {
            #region Variáveis

            string strResultado;

            #endregion Variáveis

            #region Ações

            try
            {
                strResultado = "HTTP/1.1 _status_code";

                if (this.dttUltimaModificacao.ToString().Equals(this.objSolicitacao.dttUltimaModificacao.ToString()))
                {
                    this.intStatus = 304;
                    return strResultado.Replace("_status_code", "304 Not Modified");
                }

                switch (this.intStatus)
                {
                    case 404:
                        return strResultado.Replace("_status_code", "404 Not Found");

                    default:
                        this.intStatus = 200;
                        return strResultado.Replace("_status_code", "200 OK");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }

            #endregion Ações
        }

        private string getStrServer()
        {
            #region Variáveis

            string strResultado;

            #endregion Variáveis

            #region Ações

            try
            {
                strResultado = "Server: _server_nome";
                strResultado = strResultado.Replace("_server_nome", AppWeb.i.strNomeExibicao);

                return strResultado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }

            #endregion Ações
        }

        private string getStrSetCookie()
        {
            #region Variáveis

            string strResultado;

            #endregion Variáveis

            #region Ações

            try
            {
                strResultado = "";

                foreach (Cookie objCookie in this.lstObjCookie)
                {
                    if (objCookie == null)
                    {
                        continue;
                    }

                    strResultado += objCookie.getStrFormatado();
                }

                return strResultado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }

            #endregion Ações
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}