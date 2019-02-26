import java.util.ArrayList;
import java.util.List;
import java.util.Random;

public class Store {
	private List<Customer> customers;
	private Inventory inventory;
	private Report report;
	private boolean isOpen;
	
	public Store() {
		inventory = new Inventory(); 
		report = new Report(); 
		customers = new ArrayList<Customer>();
		Customer c1 = new Casual("Monica");
		Customer c2 = new Casual("Chandler");
		Customer c3 = new Casual("Phoebe");
		Customer b1 = new Business("Joey");
		Customer b2 = new Business("Ross");
		Customer b3 = new Business("Rachel");
		Customer r1 = new Regular("Paige");
		Customer r2 = new Regular("Piper");
		Customer r3 = new Regular("Chris");
		Customer r4 = new Regular("Wyatt");
		
		customers.add(c1);
		customers.add(c2);
		customers.add(c3);
		customers.add(b1);
		customers.add(b2);
		customers.add(b3);
		customers.add(r1);
		customers.add(r2);
		customers.add(r3);
		customers.add(r4);
				
	}
	
	public Inventory getInventory(){
		return inventory; 
	}
	
	public void assist(Customer customer, int day) {
		Random rand = new Random();
		int numToolsCustomerCanRent = report.numToolsAvailableForRent(customer);
		if(customer.getType() == "Business" && inventory.getNumOfTools() < 3) {
			System.out.println("Spaghetti"); 
		}
		else {
			if(numToolsCustomerCanRent > 0) {
				int numToolsCustomerWillRent;  
				if(numToolsCustomerCanRent == customer.getMinTools()){
					numToolsCustomerWillRent = customer.getMinTools(); 
				}
				else {
					System.out.println("Day: " + day); 
					System.out.println(customer.toString()); 
					System.out.println("numToolsCustomerCanRent: " + numToolsCustomerCanRent);
					System.out.println("customer.getMinTools(): " + customer.getMinTools());
					System.out.println("customer.getMaxTools(): " + customer.getMaxTools());
					report.printRentalsForCustomer(customer);
					numToolsCustomerWillRent = rand.nextInt((numToolsCustomerCanRent - customer.getMinTools()) + 1) + customer.getMinTools();	
				}
				List<Tool> toolsRented = new ArrayList();
				if(numToolsCustomerWillRent > inventory.getNumOfTools()){
					numToolsCustomerWillRent = inventory.getNumOfTools(); 
				}
				for(int i = 0; i < numToolsCustomerWillRent; i++) {
					System.out.println("Inventory: " + inventory.list().size()); 
					int numTool = rand.nextInt(inventory.getNumOfTools())+1;
					numTool = numTool-1; 
					Tool t = inventory.list().get(numTool);
					inventory.removeTool(t);
					toolsRented.add(t);
				}
				System.out.println("maxNights: " + customer.getMaxNights()); 
				System.out.println("minNights: " + customer.getMinNights());
				System.out.println("CustomerType: " + customer.getType()) ;
				int nights = rand.nextInt((customer.getMaxNights() - customer.getMinNights()) + 1) + customer.getMinNights();
				Rental currRental = new Rental(customer.getName(), toolsRented, nights, day, true);
				System.out.println(currRental.toString()); 
				report.addRental(currRental);
			}
			else {
				System.out.println("Customer cannot rent"); 
			}
		}
	}
	
	public void checkReturns(int day) {
		List<Tool> toolsReturned = report.getToolsForReturn(day);
		for(Tool t: toolsReturned) {
			inventory.addTool(t);
		}
		
	}
	
	public List<Tool> checkInventory() {
		if (inventory.list().size() > 0)
			isOpen = true;
		else 
			isOpen = false;
		return inventory.list();
		
	}
	
	public boolean open() {
		return isOpen;
	}
	
	public List<Customer> generateEligibleCustomers() {
		List<Customer> availableCustomers = new ArrayList<Customer>();
		for (Customer c: customers) {
			if (report.numToolsAvailableForRent(c) > 0)
				availableCustomers.add(c);
		}
		return availableCustomers;
	}
	
	public Report getReport() {
		return report;
	}
}
