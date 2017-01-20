using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VoterDemo.Models
{
    public class voterModel
    {
        public int ID { get; set; }
        [Required]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Invalid VoterID")]
        public string voter_id { get; set; }
        [Required]
        [RegularExpression("^[a-zA-Z]+$", ErrorMessage = "Invalid First Name")]
        public string firstname { get; set; }
        [Required]
        [RegularExpression("^[a-zA-Z]+$", ErrorMessage = "Invalid last Name")]
        public string lastname { get; set; }
        [Required]
        [RegularExpression("^[a-zA-Z]+$", ErrorMessage = "Invalid Middle Name")]
        public string middlename { get; set; }
        [Required]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Invalid WardId")]
        public int WardId { get; set; }
        [Required]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Invalid AreaId")]
        public string Fullname { get; set; }
        public int AreaId { get; set; }
        public bool isdeleted { get; set; }
        public List<voterModel> VoterList { get; set; }
        public string WardName { get; set; }
        public string AreaName { get; set; }
    }
}