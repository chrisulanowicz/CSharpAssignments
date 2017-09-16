using System;
using System.ComponentModel.DataAnnotations;

namespace WeddingPlanner.Models
{

    public enum StateList
    {
        [Display(Name="Alabama")]
        AL,
        
        [Display(Name="Alaska")]
        AK,
        
        [Display(Name="Arkansas")]
        AR,
        
        [Display(Name="Arizona")]
        AZ,
        
        [Display(Name="California")]
        CA,
        
        [Display(Name="Colorado")]
        CO,
        
        [Display(Name="Connecticut")]
        CT,
        
        [Display(Name="D.C.")]
        DC,
        
        [Display(Name="Delaware")]
        DE,
        
        [Display(Name="Florida")]
        FL,
        
        [Display(Name="Georgia")]
        GA,
        
        [Display(Name="Hawaii")]
        HI,
        
        [Display(Name="Iowa")]
        IA,
        
        [Display(Name="Idaho")]
        ID,
        
        [Display(Name="Illinois")]
        IL,
        
        [Display(Name="Indiana")]
        IN,
        
        [Display(Name="Kansas")]
        KS,
        
        [Display(Name="Kentucky")]
        KY,
        
        [Display(Name="Louisiana")]
        LA,
        
        [Display(Name="Massachusetts")]
        MA,
        
        [Display(Name="Maryland")]
        MD,
        
        [Display(Name="Maine")]
        ME,
        
        [Display(Name="Michigan")]
        MI,
        
        [Display(Name="Minnesota")]
        MN,
        
        [Display(Name="Missouri")]
        MO,
        
        [Display(Name="Mississippi")]
        MS,
        
        [Display(Name="Montana")]
        MT,
        
        [Display(Name="North Carolina")]
        NC,

        [Display(Name="North Dakota")]
        ND,

        [Display(Name="Nebraska")]
        NE,

        [Display(Name="New Hampshire")]
        NH,

        [Display(Name="New Jersey")]
        NJ,

        [Display(Name="New Mexico")]
        NM,

        [Display(Name="Nevada")]
        NV,

        [Display(Name="New York")]
        NY,

        [Display(Name="Oklahoma")]
        OK,

        [Display(Name="Ohio")]
        OH,

        [Display(Name="Oregon")]
        OR,

        [Display(Name="Pennsylvania")]
        PA,

        [Display(Name="Rhode Island")]
        RI,

        [Display(Name="South Carolina")]
        SC,

        [Display(Name="South Dakota")]
        SD,

        [Display(Name="Tennessee")]
        TN,

        [Display(Name="Texas")]
        TX,

        [Display(Name="Utah")]
        UT,

        [Display(Name="Virginia")]
        VA,

        [Display(Name="Vermont")]
        VT,

        [Display(Name="Washington")]
        WA,

        [Display(Name="Wisconsin")]
        WI,

        [Display(Name="West Virginia")]
        WV,

        [Display(Name="Wyoming")]
        WY
    }

    public class WeddingViewModel : BaseEntity
    {

        [Required(ErrorMessage="Need 2 people to get married")]
        [Display(Name="Bride / Groom")]
        public string Partner1 { get; set; }

        [Required(ErrorMessage="Need 2 people to get married")]
        [Display(Name="Bride / Groom")]
        public string Partner2 { get; set; }

        [Required(ErrorMessage="Can't plan a wedding without a date")]
        [FutureDate]
        [DataType(DataType.Date)]
        [Display(Name="Date of Wedding")]
        public DateTime WeddingDate { get; set; }

        [Required(ErrorMessage="Gotta know where to go")]
        [Display(Name="Address 1")]
        public string Address1 { get; set; }
        
        [Display(Name="Address 2")]
        public string Address2 { get; set; }

        [Required(ErrorMessage="There's a million Main Streets, need to know what city it's in")]
        public string City { get; set; }

        [Required(ErrorMessage="Towns aren't unique, need to know what state they're in")]
        public StateList State { get; set; }

        [Required(ErrorMessage="It'll be easier for guests GPS if you provide a Zip code, SO DO IT!")]
        // [RegularExpression("/^[0-9]{5}([- /]?[0-9]{4})?$/", ErrorMessage="Please enter a 5 digit or 5+4 Zip Code")]
        [RegularExpression("[0-9]{5}", ErrorMessage="Please enter a 5 digit Zip Code")]

        public int Zip { get; set; }

    }

}