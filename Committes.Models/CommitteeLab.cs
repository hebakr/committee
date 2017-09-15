﻿using Committes.Infrastructure.Core;
using System.ComponentModel.DataAnnotations;

namespace Committes.Models
{
    public partial class CommitteeLab : EntityBase
    {
        [MaxLength(150)]
        public string Title { get; set; }

        [MaxLength(500)]
        public string SchoolName { get; set; }

        [MaxLength(10)]
        public string StudentCount { get; set; }

        [MaxLength(250)]
        public string StudentType { get; set; }

        [MaxLength(50)]
        public string ExamDate { get; set; }

        [MaxLength(50)]
        public string EvalDate { get; set; }
    }
}