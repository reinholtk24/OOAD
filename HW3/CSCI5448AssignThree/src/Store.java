import java.util.ArrayList;
import java.util.List;

public class Store {
	private List<Customer> customers;
	private Inventory inventory;
	private Report report;
	private boolean isOpen;
	
	public Store() {
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
	
	public void assistCustomer(Customer customer) {
		
	}
	
	public void checkRentals(int day) {
		List<Tool> toolsReturned = report.getToolsForReturn(day);
		for(Tool t: toolsReturned) {
			inventory.addTool(t);
		}
		
	}
	
	public List<Tool> checkInventory() {
		
		return inventory.list();
		
	}
	
	public boolean open() {
		return isOpen;
	}
	
	public List<Customer> generateEligibleCustomers(int itemsAvailable) {
		List<Customer> custs = new ArrayList<Customer>();
		if(itemsAvailable <= 2) {
			for (Customer c: customers) {
				if (c.getType().equals("Casual")) {
					custs.add(c);
				}		
			}
			return custs;
		}else {
			return customers;
		}
	}
}
