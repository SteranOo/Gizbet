using System;
using System.Collections.Generic;

namespace Gizbet.BLL.DTO
{
    public class ApplicationUserDTO
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Patronymic { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string Role { get; set; }

        public bool EmailConfirmed { get; set; }

        public string PhoneNumber { get; set; }

        public bool PhoneNumberConfirmed { get; set; }

        public bool LockoutEnabled { get; set; }

        public DateTime? LockoutEndDateUtc { get; set; }

        public bool TwoFactorEnabled { get; set; }

        public ICollection<BidDTO> Bids { get; set; }

        public ICollection<LotDTO> Lots { get; set; }

        public ICollection<ResponseDTO> ReceivedResponses { get; set; }

        public ICollection<ResponseDTO> SentResponses { get; set; }
    }
}
