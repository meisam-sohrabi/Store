﻿namespace InventoryService.ApplicationContract.DTO.ProductInventory
{
    public class ProductInventoryRequestDto
    {
        public int QuantityChange { get; set; }
        public int ProductId { get; set; }
    }
}
