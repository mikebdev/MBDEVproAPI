using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MBDEVproAPI.Common.Models
{
    public class BaseModel
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
        /// Modified By 
        /// </summary>
        [StringLength(50), Required]
        public string ModifiedBy { get; set; }

        /// <summary>
        /// Modified Date
        /// </summary>
        [Required]
        public DateTime ModifiedDate { get; set; }


    }
}
