using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace hotel_nn.Controller
{
    public  class validateEmail
    {
        public static bool validate(string pCorreo)
        {
            if (Regex.IsMatch(pCorreo, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                return true;
            } 
            else 
            { 
                return false; 
            }
        }
    }
}
