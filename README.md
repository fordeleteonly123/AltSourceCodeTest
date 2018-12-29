# AltSourceCodeTest

1. In this sample, I tried the simple version of the back-end service StoreNode.

This service will handle all business logic that runs behind the scene.

Other front-end apps (like web-page or mobile apps) will connect to StoreNode.

In StoreNode, I intend to implement single-thread business logic to make sure the integrity and correctness of data.

2. So to scale up, we need to enhance StoreNode to handle a specific range Ids of Clothing Item from configuration at runtime.

Then we can deploy multiple StoreNode services. 

There is also proxy/routing service in the middle to route incoming request to appropriate StoreNode services.

3. For the next level of scale-up, the specific range of clothing Ids should be declared and handled in 'single-thread business logic' level not in service level. 

So we can have multiple 'single-thread business logic' in one StoreNode, then multiple StoreNode.



