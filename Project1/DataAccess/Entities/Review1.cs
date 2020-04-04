﻿using System;
using System.Collections.Generic;

namespace DataAccess.Entities
{
    public partial class Review1
    {
        public int Id { get; set; }
        public int RestaurantId { get; set; }
        public string ReviewerName { get; set; }
        public int Score { get; set; }
        public string Text { get; set; }

        public virtual Restaurant1 Restaurant { get; set; }
    }
}