using System;
using System.ComponentModel.DataAnnotations;
using OneTwoOne.Infrastructure.Models;
using OneTwoOne.Module.Core.Models;

namespace OneTwoOne.Module.Reviews.Models
{
    public class Reply : EntityBase
    {
        public Reply()
        {
            Status = ReplyStatus.Pending;
            CreatedOn = DateTimeOffset.Now;
        }

        public long ReviewId { get; set; }

        public Review Review { get; set; }

        public long UserId { get; set; }

        public User User { get; set; }

        public string Comment { get; set; }

        [StringLength(450)]
        public string ReplierName { get; set; }

        public ReplyStatus Status { get; set; }

        public DateTimeOffset CreatedOn { get; set; }
    }
}
