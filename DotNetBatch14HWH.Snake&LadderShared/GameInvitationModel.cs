using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetBatch14HWH.Snake_LadderShared
{
    [Table("GameInvitation")]
    public class GameInvitationModel
    {
        [Key]
        public int? GameInvitationID { get; set; }
        public int GameId { get; set; }
        public int? InvitorId { get; set; }
        public int? InviteeId { get; set; }
    }
}
