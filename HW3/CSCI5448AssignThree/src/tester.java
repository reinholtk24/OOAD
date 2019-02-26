import java.util.List;
import java.util.Random;

public class tester {

	public static void main(String[] args) {
		Store ourStore = new Store();
		Random rand = new Random();
		for(int day = 1; day < 35; day++) {
			ourStore.checkReturns(day);
			List<Tool> toolsAvailable = ourStore.checkInventory();
			if(ourStore.open()) {
				List<Customer> availableCustomers = ourStore.generateEligibleCustomers();
				if(availableCustomers.size() > 1) {
					int numOfCustomers = rand.nextInt(availableCustomers.size()) + 1;
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
					System.out.println("no customers available."); 
				}
					
			}
		}
		ourStore.getReport().calculateTotalProfit(); 
		System.out.println(ourStore.getReport().toString());
		ourStore.getReport().getToolsInStore(ourStore.getInventory());
	}

}
