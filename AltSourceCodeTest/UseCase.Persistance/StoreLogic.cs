using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UseCase
{
    public class StoreLogic
    {
        private static StoreLogic _storeLogic;

        IPersistance persistance;
        List<CurrentStock> currentStocks;
        // Returns:
        //      Singleton StoreLogic object with already setup.
        //
        // Exceptions:
        //     NullReferenceException:
        //     StoreLogic object does not setup correctly.        
        public static StoreLogic GetSingletonStore()
        {
            return _storeLogic ?? throw new NullReferenceException(nameof(persistance));
        }

        public static StoreLogic HardSetupSingletonStore(IPersistance persistance)
        {
            // TODO: thread lock
            // We should make sure single thread access to this function at a time.
            _storeLogic = new StoreLogic(persistance);
            return _storeLogic;
        }

        private StoreLogic(IPersistance persistance)
        {
            this.persistance = persistance ?? throw new ArgumentNullException(nameof(persistance));

            currentStocks = persistance.GetAllCurrentStocks().ToList();
        }

        public void Register(Clothing item)
        {
            if (persistance.HasItem(item.Id))
            { }
            else
            {
                persistance.Register(item);
            }
        }

        // Returns:
        //      The current count of stock item.
        //      -1 item is not stocked.
        //
        //      System.InvalidOperationException:
        //      Duplicatated item in current stock.
        public int GetCurrentStock(int Id)
        {
            return currentStocks.Where(r => r.ClothingId == Id)
                .Select(r => r.Count)
                .DefaultIfEmpty(-1)
                .SingleOrDefault();            
        }

        // Returns:
        //      The current count of stock item.
        //
        // Exceptions:
        //      ArgumentException:
        //          Invalid data - Stock-in count should be greater than 0
        //          Clothing is not registed - Clothing item should be register first
        public int RecordClothingFromSupplier(StockInRecord record)
        {
            // TODO: thread lock
            // We should make sure single thread access to this function at a time.
            if (record.Count <= 0)
            {
                throw new ArgumentException("Invalid data");
            }

            if (persistance.HasItem(record.ClothingId))
            {
                persistance.StockIn(record);

                var currentStock = currentStocks.SingleOrDefault(r => r.ClothingId == record.ClothingId);

                if (currentStock == null)
                {
                    currentStock = new CurrentStock(record.ClothingId, record.Count);

                    //Add current stock to cache;
                    currentStocks.Add(currentStock);
                }
                else
                {
                    //Update current stock in cache;
                    currentStock = new CurrentStock(record.ClothingId, currentStock.Count + record.Count);
                }

                persistance.AddOrUpdateCurrentStock(record.ClothingId, currentStock.Count);

                return currentStock.Count;
            }
            else
            {
                throw new ArgumentException("Clothing is not registed");
            }
        }

        // Returns:
        //      The current count of stock item.
        //      -1 if insufficient stock amount
        //
        // Exceptions:
        //      ArgumentException:
        //          Invalid data - Order item count should be greater than 0
        //          Clothing is not registed - Clothing item should be register first
        public int RecordSellingClothingToSupplier(StockOutRecord record)
        {
            // TODO: thread lock
            // We should make sure single thread access to this function at a time.
            if (record.Count <= 0)
            {
                throw new ArgumentException("Invalid data");
            }

            if (persistance.HasItem(record.ClothingId))
            {
                var currentStock = currentStocks.SingleOrDefault(r => r.ClothingId == record.ClothingId);

                if (currentStock == null
                    || currentStock.Count < record.Count)
                {
                    return -1;
                }
                else
                {
                    persistance.StockOut(record);

                    //Update current stock in cache;
                    currentStock = new CurrentStock(record.ClothingId, currentStock.Count - record.Count);

                    persistance.AddOrUpdateCurrentStock(record.ClothingId, currentStock.Count);
                }

                return currentStock.Count;
            }
            else
            {
                throw new ArgumentException("Clothing is not registed.");
            }
        }
    }
}
