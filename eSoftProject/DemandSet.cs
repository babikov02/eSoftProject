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
    
    public partial class DemandSet
    {
        public int Id { get; set; }
        public int IdAgent { get; set; }
        public int IdClient { get; set; }
        public Nullable<int> Type { get; set; }
        public Nullable<long> MinPrice { get; set; }
        public Nullable<long> MaxPrice { get; set; }
        public Nullable<double> MinArea { get; set; }
        public Nullable<double> MaxArea { get; set; }
        public Nullable<int> MinRooms { get; set; }
        public Nullable<int> MaxRooms { get; set; }
        public Nullable<int> MinFloor { get; set; }
        public Nullable<int> MaxFloor { get; set; }
        public Nullable<int> MinFloors { get; set; }
        public Nullable<int> MaxFloors { get; set; }
    
        public virtual AgentSet AgentSet { get; set; }
        public virtual ClientSet ClientSet { get; set; }
    }
}
