using System;
using System.Collections.Generic;
using System.Text;

namespace NengaJouSimple.Data.Web.Entities
{
    public class ZipCloudRoot
    {
        private static readonly int SuccessStausCode = 200;

        public string Message { get; set; }

        public ZipCloudAddress[] Results { get; set; }

        public int Status { get; set; }

        public bool IsSuccess => Status == SuccessStausCode;
    }
}