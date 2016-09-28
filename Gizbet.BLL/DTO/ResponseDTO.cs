using System;

namespace Gizbet.BLL.DTO
{
    public class ResponseDTO
    {
        public int Id { get; set; }

        public bool IsPositive { get; set; }

        public string Text { get; set; }

        public DateTime ResponseDate { get; set; }

        public virtual ApplicationUserDTO Author { get; set; }

        public virtual ApplicationUserDTO Recipient { get; set; }
    }
}
