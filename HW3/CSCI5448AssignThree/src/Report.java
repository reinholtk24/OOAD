import java.util.*; 

public class Report {
	double totalProfit; 
	List<Tool> toolsInStore;
	List<Rental> totalRentals;
	
	Report()
	{
		totalProfit = 0.0; 
		toolsInStore = new ArrayList<Tool>(); 
		totalRentals = new ArrayList<Rental>(); 
	}
	
	public double calculateTotalProfit()
	{
		double total = 0.0; 
		
		for(Rental r: totalRentals)
		{
			totalProfit+=r.getTotal(); 
		}
		
		return total; 
	}
	
	public void getToolsInStore(Inventory storeInventory)
	{
		for(Tool t : storeInventory.list())
		{
			toolsInStore.add(t); 
		}
	}
	
	public void addRental(Rental r)
	{
		totalRentals.add(r); 
	}
	
	public void allToolsRented()
	{
		for(Rental r : totalRentals)
		{
			r.toString(); 
		}
	}
	
	public void currentToolsRented()
	{
		for(Rental r : totalRentals)
		{
			if(r.getRentStatus())
			{
				r.toString();
			}
			else
			{
				continue; 
			}
		}
	}
	
}
