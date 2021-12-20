using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WatchesShop.Data.Model
{
    public class Order
    {
        [BindNever]
        public int id { get; set; }
        [Display(Name = "Имя")]
        [StringLength(25)]
        [Required(ErrorMessage = "Длинна имени не менее 2-ух символов")]
        public string name { get; set; }
        public string delivery { get; set; }
        public string payment { get; set; }
        [Display(Name = "Адрес")]
        [StringLength(35)]
        [Required(ErrorMessage = "Длинна адреса не менее 10 символов")]
        public string adress { get; set; }
        [Display(Name = "Номер телефона")]
        [DataType(DataType.PhoneNumber)]
        [StringLength(20)]
        [Required(ErrorMessage = "Длинна номера не менее 10 символов")]
        public string phone { get; set; }
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        [StringLength(25)]
        [Required(ErrorMessage = "Длинна email не менее 7 символов")]
        public string email { get; set; }
        [BindNever]
        [ScaffoldColumn(false)]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        public DateTime dateTime { get; set; }
    }
}
