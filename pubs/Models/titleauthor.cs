﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace pubs.Models;

public partial class titleauthor
{
    public string au_id { get; set; }

    public string title_id { get; set; }

    public byte? au_ord { get; set; }

    public int? royaltyper { get; set; }

    public virtual authors au { get; set; }

    public virtual titles title { get; set; }
}