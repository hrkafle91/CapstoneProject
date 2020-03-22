using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Capstone.Web.Helpers
{
    /// <summary>
    /// A helper clas that helps in creating various passcodes
    /// </summary>
    public class PasscodeHelper
    {  
        /// <summary>
        /// Method to create an integer passcode
        /// </summary>
        /// <param name="length"></param>
        /// <returns></returns>
        public int GetPasscode(int length = 4)
        {
            Random random = new Random();
            return random.Next(1000, 9999);
        }
    }
}