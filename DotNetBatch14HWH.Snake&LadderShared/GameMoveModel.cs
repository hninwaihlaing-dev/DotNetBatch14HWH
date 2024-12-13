using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetBatch14HWH.SnakeLadderShared
{
    [Table("GameMoves")]
    public class GameMoveModel
    {
        [Key]
        public int MoveID { get; set; }
        public int GameID { get; set; }    
        public int PlayerID { get; set; }
        public int FromCell { get; set; }
        public int ToCell { get; set; }
        public DateTime MoveDate { get; set; }
    }
}
