﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace ru.org.openam.sdk.auth
{
    class AuthException:Exception
    {
        public String message;
        public String errorCode;
        public String templateName;

        //<Exception message="invalid password"  errorCode="103" templateName="login_failed_template.jsp"></Exception>
        public AuthException(XmlNode element)
            : base()
        {
            foreach (XmlAttribute attr in element.Attributes)
                if (attr.LocalName.Equals("message"))
                    message = attr.Value;
                else if (attr.LocalName.Equals("errorCode"))
                    errorCode = attr.Value;
                else if (attr.LocalName.Equals("templateName"))
                    templateName = attr.Value;
                else
                    throw new Exception("unknown attribute type=" + attr.LocalName);
        }
    }
}