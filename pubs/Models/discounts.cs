﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace pubs.Models;

public partial class discounts
{
    public string discounttype { get; set; }

    public string stor_id { get; set; }

    public short? lowqty { get; set; }

    public short? highqty { get; set; }

    public decimal discount { get; set; }

    public virtual stores stor { get; set; }
}