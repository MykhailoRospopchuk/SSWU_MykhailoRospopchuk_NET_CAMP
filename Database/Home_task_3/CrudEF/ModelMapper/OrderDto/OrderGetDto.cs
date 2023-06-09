﻿using CrudEF.Model;
using CrudEF.ModelMapper.CustomerDto;
using System.ComponentModel.DataAnnotations;

namespace CrudEF.ModelMapper.OrderDto
{
    public class OrderGetDto : BaseDto
    {
        [Required(ErrorMessage = "Order Date is required")]
        public string OrderDate { get; set; } = null!;
        [Required(ErrorMessage = "Delivery Id is required")]
        public int DeliveryId { get; set; }

        public virtual CustomerGetDto Customer { get; set; } = null!;
    }
}
