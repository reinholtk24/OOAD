
//just adding a little bit of stuff for testing
//Please don't get mad at me :/ :) 

public class Tool {
	double price; 
	String name; 
	
	public Tool(double price, String name){
		setPrice(price); 
		setName(name); 
	}

	public void setPrice(double price)
	{
		this.price = price; 
	}
	
	public double getPrice()
	{
		return price; 
	}
	
	public void setName(String name)
	{
		this.name = name; 
	}
	
	public String getName()
	{
		return name; 
	}
}
