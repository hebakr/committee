using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Committes.WebApi.Models
{
    public class JobDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
    }

    public class RoleDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
    }

    public class SpecialityDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}