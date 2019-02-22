This is a basic algorithm for what the store is responsible for (subject to change) 

* Store 
	* First, the day begins (For example day=1 in a for loop) 
	* Check all rentals and see if any tools are being returned
	* Check inventory to see if the store can open that day
	* Based on inventory, randomly select customers that will be renting 
	* Create rental for each customer 
	* Add rental to the report 

In psuedo code: 
```
for (day = 1; day <= 35; day++){
	store.checkRentals(day) // possibly replenish inventory items once day starts        
	itemsAvailable = store.checkInventory() // we will open or close store based on inventory
	if(store.open() == true){
		currentCustomers = store.generateCustomerList(itemsAvailable) // select eligible customers randomly based on itemsAvailable
		foreach customer in currentCustomers{
			store.assistCustomer(customer) //In here is where we create rentals and add them to the report
		}
	}
	else{
		continue; //to next day 
	}
}
```
