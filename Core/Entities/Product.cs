﻿namespace Core.Entities;

public class Product :BaseEntity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public string PictureUrl { get; set; }
    public ProductType productType { get; set; }
    public int ProductTypeId { get; set; }
    public ProductBrand productBrand { get; set; }
    public int ProductBrandId { get; set;
    }

}
