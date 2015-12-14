using System;

namespace Komsky.Web.Models
{
    public class CaseComment
    {
        public Int32 Id { get; set; }
        public Case Case { get; set; }
        public DateTime DateCommented { get; set; }
        public ApplicationUser CommentOwner { get; set; }
        public String Comment { get; set; }
    }
}