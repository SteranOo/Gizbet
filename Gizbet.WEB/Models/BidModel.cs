using System;
using System.ComponentModel;

namespace Gizbet.WEB.Models
{
    public class BidModel
    {
        [DisplayName("Сумма")]
        public decimal Amount { get; set; }

        [DisplayName("Время ставки")]
        public DateTime TimeOfBid { get; set; }

        [DisplayName("Пользователь")]
        public ApplicationUserPublicModel ApplicationUser { get; set; }

        [DisplayName("Лот")]
        public LotPublicModel Lot { get; set; }

        public bool IsWin { get; set; }

        public bool IsTop { get; set; }
    }
}