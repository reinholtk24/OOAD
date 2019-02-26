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
		}
		ourStore.getReport().calculateTotalProfit(); 
		System.out.println(ourStore.getReport().toString());
	}

}
