using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using System.Xml.Linq;

namespace Web.UI.Extensions
{
    public class XmlResult : ActionResult
    {
        private readonly XDocument _document;
        private readonly string _etag;

        public XmlResult(XDocument document, string etag)
        {
            _document = document;
            _etag = etag;
        }

        public override void ExecuteResult(ControllerContext context)
        {
            if (_etag != null)
                context.HttpContext.Response.AddHeader("ETag", _etag);

            context.HttpContext.Response.ContentType = "text/xml";

            using (var xmlWriter = XmlWriter.Create(context.HttpContext.Response.OutputStream))
            {
                _document.WriteTo(xmlWriter);
                xmlWriter.Flush();
            }
        }
    }
}