using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Constants
{

    public static class ValidationErrorCodes
    {
        //Model Validations
        public static int Mandatory => 1001;
        public static int Required => 1001;
        public static int NotIdentical => 1002;
        public static int NotCorrectLength => 1003;
        public static int CanNotDelete => 1004;
        //Syntax Validation
        public static int MustBeInEnglish => 2001;
        public static int NotValidEmailAddress => 2002;
        public static int NotAllowedExtension => 2003;
        public static int NotValidFormat => 2003;
        public static int NotValidDimensions => 2004;
        public static int NotValidDataType => 2005;
        //Performance
        public static int Unauthorized => 9100;
        public static int Forbidden => 9101;

        //Existing
        public static int NotExisting => 3001;
    }
}
