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

* Breakdown of how customers will be selected
* Let's say we have 5 tools left in the store, what do we do? 
	* Create a pool of eligible customer combinations based on customer min/max tool preferences
	* These are the combinations that would work with 5 tools left 
	* B-Business (3 tools) C-Casual (1-2 tools) R-Regular (3-5 tools) 
		* B,C,C
		* B,C
		* R,C,C
		* R,C
		* R
		* C,C,C
	* Create canditates for each group
		* Comb through each group and ensure the current customer is eligible to rent by checking current rentals to see if the customer would exceed their tool max if they were to rent more tools. 
	* Finally, randomly select a group from the list of eligible customer groupings
	
	
