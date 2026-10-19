using System;
using System.ComponentModel.DataAnnotations;

namespace Employesmhfdev.Models;

public class LeaveApplication : ApprovalActivity
{
    public int Id { get; set; }
        [Display(Name ="Employee Name")]
        public int EmployeeId { get; set; }

        public Employee Employee { get; set; }
        
        public int NoOfDays { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        [Display(Name = "Duration Days")]
        public int DurationId { get; set; }

        public SystemCodeDetail Duration { get; set; }
        [Display(Name = "Leave Type")]
        public int LeaveTypeId { get; set; }

        public LeaveType LeaveType { get; set; }
        public string? Attachment { get; set; }
        [Display(Name = "Notes")]
        public string Description { get; set; }
        [Display(Name = "Status")]
        public int StatusId { get; set; }

        public SystemCodeDetail Status { get; set; }


}
