using DvdClub.Domain.Enumeration;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DvdClub.Domain.Entities {
    [Table("KRATHSH")]
    public class Rental {
        [Key]
        public int Id { get; set; }//Id



        [DataType(DataType.DateTime)]
        public DateTime DateRented { set; get; }

        [DataType(DataType.DateTime)]
        public DateTime ExpectedReturnDate { get; set; }

        [DataType(DataType.DateTime)]
        /*This is also the date it was canceled*/
        public DateTime? ActualReturnDate { get; set; }

        public State State { get; set; }
        public string Comments { get; set; }

        public int CopyId { get; set; }
        public /*virtual*/ Copy Copy { get; set; }//singular

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        public Rental() {

        }
        public Rental(int id/*, string userId, State state, int copyId*/) {
            this.Id = id;
            /*this.UserId = userId;
            this.State = state;
            this.CopyId = copyId;*/
        }
    }
}
