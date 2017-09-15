using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Committes.WebApi.Models
{
    public class LabViewModel
    {
        public LabViewModel()
        {
            StudentTypes = new List<StudenTypeVM>();
        }

        public int Id { get; set; }

        public int CommitteeId { get; set; }
        public string Title { get; set; }
        public string SchoolName { get; set; }
        public string StudentCount { get; set; }
        public string StudentType
        {
            get {
                return JsonConvert.SerializeObject(StudentTypes, Formatting.None, new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() });
            }
            set {
                StudentTypes.Clear();
                StudentTypes = JsonConvert.DeserializeObject<List<StudenTypeVM>>(value, new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() });
            }
        }
        public IList<StudenTypeVM> StudentTypes { get; set; }
        public string ExamDate { get; set; }
        public string EvalDate { get; set; }
        public string WorkShopCount { get; set; }
        public string WorkShopCapacity { get; set; }
        public string GroupsCount { get; set; }

    }

    public class StudenTypeVM
    {
        public string Title { get; set; }

        public int? Count { get; set; }
    }

}