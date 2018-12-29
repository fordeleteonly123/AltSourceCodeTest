# AltSourceCodeTest

There is StoreNode as back-end service to manage clothing stock in and out.

If we want to scale up, we need to enhance StoreNode to handle a specific range Ids of Clothing Item from configuration at runtime.

Then we can deploy multiple StoreNode services. 

There is also proxy/routing service in the middle to route incoming request to appropriate StoreNode services.
