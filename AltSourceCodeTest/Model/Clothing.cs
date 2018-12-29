using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Clothing
    {
        public Clothing(int id, CType type, CSize size, CColor color)
        {
            Id = id;
            Type = type;
            Size = size;
            Color = color;
        }

        // We should implement a mechanism for generate Id.
        // In this test, to simplify as using Id as normal property.
        public int Id { get; }
        public CType Type { get; }
        public CSize Size { get; }
        public CColor Color { get; }
    }

    public class StockInRecord
    {
        public StockInRecord(int id, int clothingId, int count, decimal price, DateTime date, int supplierId)
        {
            Id = id;
            ClothingId = clothingId;
            Count = count;
            Price = price;
            Date = date;
            SupplierId = supplierId;
        }

        public int Id { get; }
        public int ClothingId { get; }
        public int Count { get; }
        public decimal Price { get; }
        public DateTime Date { get; }
        public int SupplierId { get; }
    }

    public class StockOutRecord
    {
        public StockOutRecord(int id, int clothingId, int count, decimal price, DateTime date, int orderId)
        {
            Id = id;
            ClothingId = clothingId;
            Count = count;
            Price = price;
            Date = date;
            OrderId = orderId;
        }

        public int Id { get; }
        public int ClothingId { get; }
        public int Count { get; }
        public decimal Price { get; }
        public DateTime Date { get; }
        public int OrderId { get; }
    }

    public class CurrentStock
    {
        public CurrentStock(int clothingId, int count)
        {
            ClothingId = clothingId;
            Count = count;
        }

        public int ClothingId { get;  }
        public int Count { get; }
    }

    
}
