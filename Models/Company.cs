﻿using System.Collections.Generic;

public class Company
{
    public int Id { get; set; }
    public string Name { get; set; }

    public List<Spare> Spares { get; set; } = new List<Spare>();
}