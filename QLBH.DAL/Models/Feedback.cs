using System;
using System.Collections.Generic;

#nullable disable

namespace QLBH.DAL.Models
{
    public partial class Feedback
    {
        public int FeedbackId { get; set; }
        public DateTime? FeedbackDate { get; set; }
        public string FeedbackDetail { get; set; }
        public int UserId { get; set; }
        public int ProductId { get; set; }

        public virtual Product Product { get; set; }
    }
}
