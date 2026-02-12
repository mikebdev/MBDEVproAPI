using System;
using System.Collections.Generic;
using System.Text;

namespace MBDEVproAPI.Common.ViewModels
{

    public class SaveViewModel
    {
        /// <summary>
        /// default constructor
        /// </summary>
        public SaveViewModel()
        {
            IsSaved = true;
        }

        /// <summary>
        /// default constructor
        /// <paramref name="refID">Ref ID of saved Record</paramref>
        /// </summary>
        public SaveViewModel(int? refID = null)
        {
            IsSaved = true;
            RefID = refID;
        }

        /// <summary>
        /// Error Constructor
        /// </summary>
        /// <param name="ErrMasg">Error Message</param>
        public SaveViewModel(string errorMessage)
        {
            IsSaved = false;
            ErrorMessage = errorMessage;
        }

        /// <summary>
        /// Is record Saved
        /// </summary>
        public bool IsSaved { get; set; }

        /// <summary>
        /// Error Message
        /// </summary>
        public string ErrorMessage { get; set; }

        /// <summary>
        /// Saved Ref ID of Newly added record.
        /// </summary>
        public int? RefID { get; set; }
    }

}
