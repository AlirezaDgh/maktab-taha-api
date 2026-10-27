using MaktabTaha.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaktabTaha.Domain.Entites
{
    public class Tahghigh : BaseEntity<int>
    {
        // شماره تحقیق همان Id است
        // تاریخ تحقیق
        public DateTime TahghighDate { get; set; } = DateTime.Now;

        // شماره پیش تحقیق
        public int MoshaverehId { get; set; }
        public Moshavereh Moshavereh { get; set; }

        public string ClientDescription { get; set; }
        public int FirstMohagheghId { get; set; }
        public Donor FirstMohaghegh { get; set; }
        public int SecondMohagheghId { get; set; }
        public Donor SecondMohaghegh { get; set; }

        public MohagheghIdea MohagheghIdea { get; set; }
        public string MohagheghDescription { get; set; }
        public List<Attachments> Attachments { get; set; }

    }
    
    public enum MohagheghIdea
    {
        // تایید و عدم تایید
        NotApprove = 0,
        Approve = 1
        
    }
}
