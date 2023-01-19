using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDB.AspNetCore.Data.SampleModel
{
    public  class FileUpload
    {
        public IFormFile file { get; set; }
        public string Employee { get; set; }
    }
}
