using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebBanHang.Models
{
    public partial class ProductMasterData
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Mã sản phẩm")]
        public string Name { get; set; }
        
        [Display(Name = "Tên sản phẩm")]
        public string Avartar { get; set; }
        [Display(Name = "Hình ảnh")]

        public Nullable<int> CategoryId { get; set; }
        [Display(Name = "Danh mục sản phẩm")]

        public string ShortDescription { get; set; }
        [Display(Name = "Mô tả ngắn")]

        public string fullDescription { get; set; }
        [Display(Name = "Mô tải đầy đủ ")]

        public Nullable<double> Price { get; set; }
        [Display(Name = "Giá gốc")]

        public Nullable<double> PriceDiscount { get; set; }
        [Display(Name = "Giá khuyến mãi")]

        public Nullable<int> TypeId { get; set; }
        [Display(Name = "Loại sản phẩm")]

        public string Slug { get; set; }
        

        public Nullable<int> BrandId { get; set; }
        [Display(Name = "Thương hiệu")]
        public Nullable<bool> Deleted { get; set; }
        public Nullable<bool> ShowOnHomePage { get; set; }
        public Nullable<int> DisplayOrder { get; set; }
        public Nullable<System.DateTime> CreatedOnUtc { get; set; }
        public Nullable<System.DateTime> UpdatedOnUtc { get; set; }
        
    }
}