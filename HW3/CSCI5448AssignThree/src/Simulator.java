import java.util.List;
import java.util.Random;

public class Simulator {
	Store ourStore;
	Random rand;
	
	Simulator(){
		ourStore = new Store();
		rand = new Random();
	}
	
	public void run(){
		for(int day = 1; day < 36; day++) {
			ourStore.checkReturns(day);
			List<Tool> toolsAvailable = ourStore.checkInventory();
			
			if(ourStore.open()) {
				List<Customer> availableCustomers = ourStore.generateEligibleCustomers();
				if(availableCustomers.size() > 1) {
					int numOfCustomers = rand.nextInt(availableCustomers.size()/2) + 1;
					while(numOfCustomers > 0) {
						if(ourStore.checkInventory().size() > 0) {
							int customerIndex = rand.nextInt(availableCustomers.size() - 1) + 1;
							Customer currentCustomer = availableCustomers.get(customerIndex);
							ourStore.assist(currentCustomer, day);
							
						}
						numOfCustomers--; 
					}
				}
				else {
					//next day
				}
			}
		}
		
		ourStore.getReport().calculateTotalProfit(); 
		System.out.println("PRINTING ALL RENTALS"); 
		System.out.println(ourStore.getReport().toString());
		System.out.println("PRINTING CURRENT RENTALS"); 
		ourStore.getReport().currentToolsRented(); 
		ourStore.getReport().showTotalProfit();
		ourStore.getReport().getToolsInStore(ourStore.getInventory());

	}
}
