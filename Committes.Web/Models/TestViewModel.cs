using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Committes.Web.Models
{
    public class TestViewModel
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public DateTime BirthDate { get; set; }

        [DataType(DataType.MultilineText)]
        public string About { get; set; }
    }
}