
public class Customer {
	int type; 
	String name; 
	int maxNights;
	int maxTools; 
	
	Customer(int type, String name, int maxNights, int maxTools)
	{
		setType(type); 
		setName(name); 
		setMaxNights(maxNights); 
		setMaxTools(maxTools); 
	}
	
	public int getType()
	{
		return type; 
	}
	public void setType(int type)
	{
		this.type = type; 
	}
	public String getName()
	{
		return name; 
	}
	public void setName(String name)
	{
		this.name = name; 
	}
	public int getMaxNights()
	{
		return maxNights; 
	}
	public void setMaxNights(int nights)
	{
		maxNights = nights; 
	}
	public int getMaxTools()
	{
		return maxTools; 
	}
	public void setMaxTools(int tools)
	{
		maxTools = tools; 
	}
	
}
