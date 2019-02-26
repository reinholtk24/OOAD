import java.util.*;

public class Rental {
	private String customerName; 
	private List<Tool> tools; 
	private int nights; 
	private int dayOfRental; 
	private boolean active; 
	private double total; 
	
	
	Rental(String name, List<Tool> tools, int nights, int day, boolean active){
		setCustomer(name); 
		setTools(tools); 
		setNights(nights); 
		setDayOfRental(day); 
		setRentStatus(active); 
		calculateTotal(); 
	}
	
	public String getCustomer(){
		return customerName; 
	}
	public void setCustomer(String name){
		customerName = name; 
	}
	public List<Tool> getTools(){
		return tools; 
	}
	public void setTools(List<Tool> t){
		this.tools = t; 
	}
	public int getNights(){
		return nights; 
	}
	public void setNights(int nights){
		this.nights = nights; 
	}
	public boolean getRentStatus(){
		return active; 
	}
	public void setRentStatus(boolean active){
		this.active = active; 
	}
	public void calculateTotal(){
		double subtotal = 0.0; 
		for(Tool t : tools){
			subtotal+=t.getPrice(); 
		}
		total = subtotal*nights; 
	}
	public double getTotal(){
		return total; 
	}
	public void setDayOfRental(int day){
		dayOfRental = day; 
	}
	public int getReturnDay() {
		return dayOfRental+nights; 
	}
	public String toString(){
		return String.format("Total: " + getTotal() + " Rent Status: " + active + " Customer: " + customerName 
				+ " \n\t Day of Rental: " + dayOfRental + " Nights: " + nights + " Return Day: " + getReturnDay()
				+ "\n\t Number of Tools: " + tools.size()); 
	}
	
}
