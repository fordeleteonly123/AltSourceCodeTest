using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UseCase.Persistance
{
    public class InMemoryDb : IPersistance
    {
        List<Clothing> clothings = new List<Clothing>();
        List<StockInRecord> stockInRecords = new List<StockInRecord>();
        List<StockOutRecord> stockOutRecords = new List<StockOutRecord>();
        List<CurrentStock> currentStocks = new List<CurrentStock>();

        public InMemoryDb()
        {
            

        }

        public void AddOrUpdateCurrentStock(int clothingId, int count)
        {
            var item = currentStocks.SingleOrDefault(r => r.ClothingId == clothingId);

            if (item == null)
            {
                currentStocks.Add(item);
            }
            else
            {
                item = new CurrentStock(clothingId, count);
            }
        }

        public int GetCurrentStock(int clothingId)
        {
            var item = currentStocks.SingleOrDefault(r => r.ClothingId == clothingId);

            if (item == null)
            {
                return -1;
            }
            else
            {
                return item.Count;
            }
        }

        public CurrentStock[] GetAllCurrentStocks()
        {
            return currentStocks.ToArray();
        }

        public bool HasItem(int Id)
        {
            return clothings.SingleOrDefault(r => r.Id == Id) != null;
        }

        public void Register(Clothing item)
        {
            clothings.Add(item);
        }

        public void StockIn(StockInRecord record)
        {
            stockInRecords.Add(record);
        }

        public void StockOut(StockOutRecord record)
        {
            stockOutRecords.Add(record);
        }
    }
}
