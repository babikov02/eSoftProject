//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace eSoftProject
{
    using System;
    using System.Collections.Generic;
    
    public partial class RealEstateSet
    {
        public int Id { get; set; }
        public string Address_City { get; set; }
        public string Address_Street { get; set; }
        public string Address_House { get; set; }
        public string Address_Number { get; set; }
        public Nullable<double> Coordinate_latitude { get; set; }
        public Nullable<double> Coordinate_longitude { get; set; }
        public int Type { get; set; }
        public Nullable<double> TotalArea { get; set; }
        public Nullable<int> TotalFloors { get; set; }
        public Nullable<int> Rooms { get; set; }
        public Nullable<int> Floor { get; set; }
    }
}
