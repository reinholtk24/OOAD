import java.util.*; 

public class Report {
	private double totalProfit; 
	private List<Tool> toolsInStore;
	private List<Rental> totalRentals;
	
	public Report(){
		totalProfit = 0.0; 
		toolsInStore = new ArrayList<Tool>(); 
		totalRentals = new ArrayList<Rental>(); 
	}
	
	public double calculateTotalProfit(){
		double total = 0.0; 
		
		for(Rental r: totalRentals){
			totalProfit+=r.getTotal(); 
		}
		
		return total; 
	}
	
	public List<Tool> getToolsForReturn(int day)
	{
		List<Tool> toolsBeingReturned = new ArrayList<Tool>(); 
		
		for(Rental r : totalRentals) {
			if(r.getReturnDay() == day) {
				r.setRentStatus(false);
				for(Tool t: r.getTools()) {
					toolsBeingReturned.add(t); 
				}
			}
			else {
				
			}
		}
		
		return toolsBeingReturned; 
	}
	
	//This should only be called at the end of the program!! 
	public void getToolsInStore(Inventory storeInventory){
		for(Tool t : storeInventory.list()){
			toolsInStore.add(t); 
			System.out.println(String.format("Tool: " + t.getName() + " Price: " + t.getPrice()));
		}
	}
	
	public void addRental(Rental r){
		totalRentals.add(r); 
	}
	
	public void allToolsRented(){
		for(Rental r : totalRentals){
			System.out.println(r.toString()); 
		}
	} 		
	
	public void printRentalsForCustomer(Customer c) {
		for(Rental r: totalRentals) {
			if(r.getCustomer() == c.getName()) {
				System.out.println(r.toString());  
			}
		}
	}
	
	public int numToolsAvailableForRent(Customer c) {
		int numOfTools = 0; 		
		for(Rental r: totalRentals) {
			if(r.getRentStatus() == true) {
				if(r.getCustomer() == c.getName()) {
					numOfTools=numOfTools +r.getTools().size(); 
				}
				
			}
		}
		
		System.out.println("numToolsAvailableForRent(Customer c) -> numOfTools: " + numOfTools);
		System.out.println("numToolsAvailableForRent(Customer c) -> c.getMaxTools(): " + c.getMaxTools());
		
		return c.getMaxTools()-numOfTools; 
	}
	
	public void currentToolsRented(){
		for(Rental r : totalRentals){
			if(r.getRentStatus()){
				System.out.println(r.toString());
			}
			else{
				continue; 
			}
		}
	}
	
	public String toString(){
		allToolsRented(); 
		return String.format("Total Sales: " + totalProfit ); 
	}
	
}
