using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MST.Models
{
    public class VAlbums
    {

        public int alABID { get; set; }

        [Display(Name = "อัลบัมที่")]
        [Required(ErrorMessage = "กรุณาป้อนข้อมูล")]
        public int alAlbumsID { get; set; }

        [Display(Name = "ศิลปิน")]
        public Nullable<int> alBandID { get; set; }

        [Display(Name = "อัลบัม")]
        [Required(ErrorMessage = "กรุณาป้อนข้อมูล")]
        public string alAlbumsName { get; set; }

        [Display(Name = "ปกอัลบัม")]
        public byte[] alPictureAlbums { get; set; }







    }
    [MetadataType(typeof(VAlbums))]
    public partial class Albums { }
    ////////////////////////////////////////////////////////////////////////////////////////////
    


    public class VAuthor
    {


        public int atAuthorID { get; set; }

        [Display(Name = "ชื่อผู้เเต่ง")]
        [Required(ErrorMessage = "กรุณาป้อนข้อมูล")]
        public string atAuthorName { get; set; }

        [Display(Name = "ประวัติผู้เเต่ง")]
        [Required(ErrorMessage = "กรุณาป้อนข้อมูล")]
        public string atProfile { get; set; }

        [Display(Name = "รูป")]
        [Required(ErrorMessage = "กรุณาป้อนข้อมูล")]
        public byte[] atPicture { get; set; }
    }
    [MetadataType(typeof(VAuthor))]
    public partial class Author { }
    /////////////////////////////////////////////////////////////////////////////////////////////////////
    ///

    public class VBand
    {

        public int bBandID { get; set; }

        [Display(Name = "ศิลปิน")]
        [Required(ErrorMessage = "กรุณาป้อนข้อมูล")]
        public string bBandName { get; set; }

        [Display(Name = "สมาชิก")]
        public Nullable<int> bArtID { get; set; }

        [Display(Name = "สังกัด")]
        public Nullable<int> bRecordID { get; set; }

        [Display(Name = "ประเภทศิลปิน")]
        public Nullable<int> bBTypeID { get; set; }

        [Display(Name = "สถานะศิลปิน")]
        public string bStatus { get; set; }

        [Display(Name = "รายละเอียด")]
        public string bBandProfile { get; set; }

        [Display(Name = "รูปศิลปิน")]
        public byte[] bPicturebands { get; set; }

    }
    [MetadataType(typeof(VBand))]
    public partial class Band { }
    ////////////////////////////////////////////////////////////////////////////////////////////////////////
    ///

    public class VBandType
    {


        public int btBandTypeID { get; set; }

        [Display(Name = "ประเภทศิลปิน")]
        public string btNameType { get; set; }

    }
    [MetadataType(typeof(VBandType))]
    public partial class BandType { }
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////
    ///

    public class VMelody
    {


        public int mlMelodyID { get; set; }

        [Display(Name = "ผู้เเต่งทำนอง")]
        public string mlMelodyName { get; set; }

    }
    [MetadataType(typeof(VMelody))]
    public partial class Melody { }
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    ///

    public class VMusic
    {


        public int msMusicID { get; set; }

        [Display(Name = "อัลบัม")]
        public Nullable<int> msABID { get; set; }

        [Display(Name = "ชื่อเพลง")]
        [Required(ErrorMessage = "กรุณาป้อนข้อมูล")]
        public string msMusicName { get; set; }

        [Display(Name = "เนื้อเพลง")]
        public string msLyrics { get; set; }

        [Display(Name = "ผู้เเต่ง")]
        public Nullable<int> msAuthorID { get; set; }

        [Display(Name = "ทำนอง")]
        public Nullable<int> msMelodyID { get; set; }

        [Display(Name = "อัลบัม")]
        public Nullable<int> msAlbumsID { get; set; }

        [Display(Name = "ศิลปิน")]
        public Nullable<int> msBandID { get; set; }

        [Display(Name = "แนวเพลง")]
        public Nullable<int> msMStyleID { get; set; }

        [Display(Name = "ไฟล์เพลง")]
        public string msMusicUpload { get; set; }



    }
    [MetadataType(typeof(VMusic))]
    public partial class Music { }
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    ///

    public class VMusicStyle
    {


        public int mstMusicStyleID { get; set; }

        [Display(Name = "แนวเพลง")]
        public string mstStyleName { get; set; }



    }
    [MetadataType(typeof(VMusicStyle))]
    public partial class MusicStyle { }
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    ///

    public class VRecord
    {


        public int rRecordID { get; set; }

        [Display(Name = "ชื่อบริษัท")]
        public string rRecordName { get; set; }


    }
    [MetadataType(typeof(VRecord))]
    public partial class Record { }
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    ///

    public class VUserAccount
    {


        public string UserName { get; set; }


        public string UserPassword { get; set; }


    }
    [MetadataType(typeof(VUserAccount))]
    public partial class UserAccount { }
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    ///

    public class VUserType
    {


        public int TypeUserID { get; set; }


        public string TypeUserName { get; set; }
    }
    [MetadataType(typeof(VUserType))]
    public partial class UserType { }
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    ///


}

