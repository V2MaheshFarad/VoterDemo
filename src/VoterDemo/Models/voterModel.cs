using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VoterDemo.Models
{
    public class voterModel
    {
        public int ID { get; set; }
        public string voter_id { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string middlename { get; set; }
        public int WardId { get; set; }
        public int AreaId { get; set; }
        public bool isdeleted { get; set; }
        public List<voterModel> VoterList { get; set; }
        public string WardName { get; set; }
        public string AreaName { get; set; }
    }
}