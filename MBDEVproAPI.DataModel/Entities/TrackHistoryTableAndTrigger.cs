namespace MBDEVproAPI.DataModel.Entities
{
    public class TrackHistoryTableAndTrigger
    {
        /// <summary>
        /// Created By for entities
        /// </summary>
        [StringLength(50), Required]
        public string CreatedBy { get; set; }

        /// <summary>
        /// Created Date for entities
        /// </summary>
        [Required]
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// Modified By for entities
        /// </summary>
        [StringLength(50), Required]
        public string ModifiedBy { get; set; }

        /// <summary>
        /// Modified Date for entities
        /// </summary>
        [Required]
        public DateTime ModifiedDate { get; set; }
    }
}
