//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Медицинская_лаборатория
{
    using System;
    using System.Collections.Generic;
    
    public partial class Orders
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Orders()
        {
            this.Orders_Services = new HashSet<Orders_Services>();
        }
    
        public int ID { get; set; }
        public int ID_Patient { get; set; }
        public string Barcode { get; set; }
        public System.DateTime Create_Date { get; set; }
        public Nullable<int> ID_Order_Status { get; set; }
        public Nullable<int> Order_Fulfillment_Days { get; set; }
    
        public virtual Statuses Statuses { get; set; }
        public virtual Patients Patients { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Orders_Services> Orders_Services { get; set; }
    }
}
