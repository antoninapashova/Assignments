﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Comments.Queries
{
    public class CommentListVm
    {
        public int commentId;
        public string Title { get; set; }
        public string CommentContent { get; set; }
        public DateTime AddedOn { get; set; }

    }
}