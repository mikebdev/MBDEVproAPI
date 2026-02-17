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
        [StringLength(50)]
        public string? CreatedBy { get; set; }

        /// <summary>
        /// Created Date for entities
        /// </summary>
        public DateTime? CreatedDate { get; set; }

        /// <summary>
        /// Modified By 
        /// </summary>
        [StringLength(50)]
        public string? ModifiedBy { get; set; }

        /// <summary>
        /// Modified Date
        /// </summary>
        public DateTime? ModifiedDate { get; set; }


    }
}
